using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_Desktop_App.HardwareAPI
{
    public interface IFingerPrintReader
    {
        IntPtr? OpenDevice();
        void CloseDevice();

        bool IsFingerPresent();

        byte[] ScanFinger();

    }

    public class DeviceNotConnectedException: Exception{
        public DeviceNotConnectedException(string Message)
        {
            new Exception(Message);
        }
    }

    public class DeviceScanException : Exception
    {
        private int _errorCode;

            public DeviceScanException(int errorCode)
        {
            _errorCode = errorCode;
            new Exception("Scan failed with error # " + errorCode);
        }
        public int DeviceErrorCode { get {
                return _errorCode;
            } }
    }

}


//[DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
//public static extern IntPtr ftrScanOpenDevice();


//[DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
//public static extern void ftrScanCloseDevice(IntPtr ftrHandle);

//[DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
//public static extern bool ftrScanGetImageSize(IntPtr ftrHandle, ref PFTRSCAN_IMAGE_SIZE pImageSize);

//[DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
//public static extern bool ftrScanGetFrame(IntPtr ftrHandle, byte[] pBuffer, IntPtr pFrameParameters);

//[DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
//public static extern bool ftrScanIsFingerPresent(IntPtr ftrHandle, IntPtr pFrameParameters);

//[DllImport("kernel32.dll")]
//static extern int GetLastError();

