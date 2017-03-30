using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

/* A file containing the commands responsible for communicating with the radars.
 * Refer to the TimeDomain MRM API for more information.
 * http://www.timedomain.com/datasheets/320-0298C%20MRM%20API%20Specification.pdf
 */

namespace RadarPlot
{
    public struct MRM_SET_CONFIG_REQUEST
    {
        public ushort MessageID;
        public uint NodeID;
        public int ScanStartPS, ScanStopPS;
        public ushort ScanResolutions;
        public ushort BaseIntegrationIndex;
        public ushort Seg1NumSamples, Seg2NumSamples, Seg3NumSamples, Seg4NumSamples;
        public byte Seg1IntegMult, Seg2IntegMult, Seg3IntegMult, Seg4IntegMult;
        public byte AntennaMode, TransmitGain, CodeChannel, PersistFlag;
    }

    public struct MRM_SET_CONFIG_CONFIRM
    {
        public ushort MessageID;
        public uint Status;
    }

    public struct MRM_GET_CONFIG_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_GET_CONFIG_CONFIRM
    {
        public ushort MessageID;
        public uint NodeID;
        public int ScanStartPS, ScanStopPS;
        public ushort ScanResolutions;
        public ushort BaseIntegrationIndex;
        public ushort Seg1NumSamples, Seg2NumSamples, Seg3NumSamples, Seg4NumSamples;
        public byte Seg1IntegMult, Seg2IntegMult, Seg3IntegMult, Seg4IntegMult;
        public byte AntennaMode, TransmitGain, CodeChannel, PersistFlag;
        public uint Timestamp, Status;
    }

    public struct MRM_CONTROL_REQUEST
    {
        public ushort MessageID;
        public uint ScanCount;
        public ushort Reserved;
        public uint ScanIntervalTime;
    }

    public struct MRM_CONTROL_CONFIRM
    {
        public ushort MessageID;
        public uint Status;
    }

    public struct MRM_SERVER_CONNECT_REQUEST
    {
        public ushort MessageID;
        public uint MrmIpAddress;
        public ushort MrmIpPort;
        public byte ConnectionType, Reserved;
    }

    public struct MRM_SERVER_CONNECT_CONFIRM
    {
        public ushort MessageID;
        public uint ConnectionStatus;
    }

    public struct MRM_SERVER_DISCONNECT_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_SERVER_DISCONNECT_CONFIRM
    {
        public ushort MessageID;
        public uint Status;
    }

    public struct MRM_SET_FILTER_CONFIG_REQUEST
    {
        public ushort MessageID, FilterMask;
        public byte MotionFilterIndex, Reserved;
    }

    public struct MRM_SET_FILTER_CONFIG_CONFIRM
    {
        public ushort MessageID;
        public uint Status;
    }

    public struct MRM_GET_FILTER_CONFIG_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_GET_FILTER_CONFIG_CONFIRM
    {
        public ushort MessageID, FilterMask;
        public byte MotionFilterIndex, Reserved;
        public uint Status;
    }

    public struct MRM_GET_STATUSINFO_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_GET_STATUSINFO_CONFIRM
    {
        public ushort MessageID;
        public byte MrmVersionMajor, MrmVersionMinor;
        public ushort MrmVersionBuild;
        public byte UwbKernelMajor, UwbKernelMinor;
        public ushort UwbKernelBuild;
        public byte FpgaFirmwareVersion, FpgaFirmwareYear, FpgaFirmwareMonth, FpgaFirmwareDay;
        public uint SerialNumber;
        public byte BoardRevision, PowerOnBitTestResult, TransmitterConfiguration;
        public int Temperature;
        public uint Status;
    }

    public struct MRM_REBOOT_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_REBOOT_CONFIRM
    {
        public ushort MessageID;
    }

    public struct MRM_SET_OPMODE_REQUEST
    {
        public ushort MessageID;
        public uint OperationalMode;
    }

    public struct MRM_SET_OPMODE_CONFIRM
    {
        public ushort MessageID;
        public uint OperationalMode, Status;
    }

    public struct MRM_SCAN_INFO
    {
        public ushort MessageID;
        public uint SourceID, Timestamp, Reserved1, Reserved2, Reserved3, Reserved4;
        public int ScanStartPS, ScanStopPS;
        public short ScanStepBins;
        public byte ScanType, Reserved5, AntennaID, OperationalMode;
        public ushort NumberOfSamplesInMessage;
        public uint NumberOfSamplesTotal;
        public ushort MessageIndex, NumberOfMessagesTotal;
        public int[] ScanData;
    }

    public struct MRM_DETECTION
    {
        public ushort Index, Magnitude;
    }

    public struct MRM_DETECTION_LIST_INFO
    {
        public ushort MessageID, NumberOfDetections;
        public MRM_DETECTION[] Detections;
    }

    public struct MRM_SET_SLEEPMODE_REQUEST
    {
        public ushort MessageID;
        public uint SleepMode;
    }

    public struct MRM_SET_SLEEPMODE_CONFIRM
    {
        public ushort MessageID;
        public uint Status;
    }

    public struct MRM_GET_SLEEPMODE_REQUEST
    {
        public ushort MessageID;
    }

    public struct MRM_GET_SLEEPMODE_CONFIRM
    {
        public ushort MessageID;
        public uint SleepMode, Status;
    }

    public struct MRM_READY_INFO
    {
        public ushort MessageID;
    }

    public static class RadarRequest
    {
        public static bool CommandOut = false;
        public static bool SendMRM_SET_CONFIG_REQUEST(Radar p, MRM_SET_CONFIG_REQUEST t)
        {
            try
            {
                byte[] b = new byte[40];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x24;
                b[4] = 0x10; b[5] = 0x01;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)t.MessageID;
                b[8] = (byte)(t.NodeID >> 24);
                b[9] = (byte)(t.NodeID >> 16);
                b[10] = (byte)(t.NodeID >> 8);
                b[11] = (byte)(t.NodeID);
                b[12] = (byte)(t.ScanStartPS >> 24);
                b[13] = (byte)(t.ScanStartPS >> 16);
                b[14] = (byte)(t.ScanStartPS >> 8);
                b[15] = (byte)(t.ScanStartPS);
                b[16] = (byte)(t.ScanStopPS >> 24);
                b[17] = (byte)(t.ScanStopPS >> 16);
                b[18] = (byte)(t.ScanStopPS >> 8);
                b[19] = (byte)(t.ScanStopPS);
                b[20] = (byte)(t.ScanResolutions >> 8);
                b[21] = (byte)t.ScanResolutions;
                b[22] = (byte)(t.BaseIntegrationIndex >> 8);
                b[23] = (byte)t.BaseIntegrationIndex;
                b[24] = (byte)(t.Seg1NumSamples >> 8);
                b[25] = (byte)t.Seg1NumSamples;
                b[26] = (byte)(t.Seg2NumSamples >> 8);
                b[27] = (byte)t.Seg2NumSamples;
                b[28] = (byte)(t.Seg3NumSamples >> 8);
                b[29] = (byte)t.Seg3NumSamples;
                b[30] = (byte)(t.Seg4NumSamples >> 8);
                b[31] = (byte)t.Seg4NumSamples;
                b[32] = t.Seg1IntegMult;
                b[33] = t.Seg2IntegMult;
                b[34] = t.Seg3IntegMult;
                b[35] = t.Seg4IntegMult;
                b[36] = t.AntennaMode;
                b[37] = t.TransmitGain;
                b[38] = t.CodeChannel;
                b[39] = t.PersistFlag;
                    p.Send(b);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReceiveMRM_SET_CONFIG_CONFIRM(string b, out MRM_SET_CONFIG_CONFIRM t)
        {
            t = new MRM_SET_CONFIG_CONFIRM();
            byte[] s = Encoding.Default.GetBytes(b);
            t.MessageID = Utility.ToUshort(s, 6);
            t.Status = Utility.ToUint(s, 8);
            return true;
        }

        public static bool SendMRM_GET_CONFIG_REQUEST(Radar p, MRM_GET_CONFIG_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0x10; b[5] = 0x02;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)t.MessageID;
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_CONTROL_REQUEST(Radar p, MRM_CONTROL_REQUEST t)
        {
            try
            {
                byte[] b = new byte[16];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x0C;
                b[4] = 0x10; b[5] = 0x03;
                b[6] = (byte)(t.ScanCount >> 24);
                b[7] = (byte)(t.ScanCount >> 16);
                b[8] = (byte)(t.ScanCount >> 8);
                b[9] = (byte)(t.ScanCount);
                b[10] = (byte)(t.Reserved >> 8);
                b[11] = (byte)(t.Reserved);
                b[12] = (byte)(t.ScanIntervalTime >> 24);
                b[13] = (byte)(t.ScanIntervalTime >> 16);
                b[14] = (byte)(t.ScanIntervalTime >> 8);
                b[15] = (byte)(t.ScanIntervalTime);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReceiveMRM_CONTROL_CONFIRM(string b, out MRM_CONTROL_CONFIRM t)
        {

            t = new MRM_CONTROL_CONFIRM();
            try
            {
                byte[] s = Encoding.Default.GetBytes(b);
                t.MessageID = Utility.ToUshort(s, 0);
                t.Status = Utility.ToUint(s, 2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_SERVER_CONNECT_REQUEST(Radar p, MRM_SERVER_CONNECT_REQUEST t)
        {
            try
            {
                byte[] b = new byte[16];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x0C;
                b[4] = 0x10; b[5] = 0x04;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                b[8] = (byte)(t.MrmIpAddress >> 24);
                b[9] = (byte)(t.MrmIpAddress >> 16);
                b[10] = (byte)(t.MrmIpAddress >> 8);
                b[11] = (byte)(t.MrmIpAddress);
                b[12] = (byte)(t.MrmIpPort >> 8);
                b[13] = (byte)(t.MrmIpPort);
                b[14] = t.ConnectionType;
                b[15] = t.Reserved;
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_SERVER_DISCONNECT_REQUEST(Radar p, MRM_SERVER_DISCONNECT_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0x10; b[5] = 0x05;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_SET_FILTER_CONFIG_REQUEST(Radar p, MRM_SET_FILTER_CONFIG_REQUEST t)
        {
            try
            {
                byte[] b = new byte[12];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x08;
                b[4] = 0x10; b[5] = 0x06;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                b[8] = (byte)(t.FilterMask >> 8);
                b[9] = (byte)(t.FilterMask);
                b[10] = t.MotionFilterIndex;
                b[11] = t.Reserved;
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_GET_FILTER_CONFIG_REQUEST(Radar p, MRM_GET_FILTER_CONFIG_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0x10; b[5] = 0x07;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_GET_STATUSINFO_REQUEST(Radar p, MRM_GET_STATUSINFO_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0xF0; b[5] = 0x01;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReceiveMRM_GET_STATUS_INFO_CONFIRM(string b, out MRM_GET_STATUSINFO_CONFIRM t)
        {
            t = new MRM_GET_STATUSINFO_CONFIRM();
            byte[] s = Encoding.Default.GetBytes(b);
            t.MessageID = Utility.ToUshort(s, 6);
            t.MrmVersionMajor = (byte)s[8];
            t.MrmVersionMinor = (byte)s[9];
            t.MrmVersionBuild = Utility.ToUshort(s, 10);
            t.UwbKernelMajor = (byte)s[12];
            t.UwbKernelMinor = (byte)s[13];
            t.UwbKernelBuild = Utility.ToUshort(s, 14);
            t.FpgaFirmwareVersion = (byte)s[16];
            t.FpgaFirmwareYear = (byte)s[17];
            t.FpgaFirmwareMonth = (byte)s[18];
            t.FpgaFirmwareDay = (byte)s[19];
            t.SerialNumber = Utility.ToUint(s, 20);
            t.BoardRevision = (byte)s[21];
            t.PowerOnBitTestResult = (byte)s[22];
            t.TransmitterConfiguration = (byte)s[23];
            t.Temperature = Utility.ToInt(s, 24);
            t.Status = Utility.ToUint(s, 28);
            return true;
        }

        public static bool SendMRM_REBOOT_REQUEST(Radar p, MRM_REBOOT_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0xF0; b[5] = 0x02;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_SET_OPMODE_REQUEST(Radar p, MRM_SET_OPMODE_REQUEST t)
        {
            try
            {
                byte[] b = new byte[12];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x08;
                b[4] = 0xF0; b[5] = 0x03;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                b[8] = (byte)(t.OperationalMode >> 24);
                b[9] = (byte)(t.OperationalMode >> 16);
                b[10] = (byte)(t.OperationalMode >> 8);
                b[11] = (byte)(t.OperationalMode);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReceiveMRM_SCAN_INFO(string b, out MRM_SCAN_INFO t)
        {
            try
            {
                byte[] s = Encoding.Default.GetBytes(b);
                t.MessageID = Utility.ToUshort(s, 6);
                t.SourceID = Utility.ToUint(s, 8);
                t.Timestamp = Utility.ToUint(s, 12);
                t.Reserved1 = Utility.ToUint(s, 16);
                t.Reserved2 = Utility.ToUint(s, 20);
                t.Reserved3 = Utility.ToUint(s, 24);
                t.Reserved4 = Utility.ToUint(s, 28);
                t.ScanStartPS = Utility.ToInt(s, 32);
                t.ScanStopPS = Utility.ToInt(s, 36);
                t.ScanStepBins = Utility.ToShort(s, 40);
                t.ScanType = (byte)s[42];
                t.Reserved5 = (byte)s[43];
                t.AntennaID = (byte)s[44];
                t.OperationalMode = (byte)s[45];
                t.NumberOfSamplesInMessage = Utility.ToUshort(s, 46);
                t.NumberOfSamplesTotal = Utility.ToUint(s, 48);
                t.MessageIndex = Utility.ToUshort(s, 52);
                t.NumberOfMessagesTotal = Utility.ToUshort(s, 54);
                t.ScanData = new int[(s.Length - 56)/4];
                for (int a = 56; a <= s.Length - 4; a += 4)
                    t.ScanData[(a - 56) / 4] = Utility.ToInt(s, a);
                return true;
            }
            catch
            {
                t.MessageID = 0;
                t.SourceID = 0;
                t.Timestamp = 0;
                t.Reserved1 = 0;
                t.Reserved2 = 0;
                t.Reserved3 = 0;
                t.Reserved4 = 0;
                t.ScanStartPS = 0;
                t.ScanStopPS = 0;
                t.ScanStepBins = 0;
                t.ScanType = 0;
                t.Reserved5 = 0;
                t.AntennaID = 0;
                t.OperationalMode = 0;
                t.NumberOfSamplesInMessage = 0;
                t.NumberOfSamplesTotal = 0;
                t.MessageIndex = 0;
                t.NumberOfMessagesTotal = 0;
                t.ScanData = new int[350];
                return false;
            }
        }

        public static bool SendMRM_SCAN_INFO(out byte[] b, MRM_SCAN_INFO t)
        {
            try
            {
                b = new byte[54 + 4 * t.ScanData.Length];
                Utility.FromUshort(0xA5A5, b, 0);
                Utility.FromUshort((ushort)(b.Length - 4), b, 2);
                Utility.FromUshort(t.MessageID, b, 4);
                Utility.FromUint(t.SourceID, b, 6);
                Utility.FromUint(t.Timestamp, b, 10);
                Utility.FromUint(t.Reserved1, b, 14);
                Utility.FromUint(t.Reserved2, b, 18);
                Utility.FromUint(t.Reserved3, b, 22);
                Utility.FromUint(t.Reserved4, b, 26);
                Utility.FromInt(t.ScanStartPS, b, 30);
                Utility.FromInt(t.ScanStopPS, b, 34);
                Utility.FromShort(t.ScanStepBins, b, 38);
                b[40] = t.ScanType;
                b[41] = t.Reserved5;
                b[42] = t.AntennaID;
                b[43] = t.OperationalMode;
                Utility.FromUshort(t.NumberOfSamplesInMessage, b, 44);
                Utility.FromUint(t.NumberOfSamplesTotal, b, 46);
                Utility.FromUshort(t.MessageIndex, b, 50);
                Utility.FromUshort(t.NumberOfMessagesTotal, b, 52);
                for (int k = 54; k < b.Length - 3; k += 4)
                    Utility.FromInt(t.ScanData[(k - 54) / 4], b, k);
                return true;
            }
            catch
            {
                b = null;
                return false;
            }
        }

        public static bool SendMRM_SET_SLEEPMODE_REQUEST(Radar p, MRM_SET_SLEEPMODE_REQUEST t)
        {
            try
            {
                byte[] b = new byte[12];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x08;
                b[4] = 0xF0; b[5] = 0x05;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                b[8] = (byte)(t.SleepMode >> 24);
                b[9] = (byte)(t.SleepMode >> 16);
                b[10] = (byte)(t.SleepMode >> 8);
                b[11] = (byte)(t.SleepMode);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMRM_GET_SLEEPMODE_REQUEST(Radar p, MRM_GET_SLEEPMODE_REQUEST t)
        {
            try
            {
                byte[] b = new byte[8];
                b[0] = b[1] = 0xA5;
                b[2] = 0x00; b[3] = 0x04;
                b[4] = 0xF0; b[5] = 0x05;
                b[6] = (byte)(t.MessageID >> 8);
                b[7] = (byte)(t.MessageID);
                p.Send(b);
                CommandOut = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}