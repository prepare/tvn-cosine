using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a clip part.
    /// </summary>
    public interface IClipPart : IId, IDateCreated, IOrder, IText, IFontDetail
    {
        /// <summary>
        /// The clip associated with this part.
        /// </summary>
        IClip Clip { get; }

        /// <summary>
        /// Collection of files for this clip part.
        /// </summary>
        ICollection<IClipPartFile> ClipPartFiles { get; }
    }
}
