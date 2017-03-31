using System.Collections.Generic;

namespace tvn_cosine.api.Models
{
    public class PatternMatcherResponseModel : ResponseBase
    {
        ICollection<string> PatternsMatched { get; set; }
    }
}