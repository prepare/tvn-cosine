using System;

namespace Leptonica
{
    /// <summary>
    /// box.h
    /// </summary>
    public class Box : LeptonicaObjectBase, System.IDisposable
    {
        private Box(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        ///       (1) This clips the box to the +quad.If no part of the
        /// box is in the +quad, this returns NULL.
        ///       (2) We allow you to make a box with w = 0 and/or h = 0.
        /// 
        /// This does not represent a valid region, but it is useful
        ///          as a placeholder in a boxa for which the index of the
        /// box in the boxa is important.This is an atypical
        ///           situation; usually you want to put only valid boxes with
        ///  nonzero width and height in a boxa.If you have a boxa
        ///           with invalid boxes, the accessor boxaGetValidBox()
        ///           will return NULL on each invalid box.
        ///       (3) If you want to create only valid boxes, use boxCreateValid(),
        ///           which returns NULL if either w or h is 0.
        /// </summary>
        /// <param name="x">x, y, w, h</param>
        /// <param name="y">x, y, w, h</param>
        /// <param name="w">x, y, w, h</param>
        /// <param name="h">x, y, w, h</param>
        /// <returns>box, or NULL on error</returns>
        public static Box Create(int x, int y, int w, int h)
        {
            return (Box)Native.DllImports.boxCreate(x, y, w, h);
        }

        /// <summary>
        /// boxCreateValid()
        /// </summary>
        /// <param name="x">x, y, w, h</param>
        /// <param name="y">x, y, w, h</param>
        /// <param name="w">x, y, w, h</param>
        /// <param name="h">x, y, w, h</param>
        /// <returns>This returns NULL if either w = 0 or h = 0.</returns>
        public static Box CreateValid(int x, int y, int w, int h)
        {
            return (Box)Native.DllImports.boxCreateValid(x, y, w, h);
        }

        /// <summary>
        /// boxCopy()
        /// </summary>
        /// <returns>copy of box, or NULL on error</returns>
        public Box Copy()
        {
            return (Box)Native.DllImports.boxCopy(handleRef);
        }

        /// <summary>
        /// boxClone()
        /// </summary>
        /// <returns>ptr to same box, or NULL on error</returns>
        public Box Clone()
        {
            return (Box)Native.DllImports.boxCopy(handleRef);
        }

        /// <summary>
        /// boxGetGeometry()
        /// </summary>
        /// <param name="px">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="py">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="pw">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="ph">px, py, pw, ph [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetGeometry(out int px, out int py, out int pw, out int ph)
        {
            return Native.DllImports.boxGetGeometry(handleRef, out px, out py, out pw, out ph) == 0;
        }

        /// <summary>
        /// boxSetGeometry()
        /// </summary>
        /// <param name="x">x, y, w, h  [optional]  use -1 to leave unchanged</param>
        /// <param name="y">x, y, w, h  [optional]  use -1 to leave unchanged</param>
        /// <param name="w">x, y, w, h  [optional]  use -1 to leave unchanged</param>
        /// <param name="h">x, y, w, h  [optional]  use -1 to leave unchanged</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetGeometry(int x, int y, int w, int h)
        {
            return Native.DllImports.boxSetGeometry(handleRef, x, y, w, h) == 0;
        }

        /// <summary>
        /// (1) All returned values are within the box.
        /// </summary>
        /// <param name="pl">pl, pt, pr, pb [optional]  each can be null</param>
        /// <param name="pr">pl, pt, pr, pb [optional]  each can be null</param>
        /// <param name="pt">pl, pt, pr, pb [optional]  each can be null</param>
        /// <param name="pb">pl, pt, pr, pb [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetSideLocations(out int pl, out int pr, out int pt, out int pb)
        {
            return Native.DllImports.boxGetSideLocations(handleRef, out pl, out pr, out pt, out pb) == 0;
        }

        /// <summary>
        /// boxSetSideLocations()
        /// </summary>
        /// <param name="l">l, r, t, b  [optional] use -1 to leave unchanged</param>
        /// <param name="r">l, r, t, b  [optional] use -1 to leave unchanged</param>
        /// <param name="t">l, r, t, b  [optional] use -1 to leave unchanged</param>
        /// <param name="b">l, r, t, b  [optional] use -1 to leave unchanged</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetSideLocations(int l, int r, int t, int b)
        {
            return Native.DllImports.boxSetSideLocations(handleRef, l, r, t, b) == 0;
        }

        /// <summary>
        /// Return the current reference count of %box
        /// </summary>
        /// <returns>refcount</returns>
        public int GetRefCount()
        {
            return Native.DllImports.boxGetRefcount(handleRef);
        }

        /// <summary>
        /// Adjust the current references count of %box by %delta
        /// </summary>
        /// <param name="delta">delta adjustment, usually -1 or 1</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryChangeRefCount(int delta)
        {
            return Native.DllImports.boxChangeRefcount(handleRef, delta) == 0;
        }

        /// <summary>
        /// boxIsValid()
        /// </summary>
        /// <param name="pvalid">pvalid true if valid; false otherwise</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryIsValid(out bool pvalid)
        {
            return Native.DllImports.boxIsValid(handleRef, out pvalid) == 0;
        }

        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Box(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Box(pointer);
            }
            else
            {
                return null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// (1) Decrements the ref count and, if 0, destroys the box.
        /// (2) Always nulls the input ptr.
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

                var toDestroy = handleRef.Handle;
                Native.DllImports.boxDestroy(ref toDestroy);

                disposedValue = true;
            }
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        ~Box()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
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
