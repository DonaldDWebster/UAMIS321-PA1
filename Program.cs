using System;
using System.Collections.Generic;
using System.IO;

namespace PAOne
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while(continueProgram)
            {

                Console.Clear();
                Console.WriteLine("Hello! Please follow the instructions below:");
                Console.WriteLine("\t Type 'show' to show all stored posts");
                Console.WriteLine("\t Type 'add' to add a new post");
                Console.WriteLine("\t Type 'delete' to delete an old post");
                Console.WriteLine("\t Type 'exit' to exit this program");

                string input = Console.ReadLine();
                if( input != "show" && input != "add" && input != "delete" && input != "exit")
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
                else if( input =="exit")
                {
                    continueProgram= false;
                }

            }   
        }
            

        static void PrintAllPosts()
        {
            Console.WriteLine( "Here our the current stored Posts of Big Al: \n \n");
            foreach (Post tempPost in PostFile.ReadPosts() )
            {
                System.Console.WriteLine(tempPost);
            }

            Console.WriteLine("\n press any key to contine");
            Console.ReadKey();
        }    

        static void AddPost()
        {
            //I will need to create a writePosts file
            List<Post> tempPosts = PostFile.ReadPosts();

            

            Console.WriteLine("Please input the post ID: \n");
            int userInputID= int.Parse( Console.ReadLine() );
            Console.WriteLine("Please input the post Text: \n");
            string userInputText= Console.ReadLine();

            Console.WriteLine("\n The Timestamp will be taken from the current moment;\n");
            DateTime now = DateTime.Now;
            long unixTime = ((DateTimeOffset)now).ToUnixTimeSeconds();
            long userInputTimeStamp = unixTime;

            tempPosts.Add( new Post{ PostID = userInputID, PostText= userInputText, TimeStamp = userInputTimeStamp} ) ;

            tempPosts.Sort(Post.CompareByTimeStamp);
    

            PostFile.WritePosts( tempPosts);
            Console.WriteLine("\n Succesfully added your new post! \n press any key to contine");
            Console.ReadKey();

        }       


        static void DeletePost()
        {
            Console.Clear();
            Console.WriteLine("Here our the current Posts:");

            //DA
             foreach (Post tempPost in PostFile.ReadPosts() )
            {
                System.Console.WriteLine(tempPost);
            }
            
            System.Console.WriteLine("Please type ID of the post you would like delete. To go back to menu, please type '0' ");
            
            int inputID = int.Parse( Console.ReadLine() );

            if(inputID == 0)
            {return;}


            else
            {
                List<Post> tempPosts = PostFile.ReadPosts();

                //I cannot use a foreach loop since deleting an object in the list breaks the for each loop
                for (int i =0; i< tempPosts.Count; i++)
                {
                    if(tempPosts[i].PostID == inputID)
                    {
                       tempPosts.Remove(tempPosts[i]);     
                    }
                }

                //Saves the new array back to the file
                PostFile.WritePosts(tempPosts);

                foreach (Post tempPost in tempPosts )
                {
                    System.Console.WriteLine(tempPost);
                }

                PostFile.WritePosts( tempPosts);
                Console.Clear();
                Console.WriteLine("\n Succesfully terminated your desired post. \n press any key to contine");
                Console.ReadKey();
            }
        }
    }
}
