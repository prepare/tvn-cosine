using System;
using Tvn.Cosine.Imaging;

namespace Leptonica
{
    /// <summary>
    /// boxfunc3.c
    /// </summary>
    public static class BoxFunc3
    {
        // Boxa/Boxaa painting into pix
        //           PIX* pixMaskConnComp()  
        //           PIX* pixSetBlackOrWhiteBoxa() 
        //           PIX* pixBlendBoxaRandom() 
        //           PIX* boxaaDisplay()
        //           PIXA* pixaDisplayBoxaa()

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
        public static Pix MaskBoxa(Pix destination, Pix source, Boxa boxa, GraphicPixelSetting op)
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
        public static Pix PaintBoxa(Pix pix, Boxa boxa, Color fillColor)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.GetCount() < 1 || fillColor == null)
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
        public static Pix PaintBoxaRandom(Pix pix, Boxa boxa)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.GetCount() < 1)
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
        public static Pix DrawBoxaRandom(Pix pix, Boxa boxa, int width)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.GetCount() < 1)
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
        /// and the boxa is drawn using a colormap; otherwise,
        /// it is converted to 32 bpp rgb.
        /// </summary>
        /// <param name="pix">pixs any depth; can be cmapped</param>
        /// <param name="boxa">boxa of boxes, to draw</param>
        /// <param name="width">width of lines</param>
        /// <param name="lineColor">val rgba color to draw</param>
        /// <returns>pixd with outlines of boxes added, or NULL on error</returns>
        public static Pix DrawBoxa(Pix pix, Boxa boxa, int width, Color lineColor)
        {
            //ensure pix is not null;
            if (pix == null || boxa == null || boxa.GetCount() < 1 || lineColor == null)
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


        // Split mask components into Boxa
        // BOXA            *pixSplitIntoBoxa()
        //           BOXA* pixSplitComponentIntoBoxa()
        //           static l_int32 pixSearchForRectangle()
        //
        //      Represent horizontal or vertical mosaic strips
        //           BOXA* makeMosaicStrips()
        //
        // Comparison between boxa
        // l_int32          boxaCompareRegions()
        //
        // Reliable selection of a single large box
        // BOX             *pixSelectLargeULComp()
        //           BOX* boxaSelectLargeULBox()  
    }
}
