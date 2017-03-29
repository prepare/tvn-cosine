using System;

namespace Tvn.Cosine.Imaging.Leptonica.Drawing
{
    public class PixDrawing
    {
        /// <summary>
        ///      (1) If pixs is 1 bpp, we paint the boxa using a colormap;
        /// otherwise, we convert to 32 bpp.
        ///
        ///      (2) We use up to 254 different colors for painting the regions.
        ///
        ///      (3) If boxes overlap, the later ones paint over earlier ones.
        /// </summary>
        /// <param name="pix">pixs any depth, can be cmapped</param>
        /// <param name="boxa">boxa of boxes, to paint</param> 
        /// <returns>pixd with painted boxes, or NULL on error</returns>
        public Pix PaintBoxaRandom(Pix pix, Boxa boxa)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.Count < 1)
            {
                return null;
            }

            var pointer = Native.DllImports.pixPaintBoxaRandom(pix.handleRef, boxa.handleRef);

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
        ///      (1) If pixs is 1 bpp, we draw the boxa using a colormap;
        /// otherwise, we convert to 32 bpp.
        ///
        ///      (2) We use up to 254 different colors for drawing the boxes.
        ///
        ///      (3) If boxes overlap, the later ones draw over earlier ones.
        /// </summary>
        /// <param name="pix">pixs any depth, can be cmapped</param>
        /// <param name="boxa">boxa of boxes, to draw</param>
        /// <param name="width">width thickness of line</param>
        /// <returns>pixd with box outlines drawn, or NULL on error</returns>
        public Pix DrawBoxaRandom(Pix pix, Boxa boxa, int width)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.Count < 1)
            {
                return null;
            }

            var pointer = Native.DllImports.pixDrawBoxaRandom(pix.handleRef, boxa.handleRef, width);

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
        ///      (1) If pixs is 1 bpp or is colormapped, it is converted to 8 bpp
        /// and the boxa is painted using a colormap; otherwise,
        /// it is converted to 32 bpp rgb.
        ///      (2) There are several ways to display a box on an image:
        ///* Paint it as a solid color
        /// Draw the outline
        ///* Blend the outline or region with the existing image
        /// We provide painting and drawing here; blending is in blend.c.
        ///
        ///When painting or drawing, the result can be either a
        /// cmapped image or an rgb image.The dest will be cmapped
        ///         if the src is either 1 bpp or has a cmap that is not full.
        ///          To force RGB output, use pixConvertTo8(pixs, FALSE)
        /// before calling any of these paint and draw functions.
        /// </summary>
        /// <param name="pix">pixs any depth, can be cmapped</param>
        /// <param name="boxa">boxa of boxes, to paint</param>
        /// <param name="fillColor">al rgba color to paint</param>
        /// <returns>pixd with painted boxes, or NULL on error</returns>
        public Pix PaintBoxa(Pix pix, Boxa boxa, Color fillColor)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.Count < 1 || fillColor == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixPaintBoxa(pix.handleRef, boxa.handleRef, fillColor.ToAbgrUint());

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
        ///      (1) If pixs is 1 bpp or is colormapped, it is converted to 8 bpp
        /// and the boxa is drawn using a colormap; otherwise,
        /// it is converted to 32 bpp rgb.
        /// </summary>
        /// <param name="pix">pixs any depth; can be cmapped</param>
        /// <param name="boxa">boxa of boxes, to draw</param>
        /// <param name="width">width of lines</param>
        /// <param name="lineColor">val rgba color to draw</param>
        /// <returns>pixd with outlines of boxes added, or NULL on error</returns>
        public Pix DrawBoxa(Pix pix, Boxa boxa, int width, Color lineColor)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.Count < 1 || lineColor == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixDrawBoxa(pix.handleRef, boxa.handleRef, width, lineColor.ToAbgrUint());

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
        ///      (1) This can be used with:
        ///              pixd = NULL(makes a new pixd)
        ///              pixd = pixs(in-place)
        ///      (2) If pixd == NULL, this first makes a copy of pixs, and then
        /// bit-twiddles over the boxes.Otherwise, it operates directly
        /// on pixs.
        ///
        ///      (3) This simple function is typically used with 1 bpp images.
        ///          It uses the 1-image rasterop function, rasteropUniLow(),
        ///          to set, clear or flip the pixels in pixd.
        ///      (4) If you want to generate a 1 bpp mask of ON pixels from the boxes
        ///          in a Boxa, in a pix of size(w, h):
        ///              pix = pixCreate(w, h, 1);
        ///              pixMaskBoxa(pix, pix, boxa, L_SET_PIXELS);
        /// </summary>
        /// <param name="destination">pixd [optional] may be NULL</param>
        /// <param name="source">pixs any depth; not cmapped</param>
        /// <param name="boxa">boxa of boxes, to paint</param>
        /// <param name="op">op L_SET_PIXELS, L_CLEAR_PIXELS, L_FLIP_PIXELS</param>
        /// <returns>pixd with masking op over the boxes, or NULL on error</returns>
        public Pix MaskBoxa(Pix destination, Pix source, Boxa boxa, GraphicPixelSetting op)
        {
            //ensure pix is not null;
            if (source == null || boxa == null)
            {
                return null;
            }
            if (destination == null)
            {
                destination = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixMaskBoxa(destination.handleRef, source.handleRef, boxa.handleRef, op);
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
        /// (1) See pixGetBlackOrWhiteVal() for values of black and white pixels.
        /// </summary>
        /// <param name="source">pixs all depths; colormap ok</param>
        /// <param name="width">npix number of pixels to be added to each side</param>
        /// <param name="borderColor">val  value of added border pixels</param>
        /// <returns>pixd with the added exterior pixels, or NULL on error</returns>
        public Pix AddBorder(Pix source, int width, Color borderColor)
        {
            //ensure pix is not null;
            if (source == null || borderColor == null || width < 1)
            {
                return null;
            }

            var pointer = Native.DllImports.pixAddBorder(source.handleRef, width, borderColor.ToAbgrUint());
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
        /// d = (d & ~m) | (s & m)
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
        public bool CombineMask(Pix destination, Pix source, Pix mask)
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
        ///             pixRasterop(pixd, x, y, wmin, hmin, PIX_DST & PIX_NOT(PIX_SRC),
        ///                         pixm8, 0, 0);
        ///             pixRasterop(pixd, x, y, wmin, hmin, PIX_SRC | PIX_DST,
        /// pixt, 0, 0);
        ///             pixDestroy(&pixt);
        ///             pixDestroy(&pixm8);
        /// </summary>
        /// <param name="destination">pixd 1 bpp, 8 bpp gray or 32 bpp rgb</param>
        /// <param name="source">pixs 1 bpp, 8 bpp gray or 32 bpp rgb</param>
        /// <param name="mask">pixm [optional] 1 bpp mask</param>
        /// <param name="x">x, y origin of pixs and pixm relative to pixd; can be negative</param>
        /// <param name="y">x, y origin of pixs and pixm relative to pixd; can be negative</param>
        /// <returns>true if OK; false on error</returns>
        public bool CombineMaskedGeneral(Pix destination, Pix source, Pix mask, int x, int y)
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
        ///           into which you want to write, and use PIX_SRC & PIX_DST to
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
        public bool PaintThroughMask(Pix destination, Pix mask, int x, int y, Color paintColor)
        {
            //ensure pix is not null;
            if (destination == null || mask == null)
            {
                return false;
            }

            return Native.DllImports.pixPaintThroughMask(destination.handleRef, mask.handleRef, x, y, paintColor.ToAbgrUint()) == 0;
        }
    }
}
