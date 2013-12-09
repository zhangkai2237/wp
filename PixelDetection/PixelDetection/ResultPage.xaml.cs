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

namespace PixelDetection
{
    public partial class ResultPage : PhoneApplicationPage
    {
        public ResultPage()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPoint primaryTouchPoint = e.GetPrimaryTouchPoint(null);
            if (primaryTouchPoint != null && primaryTouchPoint.Action == TouchAction.Down)
            {
                //Touch.FrameReported -= new TouchFrameEventHandler(Touch_FrameReported);
                App.Quit();
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Touch.FrameReported -= new TouchFrameEventHandler(Touch_FrameReported);
        }
    }
}