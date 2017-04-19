using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Basic operations on kernels for image convolution
    /// </summary>
    public class L_Kernel : LeptonicaObjectBase 
    {
        /// <summary>
        ///      (1) kernelCreate() initializes all values to 0.
        ///      (2) After this call, (cy, cx) and nonzero data values must be
        ///          assigned.
        /// </summary>
        /// <param name="height"> height, width</param>
        /// <param name="width"> height, width</param>
        public L_Kernel(int height, int width)
            : base(Native.DllImports.kernelCreate(height, width))
        { }

        private L_Kernel(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// kernelGetElement()
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="col">col</param>
        /// <param name="pval">pval</param>
        /// <returns>true if OK; false on error</returns>
        public bool TryGetElement(int row, int col, out float pval)
        {
            return Native.DllImports.kernelGetElement((HandleRef)this, row, col, out pval) == 0;
        }

        /// <summary>
        /// kernelGetElement()
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="col">col</param>
        /// <param name="val">val</param>
        /// <returns>true if OK; false on error</returns>
        public bool SetElement(int row, int col, float val)
        {
            return Native.DllImports.kernelSetElement((HandleRef)this, row, col, val) == 0;
        }

        /// <summary>
        /// kernelGetParameters()
        /// </summary>
        /// <param name="psy">psy, psx, pcy, pcx [optional]  each can be null</param>
        /// <param name="psx">psy, psx, pcy, pcx [optional]  each can be null</param>
        /// <param name="pcy">psy, psx, pcy, pcx [optional]  each can be null</param>
        /// <param name="pcx">psy, psx, pcy, pcx [optional]  each can be null</param>
        /// <returns>true if OK; false on error</returns>
        public bool TryGetParameters(out int psy, out int psx, out int pcy, out int pcx)
        {
            return Native.DllImports.kernelGetParameters((HandleRef)this, out psy, out psx, out pcy, out pcx) == 0;
        }

        /// <summary>
        /// kernelSetOrigin()
        /// </summary>
        /// <param name="cy">cy, cx</param>
        /// <param name="cx">cy, cx</param>
        /// <returns>true if OK; false on error</returns>
        public bool SetOrigin(int cy, int cx)
        {
            return Native.DllImports.kernelSetOrigin((HandleRef)this, cx, cy) == 0;
        }

        /// <summary>
        /// kernelGetSum()
        /// </summary>
        /// <param name="psum">psum sum of all kernel values</param>
        /// <returns>true if OK; false on error</returns>
        public bool TryGetSum(out float psum)
        {
            return Native.DllImports.kernelGetSum((HandleRef)this, out psum) == 0;
        }

        /// <summary>
        /// kernelGetMinMax()
        /// </summary>
        /// <param name="pmin">pmin [optional] minimum value</param>
        /// <param name="pmax">pmax [optional] maximum value</param>
        /// <returns>true if OK; false on error</returns>
        public bool TryGetMinMax(out float pmin, out float pmax)
        {
            return Native.DllImports.kernelGetMinMax((HandleRef)this, out pmin, out pmax) == 0;
        }

        /// <summary>
        /// (1) If the sum of kernel elements is close to 0, do not
        ///     try to calculate the normalized kernel.Instead,
        ///     return a copy of the input kernel, with a warning.
        /// </summary>
        /// <param name="normsum">normsum desired sum of elements in keld</param>
        /// <returns>keld normalized version of kels, or NULL on error or if sum of elements is very close to 0</returns>
        public L_Kernel Normalize(float normsum)
        {
            return (L_Kernel)Native.DllImports.kernelNormalize((HandleRef)this, normsum);
        }

        /// <summary>
        /// (1) For convolution, the kernel is spatially inverted before a "correlation" operation is done between the kernel and the image.
        /// </summary>
        /// <returns>keld spatially inverted, about the origin, or NULL on error</returns>
        public L_Kernel Invert()
        {
            return (L_Kernel)Native.DllImports.kernelInvert((HandleRef)this);

        }

        /// <summary>
        ///      (1) This gives a visual representation of a kernel.
        ///      (2) There are two modes of display:
        ///          (a) Grid lines of minimum width 2, surrounding regions
        ///              representing kernel elements of minimum size 17,
        ///              with a "plus" mark at the kernel origin, or
        ///          (b) A pix without grid lines and using 1 pixel per kernel element.
        ///      (3) For both cases, the kernel absolute value is displayed,
        /// normalized such that the maximum absolute value is 255.
        ///      (4) Large 2D separable kernels should be used for convolution
        /// with two 1D kernels.However, for the bilateral filter,
        /// the computation time is independent of the size of the
        ///          2D content kernel.
        /// </summary>
        /// <param name="size">size of grid interiors; odd; either 1 or a minimum size of 17 is enforced</param>
        /// <param name="gthick">gthick grid thickness; either 0 or a minimum size of 2 is enforced</param>
        /// <returns>pix display of kernel, or NULL on error</returns>
        public Pix DisplayInPix(int size, int gthick)
        {
            var pixPointer = Native.DllImports.kernelDisplayInPix((HandleRef)this, size, gthick);
            if (pixPointer == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                return new Pix(pixPointer);
            }
        }

        /// <summary>
        /// kernelWrite()
        /// </summary>
        /// <param name="fname">fname output file</param>
        /// <returns>true if OK; false on error</returns>
        public bool TryWrite(string fname)
        {
            return Native.DllImports.kernelWrite(fname, (HandleRef)this) == 0;
        }

        /// <summary>
        /// kernelRead()
        /// </summary>
        /// <param name="fname">fname filename</param>
        /// <returns>kernel, or NULL on error</returns>
        public static L_Kernel Read(string fname)
        {
            if (!File.Exists(fname))
                throw new FileNotFoundException(string.Format("The file {0} not found.", fname));

            return (L_Kernel)Native.DllImports.kernelRead(fname);
        }

        /// <summary>
        ///  Notes:
        ///       (1) The data is an array of chars, in row-major order, giving
        ///           space separated integers in the range[-255... 255].
        ///       (2) The only other formatting limitation is that you must
        ///  leave space between the last number in each row and
        /// the double-quote.If possible, it's also nice to have each
        ///           line in the string represent a line in the kernel; e.g.,
        ///               static const char* kdata =
        /// " 20   50   20 "
        ///  " 70  140   70 "
        ///  " 20   50   20 ";
        /// </summary>
        /// <param name="h">h, w     height, width</param>
        /// <param name="w">h, w     height, width</param>
        /// <param name="cy">cy, cx   origin</param>
        /// <param name="cx">cy, cx   origin</param>
        /// <param name="kdata">kdata</param>
        /// <returns>kernel of the given size, or NULL on error</returns>
        public static L_Kernel CreateFromString(int h, int w, int cy, int cx, string kdata)
        {
            return (L_Kernel)Native.DllImports.kernelCreateFromString(h, w, cy, cx, kdata);
        }

        /// <summary>
        ///       (1) The file contains, in the following order:
        ///            ~Any number of comment lines starting with '#' are ignored
        ///            ~The height and width of the kernel
        ///            ~The y and x values of the kernel origin
        ///            ~The kernel data, formatted as lines of numbers(integers
        /// or floats) for the kernel values in row-major order,
        ///              and with no other punctuation.
        /// 
        ///             (Note: this differs from kernelCreateFromString(),
        ///              where each line must begin and end with a double-quote
        ///  to tell the compiler it's part of a string.)
        ///            ~The kernel specification ends when a blank line,
        ///              a comment line, or the end of file is reached.
        ///       (2) All lines must be left-justified.
        ///       (3) See kernelCreateFromString() for a description of the string
        ///  format for the kernel data.As an example, here are the lines
        ///           of a valid kernel description file  In the file, all lines
        ///           are left-justified:
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>kernel, or NULL on error</returns>
        public static L_Kernel CreateFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(string.Format("The file {0} not found.", filename));

            return (L_Kernel)Native.DllImports.kernelCreateFromFile(filename);
        }

        /// <summary>
        /// The origin must be positive and within the dimensions of the pix.
        /// </summary>
        /// <param name="pix">pix</param>
        /// <param name="cy">cy, cx origin of kernel</param>
        /// <param name="cx">cy, cx origin of kernel</param>
        /// <returns></returns>
        public static L_Kernel CreateFromPix(Pix pix, int cy, int cx)
        { 
            return (L_Kernel)Native.DllImports.kernelCreateFromPix((HandleRef)pix, cy, cx);
        }

        /// <summary>
        /// The numbers can be ints or floats.
        /// </summary>
        /// <param name="str">str string containing numbers; not changed</param>
        /// <param name="seps">seps string of characters that can be used between ints</param>
        /// <returns>numa of numbers found, or NULL on error</returns>
        public static Numa ParseStringForNumbers(string str, string seps)
        {
            return (Numa)Native.DllImports.parseStringForNumbers(str, seps);
        }

        /// <summary>
        ///  (1) This is the same low-pass filtering kernel that is used
        ///           in the block convolution functions.
        ///  (2) The kernel origin(%cy, %cx) is typically placed as near
        ///      the center of the kernel as possible.If height and
        ///      width are odd, then using cy = height / 2 and
        ///      cx = width / 2 places the origin at the exact center.
        ///  (3) This returns a normalized kernel.
        /// </summary>
        /// <param name="height">height, width</param>
        /// <param name="width">height, width</param>
        /// <param name="cy">cy, cx origin of kernel</param>
        /// <param name="cx">cy, cx origin of kernel</param>
        /// <returns>kernel, or NULL on error</returns>
        public static L_Kernel MakeFlatKernel(int height, int width, int cy, int cx)
        {
            return (L_Kernel)Native.DllImports.makeFlatKernel(height, width, cy, cx);
        }

        /// <summary>
        ///       (1) The kernel size(sx, sy) = (2 * halfwidth + 1, 2 * halfheight + 1).
        ///       (2) The kernel center(cx, cy) = (halfwidth, halfheight).
        ///       (3) The halfwidth and halfheight are typically equal, and
        ///  are typically several times larger than the standard deviation.
        ///       (4) If pixConvolve() is invoked with normalization(the sum of
        /// kernel elements = 1.0), use 1.0 for max(or any number that's
        ///           not too small or too large).
        /// </summary>
        /// <param name="halfheight">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="halfwidth">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="stdev">stdev standard deviation</param>
        /// <param name="max">max value at (cx,cy)</param>
        /// <returns>kernel, or NULL on error</returns>
        public static L_Kernel MakeGaussianKernel(int halfheight, int halfwidth, float stdev, float max)
        {
            return (L_Kernel)Native.DllImports.makeGaussianKernel(halfheight, halfwidth, stdev, max);
        }

        /// <summary>
        ///       (1) See makeGaussianKernel() for description of input parameters.
        ///       (2) These kernels are constructed so that the result of both
        ///           normalized and un-normalized convolution will be the same
        ///           as when convolving with pixConvolve() using the full kernel.
        ///       (3) The trick for the un-normalized convolution is to have the
        ///  product of the two kernel elemets at(cx, cy) be equal to max,
        ///  not max**2.  That's why the max for kely is 1.0.  If instead
        ///  we use sqrt(max) for both, the results are slightly less
        ///  accurate, when compared to using the full kernel in
        ///  makeGaussianKernel().
        /// </summary>
        /// <param name="halfheight">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="halfwidth">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="stdev">stdev standard deviation</param>
        /// <param name="max">max value at (cx,cy)</param>
        /// <param name="pkelx">pkelx x part of kernel</param>
        /// <param name="pkely">pkelx y part of kernel</param>
        /// <returns></returns>
        public static bool MakeGaussianKernelSep(int halfheight, int halfwidth, float stdev, float max, out L_Kernel pkelx, out L_Kernel pkely)
        {
            IntPtr pkelxPtr, pkelyPtr;

            var result = Native.DllImports.makeGaussianKernelSep(halfheight, halfwidth, stdev, max, out pkelxPtr, out pkelyPtr) == 0;

            pkelx = (L_Kernel)pkelxPtr;
            pkely = (L_Kernel)pkelyPtr;

            return result;
        }

        /// <summary>
        ///       (1) The DoG(difference of gaussians) is a wavelet mother  * function with null total sum.By subtracting two blurred
        ///  versions of the image, it acts as a bandpass filter for
        ///           frequencies passed by the narrow gaussian but stopped
        ///           by the wide one.See:
        ///                http://en.wikipedia.org/wiki/Difference_of_Gaussians
        ///       (2) The kernel size(sx, sy) = (2 * halfwidth + 1, 2 * halfheight + 1).
        ///       (3) The kernel center(cx, cy) = (halfwidth, halfheight).
        ///       (4) The halfwidth and halfheight are typically equal, and
        ///  are typically several times larger than the standard deviation.
        ///       (5) The ratio is the ratio of standard deviations of the wide
        ///           to narrow gaussian.It must be >= 1.0; 1.0 is a no-op.
        /// 
        ///      (6) Because the kernel is a null sum, it must be invoked without
        /// normalization in pixConvolve().
        /// </summary>
        /// <param name="halfheight">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="halfwidth">halfheight, halfwidth sx = 2 * halfwidth + 1, etc</param>
        /// <param name="stdev">stdev standard deviation of narrower gaussian</param>
        /// <param name="ratio">ratio of stdev for wide filter to stdev for narrow one</param>
        /// <returns>kernel, or NULL on error</returns>
        public static L_Kernel MakeDoGKernel(int halfheight, int halfwidth, float stdev, float ratio)
        {
            return (L_Kernel)Native.DllImports.makeDoGKernel(halfheight, halfwidth, stdev, ratio);
        }

        /// <summary>
        /// Explicitly cast IntPtr to L_Kernal
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator L_Kernel(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new L_Kernel(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// kernelCopy()
        /// </summary>
        /// <returns>keld copy of kels, or NULL on error</returns>
        public L_Kernel Copy()
        {
            return (L_Kernel)Native.DllImports.kernelCopy((HandleRef)this);
        }

        /// <summary>
        /// kernelDestroy()
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.kernelDestroy(ref toDestroy);
        }
    }
}
