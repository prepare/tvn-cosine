using System;

namespace Leptonica
{
    public static class Rotate
    {
        /* 
//     General rotation by sampling
//              PIX     *pixRotateBySampling()
//
//     Nice (slow) rotation of 1 bpp image
//              PIX     *pixRotateBinaryNice()
//
//     Rotation including alpha (blend) component
//              PIX     *pixRotateWithAlpha()*/

        // General rotation about image center 
        //              PIX     *pixEmbedForRotation()
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
        public static Pix pixRotate(Pix pix,
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
