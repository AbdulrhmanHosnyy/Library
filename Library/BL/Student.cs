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
    class Student
    {
        DataAccessLayer DAL = new DataAccessLayer();

        //  Loading Students
        public DataTable Load()
        {
            SqlParameter[] parameters = null;
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadStudent", parameters);
            return dataTable;
        }

        //  Adding student
        public void Add(string StudentName, string StudentLocation, string Phone, string Email, string School, string Department, MemoryStream Cover)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("StudentName", StudentName);
            parameters[1] = new SqlParameter("StudentLocation", StudentLocation);
            parameters[2] = new SqlParameter("Phone", Phone);
            parameters[3] = new SqlParameter("Email", Email);
            parameters[4] = new SqlParameter("School", School);
            parameters[5] = new SqlParameter("Department", Department);
            parameters[6] = new SqlParameter("Cover", Cover.ToArray());

            DAL.Execute("PRAddStudent", parameters);
        }
        //  Loading Students to edit
        public DataTable LoadEdit(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("ID", ID);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRLoadEditStudents", parameters);
            return dataTable;
        }
        //  Editing Student
        public void Edit(int Id, string StudentName, string StudentLocation, string Phone, string Email, string School, string Department, MemoryStream Cover)
        {
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("Id", Id);
            parameters[1] = new SqlParameter("StudentName", StudentName);
            parameters[2] = new SqlParameter("StudentLocation", StudentLocation);
            parameters[3] = new SqlParameter("Phone", Phone);
            parameters[4] = new SqlParameter("Email", Email);
            parameters[5] = new SqlParameter("School", School);
            parameters[6] = new SqlParameter("Department", Department);
            parameters[7] = new SqlParameter("Cover", Cover.ToArray());

            DAL.Execute("PREditStudent", parameters);
        }
        //  Deleting Student
        public void Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", id);
            DAL.Execute("PRDeleteStudent", parameters);
        }
        //  Search Student
        public DataTable Search(string Search)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Search", Search);
            DataTable dataTable = new DataTable();
            dataTable = DAL.Read("PRSearchStudent", parameters);
            return dataTable;
        }
    }
}
