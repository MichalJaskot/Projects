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
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IUserFunctions systemik;
        public Login(IUserFunctions MainSystem)
        {
            InitializeComponent();
            systemik = MainSystem;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Exit to menu.
        {
            MainWindow Okno = new MainWindow(systemik);
            this.Close();
            Okno.Show();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e) //Log in to the system.
        {
            User tmp = systemik.LogIn(Tb1.Text, Pb1.Password);
            if (tmp != null)
            {
                Main Okno = new Main(systemik,tmp);
                this.Close();
                Okno.Show();
            }
            else
                MessageBox.Show("We couldn't log you in. Check your login and password and try again.");
        }
    }
}
