using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace People
{
    /// <summary>
    /// encapsulates a simple Person with a
    /// name, year of birth and Address
    /// </summary>
    [Serializable]
    public class Person
    {
        /// <summary>
        /// name of person
        /// simple version does not have separate first name etc
        /// </summary>
        private string name;
        /// <summary>
        /// year of birth
        /// again simple version - could use date of birth
        /// </summary>
        private int yearOfBirth;
        /// <summary>
        /// A Person can only have one address
        /// </summary>
        private Address address;

        /// <summary>
        /// Name Property
        /// read/write property for attribute name
        /// set method currently has no protection
        /// </summary>
        public string Name //Name property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Year Property
        /// read/write property for attribute year
        /// set method currently has no protection
        /// </summary>
        public int Year //Year property
        {
            get
            {
                return yearOfBirth;
            }
            set
            {
                yearOfBirth = value;
            }
        }
        
        
        /// <summary>
        /// read only accessor method for address
        /// </summary>
        public Address Address
        {
            get
            {
                return address;
            }
        }


        /// <summary>
        /// Setter method for Address
        /// currently has no protection
        /// </summary>
        /// <param name="strst">street</param>
        /// <param name="strtwn">town</param>
        /// <param name="strpc">postcode</param>
        public void setAddress(string strst, string strtwn, string
       strpc)
        {
            address.Street = strst;
            address.Town = strtwn;
            address.Postcode = strpc;
        }

        /// <summary>
        /// default Person constructor
        /// creates new address and sets to default
        /// sets year and name to default
        /// </summary>
        public Person()
        {
            address = new Address();
            setAddress("unknown", "unknown", "unknown");
            Year = 0;
            Name = "no name";
        }

        /// <summary>
        /// overriden constructor
        /// no protection for null string
        /// </summary>
        /// <param name="strn">name of person</param>
        public Person(String strn)
        {
            address = new Address();
            setAddress("unkown", "unknown", "unknown");
            Year = 0;
            Name = strn;               
        }
        /// <summary>
        /// overriden constructor
        /// no protection for null string
        /// </summary>
        /// <param name="strn">name of Person</param>
        /// <param name="yr">year of birth</param>
        public Person(String strn, int yr)
        {
            address = new Address();
            setAddress("unkown", "unknown", "unknown");
            Year = yr;
            Name = strn;           
        }

        /// <summary>
        /// overriden constructor
        /// no protection forany string parameters
        /// </summary>
        /// <param name="strn">name of person</param>
        /// <param name="strst">street</param>
        /// <param name="strtwn">town</param>
        /// <param name="strpc">postcode</param>
        /// <param name="yr">year of birth</param>
        public Person(String strn, string strst, string strtwn, string
        strpc, int yr)
        {
            address = new Address();
            setAddress(strst, strtwn, strpc);
            Year = yr;
            Name = strn;   
        }

        /// <summary>
        /// overriden ToString method
        /// </summary>
        /// <returns>string representation of person</returns>
        public override string ToString() 
        {
            string strout = Name + "\t" + Year;
            strout = strout + address;
            return strout; 
        }
    }
}
