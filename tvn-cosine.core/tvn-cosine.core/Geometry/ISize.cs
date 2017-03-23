namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default size interface.
    /// </summary>
    public interface ISize<T>
    {
        /// <summary>
        /// Width of size.
        /// </summary>
        T Width { get; }

        /// <summary>
        /// Height of size.
        /// </summary>
        T Height { get; }

        /// <summary>
        /// Area of size.
        /// </summary>
        T Area { get; }
    }

    /// <summary>
    /// Default size interface.
    /// </summary>
    public interface ISize : ISize<uint>
    { }
}
