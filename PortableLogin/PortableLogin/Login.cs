using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortableLogin.Resources;
using MetroFramework;
namespace PortableLogin
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        #region properties
        private string username;

        public string Username
        {
            get
            {
                if (User.isValidPassword(mtxtUsername.Text))
                    return mtxtUsername.Text;
                else
                    return null;
            }
        }

        private string password;

        public string Password
        {
            get
            {
                if (User.isValidPassword(mtxtPassword.Text))
                    return mtxtPassword.Text;
                else
                    return null;
            }
        }
        #endregion
        #region constructors
        public Login()
        {
            InitializeComponent();
        }
        #endregion
        #region events
        private void mBtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
                MetroMessageBox.Show(this,English.InvalidUsernameOrpassword,"Error",120);
            else
            {
                User validUser = FileMinapulation.ReadUserNameAndPassword();

                if (validUser == null)
                    MetroMessageBox.Show(this, English.FileNotFound, "Error", 120);
                else
                {
                    if (this.Username.ToLower() == validUser.Username.ToLower() &&
                         User.hashPassword(this.Password) == validUser.Password)
                    {
                        Welcome welcomeForm = new Welcome();
                        welcomeForm.Width = this.Width;
                        welcomeForm.Height = this.Height;
                        welcomeForm.StartPosition = FormStartPosition.Manual;
                        welcomeForm.Location = new Point(this.Location.X, this.Location.Y);
                        this.Hide();
                        welcomeForm.ShowDialog();
                    }
                    else
                        MetroMessageBox.Show(this, English.NotFoundCredentials, "Error", 120);
                }
            }

        }
        #endregion

      
    }

}
