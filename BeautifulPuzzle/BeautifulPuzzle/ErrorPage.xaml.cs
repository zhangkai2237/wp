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

namespace BeautifulPuzzle
{
    public partial class ErrorPage : PhoneApplicationPage
    {
        public string name;
        public ErrorPage()
        {
            InitializeComponent();
        }

        public static Exception Exception;

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ErrorText.Text = Exception.ToString();
            
            PageTitle.Text = name;
        }
    }
}