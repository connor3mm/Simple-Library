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
    /// Interaction logic for BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        /// <summary>
        /// private instance variable
        /// </summary>
        private Library theLib;


        /// <summary>
        /// constructor for borrow window
        /// makes an instance of library
        /// sets combo boxes to member and stock lists 
        /// </summary>
        public BorrowWindow()
        {
            theLib = Library.Instance;
            InitializeComponent();
            cmbMembers.ItemsSource = theLib.Members;
            cmbStock.ItemsSource = theLib.StockItems;
            //book1.
        }

      
        /// <summary>
        /// window closed method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            //this.Owner.Show();
            this.Close();
        }


        /// <summary>
        /// Checks if member and stock are valid
        /// sets certain stock to a member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnborrow1_Click(object sender, RoutedEventArgs e)
        {
            Member currentMember = (Member)cmbMembers.SelectedItem;
            Stock currentStock = (Stock)cmbStock.SelectedItem;

            try
            {
                if (currentMember is null || currentStock is null)
                {
                    throw new Exception("Please fill in the options.");
                }
                currentStock.borrow(currentMember);
                MessageBox.Show(null + currentStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid details\n" + ex.Message);
            }
            this.Close();
        }


        /// <summary>
        /// cancel button closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
