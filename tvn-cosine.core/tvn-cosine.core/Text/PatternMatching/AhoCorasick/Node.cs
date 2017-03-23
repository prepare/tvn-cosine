using System.Collections.Generic;

namespace Tvn.Cosine.Text.PatternMatching.AhoCorasick
{
    internal class Node
    {
        internal const Node fail = null;
        internal readonly Dictionary<char, Node> gotoStateDictionary; 

        internal Node(char value)
        {
            Value = value;
            gotoStateDictionary = new Dictionary<char, Node>();
            Output = new HashSet<IPattern>();
        }

        internal char Value { get; }

        internal virtual Node Failure { get; set; }
           
        internal ICollection<Node> Edges { get { return gotoStateDictionary.Values; } }

        internal ICollection<IPattern> Output { get; }
    }
}
