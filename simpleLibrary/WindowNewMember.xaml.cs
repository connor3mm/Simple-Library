using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SimpleLibrary;

namespace simpleLibrary
{
    /// <summary>
    /// Interaction logic for WindowNewMember.xaml
    /// </summary>
    public partial class WindowNewMember : Window
    {
        /// <summary>
        /// private variable
        /// </summary>
        private Library theLibrary;

        /// <summary>
        /// deafult constructor
        /// sets instance of library
        /// </summary>
        public WindowNewMember()
        {
            theLibrary = Library.Instance;
            InitializeComponent();
        }

        /// <summary>
        /// closes windowNewMember
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cancel button closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creates new member
        /// takes in name, year of birth, town, city, postcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string strName = "";
            int year = 0;
            string street = "";
            string town = "";
            string postcode = "";

            //strName = TextName.Text;
            //if (theLibrary.getMembers() != null)
            //{
            //    MessageBox.Show("customer already exists");
            //    this.Close();
            //}
            //else
            //{
            try
            {
                strName = TextName.Text;
                if (strName == "")
                    throw new Exception("Details missing");
                else if (!(strName.Length > 1))
                    throw new Exception("Must be bigger than 1 character long");

                if (TextYear.Text == "")
                    throw new Exception("Year of birth missing");
                year = int.Parse(TextYear.Text);
                if (!(year >= 1900 && year <= 2015))
                    throw new Exception("Year must be between 1900-2015");
                
                street = TextStreet.Text;
                if (street == "")
                    throw new Exception("Street missing");
                else if (!(street.Length > 1))
                    throw new Exception("The street must be bigger than 1 character lonng");

                town = TextTown.Text;
                if (town == "")
                    throw new Exception("Town missing");
                else if (!(town.Length > 1))
                    throw new Exception("The town must be bigger than 1 character lonng");

                postcode = TextPostcode.Text;
                if (postcode == "")
                    throw new Exception("Postcode missing");
                else if (!(postcode.Length >= 6 && postcode.Length <= 8))
                    throw new Exception("Postcode must be between 6-8 characters long");

                theLibrary.addMember(strName, year, street, town, postcode);
                
                MessageBox.Show("New Member Created");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid details\n" + ex.Message);
            }
        }
    }
}
