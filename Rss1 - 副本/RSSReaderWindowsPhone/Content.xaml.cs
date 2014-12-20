using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace RSSReaderWindowsPhone
{
    public partial class Content : PhoneApplicationPage
    {
        public Content()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = NavigationContext.QueryString["url"].ToString();

                ContentView.Navigate(new Uri(url, UriKind.Absolute));
            }
            catch (Exception ex)
            {
                //do something;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                ContentView.InvokeScript("eval", "history.go(-1)");
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
                ContentView.InvokeScript("eval", "history.go(1)");
            }
            catch
            {
                MessageBox.Show("不能前进");
            }
        }
    }
}