using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library.DAL;
using System.Diagnostics;
using System.IO;
namespace Library.BL
{
    class Borrow
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading sell
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadBorrow", parameters);
            return dataTable;
        }
        //  Adding Borrow
        public void Add(string StudentName, string BookTitle, string BorrowDate, string ReturnDate, int BookPrice)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("StudentName", StudentName);
            parameters[1] = new SqlParameter("BookTitle", BookTitle);
            parameters[2] = new SqlParameter("BorrowDate", BorrowDate);
            parameters[3] = new SqlParameter("ReturnDate", ReturnDate);
            parameters[4] = new SqlParameter("BookPrice", BookPrice);
            DAL.Execute("PRAddBorrow", parameters);
        }
        //  Editting Borrow
        public void Edit(int Id, string StudentName, string BookTitle, string BorrowDate, string ReturnDate, int BookPrice)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("Id", Id);
            parameters[1] = new SqlParameter("StudentName", StudentName);
            parameters[2] = new SqlParameter("BookTitle", BookTitle);
            parameters[3] = new SqlParameter("BorrowDate", BorrowDate);
            parameters[4] = new SqlParameter("ReturnDate", ReturnDate);
            parameters[5] = new SqlParameter("BookPrice", BookPrice);

            DAL.Execute("PREditBorrow", parameters);
        }
        //  Deleting Borrow
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", id);
            DAL.Execute("PRDeleteBorrow", parameters);
        }
        //  Search Borrow
        public DataTable Search(string Search)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Search", Search);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRSearchBorrow", parameters);
            return dataTable;
        }
    }
}
