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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try 
            {
                User User = new User();
                DataTable dt = new DataTable();
                dt = User.LogIn(TextBox1.Text, TextBox2.Text);
                if (dt.Rows.Count > 0)
                {
                    User.UpdateLogIn(TextBox1.Text, TextBox2.Text);
                    MainForm mainForm = new MainForm();
                    object UserName = dt.Rows[0]["FullName"];
                    object UserPerm = dt.Rows[0]["Permissions"];
                    mainForm.UserName.Text = UserName.ToString();
                    mainForm.UserPerm.Text = UserPerm.ToString();
                    mainForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invlid UserName or Password");
                }
            }  
            catch (Exception ex)
            {
                MessageBox.Show("Invlid UserName or Password");
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
