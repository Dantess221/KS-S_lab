using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpServerService.UdpExtensions
{
    class UdpServer
    {
        private static int Port => 8005;

        public static Task ReceiveMessages(ref Graphics canva)
        {
            UdpClient receiver = new UdpClient(Port);
            IPEndPoint remoteIp = null;

            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    SendMessage(remoteIp,new byte[1] { 1 });
                    try
                    {
                        Console.WriteLine(Bitmap_Extensions.Converters.ConvertFromBytes.Convert(ref canva, data));

                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SendMessage(remoteIp, new byte[1] { 0 });
            }
            finally
            {
                receiver.Close();
            }
            return Task.CompletedTask;
        }

        public static void SendMessage(IPEndPoint remoteIp, byte[] data)
        {
            UdpClient sender = new UdpClient();
            try
            {
                sender.Send(data, data.Length, remoteIp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }
    }
}
