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

namespace KBrowser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoButon_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            if (url.Length > 7)
            {
                if (url.Substring(0, 7) != "http://")
                {
                    url = "http://" + url;
                }
            }
            else
            {
                url = "http://" + url;
            }

            NavigationService.Navigate(new Uri("/Browser.xaml?url=" + url,UriKind.Relative));
        }
    }
}