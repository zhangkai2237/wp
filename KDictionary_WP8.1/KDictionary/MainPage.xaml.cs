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

using System.Data;

namespace KDictionary
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void TransButton_Click(object sender, RoutedEventArgs e)
        {
            string wordKey = WordTextBox.Text.Trim();
            if (wordKey.Length == 0)
            {
                MessageBox.Show("请输入要翻译的内容！");
            }
            else
            {
                DictionaryService.EnglishChineseSoapClient dictionary = new DictionaryService.EnglishChineseSoapClient();
                dictionary.TranslatorStringCompleted += new EventHandler<DictionaryService.TranslatorStringCompletedEventArgs>(dictionary_TranslatorStringCompleted);
                dictionary.TranslatorStringAsync(wordKey);
            }
        }

        void dictionary_TranslatorStringCompleted(object sender, DictionaryService.TranslatorStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] myValue = e.Result;
                if (myValue[3] != "WordKey Empty" && myValue[3] != "Not Found" && myValue[3] != "Error" && myValue[3] != "Not Data")
                {
                    string result = myValue[1] + "\n" + myValue[3];
                    ResultTextBlock.Text = result;
                }
                else
                {
                    string result = "额,这个单词不认识...^_^...";
                    ResultTextBlock.Text = result;
                }
            }
        }
    }
}