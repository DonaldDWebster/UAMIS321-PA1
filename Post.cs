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

        public static int CompareByTimeStamp(Post x, Post y)
        {
            return  x.TimeStamp.CompareTo(y.TimeStamp) * -1  ;
        }
       
    }
}