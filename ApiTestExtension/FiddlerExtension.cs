using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using ApiTestExtension.Dialog;
using ApiTestExtension.DataStructure;
using Newtonsoft.Json.Linq;
using ApiTestExtension.DataStructure.XMLAnalyzer;
using ApiTestExtension.DataStructure.JsonAnalyzer;
using ApiTestExtension.Utils;
using System.Text.RegularExpressions;
using ApiTestExtension.DataStructure.Matcher;

[assembly: Fiddler.RequiredVersion("2.4.9.3")]
namespace ApiTestExtension
{
    public class FiddlerExtension : IAutoTamper3, IDisposable
    {
        private MenuItem _mnuApiAutoTest;
        private MenuItem _miApiAutoTestEnabled;
        private MenuItem _miOpenRulesDialog;
        private MenuItem _miLogEnabled;

        private bool bAutotestEnabled = false;
        private bool bLogEnabled = false;
        private static ILogger logger;
        private String strModifyResponseAPI = "autotest/modifyResponse";
        private Dictionary<String, MockResponseRules> rules = new Dictionary<String, MockResponseRules>();
        private APIAutoTest dialog = new APIAutoTest(logger);
        static object locker = new object();
        static Dictionary<String, XMLApiItem> apiItems = new Dictionary<String, XMLApiItem>();

        public static Dictionary<String, XMLApiItem> ApiItems
        {
            get
            {
                return FiddlerExtension.apiItems;
            }
            set
            {
                lock (locker)
                {
                    FiddlerExtension.apiItems = value;
                }
            }
        }

        #region Settings
        public static class Settings
        {
            private const string prefix = "ApiTestExtension.";
            public static bool verboseLogging
            {
                get
                {
                    return Fiddler.FiddlerApplication.Prefs.GetBoolPref(prefix + "verboseLogging", false);
                }
                set
                {
                    Fiddler.FiddlerApplication.Prefs.SetBoolPref(prefix + "verboseLogging", value);
                }
            }

            public static String xmlFilePath
            {
                get
                {
                    return Fiddler.FiddlerApplication.Prefs.GetStringPref(prefix + "xmlFilePath", "");
                }
                set
                {
                    Fiddler.FiddlerApplication.Prefs.SetStringPref(prefix + "xmlFilePath", value);
                }
            }
        }
        #endregion

        #region InitMenu
        private void EnableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            MenuItem oSender = (sender as MenuItem);
            oSender.Checked = !oSender.Checked;

            bAutotestEnabled = _miApiAutoTestEnabled.Checked;
            if (bAutotestEnabled)
            {
                _mnuApiAutoTest.Text = "&APIAutoTest-ON";
                if (!Settings.xmlFilePath.Equals(""))
                {
                    ApiItems = APIAutoTest.getApiItems(APIAutoTest.getXMLFiles(Settings.xmlFilePath));
                }
            }
            else
            {
                _mnuApiAutoTest.Text = "&APIAutoTest-OFF";
            }
        }

        private void EnableLog_CheckedChanged(object sender, EventArgs e)
        {
            MenuItem oSender = (sender as MenuItem);
            oSender.Checked = !oSender.Checked;

            bLogEnabled = _miLogEnabled.Checked;
            Settings.verboseLogging = bLogEnabled;
        }

        private void OpenRulesDialog_Click(object sender, EventArgs e)
        {
            dialog.ShowDialog(FiddlerApplication.UI);
        }

        void initMenus()
        {
            _mnuApiAutoTest = new MenuItem();
            _miApiAutoTestEnabled = new MenuItem();
            _miOpenRulesDialog = new MenuItem();
            _miLogEnabled = new MenuItem();

            _mnuApiAutoTest.Text = "&APIAutoTest";
            _mnuApiAutoTest.MenuItems.Add(0, _miApiAutoTestEnabled);
            _mnuApiAutoTest.MenuItems.Add(1, _miOpenRulesDialog);
            _mnuApiAutoTest.MenuItems.Add(2, _miLogEnabled);

            _miApiAutoTestEnabled.Text = "Enabled";
            _miLogEnabled.Text = "Log Enabled";
            _miOpenRulesDialog.Text = "Config Autotest Rules...";
            _miApiAutoTestEnabled.Click += new EventHandler(EnableMenuItem_CheckedChanged);
            _miLogEnabled.Click += new EventHandler(EnableLog_CheckedChanged);
            _miOpenRulesDialog.Click += new EventHandler(OpenRulesDialog_Click);
        }
        #endregion

        #region Log
        public class FiddlerAppLogger : ILogger
        {
            public void Log(string message)
            {
                if (Settings.verboseLogging)
                {
                    FiddlerApplication.Log.LogString("ApiTestExtension: " + message);
                }
            }
        }
        #endregion

        public FiddlerExtension()
        {
            logger = new FiddlerAppLogger();
            initMenus();
        }

        #region Interface Methods
        public void AutoTamperRequestAfter(Session oSession)
        {

        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (bAutotestEnabled)
            {
                if (oSession.uriContains(strModifyResponseAPI))
                {
                    MockResponseRules rule = APIRequestAnalyzer.analyzeConsoleAPI(Encoding.UTF8.GetString(oSession.RequestBody), logger);
                    oSession.state = SessionStates.Done;
                    oSession["ui-hide"] = "true";
                    if (rule != null)
                    {
                        rules.Add(rule.RuleName, rule);
                    }
                }
            }

        }

        public void AutoTamperResponseAfter(Session oSession)
        {

        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            if (bAutotestEnabled && apiItems != null && oSession.responseCode == 200)
            {
                //foreach (MockResponseRules singleRule in rules.Values)
                //{
                //    if (oSession.uriContains(singleRule.ApiPattern))
                //    {
                //        String orgResponseBody = Encoding.UTF8.GetString(oSession.responseBodyBytes);
                //        oSession.responseBodyBytes = Encoding.UTF8.GetBytes(singleRule.MockedResponse(orgResponseBody));
                //    }
                //}
                foreach (XMLApiItem item in apiItems.Values)
                {
                    if (oSession.uriContains(item.Apiurl) && item.Response.Type == ResponseType.JSON || item.Response.Type == ResponseType.JSON_LIST)
                    {
                        String orgResponseBody = Encoding.UTF8.GetString(oSession.responseBodyBytes);
                        JToken jtResponse = JToken.Parse(orgResponseBody);
                        Dictionary<String, JsonResponseEntry> responseJsonEntry = JsonUtil.analyzeResponseEntry(jtResponse);
                        JsonXMLMatcher matcher = JsonUtil.matchJsonWithXML(responseJsonEntry, item.Response.Items, item.Response.Type == ResponseType.JSON_LIST);
                        item.Response.matchResult = matcher.matchResult;
                        if (matcher.matchResult == JsonXMLMatcher.MatchResult.MATCH)
                        {
                            logger.Log(item.Apiurl + " match result: MATCHED");
                        }
                        else
                        {
                            if (matcher.matchResult == JsonXMLMatcher.MatchResult.NOT_MATCH)
                            {
                                oSession["ui-backcolor"] = "red";
                            }
                            logger.Log(item.Apiurl + " match result:" + matcher.matchResultToString() + "\nroot->\n    " +
                                matcher.ToString().Replace("\n", "\n    "));
                        }
                        String newResponseBody = JsonUtil.assembleJson(responseJsonEntry).ToString();
                        String str = Regex.Replace(newResponseBody.Replace(@"\\", @"\"), @"\s *", "").Replace(",\"", ", \"").Replace("\":", "\": ");
                        oSession.responseBodyBytes = Encoding.Default.GetBytes(str);
                        logger.Log("RessembleJson:\n" + str + "\n");
                    }
                }
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {

        }

        public void OnPeekAtRequestHeaders(Session oSession)
        {

        }

        public void OnPeekAtResponseHeaders(Session oSession)
        {

        }

        public void Dispose()
        {

        }

        public void OnBeforeUnload()
        {

        }

        public void OnLoad()
        {
            FiddlerApplication.UI.mnuMain.MenuItems.Add(_mnuApiAutoTest);
        }
        #endregion
    }
}

