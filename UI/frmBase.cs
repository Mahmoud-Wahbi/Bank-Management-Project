using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankPresentationLayer
{
    public partial class frmBase : Form
    {
        protected Label lblDateTime;
        protected Timer timer;

        public frmBase()
        {
            InitializeComponent();
            InitializeCommonControls();
            StartDateTimeUpdater();
        }

      

        private void InitializeCommonControls()
        {
            lblDateTime = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 10),
            };
            this.Controls.Add(lblDateTime);
        }

        private void StartDateTimeUpdater()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {

        }
    }
}
