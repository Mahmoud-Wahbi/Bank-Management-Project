namespace BankPresentationLayer
{
    partial class frmListUsers
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
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnPrev = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoUsersExist = new System.Windows.Forms.Label();
            this.btnMainMenu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKeyWord = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbSearchMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToOrderColumns = true;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersList.Location = new System.Drawing.Point(0, 100);
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersList.Size = new System.Drawing.Size(1074, 503);
            this.dgvUsersList.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(113)))));
            this.panel2.BackgroundImage = global::UI.Properties.Resources.Forms_Background;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 603);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1074, 100);
            this.panel2.TabIndex = 8;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderRadius = 6;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnNext.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Location = new System.Drawing.Point(927, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(135, 39);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.BorderRadius = 6;
            this.btnPrev.CheckedState.Parent = this.btnPrev;
            this.btnPrev.CustomImages.Parent = this.btnPrev;
            this.btnPrev.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnPrev.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.HoverState.Parent = this.btnPrev;
            this.btnPrev.Location = new System.Drawing.Point(26, 15);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.ShadowDecoration.Parent = this.btnPrev;
            this.btnPrev.Size = new System.Drawing.Size(135, 39);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Previous";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(113)))));
            this.panel1.BackgroundImage = global::UI.Properties.Resources.Forms_Background;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblNoUsersExist);
            this.panel1.Controls.Add(this.btnMainMenu);
            this.panel1.Controls.Add(this.guna2HtmlLabel1);
            this.panel1.Controls.Add(this.txtKeyWord);
            this.panel1.Controls.Add(this.cbSearchMethod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 100);
            this.panel1.TabIndex = 9;
            // 
            // lblNoUsersExist
            // 
            this.lblNoUsersExist.AutoSize = true;
            this.lblNoUsersExist.BackColor = System.Drawing.Color.Transparent;
            this.lblNoUsersExist.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoUsersExist.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNoUsersExist.Location = new System.Drawing.Point(406, 80);
            this.lblNoUsersExist.Name = "lblNoUsersExist";
            this.lblNoUsersExist.Size = new System.Drawing.Size(262, 17);
            this.lblNoUsersExist.TabIndex = 8;
            this.lblNoUsersExist.Text = "No users exists in the system at this time.";
            this.lblNoUsersExist.Visible = false;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.BorderRadius = 6;
            this.btnMainMenu.CheckedState.Parent = this.btnMainMenu;
            this.btnMainMenu.CustomImages.Parent = this.btnMainMenu;
            this.btnMainMenu.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnMainMenu.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnMainMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.HoverState.Parent = this.btnMainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(939, 12);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.ShadowDecoration.Parent = this.btnMainMenu;
            this.btnMainMenu.Size = new System.Drawing.Size(135, 39);
            this.btnMainMenu.TabIndex = 6;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 28);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(74, 23);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Search By";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.BackColor = System.Drawing.Color.Transparent;
            this.txtKeyWord.BorderRadius = 6;
            this.txtKeyWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyWord.DefaultText = "";
            this.txtKeyWord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKeyWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKeyWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyWord.DisabledState.Parent = this.txtKeyWord;
            this.txtKeyWord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyWord.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyWord.FocusedState.Parent = this.txtKeyWord;
            this.txtKeyWord.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyWord.HoverState.Parent = this.txtKeyWord;
            this.txtKeyWord.IconLeft = global::UI.Properties.Resources.SearchLogo;
            this.txtKeyWord.Location = new System.Drawing.Point(409, 22);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.PasswordChar = '\0';
            this.txtKeyWord.PlaceholderText = "";
            this.txtKeyWord.SelectedText = "";
            this.txtKeyWord.ShadowDecoration.Parent = this.txtKeyWord;
            this.txtKeyWord.Size = new System.Drawing.Size(225, 36);
            this.txtKeyWord.TabIndex = 4;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtKeyWord_TextChanged);
            // 
            // cbSearchMethod
            // 
            this.cbSearchMethod.BackColor = System.Drawing.Color.Transparent;
            this.cbSearchMethod.BorderRadius = 6;
            this.cbSearchMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchMethod.FocusedColor = System.Drawing.Color.Empty;
            this.cbSearchMethod.FocusedState.Parent = this.cbSearchMethod;
            this.cbSearchMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSearchMethod.FormattingEnabled = true;
            this.cbSearchMethod.HoverState.Parent = this.cbSearchMethod;
            this.cbSearchMethod.ItemHeight = 30;
            this.cbSearchMethod.Items.AddRange(new object[] {
            "Name ",
            "Country Id",
            "UserName",
            "UserId",
            "Person Id",
            "Email"});
            this.cbSearchMethod.ItemsAppearance.Parent = this.cbSearchMethod;
            this.cbSearchMethod.Location = new System.Drawing.Point(121, 22);
            this.cbSearchMethod.Name = "cbSearchMethod";
            this.cbSearchMethod.ShadowDecoration.Parent = this.cbSearchMethod;
            this.cbSearchMethod.Size = new System.Drawing.Size(225, 36);
            this.cbSearchMethod.TabIndex = 3;
            // 
            // frmListUsere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 703);
            this.Controls.Add(this.dgvUsersList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListUsere";
            this.Text = "frmListUsere";
            this.Load += new System.EventHandler(this.frmListUsere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersList;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2GradientButton btnPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoUsersExist;
        private Guna.UI2.WinForms.Guna2GradientButton btnMainMenu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtKeyWord;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchMethod;
    }
}