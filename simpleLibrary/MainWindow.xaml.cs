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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleLibrary;

namespace simpleLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// private variable
        /// public gets set for member
        /// </summary>
        private Library theLibrary;
        public Member mem { get; set; }


        /// <summary>
        /// default constructor
        /// sets instance of library
        /// </summary>
        public MainWindow()
        {
            theLibrary = Library.Instance;
            InitializeComponent();
        }

        /// <summary>
        /// Creates a window of type Awindow
        /// shows windows as a dialog window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewMember_Click(object sender, RoutedEventArgs e)
        {
            WindowNewMember Awindow = new WindowNewMember();
            Awindow.ShowDialog();
        }

        /// <summary>
        /// closing winow that asks for confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Simple_Library_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "my app", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// open borrow window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBorrow_Click(object sender, RoutedEventArgs e)
        {
            BorrowWindow Bwindow = new BorrowWindow();
            Bwindow.ShowDialog();
        }

        /// <summary>
        /// opens return window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            ReturnWindow Cwindow = new ReturnWindow();
            Cwindow.ShowDialog();
        }

        /// <summary>
        /// Print a list of the members to the text output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnListMembers_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Clear();
            TxtOutput.Text = theLibrary.getMembers();
        }

        /// <summary>
        /// Prints a list of the books to text output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnListBooks_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Clear();
            TxtOutput.Text = theLibrary.getBooks();
        }

        /// <summary>
        ///  Prints a list of the journals to text output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnListJournals_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Clear();
            TxtOutput.Text = theLibrary.getJournals();
        }

        /// <summary>
        /// prints out all stock to text output
        /// prints all stock to a "dummtprint.txt" text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintStock_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Clear();
            TxtOutput.Text = theLibrary.getStock();
            theLibrary.printStock();
        }
    }
}
