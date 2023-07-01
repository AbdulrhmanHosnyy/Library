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
    class User
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading User
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadUser", parameters);
            return dataTable;
        }
        //  Adding User
        public void Add(string FullName, string UserName, string UserPassword, string Permissions, string State)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("FullName", FullName);
            parameters[1] = new SqlParameter("UserName", UserName);
            parameters[2] = new SqlParameter("UserPassword", UserPassword);
            parameters[3] = new SqlParameter("Permissions", Permissions);
            parameters[4] = new SqlParameter("State", State);


            DAL.Execute("PRAddUser", parameters);
        }
        //  Editting User
        public void Edit(int Id, string FullName, string UserName, string UserPassword, string Permissions)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("Id", Id);
            parameters[1] = new SqlParameter("FullName", FullName);
            parameters[2] = new SqlParameter("UserName", UserName);
            parameters[3] = new SqlParameter("UserPassword", UserPassword);
            parameters[4] = new SqlParameter("Permissions", Permissions);

            DAL.Execute("PREditUser", parameters);
        }
        //  Deleting sell
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", id);
            DAL.Execute("PRDeleteUser", parameters);
        }
        //  Logout
        public void LogOut()
        {
            SqlParameter[] parameters = null;

            DAL.Execute("PRLogOut", parameters);
        }

        //  Loading data for login
        public DataTable LogIn(string UserName, string UserPassword)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("UserName", UserName);
            parameters[1] = new SqlParameter("UserPassword", UserPassword);

            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLogIn", parameters);
            return dataTable;
        }
        //  Update data for login
        public void UpdateLogIn(string UserName, string UserPassword)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("UserName", UserName);
            parameters[1] = new SqlParameter("UserPassword", UserPassword);

            DAL.Execute("PRUpdateLogIn", parameters); 
        }

        //  Loading for start
        public DataTable Start()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRStart", parameters);
            return dataTable;
        }
    }
}
