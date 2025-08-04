using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System___1st_C__Project
{
    public class Book
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value == "" || value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                    title = value;
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                if (value == "" || value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                    author = value;
            }
        }

        private int pages;
        public int Pages
        {
            get { return pages; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else
                    pages = value;
            }
        }
        

        public bool IsBorrowed { get; set; } = false;

        public Member? BorrowedByMember;
        public int? BorrowedByMemberID { get; set; } = null;

        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }

      /*  public Book()
        {
        }*/

        public override string ToString()
        {
            if(BorrowedByMember == null)
                return $"{title} By {Author} , {pages} Pages - Not borrowed (Available)";
            return $"{Title} By {Author} , {Pages} Pages - Borrowed by {BorrowedByMember.Name}";
        }
    }
}
