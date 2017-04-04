using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tvn.Cosine.Imaging;

namespace Leptonica
{
    /// <summary>
    /// PixColorMap.
    /// </summary>
    public class PixColorMap : IDisposable, ICloneable, IEnumerable<Color>
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
        public PixColorMap(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depth"></param>
        public PixColorMap(int depth)
            : this(Native.DllImports.pixcmapCreate(depth))
        { }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Depth
        {
            get
            {
                return Native.DllImports.pixcmapGetDepth(handleRef);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return Native.DllImports.pixcmapGetCount(handleRef);
            }
        }
        #endregion

        #region IEnumerable Support 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var pixcmap = Native.DllImports.pixcmapCopy(handleRef);
            return new PixColorMap(pixcmap);
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
                Native.DllImports.pixcmapDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~PixColorMap()
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
