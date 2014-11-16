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
using MicroMsg.sdk;

namespace Character
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            String strUserName = InputTextBox.Text.Trim();
            if (strUserName == String.Empty && strUserName.Length == 0)
            {
                ResultTextBlock.Text = "请先输入要计算的名字";
                InputTextBox.Text = "";
            }
            else if (InputTextBox.Text == "张凯" || InputTextBox.Text == "方凯" || InputTextBox.Text == "黄涛")
            {
                ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:100" + System.Environment.NewLine + "评价:天啦！您就是传说中的神么！！！！";
                InputTextBox.Text = "";
            }
            else if (InputTextBox.Text == "日本人" || InputTextBox.Text == "小日本" || InputTextBox.Text == "日本" || InputTextBox.Text == "日本鬼子")
            {
                ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:-1" + System.Environment.NewLine + "评价:你的人品竟然负溢出了...我对你无语...";
                InputTextBox.Text = "";
            }
            else
            {
                string name = InputTextBox.Text;
                int sum = 0;
                string str = "";

                foreach (char c in name)
                {
                    str = str + Convert.ToString((int)c);
                }
                for (int i = 0; i < str.Length; i++)
                {
                    sum += str[i++];
                }

                int rp = sum % 100;
                if (rp == 0)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你一定不是人吧？怎么一点人品都没有？！";
                    InputTextBox.Text = "";
                }
                if (rp >= 1 && rp < 5)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:算了,跟你没什么人品好谈的...";
                    InputTextBox.Text = "";
                }
                if (rp >= 5 && rp < 10)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:是我不好...不应该跟你谈人品问题的...";
                    InputTextBox.Text = "";
                }
                if (rp >= 10 && rp < 15)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:杀过人没有?放过火没有?你应该无恶不做吧?";
                    InputTextBox.Text = "";
                }
                if (rp >= 15 && rp < 20)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你貌似应该三岁就偷看隔壁大妈洗澡的吧...";
                    InputTextBox.Text = "";
                }
                if (rp >= 20 && rp < 25)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品之低下实在让人惊讶啊...";
                    InputTextBox.Text = "";
                }
                if (rp >= 25 && rp < 30)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品太差了。你应该有干坏事的嗜好吧?";
                    InputTextBox.Text = "";
                }
                if (rp >= 30 && rp < 35)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品真差!肯定经常做偷鸡摸狗的事...";
                    InputTextBox.Text = "";
                }
                if (rp >= 35 && rp < 40)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你拥有如此差的人品请经常祈求佛祖保佑你吧...";
                    InputTextBox.Text = "";
                }
                if (rp >= 40 && rp < 45)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:老实交待..那些论坛上面经常出现的偷拍照是不是你的杰作?";
                    InputTextBox.Text = "";
                }
                if (rp >= 45 && rp < 50)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你随地大小便之类的事没少干吧?";
                    InputTextBox.Text = "";
                }
                if (rp >= 50 && rp < 55)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品太差了..稍不小心就会去干坏事了吧?";
                    InputTextBox.Text = "";
                }
                if (rp >= 55 && rp < 60)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品很差了..要时刻克制住做坏事的冲动哦..";
                    InputTextBox.Text = "";
                }
                if (rp >= 60 && rp < 65)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品比较差了..要好好的约束自己啊..";
                    InputTextBox.Text = "";
                }
                if (rp >= 65 && rp < 70)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品勉勉强强..要自己好自为之..";
                    InputTextBox.Text = "";
                }
                if (rp >= 70 && rp < 75)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:有你这样的人品算是不错了..";
                    InputTextBox.Text = "";
                }
                if (rp >= 75 && rp < 80)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你有较好的人品..继续保持..";
                    InputTextBox.Text = "";
                }
                if (rp >= 80 && rp < 85)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品不错..应该一表人才吧?";
                    InputTextBox.Text = "";
                }
                if (rp >= 85 && rp < 90)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品真好..做好事应该是你的爱好吧..";
                    InputTextBox.Text = "";
                }
                if (rp >= 90 && rp < 95)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你的人品太好了..你就是当代活雷锋啊...";
                    InputTextBox.Text = "";
                }
                if (rp >= 95 && rp < 100)
                {
                    ResultTextBlock.Text = "姓名:" + InputTextBox.Text + System.Environment.NewLine + "人品得分:" + rp + System.Environment.NewLine + "评价:你是世人的榜样！";
                    InputTextBox.Text = "";
                }
            }
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int scene = SendMessageToWX.Req.WXSceneSession; //发给微信朋友
        //        WXTextMessage message = new WXTextMessage();
        //        message.Title = "文本";
        //        message.Text = "这是一段文本内容";
        //        SendMessageToWX.Req req = new SendMessageToWX.Req(message, scene);
        //        IWXAPI api = WXAPIFactory.CreateWXAPI(AppID);
        //        api.SendReq(req);
        //    }
        //    catch (WXException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}