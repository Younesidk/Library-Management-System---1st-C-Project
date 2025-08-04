using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Library_Management_System___1st_C__Project
{
    public class LibraryMembers
    {
        private List<Member> LibMembers = new List<Member>();
        private const string path = "members.json";

        public void SaveMembersToJsonFile()
        {
            string jsonString = JsonSerializer.Serialize(LibMembers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);

            Console.WriteLine("Save is Done !");
        }

        public void LoadMembersFromJSONFile()
        {
            if (File.Exists(path))
            {
                string jsonFromFile = File.ReadAllText(path);

                if (!string.IsNullOrWhiteSpace(jsonFromFile))
                {
                    try
                    {
                        var loaded = JsonSerializer.Deserialize<List<Member>>(jsonFromFile);
                        if (loaded != null)
                        {
                            LibMembers = loaded;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to load Members. Json might be invalid.");
                        Console.WriteLine("Error : " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }


        public void AddMember(string Name,string Type,int id)
        {
            try
            {
                LibMembers.Add(new Member(Name, Type,id));
            }
            catch (ArgumentNullException Ar)
            {
                Console.WriteLine("The member must have a name or a type (Student,Teacher,etc");
            }
        }

        public void RemoveMember(string Name)
        {
            Member? MemberToRemove = LibMembers.Find(m => m.Name == Name);
            if (MemberToRemove == null)
            {
                Console.WriteLine("Member doesn't Exist");
                return;
            }

            LibMembers.RemoveAll(n => n.Name == Name);

        }

        public void ListAllMembers()
        {
            if (LibMembers.Count == 0)
            {
                Console.WriteLine("There are no Library members yet");
                return;
            }

            foreach (var member in LibMembers)
            {
                Console.WriteLine(member);
            }
        }

        public void BorrowBook(LibraryManager Library,string MemberName,string Title,string Author)
        {
            Book? BorrowedBook = Library.GetBook(Title, Author);
            if(BorrowedBook == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            if (BorrowedBook.IsBorrowed)
            {
                Console.WriteLine("Book is already Borrowed");
                return;
            }

            if (!Library.IsBookAvailable(Title, Author))//TODO: to verify (duplicated)
            {
                Console.WriteLine("Book is not available");
                return;
            }

            Member? MemberBookBorrow = LibMembers.Find(m => m.Name == MemberName);
            if (MemberBookBorrow == null)
            {
                Console.WriteLine("Error Encountered");
                return;
            }            

            MemberBookBorrow.BorrowedBooks.Add(BorrowedBook);
            BorrowedBook.IsBorrowed = true;
            BorrowedBook.BorrowedByMemberID = MemberBookBorrow.ID;
            BorrowedBook.BorrowedByMember = MemberBookBorrow;
        }

        public void ReturnBook(LibraryManager Library, string MemberName, string Title, string Author)
        {
            Book? BorrowedBook = Library.GetBook(Title, Author);
            if (BorrowedBook == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            Member? MemberBookBorrow = LibMembers.Find(m => m.Name == MemberName);

            if (!Library.IsBookAvailable(Title, Author))
            {
                Console.WriteLine("Book is not available");
                return;
            }

            if (!BorrowedBook.IsBorrowed || !MemberBookBorrow.BorrowedBooks.Contains(BorrowedBook))
            {
                Console.WriteLine("The Book is not even Borrowed , can't return what you don't already have");
                return;
            }

            MemberBookBorrow.BorrowedBooks.Remove(BorrowedBook);
            BorrowedBook.IsBorrowed = false;
            BorrowedBook.BorrowedByMemberID = null;
            BorrowedBook.BorrowedByMember = MemberBookBorrow;
        }

        public bool IsMemberAvailable(string Name)
        {
            Member? member = LibMembers.Find(m => m.Name == Name);
            if (member == null)
                return false;
            return true;
        }

        public bool IsThereMembers()
        {
            if (LibMembers.Count == 0)
                return false;
            return true;
        }

        public string MemberByID(int id) => LibMembers.Find(m => m.ID == id).Name;
        
    }
}
