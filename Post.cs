namespace PAOne
{
    public class Post
    {
        public int PostID {get; set;}

        public string PostText{get; set;}

        public long TimeStamp{get; set;}

        public override string ToString()
        {
            return ( PostText + "\n \t Time:" + TimeStamp.ToString() + " \t ID:" + PostID.ToString() );
        }

        //this method is used in program.cs to sort the Array List of Posts by their TimeStamp into descedning order
        public static int CompareByTimeStamp(Post x, Post y)
        {
            return  x.TimeStamp.CompareTo(y.TimeStamp) * -1  ;
        }
       
    }
}