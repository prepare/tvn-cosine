using System;

namespace Leptonica
{
    public static class Convolve
    { 
        // Top level grayscale or color block convolution 
        /// <summary>
        ///      (1) The full width and height of the convolution kernel
        /// are(2 * wc + 1) and(2 * hc + 1)
        ///      (2) Returns a copy if both wc and hc are 0
        ///      (3) Require that w >= 2 * wc + 1 and h >= 2 * hc + 1,
        ///          where(w, h) are the dimensions of pixs.
        /// </summary>
        /// <param name="source">pix 8 or 32 bpp; or 2, 4 or 8 bpp with colormap</param>
        /// <param name="wc">wc, hc   half width/height of convolution kernel</param>
        /// <param name="hc">wc, hc   half width/height of convolution kernel</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBlockconv(Pix source, int wc, int hc)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixBlockconv(source.handleRef, wc, hc);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }

        // Additive gaussian noise 
        //          l_float32     gaussDistribSampling() 
        /// <summary>
        ///      (1) This adds noise to each pixel, taken from a normal
        /// distribution with zero mean and specified standard deviation.
        /// </summary>
        /// <param name="source">pixs 8 bpp gray or 32 bpp rgb; no colormap</param>
        /// <param name="standardDeviation">stdev of noise</param>
        /// <returns>pixd 8 or 32 bpp, or NULL on error</returns>
        public static Pix AddGaussianNoise(Pix source, float standardDeviation)
        {
            //ensure pix is not null;
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixAddGaussianNoise(source.handleRef, standardDeviation);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }

         
        //      Grayscale block convolution
        //          PIX          *pixBlockconvGray()
        //          static void   blockconvLow()
        //
        //      Accumulator for 1, 8 and 32 bpp convolution
        //          PIX          *pixBlockconvAccum()
        //          static void   blockconvAccumLow()
        //
        //      Un-normalized grayscale block convolution
        //          PIX          *pixBlockconvGrayUnnormalized()
        //
        //      Tiled grayscale or color block convolution
        //          PIX          *pixBlockconvTiled()
        //          PIX          *pixBlockconvGrayTile()
        //
        //      Convolution for mean, mean square, variance and rms deviation
        //      in specified window
        //          l_int32       pixWindowedStats()
        //          PIX          *pixWindowedMean()
        //          PIX          *pixWindowedMeanSquare()
        //          l_int32       pixWindowedVariance()
        //          DPIX         *pixMeanSquareAccum()
        //
        //      Binary block sum and rank filter
        //          PIX          *pixBlockrank()
        //          PIX          *pixBlocksum()
        //          static void   blocksumLow()
        //
        //      Census transform
        //          PIX          *pixCensusTransform()
        //
        //      Generic convolution (with Pix)
        //          PIX          *pixConvolve()
        //          PIX          *pixConvolveSep()
        //          PIX          *pixConvolveRGB()
        //          PIX          *pixConvolveRGBSep()
        //
        //      Generic convolution (with float arrays)
        //          FPIX         *fpixConvolve()
        //          FPIX         *fpixConvolveSep()
        //
        //      Convolution with bias (for non-negative output)
        //          PIX          *pixConvolveWithBias()
        //
        //      Set parameter for convolution subsampling
        //          void          l_setConvolveSampling()
        //


    }
}
