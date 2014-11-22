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

namespace IPQuery
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void IPButton_Click(object sender, RoutedEventArgs e)
        {
            IPService2.IpAddressSearchWebServiceSoapClient ip = new IPService2.IpAddressSearchWebServiceSoapClient();
            ip.getCountryCityByIpCompleted += new EventHandler<IPService2.getCountryCityByIpCompletedEventArgs>(ip_getCountryCityByIpCompleted);
            ip.getCountryCityByIpAsync(IPTextBox.Text);
        }

        void ip_getCountryCityByIpCompleted(object sender, IPService2.getCountryCityByIpCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IPTextBlock.Text = e.Result[0] + ":" + e.Result[1];
            }
        }
    }
}