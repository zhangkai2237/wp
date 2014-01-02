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

        private void image_Tap(object sender, GestureEventArgs e)
        {
            Image image = (Image)sender;
            App app = Application.Current as App;
            app.ID = Convert.ToInt32(image.Name.TrimStart("image".ToCharArray()));
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}