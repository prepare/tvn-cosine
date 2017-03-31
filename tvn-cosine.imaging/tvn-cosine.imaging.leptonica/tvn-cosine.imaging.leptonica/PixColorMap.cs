using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tvn.Cosine.Imaging;

namespace Leptonica
{
    public class PixColorMap : IDisposable, ICloneable, IEnumerable<Color>
    {
        public readonly HandleRef handleRef;

        #region ctors
        public PixColorMap(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        public PixColorMap(int depth)
            : this(Native.DllImports.pixcmapCreate(depth))
        { }
        #endregion

        #region Properties
        public int Depth
        {
            get
            {
                return Native.DllImports.pixcmapGetDepth(handleRef);
            }
        }

        public int Count
        {
            get
            {
                return Native.DllImports.pixcmapGetCount(handleRef);
            }
        }
        #endregion

        #region IEnumerable Support 

        public IEnumerator<Color> GetEnumerator()
        {
            return new PixColorMapColorEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region ICloneable Support
        public object Clone()
        {
            var pixcmap = Native.DllImports.pixcmapCopy(handleRef);
            return new PixColorMap(pixcmap);
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
                Native.DllImports.pixcmapDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        ~PixColorMap()
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
