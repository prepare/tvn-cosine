using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Pix.h
    /// </summary>
    public class Pix : LeptonicaObjectBase
    {
        /// <summary>
        /// Create pix from pointer
        /// </summary>
        /// <param name="pointer">The pointer to use</param>
        public Pix(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// pixCreate()
        /// </summary>
        /// <param name="width">width, height, depth</param>
        /// <param name="height">width, height, depth</param>
        /// <param name="depth">width, height, depth</param>
        /// <returns>pixd with data allocated and initialized to 0, or NULL on error</returns>
        public static Pix Create(int width, int height, int depth)
        {
            return (Pix)Native.DllImports.pixCreate(width, height, depth);
        }

        /// <summary>
        /// pixCreateNoInit()
        /// </summary>
        /// <param name="width">width, height, depth</param>
        /// <param name="height">width, height, depth</param>
        /// <param name="depth">width, height, depth</param>
        /// <returns>pixd with data allocated but not initialized,or NULL on error</returns>
        public static Pix CreateNoItit(int width, int height, int depth)
        {
            return (Pix)Native.DllImports.pixCreateNoInit(width, height, depth);
        }

        /// <summary>
        /// (1) Makes a Pix of the same size as the input Pix, with the
        ///     data array allocated and initialized to 0.
        /// (2) Copies the other fields, including colormap if it exists.
        /// </summary>
        /// <returns>pixd, or NULL on error</returns>
        public Pix CreateTemplate()
        {
            return (Pix)Native.DllImports.pixCreateTemplate((HandleRef)this);
        }

        /// <summary>
        ///       (1) Makes a Pix of the same size as the input Pix, with
        ///  the data array allocated but not initialized to 0.
        ///       (2) Copies the other fields, including colormap if it exists.
        /// </summary>
        /// <returns>pixd, or NULL on error</returns>
        public Pix CreateTemplateNoInit()
        {
            return (Pix)Native.DllImports.pixCreateTemplateNoInit((HandleRef)this);
        }

        /// <summary>
        ///       (1) It is assumed that all 32 bit pix have 3 spp.If there is
        ///           a valid alpha channel, this will be set to 4 spp later.
        ///       (2) If the number of bytes to be allocated is larger than the
        ///  maximum value in an int32, we can get overflow, resulting
        ///          in a smaller amount of memory actually being allocated.
        ///           Later, an attempt to access memory that wasn't allocated will
        ///           cause a crash.So to avoid crashing a program (or worse)
        ///           with bad(or malicious) input, this is where we limit the
        ///           requested allocation of image data in a typesafe way.
        /// </summary>
        /// <param name="width">width, height, depth</param>
        /// <param name="height">width, height, depth</param>
        /// <param name="depth">width, height, depth</param>
        /// <returns>pixd with no data allocated, or NULL on error</returns>
        public static Pix CreateHeader(int width, int height, int depth)
        {
            return (Pix)Native.DllImports.pixCreateHeader(width, height, depth);
        }

        /// <summary>
        ///       (1) A "clone" is simply a handle(ptr) to an existing pix.
        ///           It is implemented because (a) images can be large and
        /// hence expensive to copy, and(b) extra handles to a data
        /// structure need to be made with a simple policy to avoid
        ///           both double frees and memory leaks.Pix are reference
        /// counted.The side effect of pixClone() is an increase
        ///           by 1 in the ref count.
        ///       (2) The protocol to be used is:
        ///           (a) Whenever you want a new handle to an existing image,
        ///               call pixClone(), which just bumps a ref count.
        ///           (b) Always call pixDestroy() on all handles.This
        ///  decrements the ref count, nulls the handle, and
        /// only destroys the pix when pixDestroy() has been
        ///               called on all handles.
        /// </summary>
        /// <returns>same pix ptr, or NULL on error</returns>
        public Pix Clone()
        {
            return (Pix)Native.DllImports.pixClone((HandleRef)this);
        }

        /// <summary>
        /// (1) Decrements the ref count and, if 0, destroys the pix.
        /// (2) Always nulls the input ptr.
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.pixDestroy(ref toDestroy);
        }

        /// <summary>
        ///      (1) There are three cases:
        ///            (a) pixd == null  (makes a new pix; refcount = 1)
        ///            (b) pixd == pixs(no-op)
        ///            (c) pixd != pixs(data copy; no change in refcount)
        ///          If the refcount of pixd > 1, case (c) will side-effect
        /// these handles.
        /// 
        ///     (2) The general pattern of use is:
        ///             pixd = pixCopy(pixd, pixs);
        ///          This will work for all three cases.
        /// For clarity when the case is known, you can use:
        ///            (a) pixd = pixCopy(NULL, pixs);
        ///            (c) pixCopy(pixd, pixs);
        ///      (3) For case (c), we check if pixs and pixd are the same
        ///          size(w, h, d).  If so, the data is copied directly.
        ///           Otherwise, the data is reallocated to the correct size
        ///  and the copy proceeds.The refcount of pixd is unchanged.
        /// 
        ///       (4) This operation, like all others that may involve a pre-existing
        ///  pixd, will side-effect any existing clones of pixd.
        /// </summary>
        /// <param name="pixd">pixd [optional]; can be null, or equal to pixs, or different from pixs</param>
        /// <param name="pixs">pixs</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix Copy(Pix pixd, Pix pixs)
        {
            return (Pix)Native.DllImports.pixCopy((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        ///       (1) This removes any existing image data from pixd and
        ///  allocates an uninitialized buffer that will hold the
        /// amount of image data that is in pixs.
        /// </summary>
        /// <param name="pixd">pixd gets new uninitialized buffer for image data</param>
        /// <param name="pixs">pixs determines the size of the buffer; not changed</param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryResizeImageData(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixResizeImageData((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// (1) This always destroys any colormap in pixd (except if the operation is a no-op.
        /// </summary>
        /// <param name="pixd">pixd, pixs dest and src Pix</param>
        /// <param name="pixs">pixd, pixs dest and src Pix</param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopyColormap(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopyColormap((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixSizesEqual()
        /// </summary>
        /// <param name="pix1">pix1, pix2  two pix</param>
        /// <param name="pix2">pix1, pix2  two pix</param>
        /// <returns>true if the two pix have same {h, w, d}; false otherwise.</returns>
        public static bool SizesEqual(Pix pix1, Pix pix2)
        {
            return Native.DllImports.pixSizesEqual((HandleRef)pix1, (HandleRef)pix2) == 1;
        }

        /// <summary>
        ///  pixGetWidth  
        /// </summary>
        /// <returns>Width</returns>
        public int GetWidth()
        {
            return Native.DllImports.pixGetWidth((HandleRef)this);
        }

        /// <summary>
        ///  pixSetWidth  
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetWidth(int width)
        {
            return Native.DllImports.pixSetWidth((HandleRef)this, width) == 0;
        }

        /// <summary>
        ///  pixGetHeight  
        /// </summary>
        /// <returns>Height</returns>
        public int GetHeight()
        {
            return Native.DllImports.pixGetHeight((HandleRef)this);
        }

        /// <summary>
        ///  pixSetHeight  
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetHeight(int height)
        {
            return Native.DllImports.pixSetHeight((HandleRef)this, height) == 0;
        }

        /// <summary>
        ///  pixGetDepth  
        /// </summary>
        /// <returns>Depth</returns>
        public int GetDepth()
        {
            return Native.DllImports.pixGetDepth((HandleRef)this);
        }

        /// <summary>
        ///  pixSetDepth  
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetDepth(int depth)
        {
            return Native.DllImports.pixSetDepth((HandleRef)this, depth) == 0;
        }

        /// <summary>
        /// pixGetDimensions()
        /// </summary>
        /// <param name="pw">pw, ph, pd [optional]  each can be null</param>
        /// <param name="ph">pw, ph, pd [optional]  each can be null</param>
        /// <param name="pd">pw, ph, pd [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetDimensions(out int pw, out int ph, out int pd)
        {
            return Native.DllImports.pixGetDimensions((HandleRef)this, out pw, out ph, out pd) == 0;
        }

        /// <summary>
        /// pixSetDimensions()
        /// </summary>
        /// <param name="w">w, h, d use 0 to skip the setting for any of thes</param>
        /// <param name="h">w, h, d use 0 to skip the setting for any of thes</param>
        /// <param name="d">w, h, d use 0 to skip the setting for any of thes</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetDimensions(int w, int h, int d)
        {
            return Native.DllImports.pixSetDimensions((HandleRef)this, w, h, d) == 0;
        }

        /// <summary>
        /// pixCopyDimensions()
        /// </summary>
        /// <param name="pixd">pixd</param>
        /// <param name="pixs">pixs</param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopyDimensions(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopyDimensions((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixGetSpp()
        /// </summary>
        /// <returns>Spp</returns>
        public int GetSpp()
        {
            return Native.DllImports.pixGetSpp((HandleRef)this);
        }

        /// <summary>
        ///       (1) For a 32 bpp pix, this can be used to ignore the
        ///          alpha sample(spp == 3) or to use it(spp == 4).
        ///          For example, to write a spp == 4 image without the alpha
        ///          sample(as an rgb pix), call pixSetSpp(pix, 3) and
        /// then write it out as a png.
        /// </summary>
        /// <param name="spp">spp (1, 3 or 4)</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetSpp(int spp)
        {
            return Native.DllImports.pixSetSpp((HandleRef)this, spp) == 0;
        }

        /// <summary>
        /// pixCopySpp()
        /// </summary>
        /// <param name="pixd">pixd</param>
        /// <param name="pixs">pixs</param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopySpp(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopySpp((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixGetWpl()
        /// </summary>
        /// <returns>Wpl</returns>
        public int GetWpl()
        {
            return Native.DllImports.pixGetWpl((HandleRef)this);
        }

        /// <summary>
        /// pixSetWpl()
        /// </summary>
        /// <param name="wpl">wpl</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetWpl(int wpl)
        {
            return Native.DllImports.pixSetWpl((HandleRef)this, wpl) == 0;
        }

        /// <summary>
        /// pixGetRefcount()
        /// </summary>
        /// <returns>Refcount</returns>
        public int GetRefcount()
        {
            return Native.DllImports.pixGetRefcount((HandleRef)this);
        }

        /// <summary>
        /// pixChangeRefcount
        /// </summary>
        /// <param name="delta">delta</param>
        /// <returns>true if OK, false on error</returns>
        public bool ChangeRefcount(int delta)
        {
            return Native.DllImports.pixChangeRefcount((HandleRef)this, delta) == 0;
        }

        /// <summary>
        /// pixGetXRes()
        /// </summary>
        /// <returns>XRes</returns>
        public int GetXRes()
        {
            return Native.DllImports.pixGetXRes((HandleRef)this);
        }

        /// <summary>
        /// pixSetXRes()
        /// </summary>
        /// <param name="res">res</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetXRes(int res)
        {
            return Native.DllImports.pixSetXRes((HandleRef)this, res) == 0;
        }

        /// <summary>
        /// pixGetYRes()
        /// </summary>
        /// <returns>YRes</returns>
        public int GetYRes()
        {
            return Native.DllImports.pixGetYRes((HandleRef)this);
        }

        /// <summary>
        /// pixSetYRes()
        /// </summary>
        /// <param name="res">res</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetYRes(int res)
        {
            return Native.DllImports.pixSetYRes((HandleRef)this, res) == 0;
        }

        /// <summary>
        /// pixGetResolution()
        /// </summary>
        /// <param name="pxres">pxres, pyres [optional]  each can be null</param>
        /// <param name="pyres">pxres, pyres [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetResolution(out int pxres, out int pyres)
        {
            return Native.DllImports.pixGetResolution((HandleRef)this, out pxres, out pyres) == 0;
        }

        /// <summary>
        /// pixSetResolution()
        /// </summary>
        /// <param name="pxres">xres, yres use 0 to skip the setting for either of these</param>
        /// <param name="pyres">xres, yres use 0 to skip the setting for either of these</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetResolution(int pxres, int pyres)
        {
            return Native.DllImports.pixSetResolution((HandleRef)this, pxres, pyres) == 0;
        }

        /// <summary>
        /// pixCopyResolution()
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopyResolution(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopyResolution((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixScaleResolution()
        /// </summary>
        /// <param name="xscale"></param>
        /// <param name="yscale"></param>
        /// <returns>true if OK, false on error</returns>
        public bool TryScaleResolution(float xscale, float yscale)
        {
            return Native.DllImports.pixScaleResolution((HandleRef)this, xscale, yscale) == 0;
        }

        /// <summary>
        /// pixGetInputFormat()
        /// </summary>
        /// <returns>ImageFileFormat</returns>
        public ImageFileFormat GetInputFormat()
        {
            return Native.DllImports.pixGetInputFormat((HandleRef)this);
        }

        /// <summary>
        /// pixSetInputFormat()
        /// </summary>
        /// <param name="informat">ImageFileFormat</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetInputFormat(ImageFileFormat informat)
        {
            return Native.DllImports.pixSetInputFormat((HandleRef)this, informat) == 0;
        }

        /// <summary>
        /// pixCopyInputFormat()
        /// </summary>
        /// <param name="pixd">pixd</param>
        /// <param name="pixs">pixs</param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopyInputFormat(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopyInputFormat((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixSetSpecial()
        /// </summary>
        /// <param name="special">special</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetSpecial(int special)
        {
            return Native.DllImports.pixSetSpecial((HandleRef)this, special) == 0;
        }

        /// <summary>
        /// (1) The text string belongs to the pix.  The caller must NOT free it!
        /// </summary>
        /// <returns>ptr to existing text string</returns>
        public string GetText()
        {
            return Marshal.PtrToStringAnsi(Native.DllImports.pixGetText((HandleRef)this));
        }

        /// <summary>
        /// (1) This removes any existing textstring and puts a copy of the input textstring there.
        /// </summary>
        /// <param name="textstring">textstring can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetText(string textstring)
        {
            return Native.DllImports.pixSetText((HandleRef)this, textstring) == 0;
        }

        /// <summary>
        ///      (1) This adds the new textstring to any existing text.
        ///      (2) Either or both the existing text and the new text
        /// string can be null.
        /// </summary>
        /// <param name="textstring">textstring</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryAddText(string textstring)
        {
            return Native.DllImports.pixAddText((HandleRef)this, textstring) == 0;
        }

        /// <summary>
        /// pixCopyText()
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>true if OK, false on error</returns>
        public static bool TryCopyText(Pix pixd, Pix pixs)
        {
            return Native.DllImports.pixCopyText((HandleRef)pixd, (HandleRef)pixs) == 0;
        }

        /// <summary>
        /// pixGetColormap
        /// </summary>
        /// <returns>PIXCMAP </returns>
        public PixColorMap GetColormap()
        {
            return (PixColorMap)Native.DllImports.pixGetColormap((HandleRef)this);
        }

        /// <summary>
        ///      (1) Unlike with the pix data field, pixSetColormap() destroys
        /// any existing colormap before assigning the new one.
        ///          Because colormaps are not ref counted, it is important that
        /// the new colormap does not belong to any other pix.
        /// </summary>
        /// <param name="colormap">colormap to be assigned</param>
        /// <returns>true if OK, false on error</returns>
        public bool TrySetColormap(PixColorMap colormap)
        {
            return Native.DllImports.pixSetColormap((HandleRef)this, (HandleRef)colormap) == 0;
        }

        /// <summary>
        /// pixDestroyColormap()
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TryDestroyColormap()
        {
            return Native.DllImports.pixDestroyColormap((HandleRef)this) == 0;
        }

        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Pix(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
