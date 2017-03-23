namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default rectangle interface.
    /// </summary>
    public interface IRectangle : IPoint, ISize
    {
        /// <summary>
        /// Check if rectangle contains a point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <returns>Boolean indicating if rectangle contains a point.</returns>
        bool Contains(IPoint point);

        /// <summary>
        /// Check if rectangle intersects another rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to test.</param>
        /// <returns>Boolean indicating if rectangle intersects another rectangle.</returns>
        bool Intersects(IRectangle rectangle);

        /// <summary>
        /// Defalate the rectangle by specified width and height.
        /// </summary>
        /// <param name="width">The width to deflate by.</param>
        /// <param name="height">The height to deflate by.</param>
        /// <exception cref="System.OverflowException">Throws exception if deflate would result in overflow.</exception>
        /// <returns>A new deflated rectangle.</returns>
        IRectangle Deflate(uint width, uint height);

        /// <summary>
        /// Inflate the rectangle by specified width and height.
        /// </summary>
        /// <param name="width">The width to inflate by.</param>
        /// <param name="height">The height to inflate by.</param>
        /// <exception cref="System.OverflowException">Throws exception if deflate would result in overflow.</exception>
        /// <returns>A new inflated rectangle.</returns>
        IRectangle Inflate(uint width, uint height);

        /// <summary>
        /// Get the intersection of a rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to test.</param>
        /// <returns>A new rectangle where it intersects, null if it does not intersect.</returns>
        IRectangle Intersection(IRectangle rectangle);

        /// <summary>
        /// Union two rectangles
        /// </summary>
        /// <param name="rectangle">The rectangle to union.</param>
        /// <returns>A new rectangle with union applied.</returns>
        IRectangle Union(IRectangle rectangle);
    }
}
