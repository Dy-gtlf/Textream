using System.Windows;
using WcfInterface;

namespace Textream
{
    public class IWcfServer : IWcfInterface
    {
        /// <summary>
        /// 受け取った文字列を画面上に流します。
        /// </summary>
        public void MakeTextStream(string str)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow; // メインウィンドウを取得
            mainWindow.MakeTextStream(str);
        }


    }
}