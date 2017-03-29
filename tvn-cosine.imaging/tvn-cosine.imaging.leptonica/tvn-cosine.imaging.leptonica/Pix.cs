using System;
using System.Runtime.InteropServices;

namespace leptonica.net
{
    public class Pix : IDisposable, ICloneable, geometry.net.ISize
    {
        public readonly HandleRef handleRef;
        private readonly geometry.net.ISize size;

        #region ctors
        public Pix(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
            this.size = new geometry.net.Size((ulong)Width, (ulong)Height);
        }

        public Pix(int width, int height, int depth)
            : this(Native.DllImports.pixCreate(width, height, depth))
        { }

        public Pix(string fileName)
            : this(Native.DllImports.pixRead(fileName))
        {
            if (!System.IO.File.Exists(fileName))
                throw new System.IO.FileNotFoundException();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Width in pixels 
        /// </summary>  
        public int Width
        {
            get
            {
                return Native.DllImports.pixGetWidth(handleRef);
            }
            set
            {
                Native.DllImports.pixSetWidth(handleRef, value);
            }
        }

        /// <summary>
        /// height in pixels   
        /// </summary>  
        public int Height
        {
            get
            {
                return Native.DllImports.pixGetHeight(handleRef);
            }
            set
            {
                Native.DllImports.pixSetHeight(handleRef, value);
            }
        }

        /// <summary>
        /// Area in pixels
        /// </summary>
        public int Area
        {
            get
            {
                return Width * Height;
            }
        }

        /// <summary>
        /// depth in bits  
        /// </summary>  
        public int Depth
        {
            get
            {
                return Native.DllImports.pixGetDepth(handleRef);
            }
            set
            {
                Native.DllImports.pixSetDepth(handleRef, value);
            }
        }

        /// <summary>
        /// number of samples per pixel
        /// </summary>  
        public int SamplesPerPixel
        {
            get
            {
                return Native.DllImports.pixGetSpp(handleRef);
            }
            set
            {
                Native.DllImports.pixSetSpp(handleRef, value);
            }
        }

        /// <summary>
        /// 32-bit words/line 
        /// </summary>  
        public int WordsPerLine
        {
            get
            {
                return Native.DllImports.pixGetWpl(handleRef);
            }
            set
            {
                Native.DllImports.pixSetWpl(handleRef, value);
            }
        }

        /// <summary>
        /// reference count (1 if no clones) 
        /// </summary>  
        public int RefCount
        {
            get
            {
                return Native.DllImports.pixGetRefcount(handleRef);
            }
            set
            {
                Native.DllImports.pixChangeRefcount(handleRef, value);
            }
        }

        /// <summary>
        /// image res (ppi) in x direction 
        /// (use 0 if unknown)   
        /// </summary>  
        public int XResolution
        {
            get
            {
                return Native.DllImports.pixGetXRes(handleRef);
            }
            set
            {
                Native.DllImports.pixSetXRes(handleRef, value);
            }
        }

        /// <summary>
        /// image res (ppi) in y direction 
        ///  (use 0 if unknown)  
        /// </summary>  
        public int YResolution
        {
            get
            {
                return Native.DllImports.pixGetYRes(handleRef);
            }
            set
            {
                Native.DllImports.pixSetYRes(handleRef, value);
            }
        }

        /// <summary>
        /// input file format, IFF_*    
        /// </summary>  
        public ImageFileFormat InputFileFormat
        {
            get
            {
                return Native.DllImports.pixGetInputFormat(handleRef);
            }
            set
            {
                Native.DllImports.pixSetInputFormat(handleRef, value);
            }
        }

        /// <summary>
        /// text string associated with pix  
        /// </summary>   
        public string Text
        {
            get
            {
                var pointer = Native.DllImports.pixGetText(handleRef);

                return Marshal.PtrToStringAnsi(pointer);
            }
            set
            {
                Native.DllImports.pixSetText(handleRef, value);
            }
        }

        private PixColorMap colorMap;
        /// <summary>
        /// colormap (may be null)    
        /// </summary>  
        public PixColorMap ColorMap
        {
            get
            {
                var pointer = Native.DllImports.pixGetColormap(handleRef);
                if ((colorMap == null || colorMap.handleRef.Handle != pointer)
                    && pointer != IntPtr.Zero)
                {
                    colorMap = new PixColorMap(pointer);
                }

                return colorMap;
            }
            set
            {
                Native.DllImports.pixSetColormap(handleRef, value.handleRef);
                colorMap = value;
            }
        }

        /// <summary>
        /// the image data   
        /// </summary>  
        public IntPtr Data
        {
            get
            {
                return Native.DllImports.pixGetData(handleRef);
            }
            set
            {
                Native.DllImports.pixSetData(handleRef, value);
            }
        }

        #endregion

        #region Methods
        public bool Save(string fileName, ImageFileFormat format)
        {
            if (!Enum.IsDefined(typeof(ImageFileFormat), format))
            {
                throw new InvalidCastException(string.Format("{0} does not exist as a valid file format.", format));
            }

            return Native.DllImports.pixWrite(fileName, handleRef, format) == 0;
        }
        #endregion

        #region ISize Support
        ulong geometry.net.ISize.Width
        {
            get
            {
                return size.Width;
            }
        }

        ulong geometry.net.ISize.Height
        {
            get
            {
                return size.Height;
            }
        }

        ulong geometry.net.ISize.Area
        {
            get
            {
                return size.Area;
            }
        }
        #endregion

        #region ICloneable Support
        public object Clone()
        {
            var pixd = Native.DllImports.pixCopy(IntPtr.Zero, handleRef);
            return new Pix(pixd);
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                var toDispose = handleRef.Handle;
                Native.DllImports.pixDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        ~Pix()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
