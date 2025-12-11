using System;
using System.Windows.Forms;

namespace Assignment6Final
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IPersonDataSource data = new PersonContextDataSource();

          

            Application.Run(new Form1(data));
        }
    }
}
