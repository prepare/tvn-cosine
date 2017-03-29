using System;
using System.Runtime.InteropServices;

namespace Tvn.Cosine.Ocr.Tesseract
{
    public class BoxTextRenderer : ResultRenderer
    {
        public BoxTextRenderer(string fileName)
        {
            IntPtr pointer = Native.DllImports.TessBoxTextRendererCreate(fileName);
            handleRef = new HandleRef(this, pointer);
        }
    }
}
