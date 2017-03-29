using System;
using System.Runtime.InteropServices;

namespace tvn_cosine.ocr.tesseract
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
