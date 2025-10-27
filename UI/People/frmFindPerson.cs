using BusinessLayer;
using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.SearchConstrants;

namespace BankPresentationLayer
{
    public partial class frmFindPerson : Form
    {
        // if 0 the sender form is add client , if 1 the sender form is add user.
        private bool? _SenderForm;
        public frmFindPerson(bool? senderForm)
        {
            InitializeComponent();
            _SenderForm = senderForm;
        }

        PersonBusiness PersonObject;

        private bool PersonFound = false;

        private void btnMakeaClintAccount_Click(object sender, EventArgs e)
        {
            if(PersonFound)
            {
                if(ClientsBusiness.IsClientExistByPersonId(PersonObject.PersonId))
                {
                    MessageBox.Show("This person already has a client account.", "Can't Create Multiple Client Accounts.");
                    return;
                }

                Form frmAddOnlyClient = new frmAddOnlyClient(PersonObject.PersonId);
                frmAddOnlyClient.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Search for a person first.");
            }
           
        }

        private void btnMakeUserAccount_Click(object sender, EventArgs e)
        {

            if(PersonFound)
            {
                if(UserBusiness.IsUserExistByPersonId(PersonObject.PersonId))
                {
                    MessageBox.Show("This person already has a user account.","Can't Create Multiple User Accounts.");
                    return;
                }

                Form frmAddOnlyUser = new frmAddOnlyUser(PersonObject.PersonId);
                frmAddOnlyUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Search for a person first.");

            }

        }

        private bool TryFindPerson()
        {

            if (cbSearchBy.SelectedIndex == 0)
            {
                PersonObject = PersonBusiness.FindPersonByEmail(txtFindBy.Text);

                if (PersonObject == null)
                    return false;
                else
                    return true;

            }

            if (cbSearchBy.SelectedIndex == 1)
            {
                PersonObject = PersonBusiness.FindPerson(Convert.ToInt32(txtFindBy.Text));
                if (PersonObject == null)
                    return false;
                else
                    return true;
            }

            return false;
        }

        private void FillPersonInfoLabels()
        {
            
            lblFirstName.Text = PersonObject.FirstName;
            lblLastName.Text = PersonObject.LastName;
            lblEmail.Text = PersonObject.Email;
            lblAddress.Text = PersonObject.Address;
            lblGender.Text = PersonObject.Gender.ToString();
            lblBirthDate.Text = PersonObject.BirthDate.ToString("dd/MM/yyyy");
        }

        private bool ValidateSearchbox()
        {
            // Validate PersonId length + positive numbers only
            bool IsValid = true;
            switch(cbSearchBy.SelectedIndex)
            {

                case 0:
                    // Validate emai
                   
                    if (string.IsNullOrWhiteSpace(txtFindBy.Text))
                    {
                        errorProvider1.SetError(txtFindBy, "Email cannot be empty.");
                        IsValid = false;
                    }
                    else
                    {
                        try
                        {
                            MailAddress m = new MailAddress(txtFindBy.Text);

                            string[] parts = txtFindBy.Text.Split('@');
                            string localPart = parts[0]; // before @
                            string domainPart = parts[1]; // after @

                            // Check local part length
                            if (localPart.Length < 2 || localPart.Length > 64)
                            {
                                errorProvider1.SetError(txtFindBy, "Email username (before @) must be 2-64 characters.");
                                IsValid = false;
                            }
                            // Check domain length
                            else if (domainPart.Length < 3 || domainPart.Length > 255)
                            {
                                errorProvider1.SetError(txtFindBy, "Email domain must be 3-255 characters.");
                                IsValid = false;
                            }
                            else
                            {
                                errorProvider1.SetError(txtFindBy, ""); // Email is valid
                            }
                        }
                        catch (FormatException)
                        {
                            errorProvider1.SetError(txtFindBy, "Invalid email format. Example: user@example.com");
                            IsValid = false;
                        }
                    }
                    break;

                case 1:

               if (string.IsNullOrEmpty(txtFindBy.Text) ||
               txtFindBy.Text.Length < 1 ||
               txtFindBy.Text.Length > 20 ||
               !Regex.IsMatch(txtFindBy.Text, @"^[1-9]\d*$")) // positive numbers only
                    {
                        errorProvider1.SetError(txtFindBy, "Person Id be 1-20 digits, positive only (no 0 at start).");
                        IsValid = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txtFindBy, "");
                    }
                    break;
            }

            return IsValid;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!ValidateSearchbox())
                return;

            if(TryFindPerson())
            {
                FillPersonInfoLabels();
                PersonFound = true;
            }
            else
            {
                MessageBox.Show("Person is not found.");
            }

            txtFindBy.Clear();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            cbSearchBy.SelectedIndex = 1;

            if(_SenderForm == false)
            {
                btnMakeaClintAccount.Visible = true;
                btnMakeUserAccount.Visible = false;
            }
            else
            {
                btnMakeUserAccount.Visible = true;
                btnMakeaClintAccount.Visible = false;

            }
        }


        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSearchBy.SelectedIndex)
            {
                case 0:
                    lblSearchBy.Text = "Email";
                    break;
                case 1:
                    lblSearchBy.Text = "Person ID";
                    break;
            }
        }

        private void gbUserInfoCard_Enter(object sender, EventArgs e)
        {

        }
    }
}
