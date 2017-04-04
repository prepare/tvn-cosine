using System;

namespace Leptonica
{
    /// <summary>
    /// Pix3.c
    /// </summary>
    public static class Pix3
    {
        // Masked operations
        //           l_int32     pixSetMasked()
        //           l_int32     pixSetMaskedGeneral()   
        //           PIX        *pixPaintSelfThroughMask()
        //           PIX        *pixMakeMaskFromVal()
        //           PIX        *pixMakeMaskFromLUT()
        //           PIX        *pixSetUnderTransparency()
        //           PIX        *pixMakeAlphaFromMask()
        //           l_int32     pixGetColorNearMaskBoundary()
        //
        //
        //    Foreground pixel counting in 1 bpp images
        //           l_int32     pixZero()
        //           l_int32     pixForegroundFraction()
        //           NUMA       *pixaCountPixels()
        //           l_int32     pixCountPixels()
        //           NUMA       *pixCountByRow()
        //           NUMA       *pixCountByColumn()
        //           NUMA       *pixCountPixelsByRow()
        //           NUMA       *pixCountPixelsByColumn()
        //           l_int32     pixCountPixelsInRow()
        //           NUMA       *pixGetMomentByColumn()
        //           l_int32     pixThresholdPixelSum()
        //           l_int32    *makePixelSumTab8()
        //           l_int32    *makePixelCentroidTab8()
        //
        //    Average of pixel values in gray images
        //           NUMA       *pixAverageByRow()
        //           NUMA       *pixAverageByColumn()
        //           l_int32     pixAverageInRect()
        //
        //    Variance of pixel values in gray images
        //           NUMA       *pixVarianceByRow()
        //           NUMA       *pixVarianceByColumn()
        //           l_int32     pixVarianceInRect()
        //
        //    Average of absolute value of pixel differences in gray images
        //           NUMA       *pixAbsDiffByRow()
        //           NUMA       *pixAbsDiffByColumn()
        //           l_int32     pixAbsDiffInRect()
        //           l_int32     pixAbsDiffOnLine()
        //
        //    Count of pixels with specific value
        //           l_int32     pixCountArbInRect()
        //
        //    Mirrored tiling
        //           PIX        *pixMirroredTiling()
        //
        //    Representative tile near but outside region
        //           l_int32     pixFindRepCloseTile()
        //
        //    Static helper function
        //           static BOXA    *findTileRegionsForSearch() 
         
        /// <summary>
        ///      (1) In-place operation; pixd is changed.
        ///      (2) This sets each pixel in pixd that co-locates with an ON
        ///          pixel in pixm to the corresponding value of pixs.
        ///      (3) pixs and pixd must be the same depth and not colormapped.
        ///      (4) All three input pix are aligned at the UL corner, and the
        /// operation is clipped to the intersection of all three images.
        ///      (5) If pixm == NULL, it's a no-op.
        ///      (6) Implementation: see notes in pixCombineMaskedGeneral().
        ///          For 8 bpp selective masking, you might guess that it
        /// would be faster to generate an 8 bpp version of pixm,
        ///          using pixConvert1To8(pixm, 0, 255), and then use a
        /// general combine operation
        /// d = (d  ~m) | (s  m)
        /// on a word-by-word basis.Not always.The word-by-word
        ///combine takes a time that is independent of the mask data.
        ///
        ///If the mask is relatively sparse, the byte-check method
        ///          is actually faster!
        /// </summary>
        /// <param name="destination">pixd 1 bpp, 8 bpp gray or 32 bpp rgb; no cmap</param>
        /// <param name="source">pixs 1 bpp, 8 bpp gray or 32 bpp rgb; no cmap</param>
        /// <param name="mask">pixm [optional] 1 bpp mask; no operation if NULL</param>
        /// <returns>true of Ok, false on error</returns>
        public static bool pixCombineMasked(Pix destination, Pix source, Pix mask)
        {
            //ensure pix is not null;
            if (source == null || mask == null || destination == null)
            {
                return false;
            }

            return Native.DllImports.pixCombineMasked(destination.handleRef, source.handleRef, mask.handleRef) == 0;
        }

        /// <summary>
        ///      (1) In-place operation; pixd is changed.
        ///      (2) This is a generalized version of pixCombinedMasked(), where
        /// the source and mask can be placed at the same(arbitrary)
        ///          location relative to pixd.
        ///      (3) pixs and pixd must be the same depth and not colormapped.
        ///      (4) The UL corners of both pixs and pixm are aligned with
        /// the point(x, y) of pixd, and the operation is clipped to
        ///          the intersection of all three images.
        ///      (5) If pixm == NULL, it's a no-op.
        ///      (6) Implementation.There are two ways to do these.In the first,
        ///          we use rasterop, ORing the part of pixs under the mask
        ///          with pixd(which has been appropriately cleared there first).
        ///          In the second, the mask is used one pixel at a time to
        /// selectively replace pixels of pixd with those of pixs.
        ///          Here, we use rasterop for 1 bpp and pixel-wise replacement
        ///          for 8 and 32 bpp.To use rasterop for 8 bpp, for example,
        ///
        ///we must first generate an 8 bpp version of the mask.
        ///
        ///The code is simple:
        ///
        ///             Pix* pixm8 = pixConvert1To8(NULL, pixm, 0, 255);
        ///             Pix* pixt = pixAnd(NULL, pixs, pixm8);
        ///             pixRasterop(pixd, x, y, wmin, hmin, PIX_DST  PIX_NOT(PIX_SRC),
        ///                         pixm8, 0, 0);
        ///             pixRasterop(pixd, x, y, wmin, hmin, PIX_SRC | PIX_DST,
        /// pixt, 0, 0);
        ///             pixDestroy( pixt);
        ///             pixDestroy( pixm8);
        /// </summary>
        /// <param name="destination">pixd 1 bpp, 8 bpp gray or 32 bpp rgb</param>
        /// <param name="source">pixs 1 bpp, 8 bpp gray or 32 bpp rgb</param>
        /// <param name="mask">pixm [optional] 1 bpp mask</param>
        /// <param name="x">x, y origin of pixs and pixm relative to pixd; can be negative</param>
        /// <param name="y">x, y origin of pixs and pixm relative to pixd; can be negative</param>
        /// <returns>true if OK; false on error</returns>
        public static bool pixCombineMaskedGeneral(Pix destination, Pix source, Pix mask, int x, int y)
        {
            //ensure pix is not null;
            if (source == null || mask == null || destination == null)
            {
                return false;
            }

            return Native.DllImports.pixCombineMaskedGeneral(destination.handleRef, source.handleRef, mask.handleRef, x, y) == 0;
        }

        /// <summary>
        ///       (1) In-place operation.Calls pixSetMaskedCmap() for colormapped
        /// images.
        ///       (2) For 1, 2, 4, 8 and 16 bpp gray, we take the appropriate
        /// number of least significant bits of val.
        ///       (3) If pixm == NULL, it's a no-op.
        ///       (4) The mask origin is placed at(x, y) on pixd, and the
        ///  operation is clipped to the intersection of rectangles.
        ///       (5) For rgb, the components in val are in the canonical locations,
        ///           with red in location COLOR_RED, etc.
        ///       (6) Implementation detail 1:
        ///           For painting with val == 0 or val == maxval, you can use rasterop.
        ///           If val == 0, invert the mask so that it's 0 over the region
        ///           into which you want to write, and use PIX_SRC  PIX_DST to
        ///           clear those pixels.To write with val = maxval(all 1's),
        ///  use PIX_SRC | PIX_DST to set all bits under the mask.
        ///  (7) Implementation detail 2:
        /// The rasterop trick can be used for depth > 1 as well.
        ///           For val == 0, generate the mask for depth d from the binary
        /// mask using
        ///  pixmd = pixUnpackBinary(pixm, d, 1);
        ///  and use pixRasterop() with PIX_MASK.For val == maxval,
        /// 
        /// pixmd = pixUnpackBinary(pixm, d, 0);
        ///  and use pixRasterop() with PIX_PAINT.
        ///           But note that if d == 32 bpp, it is about 3x faster to use
        ///           the general implementation (not pixRasterop()).
        ///       (8) Implementation detail 3:
        ///  It might be expected that the switch in the inner loop will
        ///  cause large branching delays and should be avoided.
        /// 
        /// This is not the case, because the entrance is always the
        ///  same and the compiler can correctly predict the jump.
        /// </summary>
        /// <param name="destination">pixd 1, 2, 4, 8, 16 or 32 bpp; or colormapped</param>
        /// <param name="mask">pixm [optional] 1 bpp mask</param>
        /// <param name="x">x, y origin of pixm relative to pixd; can be negative</param>
        /// <param name="y">x, y origin of pixm relative to pixd; can be negative</param>
        /// <param name="paintColor">val pixel value to set at each masked pixel</param>
        /// <returns>true if OK; false on error</returns>
        public static bool pixPaintThroughMask(Pix destination, Pix mask, int x, int y, Tvn.Cosine.Imaging.Color paintColor)
        {
            //ensure pix is not null;
            if (destination == null || mask == null)
            {
                return false;
            }

            return Native.DllImports.pixPaintThroughMask(destination.handleRef, mask.handleRef, x, y, paintColor.ToAbgrUint()) == 0;
        }


        //    One and two-image boolean operations on arbitrary depth images 
        //           PIX        *pixOr()
        //           PIX        *pixAnd()
        //           PIX        *pixXor()
        //           PIX        *pixSubtract()
        /// <summary>
        /// One and two-image boolean ops on arbitrary depth images
        /// </summary>
        /// <param name="destination">pixd  [optional]; this can be null, equal to pixs, or different from pixs</param>
        /// <param name="source">pixs</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixInvert(Pix destination, Pix source)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            if (destination == null)
            {
                destination = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixInvert(destination.handleRef, source.handleRef);

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
