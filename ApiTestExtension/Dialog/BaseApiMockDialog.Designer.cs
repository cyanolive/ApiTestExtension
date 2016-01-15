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
            this.rbResponse1 = new System.Windows.Forms.RadioButton();
            this.rbResponse2 = new System.Windows.Forms.RadioButton();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cbRunOnce = new System.Windows.Forms.CheckBox();
            this.btnSubmitRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRuleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRuleID = new System.Windows.Forms.TextBox();
            this.cmsTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsModValue = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListAddCopyAt = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListAddCustomAt = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListDelRange = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cmsTreeNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbResponse1
            // 
            this.rbResponse1.AutoSize = true;
            this.rbResponse1.Location = new System.Drawing.Point(12, 36);
            this.rbResponse1.Name = "rbResponse1";
            this.rbResponse1.Size = new System.Drawing.Size(143, 16);
            this.rbResponse1.TabIndex = 0;
            this.rbResponse1.TabStop = true;
            this.rbResponse1.Text = "按照规则修改Response";
            this.rbResponse1.UseVisualStyleBackColor = true;
            // 
            // rbResponse2
            // 
            this.rbResponse2.AutoSize = true;
            this.rbResponse2.Location = new System.Drawing.Point(12, 369);
            this.rbResponse2.Name = "rbResponse2";
            this.rbResponse2.Size = new System.Drawing.Size(155, 16);
            this.rbResponse2.TabIndex = 1;
            this.rbResponse2.TabStop = true;
            this.rbResponse2.Text = "直接使用下面的Response";
            this.rbResponse2.UseVisualStyleBackColor = true;
            // 
            // rtbResponse
            // 
            this.rtbResponse.Location = new System.Drawing.Point(12, 391);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(760, 159);
            this.rtbResponse.TabIndex = 2;
            this.rtbResponse.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 306);
            this.panel1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(-1, -1);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(250, 306);
            this.treeView1.TabIndex = 0;
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
            this.cmsModValue,
            this.cmsDel,
            this.toolStripSeparator1,
            this.cmsListAddCopyAt,
            this.cmsListAddCustomAt,
            this.cmsListDelRange});
            this.cmsTreeNode.Name = "cmsTreeNode";
            this.cmsTreeNode.Size = new System.Drawing.Size(177, 120);
            // 
            // cmsModValue
            // 
            this.cmsModValue.Name = "cmsModValue";
            this.cmsModValue.Size = new System.Drawing.Size(176, 22);
            this.cmsModValue.Text = "修改该项的值";
            // 
            // cmsDel
            // 
            this.cmsDel.Name = "cmsDel";
            this.cmsDel.Size = new System.Drawing.Size(176, 22);
            this.cmsDel.Text = "删除该项";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // cmsListAddCopyAt
            // 
            this.cmsListAddCopyAt.Name = "cmsListAddCopyAt";
            this.cmsListAddCopyAt.Size = new System.Drawing.Size(176, 22);
            this.cmsListAddCopyAt.Text = "复制List指定项到...";
            // 
            // cmsListAddCustomAt
            // 
            this.cmsListAddCustomAt.Name = "cmsListAddCustomAt";
            this.cmsListAddCustomAt.Size = new System.Drawing.Size(176, 22);
            this.cmsListAddCustomAt.Text = "添加自定义项到...";
            // 
            // cmsListDelRange
            // 
            this.cmsListDelRange.Name = "cmsListDelRange";
            this.cmsListDelRange.Size = new System.Drawing.Size(176, 22);
            this.cmsListDelRange.Text = "删除List子项";
            // 
            // BaseApiMockDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tbRuleID);
            this.Controls.Add(this.tbRuleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmitRule);
            this.Controls.Add(this.cbRunOnce);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbResponse);
            this.Controls.Add(this.rbResponse2);
            this.Controls.Add(this.rbResponse1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseApiMockDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.panel1.ResumeLayout(false);
            this.cmsTreeNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RadioButton rbResponse1;
        protected System.Windows.Forms.RadioButton rbResponse2;
        protected System.Windows.Forms.RichTextBox rtbResponse;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.CheckBox cbRunOnce;
        protected System.Windows.Forms.Button btnSubmitRule;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbRuleName;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbRuleID;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip cmsTreeNode;
        private System.Windows.Forms.ToolStripMenuItem cmsModValue;
        private System.Windows.Forms.ToolStripMenuItem cmsDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsListAddCopyAt;
        private System.Windows.Forms.ToolStripMenuItem cmsListAddCustomAt;
        private System.Windows.Forms.ToolStripMenuItem cmsListDelRange;
    }
}