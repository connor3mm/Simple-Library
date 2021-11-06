using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using People;

namespace SimpleLibrary
{
    /// <summary>
    /// Member encapsulates library members
    /// 
    /// extends People.Person class
    /// </summary>
    public class Member : Person
    {
        /// <summary>
        /// private variable
        /// </summary>
        private int ID;

        /// <summary>
        /// Calls base constructor.
        /// Sets ID
        /// </summary>
        public Member() : base()
        {
            ID = 0;
        }


        /// <summary>
        /// Calls base constructor
        /// Sets parameters to values. 
        /// </summary>
        /// <param name="strn">String Name</param>
        /// <param name="strst">String Street</param>
        /// <param name="strtwn">String Town</param>
        /// <param name="strpc">String Postcode</param>
        /// <param name="yr">Int Year of Birth</param>
        /// <param name="mid">Int ID</param>
        public Member(String strn, string strst, string strtwn, string strpc, int yr, int mid) : base()
        {

            Name = strn;
            Address.Street = strst;
            Address.Town = strtwn;
            Address.Postcode = strpc;
            Year = yr;
            ID = mid;
        }


        /// <summary>
        /// overriden ToString method
        /// </summary>
        /// <returns>String representing of ID and Name.</returns>
        public override string ToString()
        {
            string strout;
            strout = ID + ": " + Name;
            return strout;
        }
    }
}
