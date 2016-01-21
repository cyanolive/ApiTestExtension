namespace ApiTestExtension.Dialog.ModRespDialogs
{
    partial class ModValueDialog
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbNull = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标的值：";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(83, 20);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(480, 21);
            this.tbValue.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(488, 398);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cbNull
            // 
            this.cbNull.AutoSize = true;
            this.cbNull.Location = new System.Drawing.Point(83, 58);
            this.cbNull.Name = "cbNull";
            this.cbNull.Size = new System.Drawing.Size(96, 16);
            this.cbNull.TabIndex = 3;
            this.cbNull.Text = "设定值为Null";
            this.cbNull.UseVisualStyleBackColor = true;
            this.cbNull.CheckedChanged += new System.EventHandler(this.cbNull_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "目标条件（仅在目标类型父节点有为List的节点时可以设置）：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(14, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 262);
            this.panel1.TabIndex = 4;
            // 
            // ModValueDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbNull);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModValueDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改值";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbNull;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}