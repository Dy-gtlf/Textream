using System.Windows;
using WcfWebInterface;

namespace Textream
{
    public class IWcfWebServer : IWcfWebInterface
    {
        public void MakeTextStream(string str)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow; // メインウィンドウを取得
            mainWindow.MakeTextStream(str);
        }
    }
}
