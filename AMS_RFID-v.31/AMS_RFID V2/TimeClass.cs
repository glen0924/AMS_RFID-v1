using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AMS_RFID_V2
{
	
	class TimeClass
	{
		private static readonly string[] NtpServers = { "pool.ntp.org", "time.google.com" };
		private const int Timeout = 3000;

        public static DateTime? GetInternetTime()
        {
            foreach (string server in NtpServers)
            {
                try
                {
                    using (var client = new UdpClient(server, 123))
                    {
                        client.Client.ReceiveTimeout = Timeout;
                        client.Connect(server, 123);
                        byte[] data = new byte[48];
                        data[0] = 0x1B;
                        client.Send(data, data.Length);
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] buffer = client.Receive(ref endPoint);
                        if (buffer.Length >= 43)
                        {
                            ulong intpart = (ulong)buffer[40] << 24 | (ulong)buffer[41] << 16 | (ulong)buffer[42] << 8 | buffer[43];
                            ulong fractpart = (ulong)buffer[44] << 24 | (ulong)buffer[45] << 16 | (ulong)buffer[46] << 8 | buffer[47];
                            ulong milliseconds = (intpart * 1000) + ((fractpart * 1000) / 0x100000000L);
                            DateTime dateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(milliseconds);
                            return dateTime.ToLocalTime();
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return null;
        }
    }
}
