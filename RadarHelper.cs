using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace RadarPlot
{
    public class Point
    {
        public int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }




    public delegate void SocketDisconnectEvent(object sender);
    public delegate void SocketDataReceivedEvent(object sender, string data);

    public class Radar
    {
        public Socket _handler;
        public event SocketDisconnectEvent Disconnected;
        public event SocketDataReceivedEvent DataReceived;

        private Object thisLock = new Object();
        public List<MRM_SCAN_INFO> Scans; //List of Radar Scan Info Arrays
        public MRM_SCAN_INFO CurrentScan;
        public MRM_SCAN_INFO[] UnfilteredScans;
        public double[] FilterCoeffs = new double[4] { 1.0, -0.6, -0.3, -0.1 }; //For motion filtering
        public Point Location;
        public double Offset;
        public string Name;

        public Radar(Socket h, string name, int x, int y)
        {
            Location = new Point(x, y);
            Name = name;
            Offset = 0.0;
            Scans = new List<MRM_SCAN_INFO>();
            CurrentScan = new MRM_SCAN_INFO();
            UnfilteredScans = new MRM_SCAN_INFO[FilterCoeffs.Length];
            _handler = h;
            MRM_GET_STATUSINFO_REQUEST t = new MRM_GET_STATUSINFO_REQUEST();
            t.MessageID = 0;
            if(_handler != null)
            RadarRequest.SendMRM_GET_STATUSINFO_REQUEST(this, t);
        }

        public bool Receive()
        {
            if (_handler.Connected)
            {
                StateObject state = new StateObject();
                state.workSocket = _handler;
                _handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                return true;
            }
            else return false;
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Clear();
                    state.sb.Append(Encoding.Default.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    {
                        if (content.IndexOf("<STOP>") > -1)
                        {
                            if (this.Disconnected != null)
                                this.Disconnected(this);
                            return;
                        }
                        // Not all data received. Get more.
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);

                        if (DataReceived != null)
                            DataReceived(this, content);
                    }
                }
            }
            catch (SocketException)
            {
                if (this.Disconnected != null)
                    this.Disconnected(this);
            }
        }

        public bool Send(byte[] byteData)
        {
            // Convert the string data to byte data using ASCII encoding.
            if (_handler != null && _handler.Connected)
            {

                // Begin sending the data to the remote device.
                _handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), _handler);
                return true;
            }
            else return false;
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

                Receive();

            }
            catch (Exception)
            {
            }
        }

        public override string ToString()
        {
            return Name + ':' + Location.X.ToString() + '-' + Location.Y.ToString();
        }
    }
}
