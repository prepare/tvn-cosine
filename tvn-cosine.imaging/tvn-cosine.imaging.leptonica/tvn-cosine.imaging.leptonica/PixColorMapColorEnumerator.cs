using System;
using System.Collections;
using System.Collections.Generic;
using Tvn.Cosine.Imaging;

namespace Leptonica
{
    /// <summary>
    /// PixColorMapColorEnumerator.
    /// </summary>
    public class PixColorMapColorEnumerator : IEnumerator<Color>, IDisposable
    {
        private readonly PixColorMap pixColorMap;

        private int position = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixColorMap"></param>
        public PixColorMapColorEnumerator(PixColorMap pixColorMap)
        {
            this.pixColorMap = pixColorMap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < pixColorMap.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color Current
        {
            get
            {
                int red, green, blue, alpha;

                if (Native.DllImports.pixcmapGetRGBA(pixColorMap.handleRef, position, out red, out green, out blue, out alpha) != 0)
                    return new Color((byte)alpha, (byte)green, (byte)blue, (byte)red);
                else
                    throw new ArgumentOutOfRangeException();
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

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
