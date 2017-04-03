using System;

namespace Leptonica.ColorCorrection
{
    public class PixColorCorrection
    {
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

    }
}
