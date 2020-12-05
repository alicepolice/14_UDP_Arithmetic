using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace 栈
{
    class Communication
    {
        private UdpClient udpClient;
        private IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
        private Calculate math = new Calculate();
        private byte[] get = new byte[1024];
        private byte[] send = new byte[1024];
        public Communication()
        {
            udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(GetlocalIp()), 7788));
            Thread t = new Thread(Receive);
            t.Start();
        }

        private void Receive()
        {
            while (true)
            {
                get = udpClient.Receive(ref point);
                string message = Encoding.UTF8.GetString(get);
                Console.WriteLine("接收到的数据"+message);
                mathing(message);
                udpClient.Send(send, send.Length, point);
            }
        }

        private void mathing(string message)
        {
            math.Formula = message;
            string i = math.GetTrans + "^" +math.GetResult();
            Console.WriteLine("准备发送的数据" +i + "\n");
            send = Encoding.UTF8.GetBytes(i);
        }

    private string GetlocalIp()
        {
            string AddressIP = String.Empty;
            foreach (IPAddress _IPAdddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAdddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAdddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}
