namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default IRectangle implementation.
    /// </summary>
    public class Rectangle : IRectangle
    {
        #region ctors
        /// <summary>
        /// Creates a new instance of rectangle.
        /// </summary>
        /// <param name="x">X coordinate of rectangle.</param>
        /// <param name="y">Y coordinate of rectangle.</param>
        /// <param name="width">Width of rectangle.</param>
        /// <param name="height">Height of rectangle.</param>
        public Rectangle(int x, int y, uint width, uint height)
        {
            X = x;
            X2 = x + width;
            Y = y;
            Y2 = y + height;
            Width = width;
            Height = height;
            Area = width * height;
        }
        #endregion

        /// <summary>
        /// Area rectangle.
        /// </summary>
        public uint Area { get; }

        /// <summary>
        /// Height of rectangle.
        /// </summary>
        public uint Height { get; }

        /// <summary>
        /// Width of rectangle.
        /// </summary>
        public uint Width { get; }

        /// <summary>
        /// X coordinate of rectangle.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y coordinate of rectangle.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// X2 coordinate of rectangle.
        /// </summary>
        public long X2 { get; }

        /// <summary>
        /// Y2 coordinate of rectangle.
        /// </summary>
        public long Y2 { get; }

        /// <summary>
        /// Check if rectangle contains a point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <returns>Boolean indicating if rectangle contains a point.</returns>
        public bool Contains(IPoint<int> point)
        {
            return X >= point.X && X2 <= point.X
                && Y >= point.Y && Y2 <= point.Y;
        }

        /// <summary>
        /// Defalate the rectangle by specified width and height.
        /// </summary>
        /// <param name="width">The width to deflate by.</param>
        /// <param name="height">The height to deflate by.</param>
        /// <exception cref="System.OverflowException">Throws exception if deflate would result in overflow.</exception>
        /// <returns>A new deflated rectangle.</returns>
        public IRectangle<int, uint> Deflate(uint width, uint height)
        { 
            if (X + width > int.MaxValue
             || Y + height > int.MaxValue)
            {
                throw new System.OverflowException("Deflate resulted in a XY coordinate > int.MaxValue.");
            }

            // Ensure that deflate only deflate to min of zero 0.
            if (width > Width
             || height > Height)
            {
                width = Width;
                height = Height;
            }

            int x = (int)(X + width);
            int y = (int)(Y + height);

            height = Height - height;
            width = Width - width;

            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Inflate the rectangle by specified width and height.
        /// </summary>
        /// <param name="width">The width to inflate by.</param>
        /// <param name="height">The height to inflate by.</param>
        /// <exception cref="System.OverflowException">Throws exception if deflate would result in overflow.</exception>
        /// <returns>A new inflated rectangle.</returns>
        public IRectangle<int, uint> Inflate(uint width, uint height)
        {
            if (X - width < int.MinValue
             || Y - height < int.MinValue)
            {
                throw new System.OverflowException("Deflate resulted in a XY coordinate < int.MinValue.");
            }

            if (((long)Width + width) > uint.MaxValue
             || ((long)Height + height) > uint.MaxValue)
            {
                throw new System.OverflowException("Inflate resulted in a width or height > uint.MaxValue.");
            }

            int x = (int)(X - width);
            int y = (int)(Y - height);

            height = Height + height;
            width = Width + width;

            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Get the intersection of a rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to test.</param>
        /// <returns>A new rectangle where it intersects, null if it does not intersect.</returns>
        public IRectangle<int, uint> Intersection(IRectangle<int, uint> rectangle)
        {
            if (Intersects(rectangle))
            {
                int x = System.Math.Max(this.X, rectangle.X);
                int y = System.Math.Max(this.Y, rectangle.Y);
                long x2 = System.Math.Min(this.X2, rectangle.X + rectangle.Width);
                long y2 = System.Math.Min(this.Y2, rectangle.Y + rectangle.Height);

                uint width = (uint)(x2 - x);
                uint height = (uint)(y2 - y);

                return new Rectangle(x, y, width, height);
            }

            return null;
        }

        /// <summary>
        /// Check if rectangle intersects another rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to test.</param>
        /// <returns>Boolean indicating if rectangle intersects another rectangle.</returns>
        public bool Intersects(IRectangle<int, uint> rectangle)
        {
            return X <= rectangle.X + rectangle.Width
                && X2 >= rectangle.X
                && Y <= rectangle.Y + rectangle.Height
                && Y2 >= rectangle.Y;
        }

        /// <summary>
        /// Union two rectangles
        /// </summary>
        /// <param name="rectangle">The rectangle to union.</param>
        /// <returns>A new rectangle with union applied.</returns>
        public IRectangle<int, uint> Union(IRectangle<int, uint> rectangle)
        {
            int x = System.Math.Min(X, rectangle.X);
            int y = System.Math.Min(Y, rectangle.Y);
            long x2 = System.Math.Max(X2, rectangle.X + rectangle.Width);
            long y2 = System.Math.Max(Y2, rectangle.Y + rectangle.Height);
            uint width = (uint)(x2 - x);
            uint height = (uint)(y2 - y);

            return new Rectangle(x, y, width, height);
        }
    }
}
