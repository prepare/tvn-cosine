using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// A base abstract definition for leptonica objects
    /// </summary>
    public abstract class LeptonicaObjectBase 
    {
        /// <summary>
        /// The handle reference for the object
        /// </summary>
        public readonly HandleRef handleRef;

        /// <summary>
        /// Instantiating a base leptonica object
        /// </summary>
        /// <param name="pointer"></param>
        public LeptonicaObjectBase(System.IntPtr pointer)
        { 
            handleRef = new HandleRef(this, pointer);
        }
    }
}
