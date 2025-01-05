using System;
using System.Windows.Forms;
using ndp_odev;
using NdpOdev;

namespace zümdyCrush
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new AnaForm());
            Application.Run(new MenuForm()); //önce menü form çalıştırılır sonra memü formda isim girilince anaform çalışır
        }
    }
}
