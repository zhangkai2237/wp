﻿#pragma checksum "F:\CodeManage\GitHub\wp\BeautifulPuzzleWP8\BeautifulPuzzle\PuzzlePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "248A75D594B8B8CBB9071315D3CEA52D"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18051
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AdDuplex;
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


namespace BeautifulPuzzle {
    
    
    public partial class PuzzlePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard WinTransition;
        
        internal System.Windows.Media.Animation.Storyboard ResetWinTransition;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button SolveButton;
        
        internal System.Windows.Controls.StackPanel StatusPanel;
        
        internal System.Windows.Controls.TextBlock TotalMovesTextBlock;
        
        internal System.Windows.Controls.Border CongratsBorder;
        
        internal System.Windows.Controls.Border border;
        
        internal System.Windows.Controls.Image PreviewImage;
        
        internal System.Windows.Controls.Canvas GameContainer;
        
        internal System.Windows.Controls.TextBlock TapToContinueTextBlock;
        
        internal AdDuplex.AdControl adDuplexAd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/BeautifulPuzzle;component/PuzzlePage.xaml", System.UriKind.Relative));
            this.WinTransition = ((System.Windows.Media.Animation.Storyboard)(this.FindName("WinTransition")));
            this.ResetWinTransition = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ResetWinTransition")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.SolveButton = ((System.Windows.Controls.Button)(this.FindName("SolveButton")));
            this.StatusPanel = ((System.Windows.Controls.StackPanel)(this.FindName("StatusPanel")));
            this.TotalMovesTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("TotalMovesTextBlock")));
            this.CongratsBorder = ((System.Windows.Controls.Border)(this.FindName("CongratsBorder")));
            this.border = ((System.Windows.Controls.Border)(this.FindName("border")));
            this.PreviewImage = ((System.Windows.Controls.Image)(this.FindName("PreviewImage")));
            this.GameContainer = ((System.Windows.Controls.Canvas)(this.FindName("GameContainer")));
            this.TapToContinueTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("TapToContinueTextBlock")));
            this.adDuplexAd = ((AdDuplex.AdControl)(this.FindName("adDuplexAd")));
        }
    }
}

