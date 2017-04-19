using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Numaa
    /// </summary>
    public class Numaa : LeptonicaObjectBase
    {
        /// <summary>
        /// Creates a new Numaa from pointer
        /// </summary>
        /// <param name="pointer">The pointer</param>
        public Numaa(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// numaCreate()
        /// </summary>
        /// <param name="n">n size of number array to be alloc'd 0 for default</param>
        /// <returns>na, or NULL on error</returns>
        public static Numaa Create(int n)
        {
            return (Numaa)Native.DllImports.numaaCreate(n);
        }
         
        /// <summary>
        /// (1) Decrements the ref count and, if 0, destroys the numa.
        /// (2) Always nulls the input ptr.
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.numaaDestroy(ref toDestroy);
        } 

        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Numaa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Numaa(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
