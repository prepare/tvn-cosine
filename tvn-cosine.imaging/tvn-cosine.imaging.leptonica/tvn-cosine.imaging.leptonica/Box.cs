using System.Runtime.InteropServices;
using Tvn.Cosine.Geometry;

namespace Leptonica
{
    /// <summary>
    /// box.h
    /// </summary>
    public class Box : IPoint<int>, ISize<int>, System.ICloneable, System.IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly HandleRef handleRef;

        #region ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        public Box(System.IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Box(int x, int y, int width, int height)
            : this(Native.DllImports.boxCreate(x, y, width, height))
        { }
        #endregion

        #region Properties  
        /// <summary>
        /// 
        /// </summary>
        public int X
        {
            get
            {
                int x, y, width, height;
                Native.DllImports.boxGetGeometry(handleRef, out x, out y, out width, out height);
                return x;
            }
            set
            {
                Native.DllImports.boxSetGeometry(handleRef, value, this.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Y
        {
            get
            {
                int x, y, width, height;
                Native.DllImports.boxGetGeometry(handleRef, out x, out y, out width, out height);
                return y;
            }
            set
            {
                Native.DllImports.boxSetGeometry(handleRef, this.X, value, this.Width, this.Height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                int x, y, width, height;
                Native.DllImports.boxGetGeometry(handleRef, out x, out y, out width, out height);
                return width;
            }
            set
            {
                Native.DllImports.boxSetGeometry(handleRef, this.X, this.Y, value, this.Height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                int x, y, width, height;
                Native.DllImports.boxGetGeometry(handleRef, out x, out y, out width, out height);
                return height;
            }
            set
            {
                Native.DllImports.boxSetGeometry(handleRef, this.X, this.Y, this.Width, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Area
        {
            get
            {
                return Width * Height;
            }
        }
        #endregion

        #region ICloneable Support
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var box = Native.DllImports.boxCopy(handleRef);
            return new Box(box);
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                var toDispose = handleRef.Handle;
                Native.DllImports.boxDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Box()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
}
