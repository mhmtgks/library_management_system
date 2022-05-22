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
        static string id = "0";
        public static string Login_Check(string ID)                                                 //                            returns type of user 
        {
            dbworks.id = ID;
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

        public static  void AddBook(string bookname, string writer)
        {
            string sql = "insert into Book(BookName,Writer,Status) values (@pBookName,@pWriter,@pStatus)";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = connection1;
            string status = "avaible";
            komut.Parameters.AddWithValue("@pBookName",bookname);                       // Add book to sql Database
            komut.Parameters.AddWithValue("@pWriter", writer);
            komut.Parameters.AddWithValue("@pStatus", status);

            connection1.Open();
            komut.ExecuteNonQuery();
            connection1.Close();
  
        }
        public static DataSet BookPull(string name)
        {
            string status = "avaible";
            
            string sql = "select BookName,Writer from Book where Status=@pstatus and BookName like @pname";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pstatus", status);
            komut.Parameters.AddWithValue("@pname", "%"+name+"%");
            komut.CommandText = sql;
            komut.Connection = connection1;

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet BookPULL = new DataSet();
            connection1.Open();
            adaptor.Fill(BookPULL);
            connection1.Close();
            return BookPULL;

        }
        public static DataSet MemberPull(string Id)
        {
            
            string sql = "select Id,Name from Login1 where Id like @pId";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pId", "%" + Id + "%");
            komut.CommandText = sql;
            komut.Connection = connection1;
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet memberpull = new DataSet();
            connection1.Open();
            adaptor.Fill(memberpull);
            connection1.Close();
            return memberpull;

        }
        public static DataSet InfoPull(string Id,string status)
        {
            string sql1 = "select Name,BookName,Writer from Info RIGHT JOIN Book on Info.bookID=Book.BookID ";
            SqlCommand komut = new SqlCommand();
            if (status == "1")
            { sql1 = sql1 + "where MemberID=@pId and Info.Status=@pstatus";
                komut.Parameters.AddWithValue("@pId", Id);
                komut.Parameters.AddWithValue("@pstatus", status);
           }else if (status == "2")
            {
                sql1 = sql1 + " where Info.Status=@pstatus";
                komut.Parameters.AddWithValue("@pstatus", status);
            }
               

            komut.CommandText = sql1;
            komut.Connection = connection1;
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet infopull = new DataSet();
            connection1.Open();
            adaptor.Fill(infopull);
            connection1.Close();
            return infopull;

        }


    }
}
