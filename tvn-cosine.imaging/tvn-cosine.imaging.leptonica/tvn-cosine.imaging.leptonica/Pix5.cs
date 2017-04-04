using System;

namespace Leptonica
{
    /// <summary>
    /// Pix5.c
    /// </summary>
    public static class Pix5
    { 
        //    Extract rectangular region
        //           PIXA       *pixClipRectangles() 
        //           PIX        *pixClipMasked()
        //           l_int32     pixCropToMatch()
        //           PIX        *pixCropToSize()
        //           PIX        *pixResizeToMatch()

        /// <summary>
        ///  This should be simple, but there are choices to be made.
        ///  The box is defined relative to the pix coordinates.  However,
        ///  if the box is not contained within the pix, we have two choices:
        ///
        ///      (1) clip the box to the pix
        ///      (2) make a new pix equal to the full box dimensions,
        ///          but let rasterop do the clipping and positioning
        ///          of the src with respect to the dest
        ///
        ///  Choice(2) immediately brings up the problem of what pixel values
        /// to use that were not taken from the src.For example, on a grayscale
        /// image, do you want the pixels not taken from the src to be black
        ///  or white or something else?  To implement choice 2, one needs to
        /// specify the color of these extra pixels.
        ///
        ///  So we adopt (1), and clip the box first, if necessary,
        ///  before making the dest pix and doing the rasterop.But there
        ///  is another issue to consider.If you want to paste the
        /// clipped pix back into pixs, it must be properly aligned, and
        /// it is necessary to use the clipped box for alignment.
        /// Accordingly, this function has a third (optional) argument, which is
        ///  the input box clipped to the src pix.
        /// </summary>
        /// <param name="source">pixs</param>
        /// <param name="box">box  requested clipping region; const</param>
        /// <param name="pboxc">pboxc [optional] actual box of clipped region</param>
        /// <returns> clipped pix, or NULL on error or if rectangle doesnt intersect pixs</returns>
        public static Pix pixClipRectangle(Pix source, Box box, out Box pboxc)
        {
            if (source == null || box == null)
            {
                pboxc = null;
                return null;
            }

            IntPtr pboxcPntr;
            var pointer = Native.DllImports.pixClipRectangle(source.handleRef, box.handleRef, out pboxcPntr);
            pboxc = new Box(pboxcPntr);
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }


        //       *  *    Measurement of properties
        //           l_int32     pixaFindDimensions()
        //           l_int32     pixFindAreaPerimRatio()
        //           NUMA       *pixaFindPerimToAreaRatio()
        //           l_int32     pixFindPerimToAreaRatio()
        //           NUMA       *pixaFindPerimSizeRatio()
        //           l_int32     pixFindPerimSizeRatio()
        //           NUMA       *pixaFindAreaFraction()
        //           l_int32     pixFindAreaFraction()
        //           NUMA       *pixaFindAreaFractionMasked()
        //           l_int32     pixFindAreaFractionMasked()
        //           NUMA       *pixaFindWidthHeightRatio()
        //           NUMA       *pixaFindWidthHeightProduct()
        //           l_int32     pixFindOverlapFraction()
        //           BOXA       *pixFindRectangleComps()
        //           l_int32     pixConformsToRectangle()
        //
        //
        //    Make a frame mask
        //           PIX        *pixMakeFrameMask()
        //
        //    Fraction of Fg pixels under a mask
        //           l_int32     pixFractionFgInMask()
        //
        //    Clip to foreground
        //           PIX        *pixClipToForeground()
        //           l_int32     pixTestClipToForeground()
        //           l_int32     pixClipBoxToForeground()
        //           l_int32     pixScanForForeground()
        //           l_int32     pixClipBoxToEdges()
        //           l_int32     pixScanForEdge()
        //
        //    Extract pixel averages and reversals along lines
        //           NUMA       *pixExtractOnLine()
        //           l_float32   pixAverageOnLine()
        //           NUMA       *pixAverageIntensityProfile()
        //           NUMA       *pixReversalProfile()
        //
        //    Extract windowed variance along a line
        //           NUMA       *pixWindowedVarianceOnLine()
        //
        //    Extract min/max of pixel values near lines
        //           l_int32     pixMinMaxNearLine()
        //
        //    Rank row and column transforms
        //           PIX        *pixRankRowTransform()
        //           PIX        *pixRankColumnTransform() 
    }
}
