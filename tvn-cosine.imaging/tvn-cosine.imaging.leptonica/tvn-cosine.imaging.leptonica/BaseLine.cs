using System;

namespace Leptonica
{
    /// <summary>
    /// baseline.c
    /// </summary>
    public static class BaseLine
    {
        /// <summary>
        ///      (1) Input binary image must have text lines already aligned
        /// horizontally.This can be done by either rotating the
        /// image with pixDeskew(), or, if a projective transform
        ///         is required, by doing pixDeskewLocal() first.
        ///
        ///     (2) Input null for &pta if you don't want this returned.
        ///          The pta will come in pairs of points(left and right end
        ///          of each baseline).
        ///      (3) Caution: this will not work properly on text with multiple
        ///          columns, where the lines are not aligned between columns.
        ///          If there are multiple columns, they should be extracted
        ///          separately before finding the baselines.
        ///      (4) This function constructs different types of output
        ///          for baselines; namely, a set of raster line values and
        /// a set of end points of each baseline.
        ///
        ///     (5) This function was designed to handle short and long text lines
        ///without using dangerous thresholds on the peak heights.It does
        /// this by combining the differential signal with a morphological
        ///          analysis of the locations of the text lines.  One can also
        /// combine this data to normalize the peak heights, by weighting
        ///          the differential signal in the region of each baseline
        /// by the inverse of the width of the text line found there.
        /// </summary>
        /// <param name="pixs"> pixs 1 bpp</param>
        /// <param name="ppta"> ppta [optional] pairs of pts corresponding to   approx. ends of each text line</param>
        /// <param name="debug">debug usually false; set to true for debugging output</param>
        /// <returns>na of baseline y values, or NULL on error</returns>
        public static Numa pixFindBaselines(Pix pixs, out Pta ppta, bool debug)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                ppta = null;
                return null;
            }

            IntPtr pptaPtr;
            var pointer = Native.DllImports.pixFindBaselines(pixs.handleRef, out pptaPtr, debug ? 1 : 0);

            if (pointer != IntPtr.Zero)
            {
                ppta = new Pta(pptaPtr);
                return new Numa(pointer);
            }
            else
            {
                ppta = null;
                return null;
            }
        }

        /// <summary>
        ///       (1) This function allows deskew of a page whose skew changes
        ///           approximately linearly with vertical position.It uses
        ///           a projective transform that in effect does a differential
        ///           shear about the LHS of the page, and makes all text lines
        ///  horizontal.
        ///       (2) The origin of the keystoning can be either a cheap document
        ///  feeder that rotates the page as it is passed through, or a
        /// camera image taken from either the left or right side
        /// of the vertical.
        ///      (3) The image transformation is a projective warping,
        ///          not a rotation.Apart from this function, the text lines
        /// must be properly aligned vertically with respect to each
        ///          other.This can be done by pre-processing the page; e.g.,
        ///          by rotating or horizontally shearing it.
        ///          Typically, this can be achieved by vertically aligning
        ///          the page edge.
        /// </summary>
        /// <param name="pixs">pixs</param>
        /// <param name="nslices">nslices  the number of horizontal overlapping slices; must be larger than 1 and not exceed 20; use 0 for default</param>
        /// <param name="redsweep">redsweep sweep reduction factor: 1, 2, 4 or 8; use 0 for default value</param>
        /// <param name="redsearch">redsearch search reduction factor: 1, 2, 4 or 8, and not larger than redsweep; use 0 for default value</param>
        /// <param name="sweeprange"> sweeprange half the full range, assumed about 0; in degrees; use 0.0 for default value</param>
        /// <param name="sweepdelta"> sweepdelta angle increment of sweep; in degrees; use 0.0 for default value</param>
        /// <param name="minbsdelta">minbsdelta min binary search increment angle; in degrees; use 0.0 for default value</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixDeskewLocal(Pix pixs, int nslices, DeskewRedSweep redsweep, DeskewRedSearch redsearch, float sweeprange, float sweepdelta, float minbsdelta)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixDeskewLocal(pixs.handleRef, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (1) This generates two pairs of points in the src, each pair
        ///           corresponding to a pair of points that would lie along
        ///           the same raster line in a transformed(dewarped) image.
        /// 
        ///      (2) The sets of 4 src and 4 dest points returned by this function
        /// can then be used, in a projective or bilinear transform,
        ///           to remove keystoning in the src.
        /// </summary>
        /// <param name="pixs">pixs</param>
        /// <param name="nslices">nslices  the number of horizontal overlapping slices; must be larger than 1 and not exceed 20; use 0 for default</param>
        /// <param name="redsweep">redsweep sweep reduction factor: 1, 2, 4 or 8;use 0 for default value</param>
        /// <param name="redsearch">redsearch search reduction factor: 1, 2, 4 or 8, and not larger than redsweep; use 0 for default value</param>
        /// <param name="sweeprange">sweeprange half the full range, assumed about 0; in degrees; use 0.0 for default value</param>
        /// <param name="sweepdelta">sweepdelta angle increment of sweep; in degrees; use 0.0 for default value</param>
        /// <param name="minbsdelta">minbsdelta min binary search increment angle; in degrees;use 0.0 for default value </param>
        /// <param name="pptas">pptas  4 points in the source</param>
        /// <param name="pptad">pptad  the corresponding 4 pts in the dest</param>
        /// <returns>true if OK,false on error</returns>
        public static bool pixGetLocalSkewTransform(Pix pixs, int nslices, DeskewRedSweep redsweep, DeskewRedSearch redsearch, float sweeprange, float sweepdelta, float minbsdelta, out Pta pptas, out Pta pptad)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                pptas = null;
                pptad = null;
                return false;
            }

            IntPtr pptasPtr, pptadPtr;
            var answer = Native.DllImports.pixGetLocalSkewTransform(pixs.handleRef, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta, out pptasPtr, out pptadPtr);

            if (answer != 0)
            {

                pptas = new Pta(pptasPtr);
                pptad = new Pta(pptadPtr);
                return true;
            }
            else
            {
                pptas = null;
                pptad = null;
                return false;
            }
        }

        /// <summary>
        ///       (1) The local skew is measured in a set of overlapping strips.
        ///  We then do a least square linear fit parameters to get
        ///           the slope and intercept parameters a and b in
        ///               skew-angle = a* y + b(degrees)
        ///           for the local skew as a function of raster line y.
        ///           This is then used to make naskew, which can be interpreted
        ///           as the computed skew angle (in degrees) at the left edge
        ///           of each raster line.
        ///       (2) naskew can then be used to find the baselines of text, because
        ///  each text line has a baseline that should intersect
        ///           the left edge of the image with the angle given by this
        ///           array, evaluated at the raster line of intersection.
        /// </summary>
        /// <param name="pixs">pixs</param>
        /// <param name="nslices"> nslices the number of horizontal overlapping slices; must be larger than 1 and not exceed 20; 0 for default</param>
        /// <param name="redsweep">sweep reduction factor: 1, 2, 4 or 8; use 0 for default value</param>
        /// <param name="redsearch">search reduction factor: 1, 2, 4 or 8, and not larger than redsweep; use 0 for default value</param>
        /// <param name="sweeprange">half the full range, assumed about 0; in degrees; use 0.0 for default value</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees;  use 0.0 for default value</param>
        /// <param name="minbsdelta">min binary search increment angle; in degrees; use 0.0 for default value</param>
        /// <param name="pa">pa [optional] slope of skew as fctn of y</param>
        /// <param name="pb">pb [optional] intercept at y=0 of skew as fctn of y</param>
        /// <returns>naskew, or NULL on error</returns>
        public static Numa pixGetLocalSkewAngles(Pix pixs, int nslices, DeskewRedSweep redsweep, DeskewRedSearch redsearch, float sweeprange, float sweepdelta, float minbsdelta, out float pa, out float pb)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                pa = 0;
                pb = 0;
                return null;
            }

            var pointer = Native.DllImports.pixGetLocalSkewAngles(pixs.handleRef, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta, out pa, out pb);

            if (pointer != IntPtr.Zero)
            { 
                return new Numa(pointer);
            }
            else
            {
                pa = 0;
                pb = 0;
                return null;
            }
        }
    }
}
