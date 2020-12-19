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

namespace CashRegisterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create a list for all the entries
        List<double> sumList = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if any number button is pressed, take what is in the content
            //and put that iin the user entry text box
            Button button = (Button)sender;
            userEntryTextBox.Text += button.Content.ToString();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            //if the user entry contains a "."
            if (userEntryTextBox.Text.Contains("."))
            {
                //split the user text box into two array entries
                //the left side of the "." is array[0]
                //the right side of the "." is arrray[1]
                String[] numbers = userEntryTextBox.Text.Split('.');
                //if the right side of the "." has more than 2 numbers
                //aka two decimals
                //show message to user
                if (numbers[1].Length > 2)
                {
                    MessageBox.Show("Stop.");
                    userEntryTextBox.Clear();
                }
                //else add the entry to the list
                else
                {

                    sumList.Add(Convert.ToDouble(userEntryTextBox.Text));
                    userEntryTextBox.Clear();
                }
            }
            //if the user entry box is empty
            //display message
            else if (userEntryTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please enter a number.");
            }
            //if number has no decimals
            //add to sum list and clear text box
            else
            {
                sumList.Add(Convert.ToDouble(userEntryTextBox.Text));
                userEntryTextBox.Clear();
            }
        }

        private void totalButton_Click(object sender, RoutedEventArgs e)
        {
            //sum the sum list and put it in the sub total text box
            subtotalTextBox.Text = sumList.Sum().ToString("F");
            //take the sum from the sum list and multiply by .075 and put that in the tax text box
            taxTextBox.Text = (sumList.Sum() * .075).ToString("F");
            //add tax and subtotal and put it in the total text box
            totalTextBox.Text = (Convert.ToDouble(subtotalTextBox.Text) + Convert.ToDouble(taxTextBox.Text)).ToString("F");
        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //if userentry length is greater than 1, delete the last number in the textbox
            if (userEntryTextBox.Text.Length > 0)
            {
                userEntryTextBox.Text = userEntryTextBox.Text.Substring(0, userEntryTextBox.Text.Length - 1);
            }
            //else set text box to nothing
            else
            {
                userEntryTextBox.Text = "";
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            //Clears what is in the User Entry Text box
            userEntryTextBox.Clear();
        }

        private void clearAllButton_Click(object sender, RoutedEventArgs e)
        {
            //Clears all tetx boxes and the SumList List
            userEntryTextBox.Clear();
            subtotalTextBox.Clear();
            totalTextBox.Clear();
            taxTextBox.Clear();
            sumList.Clear();
        }


    }
}
