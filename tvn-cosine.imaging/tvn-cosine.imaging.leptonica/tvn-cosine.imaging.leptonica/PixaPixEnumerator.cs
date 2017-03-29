using System;
using System.Collections;
using System.Collections.Generic;

namespace leptonica.net
{
    public class PixaPixEnumerator : IEnumerator<Pix>, IDisposable
    {
        private readonly Pixa pixa;

        private int position = -1;

        public PixaPixEnumerator(Pixa pixa)
        {
            this.pixa = pixa;
        }

        public bool MoveNext()
        {
            position++;
            return (position < pixa.Count);
        }
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
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
