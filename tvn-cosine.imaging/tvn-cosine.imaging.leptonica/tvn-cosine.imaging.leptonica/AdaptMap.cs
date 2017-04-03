using System;

namespace Leptonica 
{
    /// <summary>
    /// local adaptive; mostly gray-to-gray in preparation for binarization
    /// </summary>
    public static class AdaptMap
    {
        //Clean background to white using background normalization
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
        public static Pix pixCleanBackgroundToWhite(Pix source, Pix mask, Pix greyScale, float gamma = 1f, int whiteValue = 70, int blackValue = 190)
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


        //Adaptive background normalization (top-level functions)
        /// <summary>
        /// Notes:
        ///    (1) This is a simplified interface to pixBackgroundNorm(),
        ///        where seven parameters are defaulted.
        ///    (2) The input image is either grayscale or rgb.
        ///    (3) See pixBackgroundNorm() for usage and function.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="greyScale">pixg [optional] 8 bpp grayscale version; can be null</param>
        /// <returns>pixd 8 bpp or 32 bpp rgb, or NULL on error</returns>
        public static Pix pixBackgroundNormSimple(Pix source, Pix mask, Pix greyScale)
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

            var pointer = Native.DllImports.pixBackgroundNormSimple(source.handleRef, mask.handleRef, greyScale.handleRef);

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
        public static Pix pixBackgroundNorm(Pix source, Pix mask, Pix greyScale, int sx = 4, int sy = 9, int thresh = 200, int mincount = 12, int bgval = 325, int smoothx = 2, int smoothy = 2)
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
        /// Notes:
        ///    (1) This is a top-level interface for normalizing the image intensity
        ///        by mapping the image so that the background is near the input
        /// value 'bgval'.
        ///    (2) The input image is either grayscale or rgb.
        ///    (3) For each component in the input image, the background value
        ///        is estimated using a grayscale closing; hence the 'Morph'
        ///        in the function name.
        ///    (4) An optional binary mask can be specified, with the foreground
        /// pixels typically over image regions.The resulting background
        ///        map values will be determined by surrounding pixels that are
        ///        not under the mask foreground.The origin (0,0) of this mask
        ///       is assumed to be aligned with the origin of the input image.
        ///
        ///This binary mask must not fully cover pixs, because then there
        ///will be no pixels in the input image available to compute
        ///        the background.
        ///    (5) The map is computed at reduced size (given by 'reduction')
        ///        from the input pixs and optional pixim.  At this scale,
        ///        pixs is closed to remove the background, using a square Sel
        /// of odd dimension.The product of reduction* size should be
        ///        large enough to remove most of the text foreground.
        ///
        ///   (6) No convolutional smoothing needs to be done on the map before
        ///inverting it.
        ///
        ///   (7) A 'bgval' target background value for the normalized image.This
        ///should be at least 128.  If set too close to 255, some
        ///clipping will occur in the result.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixBackgroundNormMorph(Pix source, Pix mask, int reduction, int size, int bgval)
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

            var pointer = Native.DllImports.pixBackgroundNormMorph(source.handleRef, mask.handleRef, reduction, size, bgval);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }


        //Arrays of inverted background values for normalization (16 bpp)
        /// <summary>
        ///  Notes:
        ///     (1) See notes in pixBackgroundNorm().
        ///     (2) This returns a 16 bpp pix that can be used by
        ///  pixApplyInvBackgroundGrayMap() to generate a normalized version
        /// of the input pixs.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale</param>
        /// <param name="mask"> pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">thresh threshold for determining foreground</param>
        /// <param name="thresh">mincount min threshold on counts in a tile</param>
        /// <param name="mincount">bgval target bg val; typ. > 128</param>
        /// <param name="bgval">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothx">smoothy half-width of block convolution kernel width</param>
        /// <param name="smoothy">moothy half-width of block convolution kernel height</param>
        /// <param name="destination">ppixd 16 bpp array of inverted background value</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixBackgroundNormGrayArray(Pix source, Pix mask, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, out Pix destination)
        {
            //ensure pix is not null;
            if (source == null)
            {
                destination = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr pixPointer;
            var result = Native.DllImports.pixBackgroundNormGrayArray(source.handleRef, mask.handleRef, sx, sy, thresh, mincount, bgval, smoothx, smoothy, out pixPointer);

            if (result != 1)
            {
                destination = new Pix(pixPointer);
                return true;
            }
            else
            {
                destination = null;
                return false;
            }
        }

        /// <summary>
        /// Notes:
        ///    (1) See notes in pixBackgroundNorm().
        ///    (2) This returns a set of three 16 bpp pix that can be used by
        /// pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///of each component of the input pixs.
        /// </summary>
        /// <param name="pixs">pixs 32 bpp rgb</param>
        /// <param name="pixim">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="pixg">pixg [optional] 8 bpp grayscale version; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh"> thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <param name="ppixr">ppixr 16 bpp array of inverted R background value</param>
        /// <param name="ppixg">ppixg 16 bpp array of inverted G background value</param>
        /// <param name="ppixb">ppixb 16 bpp array of inverted B background value</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixBackgroundNormRGBArrays(Pix source, Pix mask, Pix grayscale, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, out Pix ppixr, out Pix ppixg, out Pix ppixb)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixr = null;
                ppixg = null;
                ppixb = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }
            if (grayscale == null)
            {
                grayscale = new Pix(IntPtr.Zero);
            }

            IntPtr ppixrPointer, ppixgPointer, ppixbPointer;
            var result = Native.DllImports.pixBackgroundNormRGBArrays(source.handleRef, mask.handleRef,
                grayscale.handleRef, sx, sy, thresh, mincount, bgval, smoothx, smoothy,
                out ppixrPointer, out ppixgPointer, out ppixbPointer);

            if (result != 1)
            {
                ppixr = new Pix(ppixrPointer);
                ppixg = new Pix(ppixgPointer);
                ppixb = new Pix(ppixbPointer);
                return true;
            }
            else
            {
                ppixr = null;
                ppixg = null;
                ppixb = null;
                return false;
            }
        }

        /// <summary>
        ///  Notes:
        ///     (1) See notes in pixBackgroundNormMorph().
        ///     (2) This returns a 16 bpp pix that can be used by
        ///  pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///  of the input pixs.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <param name="destination">ppixd 16 bpp array of inverted background value</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixBackgroundNormGrayArrayMorph(Pix source, Pix mask, int reduction, int size, int bgval, out Pix destination)
        {
            //ensure pix is not null;
            if (source == null)
            {
                destination = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr pixPointer;
            var result = Native.DllImports.pixBackgroundNormGrayArrayMorph(source.handleRef, mask.handleRef,
                reduction, size, bgval, out pixPointer);

            if (result != 1)
            {
                destination = new Pix(pixPointer);
                return true;
            }
            else
            {
                destination = null;
                return false;
            }
        }

        /// <summary>
        ///  Notes:
        ///     (1) See notes in pixBackgroundNormMorph().
        ///     (2) This returns a 16 bpp pix that can be used by
        ///  pixApplyInvBackgroundGrayMap() to generate a normalized version
        /// of the input pixs.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <param name="ppixr">ppixd 16 bpp array of inverted background value</param>
        /// <param name="ppixg">ppixd 16 bpp array of inverted background value</param>
        /// <param name="ppixb">ppixd 16 bpp array of inverted background value</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixBackgroundNormRGBArraysMorph(Pix source, Pix mask, int reduction, int size, int bgval, out Pix ppixr, out Pix ppixg, out Pix ppixb)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixr = null;
                ppixg = null;
                ppixb = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr ppixrPointer, ppixgPointer, ppixbPointer;
            var result = Native.DllImports.pixBackgroundNormRGBArraysMorph(source.handleRef, mask.handleRef,
                reduction, size, bgval,
                out ppixrPointer, out ppixgPointer, out ppixbPointer);

            if (result != 1)
            {
                ppixr = new Pix(ppixrPointer);
                ppixg = new Pix(ppixgPointer);
                ppixb = new Pix(ppixbPointer);
                return true;
            }
            else
            {
                ppixr = null;
                ppixg = null;
                ppixb = null;
                return false;
            }
        }


        //Measurement of local background
        /// <summary>
        /// Notes:
        ///      (1) The background is measured in regions that don't have
        ///          images.It is then propagated into the image regions,
        ///          and finally smoothed in each image region.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; not cmapped</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh">thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param>
        /// <param name="destination">ppixd 8 bpp grayscale map</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixGetBackgroundGrayMap(Pix source, Pix mask, int sx, int sy, int thresh, int mincount, out Pix destination)
        {
            //ensure pix is not null;
            if (source == null)
            {
                destination = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr pixPointer;
            var result = Native.DllImports.pixGetBackgroundGrayMap(source.handleRef, mask.handleRef, sx, sy, thresh, mincount, out pixPointer);

            if (result != 1)
            {
                destination = new Pix(pixPointer);
                return true;
            }
            else
            {
                destination = null;
                return false;
            }
        }

        /// <summary>
        /// Notes:
        ///      (1) If pixg, which is a grayscale version of pixs, is provided,
        ///          use this internally to generate the foreground mask.
        ///          Otherwise, a grayscale version of pixs will be generated
        ///          from the green component only, used, and destroyed.
        /// </summary>
        /// <param name="source">pixs 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="grayscale">pixg [optional] 8 bpp grayscale version; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh">thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param>
        /// <param name="ppixmr">ppixmr, ppixmg, ppixmb rgb maps</param>
        /// <param name="ppixmg">ppixmr, ppixmg, ppixmb rgb maps</param>
        /// <param name="ppixmb">ppixmr, ppixmg, ppixmb rgb maps</param>
        /// <returns>0 if OK, 1 on error</returns>
        public static bool pixGetBackgroundRGBMap(Pix source, Pix mask, Pix grayscale, int sx, int sy, int thresh, int mincount, out Pix ppixmr, out Pix ppixmg, out Pix ppixmb)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixmr = null;
                ppixmg = null;
                ppixmb = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }
            if (grayscale == null)
            {
                grayscale = new Pix(IntPtr.Zero);
            }

            IntPtr ppixrPointer, ppixgPointer, ppixbPointer;
            var result = Native.DllImports.pixGetBackgroundRGBMap(source.handleRef, mask.handleRef,
                grayscale.handleRef, sx, sy, thresh, mincount,
                out ppixrPointer, out ppixgPointer, out ppixbPointer);

            if (result != 1)
            {
                ppixmr = new Pix(ppixrPointer);
                ppixmg = new Pix(ppixgPointer);
                ppixmb = new Pix(ppixbPointer);
                return true;
            }
            else
            {
                ppixmr = null;
                ppixmg = null;
                ppixmb = null;
                return false;
            }
        }

        /// <summary>
        /// pixGetBackgroundGrayMapMorph()
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; not cmapped</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="reduction">reduction factor at which closing is performed</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="ppixm">ppixm grayscale map</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixGetBackgroundGrayMapMorph(Pix source, Pix mask, int reduction, int size, out Pix ppixm)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixm = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr pixPointer;
            var result = Native.DllImports.pixGetBackgroundGrayMapMorph(source.handleRef, mask.handleRef, reduction, size, out pixPointer);

            if (result != 1)
            {
                ppixm = new Pix(pixPointer);
                return true;
            }
            else
            {
                ppixm = null;
                return false;
            }
        }

        /// <summary>
        /// pixGetBackgroundRGBMapMorph()
        /// </summary>
        /// <param name="source">pixs 32 bpp rgb</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="reduction">reduction factor at which closing is performed</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="ppixmr">ppixmr red component map</param>
        /// <param name="ppixmg">ppixmg green component map</param>
        /// <param name="ppixmb">ppixmb blue component map</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixGetBackgroundRGBMapMorph(Pix source, Pix mask, int reduction, int size, out Pix ppixmr, out Pix ppixmg, out Pix ppixmb)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixmr = null;
                ppixmg = null;
                ppixmb = null;
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            IntPtr ppixrPointer, ppixgPointer, ppixbPointer;
            var result = Native.DllImports.pixGetBackgroundRGBMapMorph(source.handleRef, mask.handleRef,
                reduction, size,
                out ppixrPointer, out ppixgPointer, out ppixbPointer);

            if (result != 1)
            {
                ppixmr = new Pix(ppixrPointer);
                ppixmg = new Pix(ppixgPointer);
                ppixmb = new Pix(ppixbPointer);
                return true;
            }
            else
            {
                ppixmr = null;
                ppixmg = null;
                ppixmb = null;
                return false;
            }
        }

        /// <summary>
        /// Notes:
        ///      (1) This is an in-place operation on pix(the map).  pix is
        ///          typically a low-resolution version of some other image
        ///          from which it was derived, where each pixel in pix
        /// corresponds to a rectangular tile(say, m x n) of pixels
        ///          in the larger image.All we need to know about the larger
        ///          image is whether or not the rightmost column and bottommost
        ///          row of pixels in pix correspond to tiles that are
        ///          only partially covered by pixels in the larger image.
        ///      (2) Typically, some number of pixels in the input map are
        ///          not known, and their values must be determined by near
        /// pixels that are known.These unknown pixels are the 'holes'.
        ///          They can take on only two values, 0 and 255, and the
        ///          instruction about which to fill is given by the filltype flag.
        ///      (3) The "holes" can come from two sources.The first is when there
        ///          are not enough foreground or background pixels in a tile;
        ///          the second is when a tile is at least partially covered
        ///          by an image mask.If we're filling holes in a fg mask,
        ///          the holes are initialized to black (0) and use L_FILL_BLACK.
        /// For filling holes in a bg mask, initialize the holes to
        ///          white(255) and use L_FILL_WHITE.
        ///
        ///      (4) If w is the map width, nx = w or nx = w - 1; ditto for h and ny.
        /// </summary>
        /// <param name="pix">pix 8 bpp; a map, with one pixel for each tile in a larger image</param>
        /// <param name="nx">nx number of horizontal pixel tiles that are entirely covered with pixels in the original source image</param>
        /// <param name="ny">ny ditto for the number of vertical pixel tiles</param>
        /// <param name="filltype">filltype L_FILL_WHITE or L_FILL_BLACK</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixFillMapHoles(Pix pix, int nx, int ny, GrayscaleFillingFlags filltype)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                return false;
            }

            var success = Native.DllImports.pixFillMapHoles(pix.handleRef, nx, ny, filltype);

            if (success == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// (1) The pixel values are extended to the left and down, as required.
        /// </summary>
        /// <param name="source">pixs 8 bpp</param>
        /// <param name="addw">addw number of extra pixels horizontally to add</param>
        /// <param name="addh">addh number of extra pixels vertically to add</param>
        /// <returns>pixd extended with replicated pixel values, or NULL on error</returns>
        public static Pix pixExtendByReplication(Pix source, int addw, int addh)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            var result = Native.DllImports.pixExtendByReplication(source.handleRef, addw, addh);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Notes:
        ///      (1) The pixels in pixs corresponding to those in each
        ///          8-connected region in the mask are set to the average value.
        ///      (2) This is required for adaptive mapping to avoid the
        /// generation of stripes in the background map, due to
        ///          variations in the pixel values near the edges of mask regions.
        ///      (3) This function is optimized for background smoothing, where
        ///          there are a relatively small number of components.It will
        /// be inefficient if used where there are many small components.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; no colormap</param>
        /// <param name="mask">pixm [optional] 1 bpp; if null, this is a no-op</param>
        /// <param name="factor">factor subsampling factor for getting average; >= 1</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixSmoothConnectedRegions(Pix source, Pix mask, int factor)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return false;
            }
            if (mask == null)
            {
                mask = new Pix(IntPtr.Zero);
            }

            var result = Native.DllImports.pixSmoothConnectedRegions(source.handleRef, mask.handleRef, factor);

            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Measurement of local foreground
        /// <summary>
        /// Notes:
        ///      (1) Each(sx, sy) tile of pixs gets mapped to one pixel in pixd.
        ///
        ///     (2) pixd is the estimate of the fg(darkest) value within each tile.
        ///      (3) All pixels in pixd that are in 'image' regions, as specified
        /// by pixim, are given the background value 0.
        ///      (4) For pixels in pixd that can't directly be given a fg value,
        ///          the value is inferred by propagating from neighboring pixels.
        ///      (5) In practice, pixd can be used to normalize the fg, and
        /// it can be done after background normalization.
        ///      (6) The overall procedure is:
        ///            ~reduce 2x by sampling
        /// ~paint all 'image' pixels white, so that they don't
        ///            ~participate in the Min reduction
        /// ~ do a further(sx, sy) Min reduction -- think of
        ///              it as a large opening followed by subsampling by the
        ///              reduction factors
        ///            ~threshold the result to identify fg, and set the
        /// bg pixels to 255 (these are 'holes')
        ///            ~fill holes by propagation from fg values
        ///            ~replicatively expand by 2x, arriving at the final
        ///              resolution of pixd
        /// ~smooth with a 17x17 kernel
        ///            ~paint the 'image' regions black
        /// </summary>
        /// <param name="source">pixs 8 bpp</param>
        /// <param name="mask">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="sx">sx, sy src tile size, in pixels</param>
        /// <param name="sy">thresh threshold for determining foreground</param>
        /// <param name="destination">ppixd 8 bpp grayscale map</param> 
        /// <returns>true if success, false on error</returns>
        public static bool pixGetForegroundGrayMap(Pix source, Pix mask, int sx, int sy, int thresh, out Pix destination)
        {
            throw new NotImplementedException();
        }


        //Generate inverted background map for each component
        /// <summary>
        /// Notes:
        ///     (1) bgval should typically be > 120 and< 240
        ///     (2) pixd is a normalization image; the original image is
        ///       multiplied by pixd and the result is divided by 256.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; no colormap</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <returns>pixd 16 bpp, or NULL on error</returns>
        public static Pix pixGetInvBackgroundMap(Pix source, int bgval, int smoothx, int smoothy)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            var result = Native.DllImports.pixGetInvBackgroundMap(source.handleRef, bgval, smoothx, smoothy);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }


        //Apply inverse background map to image
        /// <summary>
        /// pixApplyInvBackgroundGrayMap()
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; no colormap</param>
        /// <param name="mask">pixm 16 bpp, inverse background map</param>
        /// <param name="sx">sx tile width in pixels</param>
        /// <param name="sy">sy tile height in pixels</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixApplyInvBackgroundGrayMap(Pix source, Pix mask, int sx, int sy)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }
            if (mask == null)
            {
                return null;
            }

            var result = Native.DllImports.pixApplyInvBackgroundGrayMap(source.handleRef,
                mask.handleRef, sx, sy);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// pixApplyInvBackgroundRGBMap()
        /// </summary>
        /// <param name="source">pixs 32 bpp rbg</param>
        /// <param name="pixmr">pixmr 16 bpp, red inverse background map</param>
        /// <param name="pixmg">pixmg 16 bpp, green inverse background map</param>
        /// <param name="pixmb">pixmb 16 bpp, blue inverse background map</param>
        /// <param name="sx">sx tile width in pixels</param>
        /// <param name="sy">sy tile height in pixels</param>
        /// <returns>pixd 32 bpp rbg, or NULL on error</returns>
        public static Pix pixApplyInvBackgroundRGBMap(Pix source, Pix pixmr, Pix pixmg, Pix pixmb, int sx, int sy)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }
            if (pixmr == null)
            {
                return null;
            }
            if (pixmg == null)
            {
                return null;
            }
            if (pixmb == null)
            {
                return null;
            }

            var result = Native.DllImports.pixApplyInvBackgroundRGBMap(source.handleRef,
                pixmr.handleRef, pixmg.handleRef, pixmb.handleRef, sx, sy);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }


        //Apply variable map
        /// <summary>
        /// Notes:
        ///       (1) Suppose you have an image that you want to transform based
        ///  on some photometric measurement at each point, such as the
        /// threshold value for binarization.Representing the photometric
        /// measurement as an image pixg, you can threshold in input image
        ///           using pixVarThresholdToBinary().  Alternatively, you can map
        ///  the input image pointwise so that the threshold over the
        /// entire image becomes a constant, such as 128.  For example,
        ///           if a pixel in pixg is 150 and the target is 128, the
        ///  corresponding pixel in pixs is mapped linearly to a value
        ///          (128/150) of the input value.If the resulting mapped image
        ///           pixd were then thresholded at 128, you would obtain the
        ///           same result as a direct binarization using pixg with
        ///  pixVarThresholdToBinary().
        ///       (2) The sizes of pixs and pixg must be equal.
        /// </summary>
        /// <param name="source">pixs 8 bpp</param>
        /// <param name="pixg">pixg 8 bpp, variable map</param>
        /// <param name="target">target typ. 128 for threshold</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixApplyVariableGrayMap(Pix source, Pix pixg, int target)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }
            if (pixg == null)
            {
                return null;
            }

            var result = Native.DllImports.pixApplyVariableGrayMap(source.handleRef,
                pixg.handleRef, target);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }


        //Non-adaptive (global) mapping 
        /// <summary>
        ///    (1) The value of pixd determines if the results are written to a
        ///        new pix(use NULL), in-place to pixs(use pixs), or to some
        ///other existing pix.
        ///    (2) This does a global normalization of an image where the
        ///        r,g,b color components are not balanced.Thus, white in pixs is
        ///        represented by a set of r, g, b values that are not all 255.
        ///    (3) The input values(rval, gval, bval) should be chosen to
        ///        represent the gray color(mapval, mapval, mapval) in src.
        ///
        ///Thus, this function will map(rval, gval, bval) to that gray color.
        ///    (4) Typically, mapval = 255, so that(rval, gval, bval)
        ///        corresponds to the white point of src.In that case, these
        ///        parameters should be chosen so that few pixels have higher values.
        ///    (5) In all cases, we do a linear TRC separately on each of the
        ///        components, saturating at 255.
        ///    (6) If the input pix is 8 bpp without a colormap, you can get
        ///        this functionality with mapval = 255 by calling:
        ///            pixGammaTRC(pixd, pixs, 1.0, 0, bgval);
        ///        where bgval is the value you want to be mapped to 255.
        ///        Or more generally, if you want bgval to be mapped to mapval:
        ///            pixGammaTRC(pixd, pixs, 1.0, 0, 255 * bgval / mapval);
        /// </summary>
        /// <param name="destination">pixd [optional] null, existing or equal to pixs</param>
        /// <param name="source">pixs 32 bpp rgb, or colormapped</param>
        /// <param name="rval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="gval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="bval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="mapval">mapval use 255 for mapping to white</param>
        /// <returns>pixd 32 bpp rgb or colormapped, or NULL on error</returns>
        public static Pix pixGlobalNormRGB(Pix destination, Pix source, int rval, int gval, int bval, int mapval)
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

            var result = Native.DllImports.pixGlobalNormRGB(destination.handleRef, source.handleRef,
                rval, gval, bval, mapval);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  Notes:
        ///     (1) This is a version of pixGlobalNormRGB(), where the output
        ///  intensity is scaled back so that a controlled fraction of
        ///         pixel components is allowed to saturate.See comments in
        ///         pixGlobalNormRGB().
        ///     (2) The value of pixd determines if the results are written to a
        ///         new pix(use NULL), in-place to pixs(use pixs), or to some
        /// other existing pix.
        ///     (3) This does a global normalization of an image where the
        ///         r,g,b color components are not balanced.Thus, white in pixs is
        ///         represented by a set of r, g, b values that are not all 255.
        ///     (4) The input values(rval, gval, bval) can be chosen to be the
        ///         color that, after normalization, becomes white background.
        ///  For images that are mostly background, the closer these values
        ///         are to the median component values, the closer the resulting
        ///  background will be to gray, becoming white at the brightest places.
        /// 
        ///    (5) The mapval used in pixGlobalNormRGB() is computed here to
        /// avoid saturation of any component in the image(save for a
        /// fraction of the pixels given by the input rank value).
        /// </summary>
        /// <param name="destination">pixd [optional] null, existing or equal to pixs</param>
        /// <param name="source"> pixs 32 bpp rgb</param>
        /// <param name="rval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="gval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="bval">rval, gval, bval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="factor">factor subsampling factor; integer >= 1</param>
        /// <param name="rank">rank between 0.0 and 1.0; typ. use a value near 1.0</param>
        /// <returns>pixd 32 bpp rgb, or NULL on error</returns>
        public static Pix pixGlobalNormNoSatRGB(Pix destination, Pix source, int rval, int gval, int bval, int factor, float rank)
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

            var result = Native.DllImports.pixGlobalNormNoSatRGB(destination.handleRef, source.handleRef,
                rval, gval, bval, factor, rank);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }


        // Adaptive threshold spread normalization
        /// <summary>
        /// Notes:
        ///      (1) The basis of this approach is the use of seed spreading
        /// on a (possibly) sparse set of estimates for the local threshold.
        ///          The resulting dense estimates are smoothed by convolution
        ///          and used to either threshold the input image or normalize it
        ///          with a local transformation that linearly maps the pixels so
        ///          that the local threshold estimate becomes constant over the
        ///          resulting image.  This approach is one of several that
        ///          have been suggested (and implemented) by Ray Smith.
        ///      (2) You can use either the Sobel or TwoSided edge filters.
        ///          The results appear to be similar, using typical values
        /// of edgethresh in the rang 10-20.
        ///      (3) To skip the trc enhancement, use gamma = 1.0, minval = 0
        /// and maxval = 255.
        ///      (4) For the normalized image pixd, each pixel is linearly mapped
        ///          in such a way that the local threshold is equal to targetthresh.
        ///      (5) The full width and height of the convolution kernel
        /// are(2 * smoothx + 1) and(2 * smoothy + 1).
        ///      (6) This function can be used with the pixtiling utility if the
        /// images are too large.See pixOtsuAdaptiveThreshold() for
        /// an example of this.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="filtertype">filtertype L_SOBEL_EDGE or L_TWO_SIDED_EDGE;</param>
        /// <param name="edgethresh">edgethresh threshold on magnitude of edge filter; typ 10-20</param>
        /// <param name="smoothx">smoothx, smoothy half-width of convolution kernel applied to spread threshold: use 0 for no smoothing</param>
        /// <param name="smoothy">smoothx, smoothy half-width of convolution kernel applied to spread threshold: use 0 for no smoothing</param>
        /// <param name="gamma">gamma gamma correction; typ. about 0.7</param>
        /// <param name="minval">minval  input value that gives 0 for output; typ. -25</param>
        /// <param name="maxval"> maxval  input value that gives 255 for output; typ. 255</param>
        /// <param name="targetthresh">targetthresh target threshold for normalization</param>
        /// <param name="ppixth">ppixth [optional] computed local threshold value</param>
        /// <param name="ppixb">ppixb [optional] thresholded normalized image</param>
        /// <param name="ppixd">ppixd [optional] normalized image</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixThresholdSpreadNorm(Pix source, EdgeFilterFlags filtertype, int edgethresh, int smoothx, int smoothy, float gamma, int minval, int maxval, int targetthresh, out Pix ppixth, out Pix ppixb, out Pix ppixd)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixth = null;
                ppixb = null;
                ppixd = null;
                return false;
            }

            IntPtr ppixthPointer, ppixbPointer, ppixdPointer;
            var result = Native.DllImports.pixThresholdSpreadNorm(source.handleRef, filtertype,
                edgethresh, smoothx, smoothy, gamma, minval, maxval, targetthresh,
                out ppixthPointer, out ppixbPointer, out ppixdPointer);

            if (result == 0)
            {
                ppixth = new Pix(ppixthPointer);
                ppixb = new Pix(ppixbPointer);
                ppixd = new Pix(ppixdPointer);
                return true;
            }
            else
            {
                ppixth = null;
                ppixb = null;
                ppixd = null;
                return false;
            }
        }


        // Adaptive background normalization(flexible adaptaption)
        /// <summary>
        ///  Notes:
        ///       (1) This does adaptation flexibly to a quickly varying background.
        ///  For that reason, all input parameters should be small.
        /// 
        ///      (2) sx and sy give the tile size; they should be in [5 - 7].
        ///       (3) The full width and height of the convolution kernel
        ///  are(2 * smoothx + 1) and(2 * smoothy + 1).  They
        /// should be in [1 - 2].
        ///       (4) Basin filling is used to fill the large fg regions.The
        ///  parameter %delta measures the height that the black
        /// background is raised from the local minima.By raising
        ///           the background, it is possible to threshold the large
        ///  fg regions to foreground.If %delta is too large,
        ///           bg regions will be lifted, causing thickening of
        /// the fg regions.Use 0 to skip.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="sx">sx, sy desired tile dimensions; actual size may vary; use values between 3 and 10</param>
        /// <param name="sy">sx, sy desired tile dimensions; actual size may vary; use values between 3 and 10</param>
        /// <param name="smoothx">smoothx, smoothy half-width of convolution kernel applied to  threshold array: use values between 1 and 3</param>
        /// <param name="smoothy">smoothx, smoothy half-width of convolution kernel applied to  threshold array: use values between 1 and 3</param>
        /// <param name="delta">delta difference parameter in basin filling; use 0 to skip</param>
        /// <returns>pixd 8 bpp, background-normalized), or NULL on error</returns>
        public static Pix pixBackgroundNormFlex(Pix source, int sx, int sy, int smoothx, int smoothy, int delta)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            var result = Native.DllImports.pixBackgroundNormFlex(source.handleRef, sx, sy, smoothx, smoothy, delta);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }

        // Adaptive contrast normalization
        /// <summary>
        ///  Notes:
        ///       (1) This function adaptively attempts to expand the contrast
        ///           to the full dynamic range in each tile.If the contrast in
        ///           a tile is smaller than %mindiff, it uses the min and max
        ///           pixel values from neighboring tiles.It also can use
        ///           convolution to smooth the min and max values from
        ///  neighboring tiles.After all that processing, it is
        ///           possible that the actual pixel values in the tile are outside
        ///           the computed [min...max] range for local contrast
        ///           normalization.Such pixels are taken to be at either 0
        ///           (if below the min) or 255 (if above the max).
        ///       (2) pixd can be equal to pixs(in-place operation) or
        ///          null (makes a new pixd).
        ///       (3) sx and sy give the tile size; they are typically at least 20.
        ///       (4) mindiff is used to eliminate results for tiles where it is
        ///           likely that either fg or bg is missing.A value around 50
        ///           or more is reasonable.
        ///       (5) The full width and height of the convolution kernel
        ///  are(2 * smoothx + 1) and(2 * smoothy + 1).  Some smoothing
        ///           is typically useful, and we limit the smoothing half-widths
        ///  to the range from 0 to 8.
        ///       (6) A linear TRC(gamma = 1.0) is applied to increase the contrast
        ///          in each tile.The result can subsequently be globally corrected,
        /// 
        /// by applying pixGammaTRC() with arbitrary values of gamma
        /// and the 0 and 255 points of the mapping.
        /// </summary>
        /// <param name="pixd">pixd [optional] 8 bpp; null or equal to pixs</param>
        /// <param name="pix">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="sx">sx, sy tile dimensions</param>
        /// <param name="sy">sx, sy tile dimensions</param>
        /// <param name="mindiff">mindiff minimum difference to accept as valid</param>
        /// <param name="smoothx">smoothx, smoothy half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <param name="smoothy">smoothx, smoothy half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <returns>pixd always</returns>
        public static Pix pixContrastNorm(Pix destination, Pix source, int sx, int sy, int mindiff, int smoothx, int smoothy)
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

            var result = Native.DllImports.pixContrastNorm(destination.handleRef, source.handleRef, sx, sy, mindiff, smoothx, smoothy);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  (1) This computes filtered and smoothed values for the min and
        ///          max pixel values in each tile of the image.
        ///      (2) See pixContrastNorm() for usage.
        /// </summary>
        /// <param name="source">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="sx"> sx, sy tile dimensions</param>
        /// <param name="sy"> sx, sy tile dimensions</param>
        /// <param name="mindiff">mindiff minimum difference to accept as valid</param>
        /// <param name="smoothx">smoothx, smoothy half-width of convolution kernel applied to  min and max arrays: use 0 for no smoothing</param>
        /// <param name="smoothy">smoothx, smoothy half-width of convolution kernel applied to  min and max arrays: use 0 for no smoothing</param>
        /// <param name="ppixmin">ppixmin tiled minima</param>
        /// <param name="ppixmax">ppixmax tiled maxima</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixMinMaxTiles(Pix source, int sx, int sy, int mindiff, int smoothx, int smoothy, out Pix ppixmin, out Pix ppixmax)
        {
            //ensure pix is not null;
            if (source == null)
            {
                ppixmin = null;
                ppixmax = null;
                return false;
            }

            IntPtr ppixminPointer, ppixmaxPointer;
            var result = Native.DllImports.pixMinMaxTiles(source.handleRef, sx, sy, mindiff, smoothx, smoothy,
                out ppixminPointer, out ppixmaxPointer);

            if (result == 0)
            {
                ppixmin = new Pix(ppixminPointer);
                ppixmax = new Pix(ppixmaxPointer);
                return true;
            }
            else
            {
                ppixmin = null;
                ppixmax = null;
                return false;
            }
        }

        /// <summary>
        /// Notes:
        ///       (1) This compares corresponding pixels in pixs1 and pixs2.
        ///  When they differ by less than %mindiff, set the pixel
        /// values to 0 in each.Each pixel typically represents a tile
        ///           in a larger image, and a very small difference between
        ///           the min and max in the tile indicates that the min and max
        ///           values are not to be trusted.
        ///       (2) If contrast(pixel difference) detection is expected to fail,
        ///           caller should check return value.
        /// </summary>
        /// <param name="pixs1">pixs1 8 bpp</param>
        /// <param name="pixs2">pixs2 8 bpp</param>
        /// <param name="mindiff">mindiff minimum difference to accept as valid</param>
        /// <returns>true if OK; false if no pixel diffs are large enough, or on error</returns>
        public static bool pixSetLowContrast(Pix pixs1, Pix pixs2, int mindiff)
        {
            //ensure pix is not null;
            if (pixs1 == null)
            {
                return false;
            }
            if (pixs2 == null)
            {
                return false;
            }

            var result = Native.DllImports.pixSetLowContrast(pixs1.handleRef, pixs2.handleRef, mindiff);

            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Notes:
        ///      (1) pixd can be equal to pixs(in-place operation) or
        ///         null (makes a new pixd).
        ///      (2) sx and sy give the tile size; they are typically at least 20.
        ///      (3) pixmin and pixmax are generated by pixMinMaxTiles()
        ///      (4) For each tile, this does a linear expansion of the dynamic
        /// range so that the min value in the tile becomes 0 and the
        ///          max value in the tile becomes 255.
        ///      (5) The LUTs that do the mapping are generated as needed
        /// and stored for reuse in an integer array within the ptr array iaa[].
        /// </summary>
        /// <param name="pixd">pixd [optional] 8 bpp</param>
        /// <param name="pixs"> pixs 8 bpp, not colormapped</param>
        /// <param name="sx"> sx, sy tile dimensions</param>
        /// <param name="sy"> sx, sy tile dimensions</param>
        /// <param name="pixmin">pixmin pix of min values in tiles</param>
        /// <param name="pixmax">pixmax pix of max values in tiles</param>
        /// <returns>pixd always</returns>
        public static Pix pixLinearTRCTiled(Pix destination, Pix source, int sx, int sy, Pix pixmin, Pix pixmax)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }
            if (pixmin == null)
            {
                return null;
            }
            if (pixmax == null)
            {
                return null;
            }
            if (destination == null)
            {
                destination = new Pix(IntPtr.Zero);
            }

            var result = Native.DllImports.pixLinearTRCTiled(destination.handleRef, source.handleRef, sx, sy, pixmin.handleRef, pixmax.handleRef);

            if (result != IntPtr.Zero)
            {
                return new Pix(result);
            }
            else
            {
                return null;
            }
        }
         
    }
}
