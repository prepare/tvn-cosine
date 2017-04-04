using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Pixa.h
    /// </summary>
    public class Pixa : IDisposable, ICloneable, IEnumerable<Pix>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly HandleRef handleRef;

        #region ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        public Pixa(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public Pixa(int size)
            : this(Native.DllImports.pixaCreate(size))
        { }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return Native.DllImports.pixaGetCount(handleRef);
            }
        }
        #endregion

        #region IEnumerable Support 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Pix> GetEnumerator()
        {
            return new PixaPixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region ICloneable Support
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var pixa = Native.DllImports.pixaCopy(handleRef, InsertionType.COPY);
            return new Pixa(pixa);
        }
        #endregion

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

                var toDispose = handleRef.Handle;
                Native.DllImports.pixaDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Pixa()
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
