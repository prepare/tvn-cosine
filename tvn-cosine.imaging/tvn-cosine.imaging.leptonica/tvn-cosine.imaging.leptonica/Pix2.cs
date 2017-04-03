using System; 

namespace Leptonica
{
    public static class Pix2
    { 
        /// <summary>
        /// (1) See pixGetBlackOrWhiteVal() for values of black and white pixels.
        /// </summary>
        /// <param name="source">pixs all depths; colormap ok</param>
        /// <param name="width">npix number of pixels to be added to each side</param>
        /// <param name="borderColor">val  value of added border pixels</param>
        /// <returns>pixd with the added exterior pixels, or NULL on error</returns>
        public static Pix pixAddBorder(Pix source, int width, Tvn.Cosine.Imaging.Color borderColor)
        {
            //ensure pix is not null;
            if (source == null || borderColor == null || width < 1)
            {
                return null;
            }

            var pointer = Native.DllImports.pixAddBorder(source.handleRef, width, borderColor.ToAbgrUint());
            if (pointer != IntPtr.Zero)
            {
                return new Pix(pointer);
            }
            else
            {
                return null;
            }
        }

        /*
 //Pixel poking
 //           l_int32     pixGetPixel()
 //           l_int32     pixSetPixel()
 //           l_int32     pixGetRGBPixel()
 //           l_int32     pixSetRGBPixel()
 //           l_int32     pixGetRandomPixel()
 //           l_int32     pixClearPixel()
 //           l_int32     pixFlipPixel()
 //           void        setPixelLow()
 //
 //      Find black or white value
 //           l_int32     pixGetBlackOrWhiteVal()
 //
 //      Full image clear/set/set-to-arbitrary-value
 //           l_int32     pixClearAll()
 //           l_int32     pixSetAll()
 //           l_int32     pixSetAllGray()
 //           l_int32     pixSetAllArbitrary()
 //           l_int32     pixSetBlackOrWhite()
 //           l_int32     pixSetComponentArbitrary()
 //
 //      Rectangular region clear/set/set-to-arbitrary-value/blend
 //           l_int32     pixClearInRect()
 //           l_int32     pixSetInRect()
 //           l_int32     pixSetInRectArbitrary()
 //           l_int32     pixBlendInRect()
 //
 //      Set pad bits
 //           l_int32     pixSetPadBits()
 //           l_int32     pixSetPadBitsBand()
 //
 //      Assign border pixels
 //           l_int32     pixSetOrClearBorder()
 //           l_int32     pixSetBorderVal()
 //           l_int32     pixSetBorderRingVal()
 //           l_int32     pixSetMirroredBorder()
 //           PIX        *pixCopyBorder()
 //
 //      Add and remove border 
 //           PIX        *pixAddBlackOrWhiteBorder()
 //           PIX        *pixAddBorderGeneral()
 //           PIX        *pixRemoveBorder()
 //           PIX        *pixRemoveBorderGeneral()
 //           PIX        *pixRemoveBorderToSize()
 //           PIX        *pixAddMirroredBorder()
 //           PIX        *pixAddRepeatedBorder()
 //           PIX        *pixAddMixedBorder()
 //           PIX        *pixAddContinuedBorder()
 //
 //      Helper functions using alpha
 //           l_int32     pixShiftAndTransferAlpha()
 //           PIX        *pixDisplayLayersRGBA()
 //
 //      Color sample setting and extraction
 //           PIX        *pixCreateRGBImage()
 //           PIX        *pixGetRGBComponent()
 //           l_int32     pixSetRGBComponent()
 //           PIX        *pixGetRGBComponentCmap()
 //           l_int32     pixCopyRGBComponent()
 //           l_int32     composeRGBPixel()
 //           l_int32     composeRGBAPixel()
 //           void        extractRGBValues()
 //           void        extractRGBAValues()
 //           l_int32     extractMinMaxComponent()
 //           l_int32     pixGetRGBLine()
 //
 //      Conversion between big and little endians
 //           PIX        *pixEndianByteSwapNew()
 //           l_int32     pixEndianByteSwap()
 //           l_int32     lineEndianByteSwap()
 //           PIX        *pixEndianTwoByteSwapNew()
 //           l_int32     pixEndianTwoByteSwap()
 //
 //      Extract raster data as binary string
 //           l_int32     pixGetRasterData()
 //
 //      Test alpha component opaqueness
 //           l_int32     pixAlphaIsOpaque
 //
 //      Setup helpers for 8 bpp byte processing
 //           l_uint8   **pixSetupByteProcessing()
 //           l_int32     pixCleanupByteProcessing()
 //
 //      Setting parameters for antialias masking with alpha transforms
 //           void        l_setAlphaMaskBorder()
         * */
    }
}
