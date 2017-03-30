namespace RadarPlot
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RadarLoad = new System.Windows.Forms.OpenFileDialog();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.ConnectionTab = new System.Windows.Forms.TabPage();
            this.StopLoggingButton = new System.Windows.Forms.Button();
            this.StartLoggingButton = new System.Windows.Forms.Button();
            this.StopScanningButton = new System.Windows.Forms.Button();
            this.StartScanningButton = new System.Windows.Forms.Button();
            this.TcpIpGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RadarNumberVal = new System.Windows.Forms.NumericUpDown();
            this.RadarNumberBox = new System.Windows.Forms.TextBox();
            this.ScanStopVal = new System.Windows.Forms.NumericUpDown();
            this.ScanStartVal = new System.Windows.Forms.NumericUpDown();
            this.TransmitGainVal = new System.Windows.Forms.NumericUpDown();
            this.CodeChannelVal = new System.Windows.Forms.NumericUpDown();
            this.NodeIDVal = new System.Windows.Forms.NumericUpDown();
            this.MessageIDVal = new System.Windows.Forms.NumericUpDown();
            this.SetConfigButton = new System.Windows.Forms.Button();
            this.ScanStopBox = new System.Windows.Forms.TextBox();
            this.ScanStartBox = new System.Windows.Forms.TextBox();
            this.PersistBox = new System.Windows.Forms.TextBox();
            this.TransmitGainBox = new System.Windows.Forms.TextBox();
            this.CodeChannelBox = new System.Windows.Forms.TextBox();
            this.AntennaBox = new System.Windows.Forms.TextBox();
            this.PIIBox = new System.Windows.Forms.TextBox();
            this.MessageIDBox = new System.Windows.Forms.TextBox();
            this.NodeIDBox = new System.Windows.Forms.TextBox();
            this.PersistVal = new System.Windows.Forms.ComboBox();
            this.AntennaVal = new System.Windows.Forms.ComboBox();
            this.PIIVal = new System.Windows.Forms.ComboBox();
            this.RadarTab = new System.Windows.Forms.TabPage();
            this.ProximityBox = new System.Windows.Forms.CheckBox();
            this.RadarSetButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RadarYBox = new System.Windows.Forms.TextBox();
            this.RadarXBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddRadarButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.OffsetLabel = new System.Windows.Forms.Label();
            this.SigmaLabel = new System.Windows.Forms.Label();
            this.AnimationLabel = new System.Windows.Forms.Label();
            this.ThresholdBox = new System.Windows.Forms.CheckBox();
            this.ThresholdTextbox = new System.Windows.Forms.TextBox();
            this.OffsetBar = new System.Windows.Forms.TrackBar();
            this.IntervalBox = new System.Windows.Forms.TextBox();
            this.dBBox = new System.Windows.Forms.CheckBox();
            this.GammaBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.RadarComboBox = new System.Windows.Forms.ComboBox();
            this.SigmaBar = new System.Windows.Forms.TrackBar();
            this.RadarButton = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.AlignBox = new System.Windows.Forms.CheckBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.RadarBox = new System.Windows.Forms.CheckBox();
            this.AnimationSpeed = new System.Windows.Forms.TrackBar();
            this.ColorBox = new System.Windows.Forms.CheckBox();
            this.MultiplyBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ConnectionTab.SuspendLayout();
            this.TcpIpGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadarNumberVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanStopVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanStartVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitGainVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeChannelVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeIDVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageIDVal)).BeginInit();
            this.RadarTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationSpeed)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RadarLoad
            // 
            this.RadarLoad.DefaultExt = "csv";
            this.RadarLoad.InitialDirectory = "C:\\Users\\Dustin\\Radar Data";
            this.RadarLoad.RestoreDirectory = true;
            this.RadarLoad.Title = "Choose Radar File";
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 50;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // ConnectionTab
            // 
            this.ConnectionTab.Controls.Add(this.StopLoggingButton);
            this.ConnectionTab.Controls.Add(this.StartLoggingButton);
            this.ConnectionTab.Controls.Add(this.StopScanningButton);
            this.ConnectionTab.Controls.Add(this.StartScanningButton);
            this.ConnectionTab.Controls.Add(this.TcpIpGroupBox);
            this.ConnectionTab.Location = new System.Drawing.Point(4, 22);
            this.ConnectionTab.Name = "ConnectionTab";
            this.ConnectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectionTab.Size = new System.Drawing.Size(536, 300);
            this.ConnectionTab.TabIndex = 3;
            this.ConnectionTab.Text = "Connection";
            this.ConnectionTab.UseVisualStyleBackColor = true;
            // 
            // StopLoggingButton
            // 
            this.StopLoggingButton.Location = new System.Drawing.Point(190, 236);
            this.StopLoggingButton.Name = "StopLoggingButton";
            this.StopLoggingButton.Size = new System.Drawing.Size(153, 23);
            this.StopLoggingButton.TabIndex = 6;
            this.StopLoggingButton.Text = "Stop Logging";
            this.StopLoggingButton.UseVisualStyleBackColor = true;
            this.StopLoggingButton.Click += new System.EventHandler(this.StopLoggingButton_Click);
            // 
            // StartLoggingButton
            // 
            this.StartLoggingButton.Location = new System.Drawing.Point(190, 207);
            this.StartLoggingButton.Name = "StartLoggingButton";
            this.StartLoggingButton.Size = new System.Drawing.Size(153, 23);
            this.StartLoggingButton.TabIndex = 5;
            this.StartLoggingButton.Text = "Start Logging";
            this.StartLoggingButton.UseVisualStyleBackColor = true;
            this.StartLoggingButton.Click += new System.EventHandler(this.StartLoggingButton_Click);
            // 
            // StopScanningButton
            // 
            this.StopScanningButton.Location = new System.Drawing.Point(190, 178);
            this.StopScanningButton.Name = "StopScanningButton";
            this.StopScanningButton.Size = new System.Drawing.Size(153, 23);
            this.StopScanningButton.TabIndex = 4;
            this.StopScanningButton.Text = "Stop Scanning";
            this.StopScanningButton.UseVisualStyleBackColor = true;
            this.StopScanningButton.Click += new System.EventHandler(this.StopScanningButton_Click);
            // 
            // StartScanningButton
            // 
            this.StartScanningButton.Location = new System.Drawing.Point(190, 149);
            this.StartScanningButton.Name = "StartScanningButton";
            this.StartScanningButton.Size = new System.Drawing.Size(153, 23);
            this.StartScanningButton.TabIndex = 3;
            this.StartScanningButton.Text = "Start Scanning";
            this.StartScanningButton.UseVisualStyleBackColor = true;
            this.StartScanningButton.Click += new System.EventHandler(this.StartScanningButton_Click);
            // 
            // TcpIpGroupBox
            // 
            this.TcpIpGroupBox.Controls.Add(this.label4);
            this.TcpIpGroupBox.Controls.Add(this.label3);
            this.TcpIpGroupBox.Controls.Add(this.label2);
            this.TcpIpGroupBox.Controls.Add(this.label1);
            this.TcpIpGroupBox.Location = new System.Drawing.Point(181, 39);
            this.TcpIpGroupBox.Name = "TcpIpGroupBox";
            this.TcpIpGroupBox.Size = new System.Drawing.Size(171, 104);
            this.TcpIpGroupBox.TabIndex = 2;
            this.TcpIpGroupBox.TabStop = false;
            this.TcpIpGroupBox.Text = "TCP/IP";
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RadarNumberVal);
            this.tabPage2.Controls.Add(this.RadarNumberBox);
            this.tabPage2.Controls.Add(this.ScanStopVal);
            this.tabPage2.Controls.Add(this.ScanStartVal);
            this.tabPage2.Controls.Add(this.TransmitGainVal);
            this.tabPage2.Controls.Add(this.CodeChannelVal);
            this.tabPage2.Controls.Add(this.NodeIDVal);
            this.tabPage2.Controls.Add(this.MessageIDVal);
            this.tabPage2.Controls.Add(this.SetConfigButton);
            this.tabPage2.Controls.Add(this.ScanStopBox);
            this.tabPage2.Controls.Add(this.ScanStartBox);
            this.tabPage2.Controls.Add(this.PersistBox);
            this.tabPage2.Controls.Add(this.TransmitGainBox);
            this.tabPage2.Controls.Add(this.CodeChannelBox);
            this.tabPage2.Controls.Add(this.AntennaBox);
            this.tabPage2.Controls.Add(this.PIIBox);
            this.tabPage2.Controls.Add(this.MessageIDBox);
            this.tabPage2.Controls.Add(this.NodeIDBox);
            this.tabPage2.Controls.Add(this.PersistVal);
            this.tabPage2.Controls.Add(this.AntennaVal);
            this.tabPage2.Controls.Add(this.PIIVal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RadarNumberVal
            // 
            this.RadarNumberVal.Location = new System.Drawing.Point(202, 263);
            this.RadarNumberVal.Margin = new System.Windows.Forms.Padding(2);
            this.RadarNumberVal.Maximum = new decimal(new int[] {
            103,
            0,
            0,
            0});
            this.RadarNumberVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RadarNumberVal.Name = "RadarNumberVal";
            this.RadarNumberVal.Size = new System.Drawing.Size(156, 20);
            this.RadarNumberVal.TabIndex = 32;
            this.RadarNumberVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RadarNumberVal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // RadarNumberBox
            // 
            this.RadarNumberBox.AcceptsReturn = true;
            this.RadarNumberBox.BackColor = System.Drawing.Color.White;
            this.RadarNumberBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RadarNumberBox.Location = new System.Drawing.Point(97, 269);
            this.RadarNumberBox.Name = "RadarNumberBox";
            this.RadarNumberBox.ReadOnly = true;
            this.RadarNumberBox.Size = new System.Drawing.Size(100, 13);
            this.RadarNumberBox.TabIndex = 31;
            this.RadarNumberBox.Text = "Radar Number";
            // 
            // ScanStopVal
            // 
            this.ScanStopVal.Location = new System.Drawing.Point(202, 236);
            this.ScanStopVal.Margin = new System.Windows.Forms.Padding(2);
            this.ScanStopVal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ScanStopVal.Name = "ScanStopVal";
            this.ScanStopVal.Size = new System.Drawing.Size(156, 20);
            this.ScanStopVal.TabIndex = 30;
            this.ScanStopVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ScanStartVal
            // 
            this.ScanStartVal.Location = new System.Drawing.Point(202, 208);
            this.ScanStartVal.Margin = new System.Windows.Forms.Padding(2);
            this.ScanStartVal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ScanStartVal.Name = "ScanStartVal";
            this.ScanStartVal.Size = new System.Drawing.Size(156, 20);
            this.ScanStartVal.TabIndex = 29;
            this.ScanStartVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TransmitGainVal
            // 
            this.TransmitGainVal.Location = new System.Drawing.Point(202, 154);
            this.TransmitGainVal.Margin = new System.Windows.Forms.Padding(2);
            this.TransmitGainVal.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.TransmitGainVal.Name = "TransmitGainVal";
            this.TransmitGainVal.Size = new System.Drawing.Size(156, 20);
            this.TransmitGainVal.TabIndex = 28;
            this.TransmitGainVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TransmitGainVal.Value = new decimal(new int[] {
            63,
            0,
            0,
            0});
            // 
            // CodeChannelVal
            // 
            this.CodeChannelVal.Location = new System.Drawing.Point(202, 127);
            this.CodeChannelVal.Margin = new System.Windows.Forms.Padding(2);
            this.CodeChannelVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CodeChannelVal.Name = "CodeChannelVal";
            this.CodeChannelVal.Size = new System.Drawing.Size(156, 20);
            this.CodeChannelVal.TabIndex = 27;
            this.CodeChannelVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NodeIDVal
            // 
            this.NodeIDVal.Location = new System.Drawing.Point(202, 45);
            this.NodeIDVal.Margin = new System.Windows.Forms.Padding(2);
            this.NodeIDVal.Maximum = new decimal(new int[] {
            -2,
            0,
            0,
            0});
            this.NodeIDVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NodeIDVal.Name = "NodeIDVal";
            this.NodeIDVal.Size = new System.Drawing.Size(156, 20);
            this.NodeIDVal.TabIndex = 26;
            this.NodeIDVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NodeIDVal.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            // 
            // MessageIDVal
            // 
            this.MessageIDVal.Location = new System.Drawing.Point(202, 19);
            this.MessageIDVal.Margin = new System.Windows.Forms.Padding(2);
            this.MessageIDVal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MessageIDVal.Name = "MessageIDVal";
            this.MessageIDVal.Size = new System.Drawing.Size(156, 20);
            this.MessageIDVal.TabIndex = 25;
            this.MessageIDVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MessageIDVal.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // SetConfigButton
            // 
            this.SetConfigButton.Location = new System.Drawing.Point(393, 16);
            this.SetConfigButton.Name = "SetConfigButton";
            this.SetConfigButton.Size = new System.Drawing.Size(120, 23);
            this.SetConfigButton.TabIndex = 24;
            this.SetConfigButton.Text = "Set Configuration";
            this.SetConfigButton.UseVisualStyleBackColor = true;
            this.SetConfigButton.Click += new System.EventHandler(this.SetConfigButton_Click);
            // 
            // ScanStopBox
            // 
            this.ScanStopBox.BackColor = System.Drawing.Color.White;
            this.ScanStopBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScanStopBox.Location = new System.Drawing.Point(97, 242);
            this.ScanStopBox.Name = "ScanStopBox";
            this.ScanStopBox.ReadOnly = true;
            this.ScanStopBox.Size = new System.Drawing.Size(100, 13);
            this.ScanStopBox.TabIndex = 23;
            this.ScanStopBox.Text = "Scan stop";
            // 
            // ScanStartBox
            // 
            this.ScanStartBox.BackColor = System.Drawing.Color.White;
            this.ScanStartBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScanStartBox.Location = new System.Drawing.Point(97, 213);
            this.ScanStartBox.Name = "ScanStartBox";
            this.ScanStartBox.ReadOnly = true;
            this.ScanStartBox.Size = new System.Drawing.Size(100, 13);
            this.ScanStartBox.TabIndex = 22;
            this.ScanStartBox.Text = "Scan start";
            // 
            // PersistBox
            // 
            this.PersistBox.BackColor = System.Drawing.Color.White;
            this.PersistBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PersistBox.Location = new System.Drawing.Point(97, 188);
            this.PersistBox.Name = "PersistBox";
            this.PersistBox.ReadOnly = true;
            this.PersistBox.Size = new System.Drawing.Size(100, 13);
            this.PersistBox.TabIndex = 21;
            this.PersistBox.Text = "Persist";
            // 
            // TransmitGainBox
            // 
            this.TransmitGainBox.BackColor = System.Drawing.Color.White;
            this.TransmitGainBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TransmitGainBox.Location = new System.Drawing.Point(97, 160);
            this.TransmitGainBox.Name = "TransmitGainBox";
            this.TransmitGainBox.ReadOnly = true;
            this.TransmitGainBox.Size = new System.Drawing.Size(100, 13);
            this.TransmitGainBox.TabIndex = 20;
            this.TransmitGainBox.Text = "Transmit Gain";
            // 
            // CodeChannelBox
            // 
            this.CodeChannelBox.BackColor = System.Drawing.Color.White;
            this.CodeChannelBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeChannelBox.Location = new System.Drawing.Point(97, 133);
            this.CodeChannelBox.Name = "CodeChannelBox";
            this.CodeChannelBox.ReadOnly = true;
            this.CodeChannelBox.Size = new System.Drawing.Size(100, 13);
            this.CodeChannelBox.TabIndex = 19;
            this.CodeChannelBox.Text = "Code Channel";
            // 
            // AntennaBox
            // 
            this.AntennaBox.BackColor = System.Drawing.Color.White;
            this.AntennaBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AntennaBox.Location = new System.Drawing.Point(97, 106);
            this.AntennaBox.Name = "AntennaBox";
            this.AntennaBox.ReadOnly = true;
            this.AntennaBox.Size = new System.Drawing.Size(100, 13);
            this.AntennaBox.TabIndex = 18;
            this.AntennaBox.Text = "Antenna Mode";
            // 
            // PIIBox
            // 
            this.PIIBox.BackColor = System.Drawing.Color.White;
            this.PIIBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PIIBox.Location = new System.Drawing.Point(97, 78);
            this.PIIBox.Name = "PIIBox";
            this.PIIBox.ReadOnly = true;
            this.PIIBox.Size = new System.Drawing.Size(100, 13);
            this.PIIBox.TabIndex = 17;
            this.PIIBox.Text = "Pulse Int Index";
            // 
            // MessageIDBox
            // 
            this.MessageIDBox.BackColor = System.Drawing.Color.White;
            this.MessageIDBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageIDBox.Location = new System.Drawing.Point(97, 25);
            this.MessageIDBox.Name = "MessageIDBox";
            this.MessageIDBox.ReadOnly = true;
            this.MessageIDBox.Size = new System.Drawing.Size(100, 13);
            this.MessageIDBox.TabIndex = 16;
            this.MessageIDBox.Text = "Message ID";
            // 
            // NodeIDBox
            // 
            this.NodeIDBox.BackColor = System.Drawing.Color.White;
            this.NodeIDBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NodeIDBox.Location = new System.Drawing.Point(97, 51);
            this.NodeIDBox.Name = "NodeIDBox";
            this.NodeIDBox.ReadOnly = true;
            this.NodeIDBox.Size = new System.Drawing.Size(100, 13);
            this.NodeIDBox.TabIndex = 14;
            this.NodeIDBox.Text = "Node ID";
            // 
            // PersistVal
            // 
            this.PersistVal.FormattingEnabled = true;
            this.PersistVal.Items.AddRange(new object[] {
            "0 - Do NOT Write to Flash",
            "1 - Write to Flash"});
            this.PersistVal.Location = new System.Drawing.Point(202, 181);
            this.PersistVal.Name = "PersistVal";
            this.PersistVal.Size = new System.Drawing.Size(157, 21);
            this.PersistVal.TabIndex = 7;
            this.PersistVal.Text = "1 - Write to Flash";
            // 
            // AntennaVal
            // 
            this.AntennaVal.FormattingEnabled = true;
            this.AntennaVal.Items.AddRange(new object[] {
            "2 - Tx on A, Rx on B",
            "3 - Tx on B, Rx on A"});
            this.AntennaVal.Location = new System.Drawing.Point(202, 99);
            this.AntennaVal.Name = "AntennaVal";
            this.AntennaVal.Size = new System.Drawing.Size(157, 21);
            this.AntennaVal.TabIndex = 2;
            this.AntennaVal.Text = "2 - Tx on A, Rx on B";
            // 
            // PIIVal
            // 
            this.PIIVal.FormattingEnabled = true;
            this.PIIVal.Items.AddRange(new object[] {
            "6 - 64 Pulses per Symbol",
            "7 - 128 Pulses per Symbol",
            "8 - 256 Pulses per Symbol",
            "9 - 512 Pulses per Symbol",
            "10 - 1024 Pulses per Symbol",
            "11 - 2048 Pulses per Symbol",
            "12 - 4096 Pulses per Symbol",
            "13 - 8192 Pulses per Symbol",
            "14 - 16384 Pulses per Symbol",
            "15 - 32768 Pulses per Symbol"});
            this.PIIVal.Location = new System.Drawing.Point(202, 70);
            this.PIIVal.Name = "PIIVal";
            this.PIIVal.Size = new System.Drawing.Size(157, 21);
            this.PIIVal.TabIndex = 1;
            this.PIIVal.Text = "10 - 1024 Pulses per Symbol";
            // 
            // RadarTab
            // 
            this.RadarTab.Controls.Add(this.ProximityBox);
            this.RadarTab.Controls.Add(this.RadarSetButton);
            this.RadarTab.Controls.Add(this.label7);
            this.RadarTab.Controls.Add(this.label6);
            this.RadarTab.Controls.Add(this.RadarYBox);
            this.RadarTab.Controls.Add(this.RadarXBox);
            this.RadarTab.Controls.Add(this.label5);
            this.RadarTab.Controls.Add(this.AddRadarButton);
            this.RadarTab.Location = new System.Drawing.Point(4, 22);
            this.RadarTab.Name = "RadarTab";
            this.RadarTab.Padding = new System.Windows.Forms.Padding(3);
            this.RadarTab.Size = new System.Drawing.Size(536, 300);
            this.RadarTab.TabIndex = 2;
            this.RadarTab.Text = "Radars";
            this.RadarTab.UseVisualStyleBackColor = true;
            this.RadarTab.Paint += new System.Windows.Forms.PaintEventHandler(this.RadarTab_Paint);
            // 
            // ProximityBox
            // 
            this.ProximityBox.AutoSize = true;
            this.ProximityBox.Checked = true;
            this.ProximityBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ProximityBox.Location = new System.Drawing.Point(419, 177);
            this.ProximityBox.Name = "ProximityBox";
            this.ProximityBox.Size = new System.Drawing.Size(103, 17);
            this.ProximityBox.TabIndex = 7;
            this.ProximityBox.Text = "Keep Proximities";
            this.ProximityBox.UseVisualStyleBackColor = true;
            // 
            // RadarSetButton
            // 
            this.RadarSetButton.Location = new System.Drawing.Point(419, 148);
            this.RadarSetButton.Name = "RadarSetButton";
            this.RadarSetButton.Size = new System.Drawing.Size(111, 23);
            this.RadarSetButton.TabIndex = 6;
            this.RadarSetButton.Text = "Set";
            this.RadarSetButton.UseVisualStyleBackColor = true;
            this.RadarSetButton.Click += new System.EventHandler(this.RadarSetButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "X:";
            // 
            // RadarYBox
            // 
            this.RadarYBox.Location = new System.Drawing.Point(419, 122);
            this.RadarYBox.Name = "RadarYBox";
            this.RadarYBox.Size = new System.Drawing.Size(111, 20);
            this.RadarYBox.TabIndex = 3;
            // 
            // RadarXBox
            // 
            this.RadarXBox.Location = new System.Drawing.Point(419, 96);
            this.RadarXBox.Name = "RadarXBox";
            this.RadarXBox.Size = new System.Drawing.Size(111, 20);
            this.RadarXBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Enclosure Dimensions (cm)";
            // 
            // AddRadarButton
            // 
            this.AddRadarButton.Location = new System.Drawing.Point(399, 6);
            this.AddRadarButton.Name = "AddRadarButton";
            this.AddRadarButton.Size = new System.Drawing.Size(131, 23);
            this.AddRadarButton.TabIndex = 0;
            this.AddRadarButton.Text = "Add Radar";
            this.AddRadarButton.UseVisualStyleBackColor = true;
            this.AddRadarButton.Click += new System.EventHandler(this.AddRadarButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.OffsetLabel);
            this.tabPage1.Controls.Add(this.SigmaLabel);
            this.tabPage1.Controls.Add(this.AnimationLabel);
            this.tabPage1.Controls.Add(this.ThresholdBox);
            this.tabPage1.Controls.Add(this.ThresholdTextbox);
            this.tabPage1.Controls.Add(this.OffsetBar);
            this.tabPage1.Controls.Add(this.IntervalBox);
            this.tabPage1.Controls.Add(this.dBBox);
            this.tabPage1.Controls.Add(this.GammaBox);
            this.tabPage1.Controls.Add(this.EditButton);
            this.tabPage1.Controls.Add(this.RadarComboBox);
            this.tabPage1.Controls.Add(this.SigmaBar);
            this.tabPage1.Controls.Add(this.RadarButton);
            this.tabPage1.Controls.Add(this.Run);
            this.tabPage1.Controls.Add(this.AlignBox);
            this.tabPage1.Controls.Add(this.FilterButton);
            this.tabPage1.Controls.Add(this.RadarBox);
            this.tabPage1.Controls.Add(this.AnimationSpeed);
            this.tabPage1.Controls.Add(this.ColorBox);
            this.tabPage1.Controls.Add(this.MultiplyBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Threshold (0.0-1.0)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Gamma";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Scan Interval (us)";
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(444, 142);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(41, 13);
            this.OffsetLabel.TabIndex = 34;
            this.OffsetLabel.Text = "Offset: ";
            // 
            // SigmaLabel
            // 
            this.SigmaLabel.AutoSize = true;
            this.SigmaLabel.Location = new System.Drawing.Point(441, 88);
            this.SigmaLabel.Name = "SigmaLabel";
            this.SigmaLabel.Size = new System.Drawing.Size(42, 13);
            this.SigmaLabel.TabIndex = 33;
            this.SigmaLabel.Text = "Sigma: ";
            // 
            // AnimationLabel
            // 
            this.AnimationLabel.AutoSize = true;
            this.AnimationLabel.Location = new System.Drawing.Point(441, 37);
            this.AnimationLabel.Name = "AnimationLabel";
            this.AnimationLabel.Size = new System.Drawing.Size(59, 13);
            this.AnimationLabel.TabIndex = 32;
            this.AnimationLabel.Text = "Animation: ";
            // 
            // ThresholdBox
            // 
            this.ThresholdBox.AutoSize = true;
            this.ThresholdBox.Location = new System.Drawing.Point(455, 232);
            this.ThresholdBox.Name = "ThresholdBox";
            this.ThresholdBox.Size = new System.Drawing.Size(73, 17);
            this.ThresholdBox.TabIndex = 31;
            this.ThresholdBox.Text = "Threshold";
            this.ThresholdBox.UseVisualStyleBackColor = true;
            // 
            // ThresholdTextbox
            // 
            this.ThresholdTextbox.Location = new System.Drawing.Point(463, 179);
            this.ThresholdTextbox.Name = "ThresholdTextbox";
            this.ThresholdTextbox.Size = new System.Drawing.Size(65, 20);
            this.ThresholdTextbox.TabIndex = 30;
            this.ThresholdTextbox.Text = "0";
            // 
            // OffsetBar
            // 
            this.OffsetBar.BackColor = System.Drawing.Color.White;
            this.OffsetBar.LargeChange = 100;
            this.OffsetBar.Location = new System.Drawing.Point(430, 111);
            this.OffsetBar.Maximum = 5000;
            this.OffsetBar.Minimum = -5000;
            this.OffsetBar.Name = "OffsetBar";
            this.OffsetBar.Size = new System.Drawing.Size(98, 45);
            this.OffsetBar.SmallChange = 10;
            this.OffsetBar.TabIndex = 29;
            this.OffsetBar.TickFrequency = 1000;
            this.OffsetBar.ValueChanged += new System.EventHandler(this.OffsetBar_ValueChanged);
            // 
            // IntervalBox
            // 
            this.IntervalBox.Location = new System.Drawing.Point(323, 179);
            this.IntervalBox.Name = "IntervalBox";
            this.IntervalBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IntervalBox.Size = new System.Drawing.Size(79, 20);
            this.IntervalBox.TabIndex = 28;
            this.IntervalBox.Text = "100000";
            // 
            // dBBox
            // 
            this.dBBox.AutoSize = true;
            this.dBBox.Location = new System.Drawing.Point(324, 157);
            this.dBBox.Name = "dBBox";
            this.dBBox.Size = new System.Drawing.Size(69, 17);
            this.dBBox.TabIndex = 27;
            this.dBBox.Text = "dB Mode";
            this.dBBox.UseVisualStyleBackColor = true;
            // 
            // GammaBox
            // 
            this.GammaBox.Location = new System.Drawing.Point(323, 232);
            this.GammaBox.Name = "GammaBox";
            this.GammaBox.Size = new System.Drawing.Size(100, 20);
            this.GammaBox.TabIndex = 26;
            this.GammaBox.Text = "2.0";
            this.GammaBox.TextChanged += new System.EventHandler(this.GammaBox_TextChanged);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(324, 7);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(100, 21);
            this.EditButton.TabIndex = 25;
            this.EditButton.Text = "Edit...";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // RadarComboBox
            // 
            this.RadarComboBox.FormattingEnabled = true;
            this.RadarComboBox.Location = new System.Drawing.Point(6, 6);
            this.RadarComboBox.Name = "RadarComboBox";
            this.RadarComboBox.Size = new System.Drawing.Size(204, 21);
            this.RadarComboBox.TabIndex = 24;
            this.RadarComboBox.DropDown += new System.EventHandler(this.RadarComboBox_DropDown);
            this.RadarComboBox.SelectionChangeCommitted += new System.EventHandler(this.RadarComboBox_SelectionChangeCommitted);
            // 
            // SigmaBar
            // 
            this.SigmaBar.BackColor = System.Drawing.Color.White;
            this.SigmaBar.LargeChange = 10;
            this.SigmaBar.Location = new System.Drawing.Point(430, 58);
            this.SigmaBar.Maximum = 100;
            this.SigmaBar.Name = "SigmaBar";
            this.SigmaBar.Size = new System.Drawing.Size(104, 45);
            this.SigmaBar.SmallChange = 5;
            this.SigmaBar.TabIndex = 21;
            this.SigmaBar.TickFrequency = 100;
            this.SigmaBar.Value = 10;
            this.SigmaBar.ValueChanged += new System.EventHandler(this.SigmaBar_ValueChanged);
            // 
            // RadarButton
            // 
            this.RadarButton.Location = new System.Drawing.Point(218, 6);
            this.RadarButton.Name = "RadarButton";
            this.RadarButton.Size = new System.Drawing.Size(100, 21);
            this.RadarButton.TabIndex = 2;
            this.RadarButton.Text = "Load CSV";
            this.RadarButton.UseVisualStyleBackColor = true;
            this.RadarButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RadarButton_MouseClick);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(324, 33);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(100, 21);
            this.Run.TabIndex = 4;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // AlignBox
            // 
            this.AlignBox.AutoSize = true;
            this.AlignBox.Location = new System.Drawing.Point(324, 139);
            this.AlignBox.Name = "AlignBox";
            this.AlignBox.Size = new System.Drawing.Size(85, 17);
            this.AlignBox.TabIndex = 20;
            this.AlignBox.Text = "Align Offsets";
            this.AlignBox.UseVisualStyleBackColor = true;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(324, 58);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(100, 21);
            this.FilterButton.TabIndex = 5;
            this.FilterButton.Text = "Filtering: Off";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // RadarBox
            // 
            this.RadarBox.AutoSize = true;
            this.RadarBox.Location = new System.Drawing.Point(324, 120);
            this.RadarBox.Name = "RadarBox";
            this.RadarBox.Size = new System.Drawing.Size(85, 17);
            this.RadarBox.TabIndex = 19;
            this.RadarBox.Text = "Radar Mode";
            this.RadarBox.UseVisualStyleBackColor = true;
            this.RadarBox.CheckedChanged += new System.EventHandler(this.RadarBox_CheckedChanged);
            // 
            // AnimationSpeed
            // 
            this.AnimationSpeed.BackColor = System.Drawing.Color.White;
            this.AnimationSpeed.LargeChange = 100;
            this.AnimationSpeed.Location = new System.Drawing.Point(430, 7);
            this.AnimationSpeed.Maximum = 2000;
            this.AnimationSpeed.Minimum = 100;
            this.AnimationSpeed.Name = "AnimationSpeed";
            this.AnimationSpeed.Size = new System.Drawing.Size(104, 45);
            this.AnimationSpeed.SmallChange = 20;
            this.AnimationSpeed.TabIndex = 6;
            this.AnimationSpeed.TickFrequency = 100;
            this.AnimationSpeed.Value = 100;
            this.AnimationSpeed.ValueChanged += new System.EventHandler(this.AnimationSpeed_ValueChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.AutoSize = true;
            this.ColorBox.Location = new System.Drawing.Point(324, 84);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(80, 17);
            this.ColorBox.TabIndex = 7;
            this.ColorBox.Text = "Color Mode";
            this.ColorBox.UseVisualStyleBackColor = true;
            // 
            // MultiplyBox
            // 
            this.MultiplyBox.AutoSize = true;
            this.MultiplyBox.Location = new System.Drawing.Point(324, 102);
            this.MultiplyBox.Name = "MultiplyBox";
            this.MultiplyBox.Size = new System.Drawing.Size(61, 17);
            this.MultiplyBox.TabIndex = 8;
            this.MultiplyBox.Text = "Multiply";
            this.MultiplyBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.RadarTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.ConnectionTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 315);
            this.tabControl1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(551, 321);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "RatTracker Color Plot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ConnectionTab.ResumeLayout(false);
            this.TcpIpGroupBox.ResumeLayout(false);
            this.TcpIpGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadarNumberVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanStopVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanStartVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitGainVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeChannelVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeIDVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageIDVal)).EndInit();
            this.RadarTab.ResumeLayout(false);
            this.RadarTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationSpeed)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.OpenFileDialog RadarLoad;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.TabPage ConnectionTab;
        private System.Windows.Forms.Button StopLoggingButton;
        private System.Windows.Forms.Button StartLoggingButton;
        private System.Windows.Forms.Button StopScanningButton;
        private System.Windows.Forms.Button StartScanningButton;
        private System.Windows.Forms.GroupBox TcpIpGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown RadarNumberVal;
        private System.Windows.Forms.TextBox RadarNumberBox;
        private System.Windows.Forms.NumericUpDown ScanStopVal;
        private System.Windows.Forms.NumericUpDown ScanStartVal;
        private System.Windows.Forms.NumericUpDown TransmitGainVal;
        private System.Windows.Forms.NumericUpDown CodeChannelVal;
        private System.Windows.Forms.NumericUpDown NodeIDVal;
        private System.Windows.Forms.NumericUpDown MessageIDVal;
        private System.Windows.Forms.Button SetConfigButton;
        private System.Windows.Forms.TextBox ScanStopBox;
        private System.Windows.Forms.TextBox ScanStartBox;
        private System.Windows.Forms.TextBox PersistBox;
        private System.Windows.Forms.TextBox TransmitGainBox;
        private System.Windows.Forms.TextBox CodeChannelBox;
        private System.Windows.Forms.TextBox AntennaBox;
        private System.Windows.Forms.TextBox PIIBox;
        private System.Windows.Forms.TextBox MessageIDBox;
        private System.Windows.Forms.TextBox NodeIDBox;
        private System.Windows.Forms.ComboBox PersistVal;
        private System.Windows.Forms.ComboBox AntennaVal;
        private System.Windows.Forms.ComboBox PIIVal;
        private System.Windows.Forms.TabPage RadarTab;
        private System.Windows.Forms.CheckBox ProximityBox;
        private System.Windows.Forms.Button RadarSetButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RadarYBox;
        private System.Windows.Forms.TextBox RadarXBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddRadarButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ThresholdBox;
        private System.Windows.Forms.TextBox ThresholdTextbox;
        private System.Windows.Forms.TrackBar OffsetBar;
        private System.Windows.Forms.TextBox IntervalBox;
        private System.Windows.Forms.CheckBox dBBox;
        private System.Windows.Forms.TextBox GammaBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.ComboBox RadarComboBox;
        private System.Windows.Forms.TrackBar SigmaBar;
        private System.Windows.Forms.Button RadarButton;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.CheckBox AlignBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.CheckBox RadarBox;
        private System.Windows.Forms.TrackBar AnimationSpeed;
        private System.Windows.Forms.CheckBox ColorBox;
        private System.Windows.Forms.CheckBox MultiplyBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label SigmaLabel;
        private System.Windows.Forms.Label AnimationLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label OffsetLabel;
        private System.Windows.Forms.Label label8;

    }
}

