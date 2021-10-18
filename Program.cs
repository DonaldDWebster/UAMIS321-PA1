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
            System.Console.WriteLine("God Save the Emperor");
                                        // DeletePost.DropPostTable();
                                        // SavePost.CreatePostTable();

                                    // Post myPost= new Post() {PostText="Industrial Society and its Consequences" , PostID= 110010};
                                    // myPost.Save.createPost(myPost);

                                        // SaveData newSaveData = new SaveData();
                                        // newSaveData.SeedData();

                                        // IReadAllData readObject = new ReadData();
                                        // List<Post> allPosts = readObject.GetAllPosts();
                                        
                                        // foreach(Post post in allPosts)
                                        // {
                                        //     Console.WriteLine(post.ToString() );
                                        // }

                                        // allPosts[0].PostID= 69 ;
                                        // newSaveData.SaveDataMethod(allPosts[0]);

                                        // Console.WriteLine("After the update");
                                        // foreach(Post post in allPosts)
                                        // {
                                        //     Console.WriteLine(post.ToString() );
                // }

            bool continueProgram = true;

            //the while loop exists so that the user will be prompted continously by the menu until the user decided to exit
            while(continueProgram)
            {

                Console.Clear();
                Console.WriteLine("Hello! Please follow the instructions below:");
                Console.WriteLine("\t Type 'show' to show all stored posts");
                Console.WriteLine("\t Type 'add' to add a new post");
                Console.WriteLine("\t Type 'delete' to delete an old post");
                Console.WriteLine("\t Type 'edit' to edit an existing post");
                Console.WriteLine("\t Type 'reseed' to create a new database table");
                Console.WriteLine("\t Type 'exit' to exit this program");


                //detects the user input and executed a method based on the input
                string input = Console.ReadLine();
                if( input != "show" && input != "add" && input != "delete" && input != "edit" && input != "reseed" && input != "exit" )
                {
                    Console.WriteLine("error please try again");
                }
                else if( input =="show")
                {
                    PrintAllPosts();    
                }
                else if( input =="add")
                {
                    AddPost();
                }
                else if( input =="delete")
                {
                    DeletePost();
                }
                else if( input =="edit")
                {
                    EditPost();
                }
                else if( input =="reseed")
                {
                    reseed();
                }
                else if( input =="exit")
                {
                     continueProgram= false;
                 }

            }   
        }
            
          // displays all Posts stored in the database file
        static void PrintAllPosts()
        {
            System.Console.Clear();
            // Console.WriteLine( "Here our the current stored Posts of Big Al: \n \n");
            // foreach (Post tempPost in PostFile.ReadPosts() )
            // {
            //     System.Console.WriteLine(tempPost);
            // }

            // Console.WriteLine("\n press any key to contine");
            // Console.ReadKey();
            ReadData newData = new ReadData();
            List<Post> postList =  newData.GetAllPosts();

            foreach(Post post in postList)
            {
                System.Console.WriteLine(post.ToString());
            }

            System.Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }    

        // adds a post object to the databse
        static void AddPost()
        {
    
            
            //the userID does not matter for this method, an ID will be automatically given by the sql database
            //this negative one serves as a placeholder.
            int userInputID = -1;

            Console.WriteLine("Please input the post Text: \n");
            string userInputText= Console.ReadLine();

            //I detect the current time of the program witht his code
            Console.WriteLine("\n The Timestamp will be taken from the current moment;\n");
            DateTime now = DateTime.Now;
            DateTime TimeStamp = now;
           

            Post newPost = new Post{ PostID = userInputID, PostText= userInputText, TimeStamp = TimeStamp}  ;

            SavePost myPost = new SavePost();
            myPost.createPost(newPost);

            Console.WriteLine("\n Succesfully added your new post! \n press any key to contine");
            Console.ReadKey();

        }       



        static void DeletePost()
        {
            //I read the posts.txt file into an Arrry list, edit the array list, and then save the edited array list


            System.Console.WriteLine("Please type ID of the post you would like delete. To go back to menu, please type '0' ");
            
            int inputID = int.Parse( Console.ReadLine() );

            if(inputID == 0)
            {return;}

            else
            {
                
                DeletePostCopy myDeletePost = new DeletePostCopy();
                myDeletePost.DeletePostMethod(inputID);
             
                Console.Clear();
                Console.WriteLine("\n Succesfully terminated your desired post. \n press any key to contine");
                Console.ReadKey();
            }
        }

        //Based on a given post Id, I edit  post in the database
        static void EditPost()
        {
            SaveData mySaveData = new SaveData();

            System.Console.WriteLine("Please input the id of the post you would like to edit:");
            int PostID = int.Parse( Console.ReadLine() );

            Console.WriteLine("Please input the new Text: \n");
            string userInputText= Console.ReadLine();

            //I detect the current time of the program witht his code
            Console.WriteLine("\n Please input the new TimeStamp\n");
            System.Console.WriteLine("Please type your answer as mm/dd.yyyy");
            DateTime TimeStamp = DateTime.Parse( Console.ReadLine() );
      

            Post newPost = new Post{ PostID = PostID, PostText= userInputText, TimeStamp = TimeStamp}  ;

            SaveData myData = new SaveData();
            myData.SaveDataMethod(newPost);

            Console.WriteLine("\n Succesfully added your new post! \n press any key to contine");
            Console.ReadKey();
        }       


        //the post table is reset
        static void reseed()
        {
            SaveData mySaveData = new SaveData();

            mySaveData.SeedData();

            Console.WriteLine("\n Succesfully reseeded the post table! \n press any key to contine");
            Console.ReadKey();
        }   
      
    }
}
