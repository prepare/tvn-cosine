using System.Runtime.InteropServices;

namespace tvn_cosine.ocr.tesseract
{
    public class TextRenderer : ResultRenderer
    {
        public TextRenderer(string fileName)
        {
            var pointer = Native.DllImports.TessTextRendererCreate(fileName);
            handleRef = new HandleRef(this, pointer);
        }
    }
}
