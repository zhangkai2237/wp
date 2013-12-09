using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Windows.Navigation;


namespace BeautifulPuzzle
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void image1_Tap(object sender, GestureEventArgs e)
        {
            App app = Application.Current as App;
            app.ID = 1;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void image2_Tap(object sender, GestureEventArgs e)
        {
            App app = Application.Current as App;
            app.ID = 2;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void image3_Tap(object sender, GestureEventArgs e)
        {
            App app = Application.Current as App;
            app.ID = 3;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void image4_Tap(object sender, GestureEventArgs e)
        {
            App app = Application.Current as App;
            app.ID = 4;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void image5_Tap(object sender, GestureEventArgs e)
        {
            App app = Application.Current as App;
            app.ID = 5;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.Relative));
        }
    }
}