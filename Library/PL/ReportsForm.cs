using Library.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.BL;
namespace Library.PL
{
    public partial class ReportsForm : Form
    {
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
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            Reporter.Text = mainForm.UserName.Text;
            ReporterPosition.Text = mainForm.UserPerm.Text;
            ReportDate.Text = DateTime.Now.ToString();
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(img, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(img, 0, 0);
        }
    }
}
