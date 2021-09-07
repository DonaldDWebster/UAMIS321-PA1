using System;
using System.Collections.Generic;
using System.IO;

namespace PAOne
{
    public class PostFile
    {
        //I need to load the .txt file to an array list

        public static List<Post> ReadPosts()
        {
               List<Post> allPosts = new List <Post>();

               StreamReader infile = null;
                
                try
                {
                    infile = new StreamReader("Posts.txt");
                }
                catch (FileNotFoundException e)
                {
                    System.Console.WriteLine("Error encounted.", e);
                    return;
                }

                //What do they mean? Program should work if nothing is return???? ANSWER THIS LATER 

                string line = infile.ReadLine(); //priming read
                
                while( line != null )
                {
                    string[] temp = line.Split("#");
                    int tempPostID = int.Parse(temp[0]);
                    long tempTimeStamp = long.Parse(temp[2]);
                    allPosts.Add( new Post() {PostID= tempPostID, PostText = temp[1], TimeStamp= tempTimeStamp} ) ;
                   
                    //update read below
                    line = infile.ReadLine();
                }

                infile.Close();

                return allPosts;
        }    

        public static void WritePosts(List <Post> tempPosts )
        {
                StreamWriter inFile= new StreamWriter("Posts.txt");

                foreach (Post post in tempPosts)
                {
                    
                    inFile.Write( post.PostID + "#" + post.PostText + "#" + post.TimeStamp + "\n" );    

                }

                inFile.Close();
        }

        
    }


}