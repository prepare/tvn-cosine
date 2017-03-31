using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tvn.Cosine;

namespace Leptonica.Native
{
    internal class DllImports
    {
        #region set up
        private const string zlibDllName = "zlib.dll";
        private const string libPngDllName = "libpng16.dll";
        private const string jpegDllName = "jpeg.dll";
        private const string tiffDllName = "tiff.dll";
        private const string tiffXxDllName = "tiffxx.dll";
        private const string leptonicaDllName = "leptonica-1.74.1.dll";

        private static bool initialised = false;

        static DllImports()
        {
            Init();
        }

        static void Init()
        {
            if (!initialised)
            {
                var path = string.Format("{0}\\lib", AppDomain.CurrentDomain.BaseDirectory);
                if (Architecture.is64BitProcess)
                {
                    path = string.Format("{0}\\{1}", path, "x64");
                }
                else
                {
                    path = string.Format("{0}\\{1}", path, "x86");
                }

                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, zlibDllName));
                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, libPngDllName));
                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, jpegDllName));
                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, tiffDllName));
                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, tiffXxDllName));
                Architecture.LoadLibrary(string.Format("{0}\\{1}", path, leptonicaDllName));

                initialised = true;
            }
        }
        #endregion

        #region Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreate")]
        internal static extern IntPtr pixCreate(int width, int height, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRead")]
        internal static extern IntPtr pixRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClone")]
        internal static extern IntPtr pixClone(HandleRef pixs); // Create a shallow copy of pointer

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopy")]
        internal static extern IntPtr pixCopy(IntPtr pixd, HandleRef pixs); // Create a deep copy of data

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroy")]
        internal static extern void pixDestroy(ref IntPtr ppix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern int pixDestroyColormap(HandleRef pix);

        #region HandleRef Getters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWidth")]
        internal static extern int pixGetWidth(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetHeight")]
        internal static extern int pixGetHeight(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDepth")]
        internal static extern int pixGetDepth(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetSpp")]
        internal static extern int pixGetSpp(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWpl")]
        internal static extern int pixGetWpl(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRefcount")]
        internal static extern int pixGetRefcount(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetXRes")]
        internal static extern int pixGetXRes(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetYRes")]
        internal static extern int pixGetYRes(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetInputFormat")]
        internal static extern ImageFileFormat pixGetInputFormat(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetText")]
        internal static extern IntPtr pixGetText(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColormap")]
        internal static extern IntPtr pixGetColormap(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetData")]
        internal static extern IntPtr pixGetData(HandleRef pix);
        #endregion

        #region HandleRef Setters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetWidth")]
        internal static extern int pixSetWidth(HandleRef pix, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetHeight")]
        internal static extern int pixSetHeight(HandleRef pix, int height);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetDepth")]
        internal static extern int pixSetDepth(HandleRef pix, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSpp")]
        internal static extern int pixSetSpp(HandleRef pix, int spp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetWpl")]
        internal static extern int pixSetWpl(HandleRef pix, int wpl);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixChangeRefcount")]
        internal static extern int pixChangeRefcount(HandleRef pix, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetXRes")]
        internal static extern int pixSetXRes(HandleRef pix, int res);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetYRes")]
        internal static extern int pixSetYRes(HandleRef pix, int res);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInputFormat")]
        internal static extern int pixSetInputFormat(HandleRef pix, ImageFileFormat informat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetText")]
        internal static extern int pixSetText(HandleRef pix, [MarshalAs(UnmanagedType.AnsiBStr)] string textstring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetColormap")]
        internal static extern int pixSetColormap(HandleRef pix, HandleRef colormap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetData")]
        internal static extern int pixSetData(HandleRef pix, IntPtr data);
        #endregion

        #region Pix Rotations 

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkew")]
        internal static extern int pixFindSkew(HandleRef pixs, out float pangle, out float pconf);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskew")]
        internal static extern IntPtr pixDeskew(HandleRef pixs, DeskewRedSearch redsearch);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewAndDeskew")]
        internal static extern IntPtr pixFindSkewAndDeskew(HandleRef pixs, DeskewRedSearch redsearch, out float pangle, out float pconf);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewGeneral")]
        internal static extern IntPtr pixDeskewGeneral(HandleRef pixs, DeskewRedSweep redsweep, float sweeprange, float sweepdelta, DeskewRedSearch redsearch, int thresh, out float pangle, out float pconf);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate")]
        internal static extern IntPtr pixRotate(HandleRef pixs, float angle, RotateFlags type, RotateInColorFlags incolor, int width, int height);
        #endregion

        #region Pix Drawing

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBorder")]
        internal static extern IntPtr pixAddBorder(HandleRef pixs, int npix, uint val);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintThroughMask")]
        internal static extern int pixPaintThroughMask(HandleRef pixd, HandleRef pixm, int x, int y, uint val);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCombineMaskedGeneral")]
        internal static extern int pixCombineMaskedGeneral(HandleRef pixd, HandleRef pixs, HandleRef pixm, int x, int y);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskBoxa")]
        internal static extern IntPtr pixMaskBoxa(HandleRef pixd, HandleRef pixs, HandleRef boxa, GraphicPixelSetting op);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintBoxa")]
        internal static extern IntPtr pixPaintBoxa(HandleRef pixs, HandleRef boxa, uint val);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintBoxaRandom")]
        internal static extern IntPtr pixPaintBoxaRandom(HandleRef pixs, HandleRef boxa);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDrawBoxaRandom")]
        internal static extern IntPtr pixDrawBoxaRandom(HandleRef pixs, HandleRef boxa, int width);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDrawBoxa")]
        internal static extern IntPtr pixDrawBoxa(HandleRef pixs, HandleRef boxa, int width, uint val);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCombineMasked")]
        internal static extern int pixCombineMasked(HandleRef pixd, HandleRef pixs, HandleRef pixm);

        #endregion

        #region Color Correction

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNorm")]
        internal static extern IntPtr pixBackgroundNorm(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyBrightness")]
        internal static extern IntPtr pixModifyBrightness(HandleRef pixd, HandleRef pixs, float fract);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCleanBackgroundToWhite")]
        internal static extern IntPtr pixCleanBackgroundToWhite(HandleRef pixs, HandleRef pixim, HandleRef pixg, float gamma, int blackval, int whiteval);

        #endregion

        #region Filter

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGaussianNoise")]
        internal static extern IntPtr pixAddGaussianNoise(HandleRef pixs, float stdev);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconv")]
        internal static extern IntPtr pixBlockconv(HandleRef pix, int wc, int hc);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixInvert")]
        internal static extern IntPtr pixInvert(HandleRef pixd, HandleRef pixs);
        #endregion

        #region Resizing 

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGeneral")]
        internal static extern IntPtr pixScaleGeneral(HandleRef pixs, float scalex, float scaley, float sharpfract, int sharpwidth);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToSizeRel")]
        internal static extern IntPtr pixScaleToSizeRel(HandleRef pixs, int delw, int delh);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipRectangle")]
        internal static extern IntPtr pixClipRectangle(HandleRef pixs, HandleRef box, out IntPtr pboxc);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScale")]
        internal static extern IntPtr pixScale(HandleRef pixs, float scalex, float scaley);

        /* DONE */
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToSize")]
        internal static extern IntPtr pixScaleToSize(HandleRef pixs, int wd, int hd);

        #endregion

        #endregion

        #region Box
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCreate")]
        internal static extern IntPtr boxCreate(int x, int y, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCreateValid")]
        internal static extern IntPtr boxCreateValid(int x, int y, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCopy")]
        internal static extern IntPtr boxCopy(HandleRef box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClone")]
        internal static extern IntPtr boxClone(HandleRef box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxDestroy")]
        internal static extern void boxDestroy(ref IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetGeometry")]
        internal static extern int boxGetGeometry(HandleRef box, out int px, out int py, out int pw, out int ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSetGeometry")]
        internal static extern int boxSetGeometry(HandleRef box, int x, int y, int w, int h);
        #endregion

        #region PixColorMap 
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern IntPtr pixcmapCreate(int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern IntPtr pixcmapCreateRandom(int depth, int hasblack, int haswhite);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern IntPtr pixcmapCreateLinear(int d, int nlevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern IntPtr pixcmapCopy(HandleRef cmaps);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern void pixcmapDestroy(ref IntPtr pcmap);

        #region PixColorMap Getters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetDepth")]
        internal static extern int pixcmapGetDepth(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetCount")]
        internal static extern int pixcmapGetCount(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRGBA")]
        internal static extern int pixcmapGetRGBA(HandleRef cmap, int index, out int prval, out int pgval, out int pbval, out int paval);
        #endregion
        #endregion

        #region Boxa 
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCreate")]
        internal static extern IntPtr boxaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetCount")]
        internal static extern int boxaGetCount(HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetBox")]
        internal static extern IntPtr boxaGetBox(HandleRef boxa, int index, InsertionType accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCopy")]
        internal static extern IntPtr boxaCopy(HandleRef boxa, InsertionType copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAddBox")]
        internal static extern int boxaAddBox(HandleRef boxa, HandleRef box, InsertionType copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRemoveBox")]
        internal static extern int boxaRemoveBox(HandleRef boxa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaDestroy")]
        internal static extern void boxaDestroy(ref IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtendArray")]
        internal static extern int boxaExtendArray(HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtendArrayToSize")]
        internal static extern int boxaExtendArrayToSize(HandleRef boxa, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaClear")]
        internal static extern int boxaClear(HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReplaceBox")]
        internal static extern int boxaReplaceBox(HandleRef boxa, int index, HandleRef box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaInsertBox")]
        internal static extern int boxaInsertBox(HandleRef boxa, int index, HandleRef box);

        #endregion

        #region Pixa

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreate")]
        internal static extern IntPtr pixaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetCount")]
        internal static extern int pixaGetCount(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCopy")]
        internal static extern IntPtr pixaCopy(HandleRef pixa, InsertionType copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDestroy")]
        internal static extern void pixaDestroy(ref IntPtr ppixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPix")]
        internal static extern IntPtr pixaGetPix(HandleRef pixa, int index, InsertionType accesstype);
        #endregion


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormSimple")]
        internal static extern IntPtr pixBackgroundNormSimple(HandleRef pixs, HandleRef pixim, HandleRef pixg);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormMorph")]
        internal static extern IntPtr pixBackgroundNormMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormGrayArray")]
        internal static extern int pixBackgroundNormGrayArray(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, out HandleRef ppixd);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormRGBArrays")]
        internal static extern int pixBackgroundNormRGBArrays(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, out HandleRef ppixr, out HandleRef ppixg, out HandleRef ppixb);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormGrayArrayMorph")]
        internal static extern int pixBackgroundNormGrayArrayMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval, out HandleRef ppixd);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormRGBArraysMorph")]
        internal static extern int pixBackgroundNormRGBArraysMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval, out HandleRef ppixr, out HandleRef ppixg, out HandleRef ppixb);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundGrayMap")]
        internal static extern int pixGetBackgroundGrayMap(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, out HandleRef ppixd);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundRGBMap")]
        internal static extern int pixGetBackgroundRGBMap(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, out HandleRef ppixmr, out HandleRef ppixmg, out HandleRef ppixmb);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundGrayMapMorph")]
        internal static extern int pixGetBackgroundGrayMapMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, out HandleRef ppixm);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundRGBMapMorph")]
        internal static extern int pixGetBackgroundRGBMapMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, out HandleRef ppixmr, out HandleRef ppixmg, out HandleRef ppixmb);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillMapHoles")]
        internal static extern int pixFillMapHoles(HandleRef pix, int nx, int ny, int filltype);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtendByReplication")]
        internal static extern IntPtr pixExtendByReplication(HandleRef pixs, int addw, int addh);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSmoothConnectedRegions")]
        internal static extern int pixSmoothConnectedRegions(HandleRef pixs, HandleRef pixm, int factor);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetInvBackgroundMap")]
        internal static extern IntPtr pixGetInvBackgroundMap(HandleRef pixs, int bgval, int smoothx, int smoothy);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyInvBackgroundGrayMap")]
        internal static extern IntPtr pixApplyInvBackgroundGrayMap(HandleRef pixs, HandleRef pixm, int sx, int sy);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyInvBackgroundRGBMap")]
        internal static extern IntPtr pixApplyInvBackgroundRGBMap(HandleRef pixs, HandleRef pixmr, HandleRef pixmg, HandleRef pixmb, int sx, int sy);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyVariableGrayMap")]
        internal static extern IntPtr pixApplyVariableGrayMap(HandleRef pixs, HandleRef pixg, int target);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGlobalNormRGB")]
        internal static extern IntPtr pixGlobalNormRGB(HandleRef pixd, IntPtr pixs, int rval, int gval, int bval, int mapval);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGlobalNormNoSatRGB")]
        internal static extern IntPtr pixGlobalNormNoSatRGB(HandleRef pixd, IntPtr pixs, int rval, int gval, int bval, int factor, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdSpreadNorm")]
        internal static extern int pixThresholdSpreadNorm(HandleRef pixs, int filtertype, int edgethresh, int smoothx, int smoothy, float gamma, int minval, int maxval, int targetthresh, IntPtr ppixth, IntPtr ppixb, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormFlex")]
        internal static extern IntPtr pixBackgroundNormFlex(HandleRef pixs, int sx, int sy, int smoothx, int smoothy, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastNorm")]
        internal static extern IntPtr pixContrastNorm(HandleRef pixd, IntPtr Pix, int sx, int sy, int mindiff, int smoothx, int smoothy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinMaxTiles")]
        internal static extern int pixMinMaxTiles(HandleRef pixs, int sx, int sy, int mindiff, int smoothx, int smoothy, IntPtr ppixmin, IntPtr ppixmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetLowContrast")]
        internal static extern int pixSetLowContrast(HandleRef pixs1, HandleRef pixs2, int mindiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLinearTRCTiled")]
        internal static extern IntPtr pixLinearTRCTiled(HandleRef pixd, IntPtr pixs, int sx, int sy, IntPtr pixmin, IntPtr pixmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSampledPta")]
        internal static extern IntPtr pixAffineSampledPta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSampled")]
        internal static extern IntPtr pixAffineSampled(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePta")]
        internal static extern IntPtr pixAffinePta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffine")]
        internal static extern IntPtr pixAffine(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaColor")]
        internal static extern IntPtr pixAffinePtaColor(HandleRef pixs, IntPtr ptad, IntPtr ptas, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineColor")]
        internal static extern IntPtr pixAffineColor(HandleRef pixs, IntPtr vc, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaGray")]
        internal static extern IntPtr pixAffinePtaGray(HandleRef pixs, IntPtr ptad, IntPtr ptas, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineGray")]
        internal static extern IntPtr pixAffineGray(HandleRef pixs, IntPtr vc, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaWithAlpha")]
        internal static extern IntPtr pixAffinePtaWithAlpha(HandleRef pixs, HandleRef ptad, HandleRef ptas, HandleRef pixg, float fract, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getAffineXformCoeffs")]
        internal static extern int getAffineXformCoeffs(HandleRef ptas, IntPtr ptad, IntPtr pvc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineInvertXform")]
        internal static extern int affineInvertXform(HandleRef vc, IntPtr pvci);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineXformSampledPt")]
        internal static extern int affineXformSampledPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineXformPt")]
        internal static extern int affineXformPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelColor")]
        internal static extern int linearInterpolatePixelColor(HandleRef datas, int wpls, int w, int h, float x, float y, uint colorval, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelGray")]
        internal static extern int linearInterpolatePixelGray(HandleRef datas, int wpls, int w, int h, float x, float y, int grayval, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gaussjordan")]
        internal static extern int gaussjordan(HandleRef a, IntPtr b, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSequential")]
        internal static extern IntPtr pixAffineSequential(HandleRef pixs, IntPtr ptad, IntPtr ptas, int bw, int bh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dTranslate")]
        internal static extern IntPtr createMatrix2dTranslate(float transx, float transy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dScale")]
        internal static extern IntPtr createMatrix2dScale(float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dRotate")]
        internal static extern IntPtr createMatrix2dRotate(float xc, float yc, float angle);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTranslate")]
        internal static extern IntPtr ptaTranslate(HandleRef ptas, float transx, float transy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaScale")]
        internal static extern IntPtr ptaScale(HandleRef ptas, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRotate")]
        internal static extern IntPtr ptaRotate(HandleRef ptas, float xc, float yc, float angle);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTranslate")]
        internal static extern IntPtr boxaTranslate(HandleRef boxas, float transx, float transy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaScale")]
        internal static extern IntPtr boxaScale(HandleRef boxas, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRotate")]
        internal static extern IntPtr boxaRotate(HandleRef boxas, float xc, float yc, float angle);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaAffineTransform")]
        internal static extern IntPtr ptaAffineTransform(HandleRef ptas, IntPtr mat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAffineTransform")]
        internal static extern IntPtr boxaAffineTransform(HandleRef boxas, IntPtr mat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMatVec")]
        internal static extern int l_productMatVec(HandleRef mat, IntPtr vecs, IntPtr vecd, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat2")]
        internal static extern int l_productMat2(HandleRef mat1, IntPtr mat2, IntPtr matd, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat3")]
        internal static extern int l_productMat3(HandleRef mat1, IntPtr mat2, IntPtr mat3, IntPtr matd, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat4")]
        internal static extern int l_productMat4(HandleRef mat1, IntPtr mat2, IntPtr mat3, IntPtr mat4, IntPtr matd, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataBit")]
        internal static extern int l_getDataBit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataBit")]
        internal static extern void l_setDataBit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataBit")]
        internal static extern void l_clearDataBit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataBitVal")]
        internal static extern void l_setDataBitVal(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataDibit")]
        internal static extern int l_getDataDibit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataDibit")]
        internal static extern void l_setDataDibit(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataDibit")]
        internal static extern void l_clearDataDibit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataQbit")]
        internal static extern int l_getDataQbit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataQbit")]
        internal static extern void l_setDataQbit(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataQbit")]
        internal static extern void l_clearDataQbit(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataByte")]
        internal static extern int l_getDataByte(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataByte")]
        internal static extern void l_setDataByte(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataTwoBytes")]
        internal static extern int l_getDataTwoBytes(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataTwoBytes")]
        internal static extern void l_setDataTwoBytes(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataFourBytes")]
        internal static extern int l_getDataFourBytes(HandleRef line, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataFourBytes")]
        internal static extern void l_setDataFourBytes(HandleRef line, int n, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "barcodeDispatchDecoder")]
        internal static extern IntPtr barcodeDispatchDecoder(HandleRef barstr, int format, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "barcodeFormatIsSupported")]
        internal static extern int barcodeFormatIsSupported(int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindBaselines")]
        internal static extern IntPtr pixFindBaselines(HandleRef pixs, IntPtr ppta, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewLocal")]
        internal static extern IntPtr pixDeskewLocal(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLocalSkewTransform")]
        internal static extern int pixGetLocalSkewTransform(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, IntPtr pptas, IntPtr pptad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLocalSkewAngles")]
        internal static extern IntPtr pixGetLocalSkewAngles(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, IntPtr pa, IntPtr pb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr bbufferCreate(HandleRef indata, int nalloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferDestroy")]
        internal static extern void bbufferDestroy(HandleRef pbb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferDestroyAndSaveData")]
        internal static extern IntPtr bbufferDestroyAndSaveData(HandleRef pbb, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferRead")]
        internal static extern int bbufferRead(HandleRef bb, IntPtr src, int nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferReadStream")]
        internal static extern int bbufferReadStream(HandleRef bb, IntPtr fp, int nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferExtendArray")]
        internal static extern int bbufferExtendArray(HandleRef bb, int nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferWrite")]
        internal static extern int bbufferWrite(HandleRef bb, IntPtr dest, IntPtr nbytes, IntPtr pnout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferWriteStream")]
        internal static extern int bbufferWriteStream(HandleRef bb, IntPtr fp, IntPtr nbytes, IntPtr pnout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilateral")]
        internal static extern IntPtr pixBilateral(HandleRef pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilateralGray")]
        internal static extern IntPtr pixBilateralGray(HandleRef pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilateralExact")]
        internal static extern IntPtr pixBilateralExact(HandleRef pixs, IntPtr spatial_kel, IntPtr range_kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilateralGrayExact")]
        internal static extern IntPtr pixBilateralGrayExact(HandleRef pixs, IntPtr spatial_kel, IntPtr range_kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockBilateralExact")]
        internal static extern IntPtr pixBlockBilateralExact(HandleRef pixs, float spatial_stdev, float range_stdev);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeRangeKernel")]
        internal static extern IntPtr makeRangeKernel(float range_stdev);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearSampledPta")]
        internal static extern IntPtr pixBilinearSampledPta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearSampled")]
        internal static extern IntPtr pixBilinearSampled(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPta")]
        internal static extern IntPtr pixBilinearPta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinear")]
        internal static extern IntPtr pixBilinear(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaColor")]
        internal static extern IntPtr pixBilinearPtaColor(HandleRef pixs, IntPtr ptad, IntPtr ptas, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearColor")]
        internal static extern IntPtr pixBilinearColor(HandleRef pixs, IntPtr vc, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaGray")]
        internal static extern IntPtr pixBilinearPtaGray(HandleRef pixs, IntPtr ptad, IntPtr ptas, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearGray")]
        internal static extern IntPtr pixBilinearGray(HandleRef pixs, IntPtr vc, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaWithAlpha")]
        internal static extern IntPtr pixBilinearPtaWithAlpha(HandleRef pixs, IntPtr ptad, IntPtr ptas, IntPtr pixg, float fract, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getBilinearXformCoeffs")]
        internal static extern int getBilinearXformCoeffs(HandleRef ptas, IntPtr ptad, IntPtr pvc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bilinearXformSampledPt")]
        internal static extern int bilinearXformSampledPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bilinearXformPt")]
        internal static extern int bilinearXformPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOtsuAdaptiveThreshold")]
        internal static extern int pixOtsuAdaptiveThreshold(HandleRef pixs, int sx, int sy, int smoothx, int smoothy, float scorefract, out IntPtr ppixth, out IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOtsuThreshOnBackgroundNorm")]
        internal static extern IntPtr pixOtsuThreshOnBackgroundNorm(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, float scorefract, IntPtr pthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskedThreshOnBackgroundNorm")]
        internal static extern IntPtr pixMaskedThreshOnBackgroundNorm(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int smoothx, int smoothy, float scorefract, IntPtr pthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaBinarizeTiled")]
        internal static extern int pixSauvolaBinarizeTiled(HandleRef pixs, int whsize, float factor, int nx, int ny, out HandleRef ppixth, out HandleRef ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaBinarize")]
        internal static extern int pixSauvolaBinarize(HandleRef pixs, int whsize, float factor, int addborder, out HandleRef ppixm, out HandleRef ppixsd, out HandleRef ppixth, out HandleRef ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaGetThreshold")]
        internal static extern IntPtr pixSauvolaGetThreshold(HandleRef pixm, IntPtr pixms, float factor, IntPtr ppixsd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyLocalThreshold")]
        internal static extern IntPtr pixApplyLocalThreshold(HandleRef pixs, IntPtr pixth, int redfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdByConnComp")]
        internal static extern int pixThresholdByConnComp(HandleRef pixs, IntPtr pixm, int start, int end, int incr, float thresh48, float threshdiff, IntPtr pglobthresh, IntPtr ppixd, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandBinaryReplicate")]
        internal static extern IntPtr pixExpandBinaryReplicate(HandleRef pixs, int xfact, int yfact);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandBinaryPower2")]
        internal static extern IntPtr pixExpandBinaryPower2(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceBinary2")]
        internal static extern IntPtr pixReduceBinary2(HandleRef pixs, IntPtr intab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceRankBinaryCascade")]
        internal static extern IntPtr pixReduceRankBinaryCascade(HandleRef pixs, int level1, int level2, int level3, int level4);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceRankBinary2")]
        internal static extern IntPtr pixReduceRankBinary2(HandleRef pixs, int level, IntPtr intab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSubsampleTab2x")]
        internal static extern IntPtr makeSubsampleTab2x(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlend")]
        internal static extern IntPtr pixBlend(HandleRef pixs1, IntPtr pixs2, int x, int y, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendMask")]
        internal static extern IntPtr pixBlendMask(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGray")]
        internal static extern IntPtr pixBlendGray(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract, int type, int transparent, uint transpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGrayInverse")]
        internal static extern IntPtr pixBlendGrayInverse(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendColor")]
        internal static extern IntPtr pixBlendColor(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract, int transparent, uint transpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendColorByChannel")]
        internal static extern IntPtr pixBlendColorByChannel(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float rfract, float gfract, float bfract, int transparent, uint transpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGrayAdapt")]
        internal static extern IntPtr pixBlendGrayAdapt(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract, int shift);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFadeWithGray")]
        internal static extern IntPtr pixFadeWithGray(HandleRef pixs, IntPtr pixb, float factor, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendHardLight")]
        internal static extern IntPtr pixBlendHardLight(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int x, int y, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendCmap")]
        internal static extern int pixBlendCmap(HandleRef pixs, IntPtr pixb, int x, int y, int sindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendWithGrayMask")]
        internal static extern IntPtr pixBlendWithGrayMask(HandleRef pixs1, IntPtr pixs2, IntPtr pixg, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendBackgroundToColor")]
        internal static extern IntPtr pixBlendBackgroundToColor(HandleRef pixd, IntPtr pixs, IntPtr box, uint color, float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultiplyByColor")]
        internal static extern IntPtr pixMultiplyByColor(HandleRef pixd, IntPtr pixs, IntPtr box, uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAlphaBlendUniform")]
        internal static extern IntPtr pixAlphaBlendUniform(HandleRef pixs, uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddAlphaToBlend")]
        internal static extern IntPtr pixAddAlphaToBlend(HandleRef pixs, float fract, int invert);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAlphaOverWhite")]
        internal static extern IntPtr pixSetAlphaOverWhite(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfCreate")]
        internal static extern IntPtr bmfCreate([MarshalAs(UnmanagedType.AnsiBStr)] string dir, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfDestroy")]
        internal static extern void bmfDestroy(ref IntPtr pbmf);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetPix")]
        internal static extern IntPtr bmfGetPix(HandleRef bmf, char chr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetWidth")]
        internal static extern int bmfGetWidth(HandleRef bmf, char chr, IntPtr pw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetBaseline")]
        internal static extern int bmfGetBaseline(HandleRef bmf, char chr, IntPtr pbaseline);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetFont")]
        internal static extern IntPtr pixaGetFont(HandleRef dir, int fontsize, IntPtr pbl0, IntPtr pbl1, IntPtr pbl2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSaveFont")]
        internal static extern int pixaSaveFont(HandleRef indir, IntPtr outdir, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamBmp")]
        internal static extern IntPtr pixReadStreamBmp(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamBmp")]
        internal static extern int pixWriteStreamBmp(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemBmp")]
        internal static extern IntPtr pixReadMemBmp(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemBmp")]
        internal static extern int pixWriteMemBmp(HandleRef pdata, IntPtr psize, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen1")]
        internal static extern IntPtr l_bootnum_gen1(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen2")]
        internal static extern IntPtr l_bootnum_gen2(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen3")]
        internal static extern IntPtr l_bootnum_gen3(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCopy")]
        internal static extern IntPtr boxCopy(ref Box box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClone")]
        internal static extern IntPtr boxClone(ref Box box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetGeometry")]
        internal static extern int boxGetGeometry(Box box, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSetGeometry")]
        internal static extern int boxSetGeometry(Box box, int x, int y, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetSideLocations")]
        internal static extern int boxGetSideLocations(Box box, IntPtr pl, IntPtr pr, IntPtr pt, IntPtr pb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSetSideLocations")]
        internal static extern int boxSetSideLocations(Box box, int l, int r, int t, int b);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetRefcount")]
        internal static extern int boxGetRefcount(Box box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxChangeRefcount")]
        internal static extern int boxChangeRefcount(Box box, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIsValid")]
        internal static extern int boxIsValid(Box box, IntPtr pvalid);





        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetValidCount")]
        internal static extern int boxaGetValidCount(HandleRef boxa);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetValidBox")]
        internal static extern IntPtr boxaGetValidBox(HandleRef boxa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaFindInvalidBoxes")]
        internal static extern IntPtr boxaFindInvalidBoxes(HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetBoxGeometry")]
        internal static extern int boxaGetBoxGeometry(HandleRef boxa, int index, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaIsFull")]
        internal static extern int boxaIsFull(HandleRef boxa, IntPtr pfull);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRemoveBoxAndSave")]
        internal static extern int boxaRemoveBoxAndSave(HandleRef boxa, int index, IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSaveValid")]
        internal static extern IntPtr boxaSaveValid(HandleRef boxas, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaInitFull")]
        internal static extern int boxaInitFull(HandleRef boxa, IntPtr box);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaCreate")]
        internal static extern IntPtr boxaaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaCopy")]
        internal static extern IntPtr boxaaCopy(HandleRef baas, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaDestroy")]
        internal static extern void boxaaDestroy(HandleRef pbaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAddBoxa")]
        internal static extern int boxaaAddBoxa(HandleRef baa, HandleRef ba, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendArray")]
        internal static extern int boxaaExtendArray(HandleRef baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendArrayToSize")]
        internal static extern int boxaaExtendArrayToSize(HandleRef baa, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetCount")]
        internal static extern int boxaaGetCount(HandleRef baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBoxCount")]
        internal static extern int boxaaGetBoxCount(HandleRef baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBoxa")]
        internal static extern IntPtr boxaaGetBoxa(HandleRef baa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBox")]
        internal static extern IntPtr boxaaGetBox(HandleRef baa, int iboxa, int ibox, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaInitFull")]
        internal static extern int boxaaInitFull(HandleRef baa, HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendWithInit")]
        internal static extern int boxaaExtendWithInit(HandleRef baa, int maxindex, HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReplaceBoxa")]
        internal static extern int boxaaReplaceBoxa(HandleRef baa, int index, HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaInsertBoxa")]
        internal static extern int boxaaInsertBoxa(HandleRef baa, int index, HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaRemoveBoxa")]
        internal static extern int boxaaRemoveBoxa(HandleRef baa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAddBox")]
        internal static extern int boxaaAddBox(HandleRef baa, int index, Box box, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadFromFiles")]
        internal static extern IntPtr boxaaReadFromFiles(HandleRef dirname, IntPtr substr, int first, int nfiles);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaRead")]
        internal static extern IntPtr boxaaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadStream")]
        internal static extern IntPtr boxaaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadMem")]
        internal static extern IntPtr boxaaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWrite")]
        internal static extern int boxaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWriteStream")]
        internal static extern int boxaaWriteStream(HandleRef fp, IntPtr baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWriteMem")]
        internal static extern int boxaaWriteMem(HandleRef pdata, IntPtr psize, IntPtr baa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRead")]
        internal static extern IntPtr boxaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReadStream")]
        internal static extern IntPtr boxaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReadMem")]
        internal static extern IntPtr boxaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWrite")]
        internal static extern int boxaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWriteStream")]
        internal static extern int boxaWriteStream(HandleRef fp, IntPtr boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWriteMem")]
        internal static extern int boxaWriteMem(HandleRef pdata, IntPtr psize, IntPtr boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxPrintStreamInfo")]
        internal static extern int boxPrintStreamInfo(HandleRef fp, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxContains")]
        internal static extern int boxContains(HandleRef box1, IntPtr box2, IntPtr presult);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIntersects")]
        internal static extern int boxIntersects(HandleRef box1, IntPtr box2, IntPtr presult);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaContainedInBox")]
        internal static extern IntPtr boxaContainedInBox(HandleRef boxas, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaIntersectsBox")]
        internal static extern IntPtr boxaIntersectsBox(HandleRef boxas, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaClipToBox")]
        internal static extern IntPtr boxaClipToBox(HandleRef boxas, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCombineOverlaps")]
        internal static extern IntPtr boxaCombineOverlaps(HandleRef boxas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapRegion")]
        internal static extern IntPtr boxOverlapRegion(HandleRef box1, IntPtr box2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxBoundingRegion")]
        internal static extern IntPtr boxBoundingRegion(HandleRef box1, IntPtr box2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapFraction")]
        internal static extern int boxOverlapFraction(HandleRef box1, IntPtr box2, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapArea")]
        internal static extern int boxOverlapArea(HandleRef box1, IntPtr box2, IntPtr parea);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaHandleOverlaps")]
        internal static extern IntPtr boxaHandleOverlaps(HandleRef boxas, int op, int range, float min_overlap, float max_ratio, IntPtr pnamap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSeparationDistance")]
        internal static extern int boxSeparationDistance(HandleRef box1, IntPtr box2, IntPtr ph_sep, IntPtr pv_sep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxContainsPt")]
        internal static extern int boxContainsPt(HandleRef box, float x, float y, IntPtr pcontains);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetNearestToPt")]
        internal static extern IntPtr boxaGetNearestToPt(HandleRef boxa, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetCenter")]
        internal static extern int boxGetCenter(HandleRef box, IntPtr pcx, IntPtr pcy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIntersectByLine")]
        internal static extern int boxIntersectByLine(HandleRef box, int x, int y, float slope, IntPtr px1, IntPtr py1, IntPtr px2, IntPtr py2, IntPtr pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClipToRectangle")]
        internal static extern IntPtr boxClipToRectangle(HandleRef box, int wi, int hi);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClipToRectangleParams")]
        internal static extern int boxClipToRectangleParams(HandleRef box, int w, int h, IntPtr pxstart, IntPtr pystart, IntPtr pxend, IntPtr pyend, IntPtr pbw, IntPtr pbh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxRelocateOneSide")]
        internal static extern IntPtr boxRelocateOneSide(HandleRef boxd, IntPtr boxs, int loc, int sideflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxAdjustSides")]
        internal static extern IntPtr boxAdjustSides(HandleRef boxd, IntPtr boxs, int delleft, int delright, int deltop, int delbot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSetSide")]
        internal static extern IntPtr boxaSetSide(HandleRef boxad, IntPtr boxas, int side, int val, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAdjustWidthToTarget")]
        internal static extern IntPtr boxaAdjustWidthToTarget(HandleRef boxad, IntPtr boxas, int sides, int target, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAdjustHeightToTarget")]
        internal static extern IntPtr boxaAdjustHeightToTarget(HandleRef boxad, IntPtr boxas, int sides, int target, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxEqual")]
        internal static extern int boxEqual(HandleRef box1, IntPtr box2, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaEqual")]
        internal static extern int boxaEqual(HandleRef boxa1, IntPtr boxa2, int maxdist, IntPtr pnaindex, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSimilar")]
        internal static extern int boxSimilar(HandleRef box1, IntPtr box2, int leftdiff, int rightdiff, int topdiff, int botdiff, IntPtr psimilar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSimilar")]
        internal static extern int boxaSimilar(HandleRef boxa1, IntPtr boxa2, int leftdiff, int rightdiff, int topdiff, int botdiff, int debug, IntPtr psimilar, IntPtr pnasim);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaJoin")]
        internal static extern int boxaJoin(HandleRef boxad, IntPtr boxas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaJoin")]
        internal static extern int boxaaJoin(HandleRef baad, IntPtr baas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSplitEvenOdd")]
        internal static extern int boxaSplitEvenOdd(HandleRef boxa, int fillflag, IntPtr pboxae, IntPtr pboxao);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMergeEvenOdd")]
        internal static extern IntPtr boxaMergeEvenOdd(HandleRef boxae, IntPtr boxao, int fillflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTransform")]
        internal static extern IntPtr boxaTransform(HandleRef boxas, int shiftx, int shifty, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxTransform")]
        internal static extern IntPtr boxTransform(HandleRef box, int shiftx, int shifty, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTransformOrdered")]
        internal static extern IntPtr boxaTransformOrdered(HandleRef boxas, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxTransformOrdered")]
        internal static extern IntPtr boxTransformOrdered(HandleRef boxs, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRotateOrth")]
        internal static extern IntPtr boxaRotateOrth(HandleRef boxas, int w, int h, int rotation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxRotateOrth")]
        internal static extern IntPtr boxRotateOrth(HandleRef box, int w, int h, int rotation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort")]
        internal static extern IntPtr boxaSort(HandleRef boxas, int sorttype, int sortorder, IntPtr pnaindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaBinSort")]
        internal static extern IntPtr boxaBinSort(HandleRef boxas, int sorttype, int sortorder, IntPtr pnaindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSortByIndex")]
        internal static extern IntPtr boxaSortByIndex(HandleRef boxas, IntPtr naindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort2d")]
        internal static extern IntPtr boxaSort2d(HandleRef boxas, IntPtr pnaad, int delta1, int delta2, int minh1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort2dByIndex")]
        internal static extern IntPtr boxaSort2dByIndex(HandleRef boxas, IntPtr naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractAsNuma")]
        internal static extern int boxaExtractAsNuma(HandleRef boxa, IntPtr pnal, IntPtr pnat, IntPtr pnar, IntPtr pnab, IntPtr pnaw, IntPtr pnah, int keepinvalid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractAsPta")]
        internal static extern int boxaExtractAsPta(HandleRef boxa, IntPtr pptal, IntPtr pptat, IntPtr pptar, IntPtr pptab, IntPtr pptaw, IntPtr pptah, int keepinvalid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetRankVals")]
        internal static extern int boxaGetRankVals(HandleRef boxa, float fract, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetMedianVals")]
        internal static extern int boxaGetMedianVals(HandleRef boxa, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetAverageSize")]
        internal static extern int boxaGetAverageSize(HandleRef boxa, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetExtent")]
        internal static extern int boxaaGetExtent(HandleRef baa, IntPtr pw, IntPtr ph, IntPtr pbox, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaFlattenToBoxa")]
        internal static extern IntPtr boxaaFlattenToBoxa(HandleRef baa, IntPtr pnaindex, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaFlattenAligned")]
        internal static extern IntPtr boxaaFlattenAligned(HandleRef baa, int num, IntPtr fillerbox, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaEncapsulateAligned")]
        internal static extern IntPtr boxaEncapsulateAligned(HandleRef boxa, int num, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaTranspose")]
        internal static extern IntPtr boxaaTranspose(HandleRef baas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAlignBox")]
        internal static extern int boxaaAlignBox(HandleRef baa, IntPtr box, int delta, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskConnComp")]
        internal static extern IntPtr pixMaskConnComp(HandleRef pixs, int connectivity, IntPtr pboxa);





        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBlackOrWhiteBoxa")]
        internal static extern IntPtr pixSetBlackOrWhiteBoxa(HandleRef pixs, IntPtr boxa, int op);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendBoxaRandom")]
        internal static extern IntPtr pixBlendBoxaRandom(HandleRef pixs, IntPtr boxa, float fract);





        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaDisplay")]
        internal static extern IntPtr boxaaDisplay(HandleRef baa, int linewba, int linewb, uint colorba, uint colorb, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayBoxaa")]
        internal static extern IntPtr pixaDisplayBoxaa(Pix pixas, IntPtr baa, int colorflag, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitIntoBoxa")]
        internal static extern IntPtr pixSplitIntoBoxa(HandleRef pixs, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitComponentIntoBoxa")]
        internal static extern IntPtr pixSplitComponentIntoBoxa(HandleRef pix, IntPtr box, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMosaicStrips")]
        internal static extern IntPtr makeMosaicStrips(int w, int h, int direction, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCompareRegions")]
        internal static extern int boxaCompareRegions(HandleRef boxa1, IntPtr boxa2, int areathresh, IntPtr pnsame, IntPtr pdiffarea, IntPtr pdiffxor, IntPtr ppixdb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectLargeULComp")]
        internal static extern IntPtr pixSelectLargeULComp(HandleRef pixs, float areaslop, int yslop, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectLargeULBox")]
        internal static extern IntPtr boxaSelectLargeULBox(HandleRef boxas, float areaslop, int yslop);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectRange")]
        internal static extern IntPtr boxaSelectRange(HandleRef boxas, int first, int last, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaSelectRange")]
        internal static extern IntPtr boxaaSelectRange(HandleRef baas, int first, int last, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectBySize")]
        internal static extern IntPtr boxaSelectBySize(HandleRef boxas, int width, int height, int type, int relation, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeSizeIndicator")]
        internal static extern IntPtr boxaMakeSizeIndicator(HandleRef boxa, int width, int height, int type, int relation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectByArea")]
        internal static extern IntPtr boxaSelectByArea(HandleRef boxas, int area, int relation, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeAreaIndicator")]
        internal static extern IntPtr boxaMakeAreaIndicator(HandleRef boxa, int area, int relation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectByWHRatio")]
        internal static extern IntPtr boxaSelectByWHRatio(HandleRef boxas, float ratio, int relation, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeWHRatioIndicator")]
        internal static extern IntPtr boxaMakeWHRatioIndicator(HandleRef boxa, float ratio, int relation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectWithIndicator")]
        internal static extern IntPtr boxaSelectWithIndicator(HandleRef boxas, IntPtr na, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPermutePseudorandom")]
        internal static extern IntPtr boxaPermutePseudorandom(HandleRef boxas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPermuteRandom")]
        internal static extern IntPtr boxaPermuteRandom(HandleRef boxad, IntPtr boxas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSwapBoxes")]
        internal static extern int boxaSwapBoxes(HandleRef boxa, int i, int j);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaConvertToPta")]
        internal static extern IntPtr boxaConvertToPta(HandleRef boxa, int ncorners);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaConvertToBoxa")]
        internal static extern IntPtr ptaConvertToBoxa(HandleRef pta, int ncorners);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxConvertToPta")]
        internal static extern IntPtr boxConvertToPta(HandleRef box, int ncorners);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaConvertToBox")]
        internal static extern IntPtr ptaConvertToBox(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSmoothSequenceLS")]
        internal static extern IntPtr boxaSmoothSequenceLS(HandleRef boxas, float factor, int subflag, int maxdiff, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSmoothSequenceMedian")]
        internal static extern IntPtr boxaSmoothSequenceMedian(HandleRef boxas, int halfwin, int subflag, int maxdiff, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaLinearFit")]
        internal static extern IntPtr boxaLinearFit(HandleRef boxas, float factor, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWindowedMedian")]
        internal static extern IntPtr boxaWindowedMedian(HandleRef boxas, int halfwin, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaModifyWithBoxa")]
        internal static extern IntPtr boxaModifyWithBoxa(HandleRef boxas, IntPtr boxam, int subflag, int maxdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaConstrainSize")]
        internal static extern IntPtr boxaConstrainSize(HandleRef boxas, int width, int widthflag, int height, int heightflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReconcileEvenOddHeight")]
        internal static extern IntPtr boxaReconcileEvenOddHeight(HandleRef boxas, int sides, int delh, int op, float factor, int start);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReconcilePairWidth")]
        internal static extern IntPtr boxaReconcilePairWidth(HandleRef boxas, int delw, int op, float factor, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPlotSides")]
        internal static extern int boxaPlotSides(HandleRef boxa, IntPtr plotname, IntPtr pnal, IntPtr pnat, IntPtr pnar, IntPtr pnab, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPlotSizes")]
        internal static extern int boxaPlotSizes(HandleRef boxa, IntPtr plotname, IntPtr pnaw, IntPtr pnah, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaFillSequence")]
        internal static extern IntPtr boxaFillSequence(HandleRef boxas, int useflag, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetExtent")]
        internal static extern int boxaGetExtent(HandleRef boxa, IntPtr pw, IntPtr ph, IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetCoverage")]
        internal static extern int boxaGetCoverage(HandleRef boxa, int wc, int hc, int exactflag, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaSizeRange")]
        internal static extern int boxaaSizeRange(HandleRef baa, IntPtr pminw, IntPtr pminh, IntPtr pmaxw, IntPtr pmaxh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSizeRange")]
        internal static extern int boxaSizeRange(HandleRef boxa, IntPtr pminw, IntPtr pminh, IntPtr pmaxw, IntPtr pmaxh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaLocationRange")]
        internal static extern int boxaLocationRange(HandleRef boxa, IntPtr pminx, IntPtr pminy, IntPtr pmaxx, IntPtr pmaxy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetSizes")]
        internal static extern int boxaGetSizes(HandleRef boxa, IntPtr pnaw, IntPtr pnah);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetArea")]
        internal static extern int boxaGetArea(HandleRef boxa, IntPtr parea);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaDisplayTiled")]
        internal static extern IntPtr boxaDisplayTiled(HandleRef boxas, IntPtr pixa, int maxwidth, int linewidth, float scalefactor, int background, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCreate")]
        internal static extern IntPtr l_byteaCreate(HandleRef nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromMem")]
        internal static extern IntPtr l_byteaInitFromMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromFile")]
        internal static extern IntPtr l_byteaInitFromFile(HandleRef fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromStream")]
        internal static extern IntPtr l_byteaInitFromStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCopy")]
        internal static extern IntPtr l_byteaCopy(HandleRef bas, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaDestroy")]
        internal static extern void l_byteaDestroy(HandleRef pba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaGetSize")]
        internal static extern IntPtr l_byteaGetSize(HandleRef ba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaGetData")]
        internal static extern IntPtr l_byteaGetData(HandleRef ba, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCopyData")]
        internal static extern IntPtr l_byteaCopyData(HandleRef ba, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaAppendData")]
        internal static extern int l_byteaAppendData(HandleRef ba, IntPtr newdata, IntPtr newbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaAppendString")]
        internal static extern int l_byteaAppendString(HandleRef ba, IntPtr str);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaJoin")]
        internal static extern int l_byteaJoin(HandleRef ba1, IntPtr pba2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaSplit")]
        internal static extern int l_byteaSplit(HandleRef ba1, IntPtr splitloc, IntPtr pba2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaFindEachSequence")]
        internal static extern int l_byteaFindEachSequence(HandleRef ba, IntPtr sequence, int seqlen, IntPtr pda);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaWrite")]
        internal static extern int l_byteaWrite(HandleRef fname, IntPtr ba, IntPtr startloc, IntPtr endloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaWriteStream")]
        internal static extern int l_byteaWriteStream(HandleRef fp, IntPtr ba, IntPtr startloc, IntPtr endloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaCreate")]
        internal static extern IntPtr ccbaCreate(HandleRef pixs, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDestroy")]
        internal static extern void ccbaDestroy(HandleRef pccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbCreate")]
        internal static extern IntPtr ccbCreate(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbDestroy")]
        internal static extern void ccbDestroy(HandleRef pccb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaAddCcb")]
        internal static extern int ccbaAddCcb(HandleRef ccba, IntPtr ccb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGetCount")]
        internal static extern int ccbaGetCount(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGetCcb")]
        internal static extern IntPtr ccbaGetCcb(HandleRef ccba, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAllCCBorders")]
        internal static extern IntPtr pixGetAllCCBorders(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCCBorders")]
        internal static extern IntPtr pixGetCCBorders(HandleRef pixs, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBordersPtaa")]
        internal static extern IntPtr pixGetOuterBordersPtaa(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBorderPta")]
        internal static extern IntPtr pixGetOuterBorderPta(HandleRef pixs, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBorder")]
        internal static extern int pixGetOuterBorder(HandleRef ccb, IntPtr pixs, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetHoleBorder")]
        internal static extern int pixGetHoleBorder(HandleRef ccb, IntPtr pixs, IntPtr box, int xs, int ys);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findNextBorderPixel")]
        internal static extern int findNextBorderPixel(int w, int h, IntPtr data, int wpl, int px, int py, IntPtr pqpos, IntPtr pnpx, IntPtr pnpy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "locateOutsideSeedPixel")]
        internal static extern void locateOutsideSeedPixel(int fpx, int fpy, int spx, int spy, IntPtr pxs, IntPtr pys);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateGlobalLocs")]
        internal static extern int ccbaGenerateGlobalLocs(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateStepChains")]
        internal static extern int ccbaGenerateStepChains(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaStepChainsToPixCoords")]
        internal static extern int ccbaStepChainsToPixCoords(HandleRef ccba, int coordtype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateSPGlobalLocs")]
        internal static extern int ccbaGenerateSPGlobalLocs(HandleRef ccba, int ptsflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateSinglePath")]
        internal static extern int ccbaGenerateSinglePath(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getCutPathForHole")]
        internal static extern IntPtr getCutPathForHole(HandleRef pix, IntPtr pta, IntPtr boxinner, IntPtr pdir, IntPtr plen);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayBorder")]
        internal static extern IntPtr ccbaDisplayBorder(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplaySPBorder")]
        internal static extern IntPtr ccbaDisplaySPBorder(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayImage1")]
        internal static extern IntPtr ccbaDisplayImage1(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayImage2")]
        internal static extern IntPtr ccbaDisplayImage2(HandleRef ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWrite")]
        internal static extern int ccbaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteStream")]
        internal static extern int ccbaWriteStream(HandleRef fp, IntPtr ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaRead")]
        internal static extern IntPtr ccbaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaReadStream")]
        internal static extern IntPtr ccbaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteSVG")]
        internal static extern int ccbaWriteSVG([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteSVGString")]
        internal static extern IntPtr ccbaWriteSVGString([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr ccba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaThinConnected")]
        internal static extern IntPtr pixaThinConnected(HandleRef pixas, int type, int connectivity, int maxiters);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThinConnected")]
        internal static extern IntPtr pixThinConnected(HandleRef pixs, int type, int connectivity, int maxiters);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThinConnectedBySet")]
        internal static extern IntPtr pixThinConnectedBySet(HandleRef pixs, int type, IntPtr sela, int maxiters);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaMakeThinSets")]
        internal static extern IntPtr selaMakeThinSets(int index, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelation")]
        internal static extern int jbCorrelation(HandleRef dirin, float thresh, float weight, int components, IntPtr rootname, int firstpage, int npages, int renderflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbRankHaus")]
        internal static extern int jbRankHaus(HandleRef dirin, int size, float rank, int components, IntPtr rootname, int firstpage, int npages, int renderflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbWordsInTextlines")]
        internal static extern IntPtr jbWordsInTextlines(HandleRef dirin, int reduction, int maxwidth, int maxheight, float thresh, float weight, IntPtr pnatl, int firstpage, int npages);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWordsInTextlines")]
        internal static extern int pixGetWordsInTextlines(HandleRef pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, IntPtr pboxad, IntPtr ppixad, IntPtr pnai);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWordBoxesInTextlines")]
        internal static extern int pixGetWordBoxesInTextlines(HandleRef pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, IntPtr pboxad, IntPtr pnai);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractSortedPattern")]
        internal static extern IntPtr boxaExtractSortedPattern(HandleRef boxa, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCompareImagesByBoxes")]
        internal static extern int numaaCompareImagesByBoxes(HandleRef naa1, IntPtr naa2, int nperline, int nreq, int maxshiftx, int maxshifty, int delx, int dely, IntPtr psame, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorContent")]
        internal static extern int pixColorContent(HandleRef pixs, int rwhite, int gwhite, int bwhite, int mingray, IntPtr ppixr, IntPtr ppixg, IntPtr ppixb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMagnitude")]
        internal static extern IntPtr pixColorMagnitude(HandleRef pixs, int rwhite, int gwhite, int bwhite, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskOverColorPixels")]
        internal static extern IntPtr pixMaskOverColorPixels(HandleRef pixs, int threshdiff, int mindist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskOverColorRange")]
        internal static extern IntPtr pixMaskOverColorRange(HandleRef pixs, int rmin, int rmax, int gmin, int gmax, int bmin, int bmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorFraction")]
        internal static extern int pixColorFraction(HandleRef pixs, int darkthresh, int lightthresh, int diffthresh, int factor, IntPtr ppixfract, IntPtr pcolorfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumSignificantGrayColors")]
        internal static extern int pixNumSignificantGrayColors(HandleRef pixs, int darkthresh, int lightthresh, float minfract, int factor, IntPtr pncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorsForQuantization")]
        internal static extern int pixColorsForQuantization(HandleRef pixs, int thresh, IntPtr pncolors, IntPtr piscolor, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumColors")]
        internal static extern int pixNumColors(HandleRef pixs, int factor, IntPtr pncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMostPopulatedColors")]
        internal static extern int pixGetMostPopulatedColors(HandleRef pixs, int sigbits, int factor, int ncolors, IntPtr parray, IntPtr pcmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSimpleColorQuantize")]
        internal static extern IntPtr pixSimpleColorQuantize(HandleRef pixs, int sigbits, int factor, int ncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBHistogram")]
        internal static extern IntPtr pixGetRGBHistogram(HandleRef pixs, int sigbits, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeRGBIndexTables")]
        internal static extern int makeRGBIndexTables(HandleRef prtab, IntPtr pgtab, IntPtr pbtab, int sigbits);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getRGBFromIndex")]
        internal static extern int getRGBFromIndex(uint index, int sigbits, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHasHighlightRed")]
        internal static extern int pixHasHighlightRed(HandleRef pixs, int factor, float fract, float fthresh, IntPtr phasred, IntPtr pratio, IntPtr ppixdb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayRegions")]
        internal static extern IntPtr pixColorGrayRegions(HandleRef pixs, IntPtr boxa, int type, int thresh, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGray")]
        internal static extern int pixColorGray(HandleRef pixs, IntPtr box, int type, int thresh, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayMasked")]
        internal static extern IntPtr pixColorGrayMasked(HandleRef pixs, IntPtr pixm, int type, int thresh, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSnapColor")]
        internal static extern IntPtr pixSnapColor(HandleRef pixd, IntPtr pixs, uint srcval, uint dstval, int diff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSnapColorCmap")]
        internal static extern IntPtr pixSnapColorCmap(HandleRef pixd, IntPtr pixs, uint srcval, uint dstval, int diff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLinearMapToTargetColor")]
        internal static extern IntPtr pixLinearMapToTargetColor(HandleRef pixd, IntPtr pixs, uint srcval, uint dstval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelLinearMapToTargetColor")]
        internal static extern int pixelLinearMapToTargetColor(uint scolor, uint srcmap, uint dstmap, IntPtr pdcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixShiftByComponent")]
        internal static extern IntPtr pixShiftByComponent(HandleRef pixd, IntPtr pixs, uint srcval, uint dstval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelShiftByComponent")]
        internal static extern int pixelShiftByComponent(int rval, int gval, int bval, uint srcval, uint dstval, IntPtr ppixel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelFractionalShift")]
        internal static extern int pixelFractionalShift(int rval, int gval, int bval, float fraction, IntPtr ppixel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapDestroy")]
        internal static extern void pixcmapDestroy(HandleRef pcmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddColor")]
        internal static extern int pixcmapAddColor(HandleRef cmap, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddRGBA")]
        internal static extern int pixcmapAddRGBA(HandleRef cmap, int rval, int gval, int bval, int aval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddNewColor")]
        internal static extern int pixcmapAddNewColor(HandleRef cmap, int rval, int gval, int bval, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddNearestColor")]
        internal static extern int pixcmapAddNearestColor(HandleRef cmap, int rval, int gval, int bval, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapUsableColor")]
        internal static extern int pixcmapUsableColor(HandleRef cmap, int rval, int gval, int bval, IntPtr pusable);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddBlackOrWhite")]
        internal static extern int pixcmapAddBlackOrWhite(HandleRef cmap, int color, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSetBlackAndWhite")]
        internal static extern int pixcmapSetBlackAndWhite(HandleRef cmap, int setblack, int setwhite);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetFreeCount")]
        internal static extern int pixcmapGetFreeCount(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetMinDepth")]
        internal static extern int pixcmapGetMinDepth(HandleRef cmap, IntPtr pmindepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapClear")]
        internal static extern int pixcmapClear(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetColor")]
        internal static extern int pixcmapGetColor(HandleRef cmap, int index, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetColor32")]
        internal static extern int pixcmapGetColor32(HandleRef cmap, int index, IntPtr pval32);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRGBA")]
        internal static extern int pixcmapGetRGBA(HandleRef cmap, int index, IntPtr prval, IntPtr pgval, IntPtr pbval, IntPtr paval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRGBA32")]
        internal static extern int pixcmapGetRGBA32(HandleRef cmap, int index, IntPtr pval32);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapResetColor")]
        internal static extern int pixcmapResetColor(HandleRef cmap, int index, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSetAlpha")]
        internal static extern int pixcmapSetAlpha(HandleRef cmap, int index, int aval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetIndex")]
        internal static extern int pixcmapGetIndex(HandleRef cmap, int rval, int gval, int bval, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapHasColor")]
        internal static extern int pixcmapHasColor(HandleRef cmap, IntPtr pcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapIsOpaque")]
        internal static extern int pixcmapIsOpaque(HandleRef cmap, IntPtr popaque);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapIsBlackAndWhite")]
        internal static extern int pixcmapIsBlackAndWhite(HandleRef cmap, IntPtr pblackwhite);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCountGrayColors")]
        internal static extern int pixcmapCountGrayColors(HandleRef cmap, IntPtr pngray);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRankIntensity")]
        internal static extern int pixcmapGetRankIntensity(HandleRef cmap, float rankval, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetNearestIndex")]
        internal static extern int pixcmapGetNearestIndex(HandleRef cmap, int rval, int gval, int bval, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetNearestGrayIndex")]
        internal static extern int pixcmapGetNearestGrayIndex(HandleRef cmap, int val, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetDistanceToColor")]
        internal static extern int pixcmapGetDistanceToColor(HandleRef cmap, int index, int rval, int gval, int bval, IntPtr pdist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRangeValues")]
        internal static extern int pixcmapGetRangeValues(HandleRef cmap, int select, IntPtr pminval, IntPtr pmaxval, IntPtr pminindex, IntPtr pmaxindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGrayToColor")]
        internal static extern IntPtr pixcmapGrayToColor(uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapColorToGray")]
        internal static extern IntPtr pixcmapColorToGray(HandleRef cmaps, float rwt, float gwt, float bwt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapRead")]
        internal static extern IntPtr pixcmapRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapReadStream")]
        internal static extern IntPtr pixcmapReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapReadMem")]
        internal static extern IntPtr pixcmapReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWrite")]
        internal static extern int pixcmapWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWriteStream")]
        internal static extern int pixcmapWriteStream(HandleRef fp, IntPtr cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWriteMem")]
        internal static extern int pixcmapWriteMem(HandleRef pdata, IntPtr psize, IntPtr cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToArrays")]
        internal static extern int pixcmapToArrays(HandleRef cmap, IntPtr prmap, IntPtr pgmap, IntPtr pbmap, IntPtr pamap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToRGBTable")]
        internal static extern int pixcmapToRGBTable(HandleRef cmap, IntPtr ptab, IntPtr pncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSerializeToMemory")]
        internal static extern int pixcmapSerializeToMemory(HandleRef cmap, int cpc, IntPtr pncolors, IntPtr pdata);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapDeserializeFromMemory")]
        internal static extern IntPtr pixcmapDeserializeFromMemory(HandleRef data, int cpc, int ncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertToHex")]
        internal static extern IntPtr pixcmapConvertToHex(HandleRef data, int ncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGammaTRC")]
        internal static extern int pixcmapGammaTRC(HandleRef cmap, float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapContrastTRC")]
        internal static extern int pixcmapContrastTRC(HandleRef cmap, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapShiftIntensity")]
        internal static extern int pixcmapShiftIntensity(HandleRef cmap, float fraction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapShiftByComponent")]
        internal static extern int pixcmapShiftByComponent(HandleRef cmap, uint srcval, uint dstval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMorph")]
        internal static extern IntPtr pixColorMorph(HandleRef pixs, int type, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeColorQuant")]
        internal static extern IntPtr pixOctreeColorQuant(HandleRef pixs, int colors, int ditherflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeColorQuantGeneral")]
        internal static extern IntPtr pixOctreeColorQuantGeneral(HandleRef pixs, int colors, int ditherflag, float validthresh, float colorthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeRGBToIndexTables")]
        internal static extern int makeRGBToIndexTables(HandleRef prtab, IntPtr pgtab, IntPtr pbtab, int cqlevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getOctcubeIndexFromRGB")]
        internal static extern void getOctcubeIndexFromRGB(int rval, int gval, int bval, IntPtr rtab, IntPtr gtab, IntPtr btab, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeQuantByPopulation")]
        internal static extern IntPtr pixOctreeQuantByPopulation(HandleRef pixs, int level, int ditherflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeQuantNumColors")]
        internal static extern IntPtr pixOctreeQuantNumColors(HandleRef pixs, int maxcolors, int subsample);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeQuantMixedWithGray")]
        internal static extern IntPtr pixOctcubeQuantMixedWithGray(HandleRef pixs, int depth, int graylevels, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFixedOctcubeQuant256")]
        internal static extern IntPtr pixFixedOctcubeQuant256(HandleRef pixs, int ditherflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuant1")]
        internal static extern IntPtr pixFewColorsOctcubeQuant1(HandleRef pixs, int level);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuant2")]
        internal static extern IntPtr pixFewColorsOctcubeQuant2(HandleRef pixs, int level, IntPtr na, int ncolors, IntPtr pnerrors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuantMixed")]
        internal static extern IntPtr pixFewColorsOctcubeQuantMixed(HandleRef pixs, int level, int darkthresh, int lightthresh, int diffthresh, float minfract, int maxspan);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFixedOctcubeQuantGenRGB")]
        internal static extern IntPtr pixFixedOctcubeQuantGenRGB(HandleRef pixs, int level);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuantFromCmap")]
        internal static extern IntPtr pixQuantFromCmap(HandleRef pixs, IntPtr cmap, int mindepth, int level, int metric);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeQuantFromCmap")]
        internal static extern IntPtr pixOctcubeQuantFromCmap(HandleRef pixs, IntPtr cmap, int mindepth, int level, int metric);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeHistogram")]
        internal static extern IntPtr pixOctcubeHistogram(HandleRef pixs, int level, IntPtr pncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToOctcubeLUT")]
        internal static extern IntPtr pixcmapToOctcubeLUT(HandleRef cmap, int level, int metric);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveUnusedColors")]
        internal static extern int pixRemoveUnusedColors(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumberOccupiedOctcubes")]
        internal static extern int pixNumberOccupiedOctcubes(HandleRef pix, int level, int mincount, float minfract, IntPtr pncolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuant")]
        internal static extern IntPtr pixMedianCutQuant(HandleRef pixs, int ditherflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuantGeneral")]
        internal static extern IntPtr pixMedianCutQuantGeneral(HandleRef pixs, int ditherflag, int outdepth, int maxcolors, int sigbits, int maxsub, int checkbw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuantMixed")]
        internal static extern IntPtr pixMedianCutQuantMixed(HandleRef pixs, int ncolor, int ngray, int darkthresh, int lightthresh, int diffthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsMedianCutQuantMixed")]
        internal static extern IntPtr pixFewColorsMedianCutQuantMixed(HandleRef pixs, int ncolor, int ngray, int maxncolors, int darkthresh, int lightthresh, int diffthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutHisto")]
        internal static extern IntPtr pixMedianCutHisto(HandleRef pixs, int sigbits, int subsample);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegment")]
        internal static extern IntPtr pixColorSegment(HandleRef pixs, int maxdist, int maxcolors, int selsize, int finalcolors, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentCluster")]
        internal static extern IntPtr pixColorSegmentCluster(HandleRef pixs, int maxdist, int maxcolors, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAssignToNearestColor")]
        internal static extern int pixAssignToNearestColor(HandleRef pixd, IntPtr pixs, IntPtr pixm, int level, IntPtr countarray);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentClean")]
        internal static extern int pixColorSegmentClean(HandleRef pixs, int selsize, IntPtr countarray);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentRemoveColors")]
        internal static extern int pixColorSegmentRemoveColors(HandleRef pixd, IntPtr pixs, int finalcolors);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToHSV")]
        internal static extern IntPtr pixConvertRGBToHSV(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertHSVToRGB")]
        internal static extern IntPtr pixConvertHSVToRGB(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToHSV")]
        internal static extern int convertRGBToHSV(int rval, int gval, int bval, IntPtr phval, IntPtr psval, IntPtr pvval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertHSVToRGB")]
        internal static extern int convertHSVToRGB(int hval, int sval, int vval, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertRGBToHSV")]
        internal static extern int pixcmapConvertRGBToHSV(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertHSVToRGB")]
        internal static extern int pixcmapConvertHSVToRGB(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToHue")]
        internal static extern IntPtr pixConvertRGBToHue(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToSaturation")]
        internal static extern IntPtr pixConvertRGBToSaturation(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToValue")]
        internal static extern IntPtr pixConvertRGBToValue(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskHS")]
        internal static extern IntPtr pixMakeRangeMaskHS(HandleRef pixs, int huecenter, int huehw, int satcenter, int sathw, int regionflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskHV")]
        internal static extern IntPtr pixMakeRangeMaskHV(HandleRef pixs, int huecenter, int huehw, int valcenter, int valhw, int regionflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskSV")]
        internal static extern IntPtr pixMakeRangeMaskSV(HandleRef pixs, int satcenter, int sathw, int valcenter, int valhw, int regionflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoHS")]
        internal static extern IntPtr pixMakeHistoHS(HandleRef pixs, int factor, IntPtr pnahue, IntPtr pnasat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoHV")]
        internal static extern IntPtr pixMakeHistoHV(HandleRef pixs, int factor, IntPtr pnahue, IntPtr pnaval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoSV")]
        internal static extern IntPtr pixMakeHistoSV(HandleRef pixs, int factor, IntPtr pnasat, IntPtr pnaval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindHistoPeaksHSV")]
        internal static extern int pixFindHistoPeaksHSV(HandleRef pixs, int type, int width, int height, int npeaks, float erasefactor, IntPtr ppta, IntPtr pnatot, IntPtr ppixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "displayHSVColorRange")]
        internal static extern IntPtr displayHSVColorRange(int hval, int sval, int vval, int huehw, int sathw, int nsamp, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToYUV")]
        internal static extern IntPtr pixConvertRGBToYUV(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertYUVToRGB")]
        internal static extern IntPtr pixConvertYUVToRGB(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToYUV")]
        internal static extern int convertRGBToYUV(int rval, int gval, int bval, IntPtr pyval, IntPtr puval, IntPtr pvval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertYUVToRGB")]
        internal static extern int convertYUVToRGB(int yval, int uval, int vval, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertRGBToYUV")]
        internal static extern int pixcmapConvertRGBToYUV(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertYUVToRGB")]
        internal static extern int pixcmapConvertYUVToRGB(HandleRef cmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToXYZ")]
        internal static extern IntPtr pixConvertRGBToXYZ(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertXYZToRGB")]
        internal static extern IntPtr fpixaConvertXYZToRGB(HandleRef fpixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToXYZ")]
        internal static extern int convertRGBToXYZ(int rval, int gval, int bval, IntPtr pfxval, IntPtr pfyval, IntPtr pfzval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertXYZToRGB")]
        internal static extern int convertXYZToRGB(float fxval, float fyval, float fzval, int blackout, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertXYZToLAB")]
        internal static extern IntPtr fpixaConvertXYZToLAB(HandleRef fpixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertLABToXYZ")]
        internal static extern IntPtr fpixaConvertLABToXYZ(HandleRef fpixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertXYZToLAB")]
        internal static extern int convertXYZToLAB(float xval, float yval, float zval, IntPtr plval, IntPtr paval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertLABToXYZ")]
        internal static extern int convertLABToXYZ(float lval, float aval, float bval, IntPtr pxval, IntPtr pyval, IntPtr pzval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToLAB")]
        internal static extern IntPtr pixConvertRGBToLAB(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertLABToRGB")]
        internal static extern IntPtr fpixaConvertLABToRGB(HandleRef fpixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToLAB")]
        internal static extern int convertRGBToLAB(int rval, int gval, int bval, IntPtr pflval, IntPtr pfaval, IntPtr pfbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertLABToRGB")]
        internal static extern int convertLABToRGB(float flval, float faval, float fbval, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqual")]
        internal static extern int pixEqual(HandleRef pix1, IntPtr pix2, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualWithAlpha")]
        internal static extern int pixEqualWithAlpha(HandleRef pix1, IntPtr pix2, int use_alpha, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualWithCmap")]
        internal static extern int pixEqualWithCmap(HandleRef pix1, IntPtr pix2, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cmapEqual")]
        internal static extern int cmapEqual(HandleRef cmap1, IntPtr cmap2, int ncomps, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUsesCmapColor")]
        internal static extern int pixUsesCmapColor(HandleRef pixs, IntPtr pcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationBinary")]
        internal static extern int pixCorrelationBinary(HandleRef pix1, IntPtr pix2, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayDiffBinary")]
        internal static extern IntPtr pixDisplayDiffBinary(HandleRef pix1, IntPtr pix2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareBinary")]
        internal static extern int pixCompareBinary(HandleRef pix1, IntPtr pix2, int comptype, IntPtr pfract, IntPtr ppixdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGrayOrRGB")]
        internal static extern int pixCompareGrayOrRGB(HandleRef pix1, IntPtr pix2, int comptype, int plottype, IntPtr psame, IntPtr pdiff, IntPtr prmsdiff, IntPtr ppixdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGray")]
        internal static extern int pixCompareGray(HandleRef pix1, IntPtr pix2, int comptype, int plottype, IntPtr psame, IntPtr pdiff, IntPtr prmsdiff, IntPtr ppixdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareRGB")]
        internal static extern int pixCompareRGB(HandleRef pix1, IntPtr pix2, int comptype, int plottype, IntPtr psame, IntPtr pdiff, IntPtr prmsdiff, IntPtr ppixdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareTiled")]
        internal static extern int pixCompareTiled(HandleRef pix1, IntPtr pix2, int sx, int sy, int type, IntPtr ppixdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareRankDifference")]
        internal static extern IntPtr pixCompareRankDifference(HandleRef pix1, IntPtr pix2, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTestForSimilarity")]
        internal static extern int pixTestForSimilarity(HandleRef pix1, IntPtr pix2, int factor, int mindiff, float maxfract, float maxave, IntPtr psimilar, int printstats);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDifferenceStats")]
        internal static extern int pixGetDifferenceStats(HandleRef pix1, IntPtr pix2, int factor, int mindiff, IntPtr pfractdiff, IntPtr pavediff, int printstats);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDifferenceHistogram")]
        internal static extern IntPtr pixGetDifferenceHistogram(HandleRef pix1, IntPtr pix2, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPerceptualDiff")]
        internal static extern int pixGetPerceptualDiff(HandleRef pixs1, IntPtr pixs2, int sampling, int dilation, int mindiff, IntPtr pfract, IntPtr ppixdiff1, IntPtr ppixdiff2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPSNR")]
        internal static extern int pixGetPSNR(HandleRef pix1, IntPtr pix2, int factor, IntPtr ppsnr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaComparePhotoRegionsByHisto")]
        internal static extern int pixaComparePhotoRegionsByHisto(HandleRef pixa, float minratio, float textthresh, int factor, int nx, int ny, float simthresh, IntPtr pnai, IntPtr pscores, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixComparePhotoRegionsByHisto")]
        internal static extern int pixComparePhotoRegionsByHisto(HandleRef pix1, IntPtr pix2, IntPtr box1, IntPtr box2, float minratio, int factor, int nx, int ny, IntPtr pscore, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenPhotoHistos")]
        internal static extern int pixGenPhotoHistos(HandleRef pixs, IntPtr box, int factor, float thresh, int nx, int ny, IntPtr pnaa, IntPtr pw, IntPtr ph, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPadToCenterCentroid")]
        internal static extern IntPtr pixPadToCenterCentroid(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCentroid8")]
        internal static extern int pixCentroid8(HandleRef pixs, int factor, IntPtr pcx, IntPtr pcy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDecideIfPhotoImage")]
        internal static extern int pixDecideIfPhotoImage(HandleRef pix, int factor, int nx, int ny, float thresh, IntPtr pnaa, IntPtr pixadebug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "compareTilesByHisto")]
        internal static extern int compareTilesByHisto(HandleRef naa1, IntPtr naa2, float minratio, int w1, int h1, int w2, int h2, IntPtr pscore, IntPtr pixadebug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGrayByHisto")]
        internal static extern int pixCompareGrayByHisto(HandleRef pix1, IntPtr pix2, IntPtr box1, IntPtr box2, float minratio, int maxgray, int factor, int nx, int ny, IntPtr pscore, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropAlignedToCentroid")]
        internal static extern int pixCropAlignedToCentroid(HandleRef pix1, IntPtr pix2, int factor, IntPtr pbox1, IntPtr pbox2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_compressGrayHistograms")]
        internal static extern IntPtr l_compressGrayHistograms(HandleRef naa, int w, int h, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_uncompressGrayHistograms")]
        internal static extern IntPtr l_uncompressGrayHistograms(HandleRef bytea, IntPtr size, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareWithTranslation")]
        internal static extern int pixCompareWithTranslation(HandleRef pix1, IntPtr pix2, int thresh, IntPtr pdelx, IntPtr pdely, IntPtr pscore, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBestCorrelation")]
        internal static extern int pixBestCorrelation(HandleRef pix1, IntPtr pix2, int area1, int area2, int etransx, int etransy, int maxshift, IntPtr tab8, IntPtr pdelx, IntPtr pdely, IntPtr pscore, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnComp")]
        internal static extern IntPtr pixConnComp(HandleRef pixs, IntPtr ppixa, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompPixa")]
        internal static extern IntPtr pixConnCompPixa(HandleRef pixs, IntPtr ppixa, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompBB")]
        internal static extern IntPtr pixConnCompBB(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountConnComp")]
        internal static extern int pixCountConnComp(HandleRef pixs, int connectivity, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nextOnPixelInRaster")]
        internal static extern int nextOnPixelInRaster(HandleRef pixs, int xstart, int ystart, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nextOnPixelInRasterLow")]
        internal static extern int nextOnPixelInRasterLow(HandleRef data, int w, int h, int wpl, int xstart, int ystart, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBB")]
        internal static extern IntPtr pixSeedfillBB(HandleRef pixs, IntPtr stack, int x, int y, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill4BB")]
        internal static extern IntPtr pixSeedfill4BB(HandleRef pixs, IntPtr stack, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill8BB")]
        internal static extern IntPtr pixSeedfill8BB(HandleRef pixs, IntPtr stack, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill")]
        internal static extern int pixSeedfill(HandleRef pixs, IntPtr stack, int x, int y, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill4")]
        internal static extern int pixSeedfill4(HandleRef pixs, IntPtr stack, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill8")]
        internal static extern int pixSeedfill8(HandleRef pixs, IntPtr stack, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesTo1bpp")]
        internal static extern int convertFilesTo1bpp(HandleRef dirin, IntPtr substr, int upscaling, int thresh, int firstpage, int npages, IntPtr dirout, int outformat);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGray")]
        internal static extern IntPtr pixBlockconvGray(HandleRef pixs, IntPtr pixacc, int wc, int hc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvAccum")]
        internal static extern IntPtr pixBlockconvAccum(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGrayUnnormalized")]
        internal static extern IntPtr pixBlockconvGrayUnnormalized(HandleRef pixs, int wc, int hc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvTiled")]
        internal static extern IntPtr pixBlockconvTiled(HandleRef pix, int wc, int hc, int nx, int ny);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGrayTile")]
        internal static extern IntPtr pixBlockconvGrayTile(HandleRef pixs, IntPtr pixacc, int wc, int hc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedStats")]
        internal static extern int pixWindowedStats(HandleRef pixs, int wc, int hc, int hasborder, IntPtr ppixm, IntPtr ppixms, IntPtr pfpixv, IntPtr pfpixrv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedMean")]
        internal static extern IntPtr pixWindowedMean(HandleRef pixs, int wc, int hc, int hasborder, int normflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedMeanSquare")]
        internal static extern IntPtr pixWindowedMeanSquare(HandleRef pixs, int wc, int hc, int hasborder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedVariance")]
        internal static extern int pixWindowedVariance(HandleRef pixm, IntPtr pixms, IntPtr pfpixv, IntPtr pfpixrv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeanSquareAccum")]
        internal static extern IntPtr pixMeanSquareAccum(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockrank")]
        internal static extern IntPtr pixBlockrank(HandleRef pixs, IntPtr pixacc, int wc, int hc, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlocksum")]
        internal static extern IntPtr pixBlocksum(HandleRef pixs, IntPtr pixacc, int wc, int hc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCensusTransform")]
        internal static extern IntPtr pixCensusTransform(HandleRef pixs, int halfsize, IntPtr pixacc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolve")]
        internal static extern IntPtr pixConvolve(HandleRef pixs, IntPtr kel, int outdepth, int normflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveSep")]
        internal static extern IntPtr pixConvolveSep(HandleRef pixs, IntPtr kelx, IntPtr kely, int outdepth, int normflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveRGB")]
        internal static extern IntPtr pixConvolveRGB(HandleRef pixs, IntPtr kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveRGBSep")]
        internal static extern IntPtr pixConvolveRGBSep(HandleRef pixs, IntPtr kelx, IntPtr kely);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvolve")]
        internal static extern IntPtr fpixConvolve(HandleRef fpixs, IntPtr kel, int normflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvolveSep")]
        internal static extern IntPtr fpixConvolveSep(HandleRef fpixs, IntPtr kelx, IntPtr kely, int normflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveWithBias")]
        internal static extern IntPtr pixConvolveWithBias(HandleRef pixs, IntPtr kel1, IntPtr kel2, int force8, IntPtr pbias);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setConvolveSampling")]
        internal static extern void l_setConvolveSampling(int xfact, int yfact);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gaussDistribSampling")]
        internal static extern float gaussDistribSampling();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScore")]
        internal static extern int pixCorrelationScore(Pix pix1, HandleRef pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, IntPtr tab, IntPtr pscore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreThresholded")]
        internal static extern int pixCorrelationScoreThresholded(HandleRef pix1, IntPtr pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, IntPtr tab, IntPtr downcount, float score_threshold);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreSimple")]
        internal static extern int pixCorrelationScoreSimple(HandleRef pix1, IntPtr pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, IntPtr tab, IntPtr pscore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreShifted")]
        internal static extern int pixCorrelationScoreShifted(HandleRef pix1, IntPtr pix2, int area1, int area2, int delx, int dely, IntPtr tab, IntPtr pscore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpCreate")]
        internal static extern IntPtr dewarpCreate(HandleRef pixs, int pageno);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpCreateRef")]
        internal static extern IntPtr dewarpCreateRef(int pageno, int refpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpDestroy")]
        internal static extern void dewarpDestroy(HandleRef pdew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaCreate")]
        internal static extern IntPtr dewarpaCreate(int nptrs, int sampling, int redfactor, int minlines, int maxdist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaCreateFromPixacomp")]
        internal static extern IntPtr dewarpaCreateFromPixacomp(HandleRef pixac, int useboth, int sampling, int minlines, int maxdist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaDestroy")]
        internal static extern void dewarpaDestroy(HandleRef pdewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaDestroyDewarp")]
        internal static extern int dewarpaDestroyDewarp(HandleRef dewa, int pageno);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInsertDewarp")]
        internal static extern int dewarpaInsertDewarp(HandleRef dewa, IntPtr dew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaGetDewarp")]
        internal static extern IntPtr dewarpaGetDewarp(HandleRef dewa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetCurvatures")]
        internal static extern int dewarpaSetCurvatures(HandleRef dewa, int max_linecurv, int min_diff_linecurv, int max_diff_linecurv, int max_edgecurv, int max_diff_edgecurv, int max_edgeslope);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaUseBothArrays")]
        internal static extern int dewarpaUseBothArrays(HandleRef dewa, int useboth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetCheckColumns")]
        internal static extern int dewarpaSetCheckColumns(HandleRef dewa, int check_columns);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetMaxDistance")]
        internal static extern int dewarpaSetMaxDistance(HandleRef dewa, int maxdist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpRead")]
        internal static extern IntPtr dewarpRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpReadStream")]
        internal static extern IntPtr dewarpReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpReadMem")]
        internal static extern IntPtr dewarpReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWrite")]
        internal static extern int dewarpWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr dew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWriteStream")]
        internal static extern int dewarpWriteStream(HandleRef fp, IntPtr dew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWriteMem")]
        internal static extern int dewarpWriteMem(HandleRef pdata, IntPtr psize, IntPtr dew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaRead")]
        internal static extern IntPtr dewarpaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaReadStream")]
        internal static extern IntPtr dewarpaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaReadMem")]
        internal static extern IntPtr dewarpaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWrite")]
        internal static extern int dewarpaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWriteStream")]
        internal static extern int dewarpaWriteStream(HandleRef fp, IntPtr dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWriteMem")]
        internal static extern int dewarpaWriteMem(HandleRef pdata, IntPtr psize, IntPtr dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpBuildPageModel")]
        internal static extern int dewarpBuildPageModel(HandleRef dew, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpFindVertDisparity")]
        internal static extern int dewarpFindVertDisparity(HandleRef dew, IntPtr ptaa, int rotflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpFindHorizDisparity")]
        internal static extern int dewarpFindHorizDisparity(HandleRef dew, IntPtr ptaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpGetTextlineCenters")]
        internal static extern IntPtr dewarpGetTextlineCenters(HandleRef pixs, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpRemoveShortLines")]
        internal static extern IntPtr dewarpRemoveShortLines(HandleRef pixs, IntPtr ptaas, float fract, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpBuildLineModel")]
        internal static extern int dewarpBuildLineModel(HandleRef dew, int opensize, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaModelStatus")]
        internal static extern int dewarpaModelStatus(HandleRef dewa, int pageno, IntPtr pvsuccess, IntPtr phsuccess);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaApplyDisparity")]
        internal static extern int dewarpaApplyDisparity(HandleRef dewa, int pageno, IntPtr pixs, int grayin, int x, int y, IntPtr ppixd, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaApplyDisparityBoxa")]
        internal static extern int dewarpaApplyDisparityBoxa(HandleRef dewa, int pageno, IntPtr pixs, IntPtr boxas, int mapdir, int x, int y, IntPtr pboxad, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpMinimize")]
        internal static extern int dewarpMinimize(HandleRef dew);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpPopulateFullRes")]
        internal static extern int dewarpPopulateFullRes(HandleRef dew, IntPtr pix, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePage")]
        internal static extern int dewarpSinglePage(HandleRef pixs, int thresh, int adaptive, int useboth, int check_columns, IntPtr ppixd, IntPtr pdewa, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePageInit")]
        internal static extern int dewarpSinglePageInit(HandleRef pixs, int thresh, int adaptive, int useboth, int check_columns, IntPtr ppixb, IntPtr pdewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePageRun")]
        internal static extern int dewarpSinglePageRun(HandleRef pixs, IntPtr pixb, IntPtr dewa, IntPtr ppixd, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaListPages")]
        internal static extern int dewarpaListPages(HandleRef dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetValidModels")]
        internal static extern int dewarpaSetValidModels(HandleRef dewa, int notests, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInsertRefModels")]
        internal static extern int dewarpaInsertRefModels(HandleRef dewa, int notests, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaStripRefModels")]
        internal static extern int dewarpaStripRefModels(HandleRef dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaRestoreModels")]
        internal static extern int dewarpaRestoreModels(HandleRef dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInfo")]
        internal static extern int dewarpaInfo(HandleRef fp, IntPtr dewa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaModelStats")]
        internal static extern int dewarpaModelStats(HandleRef dewa, IntPtr pnnone, IntPtr pnvsuccess, IntPtr pnvvalid, IntPtr pnhsuccess, IntPtr pnhvalid, IntPtr pnref);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaShowArrays")]
        internal static extern int dewarpaShowArrays(HandleRef dewa, float scalefact, int first, int last);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpDebug")]
        internal static extern int dewarpDebug(HandleRef dew, IntPtr subdirs, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpShowResults")]
        internal static extern int dewarpShowResults(HandleRef dewa, IntPtr sa, IntPtr boxa, int firstpage, int lastpage, IntPtr pdfout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreate")]
        internal static extern IntPtr l_dnaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreateFromIArray")]
        internal static extern IntPtr l_dnaCreateFromIArray(HandleRef iarray, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreateFromDArray")]
        internal static extern IntPtr l_dnaCreateFromDArray(HandleRef darray, int size, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaMakeSequence")]
        internal static extern IntPtr l_dnaMakeSequence(double startval, double increment, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaDestroy")]
        internal static extern void l_dnaDestroy(HandleRef pda);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCopy")]
        internal static extern IntPtr l_dnaCopy(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaClone")]
        internal static extern IntPtr l_dnaClone(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaEmpty")]
        internal static extern int l_dnaEmpty(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaAddNumber")]
        internal static extern int l_dnaAddNumber(HandleRef da, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaInsertNumber")]
        internal static extern int l_dnaInsertNumber(HandleRef da, int index, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveNumber")]
        internal static extern int l_dnaRemoveNumber(HandleRef da, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaReplaceNumber")]
        internal static extern int l_dnaReplaceNumber(HandleRef da, int index, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetCount")]
        internal static extern int l_dnaGetCount(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetCount")]
        internal static extern int l_dnaSetCount(HandleRef da, int newcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetDValue")]
        internal static extern int l_dnaGetDValue(HandleRef da, int index, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetIValue")]
        internal static extern int l_dnaGetIValue(HandleRef da, int index, IntPtr pival);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetValue")]
        internal static extern int l_dnaSetValue(HandleRef da, int index, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaShiftValue")]
        internal static extern int l_dnaShiftValue(HandleRef da, int index, double diff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetIArray")]
        internal static extern IntPtr l_dnaGetIArray(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetDArray")]
        internal static extern IntPtr l_dnaGetDArray(HandleRef da, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetRefcount")]
        internal static extern int l_dnaGetRefcount(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaChangeRefcount")]
        internal static extern int l_dnaChangeRefcount(HandleRef da, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetParameters")]
        internal static extern int l_dnaGetParameters(HandleRef da, IntPtr pstartx, IntPtr pdelx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetParameters")]
        internal static extern int l_dnaSetParameters(HandleRef da, double startx, double delx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCopyParameters")]
        internal static extern int l_dnaCopyParameters(HandleRef dad, IntPtr das);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRead")]
        internal static extern IntPtr l_dnaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaReadStream")]
        internal static extern IntPtr l_dnaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaWrite")]
        internal static extern int l_dnaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaWriteStream")]
        internal static extern int l_dnaWriteStream(HandleRef fp, IntPtr da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaCreate")]
        internal static extern IntPtr l_dnaaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaCreateFull")]
        internal static extern IntPtr l_dnaaCreateFull(int nptr, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaTruncate")]
        internal static extern int l_dnaaTruncate(HandleRef daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaDestroy")]
        internal static extern void l_dnaaDestroy(HandleRef pdaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaAddDna")]
        internal static extern int l_dnaaAddDna(HandleRef daa, IntPtr da, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetCount")]
        internal static extern int l_dnaaGetCount(HandleRef daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetDnaCount")]
        internal static extern int l_dnaaGetDnaCount(HandleRef daa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetNumberCount")]
        internal static extern int l_dnaaGetNumberCount(HandleRef daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetDna")]
        internal static extern IntPtr l_dnaaGetDna(HandleRef daa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaReplaceDna")]
        internal static extern int l_dnaaReplaceDna(HandleRef daa, int index, IntPtr da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetValue")]
        internal static extern int l_dnaaGetValue(HandleRef daa, int i, int j, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaAddNumber")]
        internal static extern int l_dnaaAddNumber(HandleRef daa, int index, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaRead")]
        internal static extern IntPtr l_dnaaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaReadStream")]
        internal static extern IntPtr l_dnaaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaWrite")]
        internal static extern int l_dnaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaWriteStream")]
        internal static extern int l_dnaaWriteStream(HandleRef fp, IntPtr daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaJoin")]
        internal static extern int l_dnaJoin(HandleRef dad, IntPtr das, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaFlattenToDna")]
        internal static extern IntPtr l_dnaaFlattenToDna(HandleRef daa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaConvertToNuma")]
        internal static extern IntPtr l_dnaConvertToNuma(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToDna")]
        internal static extern IntPtr numaConvertToDna(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaUnionByAset")]
        internal static extern IntPtr l_dnaUnionByAset(HandleRef da1, IntPtr da2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveDupsByAset")]
        internal static extern IntPtr l_dnaRemoveDupsByAset(HandleRef das);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaIntersectionByAset")]
        internal static extern IntPtr l_dnaIntersectionByAset(HandleRef da1, IntPtr da2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromDna")]
        internal static extern IntPtr l_asetCreateFromDna(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaDiffAdjValues")]
        internal static extern IntPtr l_dnaDiffAdjValues(HandleRef das);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreate")]
        internal static extern IntPtr l_dnaHashCreate(int nbuckets, int initsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashDestroy")]
        internal static extern void l_dnaHashDestroy(HandleRef pdahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetCount")]
        internal static extern int l_dnaHashGetCount(HandleRef dahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetTotalCount")]
        internal static extern int l_dnaHashGetTotalCount(HandleRef dahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetDna")]
        internal static extern IntPtr l_dnaHashGetDna(HandleRef dahash, ulong key, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashAdd")]
        internal static extern int l_dnaHashAdd(HandleRef dahash, ulong key, double value);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromDna")]
        internal static extern IntPtr l_dnaHashCreateFromDna(HandleRef da);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveDupsByHash")]
        internal static extern int l_dnaRemoveDupsByHash(HandleRef das, IntPtr pdad, IntPtr pdahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaMakeHistoByHash")]
        internal static extern int l_dnaMakeHistoByHash(HandleRef das, IntPtr pdahash, IntPtr pdav, IntPtr pdac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaIntersectionByHash")]
        internal static extern IntPtr l_dnaIntersectionByHash(HandleRef da1, IntPtr da2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaFindValByHash")]
        internal static extern int l_dnaFindValByHash(HandleRef da, IntPtr dahash, double val, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphDwa_2")]
        internal static extern IntPtr pixMorphDwa_2(HandleRef pixd, IntPtr pixs, int operation, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFMorphopGen_2")]
        internal static extern IntPtr pixFMorphopGen_2(HandleRef pixd, IntPtr pixs, int operation, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphopgen_low_2")]
        internal static extern int fmorphopgen_low_2(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSobelEdgeFilter")]
        internal static extern IntPtr pixSobelEdgeFilter(HandleRef pixs, int orientflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTwoSidedEdgeFilter")]
        internal static extern IntPtr pixTwoSidedEdgeFilter(HandleRef pixs, int orientflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeasureEdgeSmoothness")]
        internal static extern int pixMeasureEdgeSmoothness(HandleRef pixs, int side, int minjump, int minreversal, IntPtr pjpl, IntPtr pjspl, IntPtr prpl, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetEdgeProfile")]
        internal static extern IntPtr pixGetEdgeProfile(HandleRef pixs, int side, IntPtr debugfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLastOffPixelInRun")]
        internal static extern int pixGetLastOffPixelInRun(HandleRef pixs, int x, int y, int direction, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLastOnPixelInRun")]
        internal static extern int pixGetLastOnPixelInRun(HandleRef pixs, int x, int y, int direction, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "encodeBase64")]
        internal static extern IntPtr encodeBase64(HandleRef inarray, int insize, IntPtr poutsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "decodeBase64")]
        internal static extern IntPtr decodeBase64(HandleRef inarray, int insize, IntPtr poutsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "encodeAscii85")]
        internal static extern IntPtr encodeAscii85(HandleRef inarray, int insize, IntPtr poutsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "decodeAscii85")]
        internal static extern IntPtr decodeAscii85(HandleRef inarray, int insize, IntPtr poutsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "reformatPacked64")]
        internal static extern IntPtr reformatPacked64(HandleRef inarray, int insize, int leadspace, int linechars, int addquotes, IntPtr poutsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRC")]
        internal static extern IntPtr pixGammaTRC(HandleRef pixd, IntPtr pixs, float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRCMasked")]
        internal static extern IntPtr pixGammaTRCMasked(HandleRef pixd, IntPtr pixs, IntPtr pixm, float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRCWithAlpha")]
        internal static extern IntPtr pixGammaTRCWithAlpha(HandleRef pixd, IntPtr pixs, float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGammaTRC")]
        internal static extern IntPtr numaGammaTRC(float gamma, int minval, int maxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastTRC")]
        internal static extern IntPtr pixContrastTRC(HandleRef pixd, IntPtr pixs, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastTRCMasked")]
        internal static extern IntPtr pixContrastTRCMasked(HandleRef pixd, IntPtr pixs, IntPtr pixm, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaContrastTRC")]
        internal static extern IntPtr numaContrastTRC(float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualizeTRC")]
        internal static extern IntPtr pixEqualizeTRC(HandleRef pixd, IntPtr pixs, float fract, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEqualizeTRC")]
        internal static extern IntPtr numaEqualizeTRC(HandleRef pix, float fract, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTRCMap")]
        internal static extern int pixTRCMap(HandleRef pixs, HandleRef pixm, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMasking")]
        internal static extern IntPtr pixUnsharpMasking(HandleRef pixs, int halfwidth, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray")]
        internal static extern IntPtr pixUnsharpMaskingGray(HandleRef pixs, int halfwidth, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingFast")]
        internal static extern IntPtr pixUnsharpMaskingFast(HandleRef pixs, int halfwidth, float fract, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGrayFast")]
        internal static extern IntPtr pixUnsharpMaskingGrayFast(HandleRef pixs, int halfwidth, float fract, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray1D")]
        internal static extern IntPtr pixUnsharpMaskingGray1D(HandleRef pixs, int halfwidth, float fract, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray2D")]
        internal static extern IntPtr pixUnsharpMaskingGray2D(HandleRef pixs, int halfwidth, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyHue")]
        internal static extern IntPtr pixModifyHue(HandleRef pixd, IntPtr pixs, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifySaturation")]
        internal static extern IntPtr pixModifySaturation(HandleRef pixd, IntPtr pixs, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeasureSaturation")]
        internal static extern int pixMeasureSaturation(HandleRef pixs, int factor, IntPtr psat);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorShiftRGB")]
        internal static extern IntPtr pixColorShiftRGB(HandleRef pixs, float rfract, float gfract, float bfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstantColor")]
        internal static extern IntPtr pixMultConstantColor(HandleRef pixs, float rfact, float gfact, float bfact);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultMatrixColor")]
        internal static extern IntPtr pixMultMatrixColor(HandleRef pixs, IntPtr kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHalfEdgeByBandpass")]
        internal static extern IntPtr pixHalfEdgeByBandpass(HandleRef pixs, int sm1h, int sm1v, int sm2h, int sm2v);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen")]
        internal static extern int fhmtautogen(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen1")]
        internal static extern int fhmtautogen1(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen2")]
        internal static extern int fhmtautogen2(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHMTDwa_1")]
        internal static extern IntPtr pixHMTDwa_1(HandleRef pixd, IntPtr pixs, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFHMTGen_1")]
        internal static extern IntPtr pixFHMTGen_1(HandleRef pixd, IntPtr pixs, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtgen_low_1")]
        internal static extern int fhmtgen_low_1(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixItalicWords")]
        internal static extern int pixItalicWords(HandleRef pixs, IntPtr boxaw, IntPtr pixw, IntPtr pboxa, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOrientDetect")]
        internal static extern int pixOrientDetect(HandleRef pixs, IntPtr pupconf, IntPtr pleftconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeOrientDecision")]
        internal static extern int makeOrientDecision(float upconf, float leftconf, float minupconf, float minratio, IntPtr porient, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetect")]
        internal static extern int pixUpDownDetect(HandleRef pixs, IntPtr pconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectGeneral")]
        internal static extern int pixUpDownDetectGeneral(HandleRef pixs, IntPtr pconf, int mincount, int npixels, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOrientDetectDwa")]
        internal static extern int pixOrientDetectDwa(HandleRef pixs, IntPtr pupconf, IntPtr pleftconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectDwa")]
        internal static extern int pixUpDownDetectDwa(HandleRef pixs, IntPtr pconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectGeneralDwa")]
        internal static extern int pixUpDownDetectGeneralDwa(HandleRef pixs, IntPtr pconf, int mincount, int npixels, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirrorDetect")]
        internal static extern int pixMirrorDetect(HandleRef pixs, IntPtr pconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirrorDetectDwa")]
        internal static extern int pixMirrorDetectDwa(HandleRef pixs, IntPtr pconf, int mincount, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipFHMTGen")]
        internal static extern IntPtr pixFlipFHMTGen(HandleRef pixd, IntPtr pixs, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen")]
        internal static extern int fmorphautogen(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen1")]
        internal static extern int fmorphautogen1(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen2")]
        internal static extern int fmorphautogen2(HandleRef sela, int fileindex, IntPtr filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphDwa_1")]
        internal static extern IntPtr pixMorphDwa_1(HandleRef pixd, IntPtr pixs, int operation, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFMorphopGen_1")]
        internal static extern IntPtr pixFMorphopGen_1(HandleRef pixd, IntPtr pixs, int operation, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphopgen_low_1")]
        internal static extern int fmorphopgen_low_1(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCreate")]
        internal static extern IntPtr fpixCreate(int width, int height);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCreateTemplate")]
        internal static extern IntPtr fpixCreateTemplate(HandleRef fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixClone")]
        internal static extern IntPtr fpixClone(HandleRef fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCopy")]
        internal static extern IntPtr fpixCopy(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixResizeImageData")]
        internal static extern int fpixResizeImageData(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixDestroy")]
        internal static extern void fpixDestroy(HandleRef pfpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetDimensions")]
        internal static extern int fpixGetDimensions(HandleRef fpix, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetDimensions")]
        internal static extern int fpixSetDimensions(HandleRef fpix, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetWpl")]
        internal static extern int fpixGetWpl(HandleRef fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetWpl")]
        internal static extern int fpixSetWpl(HandleRef fpix, int wpl);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetRefcount")]
        internal static extern int fpixGetRefcount(HandleRef fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixChangeRefcount")]
        internal static extern int fpixChangeRefcount(HandleRef fpix, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetResolution")]
        internal static extern int fpixGetResolution(HandleRef fpix, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetResolution")]
        internal static extern int fpixSetResolution(HandleRef fpix, int xres, int yres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCopyResolution")]
        internal static extern int fpixCopyResolution(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetData")]
        internal static extern IntPtr fpixGetData(HandleRef fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetData")]
        internal static extern int fpixSetData(HandleRef fpix, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetPixel")]
        internal static extern int fpixGetPixel(HandleRef fpix, int x, int y, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetPixel")]
        internal static extern int fpixSetPixel(HandleRef fpix, int x, int y, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaCreate")]
        internal static extern IntPtr fpixaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaCopy")]
        internal static extern IntPtr fpixaCopy(HandleRef fpixa, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaDestroy")]
        internal static extern void fpixaDestroy(HandleRef pfpixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaAddFPix")]
        internal static extern int fpixaAddFPix(HandleRef fpixa, IntPtr fpix, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetCount")]
        internal static extern int fpixaGetCount(HandleRef fpixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaChangeRefcount")]
        internal static extern int fpixaChangeRefcount(HandleRef fpixa, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetFPix")]
        internal static extern IntPtr fpixaGetFPix(HandleRef fpixa, int index, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetFPixDimensions")]
        internal static extern int fpixaGetFPixDimensions(HandleRef fpixa, int index, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetData")]
        internal static extern IntPtr fpixaGetData(HandleRef fpixa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetPixel")]
        internal static extern int fpixaGetPixel(HandleRef fpixa, int index, int x, int y, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaSetPixel")]
        internal static extern int fpixaSetPixel(HandleRef fpixa, int index, int x, int y, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCreate")]
        internal static extern IntPtr dpixCreate(int width, int height);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCreateTemplate")]
        internal static extern IntPtr dpixCreateTemplate(HandleRef dpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixClone")]
        internal static extern IntPtr dpixClone(HandleRef dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCopy")]
        internal static extern IntPtr dpixCopy(HandleRef dpixd, IntPtr dpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixResizeImageData")]
        internal static extern int dpixResizeImageData(HandleRef dpixd, IntPtr dpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixDestroy")]
        internal static extern void dpixDestroy(HandleRef pdpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetDimensions")]
        internal static extern int dpixGetDimensions(HandleRef dpix, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetDimensions")]
        internal static extern int dpixSetDimensions(HandleRef dpix, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetWpl")]
        internal static extern int dpixGetWpl(HandleRef dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetWpl")]
        internal static extern int dpixSetWpl(HandleRef dpix, int wpl);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetRefcount")]
        internal static extern int dpixGetRefcount(HandleRef dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixChangeRefcount")]
        internal static extern int dpixChangeRefcount(HandleRef dpix, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetResolution")]
        internal static extern int dpixGetResolution(HandleRef dpix, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetResolution")]
        internal static extern int dpixSetResolution(HandleRef dpix, int xres, int yres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCopyResolution")]
        internal static extern int dpixCopyResolution(HandleRef dpixd, IntPtr dpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetData")]
        internal static extern IntPtr dpixGetData(HandleRef dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetData")]
        internal static extern int dpixSetData(HandleRef dpix, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetPixel")]
        internal static extern int dpixGetPixel(HandleRef dpix, int x, int y, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetPixel")]
        internal static extern int dpixSetPixel(HandleRef dpix, int x, int y, double val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRead")]
        internal static extern IntPtr fpixRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixReadStream")]
        internal static extern IntPtr fpixReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixReadMem")]
        internal static extern IntPtr fpixReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWrite")]
        internal static extern int fpixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWriteStream")]
        internal static extern int fpixWriteStream(HandleRef fp, IntPtr fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWriteMem")]
        internal static extern int fpixWriteMem(HandleRef pdata, IntPtr psize, IntPtr fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixEndianByteSwap")]
        internal static extern IntPtr fpixEndianByteSwap(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixRead")]
        internal static extern IntPtr dpixRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixReadStream")]
        internal static extern IntPtr dpixReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixReadMem")]
        internal static extern IntPtr dpixReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWrite")]
        internal static extern int dpixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWriteStream")]
        internal static extern int dpixWriteStream(HandleRef fp, IntPtr dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWriteMem")]
        internal static extern int dpixWriteMem(HandleRef pdata, IntPtr psize, IntPtr dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixEndianByteSwap")]
        internal static extern IntPtr dpixEndianByteSwap(HandleRef dpixd, IntPtr dpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixPrintStream")]
        internal static extern int fpixPrintStream(HandleRef fp, IntPtr fpix, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToFPix")]
        internal static extern IntPtr pixConvertToFPix(HandleRef pixs, int ncomps);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToDPix")]
        internal static extern IntPtr pixConvertToDPix(HandleRef pixs, int ncomps);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvertToPix")]
        internal static extern IntPtr fpixConvertToPix(HandleRef fpixs, int outdepth, int negvals, int errorflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixDisplayMaxDynamicRange")]
        internal static extern IntPtr fpixDisplayMaxDynamicRange(HandleRef fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvertToDPix")]
        internal static extern IntPtr fpixConvertToDPix(HandleRef fpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixConvertToPix")]
        internal static extern IntPtr dpixConvertToPix(HandleRef dpixs, int outdepth, int negvals, int errorflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixConvertToFPix")]
        internal static extern IntPtr dpixConvertToFPix(HandleRef dpix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetMin")]
        internal static extern int fpixGetMin(HandleRef fpix, IntPtr pminval, IntPtr pxminloc, IntPtr pyminloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetMax")]
        internal static extern int fpixGetMax(HandleRef fpix, IntPtr pmaxval, IntPtr pxmaxloc, IntPtr pymaxloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetMin")]
        internal static extern int dpixGetMin(HandleRef dpix, IntPtr pminval, IntPtr pxminloc, IntPtr pyminloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetMax")]
        internal static extern int dpixGetMax(HandleRef dpix, IntPtr pmaxval, IntPtr pxmaxloc, IntPtr pymaxloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixScaleByInteger")]
        internal static extern IntPtr fpixScaleByInteger(HandleRef fpixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixScaleByInteger")]
        internal static extern IntPtr dpixScaleByInteger(HandleRef dpixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixLinearCombination")]
        internal static extern IntPtr fpixLinearCombination(HandleRef fpixd, IntPtr fpixs1, IntPtr fpixs2, float a, float b);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddMultConstant")]
        internal static extern int fpixAddMultConstant(HandleRef fpix, float addc, float multc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixLinearCombination")]
        internal static extern IntPtr dpixLinearCombination(HandleRef dpixd, IntPtr dpixs1, IntPtr dpixs2, float a, float b);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixAddMultConstant")]
        internal static extern int dpixAddMultConstant(HandleRef dpix, double addc, double multc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetAllArbitrary")]
        internal static extern int fpixSetAllArbitrary(HandleRef fpix, float inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetAllArbitrary")]
        internal static extern int dpixSetAllArbitrary(HandleRef dpix, double inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddBorder")]
        internal static extern IntPtr fpixAddBorder(HandleRef fpixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRemoveBorder")]
        internal static extern IntPtr fpixRemoveBorder(HandleRef fpixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddMirroredBorder")]
        internal static extern IntPtr fpixAddMirroredBorder(HandleRef fpixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddContinuedBorder")]
        internal static extern IntPtr fpixAddContinuedBorder(HandleRef fpixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddSlopeBorder")]
        internal static extern IntPtr fpixAddSlopeBorder(HandleRef fpixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRasterop")]
        internal static extern int fpixRasterop(HandleRef fpixd, int dx, int dy, int dw, int dh, IntPtr fpixs, int sx, int sy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotateOrth")]
        internal static extern IntPtr fpixRotateOrth(HandleRef fpixs, int quads);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotate180")]
        internal static extern IntPtr fpixRotate180(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotate90")]
        internal static extern IntPtr fpixRotate90(HandleRef fpixs, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixFlipLR")]
        internal static extern IntPtr fpixFlipLR(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixFlipTB")]
        internal static extern IntPtr fpixFlipTB(HandleRef fpixd, IntPtr fpixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAffinePta")]
        internal static extern IntPtr fpixAffinePta(HandleRef fpixs, IntPtr ptad, IntPtr ptas, int border, float inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAffine")]
        internal static extern IntPtr fpixAffine(HandleRef fpixs, IntPtr vc, float inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixProjectivePta")]
        internal static extern IntPtr fpixProjectivePta(HandleRef fpixs, IntPtr ptad, IntPtr ptas, int border, float inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixProjective")]
        internal static extern IntPtr fpixProjective(HandleRef fpixs, IntPtr vc, float inval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelFloat")]
        internal static extern int linearInterpolatePixelFloat(HandleRef datas, int w, int h, float x, float y, float inval, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixThresholdToPix")]
        internal static extern IntPtr fpixThresholdToPix(HandleRef fpix, float thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixComponentFunction")]
        internal static extern IntPtr pixComponentFunction(HandleRef pix, float rnum, float gnum, float bnum, float rdenom, float gdenom, float bdenom);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamGif")]
        internal static extern IntPtr pixReadStreamGif(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamGif")]
        internal static extern int pixWriteStreamGif(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemGif")]
        internal static extern IntPtr pixReadMemGif(HandleRef cdata, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemGif")]
        internal static extern int pixWriteMemGif(HandleRef pdata, IntPtr psize, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotCreate")]
        internal static extern IntPtr gplotCreate(HandleRef rootname, int outformat, IntPtr title, IntPtr xlabel, IntPtr ylabel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotDestroy")]
        internal static extern void gplotDestroy(HandleRef pgplot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotAddPlot")]
        internal static extern int gplotAddPlot(HandleRef gplot, IntPtr nax, IntPtr nay, int plotstyle, IntPtr plottitle);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSetScaling")]
        internal static extern int gplotSetScaling(HandleRef gplot, int scaling);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotMakeOutput")]
        internal static extern int gplotMakeOutput(HandleRef gplot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotGenCommandFile")]
        internal static extern int gplotGenCommandFile(HandleRef gplot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotGenDataFiles")]
        internal static extern int gplotGenDataFiles(HandleRef gplot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimple1")]
        internal static extern int gplotSimple1(HandleRef na, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimple2")]
        internal static extern int gplotSimple2(HandleRef na1, IntPtr na2, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleN")]
        internal static extern int gplotSimpleN(HandleRef naa, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXY1")]
        internal static extern int gplotSimpleXY1(HandleRef nax, IntPtr nay, int plotstyle, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXY2")]
        internal static extern int gplotSimpleXY2(HandleRef nax, IntPtr nay1, IntPtr nay2, int plotstyle, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXYN")]
        internal static extern int gplotSimpleXYN(HandleRef nax, IntPtr naay, int plotstyle, int outformat, IntPtr outroot, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotRead")]
        internal static extern IntPtr gplotRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotWrite")]
        internal static extern int gplotWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr gplot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaLine")]
        internal static extern IntPtr generatePtaLine(int x1, int y1, int x2, int y2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaWideLine")]
        internal static extern IntPtr generatePtaWideLine(int x1, int y1, int x2, int y2, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaBox")]
        internal static extern IntPtr generatePtaBox(HandleRef box, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaBoxa")]
        internal static extern IntPtr generatePtaBoxa(HandleRef boxa, int width, int removedups);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaHashBox")]
        internal static extern IntPtr generatePtaHashBox(HandleRef box, int spacing, int width, int orient, int outline);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaHashBoxa")]
        internal static extern IntPtr generatePtaHashBoxa(HandleRef boxa, int spacing, int width, int orient, int outline, int removedups);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaaBoxa")]
        internal static extern IntPtr generatePtaaBoxa(HandleRef boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaaHashBoxa")]
        internal static extern IntPtr generatePtaaHashBoxa(HandleRef boxa, int spacing, int width, int orient, int outline);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaPolyline")]
        internal static extern IntPtr generatePtaPolyline(HandleRef ptas, int width, int closeflag, int removedups);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaGrid")]
        internal static extern IntPtr generatePtaGrid(int w, int h, int nx, int ny, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertPtaLineTo4cc")]
        internal static extern IntPtr convertPtaLineTo4cc(HandleRef ptas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaFilledCircle")]
        internal static extern IntPtr generatePtaFilledCircle(int radius);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaFilledSquare")]
        internal static extern IntPtr generatePtaFilledSquare(int side);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaLineFromPt")]
        internal static extern IntPtr generatePtaLineFromPt(int x, int y, double length, double radang);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "locatePtRadially")]
        internal static extern int locatePtRadially(int xr, int yr, double dist, double radang, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPlotFromNuma")]
        internal static extern int pixRenderPlotFromNuma(HandleRef ppix, IntPtr na, int plotloc, int linewidth, int max, uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePlotPtaFromNuma")]
        internal static extern IntPtr makePlotPtaFromNuma(HandleRef na, int size, int plotloc, int linewidth, int max);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPlotFromNumaGen")]
        internal static extern int pixRenderPlotFromNumaGen(HandleRef ppix, IntPtr na, int orient, int linewidth, int refpos, int max, int drawref, uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePlotPtaFromNumaGen")]
        internal static extern IntPtr makePlotPtaFromNumaGen(HandleRef na, int orient, int linewidth, int refpos, int max, int drawref);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPta")]
        internal static extern int pixRenderPta(HandleRef pix, IntPtr pta, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPtaArb")]
        internal static extern int pixRenderPtaArb(HandleRef pix, IntPtr pta, byte rval, byte gval, byte bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPtaBlend")]
        internal static extern int pixRenderPtaBlend(HandleRef pix, IntPtr pta, byte rval, byte gval, byte bval, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLine")]
        internal static extern int pixRenderLine(HandleRef pix, int x1, int y1, int x2, int y2, int width, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLineArb")]
        internal static extern int pixRenderLineArb(HandleRef pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLineBlend")]
        internal static extern int pixRenderLineBlend(HandleRef pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBox")]
        internal static extern int pixRenderBox(HandleRef pix, IntPtr box, int width, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxArb")]
        internal static extern int pixRenderBoxArb(HandleRef pix, IntPtr box, int width, byte rval, byte gval, byte bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxBlend")]
        internal static extern int pixRenderBoxBlend(HandleRef pix, IntPtr box, int width, byte rval, byte gval, byte bval, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxa")]
        internal static extern int pixRenderBoxa(HandleRef pix, IntPtr boxa, int width, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxaArb")]
        internal static extern int pixRenderBoxaArb(HandleRef pix, IntPtr boxa, int width, byte rval, byte gval, byte bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxaBlend")]
        internal static extern int pixRenderBoxaBlend(HandleRef pix, IntPtr boxa, int width, byte rval, byte gval, byte bval, float fract, int removedups);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBox")]
        internal static extern int pixRenderHashBox(HandleRef pix, IntPtr box, int spacing, int width, int orient, int outline, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxArb")]
        internal static extern int pixRenderHashBoxArb(HandleRef pix, IntPtr box, int spacing, int width, int orient, int outline, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxBlend")]
        internal static extern int pixRenderHashBoxBlend(HandleRef pix, IntPtr box, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashMaskArb")]
        internal static extern int pixRenderHashMaskArb(HandleRef pix, IntPtr pixm, int x, int y, int spacing, int width, int orient, int outline, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxa")]
        internal static extern int pixRenderHashBoxa(HandleRef pix, IntPtr boxa, int spacing, int width, int orient, int outline, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxaArb")]
        internal static extern int pixRenderHashBoxaArb(HandleRef pix, IntPtr boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxaBlend")]
        internal static extern int pixRenderHashBoxaBlend(HandleRef pix, IntPtr boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolyline")]
        internal static extern int pixRenderPolyline(HandleRef pix, IntPtr ptas, int width, int op, int closeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolylineArb")]
        internal static extern int pixRenderPolylineArb(HandleRef pix, IntPtr ptas, int width, byte rval, byte gval, byte bval, int closeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolylineBlend")]
        internal static extern int pixRenderPolylineBlend(HandleRef pix, IntPtr ptas, int width, byte rval, byte gval, byte bval, float fract, int closeflag, int removedups);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderGridArb")]
        internal static extern int pixRenderGridArb(HandleRef pix, int nx, int ny, int width, byte rval, byte gval, byte bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderRandomCmapPtaa")]
        internal static extern IntPtr pixRenderRandomCmapPtaa(HandleRef pix, IntPtr ptaa, int polyflag, int width, int closeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolygon")]
        internal static extern IntPtr pixRenderPolygon(HandleRef ptas, int width, IntPtr pxmin, IntPtr pymin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillPolygon")]
        internal static extern IntPtr pixFillPolygon(HandleRef pixs, IntPtr pta, int xmin, int ymin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderContours")]
        internal static extern IntPtr pixRenderContours(HandleRef pixs, int startval, int incr, int outdepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAutoRenderContours")]
        internal static extern IntPtr fpixAutoRenderContours(HandleRef fpix, int ncontours);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRenderContours")]
        internal static extern IntPtr fpixRenderContours(HandleRef fpixs, float incr, float proxim);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGeneratePtaBoundary")]
        internal static extern IntPtr pixGeneratePtaBoundary(HandleRef pixs, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeGray")]
        internal static extern IntPtr pixErodeGray(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateGray")]
        internal static extern IntPtr pixDilateGray(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGray")]
        internal static extern IntPtr pixOpenGray(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGray")]
        internal static extern IntPtr pixCloseGray(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeGray3")]
        internal static extern IntPtr pixErodeGray3(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateGray3")]
        internal static extern IntPtr pixDilateGray3(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGray3")]
        internal static extern IntPtr pixOpenGray3(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGray3")]
        internal static extern IntPtr pixCloseGray3(HandleRef pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherToBinary")]
        internal static extern IntPtr pixDitherToBinary(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherToBinarySpec")]
        internal static extern IntPtr pixDitherToBinarySpec(HandleRef pixs, int lowerclip, int upperclip);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdToBinary")]
        internal static extern IntPtr pixThresholdToBinary(HandleRef pixs, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarThresholdToBinary")]
        internal static extern IntPtr pixVarThresholdToBinary(HandleRef pixs, HandleRef pixg);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAdaptThresholdToBinary")]
        internal static extern IntPtr pixAdaptThresholdToBinary(HandleRef pixs, IntPtr pixm, float gamma);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAdaptThresholdToBinaryGen")]
        internal static extern IntPtr pixAdaptThresholdToBinaryGen(HandleRef pixs, IntPtr pixm, float gamma, int blackval, int whiteval, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByValue")]
        internal static extern IntPtr pixGenerateMaskByValue(HandleRef pixs, int val, int usecmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByBand")]
        internal static extern IntPtr pixGenerateMaskByBand(HandleRef pixs, int lower, int upper, int inband, int usecmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherTo2bpp")]
        internal static extern IntPtr pixDitherTo2bpp(HandleRef pixs, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherTo2bppSpec")]
        internal static extern IntPtr pixDitherTo2bppSpec(HandleRef pixs, int lowerclip, int upperclip, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdTo2bpp")]
        internal static extern IntPtr pixThresholdTo2bpp(HandleRef pixs, int nlevels, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdTo4bpp")]
        internal static extern IntPtr pixThresholdTo4bpp(HandleRef pixs, int nlevels, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdOn8bpp")]
        internal static extern IntPtr pixThresholdOn8bpp(HandleRef pixs, int nlevels, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdGrayArb")]
        internal static extern IntPtr pixThresholdGrayArb(HandleRef pixs, IntPtr edgevals, int outdepth, int use_average, int setblack, int setwhite);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantIndexTable")]
        internal static extern IntPtr makeGrayQuantIndexTable(int nlevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantTargetTable")]
        internal static extern IntPtr makeGrayQuantTargetTable(int nlevels, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantTableArb")]
        internal static extern int makeGrayQuantTableArb(HandleRef na, int outdepth, IntPtr ptab, IntPtr pcmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantColormapArb")]
        internal static extern int makeGrayQuantColormapArb(HandleRef pixs, IntPtr tab, int outdepth, IntPtr pcmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByBand32")]
        internal static extern IntPtr pixGenerateMaskByBand32(HandleRef pixs, uint refval, int delm, int delp, float fractm, float fractp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByDiscr32")]
        internal static extern IntPtr pixGenerateMaskByDiscr32(HandleRef pixs, uint refval1, uint refval2, int distflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayQuantFromHisto")]
        internal static extern IntPtr pixGrayQuantFromHisto(HandleRef pixd, IntPtr pixs, IntPtr pixm, float minfract, int maxsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayQuantFromCmap")]
        internal static extern IntPtr pixGrayQuantFromCmap(HandleRef pixs, IntPtr cmap, int mindepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherToBinaryLow")]
        internal static extern void ditherToBinaryLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherToBinaryLineLow")]
        internal static extern void ditherToBinaryLineLow(HandleRef lined, int w, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip, int lastlineflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdToBinaryLow")]
        internal static extern void thresholdToBinaryLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int d, int wpls, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdToBinaryLineLow")]
        internal static extern void thresholdToBinaryLineLow(HandleRef lined, int w, IntPtr lines, int d, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherTo2bppLow")]
        internal static extern void ditherTo2bppLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherTo2bppLineLow")]
        internal static extern void ditherTo2bppLineLow(HandleRef lined, int w, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14, int lastlineflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "make8To2DitherTables")]
        internal static extern int make8To2DitherTables(HandleRef ptabval, IntPtr ptab38, IntPtr ptab14, int cliptoblack, int cliptowhite);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdTo2bppLow")]
        internal static extern void thresholdTo2bppLow(HandleRef datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdTo4bppLow")]
        internal static extern void thresholdTo4bppLow(HandleRef datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapCreate")]
        internal static extern IntPtr lheapCreate(int nalloc, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapDestroy")]
        internal static extern void lheapDestroy(HandleRef plh, int freeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapAdd")]
        internal static extern int lheapAdd(HandleRef lh, IntPtr item);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapRemove")]
        internal static extern IntPtr lheapRemove(HandleRef lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapGetCount")]
        internal static extern int lheapGetCount(HandleRef lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSwapUp")]
        internal static extern int lheapSwapUp(HandleRef lh, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSwapDown")]
        internal static extern int lheapSwapDown(HandleRef lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSort")]
        internal static extern int lheapSort(HandleRef lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSortStrictOrder")]
        internal static extern int lheapSortStrictOrder(HandleRef lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapPrint")]
        internal static extern int lheapPrint(HandleRef fp, IntPtr lh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbRankHausInit")]
        internal static extern IntPtr jbRankHausInit(int components, int maxwidth, int maxheight, int size, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelationInit")]
        internal static extern IntPtr jbCorrelationInit(int components, int maxwidth, int maxheight, float thresh, float weightfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelationInitWithoutComponents")]
        internal static extern IntPtr jbCorrelationInitWithoutComponents(int components, int maxwidth, int maxheight, float thresh, float weightfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPages")]
        internal static extern int jbAddPages(HandleRef classer, IntPtr safiles);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPage")]
        internal static extern int jbAddPage(HandleRef classer, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPageComponents")]
        internal static extern int jbAddPageComponents(HandleRef classer, IntPtr pixs, IntPtr boxas, IntPtr pixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClassifyRankHaus")]
        internal static extern int jbClassifyRankHaus(HandleRef classer, IntPtr boxa, IntPtr pixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHaustest")]
        internal static extern int pixHaustest(HandleRef pix1, IntPtr pix2, IntPtr pix3, IntPtr pix4, float delx, float dely, int maxdiffw, int maxdiffh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankHaustest")]
        internal static extern int pixRankHaustest(HandleRef pix1, IntPtr pix2, IntPtr pix3, IntPtr pix4, float delx, float dely, int maxdiffw, int maxdiffh, int area1, int area3, float rank, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClassifyCorrelation")]
        internal static extern int jbClassifyCorrelation(HandleRef classer, IntPtr boxa, IntPtr pixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetComponents")]
        internal static extern int jbGetComponents(HandleRef pixs, int components, int maxwidth, int maxheight, IntPtr pboxad, IntPtr ppixad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWordMaskByDilation")]
        internal static extern int pixWordMaskByDilation(HandleRef pixs, int maxdil, IntPtr ppixm, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWordBoxesByDilation")]
        internal static extern int pixWordBoxesByDilation(HandleRef pixs, int maxdil, int minwidth, int minheight, int maxwidth, int maxheight, IntPtr pboxa, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAccumulateComposites")]
        internal static extern IntPtr jbAccumulateComposites(HandleRef pixaa, IntPtr pna, IntPtr pptat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbTemplatesFromComposites")]
        internal static extern IntPtr jbTemplatesFromComposites(HandleRef pixac, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClasserCreate")]
        internal static extern IntPtr jbClasserCreate(int method, int components);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClasserDestroy")]
        internal static extern void jbClasserDestroy(HandleRef pclasser);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataSave")]
        internal static extern IntPtr jbDataSave(HandleRef classer);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataDestroy")]
        internal static extern void jbDataDestroy(HandleRef pdata);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataWrite")]
        internal static extern int jbDataWrite(HandleRef rootout, IntPtr jbdata);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataRead")]
        internal static extern IntPtr jbDataRead(HandleRef rootname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataRender")]
        internal static extern IntPtr jbDataRender(HandleRef data, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetULCorners")]
        internal static extern int jbGetULCorners(HandleRef classer, IntPtr pixs, IntPtr boxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetLLCorners")]
        internal static extern int jbGetLLCorners(HandleRef classer);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderJp2k")]
        internal static extern int readHeaderJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderJp2k")]
        internal static extern int freadHeaderJp2k(HandleRef fp, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemJp2k")]
        internal static extern int readHeaderMemJp2k(HandleRef data, IntPtr size, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJp2kResolution")]
        internal static extern int fgetJp2kResolution(HandleRef fp, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadJp2k")]
        internal static extern IntPtr pixReadJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, uint reduction, IntPtr box, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamJp2k")]
        internal static extern IntPtr pixReadStreamJp2k(HandleRef fp, uint reduction, IntPtr box, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteJp2k")]
        internal static extern int pixWriteJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, int quality, int nlevels, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamJp2k")]
        internal static extern int pixWriteStreamJp2k(HandleRef fp, IntPtr pix, int quality, int nlevels, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemJp2k")]
        internal static extern IntPtr pixReadMemJp2k(HandleRef data, IntPtr size, uint reduction, IntPtr box, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemJp2k")]
        internal static extern int pixWriteMemJp2k(HandleRef pdata, IntPtr psize, IntPtr pix, int quality, int nlevels, int hint, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadJpeg")]
        internal static extern IntPtr pixReadJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int cmapflag, int reduction, IntPtr pnwarn, int hint);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamJpeg")]
        internal static extern IntPtr pixReadStreamJpeg(HandleRef fp, int cmapflag, int reduction, IntPtr pnwarn, int hint);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderJpeg")]
        internal static extern int readHeaderJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pw, IntPtr ph, IntPtr pspp, IntPtr pycck, IntPtr pcmyk);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderJpeg")]
        internal static extern int freadHeaderJpeg(HandleRef fp, IntPtr pw, IntPtr ph, IntPtr pspp, IntPtr pycck, IntPtr pcmyk);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJpegResolution")]
        internal static extern int fgetJpegResolution(HandleRef fp, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJpegComment")]
        internal static extern int fgetJpegComment(HandleRef fp, IntPtr pcomment);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteJpeg")]
        internal static extern int pixWriteJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, int quality, int progressive);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamJpeg")]
        internal static extern int pixWriteStreamJpeg(HandleRef fp, IntPtr pixs, int quality, int progressive);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemJpeg")]
        internal static extern IntPtr pixReadMemJpeg(HandleRef data, IntPtr size, int cmflag, int reduction, IntPtr pnwarn, int hint);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemJpeg")]
        internal static extern int readHeaderMemJpeg(HandleRef data, IntPtr size, IntPtr pw, IntPtr ph, IntPtr pspp, IntPtr pycck, IntPtr pcmyk);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemJpeg")]
        internal static extern int pixWriteMemJpeg(HandleRef pdata, IntPtr psize, IntPtr pix, int quality, int progressive);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetChromaSampling")]
        internal static extern int pixSetChromaSampling(HandleRef pix, int sampling);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreate")]
        internal static extern IntPtr kernelCreate(int height, int width);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelDestroy")]
        internal static extern void kernelDestroy(HandleRef pkel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCopy")]
        internal static extern IntPtr kernelCopy(HandleRef kels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetElement")]
        internal static extern int kernelGetElement(HandleRef kel, int row, int col, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelSetElement")]
        internal static extern int kernelSetElement(HandleRef kel, int row, int col, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetParameters")]
        internal static extern int kernelGetParameters(HandleRef kel, IntPtr psy, IntPtr psx, IntPtr pcy, IntPtr pcx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelSetOrigin")]
        internal static extern int kernelSetOrigin(HandleRef kel, int cy, int cx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetSum")]
        internal static extern int kernelGetSum(HandleRef kel, IntPtr psum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetMinMax")]
        internal static extern int kernelGetMinMax(HandleRef kel, IntPtr pmin, IntPtr pmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelNormalize")]
        internal static extern IntPtr kernelNormalize(HandleRef kels, float normsum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelInvert")]
        internal static extern IntPtr kernelInvert(HandleRef kels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "create2dFloatArray")]
        internal static extern IntPtr create2dFloatArray(int sy, int sx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelRead")]
        internal static extern IntPtr kernelRead(HandleRef fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelReadStream")]
        internal static extern IntPtr kernelReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelWrite")]
        internal static extern int kernelWrite(HandleRef fname, IntPtr kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelWriteStream")]
        internal static extern int kernelWriteStream(HandleRef fp, IntPtr kel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromString")]
        internal static extern IntPtr kernelCreateFromString(int h, int w, int cy, int cx, IntPtr kdata);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromFile")]
        internal static extern IntPtr kernelCreateFromFile(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromPix")]
        internal static extern IntPtr kernelCreateFromPix(HandleRef pix, int cy, int cx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelDisplayInPix")]
        internal static extern IntPtr kernelDisplayInPix(HandleRef kel, int size, int gthick);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "parseStringForNumbers")]
        internal static extern IntPtr parseStringForNumbers(HandleRef str, IntPtr seps);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeFlatKernel")]
        internal static extern IntPtr makeFlatKernel(int height, int width, int cy, int cx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGaussianKernel")]
        internal static extern IntPtr makeGaussianKernel(int halfheight, int halfwidth, float stdev, float max);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGaussianKernelSep")]
        internal static extern int makeGaussianKernelSep(int halfheight, int halfwidth, float stdev, float max, IntPtr pkelx, IntPtr pkely);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeDoGKernel")]
        internal static extern IntPtr makeDoGKernel(int halfheight, int halfwidth, float stdev, float ratio);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getImagelibVersions")]
        internal static extern IntPtr getImagelibVersions();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listDestroy")]
        internal static extern void listDestroy(HandleRef phead);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listAddToHead")]
        internal static extern int listAddToHead(HandleRef phead, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listAddToTail")]
        internal static extern int listAddToTail(HandleRef phead, IntPtr ptail, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listInsertBefore")]
        internal static extern int listInsertBefore(HandleRef phead, IntPtr elem, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listInsertAfter")]
        internal static extern int listInsertAfter(HandleRef phead, IntPtr elem, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveElement")]
        internal static extern IntPtr listRemoveElement(HandleRef phead, IntPtr elem);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveFromHead")]
        internal static extern IntPtr listRemoveFromHead(HandleRef phead);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveFromTail")]
        internal static extern IntPtr listRemoveFromTail(HandleRef phead, IntPtr ptail);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listFindElement")]
        internal static extern IntPtr listFindElement(HandleRef head, IntPtr data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listFindTail")]
        internal static extern IntPtr listFindTail(HandleRef head);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listGetCount")]
        internal static extern int listGetCount(HandleRef head);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listReverse")]
        internal static extern int listReverse(HandleRef phead);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listJoin")]
        internal static extern int listJoin(HandleRef phead1, IntPtr phead2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapCreate")]
        internal static extern IntPtr l_amapCreate(int keytype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapDestroy")]
        internal static extern void l_amapDestroy(HandleRef pm);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapSize")]
        internal static extern int l_amapSize(HandleRef m);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreate")]
        internal static extern IntPtr l_asetCreate(int keytype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetDestroy")]
        internal static extern void l_asetDestroy(HandleRef ps);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetSize")]
        internal static extern int l_asetSize(HandleRef s);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateBinaryMaze")]
        internal static extern IntPtr generateBinaryMaze(int w, int h, int xi, int yi, float wallps, float ranis);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSearchBinaryMaze")]
        internal static extern IntPtr pixSearchBinaryMaze(HandleRef pixs, int xi, int yi, int xf, int yf, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSearchGrayMaze")]
        internal static extern IntPtr pixSearchGrayMaze(HandleRef pixs, int xi, int yi, int xf, int yf, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilate")]
        internal static extern IntPtr pixDilate(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErode")]
        internal static extern IntPtr pixErode(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHMT")]
        internal static extern IntPtr pixHMT(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpen")]
        internal static extern IntPtr pixOpen(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClose")]
        internal static extern IntPtr pixClose(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafe")]
        internal static extern IntPtr pixCloseSafe(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGeneralized")]
        internal static extern IntPtr pixOpenGeneralized(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGeneralized")]
        internal static extern IntPtr pixCloseGeneralized(HandleRef pixd, IntPtr pixs, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateBrick")]
        internal static extern IntPtr pixDilateBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeBrick")]
        internal static extern IntPtr pixErodeBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenBrick")]
        internal static extern IntPtr pixOpenBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseBrick")]
        internal static extern IntPtr pixCloseBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafeBrick")]
        internal static extern IntPtr pixCloseSafeBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectComposableSels")]
        internal static extern int selectComposableSels(int size, int direction, IntPtr psel1, IntPtr psel2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectComposableSizes")]
        internal static extern int selectComposableSizes(int size, IntPtr pfactor1, IntPtr pfactor2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrick")]
        internal static extern IntPtr pixDilateCompBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrick")]
        internal static extern IntPtr pixErodeCompBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrick")]
        internal static extern IntPtr pixOpenCompBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrick")]
        internal static extern IntPtr pixCloseCompBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafeCompBrick")]
        internal static extern IntPtr pixCloseSafeCompBrick(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "resetMorphBoundaryCondition")]
        internal static extern void resetMorphBoundaryCondition(int bc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getMorphBorderPixelColor")]
        internal static extern uint getMorphBorderPixelColor(int type, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBoundary")]
        internal static extern IntPtr pixExtractBoundary(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceMasked")]
        internal static extern IntPtr pixMorphSequenceMasked(HandleRef pixs, IntPtr pixm, IntPtr sequence, int dispsep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceByComponent")]
        internal static extern IntPtr pixMorphSequenceByComponent(HandleRef pixs, IntPtr sequence, int connectivity, int minw, int minh, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMorphSequenceByComponent")]
        internal static extern IntPtr pixaMorphSequenceByComponent(HandleRef pixas, IntPtr sequence, int minw, int minh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceByRegion")]
        internal static extern IntPtr pixMorphSequenceByRegion(HandleRef pixs, IntPtr pixm, IntPtr sequence, int connectivity, int minw, int minh, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMorphSequenceByRegion")]
        internal static extern IntPtr pixaMorphSequenceByRegion(HandleRef pixs, IntPtr pixam, IntPtr sequence, int minw, int minh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnionOfMorphOps")]
        internal static extern IntPtr pixUnionOfMorphOps(HandleRef pixs, IntPtr sela, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixIntersectionOfMorphOps")]
        internal static extern IntPtr pixIntersectionOfMorphOps(HandleRef pixs, IntPtr sela, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectiveConnCompFill")]
        internal static extern IntPtr pixSelectiveConnCompFill(HandleRef pixs, int connectivity, int minw, int minh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveMatchedPattern")]
        internal static extern int pixRemoveMatchedPattern(HandleRef pixs, IntPtr pixp, IntPtr pixe, int x0, int y0, int dsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayMatchedPattern")]
        internal static extern IntPtr pixDisplayMatchedPattern(HandleRef pixs, IntPtr pixp, IntPtr pixe, int x0, int y0, uint color, float scale, int nlevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendByMorph")]
        internal static extern IntPtr pixaExtendByMorph(HandleRef pixas, int type, int niters, IntPtr sel, int include);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendByScaling")]
        internal static extern IntPtr pixaExtendByScaling(HandleRef pixas, IntPtr nasc, int type, int include);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillMorph")]
        internal static extern IntPtr pixSeedfillMorph(HandleRef pixs, IntPtr pixm, int maxiters, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRunHistogramMorph")]
        internal static extern IntPtr pixRunHistogramMorph(HandleRef pixs, int runtype, int direction, int maxsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTophat")]
        internal static extern IntPtr pixTophat(HandleRef pixs, int hsize, int vsize, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHDome")]
        internal static extern IntPtr pixHDome(HandleRef pixs, int height, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFastTophat")]
        internal static extern IntPtr pixFastTophat(HandleRef pixs, int xsize, int ysize, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphGradient")]
        internal static extern IntPtr pixMorphGradient(HandleRef pixs, int hsize, int vsize, int smoothing);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCentroids")]
        internal static extern IntPtr pixaCentroids(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCentroid")]
        internal static extern int pixCentroid(HandleRef pix, IntPtr centtab, IntPtr sumtab, IntPtr pxave, IntPtr pyave);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateBrickDwa")]
        internal static extern IntPtr pixDilateBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeBrickDwa")]
        internal static extern IntPtr pixErodeBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenBrickDwa")]
        internal static extern IntPtr pixOpenBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseBrickDwa")]
        internal static extern IntPtr pixCloseBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrickDwa")]
        internal static extern IntPtr pixDilateCompBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrickDwa")]
        internal static extern IntPtr pixErodeCompBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrickDwa")]
        internal static extern IntPtr pixOpenCompBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrickDwa")]
        internal static extern IntPtr pixCloseCompBrickDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrickExtendDwa")]
        internal static extern IntPtr pixDilateCompBrickExtendDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrickExtendDwa")]
        internal static extern IntPtr pixErodeCompBrickExtendDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrickExtendDwa")]
        internal static extern IntPtr pixOpenCompBrickExtendDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrickExtendDwa")]
        internal static extern IntPtr pixCloseCompBrickExtendDwa(HandleRef pixd, IntPtr pixs, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getExtendedCompositeParameters")]
        internal static extern int getExtendedCompositeParameters(int size, IntPtr pn, IntPtr pextra, IntPtr pactualsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequence")]
        internal static extern IntPtr pixMorphSequence(HandleRef pixs, IntPtr sequence, int dispsep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphCompSequence")]
        internal static extern IntPtr pixMorphCompSequence(HandleRef pixs, IntPtr sequence, int dispsep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceDwa")]
        internal static extern IntPtr pixMorphSequenceDwa(HandleRef pixs, IntPtr sequence, int dispsep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphCompSequenceDwa")]
        internal static extern IntPtr pixMorphCompSequenceDwa(HandleRef pixs, IntPtr sequence, int dispsep);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "morphSequenceVerify")]
        internal static extern int morphSequenceVerify(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayMorphSequence")]
        internal static extern IntPtr pixGrayMorphSequence(HandleRef pixs, IntPtr sequence, int dispsep, int dispy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMorphSequence")]
        internal static extern IntPtr pixColorMorphSequence(HandleRef pixs, IntPtr sequence, int dispsep, int dispy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreate")]
        internal static extern IntPtr numaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromIArray")]
        internal static extern IntPtr numaCreateFromIArray(HandleRef iarray, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromFArray")]
        internal static extern IntPtr numaCreateFromFArray(HandleRef farray, int size, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromString")]
        internal static extern IntPtr numaCreateFromString(HandleRef str);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDestroy")]
        internal static extern void numaDestroy(HandleRef pna);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCopy")]
        internal static extern IntPtr numaCopy(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClone")]
        internal static extern IntPtr numaClone(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEmpty")]
        internal static extern int numaEmpty(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddNumber")]
        internal static extern int numaAddNumber(HandleRef na, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInsertNumber")]
        internal static extern int numaInsertNumber(HandleRef na, int index, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRemoveNumber")]
        internal static extern int numaRemoveNumber(HandleRef na, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReplaceNumber")]
        internal static extern int numaReplaceNumber(HandleRef na, int index, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetCount")]
        internal static extern int numaGetCount(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetCount")]
        internal static extern int numaSetCount(HandleRef na, int newcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetFValue")]
        internal static extern int numaGetFValue(HandleRef na, int index, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetIValue")]
        internal static extern int numaGetIValue(HandleRef na, int index, IntPtr pival);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetValue")]
        internal static extern int numaSetValue(HandleRef na, int index, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaShiftValue")]
        internal static extern int numaShiftValue(HandleRef na, int index, float diff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetIArray")]
        internal static extern IntPtr numaGetIArray(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetFArray")]
        internal static extern IntPtr numaGetFArray(HandleRef na, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRefcount")]
        internal static extern int numaGetRefcount(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaChangeRefcount")]
        internal static extern int numaChangeRefcount(HandleRef na, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetParameters")]
        internal static extern int numaGetParameters(HandleRef na, IntPtr pstartx, IntPtr pdelx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetParameters")]
        internal static extern int numaSetParameters(HandleRef na, float startx, float delx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCopyParameters")]
        internal static extern int numaCopyParameters(HandleRef nad, IntPtr nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToSarray")]
        internal static extern IntPtr numaConvertToSarray(HandleRef na, int size1, int size2, int addzeros, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRead")]
        internal static extern IntPtr numaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReadStream")]
        internal static extern IntPtr numaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReadMem")]
        internal static extern IntPtr numaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWrite")]
        internal static extern int numaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWriteStream")]
        internal static extern int numaWriteStream(HandleRef fp, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWriteMem")]
        internal static extern int numaWriteMem(HandleRef pdata, IntPtr psize, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCreate")]
        internal static extern IntPtr numaaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCreateFull")]
        internal static extern IntPtr numaaCreateFull(int nptr, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaTruncate")]
        internal static extern int numaaTruncate(HandleRef naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaDestroy")]
        internal static extern void numaaDestroy(HandleRef pnaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaAddNuma")]
        internal static extern int numaaAddNuma(HandleRef naa, IntPtr na, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetCount")]
        internal static extern int numaaGetCount(HandleRef naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNumaCount")]
        internal static extern int numaaGetNumaCount(HandleRef naa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNumberCount")]
        internal static extern int numaaGetNumberCount(HandleRef naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetPtrArray")]
        internal static extern IntPtr numaaGetPtrArray(HandleRef naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNuma")]
        internal static extern IntPtr numaaGetNuma(HandleRef naa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReplaceNuma")]
        internal static extern int numaaReplaceNuma(HandleRef naa, int index, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetValue")]
        internal static extern int numaaGetValue(HandleRef naa, int i, int j, IntPtr pfval, IntPtr pival);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaAddNumber")]
        internal static extern int numaaAddNumber(HandleRef naa, int index, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaRead")]
        internal static extern IntPtr numaaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReadStream")]
        internal static extern IntPtr numaaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReadMem")]
        internal static extern IntPtr numaaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWrite")]
        internal static extern int numaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWriteStream")]
        internal static extern int numaaWriteStream(HandleRef fp, IntPtr naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWriteMem")]
        internal static extern int numaaWriteMem(HandleRef pdata, IntPtr psize, IntPtr naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaArithOp")]
        internal static extern IntPtr numaArithOp(HandleRef nad, IntPtr na1, IntPtr na2, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaLogicalOp")]
        internal static extern IntPtr numaLogicalOp(HandleRef nad, IntPtr na1, IntPtr na2, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInvert")]
        internal static extern IntPtr numaInvert(HandleRef nad, IntPtr nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSimilar")]
        internal static extern int numaSimilar(HandleRef na1, IntPtr na2, float maxdiff, IntPtr psimilar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddToNumber")]
        internal static extern int numaAddToNumber(HandleRef na, int index, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMin")]
        internal static extern int numaGetMin(HandleRef na, IntPtr pminval, IntPtr piminloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMax")]
        internal static extern int numaGetMax(HandleRef na, IntPtr pmaxval, IntPtr pimaxloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSum")]
        internal static extern int numaGetSum(HandleRef na, IntPtr psum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetPartialSums")]
        internal static extern IntPtr numaGetPartialSums(HandleRef na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSumOnInterval")]
        internal static extern int numaGetSumOnInterval(HandleRef na, int first, int last, IntPtr psum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHasOnlyIntegers")]
        internal static extern int numaHasOnlyIntegers(HandleRef na, int maxsamples, IntPtr pallints);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSubsample")]
        internal static extern IntPtr numaSubsample(HandleRef nas, int subfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeDelta")]
        internal static extern IntPtr numaMakeDelta(HandleRef nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeSequence")]
        internal static extern IntPtr numaMakeSequence(float startval, float increment, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeConstant")]
        internal static extern IntPtr numaMakeConstant(float val, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeAbsValue")]
        internal static extern IntPtr numaMakeAbsValue(HandleRef nad, IntPtr nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddBorder")]
        internal static extern IntPtr numaAddBorder(HandleRef nas, int left, int right, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddSpecifiedBorder")]
        internal static extern IntPtr numaAddSpecifiedBorder(HandleRef nas, int left, int right, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRemoveBorder")]
        internal static extern IntPtr numaRemoveBorder(HandleRef nas, int left, int right);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetNonzeroRange")]
        internal static extern int numaGetNonzeroRange(HandleRef na, float eps, IntPtr pfirst, IntPtr plast);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetCountRelativeToZero")]
        internal static extern int numaGetCountRelativeToZero(HandleRef na, int type, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClipToInterval")]
        internal static extern IntPtr numaClipToInterval(HandleRef nas, int first, int last);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeThresholdIndicator")]
        internal static extern IntPtr numaMakeThresholdIndicator(HandleRef nas, float thresh, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaUniformSampling")]
        internal static extern IntPtr numaUniformSampling(HandleRef nas, int nsamp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReverse")]
        internal static extern IntPtr numaReverse(HandleRef nad, IntPtr nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaLowPassIntervals")]
        internal static extern IntPtr numaLowPassIntervals(HandleRef nas, float thresh, float maxn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaThresholdEdges")]
        internal static extern IntPtr numaThresholdEdges(HandleRef nas, float thresh1, float thresh2, float maxn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSpanValues")]
        internal static extern int numaGetSpanValues(HandleRef na, int span, IntPtr pstart, IntPtr pend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetEdgeValues")]
        internal static extern int numaGetEdgeValues(HandleRef na, int edge, IntPtr pstart, IntPtr pend, IntPtr psign);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateEqxVal")]
        internal static extern int numaInterpolateEqxVal(float startx, float deltax, IntPtr nay, int type, float xval, IntPtr pyval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateArbxVal")]
        internal static extern int numaInterpolateArbxVal(HandleRef nax, IntPtr nay, int type, float xval, IntPtr pyval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateEqxInterval")]
        internal static extern int numaInterpolateEqxInterval(float startx, float deltax, IntPtr nasy, int type, float x0, float x1, int npts, IntPtr pnax, IntPtr pnay);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateArbxInterval")]
        internal static extern int numaInterpolateArbxInterval(HandleRef nax, IntPtr nay, int type, float x0, float x1, int npts, IntPtr pnadx, IntPtr pnady);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFitMax")]
        internal static extern int numaFitMax(HandleRef na, IntPtr pmaxval, IntPtr naloc, IntPtr pmaxloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDifferentiateInterval")]
        internal static extern int numaDifferentiateInterval(HandleRef nax, IntPtr nay, float x0, float x1, int npts, IntPtr pnadx, IntPtr pnady);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaIntegrateInterval")]
        internal static extern int numaIntegrateInterval(HandleRef nax, IntPtr nay, float x0, float x1, int npts, IntPtr psum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortGeneral")]
        internal static extern int numaSortGeneral(HandleRef na, IntPtr pnasort, IntPtr pnaindex, IntPtr pnainvert, int sortorder, int sorttype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortAutoSelect")]
        internal static extern IntPtr numaSortAutoSelect(HandleRef nas, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortIndexAutoSelect")]
        internal static extern IntPtr numaSortIndexAutoSelect(HandleRef nas, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaChooseSortType")]
        internal static extern int numaChooseSortType(HandleRef nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSort")]
        internal static extern IntPtr numaSort(HandleRef naout, IntPtr nain, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaBinSort")]
        internal static extern IntPtr numaBinSort(HandleRef nas, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSortIndex")]
        internal static extern IntPtr numaGetSortIndex(HandleRef na, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetBinSortIndex")]
        internal static extern IntPtr numaGetBinSortIndex(HandleRef nas, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortByIndex")]
        internal static extern IntPtr numaSortByIndex(HandleRef nas, IntPtr naindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaIsSorted")]
        internal static extern int numaIsSorted(HandleRef nas, int sortorder, IntPtr psorted);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortPair")]
        internal static extern int numaSortPair(HandleRef nax, IntPtr nay, int sortorder, IntPtr pnasx, IntPtr pnasy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInvertMap")]
        internal static extern IntPtr numaInvertMap(HandleRef nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaPseudorandomSequence")]
        internal static extern IntPtr numaPseudorandomSequence(int size, int seed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRandomPermutation")]
        internal static extern IntPtr numaRandomPermutation(HandleRef nas, int seed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRankValue")]
        internal static extern int numaGetRankValue(HandleRef na, float fract, IntPtr nasort, int usebins, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMedian")]
        internal static extern int numaGetMedian(HandleRef na, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetBinnedMedian")]
        internal static extern int numaGetBinnedMedian(HandleRef na, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMode")]
        internal static extern int numaGetMode(HandleRef na, IntPtr pval, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMedianVariation")]
        internal static extern int numaGetMedianVariation(HandleRef na, IntPtr pmedval, IntPtr pmedvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaJoin")]
        internal static extern int numaJoin(HandleRef nad, IntPtr nas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaJoin")]
        internal static extern int numaaJoin(HandleRef naad, IntPtr naas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaFlattenToNuma")]
        internal static extern IntPtr numaaFlattenToNuma(HandleRef naa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaErode")]
        internal static extern IntPtr numaErode(HandleRef nas, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDilate")]
        internal static extern IntPtr numaDilate(HandleRef nas, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaOpen")]
        internal static extern IntPtr numaOpen(HandleRef nas, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClose")]
        internal static extern IntPtr numaClose(HandleRef nas, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaTransform")]
        internal static extern IntPtr numaTransform(HandleRef nas, float shift, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSimpleStats")]
        internal static extern int numaSimpleStats(HandleRef na, int first, int last, IntPtr pmean, IntPtr pvar, IntPtr prvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedStats")]
        internal static extern int numaWindowedStats(HandleRef nas, int wc, IntPtr pnam, IntPtr pnams, IntPtr pnav, IntPtr pnarv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMean")]
        internal static extern IntPtr numaWindowedMean(HandleRef nas, int wc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMeanSquare")]
        internal static extern IntPtr numaWindowedMeanSquare(HandleRef nas, int wc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedVariance")]
        internal static extern int numaWindowedVariance(HandleRef nam, IntPtr nams, IntPtr pnav, IntPtr pnarv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMedian")]
        internal static extern IntPtr numaWindowedMedian(HandleRef nas, int halfwin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToInt")]
        internal static extern IntPtr numaConvertToInt(HandleRef nas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogram")]
        internal static extern IntPtr numaMakeHistogram(HandleRef na, int maxbins, IntPtr pbinsize, IntPtr pbinstart);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogramAuto")]
        internal static extern IntPtr numaMakeHistogramAuto(HandleRef na, int maxbins);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogramClipped")]
        internal static extern IntPtr numaMakeHistogramClipped(HandleRef na, float binsize, float maxsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRebinHistogram")]
        internal static extern IntPtr numaRebinHistogram(HandleRef nas, int newsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaNormalizeHistogram")]
        internal static extern IntPtr numaNormalizeHistogram(HandleRef nas, float tsum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetStatsUsingHistogram")]
        internal static extern int numaGetStatsUsingHistogram(HandleRef na, int maxbins, IntPtr pmin, IntPtr pmax, IntPtr pmean, IntPtr pvariance, IntPtr pmedian, float rank, IntPtr prval, IntPtr phisto);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetHistogramStats")]
        internal static extern int numaGetHistogramStats(HandleRef nahisto, float startx, float deltax, IntPtr pxmean, IntPtr pxmedian, IntPtr pxmode, IntPtr pxvariance);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetHistogramStatsOnInterval")]
        internal static extern int numaGetHistogramStatsOnInterval(HandleRef nahisto, float startx, float deltax, int ifirst, int ilast, IntPtr pxmean, IntPtr pxmedian, IntPtr pxmode, IntPtr pxvariance);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeRankFromHistogram")]
        internal static extern int numaMakeRankFromHistogram(float startx, float deltax, IntPtr nasy, int npts, IntPtr pnax, IntPtr pnay);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHistogramGetRankFromVal")]
        internal static extern int numaHistogramGetRankFromVal(HandleRef na, float rval, IntPtr prank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHistogramGetValFromRank")]
        internal static extern int numaHistogramGetValFromRank(HandleRef na, float rank, IntPtr prval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDiscretizeRankAndIntensity")]
        internal static extern int numaDiscretizeRankAndIntensity(HandleRef na, int nbins, IntPtr pnarbin, IntPtr pnam, IntPtr pnar, IntPtr pnabb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRankBinValues")]
        internal static extern int numaGetRankBinValues(HandleRef na, int nbins, IntPtr pnarbin, IntPtr pnam);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSplitDistribution")]
        internal static extern int numaSplitDistribution(HandleRef na, float scorefract, IntPtr psplitindex, IntPtr pave1, IntPtr pave2, IntPtr pnum1, IntPtr pnum2, IntPtr pnascore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "grayHistogramsToEMD")]
        internal static extern int grayHistogramsToEMD(HandleRef naa1, IntPtr naa2, IntPtr pnad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEarthMoverDistance")]
        internal static extern int numaEarthMoverDistance(HandleRef na1, IntPtr na2, IntPtr pdist);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "grayInterHistogramStats")]
        internal static extern int grayInterHistogramStats(HandleRef naa, int wc, IntPtr pnam, IntPtr pnams, IntPtr pnav, IntPtr pnarv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFindPeaks")]
        internal static extern IntPtr numaFindPeaks(HandleRef nas, int nmax, float fract1, float fract2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFindExtrema")]
        internal static extern IntPtr numaFindExtrema(HandleRef nas, float delta, IntPtr pnav);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCountReversals")]
        internal static extern int numaCountReversals(HandleRef nas, float minreversal, IntPtr pnr, IntPtr pnrpl);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSelectCrossingThreshold")]
        internal static extern int numaSelectCrossingThreshold(HandleRef nax, IntPtr nay, float estthresh, IntPtr pbestthresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCrossingsByThreshold")]
        internal static extern IntPtr numaCrossingsByThreshold(HandleRef nax, IntPtr nay, float thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCrossingsByPeaks")]
        internal static extern IntPtr numaCrossingsByPeaks(HandleRef nax, IntPtr nay, float delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEvalBestHaarParameters")]
        internal static extern int numaEvalBestHaarParameters(HandleRef nas, float relweight, int nwidth, int nshift, float minwidth, float maxwidth, IntPtr pbestwidth, IntPtr pbestshift, IntPtr pbestscore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEvalHaarSum")]
        internal static extern int numaEvalHaarSum(HandleRef nas, float width, float shift, float relweight, IntPtr pscore);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genConstrainedNumaInRange")]
        internal static extern IntPtr genConstrainedNumaInRange(int first, int last, int nmax, int use_pairs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRegionsBinary")]
        internal static extern int pixGetRegionsBinary(HandleRef pixs, IntPtr ppixhm, IntPtr ppixtm, IntPtr ppixtb, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenHalftoneMask")]
        internal static extern IntPtr pixGenHalftoneMask(HandleRef pixs, IntPtr ppixtext, IntPtr phtfound, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateHalftoneMask")]
        internal static extern IntPtr pixGenerateHalftoneMask(HandleRef pixs, IntPtr ppixtext, IntPtr phtfound, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenTextlineMask")]
        internal static extern IntPtr pixGenTextlineMask(HandleRef pixs, IntPtr ppixvws, IntPtr ptlfound, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenTextblockMask")]
        internal static extern IntPtr pixGenTextblockMask(HandleRef pixs, IntPtr pixvws, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPageForeground")]
        internal static extern IntPtr pixFindPageForeground(HandleRef pixs, int threshold, int mindist, int erasedist, int pagenum, int showmorph, int display, IntPtr pdfdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitIntoCharacters")]
        internal static extern int pixSplitIntoCharacters(HandleRef pixs, int minw, int minh, IntPtr pboxa, IntPtr ppixa, IntPtr ppixdebug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitComponentWithProfile")]
        internal static extern IntPtr pixSplitComponentWithProfile(HandleRef pixs, int delta, int mindel, IntPtr ppixdebug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractTextlines")]
        internal static extern IntPtr pixExtractTextlines(HandleRef pixs, int maxw, int maxh, int minw, int minh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDecideIfText")]
        internal static extern int pixDecideIfText(HandleRef pixs, IntPtr box, IntPtr pistext, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindThreshFgExtent")]
        internal static extern int pixFindThreshFgExtent(HandleRef pixs, int thresh, IntPtr ptop, IntPtr pbot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountTextColumns")]
        internal static extern int pixCountTextColumns(HandleRef pixs, float deltafract, float peakfract, float clipfract, IntPtr pncols, IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEstimateBackground")]
        internal static extern int pixEstimateBackground(HandleRef pixs, int darkthresh, float edgecrop, IntPtr pbg);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindLargeRectangles")]
        internal static extern int pixFindLargeRectangles(HandleRef pixs, int polarity, int nrect, IntPtr pboxa, IntPtr ppixdb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindLargestRectangle")]
        internal static extern int pixFindLargestRectangle(HandleRef pixs, int polarity, IntPtr pbox, IntPtr ppixdb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSelectCmap")]
        internal static extern int pixSetSelectCmap(HandleRef pixs, IntPtr box, int sindex, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayRegionsCmap")]
        internal static extern int pixColorGrayRegionsCmap(HandleRef pixs, IntPtr boxa, int type, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayCmap")]
        internal static extern int pixColorGrayCmap(HandleRef pixs, IntPtr box, int type, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayMaskedCmap")]
        internal static extern int pixColorGrayMaskedCmap(HandleRef pixs, IntPtr pixm, int type, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "addColorizedGrayToCmap")]
        internal static extern int addColorizedGrayToCmap(HandleRef cmap, int type, int rval, int gval, int bval, IntPtr pna);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSelectMaskedCmap")]
        internal static extern int pixSetSelectMaskedCmap(HandleRef pixs, IntPtr pixm, int x, int y, int sindex, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMaskedCmap")]
        internal static extern int pixSetMaskedCmap(HandleRef pixs, IntPtr pixm, int x, int y, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "parseForProtos")]
        internal static extern IntPtr parseForProtos(HandleRef filein, IntPtr prestring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetWhiteblocks")]
        internal static extern IntPtr boxaGetWhiteblocks(HandleRef boxas, IntPtr box, int sortflag, int maxboxes, float maxoverlap, int maxperim, float fract, int maxpops);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPruneSortedOnOverlap")]
        internal static extern IntPtr boxaPruneSortedOnOverlap(HandleRef boxas, float maxoverlap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesToPdf")]
        internal static extern int convertFilesToPdf(HandleRef dirname, IntPtr substr, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertFilesToPdf")]
        internal static extern int saConvertFilesToPdf(HandleRef sa, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertFilesToPdfData")]
        internal static extern int saConvertFilesToPdfData(HandleRef sa, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectDefaultPdfEncoding")]
        internal static extern int selectDefaultPdfEncoding(HandleRef pix, IntPtr ptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertUnscaledFilesToPdf")]
        internal static extern int convertUnscaledFilesToPdf(HandleRef dirname, IntPtr substr, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertUnscaledFilesToPdf")]
        internal static extern int saConvertUnscaledFilesToPdf(HandleRef sa, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertUnscaledFilesToPdfData")]
        internal static extern int saConvertUnscaledFilesToPdfData(HandleRef sa, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertUnscaledToPdfData")]
        internal static extern int convertUnscaledToPdfData(HandleRef fname, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToPdf")]
        internal static extern int pixaConvertToPdf(HandleRef pixa, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToPdfData")]
        internal static extern int pixaConvertToPdfData(HandleRef pixa, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdf")]
        internal static extern int convertToPdf(HandleRef filein, int type, int quality, IntPtr fileout, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertImageDataToPdf")]
        internal static extern int convertImageDataToPdf(HandleRef imdata, IntPtr size, int type, int quality, IntPtr fileout, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfData")]
        internal static extern int convertToPdfData(HandleRef filein, int type, int quality, IntPtr pdata, IntPtr pnbytes, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertImageDataToPdfData")]
        internal static extern int convertImageDataToPdfData(HandleRef imdata, IntPtr size, int type, int quality, IntPtr pdata, IntPtr pnbytes, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdf")]
        internal static extern int pixConvertToPdf(HandleRef pix, int type, int quality, IntPtr fileout, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPdf")]
        internal static extern int pixWriteStreamPdf(HandleRef fp, IntPtr pix, int res, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPdf")]
        internal static extern int pixWriteMemPdf(HandleRef pdata, IntPtr pnbytes, IntPtr pix, int res, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSegmentedFilesToPdf")]
        internal static extern int convertSegmentedFilesToPdf(HandleRef dirname, IntPtr substr, int res, int type, int thresh, IntPtr baa, int quality, float scalefactor, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertNumberedMasksToBoxaa")]
        internal static extern IntPtr convertNumberedMasksToBoxaa(HandleRef dirname, IntPtr substr, int numpre, int numpost);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfSegmented")]
        internal static extern int convertToPdfSegmented(HandleRef filein, int res, int type, int thresh, IntPtr boxa, int quality, float scalefactor, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfSegmented")]
        internal static extern int pixConvertToPdfSegmented(HandleRef pixs, int res, int type, int thresh, IntPtr boxa, int quality, float scalefactor, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfDataSegmented")]
        internal static extern int convertToPdfDataSegmented(HandleRef filein, int res, int type, int thresh, IntPtr boxa, int quality, float scalefactor, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfDataSegmented")]
        internal static extern int pixConvertToPdfDataSegmented(HandleRef pixs, int res, int type, int thresh, IntPtr boxa, int quality, float scalefactor, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "concatenatePdf")]
        internal static extern int concatenatePdf(HandleRef dirname, IntPtr substr, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConcatenatePdf")]
        internal static extern int saConcatenatePdf(HandleRef sa, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraConcatenatePdf")]
        internal static extern int ptraConcatenatePdf(HandleRef pa, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "concatenatePdfToData")]
        internal static extern int concatenatePdfToData(HandleRef dirname, IntPtr substr, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConcatenatePdfToData")]
        internal static extern int saConcatenatePdfToData(HandleRef sa, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfData")]
        internal static extern int pixConvertToPdfData(HandleRef pix, int type, int quality, IntPtr pdata, IntPtr pnbytes, int x, int y, int res, IntPtr title, IntPtr plpd, int position);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraConcatenatePdfToData")]
        internal static extern int ptraConcatenatePdfToData(HandleRef pa_data, IntPtr sa, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertTiffMultipageToPdf")]
        internal static extern int convertTiffMultipageToPdf(HandleRef filein, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateCIDataForPdf")]
        internal static extern int l_generateCIDataForPdf(HandleRef fname, IntPtr pix, int quality, IntPtr pcid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateFlateDataPdf")]
        internal static extern IntPtr l_generateFlateDataPdf(HandleRef fname, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateJpegData")]
        internal static extern IntPtr l_generateJpegData(HandleRef fname, int ascii85flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateCIData")]
        internal static extern int l_generateCIData(HandleRef fname, int type, int quality, int ascii85, IntPtr pcid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateCIData")]
        internal static extern int pixGenerateCIData(HandleRef pixs, int type, int quality, int ascii85, IntPtr pcid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateFlateData")]
        internal static extern IntPtr l_generateFlateData(HandleRef fname, int ascii85flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateG4Data")]
        internal static extern IntPtr l_generateG4Data(HandleRef fname, int ascii85flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cidConvertToPdfData")]
        internal static extern int cidConvertToPdfData(HandleRef cid, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_CIDataDestroy")]
        internal static extern void l_CIDataDestroy(HandleRef pcid);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pdfSetG4ImageMask")]
        internal static extern void l_pdfSetG4ImageMask(int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pdfSetDateAndVersion")]
        internal static extern void l_pdfSetDateAndVersion(int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateNoInit")]
        internal static extern IntPtr pixCreateNoInit(int width, int height, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateTemplate")]
        internal static extern IntPtr pixCreateTemplate(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateTemplateNoInit")]
        internal static extern IntPtr pixCreateTemplateNoInit(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateHeader")]
        internal static extern IntPtr pixCreateHeader(int width, int height, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixResizeImageData")]
        internal static extern int pixResizeImageData(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyColormap")]
        internal static extern int pixCopyColormap(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSizesEqual")]
        internal static extern int pixSizesEqual(Pix pix1, HandleRef pix2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTransferAllData")]
        internal static extern int pixTransferAllData(HandleRef pixd, IntPtr ppixs, int copytext, int copyformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSwapAndDestroy")]
        internal static extern int pixSwapAndDestroy(Pix ppixd, HandleRef ppixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWidth")]
        internal static extern int pixGetWidth(Pix pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDimensions")]
        internal static extern int pixGetDimensions(HandleRef pix, IntPtr pw, IntPtr ph, IntPtr pd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetDimensions")]
        internal static extern int pixSetDimensions(HandleRef pix, int w, int h, int d);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyDimensions")]
        internal static extern int pixCopyDimensions(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopySpp")]
        internal static extern int pixCopySpp(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetResolution")]
        internal static extern int pixGetResolution(HandleRef pix, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetResolution")]
        internal static extern int pixSetResolution(HandleRef pix, int xres, int yres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyResolution")]
        internal static extern int pixCopyResolution(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleResolution")]
        internal static extern int pixScaleResolution(HandleRef pix, float xscale, float yscale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInputFormat")]
        internal static extern int pixSetInputFormat(HandleRef pix, int informat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyInputFormat")]
        internal static extern int pixCopyInputFormat(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSpecial")]
        internal static extern int pixSetSpecial(HandleRef pix, int special);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetText")]
        internal static extern int pixSetText(HandleRef pix, IntPtr textstring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddText")]
        internal static extern int pixAddText(HandleRef pix, IntPtr textstring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyText")]
        internal static extern int pixCopyText(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetData")]
        internal static extern IntPtr pixGetData(Pix pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractData")]
        internal static extern IntPtr pixExtractData(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFreeData")]
        internal static extern int pixFreeData(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLinePtrs")]
        internal static extern IntPtr pixGetLinePtrs(HandleRef pix, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPrintStreamInfo")]
        internal static extern int pixPrintStreamInfo(HandleRef fp, IntPtr pix, IntPtr text);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPixel")]
        internal static extern int pixGetPixel(HandleRef pix, int x, int y, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPixel")]
        internal static extern int pixSetPixel(HandleRef pix, int x, int y, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBPixel")]
        internal static extern int pixGetRGBPixel(HandleRef pix, int x, int y, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetRGBPixel")]
        internal static extern int pixSetRGBPixel(HandleRef pix, int x, int y, int rval, int gval, int bval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRandomPixel")]
        internal static extern int pixGetRandomPixel(HandleRef pix, IntPtr pval, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearPixel")]
        internal static extern int pixClearPixel(HandleRef pix, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipPixel")]
        internal static extern int pixFlipPixel(HandleRef pix, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setPixelLow")]
        internal static extern void setPixelLow(HandleRef line, int x, int depth, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBlackOrWhiteVal")]
        internal static extern int pixGetBlackOrWhiteVal(HandleRef pixs, int op, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearAll")]
        internal static extern int pixClearAll(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAll")]
        internal static extern int pixSetAll(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAllGray")]
        internal static extern int pixSetAllGray(HandleRef pix, int grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAllArbitrary")]
        internal static extern int pixSetAllArbitrary(HandleRef pix, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBlackOrWhite")]
        internal static extern int pixSetBlackOrWhite(HandleRef pixs, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetComponentArbitrary")]
        internal static extern int pixSetComponentArbitrary(HandleRef pix, int comp, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearInRect")]
        internal static extern int pixClearInRect(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInRect")]
        internal static extern int pixSetInRect(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInRectArbitrary")]
        internal static extern int pixSetInRectArbitrary(HandleRef pix, IntPtr box, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendInRect")]
        internal static extern int pixBlendInRect(HandleRef pixs, IntPtr box, uint val, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPadBits")]
        internal static extern int pixSetPadBits(HandleRef pix, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPadBitsBand")]
        internal static extern int pixSetPadBitsBand(HandleRef pix, int by, int bh, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetOrClearBorder")]
        internal static extern int pixSetOrClearBorder(HandleRef pixs, int left, int right, int top, int bot, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBorderVal")]
        internal static extern int pixSetBorderVal(HandleRef pixs, int left, int right, int top, int bot, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBorderRingVal")]
        internal static extern int pixSetBorderRingVal(HandleRef pixs, int dist, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMirroredBorder")]
        internal static extern int pixSetMirroredBorder(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyBorder")]
        internal static extern IntPtr pixCopyBorder(HandleRef pixd, IntPtr pixs, int left, int right, int top, int bot);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBlackOrWhiteBorder")]
        internal static extern IntPtr pixAddBlackOrWhiteBorder(HandleRef pixs, int left, int right, int top, int bot, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBorderGeneral")]
        internal static extern IntPtr pixAddBorderGeneral(HandleRef pixs, int left, int right, int top, int bot, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorder")]
        internal static extern IntPtr pixRemoveBorder(HandleRef pixs, int npix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderGeneral")]
        internal static extern IntPtr pixRemoveBorderGeneral(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderToSize")]
        internal static extern IntPtr pixRemoveBorderToSize(HandleRef pixs, int wd, int hd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMirroredBorder")]
        internal static extern IntPtr pixAddMirroredBorder(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddRepeatedBorder")]
        internal static extern IntPtr pixAddRepeatedBorder(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMixedBorder")]
        internal static extern IntPtr pixAddMixedBorder(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddContinuedBorder")]
        internal static extern IntPtr pixAddContinuedBorder(HandleRef pixs, int left, int right, int top, int bot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixShiftAndTransferAlpha")]
        internal static extern int pixShiftAndTransferAlpha(HandleRef pixd, IntPtr pixs, float shiftx, float shifty);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayLayersRGBA")]
        internal static extern IntPtr pixDisplayLayersRGBA(HandleRef pixs, uint val, int maxw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateRGBImage")]
        internal static extern IntPtr pixCreateRGBImage(HandleRef pixr, IntPtr pixg, IntPtr pixb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBComponent")]
        internal static extern IntPtr pixGetRGBComponent(HandleRef pixs, int comp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetRGBComponent")]
        internal static extern int pixSetRGBComponent(HandleRef pixd, IntPtr pixs, int comp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBComponentCmap")]
        internal static extern IntPtr pixGetRGBComponentCmap(HandleRef pixs, int comp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyRGBComponent")]
        internal static extern int pixCopyRGBComponent(HandleRef pixd, IntPtr pixs, int comp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "composeRGBPixel")]
        internal static extern int composeRGBPixel(int rval, int gval, int bval, IntPtr ppixel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "composeRGBAPixel")]
        internal static extern int composeRGBAPixel(int rval, int gval, int bval, int aval, IntPtr ppixel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractRGBValues")]
        internal static extern void extractRGBValues(uint pixel, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractRGBAValues")]
        internal static extern void extractRGBAValues(uint pixel, IntPtr prval, IntPtr pgval, IntPtr pbval, IntPtr paval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractMinMaxComponent")]
        internal static extern int extractMinMaxComponent(uint pixel, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBLine")]
        internal static extern int pixGetRGBLine(HandleRef pixs, int row, IntPtr bufr, IntPtr bufg, IntPtr bufb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianByteSwapNew")]
        internal static extern IntPtr pixEndianByteSwapNew(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianByteSwap")]
        internal static extern int pixEndianByteSwap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lineEndianByteSwap")]
        internal static extern int lineEndianByteSwap(HandleRef datad, IntPtr datas, int wpl);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianTwoByteSwapNew")]
        internal static extern IntPtr pixEndianTwoByteSwapNew(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianTwoByteSwap")]
        internal static extern int pixEndianTwoByteSwap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRasterData")]
        internal static extern int pixGetRasterData(HandleRef pixs, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAlphaIsOpaque")]
        internal static extern int pixAlphaIsOpaque(HandleRef pix, IntPtr popaque);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetupByteProcessing")]
        internal static extern IntPtr pixSetupByteProcessing(HandleRef pix, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCleanupByteProcessing")]
        internal static extern int pixCleanupByteProcessing(HandleRef pix, IntPtr lineptrs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setAlphaMaskBorder")]
        internal static extern void l_setAlphaMaskBorder(float val1, float val2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMasked")]
        internal static extern int pixSetMasked(HandleRef pixd, IntPtr pixm, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMaskedGeneral")]
        internal static extern int pixSetMaskedGeneral(HandleRef pixd, IntPtr pixm, uint val, int x, int y);






        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintSelfThroughMask")]
        internal static extern int pixPaintSelfThroughMask(HandleRef pixd, IntPtr pixm, int x, int y, int searchdir, int mindist, int tilesize, int ntiles, int distblend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeMaskFromVal")]
        internal static extern IntPtr pixMakeMaskFromVal(HandleRef pixs, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeMaskFromLUT")]
        internal static extern IntPtr pixMakeMaskFromLUT(HandleRef pixs, IntPtr tab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetUnderTransparency")]
        internal static extern IntPtr pixSetUnderTransparency(HandleRef pixs, uint val, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeAlphaFromMask")]
        internal static extern IntPtr pixMakeAlphaFromMask(HandleRef pixs, int dist, IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorNearMaskBoundary")]
        internal static extern int pixGetColorNearMaskBoundary(HandleRef pixs, IntPtr pixm, IntPtr box, int dist, IntPtr pval, int debug);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOr")]
        internal static extern IntPtr pixOr(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAnd")]
        internal static extern IntPtr pixAnd(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixXor")]
        internal static extern IntPtr pixXor(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubtract")]
        internal static extern IntPtr pixSubtract(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixZero")]
        internal static extern int pixZero(HandleRef pix, IntPtr pempty);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixForegroundFraction")]
        internal static extern int pixForegroundFraction(HandleRef pix, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCountPixels")]
        internal static extern IntPtr pixaCountPixels(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixels")]
        internal static extern int pixCountPixels(HandleRef pix, IntPtr pcount, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountByRow")]
        internal static extern IntPtr pixCountByRow(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountByColumn")]
        internal static extern IntPtr pixCountByColumn(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsByRow")]
        internal static extern IntPtr pixCountPixelsByRow(HandleRef pix, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsByColumn")]
        internal static extern IntPtr pixCountPixelsByColumn(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsInRow")]
        internal static extern int pixCountPixelsInRow(HandleRef pix, int row, IntPtr pcount, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMomentByColumn")]
        internal static extern IntPtr pixGetMomentByColumn(HandleRef pix, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdPixelSum")]
        internal static extern int pixThresholdPixelSum(HandleRef pix, int thresh, IntPtr pabove, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePixelSumTab8")]
        internal static extern IntPtr makePixelSumTab8(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePixelCentroidTab8")]
        internal static extern IntPtr makePixelCentroidTab8(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageByRow")]
        internal static extern IntPtr pixAverageByRow(HandleRef pix, IntPtr box, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageByColumn")]
        internal static extern IntPtr pixAverageByColumn(HandleRef pix, IntPtr box, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageInRect")]
        internal static extern int pixAverageInRect(HandleRef pix, IntPtr box, IntPtr pave);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceByRow")]
        internal static extern IntPtr pixVarianceByRow(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceByColumn")]
        internal static extern IntPtr pixVarianceByColumn(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceInRect")]
        internal static extern int pixVarianceInRect(HandleRef pix, IntPtr box, IntPtr prootvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffByRow")]
        internal static extern IntPtr pixAbsDiffByRow(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffByColumn")]
        internal static extern IntPtr pixAbsDiffByColumn(HandleRef pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffInRect")]
        internal static extern int pixAbsDiffInRect(HandleRef pix, IntPtr box, int dir, IntPtr pabsdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffOnLine")]
        internal static extern int pixAbsDiffOnLine(HandleRef pix, int x1, int y1, int x2, int y2, IntPtr pabsdiff);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountArbInRect")]
        internal static extern int pixCountArbInRect(HandleRef pixs, IntPtr box, int val, int factor, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirroredTiling")]
        internal static extern IntPtr pixMirroredTiling(HandleRef pixs, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindRepCloseTile")]
        internal static extern int pixFindRepCloseTile(HandleRef pixs, IntPtr box, int searchdir, int mindist, int tsize, int ntiles, IntPtr pboxtile, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogram")]
        internal static extern IntPtr pixGetGrayHistogram(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramMasked")]
        internal static extern IntPtr pixGetGrayHistogramMasked(HandleRef pixs, IntPtr pixm, int x, int y, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramInRect")]
        internal static extern IntPtr pixGetGrayHistogramInRect(HandleRef pixs, IntPtr box, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramTiled")]
        internal static extern IntPtr pixGetGrayHistogramTiled(HandleRef pixs, int factor, int nx, int ny);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorHistogram")]
        internal static extern int pixGetColorHistogram(HandleRef pixs, int factor, IntPtr pnar, IntPtr pnag, IntPtr pnab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorHistogramMasked")]
        internal static extern int pixGetColorHistogramMasked(HandleRef pixs, IntPtr pixm, int x, int y, int factor, IntPtr pnar, IntPtr pnag, IntPtr pnab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogram")]
        internal static extern IntPtr pixGetCmapHistogram(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogramMasked")]
        internal static extern IntPtr pixGetCmapHistogramMasked(HandleRef pixs, IntPtr pixm, int x, int y, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogramInRect")]
        internal static extern IntPtr pixGetCmapHistogramInRect(HandleRef pixs, IntPtr box, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountRGBColors")]
        internal static extern int pixCountRGBColors(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorAmapHistogram")]
        internal static extern IntPtr pixGetColorAmapHistogram(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "amapGetCountForColor")]
        internal static extern int amapGetCountForColor(HandleRef amap, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValue")]
        internal static extern int pixGetRankValue(HandleRef pixs, int factor, float rank, IntPtr pvalue);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValueMaskedRGB")]
        internal static extern int pixGetRankValueMaskedRGB(HandleRef pixs, IntPtr pixm, int x, int y, int factor, float rank, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValueMasked")]
        internal static extern int pixGetRankValueMasked(HandleRef pixs, IntPtr pixm, int x, int y, int factor, float rank, IntPtr pval, IntPtr pna);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageValue")]
        internal static extern int pixGetAverageValue(HandleRef pixs, int factor, int type, IntPtr pvalue);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageMaskedRGB")]
        internal static extern int pixGetAverageMaskedRGB(HandleRef pixs, IntPtr pixm, int x, int y, int factor, int type, IntPtr prval, IntPtr pgval, IntPtr pbval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageMasked")]
        internal static extern int pixGetAverageMasked(HandleRef pixs, IntPtr pixm, int x, int y, int factor, int type, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageTiledRGB")]
        internal static extern int pixGetAverageTiledRGB(HandleRef pixs, int sx, int sy, int type, IntPtr ppixr, IntPtr ppixg, IntPtr ppixb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageTiled")]
        internal static extern IntPtr pixGetAverageTiled(HandleRef pixs, int sx, int sy, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRowStats")]
        internal static extern int pixRowStats(HandleRef pixs, IntPtr box, IntPtr pnamean, IntPtr pnamedian, IntPtr pnamode, IntPtr pnamodecount, IntPtr pnavar, IntPtr pnarootvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColumnStats")]
        internal static extern int pixColumnStats(HandleRef pixs, IntPtr box, IntPtr pnamean, IntPtr pnamedian, IntPtr pnamode, IntPtr pnamodecount, IntPtr pnavar, IntPtr pnarootvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRangeValues")]
        internal static extern int pixGetRangeValues(HandleRef pixs, int factor, int color, IntPtr pminval, IntPtr pmaxval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetExtremeValue")]
        internal static extern int pixGetExtremeValue(HandleRef pixs, int factor, int type, IntPtr prval, IntPtr pgval, IntPtr pbval, IntPtr pgrayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMaxValueInRect")]
        internal static extern int pixGetMaxValueInRect(HandleRef pixs, IntPtr box, IntPtr pmaxval, IntPtr pxmax, IntPtr pymax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBinnedComponentRange")]
        internal static extern int pixGetBinnedComponentRange(HandleRef pixs, int nbins, int factor, int color, IntPtr pminval, IntPtr pmaxval, IntPtr pcarray, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankColorArray")]
        internal static extern int pixGetRankColorArray(HandleRef pixs, int nbins, int type, int factor, IntPtr pcarray, int debugflag, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBinnedColor")]
        internal static extern int pixGetBinnedColor(HandleRef pixs, IntPtr pixg, int factor, int nbins, IntPtr nalut, IntPtr pcarray, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayColorArray")]
        internal static extern IntPtr pixDisplayColorArray(HandleRef carray, int ncolors, int side, int ncols, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankBinByStrip")]
        internal static extern IntPtr pixRankBinByStrip(HandleRef pixs, int direction, int size, int nbins, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetAlignedStats")]
        internal static extern IntPtr pixaGetAlignedStats(HandleRef pixa, int type, int nbins, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtractColumnFromEachPix")]
        internal static extern int pixaExtractColumnFromEachPix(HandleRef pixa, int col, IntPtr pixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRowStats")]
        internal static extern int pixGetRowStats(HandleRef pixs, int type, int nbins, int thresh, IntPtr colvect);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColumnStats")]
        internal static extern int pixGetColumnStats(HandleRef pixs, int type, int nbins, int thresh, IntPtr rowvect);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPixelColumn")]
        internal static extern int pixSetPixelColumn(HandleRef pix, int col, IntPtr colvect);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdForFgBg")]
        internal static extern int pixThresholdForFgBg(HandleRef pixs, int factor, int thresh, IntPtr pfgval, IntPtr pbgval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitDistributionFgBg")]
        internal static extern int pixSplitDistributionFgBg(HandleRef pixs, float scorefract, int factor, IntPtr pthresh, IntPtr pfgval, IntPtr pbgval, IntPtr ppixdb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindDimensions")]
        internal static extern int pixaFindDimensions(HandleRef pixa, IntPtr pnaw, IntPtr pnah);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaPerimRatio")]
        internal static extern int pixFindAreaPerimRatio(HandleRef pixs, IntPtr tab, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindPerimToAreaRatio")]
        internal static extern IntPtr pixaFindPerimToAreaRatio(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPerimToAreaRatio")]
        internal static extern int pixFindPerimToAreaRatio(HandleRef pixs, IntPtr tab, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindPerimSizeRatio")]
        internal static extern IntPtr pixaFindPerimSizeRatio(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPerimSizeRatio")]
        internal static extern int pixFindPerimSizeRatio(HandleRef pixs, IntPtr tab, IntPtr pratio);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindAreaFraction")]
        internal static extern IntPtr pixaFindAreaFraction(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaFraction")]
        internal static extern int pixFindAreaFraction(HandleRef pixs, IntPtr tab, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindAreaFractionMasked")]
        internal static extern IntPtr pixaFindAreaFractionMasked(HandleRef pixa, IntPtr pixm, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaFractionMasked")]
        internal static extern int pixFindAreaFractionMasked(HandleRef pixs, IntPtr box, IntPtr pixm, IntPtr tab, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindWidthHeightRatio")]
        internal static extern IntPtr pixaFindWidthHeightRatio(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindWidthHeightProduct")]
        internal static extern IntPtr pixaFindWidthHeightProduct(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindOverlapFraction")]
        internal static extern int pixFindOverlapFraction(HandleRef pixs1, IntPtr pixs2, int x2, int y2, IntPtr tab, IntPtr pratio, IntPtr pnoverlap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindRectangleComps")]
        internal static extern IntPtr pixFindRectangleComps(HandleRef pixs, int dist, int minw, int minh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConformsToRectangle")]
        internal static extern int pixConformsToRectangle(HandleRef pixs, IntPtr box, int dist, IntPtr pconforms);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipRectangles")]
        internal static extern IntPtr pixClipRectangles(HandleRef pixs, IntPtr boxa);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipMasked")]
        internal static extern IntPtr pixClipMasked(HandleRef pixs, IntPtr pixm, int x, int y, uint outval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropToMatch")]
        internal static extern int pixCropToMatch(HandleRef pixs1, HandleRef pixs2, IntPtr ppixd1, IntPtr ppixd2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropToSize")]
        internal static extern IntPtr pixCropToSize(HandleRef pixs, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixResizeToMatch")]
        internal static extern IntPtr pixResizeToMatch(HandleRef pixs, HandleRef pixt, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeFrameMask")]
        internal static extern IntPtr pixMakeFrameMask(int w, int h, float hf1, float hf2, float vf1, float vf2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFractionFgInMask")]
        internal static extern int pixFractionFgInMask(HandleRef pix1, IntPtr pix2, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipToForeground")]
        internal static extern int pixClipToForeground(HandleRef pixs, IntPtr ppixd, IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTestClipToForeground")]
        internal static extern int pixTestClipToForeground(HandleRef pixs, IntPtr pcanclip);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipBoxToForeground")]
        internal static extern int pixClipBoxToForeground(HandleRef pixs, IntPtr boxs, IntPtr ppixd, IntPtr pboxd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScanForForeground")]
        internal static extern int pixScanForForeground(HandleRef pixs, IntPtr box, int scanflag, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipBoxToEdges")]
        internal static extern int pixClipBoxToEdges(HandleRef pixs, IntPtr boxs, int lowthresh, int highthresh, int maxwidth, int factor, IntPtr ppixd, IntPtr pboxd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScanForEdge")]
        internal static extern int pixScanForEdge(HandleRef pixs, IntPtr box, int lowthresh, int highthresh, int maxwidth, int factor, int scanflag, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractOnLine")]
        internal static extern IntPtr pixExtractOnLine(HandleRef pixs, int x1, int y1, int x2, int y2, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageOnLine")]
        internal static extern float pixAverageOnLine(HandleRef pixs, int x1, int y1, int x2, int y2, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageIntensityProfile")]
        internal static extern IntPtr pixAverageIntensityProfile(HandleRef pixs, float fract, int dir, int first, int last, int factor1, int factor2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReversalProfile")]
        internal static extern IntPtr pixReversalProfile(HandleRef pixs, float fract, int dir, int first, int last, int minreversal, int factor1, int factor2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedVarianceOnLine")]
        internal static extern int pixWindowedVarianceOnLine(HandleRef pixs, int dir, int loc, int c1, int c2, int size, IntPtr pnad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinMaxNearLine")]
        internal static extern int pixMinMaxNearLine(HandleRef pixs, int x1, int y1, int x2, int y2, int dist, int direction, IntPtr pnamin, IntPtr pnamax, IntPtr pminave, IntPtr pmaxave);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankRowTransform")]
        internal static extern IntPtr pixRankRowTransform(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankColumnTransform")]
        internal static extern IntPtr pixRankColumnTransform(HandleRef pixs);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromPix")]
        internal static extern IntPtr pixaCreateFromPix(HandleRef pixs, int n, int cellw, int cellh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromBoxa")]
        internal static extern IntPtr pixaCreateFromBoxa(HandleRef pixs, IntPtr boxa, IntPtr pcropwarn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSplitPix")]
        internal static extern IntPtr pixaSplitPix(HandleRef pixs, int nx, int ny, int borderwidth, uint bordercolor);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddPix")]
        internal static extern int pixaAddPix(HandleRef pixa, IntPtr pix, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddBox")]
        internal static extern int pixaAddBox(HandleRef pixa, IntPtr box, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendArrayToSize")]
        internal static extern int pixaExtendArrayToSize(HandleRef pixa, int size);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaChangeRefcount")]
        internal static extern int pixaChangeRefcount(HandleRef pixa, int delta);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPixDimensions")]
        internal static extern int pixaGetPixDimensions(HandleRef pixa, int index, IntPtr pw, IntPtr ph, IntPtr pd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxa")]
        internal static extern IntPtr pixaGetBoxa(HandleRef pixa, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxaCount")]
        internal static extern int pixaGetBoxaCount(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBox")]
        internal static extern IntPtr pixaGetBox(HandleRef pixa, int index, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxGeometry")]
        internal static extern int pixaGetBoxGeometry(HandleRef pixa, int index, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetBoxa")]
        internal static extern int pixaSetBoxa(HandleRef pixa, IntPtr boxa, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPixArray")]
        internal static extern IntPtr pixaGetPixArray(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaVerifyDepth")]
        internal static extern int pixaVerifyDepth(HandleRef pixa, IntPtr pmaxdepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaIsFull")]
        internal static extern int pixaIsFull(HandleRef pixa, IntPtr pfullpa, IntPtr pfullba);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCountText")]
        internal static extern int pixaCountText(HandleRef pixa, IntPtr pntext);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetText")]
        internal static extern int pixaSetText(HandleRef pixa, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetLinePtrs")]
        internal static extern IntPtr pixaGetLinePtrs(HandleRef pixa, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteStreamInfo")]
        internal static extern int pixaWriteStreamInfo(HandleRef fp, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReplacePix")]
        internal static extern int pixaReplacePix(HandleRef pixa, int index, IntPtr pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInsertPix")]
        internal static extern int pixaInsertPix(HandleRef pixa, int index, IntPtr pixs, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemovePix")]
        internal static extern int pixaRemovePix(HandleRef pixa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemovePixAndSave")]
        internal static extern int pixaRemovePixAndSave(HandleRef pixa, int index, IntPtr ppix, IntPtr pbox);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInitFull")]
        internal static extern int pixaInitFull(HandleRef pixa, IntPtr pix, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClear")]
        internal static extern int pixaClear(HandleRef pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaJoin")]
        internal static extern int pixaJoin(HandleRef pixad, IntPtr pixas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInterleave")]
        internal static extern IntPtr pixaInterleave(HandleRef pixa1, IntPtr pixa2, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaJoin")]
        internal static extern int pixaaJoin(HandleRef paad, IntPtr paas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaCreate")]
        internal static extern IntPtr pixaaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaCreateFromPixa")]
        internal static extern IntPtr pixaaCreateFromPixa(HandleRef pixa, int n, int type, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDestroy")]
        internal static extern void pixaaDestroy(HandleRef ppaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddPixa")]
        internal static extern int pixaaAddPixa(HandleRef paa, IntPtr pixa, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaExtendArray")]
        internal static extern int pixaaExtendArray(HandleRef paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddPix")]
        internal static extern int pixaaAddPix(HandleRef paa, int index, IntPtr pix, IntPtr box, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddBox")]
        internal static extern int pixaaAddBox(HandleRef paa, IntPtr box, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetCount")]
        internal static extern int pixaaGetCount(HandleRef paa, IntPtr pna);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetPixa")]
        internal static extern IntPtr pixaaGetPixa(HandleRef paa, int index, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetBoxa")]
        internal static extern IntPtr pixaaGetBoxa(HandleRef paa, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetPix")]
        internal static extern IntPtr pixaaGetPix(HandleRef paa, int index, int ipix, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaVerifyDepth")]
        internal static extern int pixaaVerifyDepth(HandleRef paa, IntPtr pmaxdepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaIsFull")]
        internal static extern int pixaaIsFull(HandleRef paa, IntPtr pfull);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaInitFull")]
        internal static extern int pixaaInitFull(HandleRef paa, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReplacePixa")]
        internal static extern int pixaaReplacePixa(HandleRef paa, int index, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaClear")]
        internal static extern int pixaaClear(HandleRef paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaTruncate")]
        internal static extern int pixaaTruncate(HandleRef paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRead")]
        internal static extern IntPtr pixaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadStream")]
        internal static extern IntPtr pixaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadMem")]
        internal static extern IntPtr pixaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWrite")]
        internal static extern int pixaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteStream")]
        internal static extern int pixaWriteStream(HandleRef fp, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteMem")]
        internal static extern int pixaWriteMem(HandleRef pdata, IntPtr psize, IntPtr pixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadBoth")]
        internal static extern IntPtr pixaReadBoth(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadFromFiles")]
        internal static extern IntPtr pixaaReadFromFiles(HandleRef dirname, IntPtr substr, int first, int nfiles);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaRead")]
        internal static extern IntPtr pixaaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadStream")]
        internal static extern IntPtr pixaaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadMem")]
        internal static extern IntPtr pixaaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWrite")]
        internal static extern int pixaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWriteStream")]
        internal static extern int pixaaWriteStream(HandleRef fp, IntPtr paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWriteMem")]
        internal static extern int pixaaWriteMem(HandleRef pdata, IntPtr psize, IntPtr paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccCreate")]
        internal static extern IntPtr pixaccCreate(int w, int h, int negflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccCreateFromPix")]
        internal static extern IntPtr pixaccCreateFromPix(HandleRef pix, int negflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccDestroy")]
        internal static extern void pixaccDestroy(HandleRef ppixacc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccFinal")]
        internal static extern IntPtr pixaccFinal(HandleRef pixacc, int outdepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccGetPix")]
        internal static extern IntPtr pixaccGetPix(HandleRef pixacc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccGetOffset")]
        internal static extern int pixaccGetOffset(HandleRef pixacc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccAdd")]
        internal static extern int pixaccAdd(HandleRef pixacc, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccSubtract")]
        internal static extern int pixaccSubtract(HandleRef pixacc, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccMult")]
        internal static extern int pixaccMult(HandleRef pixacc, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccMultConstAccumulate")]
        internal static extern int pixaccMultConstAccumulate(HandleRef pixacc, IntPtr pix, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectBySize")]
        internal static extern IntPtr pixSelectBySize(HandleRef pixs, int width, int height, int connectivity, int type, int relation, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectBySize")]
        internal static extern IntPtr pixaSelectBySize(HandleRef pixas, int width, int height, int type, int relation, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMakeSizeIndicator")]
        internal static extern IntPtr pixaMakeSizeIndicator(HandleRef pixa, int width, int height, int type, int relation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByPerimToAreaRatio")]
        internal static extern IntPtr pixSelectByPerimToAreaRatio(HandleRef pixs, float thresh, int connectivity, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByPerimToAreaRatio")]
        internal static extern IntPtr pixaSelectByPerimToAreaRatio(HandleRef pixas, float thresh, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByPerimSizeRatio")]
        internal static extern IntPtr pixSelectByPerimSizeRatio(HandleRef pixs, float thresh, int connectivity, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByPerimSizeRatio")]
        internal static extern IntPtr pixaSelectByPerimSizeRatio(HandleRef pixas, float thresh, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByAreaFraction")]
        internal static extern IntPtr pixSelectByAreaFraction(HandleRef pixs, float thresh, int connectivity, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByAreaFraction")]
        internal static extern IntPtr pixaSelectByAreaFraction(HandleRef pixas, float thresh, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByWidthHeightRatio")]
        internal static extern IntPtr pixSelectByWidthHeightRatio(HandleRef pixs, float thresh, int connectivity, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByWidthHeightRatio")]
        internal static extern IntPtr pixaSelectByWidthHeightRatio(HandleRef pixas, float thresh, int type, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectWithIndicator")]
        internal static extern IntPtr pixaSelectWithIndicator(HandleRef pixas, IntPtr na, IntPtr pchanged);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveWithIndicator")]
        internal static extern int pixRemoveWithIndicator(HandleRef pixs, IntPtr pixa, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddWithIndicator")]
        internal static extern int pixAddWithIndicator(HandleRef pixs, IntPtr pixa, IntPtr na);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectWithString")]
        internal static extern IntPtr pixaSelectWithString(HandleRef pixas, IntPtr str, IntPtr perror);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRenderComponent")]
        internal static extern IntPtr pixaRenderComponent(HandleRef pixs, IntPtr pixa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSort")]
        internal static extern IntPtr pixaSort(HandleRef pixas, int sorttype, int sortorder, IntPtr pnaindex, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaBinSort")]
        internal static extern IntPtr pixaBinSort(HandleRef pixas, int sorttype, int sortorder, IntPtr pnaindex, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSortByIndex")]
        internal static extern IntPtr pixaSortByIndex(HandleRef pixas, IntPtr naindex, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSort2dByIndex")]
        internal static extern IntPtr pixaSort2dByIndex(HandleRef pixas, IntPtr naa, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectRange")]
        internal static extern IntPtr pixaSelectRange(HandleRef pixas, int first, int last, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaSelectRange")]
        internal static extern IntPtr pixaaSelectRange(HandleRef paas, int first, int last, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaScaleToSize")]
        internal static extern IntPtr pixaaScaleToSize(HandleRef paas, int wd, int hd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaScaleToSizeVar")]
        internal static extern IntPtr pixaaScaleToSizeVar(HandleRef paas, IntPtr nawd, IntPtr nahd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScaleToSize")]
        internal static extern IntPtr pixaScaleToSize(HandleRef pixas, int wd, int hd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScaleToSizeRel")]
        internal static extern IntPtr pixaScaleToSizeRel(HandleRef pixas, int delw, int delh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScale")]
        internal static extern IntPtr pixaScale(HandleRef pixas, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddBorderGeneral")]
        internal static extern IntPtr pixaAddBorderGeneral(HandleRef pixad, IntPtr pixas, int left, int right, int top, int bot, uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaFlattenToPixa")]
        internal static extern IntPtr pixaaFlattenToPixa(HandleRef paa, IntPtr pnaindex, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaSizeRange")]
        internal static extern int pixaaSizeRange(HandleRef paa, IntPtr pminw, IntPtr pminh, IntPtr pmaxw, IntPtr pmaxh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSizeRange")]
        internal static extern int pixaSizeRange(HandleRef pixa, IntPtr pminw, IntPtr pminh, IntPtr pmaxw, IntPtr pmaxh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClipToPix")]
        internal static extern IntPtr pixaClipToPix(HandleRef pixas, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClipToForeground")]
        internal static extern int pixaClipToForeground(HandleRef pixas, IntPtr ppixad, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetRenderingDepth")]
        internal static extern int pixaGetRenderingDepth(HandleRef pixa, IntPtr pdepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaHasColor")]
        internal static extern int pixaHasColor(HandleRef pixa, IntPtr phascolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAnyColormaps")]
        internal static extern int pixaAnyColormaps(HandleRef pixa, IntPtr phascmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetDepthInfo")]
        internal static extern int pixaGetDepthInfo(HandleRef pixa, IntPtr pmaxdepth, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToSameDepth")]
        internal static extern IntPtr pixaConvertToSameDepth(HandleRef pixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaEqual")]
        internal static extern int pixaEqual(HandleRef pixa1, IntPtr pixa2, int maxdist, IntPtr pnaindex, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRotateOrth")]
        internal static extern IntPtr pixaRotateOrth(HandleRef pixas, int rotation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplay")]
        internal static extern IntPtr pixaDisplay(HandleRef pixa, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayOnColor")]
        internal static extern IntPtr pixaDisplayOnColor(HandleRef pixa, int w, int h, uint bgcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayRandomCmap")]
        internal static extern IntPtr pixaDisplayRandomCmap(HandleRef pixa, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayLinearly")]
        internal static extern IntPtr pixaDisplayLinearly(HandleRef pixas, int direction, float scalefactor, int background, int spacing, int border, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayOnLattice")]
        internal static extern IntPtr pixaDisplayOnLattice(HandleRef pixa, int cellw, int cellh, IntPtr pncols, IntPtr pboxa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayUnsplit")]
        internal static extern IntPtr pixaDisplayUnsplit(HandleRef pixa, int nx, int ny, int borderwidth, uint bordercolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiled")]
        internal static extern IntPtr pixaDisplayTiled(HandleRef pixa, int maxwidth, int background, int spacing);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledInRows")]
        internal static extern IntPtr pixaDisplayTiledInRows(HandleRef pixa, int outdepth, int maxwidth, float scalefactor, int background, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledInColumns")]
        internal static extern IntPtr pixaDisplayTiledInColumns(HandleRef pixas, int nx, float scalefactor, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledAndScaled")]
        internal static extern IntPtr pixaDisplayTiledAndScaled(HandleRef pixa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledWithText")]
        internal static extern IntPtr pixaDisplayTiledWithText(HandleRef pixa, int maxwidth, float scalefactor, int spacing, int border, int fontsize, uint textcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledByIndex")]
        internal static extern IntPtr pixaDisplayTiledByIndex(HandleRef pixa, IntPtr na, int width, int spacing, int border, int fontsize, uint textcolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplay")]
        internal static extern IntPtr pixaaDisplay(HandleRef paa, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplayByPixa")]
        internal static extern IntPtr pixaaDisplayByPixa(HandleRef paa, int xspace, int yspace, int maxw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplayTiledAndScaled")]
        internal static extern IntPtr pixaaDisplayTiledAndScaled(HandleRef paa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo1")]
        internal static extern IntPtr pixaConvertTo1(HandleRef pixas, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo8")]
        internal static extern IntPtr pixaConvertTo8(HandleRef pixas, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo8Color")]
        internal static extern IntPtr pixaConvertTo8Color(HandleRef pixas, int dither);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo32")]
        internal static extern IntPtr pixaConvertTo32(HandleRef pixas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConstrainedSelect")]
        internal static extern IntPtr pixaConstrainedSelect(HandleRef pixas, int first, int last, int nmax, int use_pairs, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayMultiTiled")]
        internal static extern IntPtr pixaDisplayMultiTiled(HandleRef pixas, int nx, int ny, int maxw, int maxh, float scalefactor, int spacing, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSplitIntoFiles")]
        internal static extern int pixaSplitIntoFiles(HandleRef pixas, int nsplit, float scale, int outwidth, int write_pixa, int write_pix, int write_pdf);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToNUpFiles")]
        internal static extern int convertToNUpFiles(HandleRef dir, IntPtr substr, int nx, int ny, int tw, int spacing, int border, int fontsize, IntPtr outdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToNUpPixa")]
        internal static extern IntPtr convertToNUpPixa(HandleRef dir, IntPtr substr, int nx, int ny, int tw, int spacing, int border, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToNUpPixa")]
        internal static extern IntPtr pixaConvertToNUpPixa(HandleRef pixas, IntPtr sa, int nx, int ny, int tw, int spacing, int border, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCompareInPdf")]
        internal static extern int pixaCompareInPdf(HandleRef pixa1, IntPtr pixa2, int nx, int ny, int tw, int spacing, int border, int fontsize, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCreate")]
        internal static extern int pmsCreate(HandleRef minsize, IntPtr smallest, IntPtr numalloc, IntPtr logfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsDestroy")]
        internal static extern void pmsDestroy();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCustomAlloc")]
        internal static extern IntPtr pmsCustomAlloc(HandleRef nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCustomDealloc")]
        internal static extern void pmsCustomDealloc(HandleRef data);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetAlloc")]
        internal static extern IntPtr pmsGetAlloc(HandleRef nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetLevelForAlloc")]
        internal static extern int pmsGetLevelForAlloc(HandleRef nbytes, IntPtr plevel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetLevelForDealloc")]
        internal static extern int pmsGetLevelForDealloc(HandleRef data, IntPtr plevel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsLogInfo")]
        internal static extern void pmsLogInfo();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddConstantGray")]
        internal static extern int pixAddConstantGray(HandleRef pixs, int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstantGray")]
        internal static extern int pixMultConstantGray(HandleRef pixs, float val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGray")]
        internal static extern IntPtr pixAddGray(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubtractGray")]
        internal static extern IntPtr pixSubtractGray(HandleRef pixd, IntPtr pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdToValue")]
        internal static extern IntPtr pixThresholdToValue(HandleRef pixd, IntPtr pixs, int threshval, int setval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixInitAccumulate")]
        internal static extern IntPtr pixInitAccumulate(int w, int h, uint offset);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFinalAccumulate")]
        internal static extern IntPtr pixFinalAccumulate(HandleRef pixs, uint offset, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFinalAccumulateThreshold")]
        internal static extern IntPtr pixFinalAccumulateThreshold(HandleRef pixs, uint offset, uint threshold);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAccumulate")]
        internal static extern int pixAccumulate(HandleRef pixd, IntPtr pixs, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstAccumulate")]
        internal static extern int pixMultConstAccumulate(HandleRef pixs, float factor, uint offset);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDifference")]
        internal static extern IntPtr pixAbsDifference(HandleRef pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddRGB")]
        internal static extern IntPtr pixAddRGB(HandleRef pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinOrMax")]
        internal static extern IntPtr pixMinOrMax(HandleRef pixd, IntPtr pixs1, IntPtr pixs2, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaxDynamicRange")]
        internal static extern IntPtr pixMaxDynamicRange(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaxDynamicRangeRGB")]
        internal static extern IntPtr pixMaxDynamicRangeRGB(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearScaleRGBVal")]
        internal static extern uint linearScaleRGBVal(uint sval, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "logScaleRGBVal")]
        internal static extern uint logScaleRGBVal(uint sval, IntPtr tab, float factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeLogBase2Tab")]
        internal static extern IntPtr makeLogBase2Tab(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getLogBase2")]
        internal static extern float getLogBase2(int val, IntPtr logtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromPix")]
        internal static extern IntPtr pixcompCreateFromPix(HandleRef pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromString")]
        internal static extern IntPtr pixcompCreateFromString(HandleRef data, IntPtr size, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromFile")]
        internal static extern IntPtr pixcompCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompDestroy")]
        internal static extern void pixcompDestroy(HandleRef ppixc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCopy")]
        internal static extern IntPtr pixcompCopy(HandleRef pixcs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompGetDimensions")]
        internal static extern int pixcompGetDimensions(HandleRef pixc, IntPtr pw, IntPtr ph, IntPtr pd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompDetermineFormat")]
        internal static extern int pixcompDetermineFormat(int comptype, int d, int cmapflag, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateFromPixcomp")]
        internal static extern IntPtr pixCreateFromPixcomp(HandleRef pixc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreate")]
        internal static extern IntPtr pixacompCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateWithInit")]
        internal static extern IntPtr pixacompCreateWithInit(int n, int offset, IntPtr pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromPixa")]
        internal static extern IntPtr pixacompCreateFromPixa(HandleRef pixa, int comptype, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromFiles")]
        internal static extern IntPtr pixacompCreateFromFiles(HandleRef dirname, IntPtr substr, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromSA")]
        internal static extern IntPtr pixacompCreateFromSA(HandleRef sa, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompDestroy")]
        internal static extern void pixacompDestroy(HandleRef ppixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddPix")]
        internal static extern int pixacompAddPix(HandleRef pixac, IntPtr pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddPixcomp")]
        internal static extern int pixacompAddPixcomp(HandleRef pixac, IntPtr pixc, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReplacePix")]
        internal static extern int pixacompReplacePix(HandleRef pixac, int index, IntPtr pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReplacePixcomp")]
        internal static extern int pixacompReplacePixcomp(HandleRef pixac, int index, IntPtr pixc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddBox")]
        internal static extern int pixacompAddBox(HandleRef pixac, IntPtr box, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetCount")]
        internal static extern int pixacompGetCount(HandleRef pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPixcomp")]
        internal static extern IntPtr pixacompGetPixcomp(HandleRef pixac, int index, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPix")]
        internal static extern IntPtr pixacompGetPix(HandleRef pixac, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPixDimensions")]
        internal static extern int pixacompGetPixDimensions(HandleRef pixac, int index, IntPtr pw, IntPtr ph, IntPtr pd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxa")]
        internal static extern IntPtr pixacompGetBoxa(HandleRef pixac, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxaCount")]
        internal static extern int pixacompGetBoxaCount(HandleRef pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBox")]
        internal static extern IntPtr pixacompGetBox(HandleRef pixac, int index, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxGeometry")]
        internal static extern int pixacompGetBoxGeometry(HandleRef pixac, int index, IntPtr px, IntPtr py, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetOffset")]
        internal static extern int pixacompGetOffset(HandleRef pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompSetOffset")]
        internal static extern int pixacompSetOffset(HandleRef pixac, int offset);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromPixacomp")]
        internal static extern IntPtr pixaCreateFromPixacomp(HandleRef pixac, int accesstype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompJoin")]
        internal static extern int pixacompJoin(HandleRef pixacd, IntPtr pixacs, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompInterleave")]
        internal static extern IntPtr pixacompInterleave(HandleRef pixac1, IntPtr pixac2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompRead")]
        internal static extern IntPtr pixacompRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReadStream")]
        internal static extern IntPtr pixacompReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReadMem")]
        internal static extern IntPtr pixacompReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWrite")]
        internal static extern int pixacompWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteStream")]
        internal static extern int pixacompWriteStream(HandleRef fp, IntPtr pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteMem")]
        internal static extern int pixacompWriteMem(HandleRef pdata, IntPtr psize, IntPtr pixac);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompConvertToPdf")]
        internal static extern int pixacompConvertToPdf(HandleRef pixac, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompConvertToPdfData")]
        internal static extern int pixacompConvertToPdfData(HandleRef pixac, int res, float scalefactor, int type, int quality, IntPtr title, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteStreamInfo")]
        internal static extern int pixacompWriteStreamInfo(HandleRef fp, IntPtr pixac, IntPtr text);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompWriteStreamInfo")]
        internal static extern int pixcompWriteStreamInfo(HandleRef fp, IntPtr pixc, IntPtr text);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompDisplayTiledAndScaled")]
        internal static extern IntPtr pixacompDisplayTiledAndScaled(HandleRef pixac, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThreshold8")]
        internal static extern IntPtr pixThreshold8(HandleRef pixs, int d, int nlevels, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveColormapGeneral")]
        internal static extern IntPtr pixRemoveColormapGeneral(HandleRef pixs, int type, int ifnocmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveColormap")]
        internal static extern IntPtr pixRemoveColormap(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGrayColormap8")]
        internal static extern int pixAddGrayColormap8(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMinimalGrayColormap8")]
        internal static extern IntPtr pixAddMinimalGrayColormap8(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToLuminance")]
        internal static extern IntPtr pixConvertRGBToLuminance(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGray")]
        internal static extern IntPtr pixConvertRGBToGray(HandleRef pixs, float rwt, float gwt, float bwt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayFast")]
        internal static extern IntPtr pixConvertRGBToGrayFast(HandleRef pixs);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayMinMax")]
        internal static extern IntPtr pixConvertRGBToGrayMinMax(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGraySatBoost")]
        internal static extern IntPtr pixConvertRGBToGraySatBoost(HandleRef pixs, int refval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayArb")]
        internal static extern IntPtr pixConvertRGBToGrayArb(HandleRef pixs, float rc, float gc, float bc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToColormap")]
        internal static extern IntPtr pixConvertGrayToColormap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToColormap8")]
        internal static extern IntPtr pixConvertGrayToColormap8(HandleRef pixs, int mindepth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorizeGray")]
        internal static extern IntPtr pixColorizeGray(HandleRef pixs, uint color, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToColormap")]
        internal static extern IntPtr pixConvertRGBToColormap(HandleRef pixs, int ditherflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertCmapTo1")]
        internal static extern IntPtr pixConvertCmapTo1(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuantizeIfFewColors")]
        internal static extern int pixQuantizeIfFewColors(HandleRef pixs, int maxcolors, int mingraycolors, int octlevel, IntPtr ppixd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert16To8")]
        internal static extern IntPtr pixConvert16To8(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToFalseColor")]
        internal static extern IntPtr pixConvertGrayToFalseColor(HandleRef pixs, float gamma);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnpackBinary")]
        internal static extern IntPtr pixUnpackBinary(HandleRef pixs, int depth, int invert);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To16")]
        internal static extern IntPtr pixConvert1To16(HandleRef pixd, IntPtr pixs, ushort val0, ushort val1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To32")]
        internal static extern IntPtr pixConvert1To32(HandleRef pixd, IntPtr pixs, uint val0, uint val1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To2Cmap")]
        internal static extern IntPtr pixConvert1To2Cmap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To2")]
        internal static extern IntPtr pixConvert1To2(HandleRef pixd, IntPtr pixs, int val0, int val1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To4Cmap")]
        internal static extern IntPtr pixConvert1To4Cmap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To4")]
        internal static extern IntPtr pixConvert1To4(HandleRef pixd, IntPtr pixs, int val0, int val1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To8Cmap")]
        internal static extern IntPtr pixConvert1To8Cmap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To8")]
        internal static extern IntPtr pixConvert1To8(HandleRef pixd, IntPtr pixs, byte val0, byte val1);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert2To8")]
        internal static extern IntPtr pixConvert2To8(HandleRef pixs, byte val0, byte val1, byte val2, byte val3, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert4To8")]
        internal static extern IntPtr pixConvert4To8(HandleRef pixs, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert8To16")]
        internal static extern IntPtr pixConvert8To16(HandleRef pixs, int leftshift);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo1")]
        internal static extern IntPtr pixConvertTo1(HandleRef pixs, int threshold);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo1BySampling")]
        internal static extern IntPtr pixConvertTo1BySampling(HandleRef pixs, int factor, int threshold);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8")]
        internal static extern IntPtr pixConvertTo8(HandleRef pixs, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8BySampling")]
        internal static extern IntPtr pixConvertTo8BySampling(HandleRef pixs, int factor, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8Color")]
        internal static extern IntPtr pixConvertTo8Color(HandleRef pixs, int dither);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo16")]
        internal static extern IntPtr pixConvertTo16(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo32")]
        internal static extern IntPtr pixConvertTo32(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo32BySampling")]
        internal static extern IntPtr pixConvertTo32BySampling(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert8To32")]
        internal static extern IntPtr pixConvert8To32(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8Or32")]
        internal static extern IntPtr pixConvertTo8Or32(HandleRef pixs, int copyflag, int warnflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert24To32")]
        internal static extern IntPtr pixConvert24To32(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To24")]
        internal static extern IntPtr pixConvert32To24(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To16")]
        internal static extern IntPtr pixConvert32To16(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To8")]
        internal static extern IntPtr pixConvert32To8(HandleRef pixs, int type16, int type8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveAlpha")]
        internal static extern IntPtr pixRemoveAlpha(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddAlphaTo1bpp")]
        internal static extern IntPtr pixAddAlphaTo1bpp(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertLossless")]
        internal static extern IntPtr pixConvertLossless(HandleRef pixs, int d);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertForPSWrap")]
        internal static extern IntPtr pixConvertForPSWrap(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToSubpixelRGB")]
        internal static extern IntPtr pixConvertToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToSubpixelRGB")]
        internal static extern IntPtr pixConvertGrayToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertColorToSubpixelRGB")]
        internal static extern IntPtr pixConvertColorToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setNeutralBoostVal")]
        internal static extern void l_setNeutralBoostVal(int val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompTransform")]
        internal static extern IntPtr pixConnCompTransform(HandleRef pixs, int connect, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompAreaTransform")]
        internal static extern IntPtr pixConnCompAreaTransform(HandleRef pixs, int connect);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompIncrInit")]
        internal static extern int pixConnCompIncrInit(HandleRef pixs, int conn, IntPtr ppixd, IntPtr pptaa, IntPtr pncc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompIncrAdd")]
        internal static extern int pixConnCompIncrAdd(HandleRef pixs, IntPtr ptaa, IntPtr pncc, float x, float y, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetSortedNeighborValues")]
        internal static extern int pixGetSortedNeighborValues(HandleRef pixs, int x, int y, int conn, IntPtr pneigh, IntPtr pnvals);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocToColorTransform")]
        internal static extern IntPtr pixLocToColorTransform(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingCreate")]
        internal static extern IntPtr pixTilingCreate(HandleRef pixs, int nx, int ny, int w, int h, int xoverlap, int yoverlap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingDestroy")]
        internal static extern void pixTilingDestroy(HandleRef ppt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetCount")]
        internal static extern int pixTilingGetCount(HandleRef pt, IntPtr pnx, IntPtr pny);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetSize")]
        internal static extern int pixTilingGetSize(HandleRef pt, IntPtr pw, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetTile")]
        internal static extern IntPtr pixTilingGetTile(HandleRef pt, int i, int j);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingNoStripOnPaint")]
        internal static extern int pixTilingNoStripOnPaint(HandleRef pt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingPaintTile")]
        internal static extern int pixTilingPaintTile(HandleRef pixd, int i, int j, IntPtr pixs, IntPtr pt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamPng")]
        internal static extern IntPtr pixReadStreamPng(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderPng")]
        internal static extern int readHeaderPng([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderPng")]
        internal static extern int freadHeaderPng(HandleRef fp, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemPng")]
        internal static extern int readHeaderMemPng(HandleRef data, IntPtr size, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetPngResolution")]
        internal static extern int fgetPngResolution(HandleRef fp, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "isPngInterlaced")]
        internal static extern int isPngInterlaced([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pinterlaced);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetPngColormapInfo")]
        internal static extern int fgetPngColormapInfo(HandleRef fp, IntPtr pcmap, IntPtr ptransparency);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWritePng")]
        internal static extern int pixWritePng([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, float gamma);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPng")]
        internal static extern int pixWriteStreamPng(HandleRef fp, IntPtr pix, float gamma);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetZlibCompression")]
        internal static extern int pixSetZlibCompression(HandleRef pix, int compval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pngSetReadStrip16To8")]
        internal static extern void l_pngSetReadStrip16To8(int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemPng")]
        internal static extern IntPtr pixReadMemPng(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPng")]
        internal static extern int pixWriteMemPng(HandleRef pdata, IntPtr psize, IntPtr pix, float gamma);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamPnm")]
        internal static extern IntPtr pixReadStreamPnm(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderPnm")]
        internal static extern int readHeaderPnm([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pw, IntPtr ph, IntPtr pd, IntPtr ptype, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderPnm")]
        internal static extern int freadHeaderPnm(HandleRef fp, IntPtr pw, IntPtr ph, IntPtr pd, IntPtr ptype, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPnm")]
        internal static extern int pixWriteStreamPnm(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamAsciiPnm")]
        internal static extern int pixWriteStreamAsciiPnm(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPam")]
        internal static extern int pixWriteStreamPam(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemPnm")]
        internal static extern IntPtr pixReadMemPnm(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemPnm")]
        internal static extern int readHeaderMemPnm(HandleRef data, IntPtr size, IntPtr pw, IntPtr ph, IntPtr pd, IntPtr ptype, IntPtr pbps, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPnm")]
        internal static extern int pixWriteMemPnm(HandleRef pdata, IntPtr psize, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPam")]
        internal static extern int pixWriteMemPam(HandleRef pdata, IntPtr psize, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveSampledPta")]
        internal static extern IntPtr pixProjectiveSampledPta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveSampled")]
        internal static extern IntPtr pixProjectiveSampled(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePta")]
        internal static extern IntPtr pixProjectivePta(HandleRef pixs, IntPtr ptad, IntPtr ptas, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjective")]
        internal static extern IntPtr pixProjective(HandleRef pixs, IntPtr vc, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaColor")]
        internal static extern IntPtr pixProjectivePtaColor(HandleRef pixs, IntPtr ptad, IntPtr ptas, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveColor")]
        internal static extern IntPtr pixProjectiveColor(HandleRef pixs, IntPtr vc, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaGray")]
        internal static extern IntPtr pixProjectivePtaGray(HandleRef pixs, IntPtr ptad, IntPtr ptas, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveGray")]
        internal static extern IntPtr pixProjectiveGray(HandleRef pixs, IntPtr vc, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaWithAlpha")]
        internal static extern IntPtr pixProjectivePtaWithAlpha(HandleRef pixs, IntPtr ptad, IntPtr ptas, IntPtr pixg, float fract, int border);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getProjectiveXformCoeffs")]
        internal static extern int getProjectiveXformCoeffs(HandleRef ptas, IntPtr ptad, IntPtr pvc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "projectiveXformSampledPt")]
        internal static extern int projectiveXformSampledPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "projectiveXformPt")]
        internal static extern int projectiveXformPt(HandleRef vc, int x, int y, IntPtr pxp, IntPtr pyp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesToPS")]
        internal static extern int convertFilesToPS(HandleRef dirin, IntPtr substr, int res, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertFilesToPS")]
        internal static extern int sarrayConvertFilesToPS(HandleRef sa, int res, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesFittedToPS")]
        internal static extern int convertFilesFittedToPS(HandleRef dirin, IntPtr substr, float xpts, float ypts, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertFilesFittedToPS")]
        internal static extern int sarrayConvertFilesFittedToPS(HandleRef sa, float xpts, float ypts, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeImageCompressedToPSFile")]
        internal static extern int writeImageCompressedToPSFile(HandleRef filein, IntPtr fileout, int res, IntPtr pfirstfile, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSegmentedPagesToPS")]
        internal static extern int convertSegmentedPagesToPS(HandleRef pagedir, IntPtr pagestr, int page_numpre, IntPtr maskdir, IntPtr maskstr, int mask_numpre, int numpost, int maxnum, float textscale, float imagescale, int threshold, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteSegmentedPageToPS")]
        internal static extern int pixWriteSegmentedPageToPS(HandleRef pixs, IntPtr pixm, float textscale, float imagescale, int threshold, int pageno, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMixedToPS")]
        internal static extern int pixWriteMixedToPS(HandleRef pixb, IntPtr pixc, float scale, int pageno, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPSEmbed")]
        internal static extern int convertToPSEmbed(HandleRef filein, IntPtr fileout, int level);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteCompressedToPS")]
        internal static extern int pixaWriteCompressedToPS(HandleRef pixa, IntPtr fileout, int res, int level);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWritePSEmbed")]
        internal static extern int pixWritePSEmbed(HandleRef filein, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPS")]
        internal static extern int pixWriteStreamPS(HandleRef fp, IntPtr pix, IntPtr box, int res, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStringPS")]
        internal static extern IntPtr pixWriteStringPS(HandleRef pixs, IntPtr box, int res, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateUncompressedPS")]
        internal static extern IntPtr generateUncompressedPS(HandleRef hexdata, int w, int h, int d, int psbpl, int bps, float xpt, float ypt, float wpt, float hpt, int boxflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getScaledParametersPS")]
        internal static extern void getScaledParametersPS(HandleRef box, int wpix, int hpix, int res, float scale, IntPtr pxpt, IntPtr pypt, IntPtr pwpt, IntPtr phpt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertByteToHexAscii")]
        internal static extern void convertByteToHexAscii(byte byteval, IntPtr pnib1, IntPtr pnib2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPSEmbed")]
        internal static extern int convertJpegToPSEmbed(HandleRef filein, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPS")]
        internal static extern int convertJpegToPS(HandleRef filein, IntPtr fileout, IntPtr operation, int x, int y, int res, float scale, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPSString")]
        internal static extern int convertJpegToPSString(HandleRef filein, IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateJpegPS")]
        internal static extern IntPtr generateJpegPS(HandleRef filein, IntPtr cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPSEmbed")]
        internal static extern int convertG4ToPSEmbed(HandleRef filein, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPS")]
        internal static extern int convertG4ToPS(HandleRef filein, IntPtr fileout, IntPtr operation, int x, int y, int res, float scale, int pageno, int maskflag, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPSString")]
        internal static extern int convertG4ToPSString(HandleRef filein, IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int maskflag, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateG4PS")]
        internal static extern IntPtr generateG4PS(HandleRef filein, IntPtr cid, float xpt, float ypt, float wpt, float hpt, int maskflag, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertTiffMultipageToPS")]
        internal static extern int convertTiffMultipageToPS(HandleRef filein, IntPtr fileout, float fillfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPSEmbed")]
        internal static extern int convertFlateToPSEmbed(HandleRef filein, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPS")]
        internal static extern int convertFlateToPS(HandleRef filein, IntPtr fileout, IntPtr operation, int x, int y, int res, float scale, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPSString")]
        internal static extern int convertFlateToPSString(HandleRef filein, IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateFlatePS")]
        internal static extern IntPtr generateFlatePS(HandleRef filein, IntPtr cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPS")]
        internal static extern int pixWriteMemPS(HandleRef pdata, IntPtr psize, IntPtr pix, IntPtr box, int res, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getResLetterPage")]
        internal static extern int getResLetterPage(int w, int h, float fillfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getResA4Page")]
        internal static extern int getResA4Page(int w, int h, float fillfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_psWriteBoundingBox")]
        internal static extern void l_psWriteBoundingBox(int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCreate")]
        internal static extern IntPtr ptaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCreateFromNuma")]
        internal static extern IntPtr ptaCreateFromNuma(HandleRef nax, IntPtr nay);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaDestroy")]
        internal static extern void ptaDestroy(HandleRef ppta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCopy")]
        internal static extern IntPtr ptaCopy(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCopyRange")]
        internal static extern IntPtr ptaCopyRange(HandleRef ptas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaClone")]
        internal static extern IntPtr ptaClone(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaEmpty")]
        internal static extern int ptaEmpty(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaAddPt")]
        internal static extern int ptaAddPt(HandleRef pta, float x, float y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaInsertPt")]
        internal static extern int ptaInsertPt(HandleRef pta, int index, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemovePt")]
        internal static extern int ptaRemovePt(HandleRef pta, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetRefcount")]
        internal static extern int ptaGetRefcount(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaChangeRefcount")]
        internal static extern int ptaChangeRefcount(HandleRef pta, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetCount")]
        internal static extern int ptaGetCount(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetPt")]
        internal static extern int ptaGetPt(HandleRef pta, int index, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetIPt")]
        internal static extern int ptaGetIPt(HandleRef pta, int index, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSetPt")]
        internal static extern int ptaSetPt(HandleRef pta, int index, float x, float y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetArrays")]
        internal static extern int ptaGetArrays(HandleRef pta, IntPtr pnax, IntPtr pnay);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRead")]
        internal static extern IntPtr ptaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReadStream")]
        internal static extern IntPtr ptaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReadMem")]
        internal static extern IntPtr ptaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWrite")]
        internal static extern int ptaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pta, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWriteStream")]
        internal static extern int ptaWriteStream(HandleRef fp, IntPtr pta, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWriteMem")]
        internal static extern int ptaWriteMem(HandleRef pdata, IntPtr psize, IntPtr pta, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaCreate")]
        internal static extern IntPtr ptaaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaDestroy")]
        internal static extern void ptaaDestroy(HandleRef pptaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaAddPta")]
        internal static extern int ptaaAddPta(HandleRef ptaa, IntPtr pta, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetCount")]
        internal static extern int ptaaGetCount(HandleRef ptaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetPta")]
        internal static extern IntPtr ptaaGetPta(HandleRef ptaa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetPt")]
        internal static extern int ptaaGetPt(HandleRef ptaa, int ipta, int jpt, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaInitFull")]
        internal static extern int ptaaInitFull(HandleRef ptaa, IntPtr pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReplacePta")]
        internal static extern int ptaaReplacePta(HandleRef ptaa, int index, IntPtr pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaAddPt")]
        internal static extern int ptaaAddPt(HandleRef ptaa, int ipta, float x, float y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaTruncate")]
        internal static extern int ptaaTruncate(HandleRef ptaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaRead")]
        internal static extern IntPtr ptaaRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReadStream")]
        internal static extern IntPtr ptaaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReadMem")]
        internal static extern IntPtr ptaaReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWrite")]
        internal static extern int ptaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr ptaa, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWriteStream")]
        internal static extern int ptaaWriteStream(HandleRef fp, IntPtr ptaa, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWriteMem")]
        internal static extern int ptaaWriteMem(HandleRef pdata, IntPtr psize, IntPtr ptaa, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSubsample")]
        internal static extern IntPtr ptaSubsample(HandleRef ptas, int subfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaJoin")]
        internal static extern int ptaJoin(HandleRef ptad, IntPtr ptas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaJoin")]
        internal static extern int ptaaJoin(HandleRef ptaad, IntPtr ptaas, int istart, int iend);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReverse")]
        internal static extern IntPtr ptaReverse(HandleRef ptas, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTranspose")]
        internal static extern IntPtr ptaTranspose(HandleRef ptas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCyclicPerm")]
        internal static extern IntPtr ptaCyclicPerm(HandleRef ptas, int xs, int ys);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetBoundingRegion")]
        internal static extern IntPtr ptaGetBoundingRegion(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetRange")]
        internal static extern int ptaGetRange(HandleRef pta, IntPtr pminx, IntPtr pmaxx, IntPtr pminy, IntPtr pmaxy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetInsideBox")]
        internal static extern IntPtr ptaGetInsideBox(HandleRef ptas, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindCornerPixels")]
        internal static extern IntPtr pixFindCornerPixels(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaContainsPt")]
        internal static extern int ptaContainsPt(HandleRef pta, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTestIntersection")]
        internal static extern int ptaTestIntersection(HandleRef pta1, IntPtr pta2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTransform")]
        internal static extern IntPtr ptaTransform(HandleRef ptas, int shiftx, int shifty, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaPtInsidePolygon")]
        internal static extern int ptaPtInsidePolygon(HandleRef pta, float x, float y, IntPtr pinside);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_angleBetweenVectors")]
        internal static extern float l_angleBetweenVectors(float x1, float y1, float x2, float y2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetMinMax")]
        internal static extern int ptaGetMinMax(HandleRef pta, IntPtr pxmin, IntPtr pymin, IntPtr pxmax, IntPtr pymax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSelectByValue")]
        internal static extern IntPtr ptaSelectByValue(HandleRef ptas, float xth, float yth, int type, int relation);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCropToMask")]
        internal static extern IntPtr ptaCropToMask(HandleRef ptas, IntPtr pixm);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetLinearLSF")]
        internal static extern int ptaGetLinearLSF(HandleRef pta, IntPtr pa, IntPtr pb, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetQuadraticLSF")]
        internal static extern int ptaGetQuadraticLSF(HandleRef pta, IntPtr pa, IntPtr pb, IntPtr pc, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetCubicLSF")]
        internal static extern int ptaGetCubicLSF(HandleRef pta, IntPtr pa, IntPtr pb, IntPtr pc, IntPtr pd, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetQuarticLSF")]
        internal static extern int ptaGetQuarticLSF(HandleRef pta, IntPtr pa, IntPtr pb, IntPtr pc, IntPtr pd, IntPtr pe, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaNoisyLinearLSF")]
        internal static extern int ptaNoisyLinearLSF(HandleRef pta, float factor, IntPtr pptad, IntPtr pa, IntPtr pb, IntPtr pmederr, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaNoisyQuadraticLSF")]
        internal static extern int ptaNoisyQuadraticLSF(HandleRef pta, float factor, IntPtr pptad, IntPtr pa, IntPtr pb, IntPtr pc, IntPtr pmederr, IntPtr pnafit);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyLinearFit")]
        internal static extern int applyLinearFit(float a, float b, float x, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyQuadraticFit")]
        internal static extern int applyQuadraticFit(float a, float b, float c, float x, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyCubicFit")]
        internal static extern int applyCubicFit(float a, float b, float c, float d, float x, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyQuarticFit")]
        internal static extern int applyQuarticFit(float a, float b, float c, float d, float e, float x, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPlotAlongPta")]
        internal static extern int pixPlotAlongPta(HandleRef pixs, IntPtr pta, int outformat, IntPtr title);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetPixelsFromPix")]
        internal static extern IntPtr ptaGetPixelsFromPix(HandleRef pixs, IntPtr box);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateFromPta")]
        internal static extern IntPtr pixGenerateFromPta(HandleRef pta, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetBoundaryPixels")]
        internal static extern IntPtr ptaGetBoundaryPixels(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetBoundaryPixels")]
        internal static extern IntPtr ptaaGetBoundaryPixels(HandleRef pixs, int type, int connectivity, IntPtr pboxa, IntPtr ppixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaIndexLabeledPixels")]
        internal static extern IntPtr ptaaIndexLabeledPixels(HandleRef pixs, IntPtr pncc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetNeighborPixLocs")]
        internal static extern IntPtr ptaGetNeighborPixLocs(HandleRef pixs, int x, int y, int conn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPta")]
        internal static extern IntPtr pixDisplayPta(HandleRef pixd, IntPtr pixs, IntPtr pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaaPattern")]
        internal static extern IntPtr pixDisplayPtaaPattern(HandleRef pixd, IntPtr pixs, IntPtr ptaa, IntPtr pixp, int cx, int cy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaPattern")]
        internal static extern IntPtr pixDisplayPtaPattern(HandleRef pixd, IntPtr pixs, IntPtr pta, IntPtr pixp, int cx, int cy, uint color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReplicatePattern")]
        internal static extern IntPtr ptaReplicatePattern(HandleRef ptas, IntPtr pixp, IntPtr ptap, int cx, int cy, int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaa")]
        internal static extern IntPtr pixDisplayPtaa(HandleRef pixs, IntPtr ptaa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSort")]
        internal static extern IntPtr ptaSort(HandleRef ptas, int sorttype, int sortorder, IntPtr pnaindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetSortIndex")]
        internal static extern int ptaGetSortIndex(HandleRef ptas, int sorttype, int sortorder, IntPtr pnaindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSortByIndex")]
        internal static extern IntPtr ptaSortByIndex(HandleRef ptas, IntPtr naindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaSortByIndex")]
        internal static extern IntPtr ptaaSortByIndex(HandleRef ptaas, IntPtr naindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaUnionByAset")]
        internal static extern IntPtr ptaUnionByAset(HandleRef pta1, IntPtr pta2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemoveDupsByAset")]
        internal static extern IntPtr ptaRemoveDupsByAset(HandleRef ptas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaIntersectionByAset")]
        internal static extern IntPtr ptaIntersectionByAset(HandleRef pta1, IntPtr pta2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromPta")]
        internal static extern IntPtr l_asetCreateFromPta(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaUnionByHash")]
        internal static extern IntPtr ptaUnionByHash(HandleRef pta1, IntPtr pta2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemoveDupsByHash")]
        internal static extern int ptaRemoveDupsByHash(HandleRef ptas, IntPtr pptad, IntPtr pdahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaIntersectionByHash")]
        internal static extern IntPtr ptaIntersectionByHash(HandleRef pta1, IntPtr pta2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaFindPtByHash")]
        internal static extern int ptaFindPtByHash(HandleRef pta, IntPtr dahash, int x, int y, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromPta")]
        internal static extern IntPtr l_dnaHashCreateFromPta(HandleRef pta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraCreate")]
        internal static extern IntPtr ptraCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraDestroy")]
        internal static extern void ptraDestroy(HandleRef ppa, int freeflag, int warnflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraAdd")]
        internal static extern int ptraAdd(HandleRef pa, IntPtr item);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraInsert")]
        internal static extern int ptraInsert(HandleRef pa, int index, IntPtr item, int shiftflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraRemove")]
        internal static extern IntPtr ptraRemove(HandleRef pa, int index, int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraRemoveLast")]
        internal static extern IntPtr ptraRemoveLast(HandleRef pa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraReplace")]
        internal static extern IntPtr ptraReplace(HandleRef pa, int index, IntPtr item, int freeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraSwap")]
        internal static extern int ptraSwap(HandleRef pa, int index1, int index2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraCompactArray")]
        internal static extern int ptraCompactArray(HandleRef pa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraReverse")]
        internal static extern int ptraReverse(HandleRef pa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraJoin")]
        internal static extern int ptraJoin(HandleRef pa1, IntPtr pa2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetMaxIndex")]
        internal static extern int ptraGetMaxIndex(HandleRef pa, IntPtr pmaxindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetActualCount")]
        internal static extern int ptraGetActualCount(HandleRef pa, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetPtrToItem")]
        internal static extern IntPtr ptraGetPtrToItem(HandleRef pa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaCreate")]
        internal static extern IntPtr ptraaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaDestroy")]
        internal static extern void ptraaDestroy(HandleRef ppaa, int freeflag, int warnflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaGetSize")]
        internal static extern int ptraaGetSize(HandleRef paa, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaInsertPtra")]
        internal static extern int ptraaInsertPtra(HandleRef paa, int index, IntPtr pa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaGetPtra")]
        internal static extern IntPtr ptraaGetPtra(HandleRef paa, int index, int accessflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaFlattenToPtra")]
        internal static extern IntPtr ptraaFlattenToPtra(HandleRef paa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadtreeMean")]
        internal static extern int pixQuadtreeMean(HandleRef pixs, int nlevels, IntPtr pix_ma, IntPtr pfpixa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadtreeVariance")]
        internal static extern int pixQuadtreeVariance(HandleRef pixs, int nlevels, IntPtr pix_ma, IntPtr dpix_msa, IntPtr pfpixa_v, IntPtr pfpixa_rv);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeanInRectangle")]
        internal static extern int pixMeanInRectangle(HandleRef pixs, IntPtr box, IntPtr pixma, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceInRectangle")]
        internal static extern int pixVarianceInRectangle(HandleRef pixs, IntPtr box, IntPtr pix_ma, IntPtr dpix_msa, IntPtr pvar, IntPtr prvar);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaQuadtreeRegions")]
        internal static extern IntPtr boxaaQuadtreeRegions(int w, int h, int nlevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeGetParent")]
        internal static extern int quadtreeGetParent(HandleRef fpixa, int level, int x, int y, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeGetChildren")]
        internal static extern int quadtreeGetChildren(HandleRef fpixa, int level, int x, int y, IntPtr pval00, IntPtr pval10, IntPtr pval01, IntPtr pval11);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeMaxLevels")]
        internal static extern int quadtreeMaxLevels(int w, int h);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaDisplayQuadtree")]
        internal static extern IntPtr fpixaDisplayQuadtree(HandleRef fpixa, int factor, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueCreate")]
        internal static extern IntPtr lqueueCreate(int nalloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueDestroy")]
        internal static extern void lqueueDestroy(HandleRef plq, int freeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueAdd")]
        internal static extern int lqueueAdd(HandleRef lq, IntPtr item);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueRemove")]
        internal static extern IntPtr lqueueRemove(HandleRef lq);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueGetCount")]
        internal static extern int lqueueGetCount(HandleRef lq);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueuePrint")]
        internal static extern int lqueuePrint(HandleRef fp, IntPtr lq);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilter")]
        internal static extern IntPtr pixRankFilter(HandleRef pixs, int wf, int hf, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterRGB")]
        internal static extern IntPtr pixRankFilterRGB(HandleRef pixs, int wf, int hf, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterGray")]
        internal static extern IntPtr pixRankFilterGray(HandleRef pixs, int wf, int hf, float rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianFilter")]
        internal static extern IntPtr pixMedianFilter(HandleRef pixs, int wf, int hf);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterWithScaling")]
        internal static extern IntPtr pixRankFilterWithScaling(HandleRef pixs, int wf, int hf, float rank, float scalefactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProcessBarcodes")]
        internal static extern IntPtr pixProcessBarcodes(HandleRef pixs, int format, int method, IntPtr psaw, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodes")]
        internal static extern IntPtr pixExtractBarcodes(HandleRef pixs, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadBarcodes")]
        internal static extern IntPtr pixReadBarcodes(HandleRef pixa, int format, int method, IntPtr psaw, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadBarcodeWidths")]
        internal static extern IntPtr pixReadBarcodeWidths(HandleRef pixs, int method, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocateBarcodes")]
        internal static extern IntPtr pixLocateBarcodes(HandleRef pixs, int thresh, IntPtr ppixb, IntPtr ppixm);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewBarcode")]
        internal static extern IntPtr pixDeskewBarcode(HandleRef pixs, IntPtr pixb, IntPtr box, int margin, int threshold, IntPtr pangle, IntPtr pconf);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeWidths1")]
        internal static extern IntPtr pixExtractBarcodeWidths1(HandleRef pixs, float thresh, float binfract, IntPtr pnaehist, IntPtr pnaohist, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeWidths2")]
        internal static extern IntPtr pixExtractBarcodeWidths2(HandleRef pixs, float thresh, IntPtr pwidth, IntPtr pnac, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeCrossings")]
        internal static extern IntPtr pixExtractBarcodeCrossings(HandleRef pixs, float thresh, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaQuantizeCrossingsByWidth")]
        internal static extern IntPtr numaQuantizeCrossingsByWidth(HandleRef nas, float binfract, IntPtr pnaehist, IntPtr pnaohist, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaQuantizeCrossingsByWindow")]
        internal static extern IntPtr numaQuantizeCrossingsByWindow(HandleRef nas, float ratio, IntPtr pwidth, IntPtr pfirstloc, IntPtr pnac, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadFiles")]
        internal static extern IntPtr pixaReadFiles(HandleRef dirname, IntPtr substr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadFilesSA")]
        internal static extern IntPtr pixaReadFilesSA(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadWithHint")]
        internal static extern IntPtr pixReadWithHint([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int hint);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadIndexed")]
        internal static extern IntPtr pixReadIndexed(HandleRef sa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStream")]
        internal static extern IntPtr pixReadStream(HandleRef fp, int hint);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadHeader")]
        internal static extern int pixReadHeader([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pformat, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormat")]
        internal static extern int findFileFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormatStream")]
        internal static extern int findFileFormatStream(HandleRef fp, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormatBuffer")]
        internal static extern int findFileFormatBuffer(HandleRef buf, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileFormatIsTiff")]
        internal static extern int fileFormatIsTiff(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMem")]
        internal static extern IntPtr pixReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadHeaderMem")]
        internal static extern int pixReadHeaderMem(HandleRef data, IntPtr size, IntPtr pformat, IntPtr pw, IntPtr ph, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeImageFileInfo")]
        internal static extern int writeImageFileInfo([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr fpout, int headeronly);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ioFormatTest")]
        internal static extern int ioFormatTest([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_convertCharstrToInt")]
        internal static extern int l_convertCharstrToInt(HandleRef str, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAccumulateSamples")]
        internal static extern int pixaAccumulateSamples(HandleRef pixa, IntPtr pta, IntPtr ppixd, IntPtr px, IntPtr py);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogRemoveOutliers1")]
        internal static extern IntPtr recogRemoveOutliers1(HandleRef pixas, float minscore, float minfract, IntPtr ppixarem, IntPtr pnarem);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogRemoveOutliers2")]
        internal static extern IntPtr recogRemoveOutliers2(HandleRef pixas, IntPtr ppixarem, IntPtr ppixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogMakeBootDigitTemplates")]
        internal static extern IntPtr recogMakeBootDigitTemplates(int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasterop")]
        internal static extern int pixRasterop(HandleRef pixd, int dx, int dy, int dw, int dh, int op, IntPtr pixs, int sx, int sy);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropVip")]
        internal static extern int pixRasteropVip(HandleRef pixd, int bx, int bw, int vshift, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropHip")]
        internal static extern int pixRasteropHip(HandleRef pixd, int by, int bh, int hshift, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTranslate")]
        internal static extern IntPtr pixTranslate(HandleRef pixd, IntPtr pixs, int hshift, int vshift, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropIP")]
        internal static extern int pixRasteropIP(HandleRef pixd, int hshift, int vshift, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropFullImage")]
        internal static extern int pixRasteropFullImage(HandleRef pixd, IntPtr pixs, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropVipLow")]
        internal static extern void rasteropVipLow(HandleRef data, int pixw, int pixh, int depth, int wpl, int x, int w, int shift);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropHipLow")]
        internal static extern void rasteropHipLow(HandleRef data, int pixh, int depth, int wpl, int y, int h, int shift);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "shiftDataHorizontalLow")]
        internal static extern void shiftDataHorizontalLow(HandleRef datad, int wpld, IntPtr datas, int wpls, int shift);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropUniLow")]
        internal static extern void rasteropUniLow(HandleRef datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropLow")]
        internal static extern void rasteropLow(HandleRef datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op, IntPtr datas, int spixw, int spixh, int swpl, int sx, int sy);



        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEmbedForRotation")]
        internal static extern IntPtr pixEmbedForRotation(HandleRef pixs, float angle, int incolor, int width, int height);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateBySampling")]
        internal static extern IntPtr pixRotateBySampling(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateBinaryNice")]
        internal static extern IntPtr pixRotateBinaryNice(HandleRef pixs, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateWithAlpha")]
        internal static extern IntPtr pixRotateWithAlpha(HandleRef pixs, float angle, IntPtr pixg, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAM")]
        internal static extern IntPtr pixRotateAM(HandleRef pixs, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColor")]
        internal static extern IntPtr pixRotateAMColor(HandleRef pixs, float angle, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMGray")]
        internal static extern IntPtr pixRotateAMGray(HandleRef pixs, float angle, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMCorner")]
        internal static extern IntPtr pixRotateAMCorner(HandleRef pixs, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColorCorner")]
        internal static extern IntPtr pixRotateAMColorCorner(HandleRef pixs, float angle, uint fillval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMGrayCorner")]
        internal static extern IntPtr pixRotateAMGrayCorner(HandleRef pixs, float angle, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColorFast")]
        internal static extern IntPtr pixRotateAMColorFast(HandleRef pixs, float angle, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorLow")]
        internal static extern void rotateAMColorLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMGrayLow")]
        internal static extern void rotateAMGrayLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorCornerLow")]
        internal static extern void rotateAMColorCornerLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMGrayCornerLow")]
        internal static extern void rotateAMGrayCornerLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorFastLow")]
        internal static extern void rotateAMColorFastLow(HandleRef datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateOrth")]
        internal static extern IntPtr pixRotateOrth(HandleRef pixs, int quads);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate180")]
        internal static extern IntPtr pixRotate180(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate90")]
        internal static extern IntPtr pixRotate90(HandleRef pixs, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipLR")]
        internal static extern IntPtr pixFlipLR(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipTB")]
        internal static extern IntPtr pixFlipTB(HandleRef pixd, IntPtr pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShear")]
        internal static extern IntPtr pixRotateShear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate2Shear")]
        internal static extern IntPtr pixRotate2Shear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate3Shear")]
        internal static extern IntPtr pixRotate3Shear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearIP")]
        internal static extern int pixRotateShearIP(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearCenter")]
        internal static extern IntPtr pixRotateShearCenter(HandleRef pixs, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearCenterIP")]
        internal static extern int pixRotateShearCenterIP(HandleRef pixs, float angle, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStrokeWidthTransform")]
        internal static extern IntPtr pixStrokeWidthTransform(HandleRef pixs, int color, int depth, int nangles);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRunlengthTransform")]
        internal static extern IntPtr pixRunlengthTransform(HandleRef pixs, int color, int direction, int depth);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindHorizontalRuns")]
        internal static extern int pixFindHorizontalRuns(HandleRef pix, int y, IntPtr xstart, IntPtr xend, IntPtr pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindVerticalRuns")]
        internal static extern int pixFindVerticalRuns(HandleRef pix, int x, IntPtr ystart, IntPtr yend, IntPtr pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxRuns")]
        internal static extern IntPtr pixFindMaxRuns(HandleRef pix, int direction, IntPtr pnastart);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxHorizontalRunOnLine")]
        internal static extern int pixFindMaxHorizontalRunOnLine(HandleRef pix, int y, IntPtr pxstart, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxVerticalRunOnLine")]
        internal static extern int pixFindMaxVerticalRunOnLine(HandleRef pix, int x, IntPtr pystart, IntPtr psize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "runlengthMembershipOnLine")]
        internal static extern int runlengthMembershipOnLine(HandleRef buffer, int size, int depth, IntPtr start, IntPtr end, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern IntPtr makeMSBitLocTab(int bitval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreate")]
        internal static extern IntPtr sarrayCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateInitialized")]
        internal static extern IntPtr sarrayCreateInitialized(int n, IntPtr initstr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateWordsFromString")]
        internal static extern IntPtr sarrayCreateWordsFromString(HandleRef str);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateLinesFromString")]
        internal static extern IntPtr sarrayCreateLinesFromString(HandleRef str, int blankflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayDestroy")]
        internal static extern void sarrayDestroy(HandleRef psa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCopy")]
        internal static extern IntPtr sarrayCopy(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayClone")]
        internal static extern IntPtr sarrayClone(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayAddString")]
        internal static extern int sarrayAddString(HandleRef sa, IntPtr str, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRemoveString")]
        internal static extern IntPtr sarrayRemoveString(HandleRef sa, int index);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayReplaceString")]
        internal static extern int sarrayReplaceString(HandleRef sa, int index, IntPtr newstr, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayClear")]
        internal static extern int sarrayClear(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetCount")]
        internal static extern int sarrayGetCount(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetArray")]
        internal static extern IntPtr sarrayGetArray(HandleRef sa, IntPtr pnalloc, IntPtr pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetString")]
        internal static extern IntPtr sarrayGetString(HandleRef sa, int index, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetRefcount")]
        internal static extern int sarrayGetRefcount(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayChangeRefcount")]
        internal static extern int sarrayChangeRefcount(HandleRef sa, int delta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayToString")]
        internal static extern IntPtr sarrayToString(HandleRef sa, int addnlflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayToStringRange")]
        internal static extern IntPtr sarrayToStringRange(HandleRef sa, int first, int nstrings, int addnlflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayJoin")]
        internal static extern int sarrayJoin(HandleRef sa1, IntPtr sa2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayAppendRange")]
        internal static extern int sarrayAppendRange(HandleRef sa1, IntPtr sa2, int start, int end);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayPadToSameSize")]
        internal static extern int sarrayPadToSameSize(HandleRef sa1, IntPtr sa2, IntPtr padstring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertWordsToLines")]
        internal static extern IntPtr sarrayConvertWordsToLines(HandleRef sa, int linesize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySplitString")]
        internal static extern int sarraySplitString(HandleRef sa, IntPtr str, IntPtr separators);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySelectBySubstring")]
        internal static extern IntPtr sarraySelectBySubstring(HandleRef sain, IntPtr substr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySelectByRange")]
        internal static extern IntPtr sarraySelectByRange(HandleRef sain, int first, int last);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayParseRange")]
        internal static extern int sarrayParseRange(HandleRef sa, int start, IntPtr pactualstart, IntPtr pend, IntPtr pnewstart, IntPtr substr, int loc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRead")]
        internal static extern IntPtr sarrayRead(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayReadStream")]
        internal static extern IntPtr sarrayReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayReadMem")]
        internal static extern IntPtr sarrayReadMem(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWrite")]
        internal static extern int sarrayWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWriteStream")]
        internal static extern int sarrayWriteStream(HandleRef fp, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWriteMem")]
        internal static extern int sarrayWriteMem(HandleRef pdata, IntPtr psize, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayAppend")]
        internal static extern int sarrayAppend([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getNumberedPathnamesInDirectory")]
        internal static extern IntPtr getNumberedPathnamesInDirectory(HandleRef dirname, IntPtr substr, int numpre, int numpost, int maxnum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getSortedPathnamesInDirectory")]
        internal static extern IntPtr getSortedPathnamesInDirectory(HandleRef dirname, IntPtr substr, int first, int nfiles);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSortedToNumberedPathnames")]
        internal static extern IntPtr convertSortedToNumberedPathnames(HandleRef sa, int numpre, int numpost, int maxnum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getFilenamesInDirectory")]
        internal static extern IntPtr getFilenamesInDirectory(HandleRef dirname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySort")]
        internal static extern IntPtr sarraySort(HandleRef saout, IntPtr sain, int sortorder);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySortByIndex")]
        internal static extern IntPtr sarraySortByIndex(HandleRef sain, IntPtr naindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCompareLexical")]
        internal static extern int stringCompareLexical(HandleRef str1, IntPtr str2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayUnionByAset")]
        internal static extern IntPtr sarrayUnionByAset(HandleRef sa1, IntPtr sa2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRemoveDupsByAset")]
        internal static extern IntPtr sarrayRemoveDupsByAset(HandleRef sas);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayIntersectionByAset")]
        internal static extern IntPtr sarrayIntersectionByAset(HandleRef sa1, IntPtr sa2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromSarray")]
        internal static extern IntPtr l_asetCreateFromSarray(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRemoveDupsByHash")]
        internal static extern int sarrayRemoveDupsByHash(HandleRef sas, IntPtr psad, IntPtr pdahash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayIntersectionByHash")]
        internal static extern IntPtr sarrayIntersectionByHash(HandleRef sa1, IntPtr sa2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayFindStringByHash")]
        internal static extern int sarrayFindStringByHash(HandleRef sa, IntPtr dahash, IntPtr str, IntPtr pindex);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromSarray")]
        internal static extern IntPtr l_dnaHashCreateFromSarray(HandleRef sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGenerateIntegers")]
        internal static extern IntPtr sarrayGenerateIntegers(int n);





        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleLI")]
        internal static extern IntPtr pixScaleLI(HandleRef pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColorLI")]
        internal static extern IntPtr pixScaleColorLI(HandleRef pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColor2xLI")]
        internal static extern IntPtr pixScaleColor2xLI(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColor4xLI")]
        internal static extern IntPtr pixScaleColor4xLI(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayLI")]
        internal static extern IntPtr pixScaleGrayLI(HandleRef pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLI")]
        internal static extern IntPtr pixScaleGray2xLI(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLI")]
        internal static extern IntPtr pixScaleGray4xLI(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBySampling")]
        internal static extern IntPtr pixScaleBySampling(HandleRef pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBySamplingToSize")]
        internal static extern IntPtr pixScaleBySamplingToSize(HandleRef pixs, int wd, int hd);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleByIntSampling")]
        internal static extern IntPtr pixScaleByIntSampling(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToGrayFast")]
        internal static extern IntPtr pixScaleRGBToGrayFast(HandleRef pixs, int factor, int color);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToBinaryFast")]
        internal static extern IntPtr pixScaleRGBToBinaryFast(HandleRef pixs, int factor, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayToBinaryFast")]
        internal static extern IntPtr pixScaleGrayToBinaryFast(HandleRef pixs, int factor, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleSmooth")]
        internal static extern IntPtr pixScaleSmooth(Pix pix, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToGray2")]
        internal static extern IntPtr pixScaleRGBToGray2(HandleRef pixs, float rwt, float gwt, float bwt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAreaMap")]
        internal static extern IntPtr pixScaleAreaMap(Pix pix, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAreaMap2")]
        internal static extern IntPtr pixScaleAreaMap2(Pix pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBinary")]
        internal static extern IntPtr pixScaleBinary(HandleRef pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray")]
        internal static extern IntPtr pixScaleToGray(HandleRef pixs, float scalefactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGrayFast")]
        internal static extern IntPtr pixScaleToGrayFast(HandleRef pixs, float scalefactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray2")]
        internal static extern IntPtr pixScaleToGray2(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray3")]
        internal static extern IntPtr pixScaleToGray3(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray4")]
        internal static extern IntPtr pixScaleToGray4(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray6")]
        internal static extern IntPtr pixScaleToGray6(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray8")]
        internal static extern IntPtr pixScaleToGray8(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray16")]
        internal static extern IntPtr pixScaleToGray16(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGrayMipmap")]
        internal static extern IntPtr pixScaleToGrayMipmap(HandleRef pixs, float scalefactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleMipmap")]
        internal static extern IntPtr pixScaleMipmap(HandleRef pixs1, IntPtr pixs2, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandReplicate")]
        internal static extern IntPtr pixExpandReplicate(HandleRef pixs, int factor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLIThresh")]
        internal static extern IntPtr pixScaleGray2xLIThresh(HandleRef pixs, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLIDither")]
        internal static extern IntPtr pixScaleGray2xLIDither(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLIThresh")]
        internal static extern IntPtr pixScaleGray4xLIThresh(HandleRef pixs, int thresh);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLIDither")]
        internal static extern IntPtr pixScaleGray4xLIDither(HandleRef pixs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayMinMax")]
        internal static extern IntPtr pixScaleGrayMinMax(HandleRef pixs, int xfact, int yfact, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayMinMax2")]
        internal static extern IntPtr pixScaleGrayMinMax2(HandleRef pixs, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayRankCascade")]
        internal static extern IntPtr pixScaleGrayRankCascade(HandleRef pixs, int level1, int level2, int level3, int level4);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayRank2")]
        internal static extern IntPtr pixScaleGrayRank2(HandleRef pixs, int rank);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAndTransferAlpha")]
        internal static extern int pixScaleAndTransferAlpha(HandleRef pixd, IntPtr pixs, float scalex, float scaley);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleWithAlpha")]
        internal static extern IntPtr pixScaleWithAlpha(HandleRef pixs, float scalex, float scaley, IntPtr pixg, float fract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColorLILow")]
        internal static extern void scaleColorLILow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGrayLILow")]
        internal static extern void scaleGrayLILow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColor2xLILow")]
        internal static extern void scaleColor2xLILow(HandleRef datad, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColor2xLILineLow")]
        internal static extern void scaleColor2xLILineLow(HandleRef lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray2xLILow")]
        internal static extern void scaleGray2xLILow(HandleRef datad, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray2xLILineLow")]
        internal static extern void scaleGray2xLILineLow(HandleRef lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray4xLILow")]
        internal static extern void scaleGray4xLILow(HandleRef datad, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray4xLILineLow")]
        internal static extern void scaleGray4xLILineLow(HandleRef lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleBySamplingLow")]
        internal static extern int scaleBySamplingLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleSmoothLow")]
        internal static extern int scaleSmoothLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls, int size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleRGBToGray2Low")]
        internal static extern void scaleRGBToGray2Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, float rwt, float gwt, float bwt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColorAreaMapLow")]
        internal static extern void scaleColorAreaMapLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGrayAreaMapLow")]
        internal static extern void scaleGrayAreaMapLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleAreaMapLow2")]
        internal static extern void scaleAreaMapLow2(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int d, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleBinaryLow")]
        internal static extern int scaleBinaryLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray2Low")]
        internal static extern void scaleToGray2Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG2")]
        internal static extern IntPtr makeSumTabSG2(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG2")]
        internal static extern IntPtr makeValTabSG2(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray3Low")]
        internal static extern void scaleToGray3Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG3")]
        internal static extern IntPtr makeSumTabSG3(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG3")]
        internal static extern IntPtr makeValTabSG3(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray4Low")]
        internal static extern void scaleToGray4Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG4")]
        internal static extern IntPtr makeSumTabSG4(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG4")]
        internal static extern IntPtr makeValTabSG4(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray6Low")]
        internal static extern void scaleToGray6Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG6")]
        internal static extern IntPtr makeValTabSG6(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray8Low")]
        internal static extern void scaleToGray8Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG8")]
        internal static extern IntPtr makeValTabSG8(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray16Low")]
        internal static extern void scaleToGray16Low(HandleRef datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleMipmapLow")]
        internal static extern int scaleMipmapLow(HandleRef datad, int wd, int hd, int wpld, IntPtr datas1, int wpls1, IntPtr datas2, int wpls2, float red);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBinary")]
        internal static extern IntPtr pixSeedfillBinary(HandleRef pixd, IntPtr pixs, IntPtr pixm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBinaryRestricted")]
        internal static extern IntPtr pixSeedfillBinaryRestricted(HandleRef pixd, IntPtr pixs, IntPtr pixm, int connectivity, int xmax, int ymax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHolesByFilling")]
        internal static extern IntPtr pixHolesByFilling(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillClosedBorders")]
        internal static extern IntPtr pixFillClosedBorders(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBorderConnComps")]
        internal static extern IntPtr pixExtractBorderConnComps(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderConnComps")]
        internal static extern IntPtr pixRemoveBorderConnComps(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillBgFromBorder")]
        internal static extern IntPtr pixFillBgFromBorder(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillHolesToBoundingRect")]
        internal static extern IntPtr pixFillHolesToBoundingRect(HandleRef pixs, int minsize, float maxhfract, float minfgfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGray")]
        internal static extern int pixSeedfillGray(HandleRef pixs, IntPtr pixm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayInv")]
        internal static extern int pixSeedfillGrayInv(HandleRef pixs, IntPtr pixm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGraySimple")]
        internal static extern int pixSeedfillGraySimple(HandleRef pixs, IntPtr pixm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayInvSimple")]
        internal static extern int pixSeedfillGrayInvSimple(HandleRef pixs, IntPtr pixm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayBasin")]
        internal static extern IntPtr pixSeedfillGrayBasin(HandleRef pixb, IntPtr pixm, int delta, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDistanceFunction")]
        internal static extern IntPtr pixDistanceFunction(HandleRef pixs, int connectivity, int outdepth, int boundcond);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedspread")]
        internal static extern IntPtr pixSeedspread(HandleRef pixs, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocalExtrema")]
        internal static extern int pixLocalExtrema(HandleRef pixs, int maxmin, int minmax, IntPtr ppixmin, IntPtr ppixmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectedLocalExtrema")]
        internal static extern int pixSelectedLocalExtrema(HandleRef pixs, int mindist, IntPtr ppixmin, IntPtr ppixmax);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindEqualValues")]
        internal static extern IntPtr pixFindEqualValues(HandleRef pixs1, IntPtr pixs2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectMinInConnComp")]
        internal static extern int pixSelectMinInConnComp(HandleRef pixs, IntPtr pixm, IntPtr ppta, IntPtr pnav);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveSeededComponents")]
        internal static extern IntPtr pixRemoveSeededComponents(HandleRef pixd, IntPtr pixs, IntPtr pixm, int connectivity, int bordersize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillBinaryLow")]
        internal static extern void seedfillBinaryLow(HandleRef datas, int hs, int wpls, IntPtr datam, int hm, int wplm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayLow")]
        internal static extern void seedfillGrayLow(HandleRef datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayInvLow")]
        internal static extern void seedfillGrayInvLow(HandleRef datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayLowSimple")]
        internal static extern void seedfillGrayLowSimple(HandleRef datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayInvLowSimple")]
        internal static extern void seedfillGrayInvLowSimple(HandleRef datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "distanceFunctionLow")]
        internal static extern void distanceFunctionLow(HandleRef datad, int w, int h, int d, int wpld, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedspreadLow")]
        internal static extern void seedspreadLow(HandleRef datad, int w, int h, int wpld, IntPtr datat, int wplt, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaCreate")]
        internal static extern IntPtr selaCreate(int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaDestroy")]
        internal static extern void selaDestroy(HandleRef psela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreate")]
        internal static extern IntPtr selCreate(int height, int width, IntPtr name);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selDestroy")]
        internal static extern void selDestroy(HandleRef psel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCopy")]
        internal static extern IntPtr selCopy(HandleRef sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateBrick")]
        internal static extern IntPtr selCreateBrick(int h, int w, int cy, int cx, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateComb")]
        internal static extern IntPtr selCreateComb(int factor1, int factor2, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "create2dIntArray")]
        internal static extern IntPtr create2dIntArray(int sy, int sx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddSel")]
        internal static extern int selaAddSel(HandleRef sela, IntPtr sel, IntPtr selname, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetCount")]
        internal static extern int selaGetCount(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetSel")]
        internal static extern IntPtr selaGetSel(HandleRef sela, int i);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetName")]
        internal static extern IntPtr selGetName(HandleRef sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetName")]
        internal static extern int selSetName(HandleRef sel, IntPtr name);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaFindSelByName")]
        internal static extern int selaFindSelByName(HandleRef sela, IntPtr name, IntPtr pindex, IntPtr psel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetElement")]
        internal static extern int selGetElement(HandleRef sel, int row, int col, IntPtr ptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetElement")]
        internal static extern int selSetElement(HandleRef sel, int row, int col, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetParameters")]
        internal static extern int selGetParameters(HandleRef sel, IntPtr psy, IntPtr psx, IntPtr pcy, IntPtr pcx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetOrigin")]
        internal static extern int selSetOrigin(HandleRef sel, int cy, int cx);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetTypeAtOrigin")]
        internal static extern int selGetTypeAtOrigin(HandleRef sel, IntPtr ptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetBrickName")]
        internal static extern IntPtr selaGetBrickName(HandleRef sela, int hsize, int vsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetCombName")]
        internal static extern IntPtr selaGetCombName(HandleRef sela, int size, int direction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getCompositeParameters")]
        internal static extern int getCompositeParameters(int size, IntPtr psize1, IntPtr psize2, IntPtr pnameh1, IntPtr pnameh2, IntPtr pnamev1, IntPtr pnamev2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetSelnames")]
        internal static extern IntPtr selaGetSelnames(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selFindMaxTranslations")]
        internal static extern int selFindMaxTranslations(HandleRef sel, IntPtr pxp, IntPtr pyp, IntPtr pxn, IntPtr pyn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selRotateOrth")]
        internal static extern IntPtr selRotateOrth(HandleRef sel, int quads);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaRead")]
        internal static extern IntPtr selaRead(HandleRef fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaReadStream")]
        internal static extern IntPtr selaReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selRead")]
        internal static extern IntPtr selRead(HandleRef fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selReadStream")]
        internal static extern IntPtr selReadStream(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaWrite")]
        internal static extern int selaWrite(HandleRef fname, IntPtr sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaWriteStream")]
        internal static extern int selaWriteStream(HandleRef fp, IntPtr sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selWrite")]
        internal static extern int selWrite(HandleRef fname, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selWriteStream")]
        internal static extern int selWriteStream(HandleRef fp, IntPtr sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromString")]
        internal static extern IntPtr selCreateFromString(HandleRef text, int h, int w, IntPtr name);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selPrintToString")]
        internal static extern IntPtr selPrintToString(HandleRef sel);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaCreateFromFile")]
        internal static extern IntPtr selaCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromPta")]
        internal static extern IntPtr selCreateFromPta(HandleRef pta, int cy, int cx, IntPtr name);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromPix")]
        internal static extern IntPtr selCreateFromPix(HandleRef pix, int cy, int cx, IntPtr name);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selReadFromColorImage")]
        internal static extern IntPtr selReadFromColorImage(HandleRef pathname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromColorPix")]
        internal static extern IntPtr selCreateFromColorPix(HandleRef pixs, IntPtr selname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selDisplayInPix")]
        internal static extern IntPtr selDisplayInPix(HandleRef sel, int size, int gthick);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaDisplayInPix")]
        internal static extern IntPtr selaDisplayInPix(HandleRef sela, int size, int gthick, int spacing, int ncols);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddBasic")]
        internal static extern IntPtr selaAddBasic(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddHitMiss")]
        internal static extern IntPtr selaAddHitMiss(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddDwaLinear")]
        internal static extern IntPtr selaAddDwaLinear(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddDwaCombs")]
        internal static extern IntPtr selaAddDwaCombs(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddCrossJunctions")]
        internal static extern IntPtr selaAddCrossJunctions(HandleRef sela, float hlsize, float mdist, int norient, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddTJunctions")]
        internal static extern IntPtr selaAddTJunctions(HandleRef sela, float hlsize, float mdist, int norient, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela4ccThin")]
        internal static extern IntPtr sela4ccThin(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela8ccThin")]
        internal static extern IntPtr sela8ccThin(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela4and8ccThin")]
        internal static extern IntPtr sela4and8ccThin(HandleRef sela);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelWithRuns")]
        internal static extern IntPtr pixGenerateSelWithRuns(HandleRef pixs, int nhlines, int nvlines, int distance, int minlength, int toppix, int botpix, int leftpix, int rightpix, IntPtr ppixe);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelRandom")]
        internal static extern IntPtr pixGenerateSelRandom(HandleRef pixs, float hitfract, float missfract, int distance, int toppix, int botpix, int leftpix, int rightpix, IntPtr ppixe);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelBoundary")]
        internal static extern IntPtr pixGenerateSelBoundary(HandleRef pixs, int hitdist, int missdist, int hitskip, int missskip, int topflag, int botflag, int leftflag, int rightflag, IntPtr ppixe);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRunCentersOnLine")]
        internal static extern IntPtr pixGetRunCentersOnLine(HandleRef pixs, int x, int y, int minlength);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRunsOnLine")]
        internal static extern IntPtr pixGetRunsOnLine(HandleRef pixs, int x1, int y1, int x2, int y2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubsampleBoundaryPixels")]
        internal static extern IntPtr pixSubsampleBoundaryPixels(HandleRef pixs, int skip);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "adjacentOnPixelInRaster")]
        internal static extern int adjacentOnPixelInRaster(HandleRef pixs, int x, int y, IntPtr pxa, IntPtr pya);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayHitMissSel")]
        internal static extern IntPtr pixDisplayHitMissSel(HandleRef pixs, IntPtr sel, int scalefactor, uint hitcolor, uint misscolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShear")]
        internal static extern IntPtr pixHShear(HandleRef pixd, IntPtr pixs, int yloc, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShear")]
        internal static extern IntPtr pixVShear(HandleRef pixd, IntPtr pixs, int xloc, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearCorner")]
        internal static extern IntPtr pixHShearCorner(HandleRef pixd, IntPtr pixs, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearCorner")]
        internal static extern IntPtr pixVShearCorner(HandleRef pixd, IntPtr pixs, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearCenter")]
        internal static extern IntPtr pixHShearCenter(HandleRef pixd, IntPtr pixs, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearCenter")]
        internal static extern IntPtr pixVShearCenter(HandleRef pixd, IntPtr pixs, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearIP")]
        internal static extern int pixHShearIP(HandleRef pixs, int yloc, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearIP")]
        internal static extern int pixVShearIP(HandleRef pixs, int xloc, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearLI")]
        internal static extern IntPtr pixHShearLI(HandleRef pixs, int yloc, float radang, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearLI")]
        internal static extern IntPtr pixVShearLI(HandleRef pixs, int xloc, float radang, int incolor);


        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweep")]
        internal static extern int pixFindSkewSweep(HandleRef pixs, out float pangle, int reduction, float sweeprange, float sweepdelta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearch")]
        internal static extern int pixFindSkewSweepAndSearch(HandleRef pixs, out float pangle, out float pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearchScore")]
        internal static extern int pixFindSkewSweepAndSearchScore(HandleRef pixs, IntPtr pangle, IntPtr pconf, IntPtr pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearchScorePivot")]
        internal static extern int pixFindSkewSweepAndSearchScorePivot(HandleRef pixs, IntPtr pangle, IntPtr pconf, IntPtr pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta, int pivot);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewOrthogonalRange")]
        internal static extern int pixFindSkewOrthogonalRange(HandleRef pixs, IntPtr pangle, IntPtr pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, float confprior);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindDifferentialSquareSum")]
        internal static extern int pixFindDifferentialSquareSum(HandleRef pixs, IntPtr psum);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindNormalizedSquareSum")]
        internal static extern int pixFindNormalizedSquareSum(HandleRef pixs, IntPtr phratio, IntPtr pvratio, IntPtr pfract);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamSpix")]
        internal static extern IntPtr pixReadStreamSpix(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderSpix")]
        internal static extern int readHeaderSpix([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderSpix")]
        internal static extern int freadHeaderSpix(HandleRef fp, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sreadHeaderSpix")]
        internal static extern int sreadHeaderSpix(HandleRef data, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr piscmap);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamSpix")]
        internal static extern int pixWriteStreamSpix(HandleRef fp, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemSpix")]
        internal static extern IntPtr pixReadMemSpix(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemSpix")]
        internal static extern int pixWriteMemSpix(HandleRef pdata, IntPtr psize, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSerializeToMemory")]
        internal static extern int pixSerializeToMemory(HandleRef pixs, IntPtr pdata, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeserializeFromMemory")]
        internal static extern IntPtr pixDeserializeFromMemory(HandleRef data, IntPtr nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackCreate")]
        internal static extern IntPtr lstackCreate(int nalloc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackDestroy")]
        internal static extern void lstackDestroy(HandleRef plstack, int freeflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackAdd")]
        internal static extern int lstackAdd(HandleRef lstack, IntPtr item);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackRemove")]
        internal static extern IntPtr lstackRemove(HandleRef lstack);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackGetCount")]
        internal static extern int lstackGetCount(HandleRef lstack);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackPrint")]
        internal static extern int lstackPrint(HandleRef fp, IntPtr lstack);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strcodeCreateFromFile")]
        internal static extern int strcodeCreateFromFile(HandleRef filein, int fileno, IntPtr outdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getStructStrFromFile")]
        internal static extern int l_getStructStrFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int field, IntPtr pstr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindStrokeLength")]
        internal static extern int pixFindStrokeLength(HandleRef pixs, IntPtr tab8, IntPtr plength);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindStrokeWidth")]
        internal static extern int pixFindStrokeWidth(HandleRef pixs, float thresh, IntPtr tab8, IntPtr pwidth, IntPtr pnahisto);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindStrokeWidth")]
        internal static extern IntPtr pixaFindStrokeWidth(HandleRef pixa, float thresh, IntPtr tab8, int debug);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaModifyStrokeWidth")]
        internal static extern IntPtr pixaModifyStrokeWidth(HandleRef pixas, float targetw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyStrokeWidth")]
        internal static extern IntPtr pixModifyStrokeWidth(HandleRef pixs, float width, float targetw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetStrokeWidth")]
        internal static extern IntPtr pixaSetStrokeWidth(HandleRef pixas, int width, int thinfirst, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetStrokeWidth")]
        internal static extern IntPtr pixSetStrokeWidth(HandleRef pixs, int width, int thinfirst, int connectivity);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddSingleTextblock")]
        internal static extern IntPtr pixAddSingleTextblock(HandleRef pixs, IntPtr bmf, IntPtr textstr, uint val, int location, IntPtr poverflow);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddTextlines")]
        internal static extern IntPtr pixAddTextlines(HandleRef pixs, IntPtr bmf, IntPtr textstr, uint val, int location);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetTextblock")]
        internal static extern int pixSetTextblock(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int x0, int y0, int wtext, int firstindent, out int poverflow);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetTextline")]
        internal static extern int pixSetTextline(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int x0, int y0, out int pwidth, out int poverflow);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddTextNumber")]
        internal static extern IntPtr pixaAddTextNumber(HandleRef pixas, IntPtr bmf, IntPtr na, uint val, int location);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddTextlines")]
        internal static extern IntPtr pixaAddTextlines(HandleRef pixas, IntPtr bmf, IntPtr sa, uint val, int location);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddPixWithText")]
        internal static extern int pixaAddPixWithText(HandleRef pixa, IntPtr pixs, int reduction, IntPtr bmf, IntPtr textstr, uint val, int location);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetLineStrings")]
        internal static extern IntPtr bmfGetLineStrings(HandleRef bmf, IntPtr textstr, int maxw, int firstindent, IntPtr ph);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetWordWidths")]
        internal static extern IntPtr bmfGetWordWidths(HandleRef bmf, IntPtr textstr, IntPtr sa);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetStringWidth")]
        internal static extern int bmfGetStringWidth(HandleRef bmf, IntPtr textstr, IntPtr pw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitStringToParagraphs")]
        internal static extern IntPtr splitStringToParagraphs(HandleRef textstr, int splitflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadTiff")]
        internal static extern IntPtr pixReadTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamTiff")]
        internal static extern IntPtr pixReadStreamTiff(HandleRef fp, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteTiff")]
        internal static extern int pixWriteTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, int comptype, IntPtr modestring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteTiffCustom")]
        internal static extern int pixWriteTiffCustom([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, int comptype, IntPtr modestring, IntPtr natags, IntPtr savals, IntPtr satypes, IntPtr nasizes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamTiff")]
        internal static extern int pixWriteStreamTiff(HandleRef fp, IntPtr pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadFromMultipageTiff")]
        internal static extern IntPtr pixReadFromMultipageTiff(HandleRef fname, IntPtr poffset);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadMultipageTiff")]
        internal static extern IntPtr pixaReadMultipageTiff(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeMultipageTiff")]
        internal static extern int writeMultipageTiff(HandleRef dirin, IntPtr substr, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeMultipageTiffSA")]
        internal static extern int writeMultipageTiffSA(HandleRef sa, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fprintTiffInfo")]
        internal static extern int fprintTiffInfo(HandleRef fpout, IntPtr tiffile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "tiffGetCount")]
        internal static extern int tiffGetCount(HandleRef fp, IntPtr pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getTiffResolution")]
        internal static extern int getTiffResolution(HandleRef fp, IntPtr pxres, IntPtr pyres);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderTiff")]
        internal static extern int readHeaderTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int n, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr pres, IntPtr pcmap, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderTiff")]
        internal static extern int freadHeaderTiff(HandleRef fp, int n, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr pres, IntPtr pcmap, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemTiff")]
        internal static extern int readHeaderMemTiff(HandleRef cdata, IntPtr size, int n, IntPtr pwidth, IntPtr pheight, IntPtr pbps, IntPtr pspp, IntPtr pres, IntPtr pcmap, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findTiffCompression")]
        internal static extern int findTiffCompression(HandleRef fp, IntPtr pcomptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractG4DataFromFile")]
        internal static extern int extractG4DataFromFile(HandleRef filein, IntPtr pdata, IntPtr pnbytes, IntPtr pw, IntPtr ph, IntPtr pminisblack);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemTiff")]
        internal static extern IntPtr pixReadMemTiff(HandleRef cdata, IntPtr size, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemFromMultipageTiff")]
        internal static extern IntPtr pixReadMemFromMultipageTiff(HandleRef cdata, IntPtr size, IntPtr poffset);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemTiff")]
        internal static extern int pixWriteMemTiff(HandleRef pdata, IntPtr psize, IntPtr pix, int comptype);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemTiffCustom")]
        internal static extern int pixWriteMemTiffCustom(HandleRef pdata, IntPtr psize, IntPtr pix, int comptype, IntPtr natags, IntPtr savals, IntPtr satypes, IntPtr nasizes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setMsgSeverity")]
        internal static extern int setMsgSeverity(int newsev);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorInt")]
        internal static extern int returnErrorInt(HandleRef msg, IntPtr procname, int ival);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorFloat")]
        internal static extern float returnErrorFloat(HandleRef msg, IntPtr procname, float fval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorPtr")]
        internal static extern IntPtr returnErrorPtr(HandleRef msg, IntPtr procname, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "filesAreIdentical")]
        internal static extern int filesAreIdentical(HandleRef fname1, IntPtr fname2, IntPtr psame);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnLittleEnd16")]
        internal static extern ushort convertOnLittleEnd16(ushort shortin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnBigEnd16")]
        internal static extern ushort convertOnBigEnd16(ushort shortin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnLittleEnd32")]
        internal static extern uint convertOnLittleEnd32(uint wordin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnBigEnd32")]
        internal static extern uint convertOnBigEnd32(uint wordin);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCorruptByDeletion")]
        internal static extern int fileCorruptByDeletion(HandleRef filein, float loc, float size, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCorruptByMutation")]
        internal static extern int fileCorruptByMutation(HandleRef filein, float loc, float size, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genRandomIntegerInRange")]
        internal static extern int genRandomIntegerInRange(int range, int seed, IntPtr pval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_roundftoi")]
        internal static extern int lept_roundftoi(float fval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashStringToUint64")]
        internal static extern int l_hashStringToUint64(HandleRef str, IntPtr phash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashPtToUint64")]
        internal static extern int l_hashPtToUint64(int x, int y, IntPtr phash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashFloat64ToUint64")]
        internal static extern int l_hashFloat64ToUint64(int nbuckets, double val, IntPtr phash);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findNextLargerPrime")]
        internal static extern int findNextLargerPrime(int start, IntPtr pprime);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_isPrime")]
        internal static extern int lept_isPrime(ulong n, IntPtr pis_prime, IntPtr pfactor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertBinaryToGrayCode")]
        internal static extern uint convertBinaryToGrayCode(uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertGrayCodeToBinary")]
        internal static extern uint convertGrayCodeToBinary(uint val);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getLeptonicaVersion")]
        internal static extern IntPtr getLeptonicaVersion();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "startTimer")]
        internal static extern void startTimer(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stopTimer")]
        internal static extern float stopTimer(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getCurrentTime")]
        internal static extern void l_getCurrentTime(HandleRef sec, IntPtr usec);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getFormattedDate")]
        internal static extern IntPtr l_getFormattedDate();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringNew")]
        internal static extern IntPtr stringNew(HandleRef src);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCopy")]
        internal static extern int stringCopy(HandleRef dest, IntPtr src, int n);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplace")]
        internal static extern int stringReplace(HandleRef pdest, IntPtr src);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringLength")]
        internal static extern int stringLength(HandleRef src, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCat")]
        internal static extern int stringCat(HandleRef dest, IntPtr size, IntPtr src);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringJoin")]
        internal static extern IntPtr stringJoin(HandleRef src1, IntPtr src2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringJoinIP")]
        internal static extern int stringJoinIP(HandleRef psrc1, IntPtr src2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReverse")]
        internal static extern IntPtr stringReverse(HandleRef src);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strtokSafe")]
        internal static extern IntPtr strtokSafe(HandleRef cstr, IntPtr seps, IntPtr psaveptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringSplitOnToken")]
        internal static extern int stringSplitOnToken(HandleRef cstr, IntPtr seps, IntPtr phead, IntPtr ptail);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringRemoveChars")]
        internal static extern IntPtr stringRemoveChars(HandleRef src, IntPtr remchars);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringFindSubstr")]
        internal static extern int stringFindSubstr(HandleRef src, IntPtr sub, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplaceSubstr")]
        internal static extern IntPtr stringReplaceSubstr(HandleRef src, IntPtr sub1, IntPtr sub2, IntPtr pfound, IntPtr ploc);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplaceEachSubstr")]
        internal static extern IntPtr stringReplaceEachSubstr(HandleRef src, IntPtr sub1, IntPtr sub2, IntPtr pcount);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "arrayFindEachSequence")]
        internal static extern IntPtr arrayFindEachSequence(HandleRef data, IntPtr datalen, IntPtr sequence, IntPtr seqlen);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "arrayFindSequence")]
        internal static extern int arrayFindSequence(HandleRef data, IntPtr datalen, IntPtr sequence, IntPtr seqlen, IntPtr poffset, IntPtr pfound);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "reallocNew")]
        internal static extern IntPtr reallocNew(HandleRef pindata, int oldsize, int newsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryRead")]
        internal static extern IntPtr l_binaryRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadStream")]
        internal static extern IntPtr l_binaryReadStream(HandleRef fp, IntPtr pnbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadSelect")]
        internal static extern IntPtr l_binaryReadSelect([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr start, IntPtr nbytes, IntPtr pnread);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadSelectStream")]
        internal static extern IntPtr l_binaryReadSelectStream(HandleRef fp, IntPtr start, IntPtr nbytes, IntPtr pnread);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryWrite")]
        internal static extern int l_binaryWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr operation, IntPtr data, IntPtr nbytes);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nbytesInFile")]
        internal static extern IntPtr nbytesInFile(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fnbytesInFile")]
        internal static extern IntPtr fnbytesInFile(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryCopy")]
        internal static extern IntPtr l_binaryCopy(HandleRef datas, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCopy")]
        internal static extern int fileCopy(HandleRef srcfile, IntPtr newfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileConcatenate")]
        internal static extern int fileConcatenate(HandleRef srcfile, IntPtr destfile);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileAppendString")]
        internal static extern int fileAppendString([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr str);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenReadStream")]
        internal static extern IntPtr fopenReadStream(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenWriteStream")]
        internal static extern IntPtr fopenWriteStream([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr modestring);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenReadFromMemory")]
        internal static extern IntPtr fopenReadFromMemory(HandleRef data, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenWriteWinTempfile")]
        internal static extern IntPtr fopenWriteWinTempfile();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_fopen")]
        internal static extern IntPtr lept_fopen([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr mode);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_fclose")]
        internal static extern int lept_fclose(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_calloc")]
        internal static extern IntPtr lept_calloc(HandleRef nmemb, IntPtr size);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_free")]
        internal static extern void lept_free(HandleRef ptr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_mkdir")]
        internal static extern int lept_mkdir(HandleRef subdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rmdir")]
        internal static extern int lept_rmdir(HandleRef subdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_direxists")]
        internal static extern void lept_direxists(HandleRef dir, IntPtr pexists);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rm_match")]
        internal static extern int lept_rm_match(HandleRef subdir, IntPtr substr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rm")]
        internal static extern int lept_rm(HandleRef subdir, IntPtr tail);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rmfile")]
        internal static extern int lept_rmfile(HandleRef filepath);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_mv")]
        internal static extern int lept_mv(HandleRef srcfile, IntPtr newdir, IntPtr newtail, IntPtr pnewpath);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_cp")]
        internal static extern int lept_cp(HandleRef srcfile, IntPtr newdir, IntPtr newtail, IntPtr pnewpath);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitPathAtDirectory")]
        internal static extern int splitPathAtDirectory(HandleRef pathname, IntPtr pdir, IntPtr ptail);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitPathAtExtension")]
        internal static extern int splitPathAtExtension(HandleRef pathname, IntPtr pbasename, IntPtr pextension);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pathJoin")]
        internal static extern IntPtr pathJoin(HandleRef dir, IntPtr fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "appendSubdirs")]
        internal static extern IntPtr appendSubdirs(HandleRef basedir, IntPtr subdirs);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSepCharsInPath")]
        internal static extern int convertSepCharsInPath(HandleRef path, int type);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genPathname")]
        internal static extern IntPtr genPathname(HandleRef dir, IntPtr fname);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeTempDirname")]
        internal static extern int makeTempDirname(HandleRef result, IntPtr nbytes, IntPtr subdir);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "modifyTrailingSlash")]
        internal static extern int modifyTrailingSlash(HandleRef path, IntPtr nbytes, int flag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_makeTempFilename")]
        internal static extern IntPtr l_makeTempFilename();

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractNumberFromFilename")]
        internal static extern int extractNumberFromFilename(HandleRef fname, int numpre, int numpost);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSimpleCaptcha")]
        internal static extern IntPtr pixSimpleCaptcha(HandleRef pixs, int border, int nterms, uint seed, uint color, int cmapflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRandomHarmonicWarp")]
        internal static extern IntPtr pixRandomHarmonicWarp(HandleRef pixs, float xmag, float ymag, float xfreq, float yfreq, int nx, int ny, uint seed, int grayval);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWarpStereoscopic")]
        internal static extern IntPtr pixWarpStereoscopic(HandleRef pixs, int zbend, int zshiftt, int zshiftb, int ybendt, int ybendb, int redleft);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontal")]
        internal static extern IntPtr pixStretchHorizontal(HandleRef pixs, int dir, int type, int hmax, int operation, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontalSampled")]
        internal static extern IntPtr pixStretchHorizontalSampled(HandleRef pixs, int dir, int type, int hmax, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontalLI")]
        internal static extern IntPtr pixStretchHorizontalLI(HandleRef pixs, int dir, int type, int hmax, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShear")]
        internal static extern IntPtr pixQuadraticVShear(HandleRef pixs, int dir, int vmaxt, int vmaxb, int operation, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShearSampled")]
        internal static extern IntPtr pixQuadraticVShearSampled(HandleRef pixs, int dir, int vmaxt, int vmaxb, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShearLI")]
        internal static extern IntPtr pixQuadraticVShearLI(HandleRef pixs, int dir, int vmaxt, int vmaxb, int incolor);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStereoFromPair")]
        internal static extern IntPtr pixStereoFromPair(HandleRef pix1, IntPtr pix2, float rwt, float gwt, float bwt);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedCreate")]
        internal static extern IntPtr wshedCreate(HandleRef pixs, IntPtr pixm, int mindepth, int debugflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedDestroy")]
        internal static extern void wshedDestroy(HandleRef pwshed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedApply")]
        internal static extern int wshedApply(HandleRef wshed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedBasins")]
        internal static extern int wshedBasins(HandleRef wshed, IntPtr ppixa, IntPtr pnalevels);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedRenderFill")]
        internal static extern IntPtr wshedRenderFill(HandleRef wshed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedRenderColors")]
        internal static extern IntPtr wshedRenderColors(HandleRef wshed);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamWebP")]
        internal static extern IntPtr pixReadStreamWebP(HandleRef fp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemWebP")]
        internal static extern IntPtr pixReadMemWebP(HandleRef filedata, IntPtr filesize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderWebP")]
        internal static extern int readHeaderWebP([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pw, IntPtr ph, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemWebP")]
        internal static extern int readHeaderMemWebP(HandleRef data, IntPtr size, IntPtr pw, IntPtr ph, IntPtr pspp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteWebP")]
        internal static extern int pixWriteWebP([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pixs, int quality, int lossless);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamWebP")]
        internal static extern int pixWriteStreamWebP(HandleRef fp, IntPtr pixs, int quality, int lossless);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemWebP")]
        internal static extern int pixWriteMemWebP(HandleRef pencdata, IntPtr pencsize, IntPtr pixs, int quality, int lossless);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteFiles")]
        internal static extern int pixaWriteFiles(HandleRef rootname, IntPtr pixa, int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWrite")]
        internal static extern int pixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef pix, ImageFileFormat format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteAutoFormat")]
        internal static extern int pixWriteAutoFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStream")]
        internal static extern int pixWriteStream(HandleRef fp, IntPtr pix, int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteImpliedFormat")]
        internal static extern int pixWriteImpliedFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr pix, int quality, int progressive);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixChooseOutputFormat")]
        internal static extern int pixChooseOutputFormat(HandleRef pix);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getImpliedFileFormat")]
        internal static extern int getImpliedFileFormat(HandleRef filename);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAutoFormat")]
        internal static extern int pixGetAutoFormat(HandleRef pix, IntPtr pformat);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getFormatExtension")]
        internal static extern IntPtr getFormatExtension(int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMem")]
        internal static extern int pixWriteMem(HandleRef pdata, IntPtr psize, IntPtr pix, int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_fileDisplay")]
        internal static extern int l_fileDisplay(HandleRef fname, int x, int y, float scale);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplay")]
        internal static extern int pixDisplay(HandleRef pixs, int x, int y);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWithTitle")]
        internal static extern int pixDisplayWithTitle(HandleRef pixs, int x, int y, IntPtr title, int dispflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiled")]
        internal static extern int pixSaveTiled(HandleRef pixs, IntPtr pixa, float scalefactor, int newrow, int space, int dp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiledOutline")]
        internal static extern int pixSaveTiledOutline(HandleRef pixs, IntPtr pixa, float scalefactor, int newrow, int space, int linewidth, int dp);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiledWithText")]
        internal static extern int pixSaveTiledWithText(HandleRef pixs, IntPtr pixa, int outwidth, int newrow, int space, int linewidth, IntPtr bmf, IntPtr textstr, uint val, int location);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_chooseDisplayProg")]
        internal static extern void l_chooseDisplayProg(int selection);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWrite")]
        internal static extern int pixDisplayWrite(HandleRef pixs, int reduction);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWriteFormat")]
        internal static extern int pixDisplayWriteFormat(HandleRef pixs, int reduction, int format);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayMultiple")]
        internal static extern int pixDisplayMultiple(int res, float scalefactor, IntPtr fileout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "zlibCompress")]
        internal static extern IntPtr zlibCompress(HandleRef datain, IntPtr nin, IntPtr pnout);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "zlibUncompress")]
        internal static extern IntPtr zlibUncompress(HandleRef datain, IntPtr nin, IntPtr pnout);
    }
}
