namespace UI
{
    partial class frmExchange
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
            this.components = new System.ComponentModel.Container();
            this.txtFromCurrenct = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExchange = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtToCurrency = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cbCurrenciesfrom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbCurrenciesTo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFromCurrenct
            // 
            this.txtFromCurrenct.BorderRadius = 6;
            this.txtFromCurrenct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFromCurrenct.DefaultText = "";
            this.txtFromCurrenct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFromCurrenct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFromCurrenct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFromCurrenct.DisabledState.Parent = this.txtFromCurrenct;
            this.txtFromCurrenct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFromCurrenct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFromCurrenct.FocusedState.Parent = this.txtFromCurrenct;
            this.txtFromCurrenct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFromCurrenct.HoverState.Parent = this.txtFromCurrenct;
            this.txtFromCurrenct.Location = new System.Drawing.Point(256, 178);
            this.txtFromCurrenct.Name = "txtFromCurrenct";
            this.txtFromCurrenct.PasswordChar = '\0';
            this.txtFromCurrenct.PlaceholderText = "";
            this.txtFromCurrenct.SelectedText = "";
            this.txtFromCurrenct.ShadowDecoration.Parent = this.txtFromCurrenct;
            this.txtFromCurrenct.Size = new System.Drawing.Size(200, 36);
            this.txtFromCurrenct.TabIndex = 0;
            // 
            // btnExchange
            // 
            this.btnExchange.BorderRadius = 6;
            this.btnExchange.CheckedState.Parent = this.btnExchange;
            this.btnExchange.CustomImages.Parent = this.btnExchange;
            this.btnExchange.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnExchange.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnExchange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExchange.ForeColor = System.Drawing.Color.White;
            this.btnExchange.HoverState.Parent = this.btnExchange;
            this.btnExchange.Location = new System.Drawing.Point(265, 311);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.ShadowDecoration.Parent = this.btnExchange;
            this.btnExchange.Size = new System.Drawing.Size(173, 45);
            this.btnExchange.TabIndex = 1;
            this.btnExchange.Text = "Exchange";
            this.btnExchange.Click += new System.EventHandler(this.btnExchange_Click);
            // 
            // txtToCurrency
            // 
            this.txtToCurrency.BorderRadius = 6;
            this.txtToCurrency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtToCurrency.DefaultText = "";
            this.txtToCurrency.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtToCurrency.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtToCurrency.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtToCurrency.DisabledState.Parent = this.txtToCurrency;
            this.txtToCurrency.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtToCurrency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtToCurrency.FocusedState.Parent = this.txtToCurrency;
            this.txtToCurrency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtToCurrency.HoverState.Parent = this.txtToCurrency;
            this.txtToCurrency.Location = new System.Drawing.Point(256, 241);
            this.txtToCurrency.Name = "txtToCurrency";
            this.txtToCurrency.PasswordChar = '\0';
            this.txtToCurrency.PlaceholderText = "";
            this.txtToCurrency.ReadOnly = true;
            this.txtToCurrency.SelectedText = "";
            this.txtToCurrency.ShadowDecoration.Parent = this.txtToCurrency;
            this.txtToCurrency.Size = new System.Drawing.Size(200, 36);
            this.txtToCurrency.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(129, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Currency : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(141, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Currency : ";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 6;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(613, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 5;
            // 
            // cbCurrenciesfrom
            // 
            this.cbCurrenciesfrom.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrenciesfrom.BorderRadius = 6;
            this.cbCurrenciesfrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCurrenciesfrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrenciesfrom.FocusedColor = System.Drawing.Color.Empty;
            this.cbCurrenciesfrom.FocusedState.Parent = this.cbCurrenciesfrom;
            this.cbCurrenciesfrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCurrenciesfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCurrenciesfrom.FormattingEnabled = true;
            this.cbCurrenciesfrom.HoverState.Parent = this.cbCurrenciesfrom;
            this.cbCurrenciesfrom.ItemHeight = 30;
            this.cbCurrenciesfrom.ItemsAppearance.Parent = this.cbCurrenciesfrom;
            this.cbCurrenciesfrom.Location = new System.Drawing.Point(256, 52);
            this.cbCurrenciesfrom.Name = "cbCurrenciesfrom";
            this.cbCurrenciesfrom.ShadowDecoration.Parent = this.cbCurrenciesfrom;
            this.cbCurrenciesfrom.Size = new System.Drawing.Size(200, 36);
            this.cbCurrenciesfrom.TabIndex = 8;
            this.cbCurrenciesfrom.SelectedIndexChanged += new System.EventHandler(this.cbCurrenciesfrom_SelectedIndexChanged);
            // 
            // cbCurrenciesTo
            // 
            this.cbCurrenciesTo.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrenciesTo.BorderRadius = 6;
            this.cbCurrenciesTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCurrenciesTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrenciesTo.FocusedColor = System.Drawing.Color.Empty;
            this.cbCurrenciesTo.FocusedState.Parent = this.cbCurrenciesTo;
            this.cbCurrenciesTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCurrenciesTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCurrenciesTo.FormattingEnabled = true;
            this.cbCurrenciesTo.HoverState.Parent = this.cbCurrenciesTo;
            this.cbCurrenciesTo.ItemHeight = 30;
            this.cbCurrenciesTo.ItemsAppearance.Parent = this.cbCurrenciesTo;
            this.cbCurrenciesTo.Location = new System.Drawing.Point(256, 115);
            this.cbCurrenciesTo.Name = "cbCurrenciesTo";
            this.cbCurrenciesTo.ShadowDecoration.Parent = this.cbCurrenciesTo;
            this.cbCurrenciesTo.Size = new System.Drawing.Size(200, 36);
            this.cbCurrenciesTo.TabIndex = 9;
            this.cbCurrenciesTo.SelectedIndexChanged += new System.EventHandler(this.cbCurrenciesTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(104, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Currency From  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(119, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select Currency To : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmExchange
            // 
            this.AcceptButton = this.btnExchange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(670, 380);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCurrenciesTo);
            this.Controls.Add(this.cbCurrenciesfrom);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToCurrency);
            this.Controls.Add(this.btnExchange);
            this.Controls.Add(this.txtFromCurrenct);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExchange";
            this.Load += new System.EventHandler(this.frmExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFromCurrenct;
        private Guna.UI2.WinForms.Guna2GradientButton btnExchange;
        private Guna.UI2.WinForms.Guna2TextBox txtToCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCurrenciesTo;
        private Guna.UI2.WinForms.Guna2ComboBox cbCurrenciesfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}