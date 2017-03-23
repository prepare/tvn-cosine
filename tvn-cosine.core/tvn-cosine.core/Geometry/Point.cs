namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default IPoint implementation.
    /// </summary>
    public class Point : IPoint
    {
        #region ctors
        /// <summary>
        /// Create a new instance of point.
        /// </summary>
        /// <param name="x">X coordinate of point.</param>
        /// <param name="y">Y coordinate of point.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        /// <summary>
        /// X coordinate of point.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y coordinate of point.
        /// </summary>
        public int Y { get; }
    }
}
