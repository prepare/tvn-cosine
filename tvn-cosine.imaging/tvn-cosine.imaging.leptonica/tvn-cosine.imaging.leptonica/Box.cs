using System.Runtime.InteropServices; 

namespace leptonica.net
{
    public class Box : geometry.net.IRectangle, System.ICloneable, System.IDisposable
    {
        public readonly HandleRef handleRef;
        private geometry.net.IRectangle rectangle;

        #region ctors
        public Box(System.IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
            this.rectangle = new geometry.net.Rectangle(X, Y, (ulong)Width, (ulong)Height);
        }

        public Box(int x, int y, int width, int height)
            : this(Native.DllImports.boxCreate(x, y, width, height))
        { }
        #endregion

        #region Properties  
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
                this.rectangle = new geometry.net.Rectangle(value, this.rectangle.Y, this.rectangle.Width, this.rectangle.Height);

                Native.DllImports.boxSetGeometry(handleRef, (int)this.rectangle.X, (int)this.rectangle.Y, (int)this.rectangle.Width, (int)this.rectangle.Height);
            }
        }

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
                this.rectangle = new geometry.net.Rectangle(this.rectangle.X, value, this.rectangle.Width, this.rectangle.Height);

                Native.DllImports.boxSetGeometry(handleRef, (int)this.rectangle.X, (int)this.rectangle.Y, (int)this.rectangle.Width, (int)this.rectangle.Height);
            }
        }

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
                this.rectangle = new geometry.net.Rectangle(this.rectangle.X, this.rectangle.Y, (ulong)value, this.rectangle.Height);
                Native.DllImports.boxSetGeometry(handleRef, (int)this.rectangle.X, (int)this.rectangle.Y, (int)this.rectangle.Width, (int)this.rectangle.Height);
            }
        }

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
                this.rectangle = new geometry.net.Rectangle(this.rectangle.X, this.rectangle.Y, this.rectangle.Width, (ulong)value);
                Native.DllImports.boxSetGeometry(handleRef, (int)this.rectangle.X, (int)this.rectangle.Y, (int)this.rectangle.Width, (int)this.rectangle.Height);
            }
        }
        #endregion

        #region IRectangle Support
        long geometry.net.IRectangle.X2
        {
            get
            {
                return rectangle.X2;
            }
        }

        long geometry.net.IRectangle.Y2
        {
            get
            {
                return rectangle.Y2;
            }
        }

        long geometry.net.IPoint.X
        {
            get
            {
                return rectangle.X;
            }
        }

        long geometry.net.IPoint.Y
        {
            get
            {
                return rectangle.Y;
            }
        }

        ulong geometry.net.ISize.Width
        {
            get
            {
                return rectangle.Width;
            }
        }

        ulong geometry.net.ISize.Height
        {
            get
            {
                return rectangle.Height;
            }
        }

        ulong geometry.net.ISize.Area
        {
            get
            {
                return rectangle.Area;
            }
        }

        bool geometry.net.IRectangle.Intersects(geometry.net.IRectangle rectangle)
        {
            return this.rectangle.Intersects(rectangle);
        }

        geometry.net.IRectangle geometry.net.IRectangle.Intersection(geometry.net.IRectangle rectangle)
        {
            return this.rectangle.Intersection(rectangle);
        }

        geometry.net.IRectangle geometry.net.IRectangle.Inflate(ulong width, ulong height)
        {
            return this.rectangle.Inflate(width, height);
        }

        geometry.net.IRectangle geometry.net.IRectangle.Deflate(ulong width, ulong height)
        {
            return this.rectangle.Deflate(width, height);
        }

        geometry.net.IRectangle geometry.net.IRectangle.Union(geometry.net.IRectangle other)
        {
            return this.rectangle.Union(other);
        }
         
        bool geometry.net.IRectangle.Contains(geometry.net.IPoint point)
        {
            return rectangle.Contains(point);
        }

        #endregion

        #region ICloneable Support
        public object Clone()
        {
            var box = Native.DllImports.boxCopy(handleRef);
            return new Box(box);
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
                Native.DllImports.boxDestroy(ref toDispose);

                disposedValue = true;
            }
        }

        ~Box()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
}
