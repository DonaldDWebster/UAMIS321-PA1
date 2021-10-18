using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UAMIS321_PA3.Interfaces;
using UAMIS321_PA3.Models;
using System;

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

            string stm = "SELECT * FROM posts";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            //I need to fix this below while loop to work on posts instead of books
            while(rdr.Read() )
            {  
                //debugging code
                // System.Console.WriteLine("the string(0) value is: " + rdr.GetString(0));
                // System.Console.WriteLine("the PostTExt value is: " + rdr.GetString(1));
                // System.Console.WriteLine("the TimeStamp) value is: " + rdr.GetString(2));
                                                                                              //rdr.GetString(2) FIX THIS LATER
                allPosts.Add(new Post(){PostID= int.Parse( rdr.GetString(0) ), PostText=rdr.GetString(1), TimeStamp = DateTime.Parse( rdr.GetString(2) ) });
            }

            return allPosts;

        
        }
    }
}