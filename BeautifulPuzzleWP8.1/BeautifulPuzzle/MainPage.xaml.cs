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
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using GoogleAds;


namespace BeautifulPuzzle
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int count = this.GetCount();

            List<ImageString> imageStrings = new List<ImageString>();

            for (int i = 0; i < 15; i++)
            {
                ImageString image = new ImageString();
                image.Index = i;
                string imageName = "/middle/lock.jpg";
                if (i < count)
                {
                    imageName = string.Format("/middle/{0}_small.jpg", i);
                }               
                
                image.Image = new BitmapImage(new Uri(imageName, UriKind.RelativeOrAbsolute));

                imageStrings.Add(image);
            }

            ImageList.ItemsSource = imageStrings;
        }

        private void Image_Tap(object sender, GestureEventArgs e)
        {
            Image image = (Image)sender;
            ImageString imageString = image.DataContext as ImageString;
            if (imageString.Index < this.GetCount())
            {
                App app = Application.Current as App;
                app.ID = imageString.Index;
                NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        public static List<T> GetVisualChildCollection<T>(object parent) where T : UIElement
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection<T>(parent as DependencyObject, visualCollection);
            return visualCollection;
        }

        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : UIElement
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection<T>(child, visualCollection);
                }
            }
        }

        //private void OnAdReceived(object sender, AdDuplex.AdClickEventArgs e)
        //{
        //    int count = this.GetCount();
        //    DateTime day = this.GetClickDate();
        //    if (day.Date < DateTime.Now.Date)
        //    {
        //        count += 1;
        //        IsolatedStorageSettings.ApplicationSettings["AllowCount"] = count.ToString();
        //        IsolatedStorageSettings.ApplicationSettings["ClickDate"] = DateTime.Now.Date.ToString();
        //    }
        //}


        private int GetCount()
        {
            string settingName = "AllowCount";
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(settingName))
            {
                IsolatedStorageSettings.ApplicationSettings[settingName] = 3;
            }
            int count = Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings[settingName]);

            return count;
        }

        private DateTime GetClickDate()
        {
            string settingName = "ClickDate";
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(settingName))
            {
                IsolatedStorageSettings.ApplicationSettings[settingName] = DateTime.Now.AddDays(-3).Date.ToString();
            }
            DateTime day = Convert.ToDateTime(IsolatedStorageSettings.ApplicationSettings[settingName]).Date;

            return day;
        }

        private void AdView_LeavingApplication(object sender, AdEventArgs e)
        {
            int count = this.GetCount();
            DateTime day = this.GetClickDate();
            if (day.Date < DateTime.Now.Date)
            {
                count += 1;
                IsolatedStorageSettings.ApplicationSettings["AllowCount"] = count.ToString();
                IsolatedStorageSettings.ApplicationSettings["ClickDate"] = DateTime.Now.Date.ToString();
            }
        }
    }

    public class ImageString
    {
        public int Index { get; set; }

        public BitmapImage Image { get; set; }

    }
}