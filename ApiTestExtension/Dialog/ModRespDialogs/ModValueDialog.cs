using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiTestExtension.Dialog.ModRespDialogs
{
    public partial class ModValueDialog : Form
    {
        public ModValueDialog()
        {
            InitializeComponent();
        }

        private void cbNull_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNull.Checked)
            {
                tbValue.Enabled = false;
            }
            else
            {
                tbValue.Enabled = true;
            }
        }
    }
}
