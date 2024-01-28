using Biometrics_Desktop_App.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_Desktop_App.HardwareAPI
{



    class FutronicFS80Scanner : IFingerPrintReader, IDisposable
    {
        //public static IntPtr memPtr = Marshal.AllocHGlobal (Marshal.SizeOf(typeof(PFTRSCAN_FRAME_PARAMETERS)));

        IntPtr? hdc = null;
        public FutronicFS80Scanner()
        {
        }

        public static Bitmap RawToBitmap(Size imageSize, byte[] rawImageData, bool invertColors)
        {

            Bitmap finalBitmap = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format24bppRgb);
            var tempBitmap = new Bitmap(finalBitmap.Width, finalBitmap.Height, PixelFormat.Format8bppIndexed);
            ColorPalette ncp = tempBitmap.Palette;
            for (int i = 0; i < 256; i++)
                ncp.Entries[i] = Color.FromArgb(255, i, i, i);
            tempBitmap.Palette = ncp;
            for (int y = 0; y < finalBitmap.Height; y++)
            {
                for (int x = 0; x < finalBitmap.Width; x++)
                {
                    int Value = rawImageData[x + (y * finalBitmap.Width)];
                    Color pxColor = ncp.Entries[Value];
                    if (!invertColors)
                    {
                        finalBitmap.SetPixel(x, y, pxColor);
                    }
                    else
                    {
                        finalBitmap.SetPixel(x, y, Color.FromArgb(255 - pxColor.R, 255 - pxColor.G, 255 - pxColor.B));
                    }
                }
            }
            return finalBitmap;
        }



        public void CloseDevice()
        {
            if (hdc.HasValue)
            {
                try
                {
                    ftrScanCloseDevice(hdc.Value);
                    hdc = null;
                }
                catch (Exception ex) { }
            }

        }

        public bool IsFingerPresent()
        {
            if (!hdc.HasValue) throw new DeviceNotConnectedException("Device not connected!");
            using (StructWrapper p = new StructWrapper(typeof(PFTRSCAN_FRAME_PARAMETERS)))
            {
                bool isFingerPresent = ftrScanIsFingerPresent(hdc.Value, p);
                return isFingerPresent;
            }
        }

        public IntPtr? OpenDevice()
        {
            hdc = ftrScanOpenDevice();
            if ((int)hdc == 0)
            {
                hdc = null;
            }
            return hdc;
        }

        Size? _size = null;

        public Size imageSize
        {
            get
            {
                if (!hdc.HasValue) throw new DeviceNotConnectedException("Device not connected!");
                if (!_size.HasValue)
                {
                    PFTRSCAN_IMAGE_SIZE size = new PFTRSCAN_IMAGE_SIZE();
                    if (ftrScanGetImageSize(hdc.Value, ref size))
                    {
                        _size = new Size(size.nWidth, size.nHeight);
                    }
                    return _size.Value;
                }
                else
                {
                    return _size.Value;
                }
            }
        }


        PFTRSCAN_FRAME_PARAMETERS frameParameters = new PFTRSCAN_FRAME_PARAMETERS(); // Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PFTRSCAN_FRAME_PARAMETERS)));


        public byte[] ScanFinger()
        {
            if (!hdc.HasValue) throw new DeviceNotConnectedException("Device not connected!");

            
            byte[] imageBuffer = new byte[imageSize.Width * imageSize.Height];
            // IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PFTRSCAN_FRAME_PARAMETERS)));
            using (StructWrapper p = new StructWrapper(typeof(PFTRSCAN_FRAME_PARAMETERS)))
            {

                if (ftrScanGetFrame(hdc.Value, imageBuffer, p))
                {
                    return imageBuffer;
                }
                else
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new DeviceScanException(errorCode);
                }
            }
        }


        const int FTR_ERROR_EMPTY_FRAME = 4306;
        const int FTR_ERROR_MOVABLE_FINGER = 0x20000001;
        const int FTR_ERROR_NO_FRAME = 0x20000002;
        const int FTR_ERROR_USER_CANCELED = 0x20000003;
        const int FTR_ERROR_HARDWARE_INCOMPATIBLE = 0x20000004;
        const int FTR_ERROR_FIRMWARE_INCOMPATIBLE = 0x20000005;
        const int FTR_ERROR_INVALID_AUTHORIZATION_CODE = 0x20000006;

        /* Other return codes are Windows-compatible */
        const int ERROR_NO_MORE_ITEMS = 259;                // ERROR_NO_MORE_ITEMS
        const int ERROR_NOT_ENOUGH_MEMORY = 8;              // ERROR_NOT_ENOUGH_MEMORY
        const int ERROR_NO_SYSTEM_RESOURCES = 1450;         // ERROR_NO_SYSTEM_RESOURCES
        const int ERROR_TIMEOUT = 1460;                     // ERROR_TIMEOUT
        const int ERROR_NOT_READY = 21;                     // ERROR_NOT_READY
        const int ERROR_BAD_CONFIGURATION = 1610;           // ERROR_BAD_CONFIGURATION
        const int ERROR_INVALID_PARAMETER = 87;             // ERROR_INVALID_PARAMETER
        const int ERROR_CALL_NOT_IMPLEMENTED = 120;         // ERROR_CALL_NOT_IMPLEMENTED
        const int ERROR_NOT_SUPPORTED = 50;                 // ERROR_NOT_SUPPORTED
        const int ERROR_WRITE_PROTECT = 19;                 // ERROR_WRITE_PROTECT
        const int ERROR_MESSAGE_EXCEEDS_MAX_SIZE = 4336;    // ERROR_MESSAGE_EXCEEDS_MAX_SIZE

        /* constants for CreateDIBitmap */
        const int CBM_INIT = 0x04;   /* initialize bitmap */

        /* DIB color table identifiers */

        const int DIB_RGB_COLORS = 0; /* color table in RGBs */
        const int DIB_PAL_COLORS = 1; /* color table in palette indices */
        const int BI_RGB = 0;
        const int BI_RLE8 = 1;
        const int BI_RLE4 = 2;
        const int BI_BITFIELDS = 3;
        const int BI_JPEG = 4;
        const int BI_PNG = 5;



        [DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ftrScanOpenDevice();


        [DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
        public static extern void ftrScanCloseDevice(IntPtr ftrHandle);

        [DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto)]
        public static extern bool ftrScanGetImageSize(IntPtr ftrHandle, ref PFTRSCAN_IMAGE_SIZE pImageSize);

        [DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ftrScanGetFrame(IntPtr ftrHandle, byte[] pBuffer, IntPtr pFrameParameters);

        [DllImport("ftrScanAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ftrScanIsFingerPresent(IntPtr ftrHandle, IntPtr pFrameParameters);

        [DllImport("kernel32.dll")]
        static extern int GetLastError();

        public void Dispose()
        {

        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PFTRSCAN_IMAGE_SIZE
    {
        public int nWidth;
        public int nHeight;
        public int nImageSize;
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct FTRSCAN_FAKE_REPLICA_PARAMETERS
    {
        public bool bCalculated;
        public int nCalculatedSum1;
        public int nCalculatedSumFuzzy;
        public int nCalculatedSumEmpty;
        public int nCalculatedSum2;
        public double dblCalculatedTremor;
        public double dblCalculatedValue;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PFTRSCAN_FRAME_PARAMETERS
    {
        public int nContrastOnDose2;
        public int nContrastOnDose4;
        public int nDose;
        public int nBrightnessOnDose1;
        public int nBrightnessOnDose2;
        public int nBrightnessOnDose3;
        public int nBrightnessOnDose4;
        public FTRSCAN_FAKE_REPLICA_PARAMETERS FakeReplicaParams;
        public byte[] Reserved;
    }


}
