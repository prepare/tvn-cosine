using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary> 
    /// The bbuffer is an implementation of a byte queue.
    ///    The bbuffer holds a byte array from which bytes are
    ///    processed in a first-in/first-out fashion.As with
    ///    any queue, bbuffer maintains two "pointers," one to the
    ///    tail of the queue (where you read new bytes onto it)
    ///    and one to the head of the queue(where you start from
    ///    when writing bytes out of it. 
    /// </summary>
    public class L_BBuffer : LeptonicaObjectBase, IDisposable 
    {
        /// <summary>
        ///       (1) If a buffer address is given, you should read all the data in.
        ///       (2) Allocates a bbuffer with associated byte array of
        ///  the given size.If a buffer address is given,
        /// 
        /// it then reads the number of bytes into the byte array.
        /// </summary>
        /// <param name="indata">indata address in memory [optional]</param>
        /// <param name="nalloc">nalloc size of byte array to be alloc'd 0 for default</param>
        public L_BBuffer(byte[] indata, int nalloc)
            : base(Native.DllImports.bbufferCreate(indata, nalloc))
        { }
         
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// bbufferDestroy()
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

                var toDispose = handleRef.Handle;
                Native.DllImports.bbufferDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        ~L_BBuffer()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
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