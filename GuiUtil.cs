using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RadarPlot
{
    public class GraphParams //A class to facilitate the passing of GUI parameters
    {
        public int CmWidth, CmHeight, PixWidth, PixHeight, Filtering;
        public bool DB, Multiply, Color;
        public double Gamma;

        public GraphParams(int cw, int ch, int pw, int ph, int f, double g, bool d, bool m, bool c)
        {
            CmWidth = cw;
            CmHeight = ch;
            PixWidth = pw;
            PixHeight = ph;
            Filtering = f;
            Gamma = g;
            DB = d;
            Multiply = m;
            Color = c;
        }
    }

    static class GuiUtil
    {

/* ==========================================================================
==																		   ==
==		FUNCTION			GenerateBitmap							       ==
==																		   ==
==		DESCRIPTION		Create a Bitmap object with dimensions             ==
==                      proportional to the enclosure, scaled to fit       ==
==                      inside a space maxSize by maxSize pixels           ==
==																		   ==
==		ENTRY			int maxSize - the maximum width/ height the Bitmap can be  ==
==					    int cmWidth - the width in centimeters of the enclosure      ==
==			            int cmHeight - the height in centimeters of the enclosure        ==
==																		   ==
==		RETURN			A System.Drawing.Bitmap object scaled to fit       ==
==						enclosure of size cmWidth by cmHeight into size   ==
==						maxSize by maxSize								   ==
========================================================================== */
        public static Bitmap GenerateBitmap(int maxSize, int cmWidth, int cmHeight)
        {
            int pixWidth, pixHeight;
            double XtoY = (double)cmWidth / (double)cmHeight;
            if (XtoY >= 1.0)
            {
                pixWidth = maxSize;
                pixHeight = (int)(maxSize / XtoY);
            }
            else
            {
                pixHeight = maxSize;
                pixWidth = (int)(maxSize * XtoY);
            }

            return new Bitmap(pixWidth, pixHeight);
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		DrawRadarsAndEnclosure							       ==
        ==																		   ==
        ==		DESCRIPTION		Draw a GUI representation of the enclosure          ==
        ==																		   ==
        ==		ENTRY			Control c - the Windows Forms Control to draw on        ==
        ==						List<Radar> - a List of the Radars to be drawn   ==
        ==						int cmWidth - the width of the enclosure in cm   ==
        ==						int cmHeight - the height of the enclosure in cm   ==
        ==																		   ==
        ==		RETURN			nothing								   ==
        ========================================================================== */
        public static void DrawRadarsAndEnclosure(System.Windows.Forms.Control c, List<Radar> Radars, int cmWidth, int cmHeight)
        {
            Graphics g = c.CreateGraphics();
            double XtoY = (double)cmWidth / (double)cmHeight;
            int x, y, w, h;
            if (XtoY >= 1.0)
            {
                w = 200;
                h = (int)(200 / XtoY);
            }
            else
            {
                h = 200;
                w = (int)(200 * XtoY);
            }
            x = 150 - w / 2;
            y = 150 - h / 2;
            g.FillRectangle(Brushes.White, c.ClientRectangle);
            g.DrawRectangle(Pens.Black, x, y, w, h);
            foreach (Radar r in Radars)
            {
                double ratio = (double)cmWidth / (double)w;
                int rx = x + (int)(r.Location.X / ratio);
                int ry = y + (int)(r.Location.Y / ratio);
                g.FillEllipse(Brushes.Red, rx - 10, ry - 10, 20, 20);
            }
            g.Dispose();
        }

        //not finished...
        //finds the nearest corner (or point would be more appropriate) of the enclosure from a given point in space
        public static int FindNearestCorner(int x, int y, int cmWidth, int cmHeight)
        {
            if (x >= 0 && y >= 0 && x <= cmWidth && y <= cmHeight) return 0;
            int xmin = x < 0 ? 0 : cmWidth;
            int ymin = y < 0 ? 0 : cmHeight;
            return 0;
        }


        //not finished...
        //finds the furthest corner of the enclosure from a given point in space... always a corner
        public static int FindFurthestCorner(int x, int y, int cmWidth, int cmHeight)
        {
            return 0;
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		DrawGraph							       ==
        ==																		   ==
        ==		DESCRIPTION		Draw the 2-D backprojection plot          ==
        ==																		   ==
        ==		ENTRY			Bitmap bit - the Bitmap object to draw on       ==
        ==						List<Radar> - a List of the Radars to process   ==
        ==						int cmWidth - the width of the enclosure in cm   ==
        ==						GraphParams gp - all GUI parameters needed   ==
        ==																		   ==
        ==		RETURN			A bool representing whether the operation completed successfully  ==
        ========================================================================== */
        public static bool DrawGraph(ref System.Drawing.Bitmap bit, List<Radar> Radars, double[] gauss, GraphParams gp)
        {
            if (Radars.Count == 0) return false;
            double[][] filters = new double[Radars.Count][];
            int[][] peaks = new int[Radars.Count][];
            double[] maxVals = new double[Radars.Count];
            double totalStrength = 1.0;
            double strengthDivisor;
            double maxStrength = 1.0;
            byte intensity;
            byte count;
            try
            {
                for (int z = 0; z < Radars.Count; z++) //Filter all radars' current ScanData field
                {
                    if (Radars[z].CurrentScan.ScanData != null)
                    {
                        int[] temp;
                        lock (Program.lockObj)
                        {
                            temp = new int[Radars[z].CurrentScan.ScanData.Length];
                            Radars[z].CurrentScan.ScanData.CopyTo(temp, 0); //temp now references a different array, not an alias to CurrentScan.ScanData
                            MRM_SCAN_INFO ts = Radars[z].CurrentScan;

                        }
                        filters[z] = Filter.FilterData(temp, gauss, out peaks[z], gp.DB);
                        maxVals[z] = filters[z].Max();
                    }
                }
                maxStrength = maxVals.Max();
                for (int j = 0; j < gp.PixHeight; j++) //Fill the Bitmap pixel by pixel
                                                       //Could perhaps be offloaded to GPU in future for potentially faster drawing time
                                                       //300x300 Bitmap means 90000 independent calculations... okay to be done on CPU
                                                       //1000x1000 Bitmap (perhaps more desirable) means 1000000 independent calculations... unfeasible task for CPU
                {
                    for (int i = 0; i < gp.PixWidth; i++)
                    {
                        count = 0;
                        strengthDivisor = 1.0;
                        totalStrength = 1.0;
                        bool IsZero = false;
                        for (int z = 0; z < Radars.Count; z++) //Find the strength of each radar signal at the range bin corresponding to this pixel
                                                               //This automatically provides the radial plot we need by just knowing the distance between the pixel and the radar in terms of range bins
                        {
                            if (filters[z] != null)
                            {
                                count++;
                                double stren = Filter.FindStrength(filters[z], Radars[z].CurrentScan, new Point(i, j), Radars[z].Location, Radars[z].Offset, maxStrength, maxVals[z], gp);
                                if (stren <= 0) IsZero = true;
                                if ((gp.Filtering % 2) == 1)
                                {
                                    stren = (stren * stren) / maxStrength;
                                }
                                if (gp.Multiply)
                                    totalStrength *= stren;
                                else totalStrength += stren;

                            }
                        }
                        if (IsZero) totalStrength = 0;
                        else totalStrength = Math.Pow(totalStrength, gp.Gamma); //Boosting function: (sum or product of all radar strengths)^Gamma. Provides greater flexibility than a simple add or multiply function
                        for (int k = 0; k < count; k++)
                        {
                            if (gp.Multiply) strengthDivisor *= maxStrength;
                            else strengthDivisor += maxStrength;

                        }
                        strengthDivisor = Math.Pow(strengthDivisor, gp.Gamma);
                        if (gp.Filtering >= 2)
                            totalStrength = (totalStrength * totalStrength) / strengthDivisor;
                        if (gp.Color) //Scale for color mode
                        {
                            double quotient = totalStrength / strengthDivisor;
                            if (quotient > 1.0) quotient = 1.0;
                            byte red = (quotient > 0.5 ? (byte)(255 * ((quotient - 0.5) / 0.5)) : (byte)0);
                            byte green = (quotient > 0.5 ? (byte)(255 - 255 * ((quotient - 0.5) / 0.5)) : (byte)(255 * (quotient / 0.5)));
                            byte blue = (quotient < 0.5 ? (byte)(255 - 255 * (quotient / 0.5)) : (byte)0);
                            bit.SetPixel(i, j, System.Drawing.Color.FromArgb(red, green, blue));
                        }
                        else
                        {
                            if (totalStrength > strengthDivisor)
                                count++;
                            intensity = (byte)((255 * totalStrength) / strengthDivisor);
                            bit.SetPixel(i, j, System.Drawing.Color.FromArgb(intensity, intensity, intensity));
                        }

                    }
                }

#if TIMER
               // if (!radarGraph.IsDisposed && radarGraph.Visible)
                //    radarGraph.Draw(filters, maxVals, peaks);
#endif
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
