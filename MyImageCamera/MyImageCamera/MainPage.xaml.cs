using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyImageCamera.Resources;
using Microsoft.Phone.Tasks;

namespace MyImageCamera
{
    public partial class MainPage : PhoneApplicationPage
    {
        CameraCaptureTask _cameraCaptureTask;
        PhotoChooserTask _photoChooserTask;

        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            _cameraCaptureTask = new CameraCaptureTask();
            _cameraCaptureTask.Completed += cameraCaptureTask_Completed;

            _photoChooserTask = new PhotoChooserTask();
            _photoChooserTask.Completed += _photoChooserTask_Completed;



            // 用于本地化 ApplicationBar 的示例代码
            BuildLocalizedApplicationBar();
        }



        // 用于生成本地化 ApplicationBar 的示例代码
        private void BuildLocalizedApplicationBar()
        {
            // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
            ApplicationBar = new ApplicationBar();

            // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
            ApplicationBarIconButton capturePhotoButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/capture-button-icon.png", UriKind.Relative));
            capturePhotoButton.Text = AppResources.CapturePhotoButtonText;
            capturePhotoButton.Click += capturePhotoButton_Click;
            ApplicationBar.Buttons.Add(capturePhotoButton);

            ApplicationBarIconButton openFileButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/folder-button-icon.png", UriKind.Relative));
            openFileButton.Text = AppResources.OpenFileButtonText;
            openFileButton.Click += openFileButton_Click;
            ApplicationBar.Buttons.Add(openFileButton);

            //// 使用 AppResources 中的本地化字符串创建新菜单项。
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        void capturePhotoButton_Click(object sender, EventArgs e)
        {
            _cameraCaptureTask.Show();
        }

        void openFileButton_Click(object sender, EventArgs e)
        {
            _photoChooserTask.Show();
        }

        void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                ImageDataContext imageDataContext = ImageDataContext.Singleton;

                imageDataContext.CreateStreams();
                e.ChosenPhoto.Position = 0;
                e.ChosenPhoto.CopyTo(imageDataContext.ImageStream);

                NavigationService.Navigate(new Uri("/ImagePage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("照片打开失败！");
            }
        }

        void _photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                ImageDataContext imageDataContext = ImageDataContext.Singleton;

                imageDataContext.CreateStreams();
                e.ChosenPhoto.Position = 0;
                e.ChosenPhoto.CopyTo(imageDataContext.ImageStream);

                NavigationService.Navigate(new Uri("/ImagePage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("照片读取失败！");
            }
        }


    }
}