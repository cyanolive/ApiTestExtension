using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.XMLAnalyzer;
using ApiTestExtension.Dialog.ModRespDialogs;
using ApiTestExtension.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiTestExtension.Dialog
{
    public partial class BaseApiMockDialog : Form
    {
        protected Form parentForm;
        protected String title;
        protected String apiUrl;
        protected CommonData commonData;
        protected XMLApiItem xmlItem;
        public Dictionary<TreeNode, XMLResponseItem> nodeMap = new Dictionary<TreeNode, XMLResponseItem>();

        public String Title
        {
            get { return title; }
            set
            {
                title = value;
                this.Text = value;
            }
        }

        public String ApiUrl
        {
            get { return apiUrl; }
            set { apiUrl = value; }
        }

        public CommonData CommonData
        {
            get { return commonData; }
            set { commonData = value; }
        }

        public BaseApiMockDialog()
        {
            InitializeComponent();
        }

        public BaseApiMockDialog(Form parentForm, XMLApiItem xmlItem)
        {
            this.parentForm = parentForm;
            this.xmlItem = xmlItem;
            this.Location = new Point(parentForm.Location.X + 100, parentForm.Location.Y + 100);
            InitializeComponent();
            initTreeView();
        }

        private void initTreeView()
        {
            if (xmlItem.Response.Type == ResponseType.JSON || xmlItem.Response.Type == ResponseType.JSON_LIST)
            {
                foreach (XMLResponseItem item in xmlItem.Response.Items.Values)
                {
                    treeView1.Nodes.Add(xmlResponseItemToTreeNode(item));
                }
            }
        }

        private TreeNode xmlResponseItemToTreeNode(XMLResponseItem item)
        {
            TreeNode node = new TreeNode();
            node.Text = item.ItemName;
            node.ToolTipText = item.ItemRemark;
            switch (item.Type)
            {
                case ResponseItemType.INT:
                case ResponseItemType.STRING:
                    break;
                case ResponseItemType.DICT:
                    foreach (XMLResponseItem subitem in item.SubItems.Values)
                    {
                        node.Nodes.Add(xmlResponseItemToTreeNode(subitem));
                    }
                    break;
                case ResponseItemType.LIST:
                    if (item.IsEntryList)
                    {
                        foreach (XMLResponseItem subitem in item.SubItems.Values)
                        {
                            node.Nodes.Add(xmlResponseItemToTreeNode(subitem));
                        }
                    }
                    break;
                default:
                    break;
            }
            switch (item.matchResult)
            {
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.DICT_MATCHED:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.INT_MATCHED:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.LIST_ENTRY_MATCHED:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.LIST_STRING_MATCHED:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.STRING_MATCHED:
                    node.BackColor = Color.LightGreen;
                    break;
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.DICT_NULL:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.LIST_NULL:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.NULL_MATCHED:
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.LIST_OR_DICT_PARTLY_MATCHED:
                    node.BackColor = Color.Yellow;
                    break;
                case DataStructure.Matcher.JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH:
                    node.BackColor = Color.White;
                    break;
                default:
                    node.BackColor = Color.Red;
                    break;
            }
            switch (item.Type)
            {
                case ResponseItemType.STRING:
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    break;
                case ResponseItemType.INT:
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    break;
                case ResponseItemType.LIST:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    break;
                case ResponseItemType.DICT:
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    break;
                default:
                    break;
            }
            nodeMap.Add(node, item);
            node.ContextMenuStrip = cmsTreeNode;
            return node;
        }

        private void rbReq_Click(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "rbReqNoRestrict":
                    tbReqExact.Enabled = false;
                    tbReqContains.Enabled = false;
                    tbReqReg.Enabled = false;
                    panelReqRule.Enabled = false;
                    break;
                case "rbReqExact":
                    tbReqExact.Enabled = true;
                    tbReqContains.Enabled = false;
                    tbReqReg.Enabled = false;
                    panelReqRule.Enabled = false;
                    break;
                case "rbReqContains":
                    tbReqExact.Enabled = false;
                    tbReqContains.Enabled = true;
                    tbReqReg.Enabled = false;
                    panelReqRule.Enabled = false;
                    break;
                case "rbReqReg":
                    tbReqExact.Enabled = false;
                    tbReqContains.Enabled = false;
                    tbReqReg.Enabled = true;
                    panelReqRule.Enabled = false;
                    break;
                case "rbReqRule":
                    tbReqExact.Enabled = false;
                    tbReqContains.Enabled = false;
                    tbReqReg.Enabled = false;
                    panelReqRule.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void tsmiModValue_Click(object sender, EventArgs e)
        {
            ModValueDialog dialog = new ModValueDialog();
            dialog.ShowDialog(this);
        }
    }
}
