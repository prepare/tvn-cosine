using System;

namespace Leptonica
{
    /// <summary>
    /// Access within an array of 32-bit words     
    /// </summary>
    public static class ArrayAccess
    {
        /// <summary>
        /// l_getDataBit()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        /// <returns>val of the nth 1-bit pixel.</returns>
        public static int l_getDataBit(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataBit(line, n);
        }

        /// <summary>
        /// l_setDataBit()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        public static void l_setDataBit(IntPtr line, int n)
        {
            Native.DllImports.l_setDataBit(line, n);
        }

        /// <summary>
        /// l_clearDataBit()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        public static void l_clearDataBit(IntPtr line, int n)
        {
            Native.DllImports.l_clearDataBit(line, n);
        }

        /// <summary>
        /// l_setDataBitVal()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        /// <param name="val">val   val to be inserted: 0 or 1</param>
        public static void l_setDataBitVal(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataBitVal(line, n, val);
        }

        /// <summary>
        /// l_getDataDibit()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        /// <returns>val of the nth 2-bit pixel.</returns>
        public static int l_getDataDibit(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataBit(line, n);
        }

        /// <summary>
        /// l_setDataDibit()
        /// </summary>
        /// <param name="line">line  ptr to beginning of data line</param>
        /// <param name="n">n     pixel index</param>
        /// <param name="val">val   val to be inserted: 0 - 3</param>
        public static void l_setDataDibit(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataDibit(line, n, val);
        }

        /// <summary>
        /// Action: sets the 2-bit pixel to 0
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        public static void l_clearDataDibit(IntPtr line, int n)
        {
            Native.DllImports.l_clearDataDibit(line, n);
        }

        /// <summary>
        /// l_getDataQbit()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <returns>val of the nth 4-bit pixel.</returns>
        public static int l_getDataQbit(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataQbit(line, n);
        }

        /// <summary>
        /// l_setDataQbit()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <param name="val">val   val to be inserted: 0 - 0xf</param>
        public static void l_setDataQbit(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataQbit(line, n, val);
        }

        /// <summary>
        /// Action: sets the 4-bit pixel to 0
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        public static void l_clearDataQbit(IntPtr line, int n)
        {
            Native.DllImports.l_clearDataQbit(line, n);
        }

        /// <summary>
        /// l_getDataByte(()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <returns>value of the n-th byte pixel</returns>
        public static int l_getDataByte(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataByte(line, n);
        }

        /// <summary>
        /// l_setDataByte()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <param name="val">val   val to be inserted: 0 - 0xff</param>
        public static void l_setDataByte(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataByte(line, n, val);
        }

        /// <summary>
        /// l_getDataTwoBytes()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <returns>value of the n-th 2-byte pixel</returns>
        public static int l_getDataTwoBytes(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataTwoBytes(line, n);
        }

        /// <summary>
        /// l_setDataTwoBytes()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <param name="val">val to be inserted: 0 - 0xffff</param>
        public static void l_setDataTwoBytes(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataTwoBytes(line, n, val);
        }

        /// <summary>
        /// l_getDataFourBytes()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <returns>value of the n-th 4-byte pixel</returns>
        public static int l_getDataFourBytes(IntPtr line, int n)
        {
            return Native.DllImports.l_getDataFourBytes(line, n);
        }

        /// <summary>
        /// l_setDataFourBytes()
        /// </summary>
        /// <param name="line">ptr to beginning of data line</param>
        /// <param name="n">pixel index</param>
        /// <param name="val">val to be inserted: 0 - 0xffffffff</param>
        public static void l_setDataFourBytes(IntPtr line, int n, int val)
        {
            Native.DllImports.l_setDataFourBytes(line, n, val);
        }
    }
}
