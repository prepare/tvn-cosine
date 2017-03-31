using System;
using System.Runtime.InteropServices;

namespace Tesseract
{
    public class ChoiceIterator : IDisposable
    {
        internal readonly HandleRef handleRef;

        #region Ctors
        internal ChoiceIterator(ResultIterator resultIterator)
        {
            handleRef = new HandleRef(this, Native.DllImports.TessResultIteratorGetChoiceIterator(resultIterator.handleRef));
        }
        #endregion

        public float Confidence()
        {
            return Native.DllImports.TessChoiceIteratorConfidence(handleRef);
        }

        public string GetUTF8Text()
        {
            IntPtr pointer = Native.DllImports.TessChoiceIteratorGetUTF8Text(handleRef);
            if (pointer != IntPtr.Zero)
            {
                string returnObject = Marshal.PtrToStringAnsi(pointer);
                Native.DllImports.TessDeleteText(pointer);
                return returnObject;
            }
            else
            {
                return null;
            }
        }

        public bool Next()
        {
            return Native.DllImports.TessChoiceIteratorNext(handleRef) == 1 ? true : false;
        }

        #region IDisposable Support
        public void Dispose()
        {
            if (handleRef.Handle != null && handleRef.Handle != IntPtr.Zero)
            {
                Native.DllImports.TessChoiceIteratorDelete(handleRef);
            }
        }
        #endregion
    }
}
