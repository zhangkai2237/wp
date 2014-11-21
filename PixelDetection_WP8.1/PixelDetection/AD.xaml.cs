using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GoogleAds;

namespace PixelDetection
{
    public partial class AD : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;

        public AD()
        {
            InitializeComponent();

            interstitialAd = new InterstitialAd("ca-app-pub-7694238510187885/4090565797");
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.LoadAd(adRequest);
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            App.Quit();
        }
    }
}