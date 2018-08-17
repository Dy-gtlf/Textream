using System;
using System.ServiceModel;
using System.Windows;
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
