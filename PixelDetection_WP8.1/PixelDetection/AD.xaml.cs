using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MSNADSDK.AD;

namespace PixelDetection
{
    public partial class AD : PhoneApplicationPage
    {
        string defaultAppid = "142952";
        string defaultAdId = "147544";
        string defaultIntersitialAdId = "100004";
        string defaultSerectKey = "be7d5defb7f84848937ed6d11a63e8ef";

        public AD()
        {
            InitializeComponent();
            this.LoadAD();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            App.Quit();
        }

        private void LoadAD()
        {
            AdView adView = new AdView();

            adView.Appid = defaultAppid;
            adView.SecretKey = defaultSerectKey;
            adView.SizeForAd = AdSize.Large;
            adView.IsInterstitial = true;
            adView.Adid = defaultIntersitialAdId;

            adView.TelCapability = true;

            adArea.Children.Clear();
            adArea.Children.Add(adView);


            adView.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

            adView.GetInterstitialAd();
        }
    }
}