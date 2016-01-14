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

namespace ApiTestExtension.Dialog.APIMockDialogs.Goods
{
    

    public partial class LotteryList : BaseApiMockDialog
    {
        public LotteryList()
        {
            InitializeComponent();
        }

        public LotteryList(Form parentForm, XMLApiItem xmlItem)
            : base(parentForm, xmlItem)
        {
            InitializeComponent();
        }
    }
}
