using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class DataModel
    {
        System.Data.SqlClient.SqlConnectionStringBuilder builder;
        SqlConnection conn;
        public DataModel()
        {
            builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "LAPTOP-6AR4KNHR\\SQLEXPRESS";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "N4";
            builder.UserID = "LAPTOP-6AR4KNHR\\PHAM NHAT QUYNH";

            builder["Password"] = "Nhatquynh1207pham";
            conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
        }

        public List<Dictionary<string, string>> FetchAllRow(){
             List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
     Dictionary<string, string> column; 
     string sqlQuery = "SELECT FullName, ID, Town, DoB FROM Student";

    SqlCommand command = new SqlCommand(sqlQuery, this.conn);
            

    try
    {
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {    //Every new row will create a new dictionary that holds the columns
             column = new Dictionary<string, string>();

             column["FullName"] = reader["FullName"].ToString();
             column["ID"] = reader["ID"].ToString();
             column["Town"] = reader["Town"].ToString();
             column["DoB"] = reader["DoB"].ToString();

             rows.Add(column); //Place the dictionary into the list
        }
        reader.Close();
    }
    catch (Exception ex)
    { 
         //If an exception occurs, write it to the console
         Console.WriteLine(ex.ToString());
    }

    return rows;


   }


        public bool AddNewRow(string id, string name, string town, string dob)
        {
            string addCmd = "INSERT INTO Student (ID, FullName, Town, DoB) values (@val1, @val2, @val3, @val4)";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = addCmd;
                comm.Parameters.AddWithValue("@val1", id);
                comm.Parameters.AddWithValue("@val2", name);
                comm.Parameters.AddWithValue("@val3", town);
                comm.Parameters.AddWithValue("@val4", dob);
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch(SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        public bool RemoveRow(string id)
        {
            string addCmd = "DELETE FROM Student where id = @val1";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = addCmd;
                comm.Parameters.AddWithValue("@val1", id);
             
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

    }
}
