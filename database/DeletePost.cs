// using UAMIS321_PA3.Interfaces;
// using UAMIS321_PA3;


using MySql.Data.MySqlClient;
using UAMIS321_PA3.Interfaces;
using UAMIS321_PA3;

namespace UAMIS321_PA3.database
{
    public class DeletePost : IDeletePost
    {
        //public DeletePost()
        // {
        // }
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
     
         void IDeletePost.DeletePostMethod(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}