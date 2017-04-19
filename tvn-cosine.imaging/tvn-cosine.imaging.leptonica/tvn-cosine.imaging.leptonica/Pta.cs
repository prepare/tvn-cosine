using System;

namespace Leptonica
{ 
    /// <summary>
    /// pta.h
    /// </summary>
    public class Pta : LeptonicaObjectBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        public Pta(IntPtr pointer)
            : base(pointer)
        {

        }
         
        /// <summary>
        /// Explicitly cast IntPtr to Boxa
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Pta(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Pta(pointer);
            }
            else
            {
                return null;
            }
        }
    }
} 