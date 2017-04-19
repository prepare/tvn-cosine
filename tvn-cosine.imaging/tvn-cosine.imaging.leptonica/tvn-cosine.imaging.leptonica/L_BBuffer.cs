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
    public class L_BBuffer : LeptonicaObjectBase
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

        /// <summary>
        /// (1) Destroys the byte array in the bbuffer and then the bbuffer;
        ///     then nulls the contents of the input ptr.
        /// </summary>
        public void Destroy()
        {
            var toDispose = (IntPtr)this;
            Native.DllImports.bbufferDestroy(ref toDispose);
        }

        /// <summary>
        ///       (1) For a read after write, first remove the written
        ///           bytes by shifting the unwritten bytes in the array,
        ///           then check if there is enough room to add the new bytes.
        ///  If not, realloc with bbufferExpandArray(), resulting
        ///          in a second writing of the unwritten bytes.While less
        ///           efficient, this is simpler than making a special case
        ///           of reallocNew().
        /// </summary>
        /// <param name="src">source memory buffer from which bytes are read</param>
        /// <param name="nbytes">bytes to be read</param>
        /// <returns> true if OK, false on error</returns>
        public bool TryRead(byte[] src, int nbytes)
        {
            return Native.DllImports.bbufferRead((HandleRef)this, src, nbytes) == 0;
        }

        /// <summary>
        /// (1) reallocNew() copies all bb->nalloc bytes, even though only bb->n are data.
        /// </summary>
        /// <param name="nbytes">nbytes  number of bytes to extend array size</param>
        /// <returns> true if OK, false on error</returns>
        public bool TryExtendArray(int nbytes)
        {
            return Native.DllImports.bbufferExtendArray((HandleRef)this, nbytes) == 0;
        }
    }
}