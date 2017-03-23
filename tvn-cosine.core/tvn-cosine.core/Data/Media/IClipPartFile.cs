namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface implementation for a clip part file.
    /// </summary>
    public interface IClipPartFile : IId, IFile
    {
        /// <summary>
        /// Clip part for this file.
        /// </summary>
        IClipPart ClipPart { get; }
    }
}
