using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    public interface ILanguage : Data.ILanguage
    {
        ICollection<IPublication> Publications { get; }
    }
}
