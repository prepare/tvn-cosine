using System;

namespace Leptonica
{
    public static class Affine
    {
        //   Affine(3 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        /// <summary>
        ///  Notes:
        ///       (1) Brings in either black or white pixels from the boundary.
        ///       (2) Retains colormap, which you can do for a sampled transform..
        ///       (3) The 3 points must not be collinear.
        ///       (4) The order of the 3 points is arbitrary; however, to compare
        ///           with the sequential transform they must be in these locations
        ///           and in this order: origin, x-axis, y-axis.
        ///       (5) For 1 bpp images, this has much better quality results
        ///  than pixAffineSequential(), particularly for text.
        /// 
        /// It is about 3x slower, but does not require additional
        ///           border pixels.The poor quality of pixAffineSequential()
        ///           is due to repeated quantized transforms.It is strongly
        /// recommended that pixAffineSampled() be used for 1 bpp images.
        ///       (6) For 8 or 32 bpp, much better quality is obtained by the
        /// somewhat slower pixAffinePta().  See that function
        ///          for relative timings between sampled and interpolated.
        ///       (7) To repeat, use of the sequential transform,
        ///           pixAffineSequential(), for any images, is discouraged.
        /// </summary>
        /// <param name="pixs">pixs all depths</param>
        /// <param name="ptad">ptad  3 pts of final coordinate space</param>
        /// <param name="ptas">ptas  3 pts of initial coordinate space</param>
        /// <param name="incolor">incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineSampledPta(Pix source, Pta ptad, Pta ptas, IncolorFlags incolor)
        {
            if (source == null)
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

            var pointer = Native.DllImports.pixAffineSampledPta(source.handleRef,
                ptad.handleRef, ptas.handleRef, incolor);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }
         
        // PIX        * pixAffineSampled()
        




        // Affine(3 pt) image transformation using interpolation
        //      (or area mapping) for anti-aliasing images that are
        //      2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        // PIX        * pixAffinePta()
        // PIX        * pixAffine()
        // PIX        * pixAffinePtaColor()
        // PIX        * pixAffineColor()
        // PIX        * pixAffinePtaGray()
        // PIX        * pixAffineGray()
        




        // Affine transform including alpha(blend) component
        //PIX        * pixAffinePtaWithAlpha()





        // Affine coordinate transformation
        // l_int32     getAffineXformCoeffs()
        // l_int32     affineInvertXform()
        // l_int32     affineXformSampledPt()
        // l_int32     affineXformPt()
     




        // Interpolation helper functions
        // l_int32     linearInterpolatePixelGray()
        // l_int32     linearInterpolatePixelColor()
  




        // Gauss-jordan linear equation solver
        // l_int32     gaussjordan()
  



        // Affine image transformation using a sequence of
        // shear/scale/translation operations
        // PIX        * pixAffineSequential()
    }
}
