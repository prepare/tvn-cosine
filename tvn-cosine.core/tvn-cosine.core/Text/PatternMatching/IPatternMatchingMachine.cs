using System.Collections.Generic;

namespace Tvn.Cosine.Text.PatternMatching
{
    public interface IPatternMatchingMachine
    {
        ICollection<IPattern> Match(IEnumerable<char> input); 
        void Match(IEnumerable<char> input, PatternFoundDelegate patternMatchFound);
    }
}
