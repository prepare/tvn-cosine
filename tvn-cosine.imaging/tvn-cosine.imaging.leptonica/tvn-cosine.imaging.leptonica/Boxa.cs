using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace leptonica.net
{
    public class Boxa : IDisposable, IEnumerable<Box>, ICloneable
    {
        public readonly HandleRef handleRef;

        #region ctors
        public Boxa(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        public Boxa(int size)
            : this(Native.DllImports.boxaCreate(size))
        { }
        #endregion

        #region Properties  
        public int Count
        {
            get
            {
                return Native.DllImports.boxaGetCount(handleRef);
            }
        }

        public Box this[int index]
        {
            get
            {
                return GetBox(index);
            }
        }
        #endregion

        #region Methods
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

        public bool AddBox(Box box)
        {
            return Native.DllImports.boxaAddBox(handleRef, box.handleRef, InsertionType.COPY) == 0;
        }

        public bool ExtendArray()
        {
            return Native.DllImports.boxaExtendArray(handleRef) == 0;
        }

        public bool ExtendArrayToSize(int size)
        {
            return Native.DllImports.boxaExtendArrayToSize(handleRef, size) == 0;
        }
         
        public bool RemoveBox(int index)
        {
            return Native.DllImports.boxaRemoveBox(handleRef, index) == 0;
        }

        public bool Clear()
        {
            return Native.DllImports.boxaClear(handleRef) == 0;
        }

        public bool ReplaceBoxAt(int index, Box box)
        {
            return Native.DllImports.boxaReplaceBox(handleRef, index, box.handleRef) == 0;
        }
         
        public bool InsertBoxAt(int index, Box box)
        {
            return Native.DllImports.boxaInsertBox(handleRef, index, box.handleRef) == 0;
        }
        #endregion

        #region ICloneable Support
        public object Clone()
        {
            var box = Native.DllImports.boxaCopy(handleRef, InsertionType.COPY);
            return new Box(box);
        }
        #endregion

        #region IEnumerable Support 

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

        ~Boxa()
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
