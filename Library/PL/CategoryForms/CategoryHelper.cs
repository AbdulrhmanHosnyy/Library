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
    public partial class CategoryHelper : Form
    {
        public int id;
        public CategoryHelper()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoryHelper_Load(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                ErrorDialog Error = new ErrorDialog();
                Error.ShowDialog();
                this.Close();
            }
            else
            {
                //  Add Category
                if(id == 0)
                {
                    Category Category = new Category();
                    Category.Add(TextBox1.Text);
                    AddDialog add = new AddDialog();
                    add.ShowDialog();
                    this.Close();
                }
                else
                {
                    Category Category = new Category();
                    Category.Edit(TextBox1.Text, id);
                    EditDialog edit = new EditDialog();
                    edit.ShowDialog();
                    this.Close();
                }
                
            }
        }
    }
}
