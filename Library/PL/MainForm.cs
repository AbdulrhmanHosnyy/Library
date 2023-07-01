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
using Library.BL;
using Library.PL.BookForms;
using Library.PL.UserForms;

namespace Library.PL
{
    public partial class MainForm : Form
    {
        string State;
        int Id;
        //  Var for category
        Category Category = new Category();
        //  Var for books
        Book Book = new Book();
        //  Vor for students
        Student Student = new Student();
        // var for sell
        Sell Sell = new Sell();
        // var for Borrow
        Borrow Borrow = new Borrow();
        // var for User
        User User = new User();
        public MainForm()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (MainbarPanel.Size.Width == 175)
            {
                MainbarPanel.Width = 50;
                button1.RightToLeft = RightToLeft.Yes;
                button2.RightToLeft = RightToLeft.Yes;
                button3.RightToLeft = RightToLeft.Yes;
                button4.RightToLeft = RightToLeft.Yes;
                button5.RightToLeft = RightToLeft.Yes;
                button6.RightToLeft = RightToLeft.Yes;
                button7.RightToLeft = RightToLeft.Yes;
                UserName.Visible = false;
                UserPerm.Visible = false;

            }
            else
            {
                MainbarPanel.Width = 175;
                button1.RightToLeft = RightToLeft.No;
                button2.RightToLeft = RightToLeft.No;
                button3.RightToLeft = RightToLeft.No;
                button4.RightToLeft = RightToLeft.No;
                button5.RightToLeft = RightToLeft.No;
                button6.RightToLeft = RightToLeft.No;
                button7.RightToLeft = RightToLeft.No;
                UserName.Visible = true;
                UserPerm.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = true;
            bunifuThinButton24.Visible = false;
            State = "Borrow";
            TitleLabel.Text = "Borrow";
            if (State == "Borrow")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Borrow.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    dataGridView1.Columns[2].HeaderText = "Book Title";
                    dataGridView1.Columns[3].HeaderText = "Borrowing Date";
                    dataGridView1.Columns[4].HeaderText = "Returning Date";
                    dataGridView1.Columns[5].HeaderText = "Book Price";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            // Book Details
            if (State == "Book")
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Book.LoadEdit(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dataTable.Rows[0]["TITLE"];
                    object obj2 = dataTable.Rows[0]["AUTHOR"];
                    object obj3 = dataTable.Rows[0]["CATEGORY"];
                    object obj4 = dataTable.Rows[0]["PRICE"];
                    object obj5 = dataTable.Rows[0]["BOOKDATE"];
                    object obj6 = dataTable.Rows[0]["RATE"];
                    object obj7 = dataTable.Rows[0]["COVER"];
                    BookDetails bookDetails = new BookDetails();
                    bookDetails.TextBox1.Text = obj1.ToString();
                    bookDetails.TextBox2.Text = obj2.ToString();
                    bookDetails.comboBox1.Text = obj3.ToString();
                    bookDetails.TextBox3.Text = obj4.ToString();
                    bookDetails.TextDate.Value = (DateTime)obj5;
                    bookDetails.TextRate.Value = (int)obj6;
                    byte[] bytes = (byte[])obj7;
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    bookDetails.pictureBox1.Image = Image.FromStream(memoryStream);
                    bunifuTransition1.ShowSync(bookDetails);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //  Edit Student:
            else if (State == "Student")
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Student.LoadEdit(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dataTable.Rows[0]["StudentName"];
                    object obj2 = dataTable.Rows[0]["StudentLocation"];
                    object obj3 = dataTable.Rows[0]["Phone"];
                    object obj4 = dataTable.Rows[0]["Email"];
                    object obj5 = dataTable.Rows[0]["School"];
                    object obj6 = dataTable.Rows[0]["Department"];
                    object obj7 = dataTable.Rows[0]["Cover"];
                    StudentDetails studentDetails = new StudentDetails();
                    studentDetails.TextBox1.Text = obj1.ToString();
                    studentDetails.TextBox2.Text = obj2.ToString();
                    studentDetails.TextBox3.Text = obj3.ToString();
                    studentDetails.TextBox4.Text = obj4.ToString();
                    studentDetails.TextBox5.Text = obj5.ToString();
                    studentDetails.TextBox6.Text = obj6.ToString();
                    byte[] bytes = (byte[])obj7;
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    studentDetails.pictureBox1.Image = Image.FromStream(memoryStream);
                    bunifuTransition1.ShowSync(studentDetails);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = true;
            bunifuThinButton24.Visible = false;
            State = "Category";
            TitleLabel.Text = "Category";
            if (State == "Category")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Category.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Category Name";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HomePanel.Visible = true;
            MainPanel.Visible = false;
            TitleLabel.Text = "Home";

        }



        private void MainForm_Activated(object sender, EventArgs e)
        {
            // Count Calculator:
            try
            {
                DataTable dt = new DataTable();
                dt = Book.Load();
                BookCount.Text = dt.Rows.Count.ToString();
                dt = Student.Load();
                StudentCount.Text = dt.Rows.Count.ToString();
                dt = Sell.Load();
                SalesCount.Text = dt.Rows.Count.ToString();
                dt = Borrow.Load();
                BorrowCount.Text = dt.Rows.Count.ToString();
                dt = Category.Load();
                CategoryCount.Text = dt.Rows.Count.ToString();
                dt = User.Load();
                UserCount.Text = dt.Rows.Count.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            
            //  for permissions:
            if(UserPerm.Text == "Manager")
            {
                button6.Enabled = true;
                bunifuThinButton23.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
                bunifuThinButton23.Enabled = false;
            }
            if (State == "Category")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Category.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Category Name";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "Book")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Book.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Book Name";
                    dataGridView1.Columns[2].HeaderText = "Book Author";
                    dataGridView1.Columns[3].HeaderText = "Book Category";
                    dataGridView1.Columns[4].HeaderText = "Book Price";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "Student")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Student.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Name";
                    dataGridView1.Columns[2].HeaderText = "Location";
                    dataGridView1.Columns[3].HeaderText = "Phone number";
                    dataGridView1.Columns[4].HeaderText = "Email";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "Sell")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Sell.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    dataGridView1.Columns[2].HeaderText = "Book Title";
                    dataGridView1.Columns[3].HeaderText = "Book Price";
                    dataGridView1.Columns[4].HeaderText = "Selling Date";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "Borrow")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Borrow.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    dataGridView1.Columns[2].HeaderText = "Book Title";
                    dataGridView1.Columns[3].HeaderText = "Borrowing Date";
                    dataGridView1.Columns[4].HeaderText = "Returning Date";
                    dataGridView1.Columns[5].HeaderText = "Book Price";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "User")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = User.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Full Name";
                    dataGridView1.Columns[2].HeaderText = "User Name";
                    dataGridView1.Columns[3].HeaderText = "Password";
                    dataGridView1.Columns[4].HeaderText = "State";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //  Add Category:
            if (State == "Category")
            {
                CategoryHelper addCategory = new CategoryHelper();
                addCategory.Button.ButtonText = "Add";
                addCategory.id = 0;
                bunifuTransition1.ShowSync(addCategory);
            }
            //  Add Book:
            if (State == "Book")
            {
                BookHelper addBook = new BookHelper();
                addBook.Button.ButtonText = "Add";
                addBook.id = 0;
                bunifuTransition1.ShowSync(addBook);
            }
            //  Add Student:
            if (State == "Student")
            {
                StudentHelper addStudent = new StudentHelper();
                addStudent.Button.ButtonText = "Add";
                addStudent.id = 0;
                bunifuTransition1.ShowSync(addStudent);
            }
            //  Add Sell:
            if (State == "Sell")
            {
                SellHelper addSell = new SellHelper();
                addSell.Button.ButtonText = "Add";
                addSell.id = 0;
                bunifuTransition1.ShowSync(addSell);
            }
            //  Add Borrow:
            if (State == "Borrow")
            {
                BorrowHelper addBorrow = new BorrowHelper();
                addBorrow.Button.ButtonText = "Add";
                addBorrow.id = 0;
                bunifuTransition1.ShowSync(addBorrow);
            }
            //  Add User:
            if (State == "User")
            {
                UserHelper userHelper = new UserHelper();
                userHelper.Button.ButtonText = "Add";
                //userHelper.id = 0;
                bunifuTransition1.ShowSync(userHelper);
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //  Edit Category:
            if (State == "Category")
            {
                CategoryHelper editCategory = new CategoryHelper();
                editCategory.Button.ButtonText = "Edit";
                editCategory.TextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                editCategory.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                bunifuTransition1.ShowSync(editCategory);
            }
            //  Edit Book:
            else if (State == "Book")
            {
                try
                {
                    BookHelper editBook = new BookHelper();
                    editBook.Button.ButtonText = "Edit";
                    editBook.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dataTable = new DataTable();
                    dataTable = Book.LoadEdit(editBook.id);
                    object obj1 = dataTable.Rows[0]["TITLE"];
                    object obj2 = dataTable.Rows[0]["AUTHOR"];
                    object obj3 = dataTable.Rows[0]["CATEGORY"];
                    object obj4 = dataTable.Rows[0]["PRICE"];
                    object obj5 = dataTable.Rows[0]["BOOKDATE"];
                    object obj6 = dataTable.Rows[0]["RATE"];
                    object obj7 = dataTable.Rows[0]["COVER"];
                    editBook.TextBox1.Text = obj1.ToString();
                    editBook.TextBox2.Text = obj2.ToString();
                    editBook.comboBox1.Text = obj3.ToString();
                    editBook.TextBox3.Text = obj4.ToString();
                    editBook.TextDate.Value = (DateTime)obj5;
                    editBook.TextRate.Value = (int)obj6;
                    byte[] bytes = (byte[])obj7;
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    editBook.pictureBox1.Image = Image.FromStream(memoryStream);
                    bunifuTransition1.ShowSync(editBook);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //  Edit Student:
            else if (State == "Student")
            {
                try
                {
                    StudentHelper editStudent = new StudentHelper();
                    editStudent.Button.ButtonText = "Edit";
                    editStudent.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dataTable = new DataTable();
                    dataTable = Student.LoadEdit(editStudent.id);
                    object obj1 = dataTable.Rows[0]["StudentName"];
                    object obj2 = dataTable.Rows[0]["StudentLocation"];
                    object obj3 = dataTable.Rows[0]["Phone"];
                    object obj4 = dataTable.Rows[0]["Email"];
                    object obj5 = dataTable.Rows[0]["School"];
                    object obj6 = dataTable.Rows[0]["Department"];
                    object obj7 = dataTable.Rows[0]["Cover"];
                    editStudent.TextBox1.Text = obj1.ToString();
                    editStudent.TextBox2.Text = obj2.ToString();
                    editStudent.TextBox3.Text = obj3.ToString();
                    editStudent.TextBox4.Text = obj4.ToString();
                    editStudent.TextBox5.Text = obj5.ToString();
                    editStudent.TextBox6.Text = obj6.ToString();
                    byte[] bytes = (byte[])obj7;
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    editStudent.pictureBox1.Image = Image.FromStream(memoryStream);
                    bunifuTransition1.ShowSync(editStudent);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //  Edit Sell:
            else if (State == "Sell")
            {
                try
                {
                    SellHelper editSell = new SellHelper();
                    editSell.Button.ButtonText = "Edit";
                    editSell.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    bunifuTransition1.ShowSync(editSell);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            //  Edit Borrow:
            else if (State == "Borrow")
            {
                try
                {
                    BorrowHelper editBorrow = new BorrowHelper();
                    editBorrow.Button.ButtonText = "Edit";
                    editBorrow.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    bunifuTransition1.ShowSync(editBorrow);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            //  Edit User:
            else if (State == "User")
            {
                try
                {
                    UserHelper editUser = new UserHelper();
                    editUser.Button.ButtonText = "Edit";
                    editUser.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    bunifuTransition1.ShowSync(editUser);
                }
                catch (Exception) 
                {
                    throw;
                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //  Delete Category:
            if (State == "Category")
            {
                Category.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
            //  Delete Book:
            if (State == "Book")
            {
                Book.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
            //  Delete Student:
            if (State == "Student")
            {
                Student.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
            //  Delete Sell:
            if (State == "Sell")
            {
                
                Sell.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
            //  Delete Borrow:
            if (State == "Borrow")
            {

                Borrow.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
            //  Delete User:
            if (State == "User")
            {

                User.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                DeleteDialog deleteDialog = new DeleteDialog();
                deleteDialog.Show();
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //  Search Category:
            if (State == "Category")
            {
                DataTable dataTable = new DataTable();
                dataTable = Category.Search(SearchBox.Text);
                dataGridView1.DataSource = dataTable;

            }
            //  Search Book:
            else if (State == "Book")
            {
                DataTable dataTable = new DataTable();
                dataTable = Book.Search(SearchBox.Text);
                dataGridView1.DataSource = dataTable;

            }
            //  Search Student:
            else if (State == "Student")
            {
                DataTable dataTable = new DataTable();
                dataTable = Student.Search(SearchBox.Text);
                dataGridView1.DataSource = dataTable;
            }
            //  Search Sell:
            else if (State == "Sell")
            {
                DataTable dataTable = new DataTable();
                dataTable = Sell.Search(SearchBox.Text);
                dataGridView1.DataSource = dataTable;
            }
            //  Search Borrow:
            else if (State == "Borrow")
            {
                DataTable dataTable = new DataTable();
                dataTable = Borrow.Search(SearchBox.Text);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = true;
            bunifuThinButton24.Visible = true;
            State = "Book";
            TitleLabel.Text = "Book";
            if (State == "Book")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Book.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Book Name";
                    dataGridView1.Columns[2].HeaderText = "Book Author";
                    dataGridView1.Columns[3].HeaderText = "Book Category";
                    dataGridView1.Columns[4].HeaderText = "Book Price";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = true;
            bunifuThinButton24.Visible = true;
            State = "Student";
            TitleLabel.Text = "Student";
            if (State == "Student")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Student.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Name";
                    dataGridView1.Columns[2].HeaderText = "Location";
                    dataGridView1.Columns[3].HeaderText = "Phone number";
                    dataGridView1.Columns[4].HeaderText = "Email";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = true;
            bunifuThinButton24.Visible = false;
            State = "Sell";
            TitleLabel.Text = "Sell";
            if (State == "Sell")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = Sell.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    dataGridView1.Columns[2].HeaderText = "Book Title";
                    dataGridView1.Columns[3].HeaderText = "Book Price";
                    dataGridView1.Columns[4].HeaderText = "Selling Date";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            MainPanel.Visible = true;
            SearchBox.Visible = false;
            bunifuThinButton24.Visible = false;
            State = "User";
            TitleLabel.Text = "User";
            if (State == "User")
            {
                //  Load data:
                try
                {
                    DataTable dataTable = new DataTable();
                    dataTable = User.Load();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Full Name";
                    dataGridView1.Columns[2].HeaderText = "User Name";
                    dataGridView1.Columns[3].HeaderText = "Password";
                    dataGridView1.Columns[4].HeaderText = "Permissions";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            User.LogOut();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = true;
            MainPanel.Visible = false;
            TitleLabel.Text = "Home";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CategoryHelper addCategory = new CategoryHelper();
            addCategory.Button.ButtonText = "Add";
            addCategory.id = 0;
            bunifuTransition1.ShowSync(addCategory);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            BorrowHelper addBorrow = new BorrowHelper();
            addBorrow.Button.ButtonText = "Add";
            addBorrow.id = 0;
            bunifuTransition1.ShowSync(addBorrow);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SellHelper addSell = new SellHelper();
            addSell.Button.ButtonText = "Add";
            addSell.id = 0;
            bunifuTransition1.ShowSync(addSell);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentHelper addStudent = new StudentHelper();
            addStudent.Button.ButtonText = "Add";
            addStudent.id = 0;
            bunifuTransition1.ShowSync(addStudent);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BookHelper addBook = new BookHelper();
            addBook.Button.ButtonText = "Add";
            addBook.id = 0;
            bunifuTransition1.ShowSync(addBook);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }
    }
}
