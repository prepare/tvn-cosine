using System; 

namespace Leptonica
{
    /// <summary>
    /// PixColorMap.
    /// </summary>
    public class PixColorMap : LeptonicaObjectBase
    {
        private PixColorMap(IntPtr pointer)
            : base(pointer)
        {

        }


        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator PixColorMap(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new PixColorMap(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
