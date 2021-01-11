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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Window
    {
        Books book = null;
        IUserFunctions systemik;
        User userD;
        string username;
        public Book(IUserFunctions MainSystem,Books books,User user)
        {  
            systemik = MainSystem;
            book = books;
            userD = user;
            username = user.Login;
            InitializeComponent();
            InitBinding();
            Tb1.Text = Convert.ToString(books.BookID);
            Tb2.Text = books.Name;
            Tb3.Text = books.Author;
            Tb4.Text = books.Genre;
            Tb5.Text = books.Publisher;
            Tb6.Text = Convert.ToString(books.Rate);
            if(book.GetList2().Count!=0)
            {
                foreach (Review item in book.GetList2())
                {
                    lstv1.Items.Add(item);
                    lstv1.Items.Refresh();
                }
            }
        }

        public Book(IUserFunctions MainSystem, User user)
        {
            systemik = MainSystem;
            userD = user;

            InitializeComponent();
            InitBinding();

            Btn4.IsEnabled = true;
            Btn4.Visibility = Visibility.Visible;
            Tb2.IsEnabled = true;
            Tb3.IsEnabled = true;
            Tb4.IsEnabled = true;
            Tb5.IsEnabled = true;
            Tb6.IsEnabled = true;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
        }

        private void InitBinding()
        {
            if(book!=null)
                lstv1.ItemsSource = book.Review;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e) //Exit to menu
        {
            systemik.LogOut();
            Main main = new Main(systemik,userD);
            this.Close();
            main.Show();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e) //Rating a book.
        {
            int index = Lb1.SelectedIndex;
            if (Lb1.SelectedIndex == -1)
                MessageBox.Show("Select an option.");
            else
            {
                if (systemik.RateABook(Lb1.SelectedIndex, book.BookID, username) == true)
                {
                    MessageBox.Show("Succesfully added a rate!");
                    Tb6.Text = Convert.ToString(book.Rate);
                }
                else
                {
                    MessageBox.Show("You've already rated this book.");
                }
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e) //Reviewing a book.
        {
            bool Temp = true;
            Reviewing reviewing = new Reviewing(systemik, username,book);
            reviewing.ShowDialog();
            lstv1.Items.Clear();

            for(int i=0;i<book.GetList2().Count-1;i++)
            {
                if (book.GetList2()[i].Username == username)
                    Temp = false;
            }
            if (Temp == true)
            {
                foreach (Review item in book.GetList2())
                {
                    lstv1.Items.Add(item);
                    lstv1.Items.Refresh();
                }
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (systemik.AddABook(Tb2.Text, Tb3.Text, Tb4.Text, Tb5.Text))
            {
                MessageBox.Show("Successfully added a book!");
                Main main = new Main(systemik, userD);
                this.Close();
                main.Show();
            }
            else MessageBox.Show("Failed adding a book");
            
        }
    }
}
