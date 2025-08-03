using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System___1st_C__Project
{
    public class LibraryManager
    {
        private List<Book> Books = new List<Book>();

        public void AddBook(string Title, string Author, int Pages)
        {
            try
            {
                Books.Add(new Book(Title, Author, Pages));
            }
            catch (ArgumentNullException Ar)
            {
                Console.WriteLine("The Book must have a title or an author");
            }
            catch (ArgumentOutOfRangeException Ar)
            {
                Console.WriteLine("The Book can't have Negative Pages");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception : {ex}");
            }
        }

        public void ListBooks()
        {
            
            if (Books.Count == 0)
            {
                Console.WriteLine("The Library is still empty");
                return;
            }
            Console.WriteLine("All Books : ");
            foreach (var Book in Books)
            {
                Console.WriteLine(Book);
            }
        }

        public void RemoveBook(string Title)
        {
            Book? BookToRemove = Books.Find(m => m.Title == Title);
            if (BookToRemove == null)
            {
                Console.WriteLine("Book doesn't exist");
                return;
            }

            Books.RemoveAll(b => b.Title == Title);
        }

        public bool IsBookAvailable(string Title, string Author)
        {
            List<Book> FoundBooks = Books.FindAll(b => b.Title == Title && b.Author == Author);

            foreach (var book in FoundBooks)
            {
                return true;
            }
            return false;
        }

        public Book GetBook(string Title, string Author)
        {
            return Books.Find(b => b.Title == Title && b.Author == Author);
        }

        public bool IsLibraryEmpty()
        {
            if (Books.Count == 0)
                return true;
            return false;
        }
    }
}
