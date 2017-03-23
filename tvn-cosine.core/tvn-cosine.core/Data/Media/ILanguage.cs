using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a language.
    /// </summary>
    public interface ILanguage : IId, IName, IPrefix
    {
        /// <summary>
        /// Collection of publications with this language.
        /// </summary>
        ICollection<IPublication> Publications { get; }
    }
}
