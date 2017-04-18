using System;
using System.Collections;
using System.Collections.Generic;

namespace Leptonica
{
    /// <summary>
    /// Box Enumerator of Boxa
    /// </summary>
    public class BoxaBoxEnumerator : IEnumerator<Box>
    {
        private readonly Boxa boxa;

        private int position = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxa"></param>
        public BoxaBoxEnumerator(Boxa boxa)
        {
            this.boxa = boxa;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < boxa.Count);
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
        public Box Current
        {
            get
            {
                return (Box)Native.DllImports.boxaGetBox(boxa.handleRef, position, InsertionType.CLONE); 
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
