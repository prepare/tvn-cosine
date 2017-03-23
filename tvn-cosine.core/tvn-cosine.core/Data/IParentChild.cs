namespace Tvn.Cosine.Data
{
    /// <summary>
    /// Generic interface to implement a parent child relationship.
    /// </summary>
    public interface IParentChild<T>
    {
        /// <summary>
        /// Parent of item.
        /// </summary>
        T Parent { get; }

        /// <summary>
        /// Children of item.
        /// </summary>
        System.Collections.Generic.ICollection<T> Children { get; }
    }
}
