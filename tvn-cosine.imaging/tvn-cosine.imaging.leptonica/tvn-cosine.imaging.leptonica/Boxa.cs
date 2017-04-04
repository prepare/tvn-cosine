using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// boxa.h
    /// </summary>
    public class Boxa : IDisposable, IEnumerable<Box>, ICloneable
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
        public Boxa(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public Boxa(int size)
            : this(Native.DllImports.boxaCreate(size))
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
                return Native.DllImports.boxaGetCount(handleRef);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Box this[int index]
        {
            get
            {
                return GetBox(index);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Box GetBox(int index)
        {
            var pointer = Native.DllImports.boxaGetBox(handleRef, index, InsertionType.CLONE);
            if (pointer != IntPtr.Zero)
            {
                return new Box(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool AddBox(Box box)
        {
            return Native.DllImports.boxaAddBox(handleRef, box.handleRef, InsertionType.COPY) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ExtendArray()
        {
            return Native.DllImports.boxaExtendArray(handleRef) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool ExtendArrayToSize(int size)
        {
            return Native.DllImports.boxaExtendArrayToSize(handleRef, size) == 0;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveBox(int index)
        {
            return Native.DllImports.boxaRemoveBox(handleRef, index) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            return Native.DllImports.boxaClear(handleRef) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool ReplaceBoxAt(int index, Box box)
        {
            return Native.DllImports.boxaReplaceBox(handleRef, index, box.handleRef) == 0;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool InsertBoxAt(int index, Box box)
        {
            return Native.DllImports.boxaInsertBox(handleRef, index, box.handleRef) == 0;
        }
        #endregion

        #region ICloneable Support
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var box = Native.DllImports.boxaCopy(handleRef, InsertionType.COPY);
            return new Box(box);
        }
        #endregion

        #region IEnumerable Support 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxaBoxEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
                Native.DllImports.boxaDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Boxa()
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
