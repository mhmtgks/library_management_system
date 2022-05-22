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
        public static string idmembers = "0",namemembers="";
        public static string Login_Check(string ID)                                                 //                            returns type of user 
        {
            dbworks.idmembers = ID;
            string type="0";
            string sql = "select Type,Name from Login1 where ID=@pID";
            SqlCommand komut = new SqlCommand(sql, connection1);
            komut.Parameters.AddWithValue("@pID", ID);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            connection1.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while(rdr.Read())
            {
                type = rdr.GetString(0);
                namemembers = rdr.GetString(1);
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
            
            string sql = "select BookID,BookName,Writer from Book where Status=@pstatus and BookName like @pname";
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
            string sql1 = "select Name,BookName,Writer,MemberID,Info.BookID from Info RIGHT JOIN Book on Info.BookID=Book.BookID ";
            SqlCommand komut = new SqlCommand();
            if (status == "1")
            { sql1 = sql1 + "where MemberID=@pId and Info.Status=@pstatus";
                komut.Parameters.AddWithValue("@pId", Id);
                komut.Parameters.AddWithValue("@pstatus", status);
           }else if (status == "2")
            {
                sql1 = "select Name,BookName,Writer,MemberID,Info.BookID from Info RIGHT JOIN Book on Info.bookID=Book.BookID where Info.Status=@pstatus";
                komut.Parameters.AddWithValue("@pstatus", status);
            }else if (status == "*")
            {
                sql1 = "select Name,BookName,Writer,Info.Status from Info RIGHT JOIN Book on Info.bookID=Book.BookID where Info.MemberID=@pId";
                komut.Parameters.AddWithValue("@pId", Id);
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
        public static bool confirmRequest(string status, string ıd, string bookid)
        {
            bool x = true;
            if (status == "1")
            {
                string status2 = "";
                string sql = "select Status from Book where BookID=@pbid";
                SqlCommand komut = new SqlCommand();
                komut.Parameters.AddWithValue("@ps", status);
                komut.Parameters.AddWithValue("@pId", ıd);
                komut.Parameters.AddWithValue("@pbid", bookid);
                komut.CommandText = sql;
                komut.Connection = connection1;

                connection1.Open();
                SqlDataReader rdr = komut.ExecuteReader();
                while (rdr.Read())
                {
                    status2 = rdr.GetString(0);
                }
                connection1.Close();
            
            
            if (status2 == "avaible")
            {
                string sql2 = "update Info set Status=@ps where MemberID=@pId and BookID=@pbid";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@ps", status);
                komut2.Parameters.AddWithValue("@pId", ıd);
                komut2.Parameters.AddWithValue("@pbid", bookid);
                komut2.CommandText = sql2;
                komut2.Connection = connection1;
                connection1.Open();
                komut2.ExecuteNonQuery();
                connection1.Close();
                    x = true;

                string sql3 = "update  Book set Status='not avaible' where BookID=@pid ";
                SqlCommand komut3 = new SqlCommand();
                komut3.CommandText = sql3;
                komut3.Connection = connection1;
                komut3.Parameters.AddWithValue("@pid", bookid);

                connection1.Open();
                komut3.ExecuteNonQuery();
                connection1.Close();
                }
            else
                {
                    x = false;
                }


            }
            else {
                status = "0";
                string sql3 = "update Info set Status=@ps where MemberID=@pId and BookID=@pbid";
                SqlCommand komut3 = new SqlCommand();
                komut3.Parameters.AddWithValue("@ps", status);
                komut3.Parameters.AddWithValue("@pId", ıd);
                komut3.Parameters.AddWithValue("@pbid", bookid);
                komut3.CommandText = sql3;
                komut3.Connection = connection1;
                connection1.Open();
                komut3.ExecuteNonQuery();
                connection1.Close();
                x = true;
            }
            return x;
        }
        public static bool AddInfo(string book, string ID,string name,string status)
        {
            bool x = true;
            string sql = "";
            string status2 = "";
            string sql3 = "select Status from Book where BookID=@pbid";
            SqlCommand komut3 = new SqlCommand();
            komut3.Parameters.AddWithValue("@ps", status);
            komut3.Parameters.AddWithValue("@pId", ID);
            komut3.Parameters.AddWithValue("@pbid", book);
            komut3.CommandText = sql3;
            komut3.Connection = connection1;

            connection1.Open();
            SqlDataReader rdr = komut3.ExecuteReader();
            while (rdr.Read())
            {
                status2 = rdr.GetString(0);
            }
            connection1.Close();


            if (status == "3")
            {
                string sql2 = "update  Book set Status='avaible' where BookID=@pid ";
                SqlCommand komut2 = new SqlCommand();
                komut2.CommandText = sql2;
                komut2.Connection = connection1;
                komut2.Parameters.AddWithValue("@pid", book);

                connection1.Open();
                komut2.ExecuteNonQuery();
                connection1.Close();

                sql = "update Info set Status=@pStatus where MemberID=@pID and BookID=@pBookID";
                x = true;
            }
            else if (status == "1" && status2 == "avaible")
            {


                string sql2 = "update  Book set Status='not avaible' where BookID=@pid";
                SqlCommand komut2 = new SqlCommand();
                komut2.CommandText = sql2;
                komut2.Connection = connection1;
                komut2.Parameters.AddWithValue("@pid", book);

                connection1.Open();
                komut2.ExecuteNonQuery();
                connection1.Close();
                sql = "insert into Info(MemberID,BookID,Status,Name) values (@pID,@pBookID,@pStatus,@pName)";
                x = true;
            }
            else if (status == "2") { 
                sql = "insert into Info(MemberID,BookID,Status,Name) values (@pID,@pBookID,@pStatus,@pName)";
                x= true;
            }
            else{ x = false;
                sql = "delete from Info where  MemberID=@pID and BookID=@pBookID";
            }

            
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = connection1;

            komut.Parameters.AddWithValue("@pID", ID);                       // Add info to sql Database
            komut.Parameters.AddWithValue("@pBookID", book);                    //0=rejected,1=taken,2=request,3=taken and given
            komut.Parameters.AddWithValue("@pStatus", status);
            komut.Parameters.AddWithValue("@pName", name);

            connection1.Open();
            komut.ExecuteNonQuery();
            connection1.Close();
            return x;

        }


    }
}
