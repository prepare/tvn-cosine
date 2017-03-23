namespace Tvn.Cosine.Data
{
    /// <summary>
    /// Interface to implement a IsDeleted field.
    /// </summary>
    public interface IIsDeleted
    {
        /// <summary>
        /// Value indicating if item is deleted.
        /// </summary>
        bool IsDeleted { get; }
    }
}
