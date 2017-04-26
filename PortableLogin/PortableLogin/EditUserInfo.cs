using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortableLogin.Resources;
using MetroFramework;
namespace PortableLogin
{
    public partial class EditUserInfo : MetroFramework.Forms.MetroForm
    {
        #region properties
        private string confirmedPassword;

        public string ConfirmedPassword
        {
            get
            {
                if (User.isValidPassword(txtConfirmPassword.Text))
                    return txtConfirmPassword.Text;
                else
                    return null;
            }
        }

        private string password;

        public string Password
        {
            get
            {
                if (User.isValidPassword(txtPassword.Text))
                    return txtPassword.Text;
                else
                    return null;
            }
        }
        #endregion
        #region  constructors
        public EditUserInfo()
        {
            InitializeComponent();
        }
        #endregion
        #region events
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ConfirmedPassword) || string.IsNullOrEmpty(this.Password))
               MetroMessageBox.Show(this, English.InvalidPassword, "Error", 120);
            else if(this.ConfirmedPassword!=this.Password)
                MetroMessageBox.Show(this, English.PasswordsMismatch, "Error", 120);
            else
                if (FileMinapulation.WritePassword(User.hashPassword(this.Password)) == true)
                {
                    MetroMessageBox.Show(this, English.Updated, "Success", 120);
                    Login loginForm = new Login();
                    loginForm.Width = this.Width;
                    loginForm.Height = this.Height;
                    loginForm.StartPosition = FormStartPosition.Manual;
                    loginForm.Location = new Point(this.Location.X, this.Location.Y);
                    this.Hide();
                    loginForm.ShowDialog();
                }
                else
                    MetroMessageBox.Show(this, English.UpdateError, "Error", 120);
        }
        #endregion

    }
}
