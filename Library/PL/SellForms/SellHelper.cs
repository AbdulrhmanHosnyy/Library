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
    public partial class SellHelper: Form
    {
        public int id;
        public SellHelper()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void BookHelper_Load(object sender, EventArgs e)
        {
            Sell Sell = new Sell();
            //  Load Books
            DataTable dataTable1 = new DataTable();
            dataTable1 = Sell.LoadBook();
            dataGridView2.DataSource = dataTable1;
            DataTable dataTable2 = new DataTable();
            dataTable2 = Sell.LoadStudent();
            dataGridView1.DataSource = dataTable2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Button_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
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
                    Sell Sell = new Sell();
                    Sell.Add(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(TextBox1.Text), Convert.ToString(TextDate.Value));
                    AddDialog add = new AddDialog();
                    add.ShowDialog();
                    this.Close();
                }
                else
                {
                    Sell Sell = new Sell();
                    Sell.Edit(id,Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(TextBox1.Text), Convert.ToString(TextDate.Value));
                    EditDialog edit = new EditDialog();
                    edit.ShowDialog();
                    this.Close();
                }

            }
        }
    }
}
