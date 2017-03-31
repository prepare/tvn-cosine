using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leptonica
{
   public class BoxaBoxEnumerator : IEnumerator<Box>
    {
        private readonly Boxa boxa;

        private int position = -1;

        public BoxaBoxEnumerator(Boxa boxa)
        {
            this.boxa = boxa;
        }

        public bool MoveNext()
        {
            position++;
            return (position < boxa.Count);
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

        public Box Current
        {
            get
            {
                var pointer = Native.DllImports.boxaGetBox(boxa.handleRef, position, InsertionType.CLONE);
                if (pointer != IntPtr.Zero)
                    return new Box(pointer);
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
