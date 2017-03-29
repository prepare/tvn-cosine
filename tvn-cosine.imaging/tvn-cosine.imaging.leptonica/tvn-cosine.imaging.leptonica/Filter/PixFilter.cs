using System;

namespace leptonica.net.Filter
{
    public class PixFilter
    {
        /// <summary>
        ///      (1) This adds noise to each pixel, taken from a normal
        /// distribution with zero mean and specified standard deviation.
        /// </summary>
        /// <param name="source">pixs 8 bpp gray or 32 bpp rgb; no colormap</param>
        /// <param name="standardDeviation">stdev of noise</param>
        /// <returns>pixd 8 or 32 bpp, or NULL on error</returns>
        public Pix AddGaussianNoise(Pix source, float standardDeviation)
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
        public Pix Blockconv(Pix source, int wc, int hc)
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

        /// <summary>
        /// One and two-image boolean ops on arbitrary depth images
        /// </summary>
        /// <param name="destination">pixd  [optional]; this can be null, equal to pixs, or different from pixs</param>
        /// <param name="source">pixs</param>
        /// <returns>pixd, or NULL on error</returns>
        public Pix Invert(Pix destination, Pix source)
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
