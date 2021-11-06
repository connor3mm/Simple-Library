using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    /// <summary>
    /// stock class to hold books and journals
    /// </summary>
    public abstract class Stock
    {
        /// <summary>
        /// Declares protected variables
        /// </summary>
        protected int libraryNum;
        protected string title;
        protected Member member;
        protected DateTime returnDate;


        /// <summary>
        /// default Stock constructor
        /// Sets library number to deafult
        /// sets title to unknown and member to null
        /// </summary>
        public Stock()
        {
            LibraryNum = 0;
            Title = "unknown";
            member = null;
        }


        /// <summary>
        /// overriden constructor
        /// no protection for null string
        /// </summary>
        /// <param name="id">Library number</param>
        /// <param name="strtitle">title of book/journal</param>
        public Stock(int id, string strtitle)
        {
            LibraryNum = id;
            Title = strtitle;
            member = null;
        }


        /// <summary>
        ///  library number Property
        /// read/write property for attribute library number
        /// </summary>
        public int LibraryNum
        {
            get { return libraryNum; }
            set { libraryNum = value; }
        }


        /// <summary>
        /// Title Property
        /// read/write property for attribute title
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        /// <summary>
        /// overriden ToString method
        /// </summary>
        /// <returns>string representation of stock</returns>
        public override string ToString()
        {
            string strout;
            strout = LibraryNum + " " + Title + "\n";
            return strout;
        }


        /// <summary>
        /// Abstract method for borrowing stock
        /// </summary>
        /// <param name="m">Member thats borrowing stock</param>
        public virtual void borrow(Member m)
        {

        }


        public void returnStock()
        {
            if (member == null)
            {
                throw new Exception("Not on loan");
            }
            else
            {
                member = null;
            }
        }

    }



    /// <summary>
    /// book class to create a book that holds author and base attributes
    /// </summary>
    class Book : Stock
    {
        /// <summary>
        /// Name of author
        /// </summary>
        private string author;


        /// <summary>
        /// Author Property
        /// read/write property for attribute Author
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }


        /// <summary>
        /// Calls base constructor
        /// Book constructor that sets author to default
        /// </summary>
        public Book() : base()
        {
            // Title = "unknown";
            Author = "unknown";
            //LibraryNum = 0;
        }


        /// <summary>
        /// overriden constructor
        /// </summary>
        /// <param name="strtitle">title of book</param>
        /// <param name="strauthor">author name</param>
        /// <param name="intid">id of book</param>
        public Book(string strtitle, string strauthor, int intid) : base(intid, strtitle)
        {
            // Title = strtitle;
            Author = strauthor;
            // LibraryNum = intid;  
        }


        /// <summary>
        /// overriden ToString method
        /// </summary>
        /// <returns>string representation of book</returns>
        public override string ToString()
        {
            string strout;
            if (member == null)
            {
                strout = LibraryNum + ": " + Title + " by " + Author;
                return strout; 
            }
            else
            {
                strout = LibraryNum + ": " + Title + " by " + Author + " on loan to " + member + " return date: " + returnDate + "\n";
                return strout;
            }
        }


        /// <summary>
        /// overridden method for borrow
        /// </summary>
        /// <param name="m">Member thats borrowing book stock</param>
        public override void borrow(Member m)
        {
            if (member == null)
            {
                member = m;
                returnDate = DateTime.Now;
                returnDate.AddDays(30);
            }

            else
            {
                throw new Exception("already on loan");
            }

        }
    }



    /// <summary>
    ///  Journal class to create a journal that holds volume and base attributes
    /// </summary>
    class Journal : Stock
    {
        /// <summary>
        /// Name of volume
        /// </summary>
        private int volume;

        /// <summary>
        /// Volume Property
        /// read/write property for attribute Volume
        /// </summary>
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }


        /// <summary>
        /// Calls base constructor
        /// Journal constructor that sets volume to default
        /// </summary>
        public Journal() : base()
        {
            Volume = 0;
        }


        /// <summary>
        /// overridden constructor
        /// no protection for parameters
        /// </summary>
        /// <param name="vol">journal volume</param>
        /// <param name="strtitle">journal title</param>
        /// <param name="id">journal id</param>
        public Journal(int vol, string strtitle, int id) : base(id, strtitle)
        {
            Volume = vol;
            // Title = strtitle;
            // LibraryNum = id;
        }


        /// <summary>
        /// overriden to string method 
        /// </summary>
        /// <returns>string represting journal</returns>
        public override string ToString()
        {
            string strout;
            if (member == null)
            {
                strout = LibraryNum + ": " + Title + " volume " + Volume;
                return strout;
            }
            else
            {
                strout = LibraryNum + ": " + Title + " volume " + Volume + " on loan to " + member + " return date: " + returnDate + "\n";
                return strout;
            }
        }


        /// <summary>
        /// overridden method for borrow
        /// </summary>
        /// <param name="m">member thats borrowing journal stock</param>
        public override void borrow(Member m)
        {

            if (member == null)
            {
                member = m;
                returnDate = DateTime.Now;
                returnDate.AddDays(3);
            }
            else
            {
                throw new Exception("already on loan");
            }

        }
    }
}
