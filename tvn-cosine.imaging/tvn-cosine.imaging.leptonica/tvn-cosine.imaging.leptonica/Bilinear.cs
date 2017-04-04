using System;

namespace Leptonica
{
    /// <summary>
    /// bilinear.c
    /// </summary>
    public static class Bilinear
    {
        // Bilinear (4 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        /// <summary>
        ///  (1) Brings in either black or white pixels from the boundary.
        ///       (2) Retains colormap, which you can do for a sampled transform..
        ///       (3) No 3 of the 4 points may be collinear.
        ///       (4) For 8 and 32 bpp pix, better quality is obtained by the
        ///  somewhat slower pixBilinearPta().  See that
        ///           function for relative timings between sampled and interpolated.
        /// </summary>
        /// <param name="pixs">pixs all depths</param>
        /// <param name="ptad">ptad  4 pts of final coordinate space</param>
        /// <param name="ptas">ptas  4 pts of initial coordinate space</param>
        /// <param name="incolor">incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearSampledPta(Pix pixs, Pta ptad, Pta ptas, InColorFlags incolor)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                return null;
            }
            if (ptad == null)
            {
                return null;
            }

            if (ptas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixBilinearSampledPta(pixs.handleRef, ptad.handleRef, ptas.handleRef, incolor);

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
        ///  Notes:
        ///       (1) Brings in either black or white pixels from the boundary.
        ///       (2) Retains colormap, which you can do for a sampled transform..
        ///       (3) For 8 or 32 bpp, much better quality is obtained by the
        ///  somewhat slower pixBilinear().  See that function
        ///          for relative timings between sampled and interpolated.
        /// </summary>
        /// <param name="pixs">pixs all depths</param>
        /// <param name="vc">vc  vector of 8 coefficients for bilinear transformation</param>
        /// <param name="incolor">incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearSampled(Pix pixs, float[] vc, InColorFlags incolor)
        {
            //ensure pix is not null;
            if (pixs == null)
            {
                return null;
            }
            if (vc == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixBilinearSampled(pixs.handleRef, vc, incolor);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }



        // Bilinear (4 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        //           PIX      *pixBilinearPta()
        //           PIX      *pixBilinear()
        //           PIX      *pixBilinearPtaColor()
        //           PIX      *pixBilinearColor()
        //           PIX      *pixBilinearPtaGray()
        //           PIX      *pixBilinearGray()
        //
        //      Bilinear transform including alpha (blend) component
        //           PIX      *pixBilinearPtaWithAlpha()
        //
        //      Bilinear coordinate transformation
        //           l_int32   getBilinearXformCoeffs()
        //           l_int32   bilinearXformSampledPt()
        //           l_int32   bilinearXformPt() 
         
    }
}
