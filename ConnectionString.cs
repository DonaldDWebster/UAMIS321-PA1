namespace UAMIS321_PA3
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString()
        {
            string server= "bmlx3df4ma7r1yh4.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database= "sxwj3am1kzwporko";
            string port = "3306";
            string userName="zxrkmryidt7sgwjp";
            string password = "usbygfzar1jag78e";

             cs = $@"server={server};user={userName};database={database};port={port};password={password};";
        }


       

    }
}