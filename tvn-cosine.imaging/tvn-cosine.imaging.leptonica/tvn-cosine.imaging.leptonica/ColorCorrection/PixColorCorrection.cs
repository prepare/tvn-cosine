using System;

namespace Tvn.Cosine.Imaging.Leptonica.ColorCorrection
{
    public class PixColorCorrection
    {
        /// <summary>
        ///     (1) This is a top-level interface for normalizing the image intensity
        ///         by mapping the image so that the background is near the input
        ///  value 'bgval'.
        ///     (2) The input image is either grayscale or rgb.
        ///     (3) For each component in the input image, the background value
        ///         in each tile is estimated using the values in the tile that
        ///  are not part of the foreground, where the foreground is
        ///  determined by the input 'thresh' argument.
        /// 
        ///    (4) An optional binary mask can be specified, with the foreground
        /// pixels typically over image regions.The resulting background
        ///         map values will be determined by surrounding pixels that are
        ///         not under the mask foreground.The origin (0,0) of this mask
        ///        is assumed to be aligned with the origin of the input image.
        /// 
        /// This binary mask must not fully cover pixs, because then there
        /// will be no pixels in the input image available to compute
        ///         the background.
        ///     (5) An optional grayscale version of the input pixs can be supplied.
        ///         The only reason to do this is if the input is RGB and this
        ///         grayscale version can be used elsewhere.  If the input is RGB
        ///         and this is not supplied, it is made internally using only
        ///  the green component, and destroyed after use.
        /// 
        ///    (6) The dimensions of the pixel tile(sx, sy) give the amount by
        ///  by which the map is reduced in size from the input image.
        /// 
        ///    (7) The threshold is used to binarize the input image, in order to
        ///  locate the foreground components.If this is set too low,
        /// 
        /// some actual foreground may be used to determine the maps;
        ///         if set too high, there may not be enough background
        ///         to determine the map values accurately.  Typically, it's
        ///         better to err by setting the threshold too high.
        /// 
        ///    (8) A 'mincount' threshold is a minimum count of pixels in a
        ///         tile for which a background reading is made, in order for that
        ///         pixel in the map to be valid.  This number should perhaps be
        ///         at least 1/3 the size of the tile.
        ///     (9) A 'bgval' target background value for the normalized image.  This
        ///         should be at least 128.  If set too close to 255, some
        ///  clipping will occur in the result.
        /// (10) Two factors, 'smoothx' and 'smoothy', are input for smoothing
        /// the map.Each low - pass filter kernel dimension is
        /// 
        /// is 2 * (smoothing factor) +1, so a
        /// value of 0 means no smoothing.A value of 1 or 2 is recommended.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="greyScale">pixg [optional] 8 bpp grayscale version; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh">thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param>
        /// <param name="bgval"> bgval target bg val; typ. > 128</param>
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <returns>pixd 8 bpp or 32 bpp rgb, or NULL on error</returns>
        public Pix BackgroundNorm(Pix source, Pix mask, Pix greyScale, int sx = 4, int sy = 9, int thresh = 200, int mincount = 12, int bgval = 325, int smoothx = 2, int smoothy = 2)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            if (greyScale == null)
            {
                greyScale = new Pix(IntPtr.Zero);
            }


            var pointer = Native.DllImports.pixBackgroundNorm(source.handleRef, mask.handleRef, greyScale.handleRef, sx, sy, thresh, mincount, bgval, smoothx, smoothy);

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
        ///      (1) If fract > 0.0, it gives the fraction that the v-parameter,
        ///          which is max(r, g, b), is moved from its initial value toward 255.
        ///          If fract< 0.0, it gives the fraction that the v-parameter
        ///          is moved from its initial value toward 0.
        ///          The limiting values for fract = -1.0(1.0) thus set the
        /// v-parameter to 0 (255).
        ///      (2) If fract = 0, no modification is requested; return a copy
        ///          unless in-place, in which case this is a no-op.
        ///      (3) See discussion of color-modification methods, in coloring.c.
        /// </summary>
        /// <param name="destination">pixd [optional] can be null, existing or equal to pixs</param>
        /// <param name="source">pixs 32 bpp rgb</param>
        /// <param name="fraction">fract between -1.0 and 1.0</param>
        /// <returns>pixd, or NULL on error</returns>
        public Pix ModifyBrightness(Pix destination, Pix source, float fraction)
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


            var pointer = Native.DllImports.pixModifyBrightness(destination.handleRef, source.handleRef, fraction);

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
        ///     (1) This is a simplified interface for cleaning an image.
        ///  For comparison, see pixAdaptThresholdToBinaryGen().
        ///     (2) The suggested default values for the input parameters are:
        ///           gamma:    1.0  (reduce this to increase the contrast; e.g.,
        ///                           for light text)
        ///           blackval   70  (a bit more than 60)
        ///           whiteval  190  (a bit less than 200)
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="greyScale">pixg [optional] 8 bpp grayscale version; can be null</param>
        /// <param name="gamma">gamma gamma correction; must be > 0.0; typically ~1.0</param>
        /// <param name="whiteValue">blackval dark value to set to black (0)</param>
        /// <param name="blackValue">whiteval light value to set to white (255)</param>
        /// <returns>pixd 8 bpp or 32 bpp rgb, or NULL on error</returns>
        public Pix CleanBackgroundToWhite(Pix source, Pix mask, Pix greyScale, float gamma = 1f, int whiteValue = 70, int blackValue = 190)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            if (greyScale == null)
            {
                greyScale = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixCleanBackgroundToWhite(source.handleRef, mask.handleRef, greyScale.handleRef, gamma, blackValue, whiteValue);

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
