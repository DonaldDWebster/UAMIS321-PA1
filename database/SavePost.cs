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

                string stm = @"CREATE TABLE Post(PostId INTEGER PRIMARY KEY AUTO_INCREMENT, PostText TEXT, TimeStamp TEXT)";

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

            string stm = @"INSERT INTO posts(PostText, TimeStamp) VALUES(@PostText, @TimeStamp)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@PostText", myPost.PostText);
            cmd.Parameters.AddWithValue("@TimeStamp", myPost.TimeStamp);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }



    }
}