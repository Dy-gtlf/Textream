using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Textream
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void AddIPAdressList()
        {
            var nis = NetworkInterface.GetAllNetworkInterfaces(); //すべてのネットワークインターフェイスを取得する
            foreach (var ni in nis)
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel) //ネットワーク接続しているか調べる
                {
                    IPAdressList.Content += ni.Name + "\n"; //ネットワークインターフェイスの情報を表示する
                    var ipips = ni.GetIPProperties(); //構成情報、アドレス情報を取得する
                    if (ipips != null)
                    {
                        foreach (var ip in ipips.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4のみ
                            {
                                IPAdressList.Content += ip.Address + "\n";
                            }
                        }
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddIPAdressList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow; // メインウィンドウを取得
            // エンドポイントの設定を行う
        }
    }
}
