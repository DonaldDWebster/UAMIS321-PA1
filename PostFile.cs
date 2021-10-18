using System;
using System.Collections.Generic;
using System.IO;
using UAMIS321_PA3.Models;

namespace UAMIS321_PA3
{
    public class PostFile
    {

        // // read the .txt file into a List of Posts
        // public static List<Post> ReadPosts()
        // {
        //        List<Post> allPosts = new List <Post>();

        //        StreamReader infile = null;
                
        //         try
        //         {
        //             infile = new StreamReader("Posts.txt");
        //         }
        //         catch (FileNotFoundException e)
        //         {
        //             System.Console.WriteLine("\n Error encounted.", e);
                    
        //         }

                

        //         string line = infile.ReadLine(); //priming read
                
        //         while( line != null )
        //         {
        //             string[] temp = line.Split("#");
        //             int tempPostID = int.Parse(temp[0]);
        //             long tempTimeStamp = long.Parse(temp[2]);
        //             allPosts.Add( new Post() {PostID= tempPostID, PostText = temp[1], TimeStamp= tempTimeStamp} ) ;
                   
        //             //update read below
        //             line = infile.ReadLine();
        //         }

        //         infile.Close();

        //         return allPosts;
        // }    

        // //writes an array list of posts into the posts.txt file
        // public static void WritePosts(List <Post> tempPosts )
        // {
        //         StreamWriter inFile= new StreamWriter("Posts.txt");

        //         foreach (Post post in tempPosts)
        //         {
                    
        //             inFile.Write( post.PostID + "#" + post.PostText + "#" + post.TimeStamp + "\n" );    

        //         }

        //         inFile.Close();
        // }

        
    }


}