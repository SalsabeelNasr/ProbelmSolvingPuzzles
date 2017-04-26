namespace PortableLogin
{
    partial class Welcome
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
            this.btnEditLoginInfo = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnEditLoginInfo
            // 
            this.btnEditLoginInfo.Location = new System.Drawing.Point(222, 148);
            this.btnEditLoginInfo.Name = "btnEditLoginInfo";
            this.btnEditLoginInfo.Size = new System.Drawing.Size(113, 23);
            this.btnEditLoginInfo.TabIndex = 0;
            this.btnEditLoginInfo.Text = "Change Password";
            this.btnEditLoginInfo.UseSelectable = true;
            this.btnEditLoginInfo.Click += new System.EventHandler(this.btnEditLoginInfo_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 327);
            this.Controls.Add(this.btnEditLoginInfo);
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Resizable = false;
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnEditLoginInfo;


    }
}