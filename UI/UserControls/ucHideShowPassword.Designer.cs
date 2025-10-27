namespace UI
{
    partial class ucHideShowPassword
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbHideShowPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHideShowPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHideShowPassword
            // 
            this.pbHideShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.pbHideShowPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHideShowPassword.Image = global::UI.Properties.Resources.ShowPasswordWhite;
            this.pbHideShowPassword.Location = new System.Drawing.Point(0, 0);
            this.pbHideShowPassword.Name = "pbHideShowPassword";
            this.pbHideShowPassword.Size = new System.Drawing.Size(30, 30);
            this.pbHideShowPassword.TabIndex = 0;
            this.pbHideShowPassword.TabStop = false;
            this.pbHideShowPassword.Click += new System.EventHandler(this.pbHideShowPassword_Click);
            // 
            // ucHideShowPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbHideShowPassword);
            this.Name = "ucHideShowPassword";
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pbHideShowPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHideShowPassword;
    }
}
