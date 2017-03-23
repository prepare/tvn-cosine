namespace tvn.cosine.Geometry
{
    /// <summary>
    /// Default size interface.
    /// </summary>
    public interface ISize
    {
        /// <summary>
        /// Width of size.
        /// </summary>
        uint Width { get; }

        /// <summary>
        /// Height of size.
        /// </summary>
        uint Height { get; }

        /// <summary>
        /// Area of size.
        /// </summary>
        uint Area { get; }
    }
}
