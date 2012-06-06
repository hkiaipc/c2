namespace Xdgk.Communi
{
    partial class frmDeviceItem
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numDeviceAddress = new System.Windows.Forms.NumericUpDown();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOwnerStatoin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(119, 202);
            this.okButton.TabIndex = 10;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(207, 202);
            this.cancelButton.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 21);
            this.txtName.TabIndex = 5;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(87, 115);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(192, 81);
            this.txtRemark.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "备注：";
            // 
            // numDeviceAddress
            // 
            this.numDeviceAddress.Location = new System.Drawing.Point(87, 88);
            this.numDeviceAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numDeviceAddress.Name = "numDeviceAddress";
            this.numDeviceAddress.Size = new System.Drawing.Size(191, 21);
            this.numDeviceAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(9, 90);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 12);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "设备地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "设备类型：";
            // 
            // txtOwnerStatoin
            // 
            this.txtOwnerStatoin.Location = new System.Drawing.Point(87, 8);
            this.txtOwnerStatoin.Name = "txtOwnerStatoin";
            this.txtOwnerStatoin.ReadOnly = true;
            this.txtOwnerStatoin.Size = new System.Drawing.Size(192, 21);
            this.txtOwnerStatoin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "所属站点：";
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(86, 35);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.ReadOnly = true;
            this.txtDeviceType.Size = new System.Drawing.Size(192, 21);
            this.txtDeviceType.TabIndex = 3;
            // 
            // frmDeviceItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 236);
            this.Controls.Add(this.txtDeviceType);
            this.Controls.Add(this.txtOwnerStatoin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDeviceAddress);
            this.Controls.Add(this.lblAddress);
            this.Name = "frmDeviceItem";
            this.Text = "frmDeviceItem";
            this.Load += new System.EventHandler(this.frmDeviceItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.numDeviceAddress, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtOwnerStatoin, 0);
            this.Controls.SetChildIndex(this.txtDeviceType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtName;
        protected System.Windows.Forms.TextBox txtRemark;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.NumericUpDown numDeviceAddress;
        protected System.Windows.Forms.Label lblAddress;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtOwnerStatoin;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtDeviceType;
    }
}