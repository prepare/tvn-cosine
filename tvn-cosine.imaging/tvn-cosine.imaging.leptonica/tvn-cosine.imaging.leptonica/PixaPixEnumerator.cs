using System;
using System.Collections;
using System.Collections.Generic;

namespace Leptonica
{
    /// <summary>
    /// Pixa Pix enumerator.
    /// </summary>
    public class PixaPixEnumerator : IEnumerator<Pix>, IDisposable
    {
        private readonly Pixa pixa;

        private int position = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixa"></param>
        public PixaPixEnumerator(Pixa pixa)
        {
            this.pixa = pixa;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < pixa.Count);
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
        public Pix Current
        {
            get
            {
                var pointer = Native.DllImports.pixaGetPix(pixa.handleRef, position, InsertionType.COPY);
                if (pointer != IntPtr.Zero)
                    return new Pix(pointer);
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
