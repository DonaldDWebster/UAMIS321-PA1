// using UAMIS321_PA3.Interfaces;
// using UAMIS321_PA3;


using MySql.Data.MySqlClient;
using UAMIS321_PA3.Interfaces;
//using UAMIS321_PA3;

namespace UAMIS321_PA3.database
{
    public class DeletePostCopy : IDeletePost
    {
        // public DeletePost()
        //  {
        //  }
        public static void DropPostTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS posts";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
     
        public void DeletePostMethod(int PostID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            //I am using an SQLiteConnection instead of the normal
            // using var con = new MySqlConnection(cs);
            //not sure if this different will break my code
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm =@"DELETE FROM posts WHERE PostId = @PostId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@PostID", PostID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        //   public void terminatePost(int PostID)
        // {
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;
        //     //I am using an SQLiteConnection instead of the normal
        //     // using var con = new MySqlConnection(cs);
        //     //not sure if this different will break my code
        //     using var con = new MySqlConnection(cs);
        //     con.Open();

        //     string stm =@"DELETE posts WHERE PostId = @PostId";

        //     using var cmd = new MySqlCommand(stm, con);
        //     cmd.Parameters.AddWithValue("@PostID",PostID);
        //     cmd.Prepare();
        //     cmd.ExecuteNonQuery();
        // }
    }
}