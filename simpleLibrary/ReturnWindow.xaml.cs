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
    /// Interaction logic for ReturnWindow.xaml
    /// </summary>
    public partial class ReturnWindow : Window
    {
        /// <summary>
        /// private variable
        /// </summary>
        private Library theLib;

        /// <summary>
        /// deafult return window constructor
        /// sets instance of library
        /// sets combo box to stock items
        /// </summary>
        public ReturnWindow()
        {
            theLib = Library.Instance;
            InitializeComponent();
            cmbStock.ItemsSource = theLib.StockItems;
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
        /// button click will return the stock to having no member
        /// checks to make sure a stock has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            Stock currentStock = (Stock)cmbStock.SelectedItem;

            try
            {
                if (currentStock is null)
                {
                    throw new Exception("Please fill in the options.");
                }
                currentStock.returnStock();
                MessageBox.Show("Stock returned.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid details\n" + ex.Message);
            }
            this.Close();
        }
    }
}

