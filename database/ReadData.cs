using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UAMIS321_PA3.Interfaces;
using UAMIS321_PA3.Models;

namespace UAMIS321_PA3.database
{
    public class ReadData : IReadAllData
    {
        public List<Post> GetAllPosts()
        {
            List<Post> allPosts = new List<Post>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM books";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            //I need to fix this below while loop to work on posts instead of books
            while(rdr.Read() )
            {
                                                                                        //rdr.GetString(2) FIX THIS LATER
                allPosts.Add(new Post(){PostID=rdr.GetInt32(0), PostText=rdr.GetString(1), TimeStamp = 2 });
            }

            return allPosts;
        }
    }
}