using System.Runtime.InteropServices;

namespace Leptonica
{
    public class Pta : System.ICloneable, System.IDisposable
    {
        public readonly HandleRef handleRef;

        #region ctors
        public Pta(System.IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        public Pta(int size)
            : this(Native.DllImports.ptaCreate(size))
        { }

        #endregion

        #region Methods
        public bool GetPt(int index, out float px, out float py)
        {
            return Native.DllImports.ptaGetPt(handleRef, index, out px, out py) == 0;
        }

        public bool AddPt(float px, float py)
        {
            return Native.DllImports.ptaAddPt(handleRef, px, py) == 0;
        }

        public bool RemovePt(int index)
        {
            return Native.DllImports.ptaRemovePt(handleRef, index) == 0;
        }

        public bool Empty()
        {
            return Native.DllImports.ptaEmpty(handleRef) == 0;
        } 

        public bool InsertPtAt(int index, int x, int y)
        {
            return Native.DllImports.ptaInsertPt(handleRef, index, x, y) == 0;
        }
        #endregion

        #region ICloneable Support
        public object Clone()
        {
            var box = Native.DllImports.ptaCopy(handleRef);
            return new Box(box);
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
                Native.DllImports.ptaDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        ~Pta()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
} 