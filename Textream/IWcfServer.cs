using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow; // メインウィンドウを取得
            mainWindow.MakeTextStream(str);
        }


    }
}