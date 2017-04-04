using System;

namespace Leptonica
{
    /// <summary>
    /// scale.c
    /// </summary>
    public static class Scale
    {
        //  Top-level scaling  
        /// <summary>
        ///  This function scales 32 bpp RGB; 2, 4 or 8 bpp palette color;
        ///  2, 4, 8 or 16 bpp gray; and binary images.
        ///
        /// When the input has palette color, the colormap is removed and
        ///  the result is either 8 bpp gray or 32 bpp RGB, depending on whether
        ///  the colormap has color entries.Images with 2, 4 or 16 bpp are
        ///  converted to 8 bpp.
        ///
        /// Because pixScale is meant to be a very simple interface to a
        /// number of scaling functions, including the use of unsharp masking,
        ///  the type of scaling and the sharpening parameters are chosen
        ///  by default.  Grayscale and color images are scaled using one
        /// of four methods, depending on the scale factors:
        ///   1 antialiased subsampling(lowpass filtering followed by
        ///       subsampling, implemented here by area mapping), for scale factors
        /// less than 0.2
        ///   2 antialiased subsampling with sharpening, for scale factors
        /// between 0.2 and 0.7
        ///   3 linear interpolation with sharpening, for scale factors between
        ///       0.7 and 1.4
        ///   4 linear interpolation without sharpening, for scale factors >= 1.4.
        ///
        /// One could use subsampling for scale factors very close to 1.0,
        /// because it preserves sharp edges.Linear interpolation blurs
        ///  edges because the dest pixels will typically straddle two src edge
        /// pixels.  Subsmpling removes entire columns and rows, so the edge is
        ///  not blurred.  However, there are two reasons for not doing this.
        ///  First, it moves edges, so that a straight line at a large angle to
        ///  both horizontal and vertical will have noticeable kinks where
        /// horizontal and vertical rasters are removed.Second, although it
        ///  is very fast, you get good results on sharp edges by applying
        /// a sharpening filter.
        ///
        ///  For images with sharp edges, sharpening substantially improves the
        ///  image quality for scale factors between about 0.2 and about 2.0.
        ///  pixScale uses a small amount of sharpening by default because
        /// it strengthens edge pixels that are weak due to anti-aliasing.
        ///
        /// The default sharpening factors are:
        ///      * for scaling factors smaller  0.7:   sharpfract = 0.2    sharpwidth = 1
        /// * for scaling factors >= 0.7:  sharpfract = 0.4    sharpwidth = 2
        /// The cases where the sharpening halfwidth is 1 or 2 have special
        ///  implementations and are about twice as fast as the general case.
        ///
        ///  However, sharpening is computationally expensive, and one needs
        /// to consider the speed-quality tradeoff:
        ///      * For upscaling of RGB images, linear interpolation plus default
        ///        sharpening is about 5 times slower than upscaling alone.
        ///
        ///* For downscaling, area mapping plus default sharpening is
        ///        about 10 times slower than downscaling alone.
        ///
        /// When the scale factor is larger than 1.4, the cost of sharpening,
        ///
        /// which is proportional to image area, is very large compared to the
        /// incremental quality improvement, so we cut off the default use of
        ///  sharpening at 1.4.  Thus, for scale factors greater than 1.4,
        ///
        /// pixScale only does linear interpolation.
        ///
        ///  In many situations you will get a satisfactory result by scaling
        /// without sharpening: call pixScaleGeneral with %sharpfract = 0.0.
        ///
        /// Alternatively, if you wish to sharpen but not use the default
        ///  value, first call pixScaleGeneral with %sharpfract = 0.0, and
        /// then sharpen explicitly using pixUnsharpMasking.
        ///
        /// Binary images are scaled to binary by sampling the closest pixel,
        /// without any low-pass filtering averaging of neighboring pixels.
        ///  This will introduce aliasing for reductions.Aliasing can be
        /// prevented by using pixScaleToGray instead.
        ///
        ///
        ///*** Warning: implicit assumption about RGB component order
        ///               for LI color scaling
        /// </summary>
        /// <param name="source">pixs 1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="scaleX">scalex</param>
        /// <param name="scaleY">scaley</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScale(Pix source, float scaleX, float scaleY)
        {
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixScale(source.handleRef, scaleX, scaleY);
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
        ///      (1) See pixScale() for usage.
        ///      (2) This interface may change in the future, as other special
        ///          cases are added.
        ///      (3) The actual sharpening factors used depend on the maximum
        /// of the two scale factors(maxscale):
        ///            maxscale smaller = 0.2:        no sharpening
        ///            0.2 smaller maxscale smaller  1.4:   uses the input parameters
        ///            maxscale >= 1.4:        no sharpening
        ///      (4) To avoid sharpening for grayscale and color images with
        /// scaling factors between 0.2 and 1.4, call this function
        /// with %sharpfract == 0.0.
        ///      (5) To use arbitrary sharpening in conjunction with scaling,
        ///          call this function with %sharpfract = 0.0, and follow this
        ///          with a call to pixUnsharpMasking() with your chosen parameters.
        /// </summary>
        /// <param name="source">pixs 1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="scaleX">scalex, scaley both > 0.0</param>
        /// <param name="scaleY">scalex, scaley both > 0.0</param>
        /// <param name="sharpFraction"> sharpfract use 0.0 to skip sharpening</param>
        /// <param name="sharpWidth">sharpwidth halfwidth of low-pass filter; typ. 1 or 2</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleGeneral(Pix source, float scaleX, float scaleY, float sharpFraction, int sharpWidth)
        {
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixScaleGeneral(source.handleRef, scaleX, scaleY, sharpFraction, sharpWidth);
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
        /// ScaleToSizeRel()
        /// </summary>
        /// <param name="source">pixs</param>
        /// <param name="delWidth">delw  change in width, in pixels; 0 means no change</param>
        /// <param name="delHeight">delh  change in height, in pixels; 0 means no change</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleToSizeRel(Pix source, int delWidth, int delHeight)
        {
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixScaleToSizeRel(source.handleRef, delWidth, delHeight);
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
        ///      (1) This guarantees that the output scaled image has the
        /// dimension(s) you specify.
        ///           ~To specify the width with isotropic scaling, set %hd = 0.
        ///           ~To specify the height with isotropic scaling, set %wd = 0.
        ///           ~If both %wd and %hd are specified, the image is scaled
        ///             (in general, anisotropically) to that size.
        ///
        /// ~It is an error to set both %wd and %hd to 0.
        /// </summary>
        /// <param name="source">pixs 1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="width"> wd  target width; use 0 if using height as target</param>
        /// <param name="height">hd  target height; use 0 if using width as target</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleToSize(Pix source, int width, int height)
        {
            if (source == null)
            {
                return null;
            }

            var pointer = Native.DllImports.pixScaleToSize(source.handleRef, width, height);
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }



        //         Linearly interpreted (usually up-) scaling
        //               PIX      *pixScaleLI()     ***
        //               PIX      *pixScaleColorLI()
        //               PIX      *pixScaleColor2xLI()   ***
        //               PIX      *pixScaleColor4xLI()   ***
        //               PIX      *pixScaleGrayLI()
        //               PIX      *pixScaleGray2xLI()
        //               PIX      *pixScaleGray4xLI()
        //
        //         Scaling by closest pixel sampling
        //               PIX      *pixScaleBySampling()
        //               PIX      *pixScaleBySamplingToSize()
        //               PIX      *pixScaleByIntSampling()
        //
        //         Fast integer factor subsampling RGB to gray and to binary
        //               PIX      *pixScaleRGBToGrayFast()
        //               PIX      *pixScaleRGBToBinaryFast()
        //               PIX      *pixScaleGrayToBinaryFast()
        //
        //         Downscaling with (antialias) smoothing
        //               PIX      *pixScaleSmooth() ***
        //               PIX      *pixScaleRGBToGray2()   [special 2x reduction to gray]
        //
        //         Downscaling with (antialias) area mapping
        //               PIX      *pixScaleAreaMap()     ***
        //               PIX      *pixScaleAreaMap2()
        //
        //         Binary scaling by closest pixel sampling
        //               PIX      *pixScaleBinary()
        //
        //         Scale-to-gray (1 bpp --> 8 bpp; arbitrary downscaling)
        //               PIX      *pixScaleToGray()
        //               PIX      *pixScaleToGrayFast()
        //
        //         Scale-to-gray (1 bpp --> 8 bpp; integer downscaling)
        //               PIX      *pixScaleToGray2()
        //               PIX      *pixScaleToGray3()
        //               PIX      *pixScaleToGray4()
        //               PIX      *pixScaleToGray6()
        //               PIX      *pixScaleToGray8()
        //               PIX      *pixScaleToGray16()
        //
        //         Scale-to-gray by mipmap(1 bpp --> 8 bpp, arbitrary reduction)
        //               PIX      *pixScaleToGrayMipmap()
        //
        //         Grayscale scaling using mipmap
        //               PIX      *pixScaleMipmap()
        //
        //         Replicated (integer) expansion (all depths)
        //               PIX      *pixExpandReplicate()
        //
        //         Upscale 2x followed by binarization
        //               PIX      *pixScaleGray2xLIThresh()
        //               PIX      *pixScaleGray2xLIDither()
        //
        //         Upscale 4x followed by binarization
        //               PIX      *pixScaleGray4xLIThresh()
        //               PIX      *pixScaleGray4xLIDither()
        //
        //         Grayscale downscaling using min and max
        //               PIX      *pixScaleGrayMinMax()
        //               PIX      *pixScaleGrayMinMax2()
        //
        //         Grayscale downscaling using rank value
        //               PIX      *pixScaleGrayRankCascade()
        //               PIX      *pixScaleGrayRank2()
        //
        //         Helper function for transferring alpha with scaling
        //               l_int32   pixScaleAndTransferAlpha()
        //
        //         RGB scaling including alpha (blend) component
        //               PIX      *pixScaleWithAlpha()   *** 
    }
}
