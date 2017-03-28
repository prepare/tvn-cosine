using System;
using System.Collections.Generic;

namespace Tvn.Cosine.Text.PatternMatching
{
    public interface IPattern : IEnumerable<char>, 
                                IEquatable<IPattern>
    { }
}
