#define DOUBLE
#define KEVINFILTER
#define PEAKDETECTION
//#define INTEGRAL
//#define DB
//#define MOTION
//#define THRESHOLD
#define TIMER
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RadarPlot
{
    public delegate void UIUpdater();
	public partial class Form1 : Form
	{
        private RadarGraph radarGraph;
        private AsynchronousSocketListener _async;
        public List<Radar> Radars;
        private System.Threading.Timer _scanTimer;

        private Bitmap fullBit; //Large Bitmap containing combined data from all four radars, and 4 smaller bitmaps for each radar
        private int BITROWS = 300; //Height of large bitmap
        private int BITCOLS = 300; //Width of large bitmap
        private int XDIM, YDIM;
        //private double MAXSTRENGTH = 32768;//1.84467440e19; //Max Strength of Radar Scans (tentative)
        private int scanIndex;
        private int animationInterval = 500;
        private int filtering = 0;
        private int GAUSSIANLENGTH = 51;
        private double gamma = 2.0;
#if DOUBLE
        private double GAUSSIANSUM = 0;
        private double[] GaussianKernel;
#else 
        private uint GAUSSIANSUM = 0;
        private uint[] GaussianKernel;
#endif
		public Form1()
		{
            Radars = new List<Radar>();

            XDIM = Properties.Settings.Default.Xdim;
            YDIM = Properties.Settings.Default.Ydim;
            scanIndex = 0;
#if DOUBLE
            GaussianKernel = new double[GAUSSIANLENGTH];
#else
            GaussianKernel = new uint[GAUSSIANLENGTH];
#endif
			InitializeComponent();
            GAUSSIANSUM = Filter.GenerateKernel(GaussianKernel, GAUSSIANLENGTH, SigmaBar.Value);

            fullBit = GuiUtil.GenerateBitmap(300, XDIM, YDIM);
            BITCOLS = fullBit.Width;
            BITROWS = fullBit.Height;

            radarGraph = new RadarGraph();
            _async = new AsynchronousSocketListener();
            _async.ScanReceived += async_ScanReceived;
            _async.SetConfigReceived += async_SetConfigReceived;
            _async.GetConfigReceived += async_GetConfigReceived;
            _async.RadarConnected += async_RadarConnected;
            _async.RadarDisconnected += async_RadarDisconnected;
            Thread t = new Thread(new ThreadStart(_async.StartListening));
            t.Start();
            IPEndPoint ipe = _async.GetEndPoint();
            label3.Text = ipe.Address.ToString();
            label4.Text = ipe.Port.ToString();
            RadarXBox.Text = XDIM.ToString();
            RadarYBox.Text = YDIM.ToString();
            _scanTimer = new System.Threading.Timer(new TimerCallback(ScanTimer_Tick), null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }

        private void RunAnimation()
        {
            GraphParams gp = new GraphParams(XDIM, YDIM, BITCOLS, BITROWS, filtering, gamma, dBBox.Checked, MultiplyBox.Checked, ColorBox.Checked);
            if (GuiUtil.DrawGraph(ref fullBit, Radars, GaussianKernel, gp))
            {
                Graphics g = this.tabPage1.CreateGraphics();
                double ratio = (double)BITCOLS / (double)BITROWS;
                g.DrawImage(fullBit, 5, 30, (ratio > 1.0 ? 300 : (int)(300 * ratio)), (ratio > 1.0 ? (int)(300 / ratio) : 300));
                g.Dispose();
            }
        }

        private void LoadCSV(Radar r, string path)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(path);
                this.Cursor = Cursors.WaitCursor;
                RadarButton.Text = path.Substring(path.LastIndexOf('\\') + 1);
                Utility.ReadDataFromFile(sr, r);
                sr.Close();
                this.Cursor = Cursors.Default;
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Could not open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RadarButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (RadarButton.ClientRectangle.Contains(e.Location))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!RadarBox.Checked)
                    {
                        RadarLoad.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
                        if (RadarComboBox.SelectedItem != null && RadarLoad.ShowDialog() == DialogResult.OK)
                        {
                            LoadCSV((Radar)RadarComboBox.SelectedItem, RadarLoad.FileName);
                        }
                    }
                }
                else
                {
                    if (!RadarBox.Checked)
                    {
                        ((Radar)RadarComboBox.SelectedItem).Scans.Clear();
                        RadarButton.Text = "Select...";
                    }
                }
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
#if TIMER
            DrawTimer.Interval = animationInterval;
            DrawTimer.Enabled = !DrawTimer.Enabled;
            if (DrawTimer.Enabled)
            {
                Run.Text = "Stop";
                if (RadarBox.Checked)
                {
                    uint a;
                    if (!uint.TryParse(IntervalBox.Text, out a)) a = 100000;
                    Utility.StartScanning(Radars,a);
                    Utility.StartLogging(Radars);
                }
                else
                {
                 _scanTimer = new System.Threading.Timer(new TimerCallback(ScanTimer_Tick), null, 100, 100);
                   _scanTimer.Change(100,100);
                }
                //if (!radarGraph.IsDisposed)
                //    radarGraph.Dispose();
                //radarGraph = new RadarGraph();
                //radarGraph.Show();
            }
            else
            {
                Run.Text = "Run";
                if (RadarBox.Checked)
                {
                    Utility.StopScanning(Radars);
                    Utility.StopLogging(Radars);
                }
                else
                {
                    _scanTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                }
                //radarGraph.Hide();
                //radarGraph.Dispose();
            }
            scanIndex = 0;
#else
            scanIndex = 0;
            DrawGraph();
#endif
        }

        private void ScanTimer_Tick(object sender)
        {
            if (!RadarBox.Checked)
            {
                scanIndex++;
                foreach (Radar r in Radars)
                {
                    if (!RadarBox.Checked && r.Scans != null && scanIndex < r.Scans.Count)
                    {
                        r.CurrentScan = r.Scans[scanIndex];
                    }
                }
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            RunAnimation();
            DrawTimer.Interval = animationInterval;
        }

        private void AnimationSpeed_ValueChanged(object sender, EventArgs e)
        {
            animationInterval = AnimationSpeed.Value;
            AnimationLabel.Text = "Animation: " + animationInterval.ToString() + " ms";
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            filtering = (filtering + 1) % 4;
            switch(filtering)
            {
                case 1: FilterButton.Text = "Filtering: Pre";
                    break;
                case 2: FilterButton.Text = "Filtering: Post";
                    break;
                case 3: FilterButton.Text = "Filtering: Both";
                    break;
                default: FilterButton.Text = "Filtering: Off";
                    break;
            }
        }

        private void RadarBox_CheckedChanged(object sender, EventArgs e)
        {
            if(RadarBox.Checked)
            {
                RadarButton.Text = "Not Connected";
                foreach (Radar r in Radars)
                    r.Scans.Clear();
            }
            else
            {
                RadarButton.Text = "Select...";                 
            }
        }

        private void SigmaBar_ValueChanged(object sender, EventArgs e)
        {
            double sigma = (double)SigmaBar.Value;
            GAUSSIANSUM = Filter.GenerateKernel(GaussianKernel, GAUSSIANLENGTH, sigma);
            sigma /= 10.0;
            SigmaLabel.Text = "Sigma: " + sigma.ToString();
        }

        private void RadarComboBox_DropDown(object sender, EventArgs e)
        {
            RadarComboBox.Items.Clear();
            foreach(Radar r in Radars)
            {
                RadarComboBox.Items.Add(r);
            }
        }

        private void RadarComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (RadarComboBox.SelectedItem != null)
            {
                OffsetBar.Value = (int)(10 * ((Radar)RadarComboBox.SelectedItem).Offset);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if(RadarComboBox.SelectedItem!=null)
            {
                RadarEditDialog edit = new RadarEditDialog((Radar)RadarComboBox.SelectedItem);
                if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    RadarComboBox.Text = ((Radar)RadarComboBox.SelectedItem).ToString();
            }
        }

        private void GammaBox_TextChanged(object sender, EventArgs e)
        {
            double t;
            if (double.TryParse(GammaBox.Text, out t))
                gamma = t;
        }

        private void StopScanningButton_Click(object sender, EventArgs e)
        {
            Utility.StopScanning(Radars);
        }

        private void StartScanningButton_Click(object sender, EventArgs e)
        {
            uint a;
            if (!uint.TryParse(IntervalBox.Text, out a)) a = 100000;
            Utility.StartScanning(Radars, a);
            RadarBox.Checked = true;
        }

        private void SetConfigButton_Click(object sender, EventArgs e)
        {
            MRM_SET_CONFIG_REQUEST set_config = new MRM_SET_CONFIG_REQUEST();
            set_config.MessageID = (ushort) MessageIDVal.Value;
            set_config.NodeID = (ushort) NodeIDVal.Value;
            set_config.BaseIntegrationIndex = (ushort) (PIIVal.SelectedIndex + 6);
            set_config.AntennaMode = (byte) (AntennaVal.SelectedIndex + 2);
            set_config.CodeChannel = (byte) CodeChannelVal.Value;
            set_config.TransmitGain = (byte) TransmitGainVal.Value;
            set_config.PersistFlag = (byte) PersistVal.SelectedIndex;
            set_config.ScanStartPS = (int) ScanStartVal.Value;
            set_config.ScanResolutions = 32;
            set_config.ScanStopPS = (int)ScanStopVal.Value;
            //set_config.RadarNumber = (int) RadarNumberVal.Value;
            for (int k = 0; k < Radars.Count; k++)
            {
                set_config.NodeID = (ushort)(100 + k);
                set_config.CodeChannel = (byte)k;
            //    set_config.ScanStartPS = FindNearestCorner(Radars[k].Location.X, Radars[k].Location.Y, XDIM, YDIM) + 12000;
            //   set_config.ScanStopPS = FindFurthestCorner(Radars[k].Location.X, Radars[k].Location.Y, XDIM, YDIM) + 12000;
                RadarRequest.SendMRM_SET_CONFIG_REQUEST(Radars[k], set_config);
            }
        }

        private void async_ScanReceived(object sender, string data)
        {
            Radar r = (Radar)sender;
            MRM_SCAN_INFO t;
            if(RadarRequest.ReceiveMRM_SCAN_INFO(data, out t))
            {
                Filter.BandpassFilter(ref t.ScanData);
                Filter.MotionFilter(ref r, ref t);
              //  lock (Program.lockObj)
              //  {
                    r.CurrentScan = t;
                    r.CurrentScan.ScanData = new int[t.ScanData.Length];
                    t.ScanData.CopyTo(r.CurrentScan.ScanData, 0);
                    r.CurrentScan = t;
                    r.CurrentScan.ScanData = new int[t.ScanData.Length];
                    t.ScanData.CopyTo(r.CurrentScan.ScanData, 0);

              //  }
            }
        }

        private void async_SetConfigReceived(object sender, string data)
        {
            MRM_GET_CONFIG_REQUEST m = new MRM_GET_CONFIG_REQUEST();
            m.MessageID = 4;
            RadarRequest.SendMRM_GET_CONFIG_REQUEST((Radar)sender, m);
        }

        private void async_GetConfigReceived(object sender, string data)
        {
            //MRM_GET_CONFIG_CONFIRM m;
        }

        private void async_RadarConnected(object sender, EventArgs e)
        {
            Radars.Add((Radar)sender);
            //MessageBox.Show("Radar Connected");
        }

        private void async_RadarDisconnected(object sender, EventArgs e)
        {
            Radars.Remove((Radar)sender);
            //MessageBox.Show("Radar Disconnected");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _async.QuitIt = true;
            _scanTimer.Dispose();
            AsynchronousSocketListener.allDone.Set();
            Properties.Settings.Default.Xdim = XDIM;
            Properties.Settings.Default.Ydim = YDIM;
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }

        private void AddRadarButton_Click(object sender, EventArgs e)
        {
            Radar r = new Radar(null,"", 0, 0);
            RadarEditDialog d = new RadarEditDialog(r);
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Radars.Add(r);
        }

        private void StartLoggingButton_Click(object sender, EventArgs e)
        {
            Utility.StartLogging(Radars);
        }

        private void StopLoggingButton_Click(object sender, EventArgs e)
        {
            Utility.StopLogging(Radars);
        }

        private void RadarTab_Paint(object sender, PaintEventArgs e)
        {
            OnPaint(e);
            GuiUtil.DrawRadarsAndEnclosure(RadarTab, Radars, XDIM, YDIM);
        }

        private void RadarSetButton_Click(object sender, EventArgs e)
        {
            int x, y;
            if(int.TryParse(RadarXBox.Text, out x) && int.TryParse(RadarYBox.Text, out y))
            {
                if(ProximityBox.Checked)
                {
                    foreach(Radar r in Radars)
                    {
                        double proxX = (double)r.Location.X / (double)XDIM;
                        double proxY = (double)r.Location.Y / (double)YDIM;
                        if (proxX >= 0.0 && proxX <= 1.0)
                            r.Location.X = (int)(proxX * x);
                        else if (proxX > 1.0) r.Location.X = (int)(r.Location.X - XDIM) + x;
                        if (proxY >= 0.0 && proxY <= 1.0)
                            r.Location.Y = (int)(proxY * y);
                        else if (proxY > 1.0) r.Location.Y = (int)(r.Location.Y - YDIM) + y;
                    }
                }
                XDIM = x;
                YDIM = y;
                if (fullBit != null) fullBit.Dispose();
                fullBit = GuiUtil.GenerateBitmap(300, XDIM, YDIM);
                BITCOLS = fullBit.Width;
                BITROWS = fullBit.Height;
            }
            else
            {
                MessageBox.Show("Invalid dimensions", "Error", MessageBoxButtons.OK);
            }
        }

        private void OffsetBar_ValueChanged(object sender, EventArgs e)
        {
            double o = OffsetBar.Value / 10;
            if (AlignBox.Checked)
            {
                foreach (Radar r in Radars)
                {
                    r.Offset = o;
                }
            }
            else
            {
                if (RadarComboBox.SelectedItem != null)
                    ((Radar)RadarComboBox.SelectedItem).Offset = o;
            }

            OffsetLabel.Text = "Offset: " + o.ToString() + " cm";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
	}
}
