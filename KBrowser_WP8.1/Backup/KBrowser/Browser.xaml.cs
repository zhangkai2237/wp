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
    public partial class Browser : PhoneApplicationPage
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string url = NavigationContext.QueryString["url"].ToString();
            MainBrowser.Navigate(new Uri(url, UriKind.Absolute));
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MainBrowser.Navigate(new Uri(MainBrowser.Source.ToString(), UriKind.Absolute));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainBrowser.InvokeScript("eval", "history.go(-1)");
                //NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("不能回退");
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainBrowser.InvokeScript("eval", "history.go(1)");
            }
            catch
            {
                MessageBox.Show("不能前进");
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
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

            MainBrowser.Navigate(new Uri(url, UriKind.Absolute));
        }
    }
}