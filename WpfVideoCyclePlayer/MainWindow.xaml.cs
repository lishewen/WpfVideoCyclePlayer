using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfVideoCyclePlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 定时器方式
        //DispatcherTimer timer = new DispatcherTimer();  // 定时器timer
        //int durTime = 5;  // 视频播放时长，也就是循环周期

        //// 窗口加载事件
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    mediaElement.Source = new Uri("D:/bird.mp4"); // 绑定视频文件

        //    mediaElement.Play(); // 设置启动播放
        //    timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
        //    timer.Tick += new EventHandler(timerEvent);  // 设置定时器事件

        //    timer.Start();  // 启动定时器
        //}

        //// 定时器事件 
        //public void timerEvent(object sender, EventArgs e)
        //{
        //    // MediaElement需要先停止播放才能再开始播放，
        //    // 否则会停在最后一帧不动
        //    mediaElement.Stop();
        //    mediaElement.Play();
        //}

        ///*
        //    播放控制按钮的点击事件 
        //*/
        //private void btnPlay_Click(object sender, RoutedEventArgs e)
        //{
        //    mediaElement.Play();  // 开始播放
        //    timer.Start();  // 重新启动定时器
        //}

        //private void btnPause_Click(object sender, RoutedEventArgs e)
        //{
        //    mediaElement.Pause(); // 暂停当前播放
        //    timer.Stop();  // 停止定时器
        //}

        //private void btnStop_Click(object sender, RoutedEventArgs e)
        //{
        //    mediaElement.Stop(); // 停止当前播放
        //    timer.Stop();  // 停止定时器
        //}
        #endregion

        #region MediaElement.MediaEnd事件方式
        // 窗口加载事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 绑定视频文件
            mediaElement.Source = new Uri("D:/Test.mp4");

            // 交互式控制
            mediaElement.LoadedBehavior = MediaState.Manual;

            // 添加元素加载完成事件 -- 自动开始播放
            mediaElement.Loaded += new RoutedEventHandler(media_Loaded);

            // 添加媒体播放结束事件 -- 重新播放
            mediaElement.MediaEnded += new RoutedEventHandler(media_MediaEnded);

            // 添加元素卸载完成事件 -- 停止播放
            mediaElement.Unloaded += new RoutedEventHandler(media_Unloaded);
        }

        /*
            元素事件 
        */
        private void media_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Play();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            // MediaElement需要先停止播放才能再开始播放，
            // 否则会停在最后一帧不动
            (sender as MediaElement).Stop();
            (sender as MediaElement).Play();
        }

        private void media_Unloaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
        }

        /*
            播放控制按钮的点击事件 
        */
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }
        #endregion
    }
}
