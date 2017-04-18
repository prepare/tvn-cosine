using System;

namespace Leptonica
{
    /// <summary>
    /// boxa.h
    /// </summary>
    public class Boxa : LeptonicaObjectBase, IDisposable
    {
        private Boxa(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// boxaCreate()
        /// </summary>
        /// <param name="n">n  initial number of ptrs</param>
        /// <returns>boxa, or NULL on error</returns>
        public static Boxa Create(int n)
        {
            return (Boxa)Native.DllImports.boxaCreate(n);
        }

        /// <summary>
        /// (1) See pix.h for description of the copyflag.
        /// (2) The copy-clone makes a new boxa that holds clones of each box.
        /// </summary>
        /// <param name="copyflag">copyflag L_COPY, L_CLONE, L_COPY_CLONE</param>
        /// <returns>new boxa, or NULL on error</returns>
        public Boxa Copy(InsertionType copyflag)
        {
            return (Boxa)Native.DllImports.boxaCopy(handleRef, copyflag);
        }

        /// <summary>
        /// boxaAddBox()
        /// </summary>
        /// <param name="box">box  to be added</param>
        /// <param name="copyflag">copyflag L_INSERT, L_COPY, L_CLONE</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryAddBox(Box box, InsertionType copyflag)
        {
            return Native.DllImports.boxaAddBox(handleRef, box.handleRef, copyflag) == 0;
        }

        /// <summary>
        /// (1) Reallocs with doubled size of ptr array.
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArray()
        {
            return Native.DllImports.boxaExtendArray(handleRef) == 0;
        }

        /// <summary>
        /// (1) If necessary, reallocs new boxa ptr array to %size.
        /// </summary>
        /// <param name="size">size new size of boxa array</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArrayToSize(int size)
        {
            return Native.DllImports.boxaExtendArrayToSize(handleRef, size) == 0;
        }

        /// <summary>
        /// boxaGetCount()
        /// </summary>
        /// <returns>count of all boxes; 0 if no boxes or on error</returns>
        public int GetCount()
        {
            return Native.DllImports.boxaGetCount(handleRef);
        }

        /// <summary>
        /// boxaGetValidCount()
        /// </summary>
        /// <returns>count of valid boxes; 0 if no valid boxes or on error</returns>
        public int GetValidCount()
        {
            return Native.DllImports.boxaGetValidCount(handleRef);
        }

        /// <summary>
        /// boxaGetBox()
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="accessflag">accessflag  L_COPY or L_CLONE</param>
        /// <returns>box, or NULL on error</returns>
        public Box GetBox(int index, InsertionType accessflag)
        {
            return (Box)Native.DllImports.boxaGetBox(handleRef, index, accessflag);
        }

        /// <summary>
        ///      (1) This returns NULL for an invalid box in a boxa.
        ///          For a box to be valid, both the width and height must be > 0.
        ///      (2) We allow invalid boxes, with w = 0 or h = 0, as placeholders
        ///          in boxa for which the index of the box in the boxa is important.
        /// This is an atypical situation; usually you want to put only
        ///          valid boxes in a boxa.
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="accessflag">accessflag  L_COPY or L_CLONE</param>
        /// <returns>box, or NULL on error</returns>
        public Box GetValidBox(int index, InsertionType accessflag)
        {
            return (Box)Native.DllImports.boxaGetValidBox(handleRef, index, accessflag);
        }

        /// <summary>
        /// boxaFindInvalidBoxes()
        /// </summary>
        /// <returns>numa of invalid boxes; NULL if there are none or on error</returns>
        public Numa FindInvalidBoxes()
        {
            return (Numa)Native.DllImports.boxaFindInvalidBoxes(handleRef);
        }

        /// <summary>
        /// boxaGetBoxGeometry()
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="px">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="py">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="pw">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="ph">px, py, pw, ph [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetBoxGeometry(int index, out int px, out int py, out int pw, out int ph)
        {
            return Native.DllImports.boxaGetBoxGeometry(handleRef, index, out px, out py, out pw, out ph) == 0;
        }

        /// <summary>
        /// boxaIsFull()
        /// </summary>
        /// <param name="pfull">pfull 1 if boxa is full</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryIsFull(out bool pfull)
        {
            return Native.DllImports.boxaIsFull(handleRef, out pfull) == 0;
        }


        /// <summary>
        /// Explicitly cast IntPtr to Boxa
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Boxa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                var toDestroy = handleRef.Handle;
                Native.DllImports.boxaDestroy(ref toDestroy);

                disposedValue = true;
            }
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        ~Boxa()
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
