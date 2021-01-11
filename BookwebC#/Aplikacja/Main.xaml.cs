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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        IUserFunctions systemik;
        User userD;

        public Main(IUserFunctions MainSystem, User userD)
        {
            InitializeComponent();
            systemik = MainSystem;
            this.userD = userD;
            label2.Content = this.userD.Login;
            foreach (Books item in systemik.SearchABook(""))
            {
                searchlst.Items.Add(item);
                searchlst.Items.Refresh();
            }
            if (userD.Admin == true)
            {
                Btn2.IsEnabled = true;
                Btn2.Visibility = Visibility.Visible;
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e) //Exit to menu
        {
            systemik.LogOut();
            MainWindow mainWindow = new MainWindow(systemik);
            this.Close();
            mainWindow.Show();
        }

        private void Tb1_TextChanged(object sender, TextChangedEventArgs e) //Search for the books.
        {
            searchlst.Items.Clear();
            foreach (Books item in systemik.SearchABook(Tb1.Text))
            {
                searchlst.Items.Add(item);
                searchlst.Items.Refresh();
            }
        }

        private void Searchlst_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Open page of the selected book.
        {
            Book book = new Book(systemik,(Books)searchlst.SelectedItem,userD);
            this.Close();
            book.Show();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book(systemik, userD);
            this.Close();
            book.Show();
        }
    }
}
