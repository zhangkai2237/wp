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

namespace PixelDetection
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            //Touch.FrameReported +=new TouchFrameEventHandler(Touch_FrameReported);
        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs args)
        {
            TouchPoint primaryTouchPoint = args.GetPrimaryTouchPoint(null);
            if (primaryTouchPoint != null && primaryTouchPoint.Action == TouchAction.Down)
            {
                //Touch.FrameReported -= new TouchFrameEventHandler(Touch_FrameReported);
                NavigationService.Navigate(new Uri("/RedPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Touch.FrameReported -= new TouchFrameEventHandler(Touch_FrameReported);
        }
    }
}