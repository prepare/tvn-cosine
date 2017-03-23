namespace tvn.cosine.Text.PatternMatching.AhoCorasick
{
    internal class RootNode  : Node  
    { 
        internal RootNode()
            : base('ϵ')
        {
            Failure = this; // a rootnode fails towards itself
        } 
    }
}
