using System;
using System.Collections.Generic;
using UAMIS321_PA3.database;
using System.IO;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using UAMIS321_PA3.Models;

using UAMIS321_PA3.Interfaces;

namespace UAMIS321_PA3
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            // DeletePost.DropPostTable();
            // SavePost.CreatePostTable();

            Post myPost= new Post() {PostText="Industrial Society and its Consequences" , PostID= 110010};
            myPost.Save.createPost(myPost);


            // bool continueProgram = true;

            // //the while loop exists so that the user will be prompted continously by the menu until the user decided to exit
            // while(continueProgram)
            // {

            //     Console.Clear();
            //     Console.WriteLine("Hello! Please follow the instructions below:");
            //     Console.WriteLine("\t Type 'show' to show all stored posts");
            //     Console.WriteLine("\t Type 'add' to add a new post");
            //     Console.WriteLine("\t Type 'delete' to delete an old post");
            //     Console.WriteLine("\t Type 'exit' to exit this program");


            //     //detects the user input and executed a method based on the input
            //     string input = Console.ReadLine();
            //     if( input != "show" && input != "add" && input != "delete" && input != "exit")
            //     {
            //         Console.WriteLine("error please try again");
            //     }
            //     else if( input ="show")
            //     {
            //         PrintAllPosts();    
            //     }
            //     else if( input =="add")
            //     {
            //         AddPost();
            //     }
            //     else if( input =="delete")
            //     {
            //         DeletePost();
            //     }
            //     else if( input =="exit")
            //     {
             //         continueProgram= false;
             //     }

            // }   
        // }
            
        //displays all Posts stored in the posts.txt file
        // static void PrintAllPosts()
        // {
        //     Console.WriteLine( "Here our the current stored Posts of Big Al: \n \n");
        //     foreach (Post tempPost in PostFile.ReadPosts() )
        //     {
        //         System.Console.WriteLine(tempPost);
        //     }

        //     Console.WriteLine("\n press any key to contine");
        //     Console.ReadKey();
        // }    

        // //adds a post object to the .txt file
        // static void AddPost()
        // {
        //     //I read the posts.txt file into an Arrry list, edit the array list, and then save the edited array list
        //     List<Post> tempPosts = PostFile.ReadPosts();

            

        //     Console.WriteLine("Please input the post ID: \n");
        //     int userInputID= int.Parse( Console.ReadLine() );
        //     Console.WriteLine("Please input the post Text: \n");
        //     string userInputText= Console.ReadLine();

        //     //I detect the current time of the program witht his code
        //     Console.WriteLine("\n The Timestamp will be taken from the current moment;\n");
        //     DateTime now = DateTime.Now;
        //     long unixTime = ((DateTimeOffset)now).ToUnixTimeSeconds();
        //     long userInputTimeStamp = unixTime;

        //     tempPosts.Add( new Post{ PostID = userInputID, PostText= userInputText, TimeStamp = userInputTimeStamp} ) ;

        //     tempPosts.Sort(Post.CompareByTimeStamp);
    

        //     PostFile.WritePosts( tempPosts);
        //     Console.WriteLine("\n Succesfully added your new post! \n press any key to contine");
        //     Console.ReadKey();

        // }       



        // static void DeletePost()
        // {
        //     //I read the posts.txt file into an Arrry list, edit the array list, and then save the edited array list

        //     Console.Clear();
        //     Console.WriteLine("Here our the current Posts:");

        //     //DA
        //      foreach (Post tempPost in PostFile.ReadPosts() )
        //     {
        //         System.Console.WriteLine(tempPost);
        //     }
            
        //     System.Console.WriteLine("Please type ID of the post you would like delete. To go back to menu, please type '0' ");
            
        //     int inputID = int.Parse( Console.ReadLine() );

        //     if(inputID == 0)
        //     {return;}


        //     else
        //     {
        //         List<Post> tempPosts = PostFile.ReadPosts();

        //         //I cannot use a foreach loop since deleting an object in the list breaks the for each loop
        //         for (int i =0; i< tempPosts.Count; i++)
        //         {
        //             if(tempPosts[i].PostID == inputID)
        //             {
        //                tempPosts.Remove(tempPosts[i]);     
        //             }
        //         }

        //         //Saves the new array back to the file
        //         PostFile.WritePosts(tempPosts);

        //         foreach (Post tempPost in tempPosts )
        //         {
        //             System.Console.WriteLine(tempPost);
        //         }

        //         PostFile.WritePosts( tempPosts);
        //         Console.Clear();
        //         Console.WriteLine("\n Succesfully terminated your desired post. \n press any key to contine");
        //         Console.ReadKey();
        //     }
        }
    }
}
