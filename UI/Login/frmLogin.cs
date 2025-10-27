using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankPresentationLayer
{
    public partial class frmLogin : frmBase
    {

        UserBusiness UserObject;

        public bool IsValidUserNameAndPassword = false;

        public static byte LoginTimes = 3;

        public frmLogin()
        {
            InitializeComponent();
        }

      
        private void btnLogin_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

            bool HasErrors = false;

            if(string.IsNullOrWhiteSpace(UserName))
            {
                errorProvider1.SetError(txtUserName , "Username is required.");
                HasErrors = true;
            }

            if(string.IsNullOrWhiteSpace(Password))
            {
                errorProvider1.SetError(txtPassword, "Password is requierd.");
                HasErrors = true;
            }
           
            if(HasErrors)
            {
                return;
            }

            UserObject = UserBusiness.FindUser(UserName);

            if (UserObject == null)
            {
                MessageBox.Show($"User With UserName '{UserName}' is not exist");
            }
            else
            {

                if (!UserObject.Login(UserName, Password))
                {
                    LoginTimes--;

                    MessageBox.Show($"Incorrect Passowrd you still have {LoginTimes} try(s).");
                }
                else
                {
                    IsValidUserNameAndPassword = true;
                    GlobaCurrentlUser.CurrentUser = UserObject;

                    if(!UserObject._RegesterALogin())
                    {
                        MessageBox.Show("Couldn't regester the login operation in database.");
                    }

                    this.Close();
                }

                if (LoginTimes == 0)
                {

                    IsValidUserNameAndPassword = false;
                    this.Close();
                }

            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "Admin";
            txtPassword.Text = "1234";
        }

       
    }
}
