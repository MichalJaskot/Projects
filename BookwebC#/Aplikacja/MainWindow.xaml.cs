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

namespace Aplikacja
{
    
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserFunctions systemik=new Systemik();

        public MainWindow()
        {
            InitializeComponent();
            //Tutaj byłyby wczytywane dane użytkowników z pliku.
        }
        
        public MainWindow(IUserFunctions MainSystem)
        {
            InitializeComponent();
            systemik = MainSystem;
        }
       

        private void Btn1_Click(object sender, RoutedEventArgs e) //Path for user to log in.
        {
            Login Okno = new Login(systemik);
            this.Close();
            Okno.Show();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e) //Path for user to register. 
        {
            Register Okno = new Register(systemik);
            this.Close();
            Okno.Show();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e) //Exit the application.
        {
            //W tym momencie dane użytkowników byłyby przekazane do pliku.
            System.Windows.Application.Current.Shutdown();
        }
    }
}
