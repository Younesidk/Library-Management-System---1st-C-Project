namespace Library_Management_System___1st_C__Project
{
    class Program
    {
        static void Main()
        {
            LibraryManager Library = new LibraryManager();
            LibraryMembers Members = new LibraryMembers();
            while (true)
            {
                Menu();
                int Choice = 0;
                while (!int.TryParse(Console.ReadLine(), out Choice) || Choice < 0 || Choice > 8)
                {
                    Console.WriteLine("please respect the input");
                }

                Console.Clear();

                switch (Choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the Name and Type of the Member");
                            string Name = Console.ReadLine();
                            string Type = Console.ReadLine();

                            Members.AddMember(Name, Type);
                            break;
                        }
                    case 2:
                        {
                            if(!Members.IsThereMembers())
                            {
                                Console.WriteLine("There is no Members");
                                break;
                            }

                            Console.WriteLine("Enter the Name of the Member you want to remove");
                            string Name = Console.ReadLine();

                            Members.RemoveMember(Name);
                            break;
                        }
                    case 3:
                        {
                            Members.ListAllMembers();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the Properties of the Book you want to add : Title , Author , Page count");
                            string Title = Console.ReadLine();
                            string Author = Console.ReadLine();
                            int Pages = 0;
                            while(!int.TryParse(Console.ReadLine(),out Pages))
                                Console.WriteLine("Please Enter a number");

                            Library.AddBook(Title, Author, Pages);
                            break;
                        }
                    case 5:
                        {
                            if(Library.IsLibraryEmpty())
                            {
                                Console.WriteLine("Library is Empty");
                                break;
                            }

                            Console.WriteLine("Enter the title of the book you want to Delete");
                            string BookToRemoveTitle = Console.ReadLine();

                            Library.RemoveBook(BookToRemoveTitle);
                            break;
                        }
                    case 6:
                        {
                            Library.ListBooks();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("What Member want to Borrow the Book ?");
                            string MemberName = Console.ReadLine();
                            if (!Members.IsMemberAvailable(MemberName))
                            {
                                Console.WriteLine("Member not found");
                                break;
                            }


                            Console.WriteLine("Enter the Title and Author of the book :");
                            string Title = Console.ReadLine();
                            string Author = Console.ReadLine();
                            Members.BorrowBook(Library, MemberName, Title, Author);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("What Member to Return the Book ?");
                            string MemberName = Console.ReadLine();
                            if (!Members.IsMemberAvailable(MemberName))
                            {
                                Console.WriteLine("Member not found");
                                break;
                            }

                            Console.WriteLine("Enter the Title and Author of the book :");
                            string Title = Console.ReadLine();
                            string Author = Console.ReadLine();
                            Members.ReturnBook(Library, MemberName, Title, Author);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("See you Soon !");
                            return;
                        }
                }

                Console.WriteLine();

            }

        }

        static void Menu()
        {
            Console.WriteLine("1.Add Member\n" +
                "2.Remove Member\n" +
                "3.List Members\n" +
                "4.Add Book\n" +
                "5.Remove Book\n" +
                "6.List Books\n" +
                "7.Borrow Book\n" +
                "8.Return Book\n" +
                "0.Exit");
        }
    }
}