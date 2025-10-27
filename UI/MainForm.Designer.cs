namespace BankProjectUi
{
    partial class MainForm
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
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowListClientsForm = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnShowAddClientForm = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFindClient = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdateClient = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnShowDeleteClientForm = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTransactions = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDeposit = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnWithdraw = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTotalBalances = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTransfer = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTransferLog = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnManageUsers = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnListUsers = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFindUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdateUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDeleteUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnAIChatBot = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(234)))));
            this.lblDateTime.Location = new System.Drawing.Point(706, 722);
            this.lblDateTime.Size = new System.Drawing.Size(197, 25);
            this.lblDateTime.Text = "2025-10-24 18:24:38";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(229)))), ((int)(((byte)(196)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1285, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(229)))), ((int)(((byte)(196)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1234, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 5;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::UI.Properties.Resources.BankLogoMainScreen;
            this.pbLogo.Location = new System.Drawing.Point(442, 178);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(582, 403);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 10;
            this.pbLogo.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(229)))), ((int)(((byte)(196)))));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Controls.Add(this.btnShowListClientsForm);
            this.flowLayoutPanel1.Controls.Add(this.btnShowAddClientForm);
            this.flowLayoutPanel1.Controls.Add(this.btnFindClient);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateClient);
            this.flowLayoutPanel1.Controls.Add(this.btnShowDeleteClientForm);
            this.flowLayoutPanel1.Controls.Add(this.btnTransactions);
            this.flowLayoutPanel1.Controls.Add(this.btnDeposit);
            this.flowLayoutPanel1.Controls.Add(this.btnWithdraw);
            this.flowLayoutPanel1.Controls.Add(this.btnTotalBalances);
            this.flowLayoutPanel1.Controls.Add(this.btnTransfer);
            this.flowLayoutPanel1.Controls.Add(this.btnTransferLog);
            this.flowLayoutPanel1.Controls.Add(this.btnManageUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnListUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnAddUser);
            this.flowLayoutPanel1.Controls.Add(this.btnFindUser);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateUser);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteUser);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, -1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 779);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnShowListClientsForm
            // 
            this.btnShowListClientsForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowListClientsForm.BackColor = System.Drawing.Color.Transparent;
            this.btnShowListClientsForm.BorderRadius = 5;
            this.btnShowListClientsForm.CheckedState.Parent = this.btnShowListClientsForm;
            this.btnShowListClientsForm.CustomImages.Parent = this.btnShowListClientsForm;
            this.btnShowListClientsForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnShowListClientsForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnShowListClientsForm.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowListClientsForm.ForeColor = System.Drawing.Color.White;
            this.btnShowListClientsForm.HoverState.Parent = this.btnShowListClientsForm;
            this.btnShowListClientsForm.Image = global::UI.Properties.Resources.ListClients;
            this.btnShowListClientsForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowListClientsForm.Location = new System.Drawing.Point(19, 10);
            this.btnShowListClientsForm.Margin = new System.Windows.Forms.Padding(19, 10, 3, 10);
            this.btnShowListClientsForm.Name = "btnShowListClientsForm";
            this.btnShowListClientsForm.ShadowDecoration.Parent = this.btnShowListClientsForm;
            this.btnShowListClientsForm.Size = new System.Drawing.Size(202, 35);
            this.btnShowListClientsForm.TabIndex = 8;
            this.btnShowListClientsForm.Text = "List Clients";
            this.btnShowListClientsForm.Click += new System.EventHandler(this.btnShowListClientsForm_Click);
            // 
            // btnShowAddClientForm
            // 
            this.btnShowAddClientForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowAddClientForm.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAddClientForm.BorderRadius = 5;
            this.btnShowAddClientForm.CheckedState.Parent = this.btnShowAddClientForm;
            this.btnShowAddClientForm.CustomImages.Parent = this.btnShowAddClientForm;
            this.btnShowAddClientForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnShowAddClientForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnShowAddClientForm.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAddClientForm.ForeColor = System.Drawing.Color.White;
            this.btnShowAddClientForm.HoverState.Parent = this.btnShowAddClientForm;
            this.btnShowAddClientForm.Image = global::UI.Properties.Resources.Add_Client;
            this.btnShowAddClientForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowAddClientForm.Location = new System.Drawing.Point(19, 58);
            this.btnShowAddClientForm.Margin = new System.Windows.Forms.Padding(19, 3, 3, 10);
            this.btnShowAddClientForm.Name = "btnShowAddClientForm";
            this.btnShowAddClientForm.ShadowDecoration.Parent = this.btnShowAddClientForm;
            this.btnShowAddClientForm.Size = new System.Drawing.Size(202, 35);
            this.btnShowAddClientForm.TabIndex = 9;
            this.btnShowAddClientForm.Text = "Add Cleint";
            this.btnShowAddClientForm.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnFindClient
            // 
            this.btnFindClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindClient.BackColor = System.Drawing.Color.Transparent;
            this.btnFindClient.BorderRadius = 5;
            this.btnFindClient.CheckedState.Parent = this.btnFindClient;
            this.btnFindClient.CustomImages.Parent = this.btnFindClient;
            this.btnFindClient.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnFindClient.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnFindClient.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindClient.ForeColor = System.Drawing.Color.White;
            this.btnFindClient.HoverState.Parent = this.btnFindClient;
            this.btnFindClient.Image = global::UI.Properties.Resources.Find_Client;
            this.btnFindClient.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFindClient.Location = new System.Drawing.Point(19, 106);
            this.btnFindClient.Margin = new System.Windows.Forms.Padding(19, 3, 3, 10);
            this.btnFindClient.Name = "btnFindClient";
            this.btnFindClient.ShadowDecoration.Parent = this.btnFindClient;
            this.btnFindClient.Size = new System.Drawing.Size(202, 35);
            this.btnFindClient.TabIndex = 16;
            this.btnFindClient.Text = "Find Client";
            this.btnFindClient.Click += new System.EventHandler(this.btnFindClient_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateClient.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateClient.BorderRadius = 5;
            this.btnUpdateClient.CheckedState.Parent = this.btnUpdateClient;
            this.btnUpdateClient.CustomImages.Parent = this.btnUpdateClient;
            this.btnUpdateClient.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnUpdateClient.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnUpdateClient.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateClient.ForeColor = System.Drawing.Color.White;
            this.btnUpdateClient.HoverState.Parent = this.btnUpdateClient;
            this.btnUpdateClient.Image = global::UI.Properties.Resources.Update_Client;
            this.btnUpdateClient.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpdateClient.Location = new System.Drawing.Point(19, 154);
            this.btnUpdateClient.Margin = new System.Windows.Forms.Padding(19, 3, 3, 10);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.ShadowDecoration.Parent = this.btnUpdateClient;
            this.btnUpdateClient.Size = new System.Drawing.Size(202, 35);
            this.btnUpdateClient.TabIndex = 9;
            this.btnUpdateClient.Text = "Update Client";
            this.btnUpdateClient.Click += new System.EventHandler(this.btnUpdateClient_Click);
            // 
            // btnShowDeleteClientForm
            // 
            this.btnShowDeleteClientForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowDeleteClientForm.BackColor = System.Drawing.Color.Transparent;
            this.btnShowDeleteClientForm.BorderRadius = 5;
            this.btnShowDeleteClientForm.CheckedState.Parent = this.btnShowDeleteClientForm;
            this.btnShowDeleteClientForm.CustomImages.Parent = this.btnShowDeleteClientForm;
            this.btnShowDeleteClientForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnShowDeleteClientForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnShowDeleteClientForm.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDeleteClientForm.ForeColor = System.Drawing.Color.White;
            this.btnShowDeleteClientForm.HoverState.Parent = this.btnShowDeleteClientForm;
            this.btnShowDeleteClientForm.Image = global::UI.Properties.Resources.Delete_Client;
            this.btnShowDeleteClientForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowDeleteClientForm.Location = new System.Drawing.Point(19, 202);
            this.btnShowDeleteClientForm.Margin = new System.Windows.Forms.Padding(19, 3, 3, 10);
            this.btnShowDeleteClientForm.Name = "btnShowDeleteClientForm";
            this.btnShowDeleteClientForm.ShadowDecoration.Parent = this.btnShowDeleteClientForm;
            this.btnShowDeleteClientForm.Size = new System.Drawing.Size(202, 35);
            this.btnShowDeleteClientForm.TabIndex = 9;
            this.btnShowDeleteClientForm.Text = "Delete Client";
            this.btnShowDeleteClientForm.Click += new System.EventHandler(this.btnShowDeleteClientForm_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTransactions.BackColor = System.Drawing.Color.Transparent;
            this.btnTransactions.BorderRadius = 5;
            this.btnTransactions.CheckedState.Parent = this.btnTransactions;
            this.btnTransactions.CustomImages.Parent = this.btnTransactions;
            this.btnTransactions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnTransactions.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(86)))), ((int)(((byte)(100)))));
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.Color.White;
            this.btnTransactions.HoverState.Parent = this.btnTransactions;
            this.btnTransactions.Image = global::UI.Properties.Resources.Transactions;
            this.btnTransactions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransactions.Location = new System.Drawing.Point(19, 250);
            this.btnTransactions.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.ShadowDecoration.Parent = this.btnTransactions;
            this.btnTransactions.Size = new System.Drawing.Size(202, 35);
            this.btnTransactions.TabIndex = 9;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeposit.BackColor = System.Drawing.Color.Transparent;
            this.btnDeposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeposit.BorderRadius = 5;
            this.btnDeposit.CheckedState.Parent = this.btnDeposit;
            this.btnDeposit.CustomImages.Parent = this.btnDeposit;
            this.btnDeposit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnDeposit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnDeposit.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.ForeColor = System.Drawing.Color.White;
            this.btnDeposit.HoverState.Parent = this.btnDeposit;
            this.btnDeposit.Image = global::UI.Properties.Resources.Deposit;
            this.btnDeposit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDeposit.Location = new System.Drawing.Point(19, 291);
            this.btnDeposit.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.ShadowDecoration.Parent = this.btnDeposit;
            this.btnDeposit.Size = new System.Drawing.Size(202, 35);
            this.btnDeposit.TabIndex = 9;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.Visible = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWithdraw.BackColor = System.Drawing.Color.Transparent;
            this.btnWithdraw.BorderRadius = 5;
            this.btnWithdraw.CheckedState.Parent = this.btnWithdraw;
            this.btnWithdraw.CustomImages.Parent = this.btnWithdraw;
            this.btnWithdraw.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnWithdraw.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnWithdraw.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnWithdraw.HoverState.Parent = this.btnWithdraw;
            this.btnWithdraw.Image = global::UI.Properties.Resources.Withdraw;
            this.btnWithdraw.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnWithdraw.Location = new System.Drawing.Point(19, 332);
            this.btnWithdraw.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.ShadowDecoration.Parent = this.btnWithdraw;
            this.btnWithdraw.Size = new System.Drawing.Size(202, 35);
            this.btnWithdraw.TabIndex = 10;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.Visible = false;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnTotalBalances
            // 
            this.btnTotalBalances.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTotalBalances.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalBalances.BorderRadius = 5;
            this.btnTotalBalances.CheckedState.Parent = this.btnTotalBalances;
            this.btnTotalBalances.CustomImages.Parent = this.btnTotalBalances;
            this.btnTotalBalances.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnTotalBalances.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnTotalBalances.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalBalances.ForeColor = System.Drawing.Color.White;
            this.btnTotalBalances.HoverState.Parent = this.btnTotalBalances;
            this.btnTotalBalances.Image = global::UI.Properties.Resources.Total_Balances;
            this.btnTotalBalances.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTotalBalances.Location = new System.Drawing.Point(19, 373);
            this.btnTotalBalances.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnTotalBalances.Name = "btnTotalBalances";
            this.btnTotalBalances.ShadowDecoration.Parent = this.btnTotalBalances;
            this.btnTotalBalances.Size = new System.Drawing.Size(202, 35);
            this.btnTotalBalances.TabIndex = 11;
            this.btnTotalBalances.Text = "Total Balances";
            this.btnTotalBalances.Visible = false;
            this.btnTotalBalances.Click += new System.EventHandler(this.btnTotalBalances_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTransfer.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfer.BorderRadius = 5;
            this.btnTransfer.CheckedState.Parent = this.btnTransfer;
            this.btnTransfer.CustomImages.Parent = this.btnTransfer;
            this.btnTransfer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnTransfer.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.HoverState.Parent = this.btnTransfer;
            this.btnTransfer.Image = global::UI.Properties.Resources.Transfer;
            this.btnTransfer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransfer.Location = new System.Drawing.Point(19, 414);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.ShadowDecoration.Parent = this.btnTransfer;
            this.btnTransfer.Size = new System.Drawing.Size(202, 35);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.Visible = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnTransferLog
            // 
            this.btnTransferLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTransferLog.BackColor = System.Drawing.Color.Transparent;
            this.btnTransferLog.BorderRadius = 5;
            this.btnTransferLog.CheckedState.Parent = this.btnTransferLog;
            this.btnTransferLog.CustomImages.Parent = this.btnTransferLog;
            this.btnTransferLog.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnTransferLog.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnTransferLog.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferLog.ForeColor = System.Drawing.Color.White;
            this.btnTransferLog.HoverState.Parent = this.btnTransferLog;
            this.btnTransferLog.Image = global::UI.Properties.Resources.Transfer_Log;
            this.btnTransferLog.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransferLog.Location = new System.Drawing.Point(19, 455);
            this.btnTransferLog.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnTransferLog.Name = "btnTransferLog";
            this.btnTransferLog.ShadowDecoration.Parent = this.btnTransferLog;
            this.btnTransferLog.Size = new System.Drawing.Size(202, 35);
            this.btnTransferLog.TabIndex = 13;
            this.btnTransferLog.Text = "Transfer Log";
            this.btnTransferLog.Visible = false;
            this.btnTransferLog.Click += new System.EventHandler(this.btnTransferLog_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnManageUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnManageUsers.BorderRadius = 5;
            this.btnManageUsers.CheckedState.Parent = this.btnManageUsers;
            this.btnManageUsers.CustomImages.Parent = this.btnManageUsers;
            this.btnManageUsers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.btnManageUsers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(86)))), ((int)(((byte)(100)))));
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.HoverState.Parent = this.btnManageUsers;
            this.btnManageUsers.Image = global::UI.Properties.Resources.Manage_Users;
            this.btnManageUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageUsers.Location = new System.Drawing.Point(19, 503);
            this.btnManageUsers.Margin = new System.Windows.Forms.Padding(19, 10, 3, 3);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.ShadowDecoration.Parent = this.btnManageUsers;
            this.btnManageUsers.Size = new System.Drawing.Size(202, 35);
            this.btnManageUsers.TabIndex = 21;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnListUsers
            // 
            this.btnListUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnListUsers.BorderRadius = 5;
            this.btnListUsers.CheckedState.Parent = this.btnListUsers;
            this.btnListUsers.CustomImages.Parent = this.btnListUsers;
            this.btnListUsers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnListUsers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnListUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListUsers.ForeColor = System.Drawing.Color.White;
            this.btnListUsers.HoverState.Parent = this.btnListUsers;
            this.btnListUsers.Image = global::UI.Properties.Resources.ListClients;
            this.btnListUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnListUsers.Location = new System.Drawing.Point(19, 542);
            this.btnListUsers.Margin = new System.Windows.Forms.Padding(19, 1, 3, 3);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.ShadowDecoration.Parent = this.btnListUsers;
            this.btnListUsers.Size = new System.Drawing.Size(202, 35);
            this.btnListUsers.TabIndex = 16;
            this.btnListUsers.Text = "List Users";
            this.btnListUsers.Visible = false;
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.BorderRadius = 5;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnAddUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Image = global::UI.Properties.Resources.Add_Client;
            this.btnAddUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddUser.Location = new System.Drawing.Point(19, 583);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(202, 35);
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Visible = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindUser.BackColor = System.Drawing.Color.Transparent;
            this.btnFindUser.BorderRadius = 5;
            this.btnFindUser.CheckedState.Parent = this.btnFindUser;
            this.btnFindUser.CustomImages.Parent = this.btnFindUser;
            this.btnFindUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnFindUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnFindUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUser.ForeColor = System.Drawing.Color.White;
            this.btnFindUser.HoverState.Parent = this.btnFindUser;
            this.btnFindUser.Image = global::UI.Properties.Resources.Find_Client;
            this.btnFindUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFindUser.Location = new System.Drawing.Point(19, 624);
            this.btnFindUser.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.ShadowDecoration.Parent = this.btnFindUser;
            this.btnFindUser.Size = new System.Drawing.Size(202, 35);
            this.btnFindUser.TabIndex = 20;
            this.btnFindUser.Text = "Find User";
            this.btnFindUser.Visible = false;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateUser.BorderRadius = 5;
            this.btnUpdateUser.CheckedState.Parent = this.btnUpdateUser;
            this.btnUpdateUser.CustomImages.Parent = this.btnUpdateUser;
            this.btnUpdateUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnUpdateUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.HoverState.Parent = this.btnUpdateUser;
            this.btnUpdateUser.Image = global::UI.Properties.Resources.Update_Client;
            this.btnUpdateUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpdateUser.Location = new System.Drawing.Point(19, 665);
            this.btnUpdateUser.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.ShadowDecoration.Parent = this.btnUpdateUser;
            this.btnUpdateUser.Size = new System.Drawing.Size(202, 35);
            this.btnUpdateUser.TabIndex = 19;
            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.Visible = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteUser.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.BorderRadius = 5;
            this.btnDeleteUser.CheckedState.Parent = this.btnDeleteUser;
            this.btnDeleteUser.CustomImages.Parent = this.btnDeleteUser;
            this.btnDeleteUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.btnDeleteUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(156)))));
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.HoverState.Parent = this.btnDeleteUser;
            this.btnDeleteUser.Image = global::UI.Properties.Resources.Delete_Client;
            this.btnDeleteUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDeleteUser.Location = new System.Drawing.Point(19, 706);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(19, 3, 3, 3);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.ShadowDecoration.Parent = this.btnDeleteUser;
            this.btnDeleteUser.Size = new System.Drawing.Size(202, 35);
            this.btnDeleteUser.TabIndex = 18;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Visible = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAIChatBot
            // 
            this.btnAIChatBot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAIChatBot.BackColor = System.Drawing.Color.Transparent;
            this.btnAIChatBot.BorderColor = System.Drawing.Color.Transparent;
            this.btnAIChatBot.CheckedState.Parent = this.btnAIChatBot;
            this.btnAIChatBot.CustomImages.Parent = this.btnAIChatBot;
            this.btnAIChatBot.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnAIChatBot.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnAIChatBot.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIChatBot.ForeColor = System.Drawing.Color.White;
            this.btnAIChatBot.HoverState.Parent = this.btnAIChatBot;
            this.btnAIChatBot.Image = global::UI.Properties.Resources.ListClients;
            this.btnAIChatBot.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAIChatBot.Location = new System.Drawing.Point(1116, 705);
            this.btnAIChatBot.Margin = new System.Windows.Forms.Padding(19, 10, 3, 10);
            this.btnAIChatBot.Name = "btnAIChatBot";
            this.btnAIChatBot.PressedColor = System.Drawing.Color.Transparent;
            this.btnAIChatBot.ShadowDecoration.Parent = this.btnAIChatBot;
            this.btnAIChatBot.Size = new System.Drawing.Size(202, 35);
            this.btnAIChatBot.TabIndex = 12;
            this.btnAIChatBot.Text = "AI ChatBot";
            this.btnAIChatBot.Click += new System.EventHandler(this.btnAIChatBot_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1341, 756);
            this.Controls.Add(this.btnAIChatBot);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(251, 0, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.guna2ControlBox1, 0);
            this.Controls.SetChildIndex(this.guna2ControlBox2, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pbLogo, 0);
            this.Controls.SetChildIndex(this.btnAIChatBot, 0);
            this.Controls.SetChildIndex(this.lblDateTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnShowListClientsForm;
        private Guna.UI2.WinForms.Guna2GradientButton btnShowAddClientForm;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdateClient;
        private Guna.UI2.WinForms.Guna2GradientButton btnShowDeleteClientForm;
        private Guna.UI2.WinForms.Guna2GradientButton btnTransactions;
        private Guna.UI2.WinForms.Guna2GradientButton btnTransferLog;
        private Guna.UI2.WinForms.Guna2GradientButton btnTransfer;
        private Guna.UI2.WinForms.Guna2GradientButton btnTotalBalances;
        private Guna.UI2.WinForms.Guna2GradientButton btnWithdraw;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeposit;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageUsers;
        private Guna.UI2.WinForms.Guna2GradientButton btnFindUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdateUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeleteUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnListUsers;
        private Guna.UI2.WinForms.Guna2GradientButton btnFindClient;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pbLogo;
        private Guna.UI2.WinForms.Guna2GradientButton btnAIChatBot;
    }
}

