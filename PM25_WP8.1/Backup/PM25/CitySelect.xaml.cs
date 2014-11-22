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
using Microsoft.Phone.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using PM25.Utility;
using System.IO.IsolatedStorage;

namespace PM25
{
    public partial class CitySelect : PhoneApplicationPage
    {
        public CitySelect()
        {
            InitializeComponent();
        }

        private void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string city = CityList.SelectedItem.ToString();
            string cities = AnalyzeJson.Read("cities");
            if (string.IsNullOrEmpty(cities))
            {
                cities = city;
            }
            else
            {
                cities = cities + "|" + city;
            }
            AnalyzeJson.Save(cities, "cities");
            IsolatedStorageSettings.ApplicationSettings["City"] = city;
            IsolatedStorageSettings.ApplicationSettings.Save();//very importent.
            NavigationService.GoBack();

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string jsonStr = AnalyzeJson.Read("CityList");
            if (string.IsNullOrEmpty(jsonStr))
            {
                UpdateData();
            }
            else
            {
                try
                {
                    CityList.ItemsSource = GetCityList(jsonStr);
                }
                catch
                {
                    UpdateData();
                }
            }
        }

        private void UpdateData()
        {
            WebClient wb = new WebClient();
            //添加下载完成后的处理事件  
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
            //开始异步下载  
            string urlStr = "http://pm25.in/api/querys.json?token=qExyDEkkCvjSiysDT7Jz";
            wb.DownloadStringAsync(new Uri(urlStr, UriKind.Absolute));
        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.None)
            {
                MessageBox.Show("无法连接网络", "注意", MessageBoxButton.OK);
                return;
            }

            //string[] cityList = json["cities"].ToString().TrimEnd("\"]".ToCharArray()).TrimStart("[\"".ToCharArray()).Split("\",\"".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            CityList.ItemsSource = GetCityList(e.Result);
            AnalyzeJson.Save(e.Result, "CityList");
        }

        private JArray GetCityList(string jsonStr)
        {
            JObject json = JObject.Parse(jsonStr);
            JArray cityList = (JArray)json["cities"];
            return cityList;
        }

        private void CitySeach_TextChanged(object sender, TextChangedEventArgs e)
        {
            string jsonStr = AnalyzeJson.Read("CityList");

            JArray cityList = GetCityList(jsonStr);

            var Result = cityList.Where(city => city.ToString() == CitySeach.Text);

            CityList.ItemsSource = Result;

            //List<string> cityList = new List<string>(GetCityList(jsonStr).ToString());
        }


    }
}