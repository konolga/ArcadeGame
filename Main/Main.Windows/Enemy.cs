using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Main
{
    class Enemy
    {
        Image _image;

        public Enemy(Canvas gameArea, byte enemynumber)
        {

            _image = new Image();
            _image.Height = 100;
            _image.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/Jelly" + enemynumber + ".png", UriKind.Absolute));
            gameArea.Children.Add(_image);
            EnemyStartPosition(gameArea);
        }


        private readonly Random rnd = new Random();
        private readonly object syncLock = new object();
        private void EnemyStartPosition(Canvas gameArea)
        {
            lock (syncLock)
            {
                _image.SetValue(Canvas.LeftProperty, new Random().Next(0, (int) (gameArea.ActualWidth - _image.ActualWidth)));
                _image.SetValue(Canvas.TopProperty, new Random().Next(0, (int) (gameArea.ActualHeight - _image.ActualHeight)));
            }
        }
    }
}
