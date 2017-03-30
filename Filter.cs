#define KEVINFILTER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPlot
{

    //A set of filter operations. 
    static class Filter
    {
        public const double PSPERBIN = 1.907;
        public const double CMPERPS = 0.015;
        public const double PSPERCM = 66.666666666666666666666666666667;

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		BandpassFilter							       ==
        ==																		   ==
        ==		DESCRIPTION		Time Domain's bandpass filter for a ScanData array          ==
        ==																		   ==
        ==		ENTRY			ref int[] t - unfiltered array                    ==
        ==																		   ==
        ==		RETURN			none                                                ==
        ========================================================================== */
        public static void BandpassFilter(ref int[] t)
        {
            double[] a = new double[7], b = new double[7];
            b[0] = 0.058918593549;
            b[1] = 0.003704122993;
            b[2] = -0.130605206968;
            b[3] = 0;
            b[4] = 0.130605206968;
            b[5] = -0.003704122993;
            b[6] = -0.058918593549;
            a[0] = 1;
            a[1] = 0.339893240317;
            a[2] = 1.247471159638;
            a[3] = 0.315004577848;
            a[4] = 0.752494992039;
            a[5] = 0.094346011045;
            a[6] = 0.145214408359;
            int[] temp = new int[t.Length];
            t.CopyTo(temp, 0);
            for (int n = 7; n < temp.Length; n++) //Bandpass Filter
            {
                temp[n] = (int)(b[0] * t[n] + b[1] * t[n - 1] + b[2] * t[n - 2] + b[4] * t[n - 4] + b[5] * t[n - 5] + b[6] * t[n - 6]);
                temp[n] += (int)(-a[1] * temp[n - 1] - a[2] * temp[n - 2] - a[3] * temp[n - 3] - a[4] * temp[n - 4] - a[5] * temp[n - 5] - a[6] * temp[n - 6]);
            }
            t = temp;
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		MotionFilter							       ==
        ==																		   ==
        ==		DESCRIPTION		A 4-tap motion filter for a ScanData array          ==
        ==																		   ==
        ==		ENTRY			ref Radar r - contains previous unfiltered scans  ==
        ==                      ref MRM_SCAN_INFO temp - current unfiltered scan
        ==																		   ==
        ==		RETURN			none                                                ==
        ========================================================================== */
        public static void MotionFilter(ref Radar r, ref MRM_SCAN_INFO temp)
        {
            for (int k = r.UnfilteredScans.Length - 1; k > 0; k--)
            {
                r.UnfilteredScans[k] = r.UnfilteredScans[k - 1];
            }
            r.UnfilteredScans[0] = temp;
            r.UnfilteredScans[0].ScanData = new int[temp.ScanData.Length];
            temp.ScanData.CopyTo(r.UnfilteredScans[0].ScanData, 0);
            for (int i = 1; i < r.UnfilteredScans.Length; i++)
            {
                if (r.UnfilteredScans[i].ScanData != null)
                    for (int j = 0; j < r.UnfilteredScans[i].ScanData.Length; j++)
                    //int[] tarray = new int[temp.ScanData.Length];
                    //for(int j = 3; j < temp.ScanData.Length; j++)
                    {
                        if (temp.ScanData.Length > j)
                            temp.ScanData[j] += (int)(r.FilterCoeffs[i] * r.UnfilteredScans[i].ScanData[j]);
                        //for(int i = 0; i<r.FilterCoeffs.Length; i++)
                        //  tarray[j] += (int)(r.FilterCoeffs[i] * temp.ScanData[j - i]);
                    }
                //temp.ScanData = tarray;
            }
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		KevinFilter				        			       ==
        ==																		   ==
        ==		DESCRIPTION		A moving weighted average filter                 ==
        ==																		   ==
        ==		ENTRY			int[] filtin - the unfiltered input array          ==
        ==                      double[] gauss - the filter window                 ==
        ==                      double[] filtout - the filtered output array       ==
        ==                      out double average - the average value in the output array ==
        ==                      bool db - a flag for conversion to dB scale        ==
        ==																		   ==
        ==		RETURN			the maximum value in the input array               ==
        ========================================================================== */
        public static int KevinFilter(int[] filtin, double[] gauss, double[] filtout, out double average, bool db)
        {
            int max = filtin.Max();
           // double sum = 0.0;
            average = 0.0;
            for (int m = 0; m < filtin.Length; m++)
            {
#if KEVINFILTER
                for (int k = -gauss.Length / 2; k <= gauss.Length / 2; k++)
                {
                    if (m < filtout.Length && m + k >= 0 && m + k < filtin.Length && gauss[gauss.Length / 2 + k] != 0)
                        filtout[m] += ((double)filtin[m + k]) * (((double)filtin[m + k]) / ((double)max)) * gauss[gauss.Length / 2 + k];
                }

#elif INTEGRAL
                    sum += (double)filtin[m];
                   filtout[m] = sum;

#else
                filtout[m] = filtin[m];
#endif
                if (m < filtout.Length)
                    filtout[m] = Math.Abs(filtout[m]);
                if (db)
                    filtout[m] = 10 * Math.Log10(filtout[m] + 1);
                average += filtout[m] / filtout.Length;
            }
            return max;
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		KevinFilter				        			       ==
        ==																		   ==
        ==		DESCRIPTION		A moving weighted average filter                 ==
        ==																		   ==
        ==		ENTRY			int[] filtin - the unfiltered input array          ==
        ==                      double[] gauss - the filter window                 ==
        ==                      double[] filtout - the filtered output array       ==
        ==                      out double average - the average value in the output array ==
        ==                      bool db - a flag for conversion to dB scale        ==
        ==																		   ==
        ==		RETURN			the maximum value in the input array               ==
        ========================================================================== */
        public static double FindStrength(double[] filtin, MRM_SCAN_INFO t, Point loc, Point radar, double offset, double maxstren, double inmax, GraphParams gp)
        {
            double coeff = (double)gp.CmWidth / (double)gp.PixWidth;
            int radX = (gp.PixWidth * radar.X) / gp.CmWidth;
            int radY = (gp.PixHeight * radar.Y) / gp.CmHeight;
            double bitDist = PSPERCM * (coeff * Math.Sqrt((loc.X - radX) * (loc.X - radX) + (loc.Y - radY) * (loc.Y - radY)) - offset); //Pixel's distance from radar 1 in picoseconds
            if (filtin != null)
            {
                int dist = (int)((bitDist - (double)t.ScanStartPS + 12000.0) / (((double)t.ScanStepBins) * PSPERBIN)); //converts picoseconds to range bin index
                if (dist >= filtin.Length)
                    dist = filtin.Length - 1;
                if (dist < 0)
                    dist = 0;
                return (maxstren / inmax) * filtin[dist]; // *(filtin[dist] / inmax);
            }
            else return 1;
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		FilterData				        			       ==
        ==																		   ==
        ==		DESCRIPTION		A function primarily used to execute any desired   ==
        ==                      filters (e.g. KevinFilter) during runtime          ==
        ==																		   ==
        ==		ENTRY			int[] filtin - the unfiltered input array          ==
        ==                      double[] gauss - the filter window                 ==
        ==                      out int[] peaks - used for peak detection          ==
        ==                      bool db - a flag for conversion to dB scale        ==
        ==																		   ==
        ==		RETURN			the filtered output array                          ==
        ========================================================================== */
        public static double[] FilterData(int[] filtin, double[] gauss, out int[] peaks, bool db)
        {
            double[] filtout = new double[filtin.Length];
            peaks = new int[filtin.Length];
            //int count = 0;
#if KEVINFILTER
            for (int a = 0; a < filtin.Length; a++)
                filtin[a] = (int)Math.Abs(filtin[a]);
#endif
            double average;
            int max = Filter.KevinFilter(filtin, gauss, filtout, out average, db);
           // double b;

            int fil = filtout.Length;
            for (int k = 0; k < fil; k++)
            {
                // if (filtout[k] >= b * max)
                //     filtout[k] = max;
            //    if (checkBox2.Checked && double.TryParse(textBox4.Text, out b)) //Thresholding
             //   {
             //       if (filtout[k] < b * max) filtout[k] = 0;
                    //else filtout[k] = 1.0;
            //    }
#if PEAKDETECTION
                        if(k>0 && k<fil - 1 && filtout[k] > filtout[k-1] && filtout[k] > filtout[k+1])
                        {
                            peaks[count++] = k;
                        }
#endif
            }
#if BOOST
                   int[] filtret = new int[filtout.Length];
                    peaks[count] = -1;
                    int j = 0;
            while(peaks[j] != -1)
            {
                filtret[peaks[j]] = 1;
                j++;
            }
            filtout = new double[filtout.Length];
            max = KevinFilter(filtret, gauss, filtout, ref average);
#endif
            //else
            //{
            //    sum = 0.0;
            //    for (int k = 0; k < filtout.Length; k++)
            //    {
            //        double temp = (filtout[k] - average < 0.0 ? 0.0 : filtout[k] - average);
            //        filtout[k] = temp;// -sum;
            //        // sum = temp;

            //    }
            //}
            //double min = filtout.Min();
            //for (int k = 0; k < filtout.Length; k++) filtout[k] -= min;
            //   double maxo = filtout.Max();
            //   for (int a = 0; a < filtout.Length; a++) filtout[a] /= maxo;
            return filtout;
        }

        /* ==========================================================================
        ==																		   ==
        ==		FUNCTION		GenerateKernel				        		       ==
        ==																		   ==
        ==		DESCRIPTION		Generates a filter kernel. Originally gaussian,    ==
        ==                      but now a broad-tailed quasi-laplacian kernel      ==
        ==																		   ==
        ==		ENTRY			double[] GaussianKernel - the kernel               ==
        ==                      int GAUSSIANLENGTH - the length of the kernel      ==
        ==                      double sigma - the parameter for creating the kernel ==
        ==																		   ==
        ==		RETURN			the sum of all elements in the kernel              ==
        ========================================================================== */
        public static double GenerateKernel(double[] GaussianKernel, int GAUSSIANLENGTH, double sigma)
        {
            double sum = 0.0;
            double value = 1.0;
            //for(int k=0;k<GAUSSIANLENGTH;k++)
            for (int k = GAUSSIANLENGTH / 2; k >= 0; k--)
            {
                //GaussianKernel[k] = Math.Exp(-((double)(0.1 * (GAUSSIANLENGTH / 2 - k) * 0.1 * (GAUSSIANLENGTH / 2 - k))) / (2.0 * sigma)) / Math.Sqrt(2 * Math.PI * Math.Abs(0.1*(GAUSSIANLENGTH / 2 - k)) + 0.01);
#if DOUBLE
                GaussianKernel[k] = value;
                GaussianKernel[GAUSSIANLENGTH - k - 1] = value;
#else
                GaussianKernel[k] = (uint)(1.0 / value);
                GaussianKernel[GAUSSIANLENGTH - k - 1] = (uint)(1.0 / value);
#endif
                sum += (k == GAUSSIANLENGTH / 2) ? value : 2 * value;
                value -= (sigma * value) / 100;
            }
#if DOUBLE
            GAUSSIANSUM = sum;
#else
            return Math.Ceiling(sum);
#endif
            /*
            for (int k = 0; k < GAUSSIANLENGTH; k++)
            {
                GaussianKernel[k] /= sum;
            }*/
        }
    }
}
