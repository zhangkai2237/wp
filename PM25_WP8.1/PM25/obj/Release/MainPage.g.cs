﻿#pragma checksum "F:\CodeManage\GitHub\WP\PM25_WP8.1\PM25\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1D1C794831B45DFFB30D59B3FD6F4466"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PM25 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Area;
        
        internal System.Windows.Controls.TextBlock AQI;
        
        internal System.Windows.Controls.TextBlock Quality;
        
        internal System.Windows.Controls.TextBlock Pm25;
        
        internal System.Windows.Controls.TextBlock Pm10;
        
        internal System.Windows.Controls.TextBlock SO2;
        
        internal System.Windows.Controls.TextBlock NO2;
        
        internal System.Windows.Controls.ListBox DetailsList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PM25;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Area = ((System.Windows.Controls.TextBlock)(this.FindName("Area")));
            this.AQI = ((System.Windows.Controls.TextBlock)(this.FindName("AQI")));
            this.Quality = ((System.Windows.Controls.TextBlock)(this.FindName("Quality")));
            this.Pm25 = ((System.Windows.Controls.TextBlock)(this.FindName("Pm25")));
            this.Pm10 = ((System.Windows.Controls.TextBlock)(this.FindName("Pm10")));
            this.SO2 = ((System.Windows.Controls.TextBlock)(this.FindName("SO2")));
            this.NO2 = ((System.Windows.Controls.TextBlock)(this.FindName("NO2")));
            this.DetailsList = ((System.Windows.Controls.ListBox)(this.FindName("DetailsList")));
        }
    }
}

