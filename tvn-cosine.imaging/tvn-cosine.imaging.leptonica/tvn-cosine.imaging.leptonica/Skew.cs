using System;

namespace Leptonica
{
    /// <summary>
    /// skew.c
    /// </summary>
    public static class Skew
    { 
        // Top-level angle-finding interface 
        /// <summary>
        ///      (1) This is a simple high-level interface, that uses default
        ///          values of the parameters for reasonable speed and accuracy.
        ///      (2) The angle returned is the negative of the skew angle of
        /// the image.It is the angle required for deskew.
        ///
        /// Clockwise rotations are positive angles.
        /// </summary>
        /// <param name="pix">pixs  1 bpp</param>
        /// <param name="radiance">pangle   angle required to deskew, in degrees</param>
        /// <param name="confidence">pconf    confidence value is ratio max/min scores</param>
        /// <returns>true if OK, false on error or if angle measurment not valid</returns>
        public static bool pixFindSkew(Pix pix, out float radiance, out float confidence)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                radiance = 0;
                confidence = 0;
                return false;
            }

            return Native.DllImports.pixFindSkew(pix.handleRef, out radiance, out confidence) == 0;
        }


        // Top-level deskew interfaces   
        /// <summary>
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs any depth</param>
        /// <param name="redSearch">redsearch for binary search: reduction factor = 1, 2 or 4; use 0 for default</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixDeskew(Pix pix, DeskewRedSearch redSearch = DeskewRedSearch.DEFAULT)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixDeskew(pix.handleRef, redSearch);
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
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs any depth</param>
        /// <param name="redsearch">redsearch for binary search: reduction factor = 1, 2 or 4;use 0 for default</param>
        /// <param name="pangle">pangle   [optional] angle required to deskew,in degrees; use NULL to skip</param>
        /// <param name="pconf">pconf    [optional] conf value is ratio of max/min scores; use NULL to skip</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixFindSkewAndDeskew(Pix pix, DeskewRedSearch redsearch, out float pangle, out float pconf)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                pangle = 0;
                pconf = 0;
                return null;
            }

            var pointer = Native.DllImports.pixFindSkewAndDeskew(pix.handleRef, redsearch, out pangle, out pconf);
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
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs  any depth</param>
        /// <param name="redsweep">redsweep  for linear search: reduction factor = 1, 2 or 4;use 0 for default</param>
        /// <param name="sweepRange">sweeprange in degrees in each direction from 0;use 0.0 for default</param>
        /// <param name="sweepDelta">sweepdelta in degrees; use 0.0 for default</param>
        /// <param name="redsearch">redsearch  for binary search: reduction factor = 1, 2 or 4;use 0 for default;</param>
        /// <param name="threshold">thresh for binarizing the image; use 0 for default</param>
        /// <param name="radiance">pangle   [optional] angle required to deskew,in degrees; use NULL to skip</param>
        /// <param name="confidence">[optional] conf value is ratio of max/min scores; use NULL to skip</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixDeskewGeneral(Pix pix, DeskewRedSweep redsweep, float sweepRange, float sweepDelta, DeskewRedSearch redsearch, int threshold, out float radiance, out float confidence)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                radiance = 0;
                confidence = 0;
                return null;
            }

            var pointer = Native.DllImports.pixDeskewGeneral(pix.handleRef, redsweep, sweepRange, sweepDelta, redsearch, threshold, out radiance, out confidence);
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                radiance = 0;
                confidence = 0;
                return null;
            }
        }


        //
        //
        //      Basic angle-finding functions
        //          l_int32    pixFindSkewSweep()
        //          l_int32    pixFindSkewSweepAndSearch()
        //          l_int32    pixFindSkewSweepAndSearchScore()
        //          l_int32    pixFindSkewSweepAndSearchScorePivot()
        //
        //      Search over arbitrary range of angles in orthogonal directions
        //          l_int32    pixFindSkewOrthogonalRange()
        //
        //      Differential square sum function for scoring
        //          l_int32    pixFindDifferentialSquareSum()
        //
        //      Measures of variance of row sums
        //          l_int32    pixFindNormalizedSquareSum() 
    }
}
