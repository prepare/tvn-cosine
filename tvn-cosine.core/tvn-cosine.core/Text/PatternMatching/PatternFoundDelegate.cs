using System.Collections.Generic;

namespace Tvn.Cosine.Text.PatternMatching
{
    public delegate void PatternFoundDelegate(IPatternMatchingMachine sender, ISet<IPattern> patternsFound, uint position);
}
