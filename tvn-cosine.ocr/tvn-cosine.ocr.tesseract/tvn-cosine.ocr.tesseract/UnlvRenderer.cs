using System;
using System.Runtime.InteropServices;

namespace tvn_cosine.ocr.tesseract
{
    public class UnlvRenderer : ResultRenderer
    {
        public UnlvRenderer(string fileName)
        {
            IntPtr pointer = Native.DllImports.TessUnlvRendererCreate(fileName);
            handleRef = new HandleRef(this, pointer);
        }
    }
}
