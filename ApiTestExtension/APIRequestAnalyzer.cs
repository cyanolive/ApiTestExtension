using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ApiTestExtension.MockResponseCallbacks;

namespace ApiTestExtension
{
    class APIRequestAnalyzer
    {
        public static MockResponseRules analyzeConsoleAPI(String responseBody, ILogger logger)
        {
            JObject jobject = (JObject)JsonConvert.DeserializeObject(responseBody);

            String ruleName = "";
            String url = jobject["url"].ToString();
            ApiTestExtension.MockResponseRules.APIPatternType urlPatternType = MockResponseRules.APIPatternType.NORMAL;
            ApiTestExtension.MockResponseRules.OpeartionType ruleType = MockResponseRules.OpeartionType.NEW_RESPONSE;
            JToken data = null;
            if (!(jobject["name"] == null))
            {
                ruleName = jobject["name"].ToString();
            }
            if (!(jobject["name"] == null))
            {
                url = jobject["url"].ToString();
            }
            if (!(jobject["data"] == null))
            {
                data = jobject["data"];
            }

            if (!(jobject["urlType"] == null))
            {
                switch (jobject["urlType"].ToString())
                {
                    case "0":
                        urlPatternType = MockResponseRules.APIPatternType.NORMAL;
                        break;
                    case "1":
                        urlPatternType = MockResponseRules.APIPatternType.REGULAR;
                        break;
                    default:
                        urlPatternType = MockResponseRules.APIPatternType.NORMAL;
                        break;
                }
            }

            if (!(jobject["ruleType"] == null))
            {
                switch (jobject["ruleType"].ToString())
                {
                    case "0":
                        ruleType = MockResponseRules.OpeartionType.NEW_RESPONSE;
                        break;
                    case "2":
                        ruleType = MockResponseRules.OpeartionType.REPLACE_RESPONSE;
                        break;
                    case "100":
                        ruleType = MockResponseRules.OpeartionType.REMOVE;
                        break;
                    default:
                        ruleType = MockResponseRules.OpeartionType.NEW_RESPONSE;
                        break;
                }
            }

            if (ruleType == MockResponseRules.OpeartionType.NEW_RESPONSE)
            {
                if (data == null)
                {
                    logger.Log("With no Response to show, please check the rule.");
                    return null;
                }
                NewResponseCallback responseCallback = new NewResponseCallback(data.ToString());
                MockResponseRules rule = new MockResponseRules(ruleName, url, ruleType, urlPatternType, logger, responseCallback);
                return rule;
            }

            if (ruleType == MockResponseRules.OpeartionType.REMOVE)
            {
                return new MockResponseRules(ruleName, ruleType, logger);
            }

            return null;
        }
    }
}
