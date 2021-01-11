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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            circle.ImageSource = btpImg; //set circle image
            cross.ImageSource = btpImg2; //set cross image
            ImgT.Source = btpImg; //set turn image
        }

        bool turn=true; //Turn, if true then it is circle, if false then cross
        int CircleWins = 0; //Number of won games by circle
        int CrossWins = 0; //Number of won games by cross

        ImageBrush circle = new ImageBrush();
        BitmapImage btpImg = new BitmapImage(new Uri("pack://application:,,,/kolko.png"));

        ImageBrush cross = new ImageBrush();
        BitmapImage btpImg2 = new BitmapImage(new Uri("pack://application:,,,/krzyzyk.png"));

        void WinFunction() //Check if someone won the game
        {
            if(turn == true) //Check if cross or circle
            {
                //Check vertically
                if ((Img1.Background == circle && Img4.Background == circle && Img7.Background == circle) ||
                   (Img2.Background == circle && Img5.Background == circle && Img8.Background == circle) ||
                   (Img3.Background == circle && Img6.Background == circle && Img9.Background == circle))
                {
                    MessageBox.Show("Circle player has won!");
                    CircleWins++; //Increment cicrle games won
                    CiW.Content = CircleWins; //Change number of won games on the interface
                    PGame(); //Pause the game
                }
                //Check cross
                else if ((Img1.Background == circle && Img5.Background == circle && Img9.Background == circle) ||
                        (Img3.Background == circle && Img5.Background == circle && Img7.Background == circle))
                 { 
                    MessageBox.Show("Circle player has won!");
                    CircleWins++; //Increment cicrle games won
                    CiW.Content = CircleWins; //Change number of won games on the interface
                    PGame(); //Pause the game
                }
                //Check horizontally
                else if ((Img1.Background == circle && Img2.Background == circle && Img3.Background == circle) ||
                  (Img4.Background == circle && Img5.Background == circle && Img6.Background == circle) ||
                  (Img7.Background == circle && Img8.Background == circle && Img9.Background == circle))
                { 
                    MessageBox.Show("Circle player has won!");
                    CircleWins++; //Increment cicrle games won
                    CiW.Content = CircleWins; //Change number of won games on the interface
                    PGame(); //Pause the game
                }
            }
            else
            {
                if ((Img1.Background == cross && Img4.Background == cross && Img7.Background == cross) ||
                   (Img2.Background == cross && Img5.Background == cross && Img8.Background == cross) ||
                   (Img3.Background == cross && Img6.Background == cross && Img9.Background == cross))
                { 
                    MessageBox.Show("Cross player has won!");
                    CrossWins++; //Increment cross games won
                    CrW.Content = CrossWins; //Change number of won games on the interface
                    PGame(); //Pause the game
                }
                //Check cross
                else if ((Img1.Background == cross && Img5.Background == cross && Img9.Background == cross) ||
                        (Img3.Background == cross && Img5.Background == cross && Img7.Background == cross))
                { 
                    MessageBox.Show("Cross player has won!");
                    CrossWins++;//Increment cross games won
                    CrW.Content = CrossWins;//Change number of won games on the interface
                    PGame(); //Pause the game
                }
                //Check horizontally
                else if ((Img1.Background == cross && Img2.Background == cross && Img3.Background == cross) ||
                  (Img4.Background == cross && Img5.Background == cross && Img6.Background == cross) ||
                  (Img7.Background == cross && Img8.Background == cross && Img9.Background == cross))
                { 
                    MessageBox.Show("Cross player has won!");
                    CrossWins++;//Increment cross games won
                    CrW.Content = CrossWins;//Change number of won games on the interface
                    PGame(); //Pause the game
                }
            }

        }

        void PGame() //Function to pause the game
        {
            //Turn off all the buttons to pause the game
            Img1.IsEnabled = false;
            Img2.IsEnabled = false;
            Img3.IsEnabled = false;
            Img4.IsEnabled = false;
            Img5.IsEnabled = false;
            Img6.IsEnabled = false;
            Img7.IsEnabled = false;
            Img8.IsEnabled = false;
            Img9.IsEnabled = false;
        }

        void RGame() //Function to resume the game
        {
            //Reset buttons to restart gamestate
            Img1.Background = null;
            Img2.Background = null;
            Img3.Background = null;
            Img4.Background = null;
            Img5.Background = null;
            Img6.Background = null;
            Img7.Background = null;
            Img8.Background = null;
            Img9.Background = null;

            //Turn on buttons to resume the game
            Img1.IsEnabled = true;
            Img2.IsEnabled = true;
            Img3.IsEnabled = true;
            Img4.IsEnabled = true;
            Img5.IsEnabled = true;
            Img6.IsEnabled = true;
            Img7.IsEnabled = true;
            Img8.IsEnabled = true;
            Img9.IsEnabled = true;

        }

        private void Img1_Click(object sender, RoutedEventArgs e)
        {
            if(!(Img1.Background==circle) && !(Img1.Background==cross))
            {
                if (turn == true)
                {
                    Img1.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img1.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img2_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img2.Background == circle) && !(Img2.Background == cross))
            {
                if (turn == true)
                {
                    Img2.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img2.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img3_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img3.Background == circle) && !(Img3.Background == cross))
            {
                if (turn == true)
                {
                    Img3.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img3.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img4_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img4.Background == circle) && !(Img4.Background == cross))
            {
                if (turn == true)
                {
                    Img4.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img4.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img5_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img5.Background == circle) && !(Img5.Background == cross))
            {
                if (turn == true)
                {
                    Img5.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img5.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img6_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img6.Background == circle) && !(Img6.Background == cross))
            {
                if (turn == true)
                {
                    Img6.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img6.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img7_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img7.Background == circle) && !(Img7.Background == cross))
            {
                if (turn == true)
                {
                    Img7.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img7.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img8_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img8.Background == circle) && !(Img8.Background == cross))
            {
                if (turn == true)
                {
                    Img8.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img8.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void Img9_Click(object sender, RoutedEventArgs e)
        {
            if (!(Img9.Background == circle) && !(Img9.Background == cross))
            {
                if (turn == true)
                {
                    Img9.Background = circle;
                    WinFunction();
                    this.turn = false;
                    ImgT.Source = btpImg2;
                }
                else
                {
                    Img9.Background = cross;
                    WinFunction();
                    this.turn = true;
                    ImgT.Source = btpImg;
                }
            }
        }

        private void BtnR_Click(object sender, RoutedEventArgs e) //Reset button
        {
            RGame(); //Call in function to reset game
            UpdateLayout(); //Refresh window
        }
    }
}
