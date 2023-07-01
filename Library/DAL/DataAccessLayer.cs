using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Library.DAL
{
    class DataAccessLayer
    {
        SqlConnection conn = new SqlConnection();
        public DataAccessLayer()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBLibrary.mdf;Integrated Security=True");
        }

        //  Method to open sql connection:
        public void Open()
        {
            if(conn.State == ConnectionState.Closed) conn.Open(); 
        }

        //  Method to close sql connection:
        public void Close()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

        //  Method to read data:
        public DataTable Read(String storeProcedure, SqlParameter[] parameters)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storeProcedure; 
            if(parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        //  Method to execute insert, edit, and delete
        public void Execute(String storeProcedure, SqlParameter[] parameters)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storeProcedure;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
