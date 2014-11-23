using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO;
using Nokia.Graphics.Imaging;
using MyImageCamera.Resources;
using Windows.Storage.Streams;
using Microsoft.Xna.Framework.Media;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MyImageCamera
{
    public partial class ImagePage : PhoneApplicationPage
    {
        private const String FileNamePrefix = "FilterEffects_";
        ImageDataContext _imageDataContext = ImageDataContext.Singleton;
        public ImagePage()
        {
            InitializeComponent();

            this.BuildLocalizedApplicationBar();

            LstPreview.ItemsSource = FilterItem.FilterSource;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Stream imageSource = _imageDataContext.ImageStream;
            imageSource.Seek(0, SeekOrigin.Begin);

            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(imageSource);
            PhotoSample.Source = bmp;

            base.OnNavigatedTo(e);
        }

        private async void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image image = sender as Image;

            // 读取根目录下的示例图片 
            Stream _imageSource = App.GetResourceStream(new Uri("Sample.jpg", UriKind.Relative)).Stream;
            _imageSource.Seek(0, SeekOrigin.Begin);

            // 获取当前 Item 的 DataContext
            FilterItem item = image.DataContext as FilterItem;

            WriteableBitmap writeableBitmap = new WriteableBitmap(100, 100);

            // 为示例图片添加相应的滤镜效果
            using (var source = new StreamImageSource(_imageSource))
            using (var filterEffect = new FilterEffect(source) { Filters = FilterItem.CreateInstance(item.Index).ToArray() })
            using (var renderer = new WriteableBitmapRenderer(filterEffect, writeableBitmap))
            {
                await renderer.RenderAsync();
            }

            // 显示到页面中
            image.Source = writeableBitmap;
        }

        private async void RefreshImage()
        {
            Stream imageSource = _imageDataContext.ImageStream;
            imageSource.Seek(0, SeekOrigin.Begin);

            // 获取当前 Item 的 DataContext
            FilterItem item = FilterItem.CurrentFilterItem;

            // 为示例图片添加相应的滤镜效果
            using (var source = new StreamImageSource(imageSource))
            using (var filterEffect = new FilterEffect(source) { Filters = FilterItem.CreateInstance(item.Index).ToArray() })
            using (var renderer = new JpegRenderer(filterEffect))
            {
                Windows.Storage.Streams.IBuffer buf = await renderer.RenderAsync();

                Stream stream = System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeBufferExtensions.AsStream(buf);
                BitmapImage bi = new BitmapImage();
                bi.SetSource(stream);
                PhotoSample.Source = bi;
            }

            // 显示到页面中
            
        }

        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FilterItem.CurrentFilterItem = (sender as Border).DataContext as FilterItem;
            RefreshImage();
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        private void BuildLocalizedApplicationBar()
        {
            // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
            ApplicationBar = new ApplicationBar();

            // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
            ApplicationBarIconButton saveButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save-button-icon.png", UriKind.Relative));
            saveButton.Text = AppResources.SaveButtonText;
            saveButton.Click += saveButton_Click;
            ApplicationBar.Buttons.Add(saveButton);

            //// 使用 AppResources 中的本地化字符串创建新菜单项。
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterItem item = FilterItem.CurrentFilterItem;

                IBuffer buffer = await RenderJpegAsync(
                    _imageDataContext.ImageStream.GetWindowsRuntimeBuffer());

                using (MediaLibrary library = new MediaLibrary())
                {
                    library.SavePictureToCameraRoll(FileNamePrefix
                        + DateTime.Now.ToString() + ".jpg", buffer.AsStream());
                }
            }
            catch
            {
                MessageBox.Show("图片保存失败！");
                return;
            }
            MessageBox.Show("图片保存成功！");
        }

        private async Task<IBuffer> RenderJpegAsync(IBuffer buffer)
        {
            Stream _imageSource = _imageDataContext.ImageStream;
            _imageSource.Seek(0, SeekOrigin.Begin);

            // 获取当前 Item 的 DataContext
            FilterItem item = FilterItem.CurrentFilterItem;
            using (var streamSource = new StreamImageSource(_imageSource))
            using (var filterEffect = new FilterEffect(streamSource) { Filters = FilterItem.CreateInstance(item.Index).ToArray() })

            using (BufferImageSource source = new BufferImageSource(buffer))
            using (JpegRenderer renderer = new JpegRenderer(filterEffect))
            {
                return await renderer.RenderAsync();
            }
        }
    }
}