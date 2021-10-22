using System;
using System.Drawing;
using System.Threading.Tasks;

namespace UdpServerService
{
    class Program
    {
        static Graphics canva = Graphics.FromImage(new Bitmap(1024, 1024));

        static void Main(string[] args)
        {
            UdpExtensions.UdpServer.ReceiveMessages(ref canva);

        }
    }
}
