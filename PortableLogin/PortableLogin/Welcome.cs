using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
namespace PortableLogin
{
    public partial class Welcome : MetroFramework.Forms.MetroForm
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnEditLoginInfo_Click(object sender, EventArgs e)
        {
            EditUserInfo editUserInfoForm = new EditUserInfo();
            editUserInfoForm.Width = this.Width;
            editUserInfoForm.Height = this.Height;
            editUserInfoForm.StartPosition = FormStartPosition.Manual;
            editUserInfoForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            editUserInfoForm.ShowDialog();
        }

        
    }
}
