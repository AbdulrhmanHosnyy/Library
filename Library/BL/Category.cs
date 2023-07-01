using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library.DAL;

namespace Library.BL
{
    class Category
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading categories
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadCategory", parameters);
            return dataTable;
        }

        //  Search categories
        public DataTable Search(string Search)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Search", Search);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRSearchCategory", parameters);
            return dataTable;
        }

        //  Adding category
        public void Add(string CategoryName)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CategoryName", CategoryName);
            DAL.Execute("PRAddCategory", parameters);
        }

        //  Editing category
        public void Edit(string CategoryName, int id)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("CategoryName", CategoryName);
            parameters[1] = new SqlParameter("Id", id);
            DAL.Execute("PREditCategory", parameters);
        }

        //  Deleting category
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("ID", id);
            DAL.Execute("PRDeleteCategory", parameters);
        }
    }
}
