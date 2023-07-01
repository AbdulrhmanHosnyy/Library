using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Library.BL;

namespace Library.PL
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             User User = new User();
            DataTable dt = new DataTable();
            dt = User.Start();
            if(dt.Rows.Count > 0 )
            {
                MainForm mainForm = new MainForm();
                object UserName = dt.Rows[0]["FullName"];
                object UserPerm = dt.Rows[0]["Permissions"];
                mainForm.UserName.Text = UserName.ToString();
                mainForm.UserPerm.Text = UserPerm.ToString();
                mainForm.Show();
                this.Hide();
                timer1.Enabled = false;
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
                timer1.Enabled = false;
            }
        }
    }
}
