using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Barcode Decoding dispatcher   
    /// </summary>
    public static class Barcode
    {
        /// <summary>
        /// barcodeDispatchDecoder()
        /// </summary>
        /// <param name="barstr">barstr string of integers in set {1,2,3,4} of bar widths</param>
        /// <param name="format">format L_BF_ANY, L_BF_CODEI2OF5, L_BF_CODE93, ...</param>
        /// <param name="debugflag"></param>
        /// <returns>data string of decoded barcode data, or NULL on error</returns>
        public static string barcodeDispatchDecoder(string barstr, BarcodeFormats format, bool debugflag)
        {
            if (string.IsNullOrWhiteSpace(barstr))
            {
                return null;
            }

            var pointer = Native.DllImports.barcodeDispatchDecoder(barstr, format, debugflag ? 1 : 0);

            if (pointer != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// barcodeFindFormat()
        /// </summary>
        /// <param name="format">format</param>
        /// <returns>true if format is one of those supported; false otherwise</returns>
        public static bool barcodeFormatIsSupported(BarcodeFormats format)
        {
            return Native.DllImports.barcodeFormatIsSupported(format) == 1; 
        }
    }
}
