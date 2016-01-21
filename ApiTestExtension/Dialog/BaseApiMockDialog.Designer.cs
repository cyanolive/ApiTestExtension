namespace ApiTestExtension.Dialog
{
    partial class BaseApiMockDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseApiMockDialog));
            this.rbRespRule = new System.Windows.Forms.RadioButton();
            this.rbRespJson = new System.Windows.Forms.RadioButton();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.panelResp = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.dgvRespRules = new System.Windows.Forms.DataGridView();
            this.dgvtbcRuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcRuleString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ilResponseType = new System.Windows.Forms.ImageList(this.components);
            this.cbRunOnce = new System.Windows.Forms.CheckBox();
            this.btnSubmitRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRuleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRuleID = new System.Windows.Forms.TextBox();
            this.cmsTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiModValue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tssList = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiListAddCopyAt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListAddCustomAt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListDelRange = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCustomize = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCustomize = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelReqRule = new System.Windows.Forms.Panel();
            this.tbReqReg = new System.Windows.Forms.TextBox();
            this.tbReqContains = new System.Windows.Forms.TextBox();
            this.tbReqExact = new System.Windows.Forms.TextBox();
            this.rbReqRule = new System.Windows.Forms.RadioButton();
            this.rbReqReg = new System.Windows.Forms.RadioButton();
            this.rbReqContains = new System.Windows.Forms.RadioButton();
            this.rbReqExact = new System.Windows.Forms.RadioButton();
            this.rbReqNoRestrict = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tssDict = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDictNull = new System.Windows.Forms.ToolStripMenuItem();
            this.panelResp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespRules)).BeginInit();
            this.cmsTreeNode.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbRespRule
            // 
            this.rbRespRule.AutoSize = true;
            this.rbRespRule.Checked = true;
            this.rbRespRule.Location = new System.Drawing.Point(6, 10);
            this.rbRespRule.Name = "rbRespRule";
            this.rbRespRule.Size = new System.Drawing.Size(143, 16);
            this.rbRespRule.TabIndex = 0;
            this.rbRespRule.TabStop = true;
            this.rbRespRule.Text = "按照规则修改Response";
            this.rbRespRule.UseVisualStyleBackColor = true;
            // 
            // rbRespJson
            // 
            this.rbRespJson.AutoSize = true;
            this.rbRespJson.Location = new System.Drawing.Point(6, 367);
            this.rbRespJson.Name = "rbRespJson";
            this.rbRespJson.Size = new System.Drawing.Size(155, 16);
            this.rbRespJson.TabIndex = 1;
            this.rbRespJson.Text = "直接使用下面的Response";
            this.rbRespJson.UseVisualStyleBackColor = true;
            // 
            // rtbResponse
            // 
            this.rtbResponse.Location = new System.Drawing.Point(6, 389);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(738, 95);
            this.rtbResponse.TabIndex = 2;
            this.rtbResponse.Text = "";
            // 
            // panelResp
            // 
            this.panelResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResp.Controls.Add(this.btnDelete);
            this.panelResp.Controls.Add(this.btnMoveDown);
            this.panelResp.Controls.Add(this.btnMoveUp);
            this.panelResp.Controls.Add(this.dgvRespRules);
            this.panelResp.Controls.Add(this.label3);
            this.panelResp.Controls.Add(this.treeView1);
            this.panelResp.Location = new System.Drawing.Point(6, 31);
            this.panelResp.Name = "panelResp";
            this.panelResp.Size = new System.Drawing.Size(738, 330);
            this.panelResp.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(679, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(623, 54);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(42, 23);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(567, 54);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(42, 23);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // dgvRespRules
            // 
            this.dgvRespRules.AllowUserToAddRows = false;
            this.dgvRespRules.AllowUserToDeleteRows = false;
            this.dgvRespRules.AllowUserToResizeColumns = false;
            this.dgvRespRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRespRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcRuleId,
            this.dgvtbcRuleString});
            this.dgvRespRules.Location = new System.Drawing.Point(255, 83);
            this.dgvRespRules.Name = "dgvRespRules";
            this.dgvRespRules.ReadOnly = true;
            this.dgvRespRules.RowTemplate.Height = 23;
            this.dgvRespRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRespRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRespRules.ShowEditingIcon = false;
            this.dgvRespRules.Size = new System.Drawing.Size(476, 242);
            this.dgvRespRules.TabIndex = 2;
            // 
            // dgvtbcRuleId
            // 
            this.dgvtbcRuleId.HeaderText = "序号";
            this.dgvtbcRuleId.Name = "dgvtbcRuleId";
            this.dgvtbcRuleId.ReadOnly = true;
            // 
            // dgvtbcRuleString
            // 
            this.dgvtbcRuleString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvtbcRuleString.HeaderText = "规则内容";
            this.dgvtbcRuleString.Name = "dgvtbcRuleString";
            this.dgvtbcRuleString.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(255, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "在左边的树结构中右键选择需要操作的项进行操作，请按照实际顺序依次完成操作，然后会生成操作字符串生成规则在下面的列表中";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ilResponseType;
            this.treeView1.Location = new System.Drawing.Point(-1, -1);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(250, 330);
            this.treeView1.TabIndex = 0;
            // 
            // ilResponseType
            // 
            this.ilResponseType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilResponseType.ImageStream")));
            this.ilResponseType.TransparentColor = System.Drawing.Color.Transparent;
            this.ilResponseType.Images.SetKeyName(0, "String.png");
            this.ilResponseType.Images.SetKeyName(1, "Int.png");
            this.ilResponseType.Images.SetKeyName(2, "List.png");
            this.ilResponseType.Images.SetKeyName(3, "Dict.png");
            // 
            // cbRunOnce
            // 
            this.cbRunOnce.AutoSize = true;
            this.cbRunOnce.Location = new System.Drawing.Point(386, 11);
            this.cbRunOnce.Name = "cbRunOnce";
            this.cbRunOnce.Size = new System.Drawing.Size(84, 16);
            this.cbRunOnce.TabIndex = 4;
            this.cbRunOnce.Text = "仅运行一次";
            this.cbRunOnce.UseVisualStyleBackColor = true;
            // 
            // btnSubmitRule
            // 
            this.btnSubmitRule.Location = new System.Drawing.Point(697, 13);
            this.btnSubmitRule.Name = "btnSubmitRule";
            this.btnSubmitRule.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitRule.TabIndex = 5;
            this.btnSubmitRule.Text = "生成规则";
            this.btnSubmitRule.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "规则名称";
            // 
            // tbRuleName
            // 
            this.tbRuleName.Location = new System.Drawing.Point(214, 9);
            this.tbRuleName.Name = "tbRuleName";
            this.tbRuleName.Size = new System.Drawing.Size(155, 21);
            this.tbRuleName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "规则ID";
            // 
            // tbRuleID
            // 
            this.tbRuleID.Enabled = false;
            this.tbRuleID.Location = new System.Drawing.Point(59, 7);
            this.tbRuleID.Name = "tbRuleID";
            this.tbRuleID.Size = new System.Drawing.Size(67, 21);
            this.tbRuleID.TabIndex = 7;
            // 
            // cmsTreeNode
            // 
            this.cmsTreeNode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmsTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModValue,
            this.tsmiDel,
            this.tssList,
            this.tsmiListAddCopyAt,
            this.tsmiListAddCustomAt,
            this.tsmiListDelRange,
            this.tssDict,
            this.tsmiDictNull,
            this.tssCustomize,
            this.tsmiCustomize});
            this.cmsTreeNode.Name = "cmsTreeNode";
            this.cmsTreeNode.ShowImageMargin = false;
            this.cmsTreeNode.Size = new System.Drawing.Size(162, 198);
            // 
            // tsmiModValue
            // 
            this.tsmiModValue.Name = "tsmiModValue";
            this.tsmiModValue.Size = new System.Drawing.Size(161, 22);
            this.tsmiModValue.Text = "修改该项的值";
            this.tsmiModValue.Click += new System.EventHandler(this.tsmiModValue_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(161, 22);
            this.tsmiDel.Text = "删除该项";
            // 
            // tssList
            // 
            this.tssList.Name = "tssList";
            this.tssList.Size = new System.Drawing.Size(158, 6);
            // 
            // tsmiListAddCopyAt
            // 
            this.tsmiListAddCopyAt.Name = "tsmiListAddCopyAt";
            this.tsmiListAddCopyAt.Size = new System.Drawing.Size(161, 22);
            this.tsmiListAddCopyAt.Text = "复制List指定项到...";
            // 
            // tsmiListAddCustomAt
            // 
            this.tsmiListAddCustomAt.Name = "tsmiListAddCustomAt";
            this.tsmiListAddCustomAt.Size = new System.Drawing.Size(161, 22);
            this.tsmiListAddCustomAt.Text = "添加自定义项到...";
            // 
            // tsmiListDelRange
            // 
            this.tsmiListDelRange.Name = "tsmiListDelRange";
            this.tsmiListDelRange.Size = new System.Drawing.Size(161, 22);
            this.tsmiListDelRange.Text = "删除List子项";
            // 
            // tssCustomize
            // 
            this.tssCustomize.Name = "tssCustomize";
            this.tssCustomize.Size = new System.Drawing.Size(158, 6);
            // 
            // tsmiCustomize
            // 
            this.tsmiCustomize.Name = "tsmiCustomize";
            this.tsmiCustomize.Size = new System.Drawing.Size(161, 22);
            this.tsmiCustomize.Text = "使用自定义Json替换";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(758, 514);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelReqRule);
            this.tabPage1.Controls.Add(this.tbReqReg);
            this.tabPage1.Controls.Add(this.tbReqContains);
            this.tabPage1.Controls.Add(this.tbReqExact);
            this.tabPage1.Controls.Add(this.rbReqRule);
            this.tabPage1.Controls.Add(this.rbReqReg);
            this.tabPage1.Controls.Add(this.rbReqContains);
            this.tabPage1.Controls.Add(this.rbReqExact);
            this.tabPage1.Controls.Add(this.rbReqNoRestrict);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(750, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request条件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelReqRule
            // 
            this.panelReqRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReqRule.Location = new System.Drawing.Point(17, 192);
            this.panelReqRule.Name = "panelReqRule";
            this.panelReqRule.Size = new System.Drawing.Size(714, 290);
            this.panelReqRule.TabIndex = 3;
            // 
            // tbReqReg
            // 
            this.tbReqReg.Enabled = false;
            this.tbReqReg.Location = new System.Drawing.Point(129, 119);
            this.tbReqReg.Name = "tbReqReg";
            this.tbReqReg.Size = new System.Drawing.Size(602, 21);
            this.tbReqReg.TabIndex = 2;
            // 
            // tbReqContains
            // 
            this.tbReqContains.Enabled = false;
            this.tbReqContains.Location = new System.Drawing.Point(129, 83);
            this.tbReqContains.Name = "tbReqContains";
            this.tbReqContains.Size = new System.Drawing.Size(602, 21);
            this.tbReqContains.TabIndex = 2;
            // 
            // tbReqExact
            // 
            this.tbReqExact.Enabled = false;
            this.tbReqExact.Location = new System.Drawing.Point(129, 47);
            this.tbReqExact.Name = "tbReqExact";
            this.tbReqExact.Size = new System.Drawing.Size(602, 21);
            this.tbReqExact.TabIndex = 2;
            // 
            // rbReqRule
            // 
            this.rbReqRule.AutoSize = true;
            this.rbReqRule.Location = new System.Drawing.Point(17, 157);
            this.rbReqRule.Name = "rbReqRule";
            this.rbReqRule.Size = new System.Drawing.Size(83, 16);
            this.rbReqRule.TabIndex = 1;
            this.rbReqRule.Text = "按规则筛选";
            this.rbReqRule.UseVisualStyleBackColor = true;
            this.rbReqRule.Click += new System.EventHandler(this.rbReq_Click);
            // 
            // rbReqReg
            // 
            this.rbReqReg.AutoSize = true;
            this.rbReqReg.Location = new System.Drawing.Point(17, 121);
            this.rbReqReg.Name = "rbReqReg";
            this.rbReqReg.Size = new System.Drawing.Size(89, 16);
            this.rbReqReg.TabIndex = 1;
            this.rbReqReg.Text = "URL正则匹配";
            this.rbReqReg.UseVisualStyleBackColor = true;
            this.rbReqReg.Click += new System.EventHandler(this.rbReq_Click);
            // 
            // rbReqContains
            // 
            this.rbReqContains.AutoSize = true;
            this.rbReqContains.Location = new System.Drawing.Point(17, 85);
            this.rbReqContains.Name = "rbReqContains";
            this.rbReqContains.Size = new System.Drawing.Size(89, 16);
            this.rbReqContains.TabIndex = 1;
            this.rbReqContains.Text = "URL部分匹配";
            this.rbReqContains.UseVisualStyleBackColor = true;
            this.rbReqContains.Click += new System.EventHandler(this.rbReq_Click);
            // 
            // rbReqExact
            // 
            this.rbReqExact.AutoSize = true;
            this.rbReqExact.Location = new System.Drawing.Point(17, 49);
            this.rbReqExact.Name = "rbReqExact";
            this.rbReqExact.Size = new System.Drawing.Size(89, 16);
            this.rbReqExact.TabIndex = 1;
            this.rbReqExact.Text = "URL完全匹配";
            this.rbReqExact.UseVisualStyleBackColor = true;
            this.rbReqExact.Click += new System.EventHandler(this.rbReq_Click);
            // 
            // rbReqNoRestrict
            // 
            this.rbReqNoRestrict.AutoSize = true;
            this.rbReqNoRestrict.Checked = true;
            this.rbReqNoRestrict.Location = new System.Drawing.Point(17, 13);
            this.rbReqNoRestrict.Name = "rbReqNoRestrict";
            this.rbReqNoRestrict.Size = new System.Drawing.Size(59, 16);
            this.rbReqNoRestrict.TabIndex = 0;
            this.rbReqNoRestrict.TabStop = true;
            this.rbReqNoRestrict.Text = "不限制";
            this.rbReqNoRestrict.UseVisualStyleBackColor = true;
            this.rbReqNoRestrict.Click += new System.EventHandler(this.rbReq_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rbRespJson);
            this.tabPage2.Controls.Add(this.rbRespRule);
            this.tabPage2.Controls.Add(this.rtbResponse);
            this.tabPage2.Controls.Add(this.panelResp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(750, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Response条件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tssDict
            // 
            this.tssDict.Name = "tssDict";
            this.tssDict.Size = new System.Drawing.Size(158, 6);
            // 
            // tsmiDictNull
            // 
            this.tsmiDictNull.Name = "tsmiDictNull";
            this.tsmiDictNull.Size = new System.Drawing.Size(161, 22);
            this.tsmiDictNull.Text = "返回一个空的Dict";
            // 
            // BaseApiMockDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbRuleID);
            this.Controls.Add(this.tbRuleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmitRule);
            this.Controls.Add(this.cbRunOnce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseApiMockDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.panelResp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespRules)).EndInit();
            this.cmsTreeNode.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RadioButton rbRespRule;
        protected System.Windows.Forms.RadioButton rbRespJson;
        protected System.Windows.Forms.RichTextBox rtbResponse;
        protected System.Windows.Forms.Panel panelResp;
        protected System.Windows.Forms.CheckBox cbRunOnce;
        protected System.Windows.Forms.Button btnSubmitRule;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbRuleName;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbRuleID;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip cmsTreeNode;
        private System.Windows.Forms.ToolStripMenuItem tsmiModValue;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ToolStripSeparator tssList;
        private System.Windows.Forms.ToolStripMenuItem tsmiListAddCopyAt;
        private System.Windows.Forms.ToolStripMenuItem tsmiListAddCustomAt;
        private System.Windows.Forms.ToolStripMenuItem tsmiListDelRange;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton rbReqReg;
        private System.Windows.Forms.RadioButton rbReqContains;
        private System.Windows.Forms.RadioButton rbReqExact;
        private System.Windows.Forms.RadioButton rbReqNoRestrict;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbReqReg;
        private System.Windows.Forms.TextBox tbReqContains;
        private System.Windows.Forms.TextBox tbReqExact;
        private System.Windows.Forms.Panel panelReqRule;
        private System.Windows.Forms.RadioButton rbReqRule;
        private System.Windows.Forms.ImageList ilResponseType;
        private System.Windows.Forms.ToolStripSeparator tssCustomize;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustomize;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.DataGridView dgvRespRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcRuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcRuleString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator tssDict;
        private System.Windows.Forms.ToolStripMenuItem tsmiDictNull;
    }
}