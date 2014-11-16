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

namespace CommonQueries
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 将 listbox 控件的数据上下文设置为示例数据
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // 为 ViewModel 项加载数据
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void PhoneNumButton_Click(object sender, RoutedEventArgs e)
        {
            //检查输入数据的有效性
            string phone = PhoneNumTextBox.Text;
            if (phone.Length != 11)
            {
                PhoneNumTextBlock.Text = "请输入有效的11位手机号码！";
            }

            else
            {
                PhoneNumService.MobileCodeWSSoapClient phoneNum = new PhoneNumService.MobileCodeWSSoapClient();
                phoneNum.getMobileCodeInfoCompleted += new EventHandler<PhoneNumService.getMobileCodeInfoCompletedEventArgs>(phoneNum_getMobileCodeInfoCompleted);
                phoneNum.getMobileCodeInfoAsync(phone, "");
            }
        }

        void phoneNum_getMobileCodeInfoCompleted(object sender, PhoneNumService.getMobileCodeInfoCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PhoneNumTextBlock.Text = e.Result;
            }
        }

        private void IPButton_Click(object sender, RoutedEventArgs e)
        {
            IPService.IpAddressSearchWebServiceSoapClient ip = new IPService.IpAddressSearchWebServiceSoapClient();
            ip.getCountryCityByIpCompleted += new EventHandler<IPService.getCountryCityByIpCompletedEventArgs>(ip_getCountryCityByIpCompleted);
            ip.getCountryCityByIpAsync(IPTextBox.Text);
        }

        void ip_getCountryCityByIpCompleted(object sender, IPService.getCountryCityByIpCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IPTextBlock.Text = e.Result[0] + ":" + e.Result[1];
            }
        }
    }
}