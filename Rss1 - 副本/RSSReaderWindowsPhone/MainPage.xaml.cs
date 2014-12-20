//This code was taken from http://social.msdn.microsoft.com/profile/khaled%20jemni/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RSSReaderWindowsPhone.Resources;
using System.Xml.Linq;

// Khaled JEMNI
// Microsoft Student Partner Tunisia
// khaled.jemni@studentpartner.com
// @khaledjemni
// +216 24 51 81 31
namespace RSSReaderWindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // In this event we need to create the web client who's going to download the informations from our link 
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            // I've used a link of a Tunisian Radio that I've developped their app on Windows Phone
            // feel free to change it and set it with your own links
            wc.DownloadStringAsync(new Uri("http://coolshell.cn/feed"));
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //This simple test will return an error if the device is not connected to the internet
            if (e.Error != null)
                return;
            XElement xmlitems = XElement.Parse(e.Result);
            // We need to create a list of the elements
            List<XElement> elements = xmlitems.Descendants("item").ToList();

            // Now we're putting the informations that we got in our ListBox in the XAML code
            // we have to use a foreach statment to be able to read all the elements 
            // Description 1 , Link1 , Title1 are the attributes in the RSSItem class that I've already added
            List<RSSItem> aux = new List<RSSItem>();
            foreach (XElement rssItem in elements)
            {
                RSSItem rss = new RSSItem();

                rss.Description1 = rssItem.Element("pubDate").Value;
                rss.Link1 = rssItem.Element("link").Value;
                rss.Title1 = rssItem.Element("title").Value;
                aux.Add(rss);

                StackPanel panel = new StackPanel();

                TextBlock tbUrl = new TextBlock();
                tbUrl.Text = rss.Link1;
                tbUrl.Visibility = Visibility.Collapsed;
                panel.Children.Add(tbUrl);

                TextBlock tbTitle = new TextBlock();
                tbTitle.FontSize = 28;
                tbTitle.TextWrapping = TextWrapping.Wrap;
                tbTitle.Text = rss.Title1;
                panel.Children.Add(tbTitle);
                //ListBoxRss.Items.Add(tbTitle);

                TextBlock tbDescription = new TextBlock();
                tbDescription.Text = "      发布时间：" + rss.Description1 + "\n";
                panel.Children.Add(tbDescription);
                //ListBoxRss.Items.Add(tbDescription);

                panel.Tap += panel_Tap;

                ListBoxRss.Items.Add(panel);

            }
        }

        void panel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            TextBlock textBlock = (TextBlock)panel.Children[0];
            NavigationService.Navigate(new Uri("/Content.xaml?url=" + textBlock.Text, UriKind.RelativeOrAbsolute));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}