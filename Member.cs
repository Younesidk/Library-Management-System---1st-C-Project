using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System___1st_C__Project
{
    public class Member
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentNullException();
                else
                    name = value;
            }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentNullException();
                else
                    type = value;
            }
        }

        public List<Book> BorrowedBooks = new List<Book>();

        public Member(string Name,string Type)
        {
            this.Name = Name;
            this.Type = Type;
        }

        public override string ToString()
        {
            if(BorrowedBooks.Count != 0)
                return $"Member : {Name} , is a {Type} , borrowed books : {string.Join(" - ",BorrowedBooks)}";
            return $"Member : {Name} , is a {Type}";
        }
    }
}
