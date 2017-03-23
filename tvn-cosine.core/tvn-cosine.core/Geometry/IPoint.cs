namespace Tvn.Cosine.Geometry
{
    /// <summary>
    /// Default point interface.
    /// </summary>
    public interface IPoint<T>
    {
        /// <summary>
        /// X coordinate of point.
        /// </summary>
        T X { get; }

        /// <summary>
        /// Y coordinate of point.
        /// </summary>
        T Y { get; }
    }

    /// <summary>
    /// Default point interface.
    /// </summary>
    public interface IPoint : IPoint<int>
    { }
}
