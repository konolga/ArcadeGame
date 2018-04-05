using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace Main
{
    class Player

    {
        public Image _image;
        

        public Player(Canvas gameArea)
        {
            _image = new Image {Height = 100, Width = 200};
            _image.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/crabbig.png", UriKind.Absolute));
            gameArea.Children.Add(_image);
            PlayerStartPosition(gameArea);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0,100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        
        private void timer_Tick(object sender, object e)
        {
                MoveElement();

        }

        //Set Horizontal and vertical position,
        // so that player will not move out of the canvas
        //????????????????Why I cannot get Canvas.ActualWidth?????
        private double position;
       // private Canvas gameArea;
        byte step = 50;
        private double HorizontalPosition(int step)
        {
            position = Canvas.GetLeft(_image);
            position += step;
            if (position > 1500)
            {
                position = 1500- _image.ActualWidth;
                // position = gameArea.ActualWidth - _image.ActualWidth;
            }
            else if (position < 0)
            {
                position = 0;
            }
            return position;
        }
        private double VerticalPosition(int step)
        {
            position = Canvas.GetTop(_image);
            position += step;
            if (position > 1200)
            {
                position = 1200 - _image.ActualHeight;
            }
            else if (position < 0)
            {
                position = 0;
            }
            return position;
        }

        private void MoveElement()      
        {
            //=====================================================================
            //This idea was taken from 
            //Windows 8.1 Apps with XAML and C# Unleashed. By Adam Nathan, page 171
            //https://goo.gl/mctssA
            //=====================================================================


            CoreVirtualKeyStates DownState = Window.Current.CoreWindow.GetKeyState(VirtualKey.Down);
            CoreVirtualKeyStates UpState = Window.Current.CoreWindow.GetKeyState(VirtualKey.Up);
            CoreVirtualKeyStates RightState = Window.Current.CoreWindow.GetKeyState(VirtualKey.Right);
            CoreVirtualKeyStates LeftState = Window.Current.CoreWindow.GetKeyState(VirtualKey.Left);

            if ((DownState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
                {
                    //only DOWN is pressed
                    Canvas.SetTop(_image, VerticalPosition(step));
                }
                if ((UpState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
                {
                    //only UP is pressed
                    Canvas.SetTop(_image, VerticalPosition(-step));
                }
                if ((LeftState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
                {
                    //only LEFT is pressed
                    Canvas.SetLeft(_image, HorizontalPosition(-step));
                }
                if ((RightState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
                {
                //only RIGHT is pressed
                     Canvas.SetLeft(_image, HorizontalPosition(step));
            }
        }


        // Method to set the original position of the player randomly
        private void PlayerStartPosition(Canvas gameArea)
        {
            Random rnd = new Random();
            _image.SetValue(Canvas.LeftProperty, rnd.Next(0, (int) (gameArea.ActualWidth - _image.ActualWidth)));
            _image.SetValue(Canvas.TopProperty, rnd.Next(0, (int) (gameArea.ActualHeight - _image.ActualHeight)));
            
        }
    }
}


















//https://blogs.windows.com/buildingapps/2015/04/09/how-to-make-a-windows-store-game-with-c-and-xaml-part-3/#Cw0YlHzVH72Vaj4J.97