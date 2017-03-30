using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RadarPlot
{
	static class Program
	{
        public static Object lockObj = new Object();
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
