using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tvn.cosine.Text.PatternMatching.AhoCorasick
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
