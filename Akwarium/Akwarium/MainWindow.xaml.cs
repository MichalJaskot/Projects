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
using System.Threading;
using System.Windows.Threading;

namespace Akwarium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Fish> fish = new List<Fish>();
        public ImageBrush[] Images = new ImageBrush[5];
        public Random random = new Random();
        MainWindow window;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            window = this;
            BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Blue.png"));
            Images[0] = new ImageBrush(bitmapImage);

            bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Green.png"));
            Images[1] = new ImageBrush(bitmapImage);

            bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Pink.png"));
            Images[2] = new ImageBrush(bitmapImage);

            bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Red.png"));
            Images[3] = new ImageBrush(bitmapImage);

            bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Yellow.png"));
            Images[4] = new ImageBrush(bitmapImage);
        }

        private void NFish_Click(object sender, RoutedEventArgs e)
        {
            fish.Add(new Fish(window));

        }

        private void RFish_Click(object sender, RoutedEventArgs e)
        {
            if (Aquarium.Children.Count != 0)
            {
                fish.RemoveAt(fish.Count - 1);
                Aquarium.Children.RemoveAt(Aquarium.Children.Count - 1);
            }
            else MessageBox.Show("Nie ma zadnych ryb!");
        }
        public void RemoveFish()
        {
            this.fish[fish.Count - 1].Decrease();
            this.fish[fish.Count - 1].thread.Abort();
            this.fish.RemoveAt(this.fish.Count - 1);
            this.Aquarium.Children.RemoveAt(this.Aquarium.Children.Count - 1);
            FCount.Content = this.fish.Count;

        }

        private void NFish_Click_1(object sender, RoutedEventArgs e)
        {
            fish.Add(new Fish(this));
            FCount.Content = fish.Count;
        }

        private void RFish_Click_1(object sender, RoutedEventArgs e)
        {
            if (Aquarium.Children.Count != 0)
            {
                RemoveFish();
            }
            else MessageBox.Show("There is no fish left!");
        }
    }

    public class Fish
    {
        public Thread thread;
        MainWindow window;
        Rectangle Fishs;
        double x, y;
        public static int index;
        public int indexx, NumberofFish;
        public ImageBrush image;
        public bool ImageRotate = false; //If true then fish is looking right else left;
        public Fish(MainWindow window)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.StrokeThickness = 10;
            rectangle.Height = 50;
            rectangle.Width = 50;
            NumberofFish = window.random.Next(5);
            rectangle.Fill = window.Images[NumberofFish];
            image = window.Images[NumberofFish];
            x = window.random.Next(100,650);
            y = window.random.Next(70,350);
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            window.Aquarium.Children.Add(rectangle);
            Fishs = rectangle;
            this.window = window;

            if (NumberofFish == 2) ImageRotate = true;


            thread = new Thread(new ThreadStart(FishMov));
            thread.Start();
            indexx = Interlocked.Increment(ref index);
        }

        public void Decrease()
        {
            this.indexx = Interlocked.Decrement(ref index);
        }

        public void FishMov()
        {
            Random random = new Random();
            while (true)
            {
                switch (random.Next(9))
                {
                    case 0://Stay
                        Thread.Sleep(20);
                        break;
                    case 1: //North
                        if ((y - 1) > 0)
                        {
                            y--;
                            window.Aquarium.Dispatcher.Invoke(
                        new Action(delegate ()
                        {
                            Canvas.SetTop(Fishs, y);
                            window.Aquarium.Children.RemoveAt(indexx - 1);
                            window.Aquarium.Children.Insert(indexx - 1, Fishs);
                            Thread.SpinWait(window.Aquarium.Children.Count);
                        }
                        ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 2: //North-East
                        if (((y - 1) > 0)||( (x + 1) < 729))
                        {
                            y--;
                            x++;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetTop(Fishs, y);
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                               
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 3: //East
                        if ((x + 1) < 729)
                        {
                            x++;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 4: //South-East
                        if ((y + 1 < 355) || ((x + 1) < 729))
                        {
                            y++;
                            x++;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetTop(Fishs, y);
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 5: //South
                        if ((y + 1) < 390)
                        {
                            y++;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetTop(Fishs, y);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 6: //South-West
                        if ((y + 1 < 355) || ((x - 1) > 1))
                        {
                            y++;
                            x--;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetTop(Fishs, y);
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 7: //West
                        if ((x-1) > 1)
                        {
                            x--;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count);
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                    case 8: //North-West
                        if (((y - 1) > 0) || ((x - 1) > 1))
                        {
                            y--;
                            x--;
                            window.Aquarium.Dispatcher.Invoke(
                            new Action(delegate ()
                            {
                                Canvas.SetTop(Fishs, y);
                                Canvas.SetLeft(Fishs, x);
                                window.Aquarium.Children.RemoveAt(indexx - 1);
                                window.Aquarium.Children.Insert(indexx - 1, Fishs);
                                Thread.SpinWait(window.Aquarium.Children.Count); 
                            }
                            ));
                        }
                        else { Thread.Sleep(20); }
                        break;
                }
            }
        }
    }
}






