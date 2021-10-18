using UAMIS321_PA3.Interfaces;
using UAMIS321_PA3.Models;
using MySql.Data.MySqlClient;

namespace UAMIS321_PA3.database
{

   
    public class SavePost :ISavePost
    {
         public static void CreatePostTable()
        {
                ConnectionString myConnection = new ConnectionString();
                string cs = myConnection.cs;
                using var con = new MySqlConnection(cs);
                con.Open();

                string stm = @"CREATE TABLE books(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, author TEXT)";

                using var cmd = new MySqlCommand(stm, con);

                cmd.ExecuteNonQuery();
        }

        void ISavePost.savePost(Post myPost)
        {
            throw new System.NotImplementedException();
        }

        public void createPost(Post myPost)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO books(title, author) VALUES(@title, @author)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", myPost.PostID);
            cmd.Parameters.AddWithValue("@author", myPost.PostText);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }



    }
}