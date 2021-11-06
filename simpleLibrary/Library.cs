using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace SimpleLibrary
{
    public class Library
    {
        /// <summary>
        /// Singleton object
        /// </summary>
        private static Library library;

        // declares and initialises a constant
        private const string FILE_NAME = "dummyprinter.txt";

        /// <summary>
        /// Instance property returns the singleton instance
        /// </summary>
        public static Library Instance
        {
            get
            {
                if (library == null)
                    library = new Library();
                return library;
            }
        }

        /// <summary>
        /// Instance variables
        /// </summary>
        private List<Member> members;

        /// <summary>
        /// Instance variables
        /// </summary>
        private List<Stock> stock;


        /// <summary>
        /// default library constructor
        /// </summary>
        public Library()
        {
            members = new List<Member>();
            stock = new List<Stock>();
        }


        /// <summary>
        /// read only accessor method for Members
        /// </summary>
        public List<Member> Members
        {
            get
            {
                return members;
            }
        }


        /// <summary>
        /// read only accessor method for Stock items
        /// </summary>
        public List<Stock> StockItems
        {
            get
            {
                return stock;
            }
        }


        /// <summary>
        /// Setter method for addMembers
        /// currently has no protection
        /// </summary>
        /// <param name="nm">name of person</param>
        /// <param name="yr">year of birth</param>
        /// <param name="St">street</param>
        /// <param name="Twn">town</param>
        /// <param name="strpc">street postcode</param>
        public void addMember(string nm, int yr, string St, string Twn, string strpc)
        {
            int mid = getNextMemberID();
            Member a = new Member(nm, St, Twn, strpc, yr, mid);
            members.Add(a);
        }


        /// <summary>
        /// Calculates an id number for new member
        /// </summary>
        /// <returns>new members id</returns>
        private int getNextMemberID()
        {
            int mid = Members.Count + 1;

            return mid;
        }


        /// <summary>
        /// Method to list all members in the list
        /// Throws exception if no entries 
        /// </summary>
        /// <returns>"no entries" if member count is zero
        /// if theres members in the list, lists all members</returns>
        public string getMembers()
        {
            string strMembers = "";

            if (Members.Count == 0)
            {
                return "No Entries";
            }

            foreach (Member a in Members)
            {
                strMembers = strMembers + a + "\n";
            }
            return "Library Members" + "\n\n" + strMembers;
        }


        /// <summary>
        /// overriden constructor
        /// Adds every number of copies to stock
        /// no protection for null string
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="author">Author of book</param>
        /// <param name="numCopies">Number of copies of a single book.</param>
        public void addBook(String title, String author, int numCopies)
        {
            for (int i = 0; i < numCopies; i++)
            {
                int intid = getNextLibNum();
                Book a = new Book(title, author, intid);
                stock.Add(a);
            }
        }


        /// <summary>
        /// Calculates new stock id.
        /// </summary>
        /// <returns>new library id</returns>
        public int getNextLibNum()
        {
            int intid = StockItems.Count + 1;

            return intid;
        }


        /// <summary>
        /// overriden constructor
        /// Adds every number of copies to stock
        /// no protection for null string
        /// </summary>
        /// <param name="title">Title of journal</param>
        /// <param name="vol">Volume of journal</param>
        /// <param name="quantity">Number of single journals</param>
        public void addJournal(string title, int vol, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int id = getNextLibNum();
                Journal a = new Journal(vol, title, id);
                stock.Add(a);
            }
        }


        /// <summary>
        /// Method to list all stock in the list
        /// </summary>
        /// <returns>
        /// 1.No entries if stock list is empty.
        /// 2.All stock in the list
        /// </returns>
        public string getStock()
        {
            string strStock = "";

            if (StockItems.Count == 0)
            {
                return "No Entries";
            }

            foreach (Stock a in StockItems)
            {
                strStock = strStock + a + "\n";
            }
            return "Stock:" + "\n\n" + strStock;
        }


        /// <summary>
        /// Method to list all books in stock list
        /// </summary>
        /// <returns>
        /// 1. No entries if no books in list
        /// 2. Every book in stock list
        /// </returns>
        public string getBooks()
        {
            string strBooks = "";

            if (StockItems.Count == 0)
            {
                return "No Entries";
            }

            foreach (Stock a in StockItems)
            {
                if (a is Book)
                {
                    strBooks = strBooks + a + "\n";
                }
            }
            return "Books:" + "\n\n" + strBooks;
        }


        /// <summary>
        /// Method to list all journals in stock list
        /// </summary>
        /// <returns>
        /// 1. No entries if no journals in list
        /// 2. Every journal in stock list
        /// </returns>
        public string getJournals()
        {
            string strJournals = "";

            if (StockItems.Count == 0)
            {
                return "No Entries";
            }

            foreach (Stock a in StockItems)
            {
                if (a is Journal)
                {
                    strJournals = strJournals + a + "\n";
                }
            }
            return "Jornals:" + "\n\n" + strJournals;
        }


        /// <summary>
        /// Creates new file to write all stock too.
        /// </summary>
        /// <returns>File thats been written too</returns>
        public string printStock()
        {
            //checks to see if a file already exists
            if (File.Exists(FILE_NAME))
            {
                using (StreamWriter sw = File.AppendText(FILE_NAME))
                {
                    sw.WriteLine(getStock());
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(FILE_NAME))
                {
                    sw.WriteLine(getStock());
                    sw.Close();
                }
            }

            return FILE_NAME; //yes
        }
    }
}
