using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                // adding player
                Player player = new Player(GameArea);
                textBlock1.Text = player._image.ActualWidth.ToString();

                //adding enemies
                Enemy enemy1 = new Enemy(GameArea, 1);
                Enemy enemy2 = new Enemy(GameArea, 2);
                Enemy enemy3 = new Enemy(GameArea, 3);
                Enemy enemy4 = new Enemy(GameArea, 4);
                Enemy enemy5 = new Enemy(GameArea, 5);
                Enemy enemy6 = new Enemy(GameArea, 6);
                Enemy enemy7 = new Enemy(GameArea, 7);
                Enemy enemy8 = new Enemy(GameArea, 8);

            };
            }
        }
    }

