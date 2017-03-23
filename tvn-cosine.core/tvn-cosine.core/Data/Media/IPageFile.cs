namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a page file.
    /// </summary>
    public interface IPageFile : IId, IFile
    {
        /// <summary>
        /// The page this file belongs.
        /// </summary>
        IPage Page { get; } 
    }
}
