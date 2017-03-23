namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a file.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// The document format of this file.
        /// </summary>
        IDocumentFormat DocumentFormat { get; }

        /// <summary>
        /// The full path of this file.
        /// </summary>
        string FullPath { get; }
    }
}
