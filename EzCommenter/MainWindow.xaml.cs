using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WcfInterface;

namespace EzCommenter
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChannelFactory<IWcfInterface> channelFactory;
        private string uri = @"net.tcp://localhost/Textream/tcp";
        private IWcfInterface service;

        public MainWindow()
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IWcfInterface>(new NetTcpBinding());
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            service = channelFactory.CreateChannel(new EndpointAddress(uri));
            service.MakeTextStream(TextBox1.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            channelFactory.Close();
        }
    }
}
