using System;
using System.Collections.Generic;

namespace Practice_Log_CLI
{
    public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }

    class Program
    {
        public static List<Musician> musiciansClassified = new List<Musician>()
        {
             new Musician("Rin", "Piano"),
             new Musician("Thera", "Violin"),
             new Musician("Que", "Saxophone")
        };

        public static List<Piece> AllSongs = new List<Piece>();

        static void Main(string[] args)
        {
            Console.WriteLine("----Welcome to the Practice Log----");
            //showMusicians(musiciansClassified);
            bool isLooping = true;

            do
            {
                Console.WriteLine("Are you a new user? Y/N");
                string userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "y" || userChoice.ToLower() == "yes")
                {
                    SignUp();
                }
                else if (userChoice.ToLower() == "n" || userChoice.ToLower() == "no")
                {
                    Console.WriteLine("Logging in");
                    Console.WriteLine("");
                    Console.Write("Please Login name: ");
                    string userLogin = Console.ReadLine();

                    var user = musiciansClassified.Find(m => m.Name == userLogin);
                    Console.WriteLine(user.Name);
                    MainMenu();
                    isLooping = false;
                }
            } while (isLooping);
            
            Console.ReadKey();
        }

        //Seed Musicians
        static void ShowMusicians(List<Musician> musiciansClassified)
        {
            for (int i = 0; i < musiciansClassified.Count; i++)
            {
                Console.WriteLine("{0} plays the {1}.", musiciansClassified[i].Name, musiciansClassified[i].Instrument);
            }
            Console.WriteLine("");
        }

        static void SignUp()
        {
            Console.WriteLine("Signing Up");
            Console.WriteLine("");

            Console.Write("Enter name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter instrument: ");
            string newInstrument = Console.ReadLine();
            Musician newUser = new Musician(newName, newInstrument);
            musiciansClassified.Add(newUser);

            Console.WriteLine("Welcome {0}, whom plays {1}.", newUser.Name, newUser.Instrument);
        }

        static void MainMenu()
        {
            bool isLooping = true;

            do
            {
                Console.WriteLine("----------------");
                Console.WriteLine("1. Show all Musicians");
                Console.WriteLine("2. View Pieces");
                Console.WriteLine("3. Add new piece to practice");
                Console.WriteLine("4. Edit Practice Days for a Piece");
                Console.WriteLine("5. Delete a Piece");
                Console.WriteLine("6. Exit");
                Console.Write("Choice: ");

                string userTyping = Console.ReadLine();
                int menuChoice = Convert.ToInt32(userTyping);

                switch (menuChoice)
                {
                    case 1:
                        ShowMusicians(musiciansClassified);
                        break;
                    case 2:
                        ViewPieces();   
                        break;
                    case 3:
                        AddPiece(); 
                        break;
                    case 4:
                        EditPracticeDays();
                        break;
                    case 5:
                        DeletePiece();
                        break;
                    case 6:
                        isLooping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.Clear();
                        break;
                }
            } while (isLooping);

            Console.WriteLine("Thank you for using the Practice Log.");
            Console.ReadKey();
            Environment.Exit(0);

        }

        static void DisplayPieces()
        {
            for (int i = 0; i < AllSongs.Count; i++)
            {
                Console.WriteLine("[{0}] {1} - {2}", i + 1, AllSongs[i].Artist, AllSongs[i].Title);
            }
        }

        static void ViewPieces()
        {
            if(AllSongs.Count == 0)
            {
                Console.WriteLine("No Songs saved right now.");
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("List of Songs to Practice");
                Console.WriteLine("-------------------------");
                foreach(Piece song in AllSongs)
                {
                    Console.WriteLine("{0} - {1}", song.Artist, song.Title);
                }
            }
        }

        static void AddPiece()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Adding new Piece");
            Console.WriteLine("----------------");
            Console.Write("Enter Artist Name: ");
            string newArtist = Console.ReadLine();
            Console.Write("Enter Title: ");
            string newTitle = Console.ReadLine();

            Piece newPiece = new Piece(newArtist, newTitle);

            AllSongs.Add(newPiece);
        }

        static void EditPracticeDays()
        {
            DisplayPieces();
            Console.Write("Input a number to Edit a piece: ");
            string editInput = Console.ReadLine();
            int editChoice = Convert.ToInt32(editInput);

            AddDays(editChoice);
        }

        static void AddDays(int editChoice)
        {
            Piece selectedPiece = AllSongs[editChoice - 1];

            //Days Enum
            foreach(Days day in Enum.GetValues(typeof(Days)))
            {
                int x = (int)day;
                Console.WriteLine("{0} = {1}", day, x + 1);
            }
            Console.WriteLine("Add a practice day to schedule by Number: ");
            string dayInput = Console.ReadLine();
            int selectedDay = Convert.ToInt32(dayInput);

        }

        static void DeletePiece()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Deleting a Piece");
            Console.WriteLine("----------------");

            DisplayPieces();

            Console.Write("Input a number to delete a piece: ");
            string deleteInput = Console.ReadLine();
            int delChoice = Convert.ToInt32(deleteInput);

            AllSongs.RemoveAt(delChoice-1);

        }
    }
}
