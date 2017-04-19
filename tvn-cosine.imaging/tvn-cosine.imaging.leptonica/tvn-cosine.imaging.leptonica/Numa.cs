using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// numabasic.c
    /// </summary>
    public class Numa : LeptonicaObjectBase
    {
        /// <summary>
        /// Creates a new Numa from pointer
        /// </summary>
        /// <param name="pointer">The pointer</param>
        public Numa(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// numaCreate()
        /// </summary>
        /// <param name="n">n size of number array to be alloc'd 0 for default</param>
        /// <returns>na, or NULL on error</returns>
        public static Numa Create(int n)
        {
            return (Numa)Native.DllImports.numaCreate(n);
        }

        /// <summary>
        ///  (1) We can't insert this int array into the numa, because a numa
        ///      takes a float array.So this just copies the data from the
        ///      input array into the numa.The input array continues to be
        ///      owned by the caller.
        /// </summary>
        /// <param name="iarray">iarray integer</param>
        /// <param name="size">size of the array</param>
        /// <returns>na, or NULL on error</returns>
        public static Numa CreateFromIArray(int[] iarray, int size)
        {
            return (Numa)Native.DllImports.numaCreateFromIArray(iarray, size);
        }

        /// <summary>
        ///      (1) With L_INSERT, ownership of the input array is transferred
        /// to the returned numa, and all %size elements are considered
        ///          to be valid.
        /// </summary>
        /// <param name="farray">farray float</param>
        /// <param name="size">size of the array</param>
        /// <param name="copyflag">copyflag L_INSERT or L_COPY</param>
        /// <returns>na, or NULL on error</returns>
        public static Numa CreateFromFArray(float[] farray, int size, InsertionType copyflag)
        {
            return (Numa)Native.DllImports.numaCreateFromFArray(farray, size, copyflag);
        }

        /// <summary>
        /// (1) Decrements the ref count and, if 0, destroys the numa.
        /// (2) Always nulls the input ptr.
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.numaDestroy(ref toDestroy);
        }

        /// <summary>
        /// numaCopy()
        /// </summary>
        /// <returns>copy of numa, or NULL on error</returns>
        public Numa Copy()
        {
            return (Numa)Native.DllImports.numaCopy((HandleRef)this);
        }

        /// <summary>
        /// numaClone()
        /// </summary>
        /// <returns>ptr to same numa, or NULL on error</returns>
        public Numa Clone()
        {
            return (Numa)Native.DllImports.numaClone((HandleRef)this);
        }

        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Numa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Numa(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
