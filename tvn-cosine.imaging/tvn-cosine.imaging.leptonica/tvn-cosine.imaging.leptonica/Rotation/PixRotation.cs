using System;

namespace leptonica.net.Rotation
{
    public class PixRotation
    {
        /// <summary>
        ///      (1) This is a simple high-level interface, that uses default
        ///          values of the parameters for reasonable speed and accuracy.
        ///      (2) The angle returned is the negative of the skew angle of
        /// the image.It is the angle required for deskew.
        ///
        /// Clockwise rotations are positive angles.
        /// </summary>
        /// <param name="pix">pixs  1 bpp</param>
        /// <param name="radiance">pangle   angle required to deskew, in degrees</param>
        /// <param name="confidence">pconf    confidence value is ratio max/min scores</param>
        /// <returns>true if OK, false on error or if angle measurment not valid</returns>
        public bool FindSkew(Pix pix, out float radiance, out float confidence)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                radiance = 0;
                confidence = 0;
                return false;
            }

            return Native.DllImports.pixFindSkew(pix.handleRef, out radiance, out confidence) == 0;
        }

        /// <summary>
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs  any depth</param>
        /// <param name="redsweep">redsweep  for linear search: reduction factor = 1, 2 or 4;use 0 for default</param>
        /// <param name="sweepRange">sweeprange in degrees in each direction from 0;use 0.0 for default</param>
        /// <param name="sweepDelta">sweepdelta in degrees; use 0.0 for default</param>
        /// <param name="redsearch">redsearch  for binary search: reduction factor = 1, 2 or 4;use 0 for default;</param>
        /// <param name="threshold">thresh for binarizing the image; use 0 for default</param>
        /// <param name="radiance">pangle   [optional] angle required to deskew,in degrees; use NULL to skip</param>
        /// <param name="confidence">[optional] conf value is ratio of max/min scores; use NULL to skip</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public Pix DeskewGeneral(Pix pix, DeskewRedSweep redsweep, float sweepRange, float sweepDelta, DeskewRedSearch redsearch, int threshold, out float radiance, out float confidence)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                radiance = 0;
                confidence = 0;
                return null;
            }

            var pointer = Native.DllImports.pixDeskewGeneral(pix.handleRef, redsweep, sweepRange, sweepDelta, redsearch, threshold, out radiance, out confidence);
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                radiance = 0;
                confidence = 0;
                return null;
            }
        }

        /// <summary>
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs any depth</param>
        /// <param name="redsearch">redsearch for binary search: reduction factor = 1, 2 or 4;use 0 for default</param>
        /// <param name="pangle">pangle   [optional] angle required to deskew,in degrees; use NULL to skip</param>
        /// <param name="pconf">pconf    [optional] conf value is ratio of max/min scores; use NULL to skip</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public Pix FindSkewAndDeskew(Pix pix, DeskewRedSearch redsearch, out float radiance, out float confidence)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                radiance = 0;
                confidence = 0;
                return null;
            }

            var pointer = Native.DllImports.pixFindSkewAndDeskew(pix.handleRef, redsearch, out radiance, out confidence);
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
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pix">pixs any depth</param>
        /// <param name="redSearch">redsearch for binary search: reduction factor = 1, 2 or 4; use 0 for default</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public Pix Deskew(Pix pix, DeskewRedSearch redSearch = DeskewRedSearch.DEFAULT)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixDeskew(pix.handleRef, redSearch);
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
        ///      (1) This is a high-level, simple interface for rotating images
        ///          about their center.
        ///      (2) For very small rotations, just return a clone.
        ///      (3) Rotation brings either white or black pixels in
        ///          from outside the image.
        ///      (4) The rotation type is adjusted if necessary for the image
        ///          depth and size of rotation angle.For 1 bpp images, we
        /// rotate either by shear or sampling.
        ///      (5) Colormaps are removed for rotation by area mapping.
        ///      (6) The dest can be expanded so that no image pixels
        ///          are lost.To invoke expansion, input the original
        /// width and height.  For repeated rotation, use of the
        /// original width and height allows the expansion to
        /// stop at the maximum required size, which is a square
        ///          with side = sqrt(w * w + h * h).
        /// </summary>
        /// <param name="pix">pixs 1, 2, 4, 8, 32 bpp rgb</param>
        /// <param name="radiance">angle radians; clockwise is positive</param>
        /// <param name="type">type L_ROTATE_AREA_MAP, L_ROTATE_SHEAR, L_ROTATE_SAMPLING</param>
        /// <param name="incolor"> incolor L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <param name="width">width original width; use 0 to avoid embedding</param>
        /// <param name="height">height original height; use 0 to avoid embedding</param>
        /// <returns>pixd, or NULL on error</returns>
        public Pix Rotate(Pix pix,
                          float radiance,
                          RotateFlags type = RotateFlags.ROTATE_SAMPLING,
                          RotateInColorFlags incolor = RotateInColorFlags.BRING_IN_WHITE,
                          int width = -1,
                          int height = -1)
        {
            //ensure pix is not null;
            if (pix == null)
            {
                return null;
            }

            //fix the width and height
            if (width == -1 || height == -1)
            {
                width = pix.Width;
                height = pix.Height;
            }

            var pointer = Native.DllImports.pixRotate(pix.handleRef, radiance, type, incolor, width, height);
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
