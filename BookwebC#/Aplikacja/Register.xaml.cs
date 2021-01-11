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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        IUserFunctions systemik;

        public Register(IUserFunctions MainSystem)
        {
            InitializeComponent();
            systemik = MainSystem;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e) //Exit to menu.
        {
            MainWindow Okno = new MainWindow(systemik);
            this.Close();
            Okno.Show();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e) //Register new user.
        {
            if (systemik.Registration(Tb1.Text, Pb1.Password , Tb3.Text) == true)
            {
                Login login = new Login(systemik);
                this.Close();
                login.Show();
            }
            else
                MessageBox.Show("We couldn't register your account. Try again.");
        }
    }
}
