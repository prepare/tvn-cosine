using System;
using System.Runtime.InteropServices;

namespace Tvn.Cosine.Ocr.Tesseract
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
