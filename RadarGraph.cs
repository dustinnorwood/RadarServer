using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadarPlot
{
    public partial class RadarGraph : Form
    {
        private Bitmap b;
        public RadarGraph()
        {
            InitializeComponent();
            b = new Bitmap(651, 601);
        }

        public void Draw(double[][] graphs, double[] maxs, int[][] peaks)
        {
            int graphHeight = 600 / graphs.GetLength(0);
            SolidBrush white = new SolidBrush(Color.White);
            Pen black = new Pen(Color.Black);
            Graphics g = Graphics.FromImage(b);
            Font f = new System.Drawing.Font(FontFamily.GenericSansSerif, 8);
            SolidBrush bb = new SolidBrush(Color.Black);
            g.FillRectangle(white, 0, 0, b.Width, b.Height);
            
            for( int k = 0;k<graphs.GetLength(0);k++)
            {
                if (graphs[k] != null)
                {
                    double max = maxs[k];
                    for (int l = 0; l < graphs[k].Length; l++)
                    {
                        try
                        {
                            PointF p1 = new PointF((int)((l * 600) / graphs[k].Length), (k + 1) * graphHeight);
                            PointF p2 = new PointF((int)((l * 600) / graphs[k].Length), (int)((k + 1) * graphHeight - (graphs[k][l] * graphHeight) / max));
                            g.DrawLine(black, p1, p2);
                            g.DrawString(max.ToString(), f, bb, 605, graphHeight * k + 5);
                            g.DrawString((max / 2).ToString(), f, bb, 605, graphHeight * k + graphHeight / 2 + 5);
                            
                        }
                        catch (ArgumentOutOfRangeException)
                        {

                        }
                    }
                    int j = 0;
                    while(j < peaks[k].Length && peaks[k][j]!=-1)
                    {
                        int z = peaks[k][j];
                        PointF p2 = new PointF((int)((z * 600) / graphs[k].Length), (int)((k + 1) * graphHeight - (graphs[k][z] * graphHeight) / max));
                        g.FillRectangle(Brushes.Red, p2.X - 1, p2.Y - 1, 3, 3);
                        j++;
                    }
                }
            }
            if (!this.IsDisposed)
            {
                this.CreateGraphics().DrawImage(b, 0, 0);
            }
            white.Dispose();
            black.Dispose();
            f.Dispose();
            bb.Dispose();
            g.Dispose();
        }

    }
}
