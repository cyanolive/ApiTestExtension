using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.XMLAnalyzer;
using ApiTestExtension.Dialog.APIMockDialogs.Goods;
using ApiTestExtension.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiTestExtension.Dialog
{
    public partial class APIAutoTest : Form
    {
        ILogger logger;

        public APIAutoTest(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        private void miList_Click(object sender, EventArgs e)
        {
            XMLApiItem apiItem = FiddlerExtension.ApiItems[((ToolStripMenuItem)sender).Name];
            BaseApiMockDialog APIDialog = new BaseApiMockDialog(this, apiItem);
            APIDialog.Title = apiItem.Function;
            APIDialog.ApiUrl = apiItem.Apiurl;
            APIDialog.ShowDialog(this);
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            if (fbdLoadXML.ShowDialog() == DialogResult.OK)
            {
                String xmlFolderPath = fbdLoadXML.SelectedPath;
                List<FileInfo> xmlFiles = getXMLFiles(xmlFolderPath);
                try
                {
                    FiddlerExtension.ApiItems = getApiItems(xmlFiles);
                    FiddlerExtension.Settings.xmlFilePath = xmlFolderPath;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.GetType().ToString());
                }
                toolStripStatusLabel.Text = "已加载文件夹" + xmlFolderPath + "下的全部XML文件,共加载" + xmlFiles.Count + "个XML文件";
                initMenu();
            }
        }

        public static List<FileInfo> getXMLFiles(String xmlFolderPath)
        {
            List<FileInfo> xmlFiles = new List<FileInfo>();
            DirectoryInfo xmlFolder = new DirectoryInfo(xmlFolderPath);
            foreach (DirectoryInfo di in xmlFolder.GetDirectories())
            {
                foreach (DirectoryInfo subdi in di.GetDirectories())
                {
                    foreach (FileInfo fi in subdi.GetFiles())
                    {
                        if (fi.FullName.EndsWith(".xml"))
                        {
                            xmlFiles.Add(fi);
                        }
                    }
                }
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.FullName.EndsWith(".xml"))
                    {
                        xmlFiles.Add(fi);
                    }
                }
            }
            foreach (FileInfo fi in xmlFolder.GetFiles())
            {
                if (fi.FullName.EndsWith(".xml"))
                {
                    xmlFiles.Add(fi);
                }
            }
            return xmlFiles;
        }

        public static Dictionary<String, XMLApiItem> getApiItems(List<FileInfo> xmlFiles)
        {
            Dictionary<String, XMLApiItem> apiItems = new Dictionary<String, XMLApiItem>();
            foreach (FileInfo fi in xmlFiles)
            {
                foreach (XMLApiItem item in XMLUtil.analyzeXML(fi).Values)
                {
                    apiItems[item.Apiurl] = item;
                }
            }
            return apiItems;
        }

        private void initMenu()
        {
            if (FiddlerExtension.ApiItems.Count == 0)
            {
                this.menuStrip.Items.Clear();
            }
            else
            {
                foreach (XMLApiItem item in FiddlerExtension.ApiItems.Values)
                {
                    String product = item.Product;
                    ToolStripMenuItem productItem = null;
                    bool productMenuExists = false;
                    String menuFolder = item.MenuFolder;
                    ToolStripMenuItem menuFolderItem = null;
                    bool menuFolderMenuExists = false;
                    String menuText = item.MenuText;
                    bool menuMenuItemExists = false;

                    //创建product项
                    foreach (ToolStripMenuItem tsmi in menuStrip.Items)
                    {
                        if (tsmi.Text.Equals(product))
                        {
                            productMenuExists = true;
                            productItem = tsmi;
                            break;
                        }
                    }
                    if (!productMenuExists)
                    {
                        ToolStripMenuItem productMenuItem = new ToolStripMenuItem();
                        menuStrip.Items.Add(productMenuItem);
                        productMenuItem.Text = product;
                        productItem = productMenuItem;
                    }

                    //创建文件夹
                    foreach (ToolStripMenuItem tsmi in productItem.DropDownItems)
                    {
                        if (tsmi.Text.Equals(menuFolder))
                        {
                            menuFolderMenuExists = true;
                            menuFolderItem = tsmi;
                            break;
                        }
                    }
                    if (!menuFolderMenuExists)
                    {
                        ToolStripMenuItem menuFolderMenuItem = new ToolStripMenuItem();
                        productItem.DropDownItems.Add(menuFolderMenuItem);
                        menuFolderMenuItem.Text = menuFolder;
                        menuFolderItem = menuFolderMenuItem;
                    }

                    //创建API项
                    foreach (ToolStripMenuItem tsmi in menuFolderItem.DropDownItems)
                    {
                        if (tsmi.Text.Equals(menuText))
                        {
                            menuMenuItemExists = true;
                            switch (item.Response.matchResult)
                            {
                                case DataStructure.Matcher.JsonXMLMatcher.MatchResult.MATCH:
                                    tsmi.BackColor = Color.LightGreen;
                                    break;
                                case DataStructure.Matcher.JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL:
                                case DataStructure.Matcher.JsonXMLMatcher.MatchResult.MATCH_PARTLY:
                                    tsmi.BackColor = Color.LightBlue;
                                    break;
                                case DataStructure.Matcher.JsonXMLMatcher.MatchResult.NOT_MATCH:
                                    tsmi.BackColor = Color.Red;
                                    break;
                                default:
                                    tsmi.BackColor = Color.White;
                                    break;
                            }
                            break;
                        }
                    }
                    if (!menuMenuItemExists)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Text = menuText;
                        menuItem.Name = item.Apiurl;
                        menuItem.Click += new System.EventHandler(miList_Click);
                        menuFolderItem.DropDownItems.Add(menuItem);

                        switch(item.Response.matchResult)
                        {
                            case DataStructure.Matcher.JsonXMLMatcher.MatchResult.MATCH:
                                menuItem.BackColor = Color.LightGreen;
                                break;
                            case DataStructure.Matcher.JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL:
                            case DataStructure.Matcher.JsonXMLMatcher.MatchResult.MATCH_PARTLY:
                                menuItem.BackColor = Color.LightBlue;
                                break;
                            case DataStructure.Matcher.JsonXMLMatcher.MatchResult.NOT_MATCH:
                                menuItem.BackColor = Color.Red;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void APIAutoTest_Load(object sender, EventArgs e)
        {
            initMenu();
        }
    }
}
