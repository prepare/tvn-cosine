using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace leptonica.net
{
    public class Pixa : IDisposable, ICloneable, IEnumerable<Pix>
    {
        public readonly HandleRef handleRef;

        #region ctors
        public Pixa(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        public Pixa(int size)
            : this(Native.DllImports.pixaCreate(size))
        { }
        #endregion

        #region Properties
        public int Count
        {
            get
            {
                return Native.DllImports.pixaGetCount(handleRef);
            }
        } 
        #endregion

        #region IEnumerable Support 

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
        public object Clone()
        {
            var pixa= Native.DllImports.pixaCopy(handleRef, InsertionType.COPY);
            return new Pixa(pixa);
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

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

        ~Pixa()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
