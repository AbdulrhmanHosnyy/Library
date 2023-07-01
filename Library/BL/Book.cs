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
    class Book
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading books
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadBooks", parameters);
            return dataTable;
        }

        //  Load ComboBox
        public DataTable LoadComboBox()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadCategoryToComboBox", parameters);
            return dataTable;
        }

        //  Adding book
        public void Add(string Title, string Author, string Category, string Price, string BookDate, int Rate, MemoryStream Cover)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("Title", Title);
            parameters[1] = new SqlParameter("Author", Author);
            parameters[2] = new SqlParameter("Category", Category);
            parameters[3] = new SqlParameter("Price", Price);
            parameters[4] = new SqlParameter("BookDate", BookDate);
            parameters[5] = new SqlParameter("Rate", Rate);
            parameters[6] = new SqlParameter("Cover", Cover.ToArray());

            DAL.Execute("PRAddBook", parameters);
        }

        //  Loading books to edit
        public DataTable LoadEdit(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("ID", ID);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadEditBooks", parameters);
            return dataTable;
        }

        //  Editing book
        public void Edit(int Id, string Title, string Author, string Category, string Price, string BookDate, int Rate, MemoryStream Cover)
        {
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("Id", Id);
            parameters[1] = new SqlParameter("Title", Title);
            parameters[2] = new SqlParameter("Author", Author);
            parameters[3] = new SqlParameter("Category", Category);
            parameters[4] = new SqlParameter("Price", Price);
            parameters[5] = new SqlParameter("BookDate", BookDate);
            parameters[6] = new SqlParameter("Rate", Rate);
            parameters[7] = new SqlParameter("Cover", Cover.ToArray());
            DAL.Execute("PREditBook", parameters);
        }

        //  Deleting book
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", id);
            DAL.Execute("PRDeleteBook", parameters);
        }

        //  Search book
        public DataTable Search(string Search)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Search", Search);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRSearchBook", parameters);
            return dataTable;
        }

    }
}
