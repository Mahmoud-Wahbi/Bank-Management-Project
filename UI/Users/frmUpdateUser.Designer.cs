namespace BankPresentationLayer
{
    partial class frmUpdateUser
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.gbPermissions = new System.Windows.Forms.GroupBox();
            this.ucHideShowPassword1 = new UI.ucHideShowPassword();
            this.chkAllPermissions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkTransactions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkUpdateClient = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkListClients = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAddNewClient = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkFindClient = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageUesrs = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkDeleteClient = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbPersonalInfo = new System.Windows.Forms.GroupBox();
            this.cbCountry = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pbCountryFlag = new System.Windows.Forms.PictureBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDeleteSelectedPhone = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtFind = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddToPhonesList = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label12 = new System.Windows.Forms.Label();
            this.cbPhones = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llAdd = new System.Windows.Forms.LinkLabel();
            this.llRemove = new System.Windows.Forms.LinkLabel();
            this.pbPersonalImage = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnMainMenu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.gbPermissions.SuspendLayout();
            this.gbPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 6;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Location = new System.Drawing.Point(432, 659);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbPermissions
            // 
            this.gbPermissions.BackColor = System.Drawing.Color.Transparent;
            this.gbPermissions.Controls.Add(this.ucHideShowPassword1);
            this.gbPermissions.Controls.Add(this.chkAllPermissions);
            this.gbPermissions.Controls.Add(this.txtPassword);
            this.gbPermissions.Controls.Add(this.chkTransactions);
            this.gbPermissions.Controls.Add(this.chkUpdateClient);
            this.gbPermissions.Controls.Add(this.txtUserName);
            this.gbPermissions.Controls.Add(this.chkListClients);
            this.gbPermissions.Controls.Add(this.chkAddNewClient);
            this.gbPermissions.Controls.Add(this.label10);
            this.gbPermissions.Controls.Add(this.chkFindClient);
            this.gbPermissions.Controls.Add(this.chkManageUesrs);
            this.gbPermissions.Controls.Add(this.chkDeleteClient);
            this.gbPermissions.Controls.Add(this.label9);
            this.gbPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPermissions.ForeColor = System.Drawing.Color.White;
            this.gbPermissions.Location = new System.Drawing.Point(12, 7);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(783, 206);
            this.gbPermissions.TabIndex = 49;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "User Info";
            // 
            // ucHideShowPassword1
            // 
            this.ucHideShowPassword1.BackColor = System.Drawing.Color.Transparent;
            this.ucHideShowPassword1.Location = new System.Drawing.Point(740, 147);
            this.ucHideShowPassword1.Margin = new System.Windows.Forms.Padding(4);
            this.ucHideShowPassword1.Name = "ucHideShowPassword1";
            this.ucHideShowPassword1.Size = new System.Drawing.Size(29, 30);
            this.ucHideShowPassword1.TabIndex = 63;
            this.ucHideShowPassword1.ToggleStateChanged += new System.EventHandler(this.ucHideShowPassword1_ToggleStateChanged);
            // 
            // chkAllPermissions
            // 
            this.chkAllPermissions.AutoSize = true;
            this.chkAllPermissions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAllPermissions.CheckedState.BorderRadius = 2;
            this.chkAllPermissions.CheckedState.BorderThickness = 0;
            this.chkAllPermissions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAllPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllPermissions.ForeColor = System.Drawing.Color.White;
            this.chkAllPermissions.Location = new System.Drawing.Point(238, 162);
            this.chkAllPermissions.Name = "chkAllPermissions";
            this.chkAllPermissions.Size = new System.Drawing.Size(118, 21);
            this.chkAllPermissions.TabIndex = 49;
            this.chkAllPermissions.Tag = "-1";
            this.chkAllPermissions.Text = "All Permissions";
            this.chkAllPermissions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAllPermissions.UncheckedState.BorderRadius = 2;
            this.chkAllPermissions.UncheckedState.BorderThickness = 0;
            this.chkAllPermissions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAllPermissions.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderRadius = 6;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new System.Drawing.Point(532, 142);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(200, 37);
            this.txtPassword.TabIndex = 38;
            // 
            // chkTransactions
            // 
            this.chkTransactions.AutoSize = true;
            this.chkTransactions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkTransactions.CheckedState.BorderRadius = 2;
            this.chkTransactions.CheckedState.BorderThickness = 0;
            this.chkTransactions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransactions.ForeColor = System.Drawing.Color.White;
            this.chkTransactions.Location = new System.Drawing.Point(238, 117);
            this.chkTransactions.Name = "chkTransactions";
            this.chkTransactions.Size = new System.Drawing.Size(102, 21);
            this.chkTransactions.TabIndex = 51;
            this.chkTransactions.Tag = "64";
            this.chkTransactions.Text = "Transactions";
            this.chkTransactions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkTransactions.UncheckedState.BorderRadius = 2;
            this.chkTransactions.UncheckedState.BorderThickness = 0;
            this.chkTransactions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkTransactions.UseVisualStyleBackColor = true;
            // 
            // chkUpdateClient
            // 
            this.chkUpdateClient.AutoSize = true;
            this.chkUpdateClient.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkUpdateClient.CheckedState.BorderRadius = 2;
            this.chkUpdateClient.CheckedState.BorderThickness = 0;
            this.chkUpdateClient.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkUpdateClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdateClient.ForeColor = System.Drawing.Color.White;
            this.chkUpdateClient.Location = new System.Drawing.Point(238, 78);
            this.chkUpdateClient.Name = "chkUpdateClient";
            this.chkUpdateClient.Size = new System.Drawing.Size(115, 21);
            this.chkUpdateClient.TabIndex = 52;
            this.chkUpdateClient.Tag = "16";
            this.chkUpdateClient.Text = "Update Clients";
            this.chkUpdateClient.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkUpdateClient.UncheckedState.BorderRadius = 2;
            this.chkUpdateClient.UncheckedState.BorderThickness = 0;
            this.chkUpdateClient.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkUpdateClient.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderRadius = 6;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.Parent = this.txtUserName;
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.FocusedState.Parent = this.txtUserName;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.HoverState.Parent = this.txtUserName;
            this.txtUserName.Location = new System.Drawing.Point(532, 43);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PlaceholderText = "";
            this.txtUserName.SelectedText = "";
            this.txtUserName.ShadowDecoration.Parent = this.txtUserName;
            this.txtUserName.Size = new System.Drawing.Size(200, 37);
            this.txtUserName.TabIndex = 37;
            // 
            // chkListClients
            // 
            this.chkListClients.AutoSize = true;
            this.chkListClients.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkListClients.CheckedState.BorderRadius = 2;
            this.chkListClients.CheckedState.BorderThickness = 0;
            this.chkListClients.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkListClients.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListClients.ForeColor = System.Drawing.Color.White;
            this.chkListClients.Location = new System.Drawing.Point(27, 30);
            this.chkListClients.Name = "chkListClients";
            this.chkListClients.Size = new System.Drawing.Size(91, 21);
            this.chkListClients.TabIndex = 45;
            this.chkListClients.Tag = "2";
            this.chkListClients.Text = "List Clients";
            this.chkListClients.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkListClients.UncheckedState.BorderRadius = 2;
            this.chkListClients.UncheckedState.BorderThickness = 0;
            this.chkListClients.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkListClients.UseVisualStyleBackColor = true;
            // 
            // chkAddNewClient
            // 
            this.chkAddNewClient.AutoSize = true;
            this.chkAddNewClient.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAddNewClient.CheckedState.BorderRadius = 2;
            this.chkAddNewClient.CheckedState.BorderThickness = 0;
            this.chkAddNewClient.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAddNewClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddNewClient.ForeColor = System.Drawing.Color.White;
            this.chkAddNewClient.Location = new System.Drawing.Point(238, 30);
            this.chkAddNewClient.Name = "chkAddNewClient";
            this.chkAddNewClient.Size = new System.Drawing.Size(121, 21);
            this.chkAddNewClient.TabIndex = 50;
            this.chkAddNewClient.Tag = "4";
            this.chkAddNewClient.Text = "Add New Client";
            this.chkAddNewClient.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAddNewClient.UncheckedState.BorderRadius = 2;
            this.chkAddNewClient.UncheckedState.BorderThickness = 0;
            this.chkAddNewClient.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAddNewClient.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(436, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Password";
            // 
            // chkFindClient
            // 
            this.chkFindClient.AutoSize = true;
            this.chkFindClient.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkFindClient.CheckedState.BorderRadius = 2;
            this.chkFindClient.CheckedState.BorderThickness = 0;
            this.chkFindClient.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkFindClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFindClient.ForeColor = System.Drawing.Color.White;
            this.chkFindClient.Location = new System.Drawing.Point(26, 118);
            this.chkFindClient.Name = "chkFindClient";
            this.chkFindClient.Size = new System.Drawing.Size(91, 21);
            this.chkFindClient.TabIndex = 47;
            this.chkFindClient.Tag = "32";
            this.chkFindClient.Text = "Find Client";
            this.chkFindClient.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkFindClient.UncheckedState.BorderRadius = 2;
            this.chkFindClient.UncheckedState.BorderThickness = 0;
            this.chkFindClient.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkFindClient.UseVisualStyleBackColor = true;
            // 
            // chkManageUesrs
            // 
            this.chkManageUesrs.AutoSize = true;
            this.chkManageUesrs.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkManageUesrs.CheckedState.BorderRadius = 2;
            this.chkManageUesrs.CheckedState.BorderThickness = 0;
            this.chkManageUesrs.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkManageUesrs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageUesrs.ForeColor = System.Drawing.Color.White;
            this.chkManageUesrs.Location = new System.Drawing.Point(26, 162);
            this.chkManageUesrs.Name = "chkManageUesrs";
            this.chkManageUesrs.Size = new System.Drawing.Size(113, 21);
            this.chkManageUesrs.TabIndex = 48;
            this.chkManageUesrs.Tag = "128";
            this.chkManageUesrs.Text = "Manage Users";
            this.chkManageUesrs.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkManageUesrs.UncheckedState.BorderRadius = 2;
            this.chkManageUesrs.UncheckedState.BorderThickness = 0;
            this.chkManageUesrs.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkManageUesrs.UseVisualStyleBackColor = true;
            // 
            // chkDeleteClient
            // 
            this.chkDeleteClient.AutoSize = true;
            this.chkDeleteClient.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDeleteClient.CheckedState.BorderRadius = 2;
            this.chkDeleteClient.CheckedState.BorderThickness = 0;
            this.chkDeleteClient.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDeleteClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteClient.ForeColor = System.Drawing.Color.White;
            this.chkDeleteClient.Location = new System.Drawing.Point(26, 78);
            this.chkDeleteClient.Name = "chkDeleteClient";
            this.chkDeleteClient.Size = new System.Drawing.Size(103, 21);
            this.chkDeleteClient.TabIndex = 46;
            this.chkDeleteClient.Tag = "8";
            this.chkDeleteClient.Text = "Delete Client";
            this.chkDeleteClient.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDeleteClient.UncheckedState.BorderRadius = 2;
            this.chkDeleteClient.UncheckedState.BorderThickness = 0;
            this.chkDeleteClient.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDeleteClient.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(429, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "UserName";
            // 
            // gbPersonalInfo
            // 
            this.gbPersonalInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbPersonalInfo.Controls.Add(this.cbCountry);
            this.gbPersonalInfo.Controls.Add(this.pbCountryFlag);
            this.gbPersonalInfo.Controls.Add(this.btnFind);
            this.gbPersonalInfo.Controls.Add(this.btnDeleteSelectedPhone);
            this.gbPersonalInfo.Controls.Add(this.txtFind);
            this.gbPersonalInfo.Controls.Add(this.label11);
            this.gbPersonalInfo.Controls.Add(this.btnAddToPhonesList);
            this.gbPersonalInfo.Controls.Add(this.label12);
            this.gbPersonalInfo.Controls.Add(this.cbPhones);
            this.gbPersonalInfo.Controls.Add(this.cbGender);
            this.gbPersonalInfo.Controls.Add(this.txtPhone);
            this.gbPersonalInfo.Controls.Add(this.txtAddress);
            this.gbPersonalInfo.Controls.Add(this.txtLastName);
            this.gbPersonalInfo.Controls.Add(this.txtEmail);
            this.gbPersonalInfo.Controls.Add(this.txtFirstName);
            this.gbPersonalInfo.Controls.Add(this.label8);
            this.gbPersonalInfo.Controls.Add(this.label7);
            this.gbPersonalInfo.Controls.Add(this.label6);
            this.gbPersonalInfo.Controls.Add(this.dtpBirthDate);
            this.gbPersonalInfo.Controls.Add(this.label5);
            this.gbPersonalInfo.Controls.Add(this.label4);
            this.gbPersonalInfo.Controls.Add(this.label3);
            this.gbPersonalInfo.Controls.Add(this.label2);
            this.gbPersonalInfo.Controls.Add(this.label1);
            this.gbPersonalInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonalInfo.ForeColor = System.Drawing.Color.White;
            this.gbPersonalInfo.Location = new System.Drawing.Point(12, 230);
            this.gbPersonalInfo.Name = "gbPersonalInfo";
            this.gbPersonalInfo.Size = new System.Drawing.Size(1059, 378);
            this.gbPersonalInfo.TabIndex = 48;
            this.gbPersonalInfo.TabStop = false;
            this.gbPersonalInfo.Text = "Personal Info";
            // 
            // cbCountry
            // 
            this.cbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCountry.BackColor = System.Drawing.Color.Transparent;
            this.cbCountry.BorderRadius = 5;
            this.cbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FocusedColor = System.Drawing.Color.Empty;
            this.cbCountry.FocusedState.Parent = this.cbCountry;
            this.cbCountry.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.HoverState.Parent = this.cbCountry;
            this.cbCountry.IntegralHeight = false;
            this.cbCountry.ItemHeight = 30;
            this.cbCountry.ItemsAppearance.Parent = this.cbCountry;
            this.cbCountry.Location = new System.Drawing.Point(140, 306);
            this.cbCountry.Margin = new System.Windows.Forms.Padding(4);
            this.cbCountry.MaxDropDownItems = 13;
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.ShadowDecoration.Parent = this.cbCountry;
            this.cbCountry.Size = new System.Drawing.Size(200, 36);
            this.cbCountry.Sorted = true;
            this.cbCountry.TabIndex = 62;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // pbCountryFlag
            // 
            this.pbCountryFlag.Image = global::UI.Properties.Resources.no_image_white;
            this.pbCountryFlag.Location = new System.Drawing.Point(356, 311);
            this.pbCountryFlag.Name = "pbCountryFlag";
            this.pbCountryFlag.Size = new System.Drawing.Size(42, 24);
            this.pbCountryFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCountryFlag.TabIndex = 55;
            this.pbCountryFlag.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.BorderRadius = 6;
            this.btnFind.CheckedState.Parent = this.btnFind;
            this.btnFind.CustomImages.Parent = this.btnFind;
            this.btnFind.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnFind.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.HoverState.Parent = this.btnFind;
            this.btnFind.Location = new System.Drawing.Point(348, 60);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Parent = this.btnFind;
            this.btnFind.Size = new System.Drawing.Size(121, 37);
            this.btnFind.TabIndex = 54;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDeleteSelectedPhone
            // 
            this.btnDeleteSelectedPhone.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSelectedPhone.BorderRadius = 6;
            this.btnDeleteSelectedPhone.CheckedState.Parent = this.btnDeleteSelectedPhone;
            this.btnDeleteSelectedPhone.CustomImages.Parent = this.btnDeleteSelectedPhone;
            this.btnDeleteSelectedPhone.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteSelectedPhone.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnDeleteSelectedPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelectedPhone.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSelectedPhone.HoverState.Parent = this.btnDeleteSelectedPhone;
            this.btnDeleteSelectedPhone.Location = new System.Drawing.Point(929, 238);
            this.btnDeleteSelectedPhone.Name = "btnDeleteSelectedPhone";
            this.btnDeleteSelectedPhone.ShadowDecoration.Parent = this.btnDeleteSelectedPhone;
            this.btnDeleteSelectedPhone.Size = new System.Drawing.Size(121, 37);
            this.btnDeleteSelectedPhone.TabIndex = 44;
            this.btnDeleteSelectedPhone.Text = "Delete Selected";
            this.btnDeleteSelectedPhone.Click += new System.EventHandler(this.btnRemovePhoneFromList_Click);
            // 
            // txtFind
            // 
            this.txtFind.BackColor = System.Drawing.Color.Transparent;
            this.txtFind.BorderRadius = 6;
            this.txtFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFind.DefaultText = "";
            this.txtFind.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFind.DisabledState.Parent = this.txtFind;
            this.txtFind.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFind.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFind.FocusedState.Parent = this.txtFind;
            this.txtFind.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFind.HoverState.Parent = this.txtFind;
            this.txtFind.Location = new System.Drawing.Point(144, 60);
            this.txtFind.Margin = new System.Windows.Forms.Padding(5);
            this.txtFind.Name = "txtFind";
            this.txtFind.PasswordChar = '\0';
            this.txtFind.PlaceholderText = "";
            this.txtFind.SelectedText = "";
            this.txtFind.ShadowDecoration.Parent = this.txtFind;
            this.txtFind.Size = new System.Drawing.Size(200, 37);
            this.txtFind.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(652, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Phones";
            // 
            // btnAddToPhonesList
            // 
            this.btnAddToPhonesList.BackColor = System.Drawing.Color.Transparent;
            this.btnAddToPhonesList.BorderRadius = 6;
            this.btnAddToPhonesList.CheckedState.Parent = this.btnAddToPhonesList;
            this.btnAddToPhonesList.CustomImages.Parent = this.btnAddToPhonesList;
            this.btnAddToPhonesList.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnAddToPhonesList.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnAddToPhonesList.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToPhonesList.ForeColor = System.Drawing.Color.White;
            this.btnAddToPhonesList.HoverState.Parent = this.btnAddToPhonesList;
            this.btnAddToPhonesList.Location = new System.Drawing.Point(929, 178);
            this.btnAddToPhonesList.Name = "btnAddToPhonesList";
            this.btnAddToPhonesList.ShadowDecoration.Parent = this.btnAddToPhonesList;
            this.btnAddToPhonesList.Size = new System.Drawing.Size(121, 37);
            this.btnAddToPhonesList.TabIndex = 42;
            this.btnAddToPhonesList.Text = "Add";
            this.btnAddToPhonesList.Click += new System.EventHandler(this.btnAddPhoneToList_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 17);
            this.label12.TabIndex = 52;
            this.label12.Text = "Search (Username)";
            // 
            // cbPhones
            // 
            this.cbPhones.BackColor = System.Drawing.Color.Transparent;
            this.cbPhones.BorderRadius = 6;
            this.cbPhones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPhones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhones.FocusedColor = System.Drawing.Color.Empty;
            this.cbPhones.FocusedState.Parent = this.cbPhones;
            this.cbPhones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPhones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPhones.FormattingEnabled = true;
            this.cbPhones.HoverState.Parent = this.cbPhones;
            this.cbPhones.ItemHeight = 30;
            this.cbPhones.ItemsAppearance.Parent = this.cbPhones;
            this.cbPhones.Location = new System.Drawing.Point(722, 239);
            this.cbPhones.Name = "cbPhones";
            this.cbPhones.ShadowDecoration.Parent = this.cbPhones;
            this.cbPhones.Size = new System.Drawing.Size(200, 36);
            this.cbPhones.TabIndex = 40;
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderRadius = 6;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FocusedColor = System.Drawing.Color.Empty;
            this.cbGender.FocusedState.Parent = this.cbGender;
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.HoverState.Parent = this.cbGender;
            this.cbGender.ItemHeight = 30;
            this.cbGender.ItemsAppearance.Parent = this.cbGender;
            this.cbGender.Location = new System.Drawing.Point(722, 303);
            this.cbGender.Name = "cbGender";
            this.cbGender.ShadowDecoration.Parent = this.cbGender;
            this.cbGender.Size = new System.Drawing.Size(200, 36);
            this.cbGender.TabIndex = 39;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.BorderRadius = 6;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.Parent = this.txtPhone;
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.FocusedState.Parent = this.txtPhone;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.HoverState.Parent = this.txtPhone;
            this.txtPhone.Location = new System.Drawing.Point(723, 178);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.ShadowDecoration.Parent = this.txtPhone;
            this.txtPhone.Size = new System.Drawing.Size(200, 37);
            this.txtPhone.TabIndex = 38;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderRadius = 6;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.Parent = this.txtAddress;
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.FocusedState.Parent = this.txtAddress;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.HoverState.Parent = this.txtAddress;
            this.txtAddress.Location = new System.Drawing.Point(723, 112);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.Parent = this.txtAddress;
            this.txtAddress.Size = new System.Drawing.Size(200, 37);
            this.txtAddress.TabIndex = 37;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.BorderRadius = 6;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.DefaultText = "";
            this.txtLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLastName.DisabledState.Parent = this.txtLastName;
            this.txtLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLastName.FocusedState.Parent = this.txtLastName;
            this.txtLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLastName.HoverState.Parent = this.txtLastName;
            this.txtLastName.Location = new System.Drawing.Point(723, 54);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = '\0';
            this.txtLastName.PlaceholderText = "";
            this.txtLastName.SelectedText = "";
            this.txtLastName.ShadowDecoration.Parent = this.txtLastName;
            this.txtLastName.Size = new System.Drawing.Size(200, 37);
            this.txtLastName.TabIndex = 36;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(144, 177);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(200, 37);
            this.txtEmail.TabIndex = 35;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.BorderRadius = 6;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.DisabledState.Parent = this.txtFirstName;
            this.txtFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.FocusedState.Parent = this.txtFirstName;
            this.txtFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.HoverState.Parent = this.txtFirstName;
            this.txtFirstName.Location = new System.Drawing.Point(144, 116);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = '\0';
            this.txtFirstName.PlaceholderText = "";
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.ShadowDecoration.Parent = this.txtFirstName;
            this.txtFirstName.Size = new System.Drawing.Size(200, 37);
            this.txtFirstName.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(71, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Country";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(648, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(629, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Add Phone";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(144, 242);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 25);
            this.dtpBirthDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(64, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "BirthDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(653, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(89, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(633, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // llAdd
            // 
            this.llAdd.AutoSize = true;
            this.llAdd.BackColor = System.Drawing.Color.Transparent;
            this.llAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAdd.ForeColor = System.Drawing.Color.White;
            this.llAdd.LinkColor = System.Drawing.Color.White;
            this.llAdd.Location = new System.Drawing.Point(961, 170);
            this.llAdd.Name = "llAdd";
            this.llAdd.Size = new System.Drawing.Size(110, 17);
            this.llAdd.TabIndex = 47;
            this.llAdd.TabStop = true;
            this.llAdd.Text = "Add Personal Pic";
            this.llAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAdd_LinkClicked);
            // 
            // llRemove
            // 
            this.llRemove.AutoSize = true;
            this.llRemove.BackColor = System.Drawing.Color.Transparent;
            this.llRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRemove.ForeColor = System.Drawing.Color.White;
            this.llRemove.LinkColor = System.Drawing.Color.White;
            this.llRemove.Location = new System.Drawing.Point(812, 170);
            this.llRemove.Name = "llRemove";
            this.llRemove.Size = new System.Drawing.Size(134, 17);
            this.llRemove.TabIndex = 46;
            this.llRemove.TabStop = true;
            this.llRemove.Text = "Remove Personal pic";
            this.llRemove.Visible = false;
            this.llRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemove_LinkClicked);
            // 
            // pbPersonalImage
            // 
            this.pbPersonalImage.BackColor = System.Drawing.Color.Transparent;
            this.pbPersonalImage.Image = global::UI.Properties.Resources.no_image_white;
            this.pbPersonalImage.Location = new System.Drawing.Point(827, 12);
            this.pbPersonalImage.Name = "pbPersonalImage";
            this.pbPersonalImage.Size = new System.Drawing.Size(235, 154);
            this.pbPersonalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonalImage.TabIndex = 45;
            this.pbPersonalImage.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnMainMenu.BorderRadius = 5;
            this.btnMainMenu.CheckedState.Parent = this.btnMainMenu;
            this.btnMainMenu.CustomImages.Parent = this.btnMainMenu;
            this.btnMainMenu.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnMainMenu.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnMainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.HoverState.Parent = this.btnMainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(17, 659);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.ShadowDecoration.Parent = this.btnMainMenu;
            this.btnMainMenu.Size = new System.Drawing.Size(164, 39);
            this.btnMainMenu.TabIndex = 54;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.Forms_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 703);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.gbPersonalInfo);
            this.Controls.Add(this.llAdd);
            this.Controls.Add(this.llRemove);
            this.Controls.Add(this.pbPersonalImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdateUser";
            this.Text = "frmUpdateUser";
            this.Load += new System.EventHandler(this.frmUpdateUser_Load);
            this.gbPermissions.ResumeLayout(false);
            this.gbPermissions.PerformLayout();
            this.gbPersonalInfo.ResumeLayout(false);
            this.gbPersonalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private System.Windows.Forms.GroupBox gbPermissions;
        private Guna.UI2.WinForms.Guna2CheckBox chkAllPermissions;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2CheckBox chkTransactions;
        private Guna.UI2.WinForms.Guna2CheckBox chkUpdateClient;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2CheckBox chkListClients;
        private Guna.UI2.WinForms.Guna2CheckBox chkAddNewClient;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2CheckBox chkFindClient;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageUesrs;
        private Guna.UI2.WinForms.Guna2CheckBox chkDeleteClient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbPersonalInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeleteSelectedPhone;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddToPhonesList;
        private Guna.UI2.WinForms.Guna2ComboBox cbPhones;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtLastName;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llAdd;
        private System.Windows.Forms.LinkLabel llRemove;
        private System.Windows.Forms.PictureBox pbPersonalImage;
        private Guna.UI2.WinForms.Guna2TextBox txtFind;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2GradientButton btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbCountryFlag;
        private Guna.UI2.WinForms.Guna2ComboBox cbCountry;
        private UI.ucHideShowPassword ucHideShowPassword1;
        private Guna.UI2.WinForms.Guna2GradientButton btnMainMenu;
    }
}