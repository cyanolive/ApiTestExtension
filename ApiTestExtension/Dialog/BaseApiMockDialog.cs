using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.XMLAnalyzer;
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
        }
    }
}
