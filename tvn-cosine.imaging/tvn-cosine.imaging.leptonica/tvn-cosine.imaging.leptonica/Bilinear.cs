using System;
using System.Runtime.InteropServices;

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

            var pointer = Native.DllImports.pixBilinearSampledPta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);

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

            var pointer = Native.DllImports.pixBilinearSampled((HandleRef)pixs, vc, incolor);

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
        /// <summary>
        ///      (1) Brings in either black or white pixels from the boundary
        ///      (2) Removes any existing colormap, if necessary, before transforming
        /// </summary>
        /// <param name="pixs">pixs all depths; colormap ok</param>
        /// <param name="ptad">ptad  4 pts of final coordinate space</param>
        /// <param name="ptas">ptas  4 pts of initial coordinate space</param>
        /// <param name="incolor">incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearPta(Pix pixs, Pta ptad, Pta ptas, InColorFlags incolor)
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

            var pointer = Native.DllImports.pixBilinearPta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);

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
        ///     (1) Brings in either black or white pixels from the boundary
        ///     (2) Removes any existing colormap, if necessary, before transforming
        /// </summary>
        /// <param name="pixs">pixs all depths; colormap ok</param>
        /// <param name="vc">vc  vector of 8 coefficients for bilinear transformation</param>
        /// <param name="incolor">incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinear(Pix pixs, float[] vc, InColorFlags incolor)
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

            var pointer = Native.DllImports.pixBilinear((HandleRef)pixs, vc, incolor);

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
        /// pixBilinearPtaColor()
        /// </summary>
        /// <param name="pixs">pixs 32 bpp</param>
        /// <param name="ptad">ptad  4 pts of final coordinate space</param>
        /// <param name="ptas">ptas  4 pts of initial coordinate space</param>
        /// <param name="colorval">colorval e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearPtaColor(Pix pixs, Pta ptad, Pta ptas, Tvn.Cosine.Imaging.IColor colorval)
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

            var pointer = Native.DllImports.pixBilinearPtaColor((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, colorval.ToAbgrUint());

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
        /// pixBilinearColor()
        /// </summary>
        /// <param name="pixs">pixs 32 bpp</param>
        /// <param name="vc">vc  vector of 8 coefficients for bilinear transformation</param>
        /// <param name="colorval">colorval e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearColor(Pix pixs, float[] vc, Tvn.Cosine.Imaging.IColor colorval)
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

            var pointer = Native.DllImports.pixBilinearColor((HandleRef)pixs, vc, colorval.ToAbgrUint());

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
        /// pixBilinearPtaGray()
        /// </summary>
        /// <param name="pixs">pixs 8 bpp</param>
        /// <param name="ptad">ptad  4 pts of final coordinate space</param>
        /// <param name="ptas"> ptas  4 pts of initial coordinate space</param>
        /// <param name="grayval">grayval 0 to bring in BLACK, 255 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearPtaGray(Pix pixs, Pta ptad, Pta ptas, byte grayval)
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

            var pointer = Native.DllImports.pixBilinearPtaGray((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, grayval);

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
        /// pixBilinearGray()
        /// </summary>
        /// <param name="pixs">pixs 8 bpp</param>
        /// <param name="vc">vc  vector of 8 coefficients for bilinear transformation</param>
        /// <param name="grayval">grayval 0 to bring in BLACK, 255 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearGray(Pix pixs, float[] vc, byte grayval)
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

            var pointer = Native.DllImports.pixBilinearGray((HandleRef)pixs, vc, grayval);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }



        // Bilinear transform including alpha (blend) component
        /// <summary>
        ///       (1) The alpha channel is transformed separately from pixs,
        ///           and aligns with it, being fully transparent outside the
        ///           boundary of the transformed pixs.For pixels that are fully
        /// transparent, a blending function like pixBlendWithGrayMask()
        ///           will give zero weight to corresponding pixels in pixs.
        ///       (2) If pixg is NULL, it is generated as an alpha layer that is
        ///           partially opaque, using %fract.Otherwise, it is cropped
        /// to pixs if required and %fract is ignored.The alpha channel
        ///          in pixs is never used.
        ///       (3) Colormaps are removed.
        /// 
        ///      (4) When pixs is transformed, it doesn't matter what color is brought
        ///           in because the alpha channel will be transparent(0) there.
        /// 
        ///      (5) To avoid losing source pixels in the destination, it may be
        ///  necessary to add a border to the source pix before doing
        ///  the bilinear transformation.This can be any non-negative number.
        ///       (6) The input %ptad and %ptas are in a coordinate space before
        ///  the border is added.Internally, we compensate for this
        ///           before doing the bilinear transform on the image after
        /// the border is added.
        /// 
        ///      (7) The default setting for the border values in the alpha channel
        ///           is 0 (transparent) for the outermost ring of pixels and
        ///           (0.5 * fract * 255) for the second ring.  When blended over
        ///           a second image, this
        ///           (a) shrinks the visible image to make a clean overlap edge
        ///               with an image below, and
        ///           (b) softens the edges by weakening the aliasing there.
        ///           Use l_setAlphaMaskBorder() to change these values.
        /// </summary>
        /// <param name="pixs">pixs 32 bpp rgb</param>
        /// <param name="ptad">ptad  4 pts of final coordinate space</param>
        /// <param name="ptas">ptas  4 pts of initial coordinate space</param>
        /// <param name="pixg">pixg [optional] 8 bpp, can be null</param>
        /// <param name="fract">fract between 0.0 and 1.0, with 0.0 fully transparent and 1.0 fully opaque</param>
        /// <param name="border">border of pixels added to capture transformed source pixels</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixBilinearPtaWithAlpha(Pix pixs, Pta ptad, Pta ptas, Pix pixg, float fract, int border)
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
            if (pixg == null)
            {
                pixg = new Pix(IntPtr.Zero);
            }

            var pointer = Native.DllImports.pixBilinearPtaWithAlpha((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, (HandleRef)pixg, fract, border);

            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }




        // Bilinear coordinate transformation
        /// <summary>
        /// We have a set of 8 equations, describing the bilinear
        /// transformation that takes 4 points ptas into 4 other
        /// points ptad.These equations are:
        ///
        ///          x1' = c[0]*x1 + c[1]*y1 + c[2]*x1*y1 + c[3]
        ///          y1' = c[4]*x1 + c[5]*y1 + c[6]*x1*y1 + c[7]
        ///          x2' = c[0]*x2 + c[1]*y2 + c[2]*x2*y2 + c[3]
        ///          y2' = c[4]*x2 + c[5]*y2 + c[6]*x2*y2 + c[7]
        ///          x3' = c[0]*x3 + c[1]*y3 + c[2]*x3*y3 + c[3]
        ///          y3' = c[4]*x3 + c[5]*y3 + c[6]*x3*y3 + c[7]
        ///          x4' = c[0]*x4 + c[1]*y4 + c[2]*x4*y4 + c[3]
        ///          y4' = c[4]*x4 + c[5]*y4 + c[6]*x4*y4 + c[7]
        ///
        /// This can be represented as
        ///
        ///           AC = B
        ///
        /// where B and C are column vectors
        ///
        ///         B = [x1' y1' x2' y2' x3' y3' x4' y4' ]
        /// C = [c[0] c[1] c[2] c[3] c[4] c[5] c[6] c[7]]
        ///
        ///and A is the 8x8 matrix
        ///
        ///             x1 y1   x1* y1   1   0    0      0     0
        ///              0    0     0     0   x1 y1   x1* y1   1
        ///             x2 y2   x2* y2   1   0    0      0     0
        ///              0    0     0     0   x2 y2   x2* y2   1
        ///             x3 y3   x3* y3   1   0    0      0     0
        ///              0    0     0     0   x3 y3   x3* y3   1
        ///             x4 y4   x4* y4   1   0    0      0     0
        ///              0    0     0     0   x4 y4   x4* y4   1
        ///
        /// These eight equations are solved here for the coefficients C.
        ///
        /// These eight coefficients can then be used to find the mapping
        /// x,y) --> (x',y':
        ///
        ///           x' = c[0]x + c[1]y + c[2]xy + c[3]
        ///           y' = c[4]x + c[5]y + c[6]xy + c[7]
        ///
        /// that are implemented in bilinearXformSampledPt and
        /// bilinearXFormPt.
        /// </summary>
        /// <param name="ptas">ptas  source 4 points; unprimed</param>
        /// <param name="ptad">ptad  transformed 4 points; primed</param>
        /// <param name="pvc">pvc   vector of coefficients of transform</param>
        /// <returns>true if OK; false on error</returns>
        public static bool getBilinearXformCoeffs(Pta ptas, Pta ptad, out float[] pvc)
        {
            if (ptad == null)
            {
                pvc = null;
                return false;
            }
            if (ptas == null)
            {
                pvc = null;
                return false;
            }

            return Native.DllImports.getBilinearXformCoeffs((HandleRef)ptad, (HandleRef)ptas, out pvc) == 0;
        }

        /// <summary>
        ///      (1) This finds the nearest pixel coordinates of the transformed point.
        ///      (2) It does not check ptrs for returned data!
        /// </summary>
        /// <param name="vc">vc vector of 8 coefficients</param>
        /// <param name="x">x, y  initial point</param>
        /// <param name="y">x, y  initial point</param>
        /// <param name="pxp">pxp, pyp   transformed point</param>
        /// <param name="pyp">pxp, pyp   transformed point</param>
        /// <returns>true if OK; false on error</returns>
        public static bool bilinearXformSampledPt(float[] vc, int x, int y, out int pxp, out int pyp)
        {
            if (vc == null)
            {
                pxp = 0;
                pyp = 0;
                return false;
            }

            return Native.DllImports.bilinearXformSampledPt(vc, x, y, out pxp, out pyp) == 0;
        }

        /// <summary>
        ///      (1) This computes the floating point location of the transformed point.
        ///      (2) It does not check ptrs for returned data!
        /// </summary>
        /// <param name="vc">vc vector of 8 coefficients</param>
        /// <param name="x">x, y  initial point</param>
        /// <param name="y">x, y  initial point</param>
        /// <param name="pxp">pxp, pyp   transformed point</param>
        /// <param name="pyp">pxp, pyp   transformed point</param>
        /// <returns>true if OK; false on error</returns>
        public static bool bilinearXformPt(float[] vc, int x, int y, out float pxp, out float pyp)
        {
            if (vc == null)
            {
                pxp = 0;
                pyp = 0;
                return false;
            }

            return Native.DllImports.bilinearXformPt(vc, x, y, out pxp, out pyp) == 0;
        } 
    } 
}
