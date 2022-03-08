using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace library
{
    class dbworks
    {
        static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mgoek\Documents\Library_System.mdf;Integrated Security=True;Connect Timeout=30";
        static SqlConnection connection1 = new SqlConnection(ConnectionString);

        public static string Login_Check(string ID)                                                 //                            returns type of user 
        {
            string type="0";
            string sql = "select Type from Login1 where ID=@pID";
            SqlCommand komut = new SqlCommand(sql, connection1);
            komut.Parameters.AddWithValue("@pID", ID);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            connection1.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while(rdr.Read())
            {
                type = rdr.GetString(0);
            }
            connection1.Close();
            return type;

        }



    }
}
