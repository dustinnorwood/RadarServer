using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections.Generic;

// State object for receiving data from remote device.
namespace RadarPlot
{
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 8192;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        // Thread signal.
        public event EventHandler RadarConnected, RadarDisconnected;
        public event SocketDataReceivedEvent ScanReceived, StatusInfoReceived, SetConfigReceived, GetConfigReceived; //SocketDataReceivedEvent is defined in RadarHelper.cs
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public volatile bool QuitIt = false;
        public AsynchronousSocketListener()
        {
        }

        public IPEndPoint GetEndPoint()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            return new IPEndPoint(ipAddress, 11000);
        }

        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (!QuitIt)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }

            }
            catch (Exception)
            {
            }


        }

        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket; 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));
                    content = state.sb.ToString();
                    if (content.IndexOf("RADAR") > -1) //If client connection is a radar, parse the radar's name
                    {
                        string[] param = content.Split(',');
                        string name = param[1];
                        int x, y;
                        if (!int.TryParse(param[2], out x)) x = 0;
                        if (!int.TryParse(param[3], out y)) y = 0;
                        Radar sock = new Radar(handler, name, x, y);
                        sock.Disconnected += radar_Disconnected;
                        sock.DataReceived += radar_DataReceived;
                        OnRadarConnected(sock);
                    }
                }
            }
            catch(SocketException)
            { 

            }
        }

        protected void OnRadarConnected(object sender)
        {
            if(RadarConnected != null)
            {
                EventArgs e = new EventArgs();
                this.RadarConnected(sender, e);
            }
        }

        protected void OnRadarDisconnected(object sender)
        {
            if (RadarDisconnected != null)
            {
                EventArgs e = new EventArgs();
                this.RadarDisconnected(sender, e);
            }
        }

        private void radar_DataReceived(object sender, string data)
        {
            byte[] b = Encoding.Default.GetBytes(data);
            switch ((b[4] << 8) + b[5])
            {
                case 0xF101:
                    {
                        if (this.StatusInfoReceived != null)
                            this.StatusInfoReceived(sender, data);
                    }
                    break;
                case 0x1101:
                    {
                        if (this.SetConfigReceived != null)
                            this.SetConfigReceived(sender, data);
                    }
                    break;
                case 0x1102:
                    {
                        byte[] d = Encoding.Default.GetBytes(data);
                        if (this.GetConfigReceived != null)
                            this.GetConfigReceived(sender, data);
                    }
                    break;
                case 0xF201:
                    {
                        if(this.ScanReceived != null)
                        {
                            this.ScanReceived(sender, data);
                        }
                    }
                    break;
            }
        }

        private void radar_Disconnected(object sender)
        {
            OnRadarDisconnected(sender);
        }
    }
}