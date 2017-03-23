namespace tvn.cosine
{
    /// <summary>
    /// Interface to implement a generic Id field.
    /// </summary>
    public interface IId<T>
    {
        /// <summary>
        /// Id of item.
        /// </summary>
        T Id { get; }
    }

    /// <summary>
    /// Interface to implement a uint Id field.
    /// </summary>
    public interface IId : IId<uint>
    { }
}
