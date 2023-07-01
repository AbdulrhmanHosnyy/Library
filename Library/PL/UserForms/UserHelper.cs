using Library.BL;
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


namespace Library.PL.UserForms
{
    public partial class UserHelper : Form
    {
        public int id;
        public UserHelper()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
            {
                ErrorDialog Error = new ErrorDialog();
                Error.ShowDialog();
                this.Close();
            }
            else
            {
                //  Add User
                if (id == 0)
                {
                    User User = new User();
                    User.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text, comboBox1.Text, "False");
                    AddDialog add = new AddDialog();
                    add.ShowDialog();
                    this.Close();
                }
                else
                {
                    User User = new User();
                    User.Edit(id, TextBox1.Text, TextBox2.Text, TextBox3.Text, comboBox1.Text);
                    EditDialog edit = new EditDialog();
                    edit.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
