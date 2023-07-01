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

namespace Library.PL
{
    public partial class BookHelper : Form
    {
        public int id;
        public BookHelper()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void BookHelper_Load(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                DataTable dt = new DataTable();
                dt = book.LoadComboBox();
                object[] obj = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj[i] = dt.Rows[i]["CategoryName"];
                }
                comboBox1.Items.AddRange(obj);
            }
            catch
            {

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategoryHelper categoryHelper = new CategoryHelper();
            categoryHelper.Button.ButtonText = "Add";
            categoryHelper.id = 0;
            categoryHelper.Show();
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
                //  Add Book
                if (id == 0)
                {
                    Book Book = new Book();
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Book.Add(TextBox1.Text, TextBox2.Text, comboBox1.Text, TextBox3.Text, TextDate.Value.ToString(), TextRate.Value, memoryStream);
                    AddDialog add = new AddDialog();
                    add.ShowDialog();
                    this.Close();
                }
                else
                {
                    Book Book = new Book();
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Book.Edit(id, TextBox1.Text, TextBox2.Text, comboBox1.Text, TextBox3.Text, TextDate.Value.ToString(), TextRate.Value, memoryStream);
                    EditDialog edit = new EditDialog();
                    edit.ShowDialog();
                    this.Close();
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
