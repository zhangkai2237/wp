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
using PM25.Utility;
using Newtonsoft.Json.Linq;
using PM25.Model;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone.Net.NetworkInformation;

namespace PM25
{
    public partial class MainPage : PhoneApplicationPage
    {

        //List<AirModel> entityList = new List<AirModel>();

        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            //progressBar1.IsIndeterminate = true;
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            //DetailsList.DataContext = 
            //Panorama1.Title = "上海";
            string jsonStr = AnalyzeJson.Read("MainPage");
            List<AirModel> entityList = AnalyzeJson.JsonToEntityList(jsonStr);
            if (entityList.Count == 0)
            {
                AirModel entity = new AirModel() { AQI = 100, Area = "上海", No2 = 13, Pm10 = 89, Quality = "良", Pm25 = 13, SO2 = 34, TimePoint = DateTime.Now };
                entityList.Add(entity);
            }
            UploadUI(entityList);
            UpdateData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="entity"></param>
        private void UploadUI(List<AirModel> entityList)
        {
            AirModel entity = entityList[entityList.Count() - 1];
            entityList.Remove(entity);
            #region 更新城市空气质量
            Area.Inlines.Clear();
            Area.Inlines.Add(new Run() { Text = entity.Area, FontSize = 50 });
            Area.Inlines.Add(new LineBreak());
            Area.Inlines.Add(new Run() { Text = entity.TimePoint.ToString("yyyy年MM月dd日") });

            AQI.Inlines.Clear();
            AQI.Inlines.Add(new Run() { Text = entity.AQI.ToString(), FontSize = 50 });
            AQI.Inlines.Add(new LineBreak());
            AQI.Inlines.Add(new Run() { Text = entity.TimePoint.ToString("HH:mm更新") });

            Quality.Text = entity.Quality;

            Pm25.Text = entity.Pm25.ToStringValue();
            Pm10.Text = entity.Pm10.ToStringValue();
            SO2.Text = entity.SO2.ToStringValue();
            NO2.Text = entity.No2.ToStringValue();
            #endregion

            //更新监测站数据
            DetailsList.ItemsSource = entityList;
        }

        #region 更新数据
        private void UpdateData()
        {
            //progressBar1.Visibility = System.Windows.Visibility.Visible;
            //得到城市
            string city = "上海";
            if (IsolatedStorageSettings.ApplicationSettings.Contains("City"))
            {
                city = IsolatedStorageSettings.ApplicationSettings["City"] as string;
            }
            WebClient wb = new WebClient();
            //添加下载完成后的处理事件  
            wb.DownloadStringCompleted += wb_DownloadStringCompleted;
            //开始异步下载  
            string urlStr = string.Format("http://pm25.in/api/querys/aqi_details.json?city={0}&token=qExyDEkkCvjSiysDT7Jz", HttpUtility.UrlEncode(city));
            wb.DownloadStringAsync(new Uri(urlStr, UriKind.Absolute));
        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            List<AirModel> entityList = new List<AirModel>();
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.None)
            {
                MessageBox.Show("无法连接网络", "注意", MessageBoxButton.OK);
                return;
            }
            entityList = AnalyzeJson.JsonToEntityList(e.Result);

            UploadUI(entityList);
            AnalyzeJson.Save(e.Result, "MainPage");
            //progressBar1.Visibility = System.Windows.Visibility.Collapsed;
        }
        #endregion

        private void CityButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CitySelect.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}