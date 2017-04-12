using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leptonica
{
    /// <summary>
    /// binarize.c
    /// </summary>
    public static class Binarize
    {
        // Adaptive Otsu-based thresholding
        /// <summary>
        ///       (1) The Otsu method finds a single global threshold for an image.
        ///           This function allows a locally adapted threshold to be
        ///  found for each tile into which the image is broken up.
        ///       (2) The array of threshold values, one for each tile, constitutes
        ///           a highly downscaled image.This array is optionally
        ///  smoothed using a convolution.The full width and height of the
        /// convolution kernel are(2 * %smoothx + 1) and(2 * %smoothy + 1).
        ///       (3) The minimum tile dimension allowed is 16.  If such small
        ///  tiles are used, it is recommended to use smoothing, because
        ///  without smoothing, each small tile determines the splitting
        ///  threshold independently.A tile that is entirely in the
        /// image bg will then hallucinate fg, resulting in a very noisy
        /// binarization.The smoothing should be large enough that no
        /// tile is only influenced by one type (fg or bg) of pixels,
        ///  because it will force a split of its pixels.
        ///       (4) To get a single global threshold for the entire image, use
        /// input values of %sx and %sy that are larger than the image.
        /// 
        /// For this situation, the smoothing parameters are ignored.
        /// 
        ///      (5) The threshold values partition the image pixels into two classes:
        ///           one whose values are less than the threshold and another
        ///           whose values are greater than or equal to the threshold.
        ///           This is the same use of 'threshold' as in pixThresholdToBinary().
        ///       (6) The scorefract is the fraction of the maximum Otsu score, which
        ///           is used to determine the range over which the histogram minimum
        ///           is searched.  See numaSplitDistribution() for details on the
        ///           underlying method of choosing a threshold.
        ///       (7) This uses enables a modified version of the Otsu criterion for
        ///           splitting the distribution of pixels in each tile into a
        ///           fg and bg part.  The modification consists of searching for
        ///           a minimum in the histogram over a range of pixel values where
        ///           the Otsu score is within a defined fraction, %scorefract,
        ///           of the max score.  To get the original Otsu algorithm, set
        ///           % scorefract == 0.
        ///  (8) N.B.This method is NOT recommended for images with weak text
        /// and significant background noise, such as bleedthrough, because
        /// of the problem noted in (3) above for tiling.Use Sauvola.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp</param>
        /// <param name="sx">sx, sy desired tile dimensions; actual size may vary</param>
        /// <param name="sy">sx, sy desired tile dimensions; actual size may vary</param>
        /// <param name="smoothx">smoothx, smoothy half-width of convolution kernel applied to threshold array: use 0 for no smoothing</param>
        /// <param name="smoothy">smoothx, smoothy half-width of convolution kernel applied to threshold array: use 0 for no smoothing</param>
        /// <param name="scorefract"> scorefract fraction of the max Otsu score; typ. 0.1; use 0.0 for standard Otsu</param>
        /// <param name="ppixth">ppixth [optional] array of threshold values found for each tile</param>
        /// <param name="ppixd">ppixd [optional] thresholded input pixs, based on the threshold array</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixOtsuAdaptiveThreshold(Pix pixs, int sx, int sy, int smoothx, int smoothy, float scorefract, out Pix ppixth, out Pix ppixd)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                ppixth = null;
                ppixd = null;
                return false;
            }

            IntPtr ppixthPtr, ppixdPtr;
            var answer = Native.DllImports.pixOtsuAdaptiveThreshold(pixs.handleRef, sx, sy, smoothx, smoothy, scorefract, out ppixthPtr, out ppixdPtr);

            if (answer != 0)
            {
                ppixth = null;
                ppixd = null;
                return false;
            }
            else
            {
                ppixth = new Pix(ppixthPtr);
                ppixd = new Pix(ppixdPtr);
                return true;
            }
        }




        // Otsu thresholding on adaptive background normalization
        /// <summary>
        ///      (1) This does background normalization followed by Otsu
        /// thresholding.Otsu binarization attempts to split the
        /// image into two roughly equal sets of pixels, and it does
        /// a very poor job when there are large amounts of dark
        ///          background.By doing a background normalization first,
        /// to get the background near 255, we remove this problem.
        /// Then we use a modified Otsu to estimate the best global
        ///          threshold on the normalized image.
        ///      (2) See pixBackgroundNorm() for meaning and typical values
        ///          of input parameters.For a start, you can try:
        ///            sx, sy = 10, 15
        ///            thresh = 100
        ///            mincount = 50
        ///            bgval = 255
        ///            smoothx, smoothy = 2
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="pixim">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh">thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <param name="scorefract"> scorefract fraction of the max Otsu score; typ. 0.1</param>
        /// <param name="pthresh">pthresh [optional] threshold value that was used on the normalized image</param>
        /// <returns>pixd 1 bpp thresholded image, or NULL on error</returns>
        public static Pix pixOtsuThreshOnBackgroundNorm(Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, float scorefract, out int pthresh)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                pthresh = 0;
                return null;
            }
            if (pixim == null)
            {
                pixim = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixOtsuThreshOnBackgroundNorm(pixs.handleRef, pixim.handleRef, sx, sy, thresh, mincount, bgval, smoothx, smoothy, scorefract, out pthresh);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }




        //      Masking and Otsu estimate on adaptive background normalization
        /// <summary>
        ///      (1) This begins with a standard background normalization.
        /// Additionally, there is a flexible background norm, that
        ///          will adapt to a rapidly varying background, and this
        ///          puts white pixels in the background near regions with
        /// significant foreground.The white pixels are turned into
        ///          a 1 bpp selection mask by binarization followed by dilation.
        ///          Otsu thresholding is performed on the input image to get an
        ///          estimate of the threshold in the non-mask regions.
        ///          The background normalized image is thresholded with two
        /// different values, and the result is combined using
        /// the selection mask.
        ///      (2) Note that the numbers 255 (for bgval target) and 190 (for
        /// thresholding on pixn) are tied together, and explicitly
        /// defined in this function.
        ///
        ///     (3) See pixBackgroundNorm() for meaning and typical values
        ///          of input parameters.  For a start, you can try:
        ///            sx, sy = 10, 15
        ///            thresh = 100
        ///            mincount = 50
        ///            smoothx, smoothy = 2
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="pixim">pixim [optional] 1 bpp 'image' mask; can be null</param>
        /// <param name="sx">sx, sy tile size in pixels</param>
        /// <param name="sy">sx, sy tile size in pixels</param>
        /// <param name="thresh">thresh threshold for determining foreground</param>
        /// <param name="mincount">mincount min threshold on counts in a tile</param> 
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <param name="scorefract">scorefract fraction of the max Otsu score; typ. ~ 0.1</param>
        /// <param name="pthresh">pthresh [optional] threshold value that was used on the normalized image</param>
        /// <returns>pixd 1 bpp thresholded image, or NULL on error</returns>
        public static Pix pixMaskedThreshOnBackgroundNorm(Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, int smoothx, int smoothy, float scorefract, out int pthresh)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                pthresh = 0;
                return null;
            }
            if (pixim == null)
            {
                pixim = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixMaskedThreshOnBackgroundNorm(pixs.handleRef, pixim.handleRef, sx, sy, thresh, mincount, smoothx, smoothy, scorefract, out pthresh);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }




        // Sauvola local thresholding
        /// <summary>
        ///       (1) The window width and height are 2 * %whsize + 1.  The minimum
        ///           value for %whsize is 2; typically it is >= 7..
        ///       (2) For nx == ny == 1, this defaults to pixSauvolaBinarize().
        ///       (3) Why a tiled version?
        ///           (a) Because the mean value accumulator is a uint32, overflow
        ///               can occur for an image with more than 16M pixels.
        ///           (b) The mean value accumulator array for 16M pixels is 64 MB.
        ///  The mean square accumulator array for 16M pixels is 128 MB.
        /// 
        /// Using tiles reduces the size of these arrays.
        /// 
        ///          (c) Each tile can be processed independently, in parallel,
        ///               on a multicore processor.
        ///       (4) The Sauvola threshold is determined from the formula:
        ///               t = m* (1 - k* (1 - s / 128))
        ///           See pixSauvolaBinarize() for details.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale, not colormapped</param>
        /// <param name="whsize">whsize window half-width for measuring local statistics</param>
        /// <param name="factor">factor factor for reducing threshold due to variance; >= 0</param>
        /// <param name="nx">nx, ny subdivision into tiles; >= 1</param>
        /// <param name="ny">nx, ny subdivision into tiles; >= 1</param>
        /// <param name="ppixth">ppixth [optional] Sauvola threshold values</param>
        /// <param name="ppixd"> ppixd [optional] thresholded image</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixSauvolaBinarizeTiled(Pix pixs, int whsize, float factor, int nx, int ny, out Pix ppixth, out Pix ppixd)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                ppixth = null;
                ppixd = null;
                return false;
            }

            IntPtr ppixthPtr, ppixdPtr;
            var answer = Native.DllImports.pixSauvolaBinarizeTiled(pixs.handleRef, whsize, factor, nx, ny, out ppixthPtr, out ppixdPtr);

            if (answer != 0)
            {
                ppixth = null;
                ppixd = null;
                return false;
            }
            else
            {
                ppixth = new Pix(ppixthPtr);
                ppixd = new Pix(ppixdPtr);
                return true;
            }
        }

        /// <summary>
        ///       (1) The window width and height are 2 * %whsize + 1.  The minimum
        ///           value for %whsize is 2; typically it is >= 7..
        ///       (2) The local statistics, measured over the window, are the
        ///  average and standard deviation.
        /// 
        ///      (3) The measurements of the mean and standard deviation are
        /// performed inside a border of(%whsize + 1) pixels.If pixs does
        /// not have these added border pixels, use %addborder = 1 to add
        ///           it here; otherwise use %addborder = 0.
        ///       (4) The Sauvola threshold is determined from the formula:
        ///             t = m* (1 - k* (1 - s / 128))
        ///           where:
        ///             t = local threshold
        ///             m = local mean
        ///             k = %factor(>= 0)   [typ. 0.35 ]
        /// 
        /// s = local standard deviation, which is maximized at
        ///                 127.5 when half the samples are 0 and half are 255.
        ///       (5) The basic idea of Niblack and Sauvola binarization is that
        ///  the local threshold should be less than the median value,
        ///           and the larger the variance, the closer to the median
        ///  it should be chosen.Typical values for k are between
        ///          0.2 and 0.5.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="whsize">whsize window half-width for measuring local statistics</param>
        /// <param name="factor">factor factor for reducing threshold due to variance; >= 0</param>
        /// <param name="addborder">addborder 1 to add border of width (%whsize + 1) on all sides</param>
        /// <param name="ppixm">ppixm [optional] local mean values</param>
        /// <param name="ppixsd">ppixsd [optional] local standard deviation values</param>
        /// <param name="ppixth">ppixth [optional] threshold values</param>
        /// <param name="ppixd">ppixd [optional] thresholded image</param>
        /// <returns>true if OK, false on error</returns>
        public static bool pixSauvolaBinarize(Pix pixs, int whsize, float factor, int addborder, out Pix ppixm, out Pix ppixsd, out Pix ppixth, out Pix ppixd)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                ppixth = null;
                ppixd = null;
                ppixm = null;
                ppixsd = null;
                return false;
            }

            IntPtr ppixmPtr, ppixsdPtr, ppixthPtr, ppixdPtr;
            var answer = Native.DllImports.pixSauvolaBinarize(pixs.handleRef, whsize, factor, addborder, out ppixmPtr, out ppixsdPtr, out ppixthPtr, out ppixdPtr);

            if (answer != 0)
            {
                ppixth = null;
                ppixd = null;
                ppixm = null;
                ppixsd = null;
                return false;
            }
            else
            {
                ppixth = new Pix(ppixthPtr);
                ppixd = new Pix(ppixdPtr);
                ppixm = new Pix(ppixmPtr); ;
                ppixsd = new Pix(ppixsdPtr); ;
                return true;
            }
        }

        /// <summary>
        ///       (1) The Sauvola threshold is determined from the formula:
        ///             t = m* (1 - k* (1 - s / 128))
        ///           where:
        ///             t = local threshold
        ///             m = local mean
        ///             k = %factor(>= 0)   [typ. 0.35 ]
        /// 
        /// s = local standard deviation, which is maximized at
        ///                 127.5 when half the samples are 0 and half are 255.
        ///       (2) See pixSauvolaBinarize() for other details.
        ///       (3) Important definitions and relations for computing averages:
        ///             v == pixel value
        ///             E(p) == expected value of p == average of p over some pixel set
        ///  S(v) == square of v == v* v
        ///             mv == E(v) == expected pixel value == mean value
        ///             ms == E(S(v)) == expected square of pixel values
        ///                == mean square value
        ///  var == variance == expected square of deviation from mean
        ///                 == E(S(v - mv)) = E(S(v) - 2 * S(v* mv) + S(mv))
        ///                                 = E(S(v)) - S(mv)
        ///                                 = ms - mv* mv
        ///             s == standard deviation = sqrt(var)
        ///  So for evaluating the standard deviation in the Sauvola
        ///           threshold, we take
        ///             s = sqrt(ms - mv* mv)
        /// </summary>
        /// <param name="pixm">pixm 8 bpp grayscale; not colormapped</param>
        /// <param name="pixms">pixms 32 bpp</param>
        /// <param name="factor">factor factor for reducing threshold due to variance; >= 0</param>
        /// <param name="ppixsd">ppixsd [optional] local standard deviation</param>
        /// <returns>pixd 8 bpp, sauvola threshold values, or NULL on error</returns>
        public static Pix pixSauvolaGetThreshold(Pix pixm, Pix pixms, float factor, out Pix ppixsd)
        {
            //ensure pix is not null;
            if (pixm == null)
            {
                ppixsd = null;
                return null;
            }
            if (pixms == null)
            {
                ppixsd = null;
                return null;
            }

            IntPtr ppixsdPtr;
            var pointer = Native.DllImports.pixSauvolaGetThreshold(pixm.handleRef, pixms.handleRef, factor, out ppixsdPtr);

            if (pointer != IntPtr.Zero)
            {
                if (pointer == ppixsdPtr)
                {
                    ppixsd = new Pix(pointer);
                    return ppixsd;
                }
                else
                {
                    ppixsd = new Pix(ppixsdPtr);
                    return new Pix(pointer);
                }
            }
            else
            {
                ppixsd = null;
                return null;
            }
        }

        /// <summary>
        /// pixApplyLocalThreshold()
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; not colormapped</param>
        /// <param name="pixth">pixth 8 bpp array of local thresholds</param>
        /// <param name="redfactor">redfactor  ...</param>
        /// <returns>pixd 1 bpp, thresholded image, or NULL on error</returns>
        public static Pix pixApplyLocalThreshold(Pix pixs, Pix pixth, int redfactor)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                return null;
            }
            if (pixth == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixApplyLocalThreshold(pixs.handleRef, pixth.handleRef, redfactor);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }




        // Thresholding using connected components
        /// <summary>
        ///       (1) This finds a global threshold based on connected components.
        ///  Although slow, it is reasonable to use it in a situation where
        ///          (a) the background in the image is relatively uniform, and
        ///           (b) the result will be fed to an OCR program that accepts 1 bpp
        ///  images and works best with easily segmented characters.
        /// 
        /// The reason for (b) is that this selects a threshold with a
        /// minimum number of both broken characters and merged characters.
        ///       (2) If the pix has color, it is converted to gray using the
        ///  max component.
        /// 
        ///      (3) Input 0 to use default values for any of these inputs:
        ///           %start, %end, %incr, %thresh48, %threshdiff.
        ///       (4) This approach can be understood as follows.When the
        ///  binarization threshold is varied, the numbers of c.c.identify
        ///           four regimes:
        ///           (a) For low thresholds, text is broken into small pieces, and
        ///  the number of c.c. is large, with the 4 c.c.significantly
        /// exceeding the 8 c.c.
        /// 
        ///          (b) As the threshold rises toward the optimum value, the text
        /// characters coalesce and there is very little difference
        /// between the numbers of 4 and 8 c.c, which both go
        /// through a minimum.
        ///           (c) Above this, the image background gets noisy because some
        /// pixels are(thresholded to foreground, and the numbers
        /// of c.c.quickly increase, with the 4 c.c.significantly
        /// larger than the 8 c.c.
        /// 
        ///          (d) At even higher thresholds, the image background noise
        ///               coalesces as it becomes mostly foreground, and the
        ///               number of c.c. drops quickly.
        ///       (5) If there is no global threshold that distinguishes foreground
        ///           text from background (e.g., weak text over a background that
        ///           has significant variation and/or bleedthrough), this returns 1,
        ///           which the caller should check.
        /// </summary>
        /// <param name="pixs">pixs depth > 1, colormap OK</param>
        /// <param name="pixm">pixm [optional] 1 bpp mask giving region to ignore by setting </param>
        /// <param name="start">start, end, incr binarization threshold levels to test</param>
        /// <param name="end">start, end, incr binarization threshold levels to test</param>
        /// <param name="incr">start, end, incr binarization threshold levels to test</param>
        /// <param name="thresh48">thresh48 threshold on normalized difference between the numbers of 4 and 8 connected component</param>
        /// <param name="threshdiff">threshdiff threshold on normalized difference between the number of 4 cc at successive iterations</param>
        /// <param name="pglobthresh">pglobthresh [optional] best global threshold; 0 if no threshold is found</param>
        /// <param name="ppixd">ppixd [optional] image thresholded to binary, or null if no threshold is found</param>
        /// <param name="debugflag">debugflag 1 for plotted results</param>
        /// <returns>0 if OK, 1 on error or if no threshold is found</returns>
        public static bool pixThresholdByConnComp(Pix pixs, Pix pixm, int start, int end, int incr, float thresh48, float threshdiff, out int pglobthresh, out Pix ppixd, bool debugflag)
        {

            //ensure pix is not null;
            if (pixs == null)
            {
                pglobthresh = 0;
                ppixd = null;
                return false;
            }
            if (pixm == null)
            {
                pixm = new Pix(IntPtr.Zero);
            }

            IntPtr ppixdPtr;
            int idebugflag = debugflag ? 1 : 0;
            var answer = Native.DllImports.pixThresholdByConnComp(pixs.handleRef, pixm.handleRef, start, end, incr, thresh48, threshdiff, out pglobthresh, out ppixdPtr, idebugflag);

            if (answer != 0)
            {
                ppixd = new Pix(ppixdPtr);
                return true;
            }
            else
            {
                pglobthresh = 0;
                ppixd = null;
                return false;
            }
        }
    }
}
