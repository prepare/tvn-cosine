using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Pta.h
    /// </summary>
    public class Pta : System.ICloneable, System.IDisposable
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
        public Pta(System.IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public Pta(int size)
            : this(Native.DllImports.ptaCreate(size))
        { }

        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <returns></returns>
        public bool GetPt(int index, out float px, out float py)
        {
            return Native.DllImports.ptaGetPt(handleRef, index, out px, out py) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <returns></returns>
        public bool AddPt(float px, float py)
        {
            return Native.DllImports.ptaAddPt(handleRef, px, py) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemovePt(int index)
        {
            return Native.DllImports.ptaRemovePt(handleRef, index) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            return Native.DllImports.ptaEmpty(handleRef) == 0;
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool InsertPtAt(int index, int x, int y)
        {
            return Native.DllImports.ptaInsertPt(handleRef, index, x, y) == 0;
        }
        #endregion

        #region ICloneable Support
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            throw new NotImplementedException();
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
                Native.DllImports.ptaDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Pta()
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
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
} 