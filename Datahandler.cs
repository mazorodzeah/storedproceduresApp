using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace storedproceduresApp
{
    class Datahandler
    {
        string connectionString = @"Data Source=DESKTOP-B4I5OVG\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";
        public DataTable students = new DataTable();
        SqlConnection conn;
        public void displayStudents()
        {

            using (conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetStudents",conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(students);
            }
        }

        public void insertData(int id, string name, string surname,string course)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spAddStudent", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@course", course);
                     
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
