using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Xdgk.Communi.UITest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            NUnit.Core.InternalTrace.Initialize("nnn.log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
