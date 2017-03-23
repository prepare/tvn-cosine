namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default ISize implementation.
    /// </summary>
    public class Size : ISize
    {
        #region ctors
        /// <summary>
        /// Creates a new instance of size.
        /// </summary>
        /// <param name="width">The width of the size.</param>
        /// <param name="height">The height of the size.</param>
        public Size(uint width, uint height)
        {
            Width = width;
            Height = height;
            Area = width * height;
        }
        #endregion

        /// <summary>
        /// Area of size.
        /// </summary>
        public uint Area { get; }

        /// <summary>
        /// Height of size.
        /// </summary>
        public uint Height { get; }

        /// <summary>
        /// Width of size.
        /// </summary>
        public uint Width { get; }
    }
}
