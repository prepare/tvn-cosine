using System;
using System.Runtime.InteropServices;

namespace tvn_cosine.ocr.tesseract
{
    public class MutableIterator : ResultIterator
    {
        #region Ctors
        internal MutableIterator(TessBaseAPI tessBaseApi)
        {
            var pointer = Native.DllImports.TessBaseAPIGetMutableIterator(tessBaseApi.handleRef);
            if (pointer == IntPtr.Zero)
                throw new ArgumentNullException("TessBaseAPIGetMutableIterator returned null");

            handleRef = new HandleRef(this, pointer);
        }
        #endregion
    }
}
