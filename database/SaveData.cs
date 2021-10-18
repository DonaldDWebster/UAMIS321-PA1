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

            string stm =@"UPDATE books set title = @title, author = @author, WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",value.PostID);
            cmd.Parameters.AddWithValue("@id",value.PostText);
           // cmd.Parameters.AddWithValue("@id",value.TimeStamp);
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
            string stm ="DROP TABLE IF EXISTS books";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            //CONVERT THIS TO POSTS. Do i need to swithc cmd.CommandText to stm or something
            cmd.CommandText = @"CREATE TABLE books(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, author TEXT)";
            cmd.ExecuteNonQuery(); 

            cmd.CommandText = @"INSERT INTO books(title,author) VALUES(@title,@author)";
            cmd.Parameters.AddWithValue("@Title", "MistBorn");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //THE PART BELOW IS BROKE, TRY TO FIX LATER
            cmd.Parameters.Clear();
            cmd.CommandText = @"INSERT INTO books(title,author) VALUES(@title,@author)";
            cmd.Parameters.AddWithValue("@Title", "Flatland");
            cmd.Parameters.AddWithValue("@author", "Edwin Abbott");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

             cmd.Parameters.Clear();
            cmd.CommandText = @"INSERT INTO books(title,author) VALUES(@title,@author)";
            cmd.Parameters.AddWithValue("@Title", "Imperial Sunrise");
            cmd.Parameters.AddWithValue("@author", "Hirohito Minimito");
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