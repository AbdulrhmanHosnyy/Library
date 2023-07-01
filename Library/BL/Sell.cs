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
    class Sell
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading sell
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadSell", parameters);
            return dataTable;
        }
        //  Loading book
        public DataTable LoadBook()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadBookSell", parameters);
            return dataTable;
        }
        //  Loading Student
        public DataTable LoadStudent()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadStudentSell", parameters);
            return dataTable;
        }
        //  Adding Sell
        public void Add(string StudentName, string BookTitle, int BookPrice, string SellDate)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("StudentName", StudentName);
            parameters[1] = new SqlParameter("BookTitle", BookTitle);
            parameters[2] = new SqlParameter("BookPrice", BookPrice);
            parameters[3] = new SqlParameter("SellDate", SellDate);

            DAL.Execute("PRAddSell", parameters);
        }
        //  Editting Sell
        public void Edit(int Id, string StudentName, string BookTitle, int BookPrice, string SellDate)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("Id", Id);
            parameters[1] = new SqlParameter("StudentName", StudentName);
            parameters[2] = new SqlParameter("BookTitle", BookTitle);
            parameters[3] = new SqlParameter("BookPrice", BookPrice);
            parameters[4] = new SqlParameter("SellDate", SellDate);

            DAL.Execute("PREditSell", parameters);
        }
        //  Deleting sell
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", id);
            DAL.Execute("PRDeleteSell", parameters);
        }
        //  Search Sell
        public DataTable Search(string Search)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Search", Search);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRSearchSell", parameters);
            return dataTable;
        }

    }
}
