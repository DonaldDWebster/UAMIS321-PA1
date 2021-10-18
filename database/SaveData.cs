using UAMIS321_PA3.Interfaces;
using UAMIS321_PA3;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using UAMIS321_PA3.Models;

namespace UAMIS321_PA3.database
{
    public class SaveData : ISeedData , ISaveData
    {
        public void SaveDataMethod(Post value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            //I am using an SQLiteConnection instead of the normal
            // using var con = new MySqlConnection(cs);
            //not sure if this different will break my code
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm =@"UPDATE posts set TimeStamp = @TimeStamp, PostText = @PostText WHERE PostId = @PostId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@PostID",value.PostID);
            cmd.Parameters.AddWithValue("@TimeStamp",value.TimeStamp);
            cmd.Parameters.AddWithValue("@PostText",value.PostText);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void SeedData()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            //I am using an SQLiteConnection instead of the normal
            // using var con = new MySqlConnection(cs);
            //not sure if this different will break my code
            using var con = new MySqlConnection(cs);
            con.Open();

            //convert this to posts
            string stm ="DROP TABLE IF EXISTS posts";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            //CONVERT THIS TO POSTS. Do i need to swithc cmd.CommandText to stm or something
            cmd.CommandText = @"CREATE TABLE posts(PostId INTEGER PRIMARY KEY AUTO_INCREMENT, PostText TEXT, TimeStamp TEXT)";
            cmd.ExecuteNonQuery(); 

            cmd.CommandText = @"INSERT INTO posts(PostText,TimeStamp) VALUES(@PostText,@TimeStamp)";
            cmd.Parameters.AddWithValue("@PostText", "I am currently in Musth, please stay away");
            cmd.Parameters.AddWithValue("@TimeStamp", "10-16-2000");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

         
            cmd.Parameters.Clear();
            cmd.CommandText = @"INSERT INTO posts(PostText,TimeStamp) VALUES(@PostText,@TimeStamp)";
            cmd.Parameters.AddWithValue("@PostText", "RAWRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR");
            cmd.Parameters.AddWithValue("@TimeStamp", "10-31-2000");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.CommandText = @"INSERT INTO posts(PostText,TimeStamp) VALUES(@PostText,@TimeStamp)";
            cmd.Parameters.AddWithValue("@PostText", "Hey Kids! Come to the game tomorrow");
            cmd.Parameters.AddWithValue("@TimeStamp", "11-15-2000");
            cmd.Prepare();
            cmd.ExecuteNonQuery();


            // ConnectionString myConnection = new ConnectionString();
            //     string cs = myConnection.cs;
            //     using var con = new MySqlConnection(cs);
            //     con.Open();

            //     string stm = @"CREATE TABLE books(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, author TEXT)";

            //     using var cmd = new MySqlCommand(stm, con);

            //     cmd.ExecuteNonQuery();
        }
    } 
}