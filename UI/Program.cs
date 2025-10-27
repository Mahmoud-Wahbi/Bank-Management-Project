using BankPresentationLayer;
using BankProjectUi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmLogin LoginForm = new frmLogin();
            LoginForm.ShowDialog();

            if (LoginForm.IsValidUserNameAndPassword)
            {
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("Login Canceld of failed the application now will be closed.");
            }

        }
    }
}
