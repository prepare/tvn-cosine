using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// 
    /// </summary>
    public class Numa : System.ICloneable, System.IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly HandleRef handleRef;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        public Numa(System.IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Explicitly cast IntPtr to Numa
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Numa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Numa(pointer);
            }
            else
            {
                return null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }


                // var toDispose = handleRef.Handle;
                //  Native.DllImports.boxDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Numa()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
