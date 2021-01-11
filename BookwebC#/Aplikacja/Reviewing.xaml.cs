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

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy Reviewing.xaml
    /// </summary>
    public partial class Reviewing : Window
    {
        IUserFunctions systemik;
        string username;
        Books book;

        public Reviewing(IUserFunctions MainSystem, string user,Books temp)
        {
            systemik = MainSystem;
            username = user;
            book = temp;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Adding a review.
        {
            if (Tb1.Text=="")
            {
                MessageBox.Show("Wrong review.");
            }
            else if (systemik.AddReview(Tb1.Text, book.BookID, username) == true)
            {
                MessageBox.Show("Succesfully added a review!");
                this.Close();
            }
            else
                MessageBox.Show("You've already reviewed this book.");
        }

        private void Button2_Click(object sender, RoutedEventArgs e) //Back to the page of the book.
        {
            this.Close();
        }
    }
}
