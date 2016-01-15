using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.XMLAnalyzer;
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
        protected Dictionary<TreeNode, XMLResponseItem> nodeMap = new Dictionary<TreeNode, XMLResponseItem>();

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

        public void initTreeView()
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
            nodeMap.Add(node, item);
            node.ContextMenuStrip = cmsTreeNode;
            return node;
        }
    }
}
