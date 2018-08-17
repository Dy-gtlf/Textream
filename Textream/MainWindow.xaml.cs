using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using WcfInterface;

namespace Textream
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost serviceHost;
        private string baseAddress = @"net.tcp://localhost/Textream";
        private string endPointAddress = "tcp";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskTrayIcon.Icon = Properties.Resources.Icon; // タスクトレイのアイコンを設定

            serviceHost = new ServiceHost(typeof(IWcfServer), new Uri(baseAddress));
            serviceHost.AddServiceEndpoint(typeof(IWcfInterface), new NetTcpBinding(), endPointAddress);
            serviceHost.Open(); // WCFサービスの開始

            var settingWindow = new SettingWindow();
            settingWindow.ShowDialog(); // 設定画面を開く
        }

        /// <summary>
        /// テキストブロックの生成
        /// </summary>
        public void MakeTextStream(string str)
        {
            var textBlock = new TextBlock
            {
                Text = str,
                Opacity = 0,
                FontSize = 30,
                TextWrapping = TextWrapping.NoWrap,
                Foreground = new SolidColorBrush(Colors.White),
                Background = new SolidColorBrush(Colors.Transparent),
                Effect = new DropShadowEffect
                {
                    ShadowDepth = 3,
                    Opacity = 1,
                    BlurRadius = 0
                }
            };
            Root.Children.Add(textBlock); // Canvasに追加
            Dispatcher.BeginInvoke(new Action(() => 
            {
                MoveText(textBlock); // 描写が終わってからアニメーション
            }), DispatcherPriority.Loaded);
        }

        /// <summary>
        /// 文字列のアニメーション
        /// </summary>
        private void MoveText(TextBlock textBlock)
        {
            var random = new Random();
            Canvas.SetTop(textBlock, random.Next((int)textBlock.ActualHeight, (int)(Height * 0.9))); // タスクバーを隠さないランダムな高さに出現
            var time = random.Next(9000, 13000); // ランダムな時間の間流れる
            var animation = new DoubleAnimation // 右画面外から左画面外へのアニメーション
            {
                From = Width,
                To = -1 * textBlock.ActualWidth - 10,
                Duration = TimeSpan.FromMilliseconds(time)
            };
            var deleteTimer = new DispatcherTimer(DispatcherPriority.SystemIdle) // 流れたら削除する
            {
                Interval = TimeSpan.FromMilliseconds(time),
            };
            deleteTimer.Tick += (s, e) =>
            {
                deleteTimer.Stop();
                Root.Children.Remove(textBlock);
            };
            textBlock.BeginAnimation(LeftProperty, animation); // そぉぃ
            deleteTimer.Start();
            textBlock.Opacity = 100;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            serviceHost.Close(); // WCFサービスの終了
        }

        private void OpenSettingWindow(object sender, EventArgs e)
        {
            var settingWindow = new SettingWindow(); 
            settingWindow.ShowDialog(); // 設定画面を開く
        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
