using System.Collections.Generic;
using Tvn.Cosine.Data.Media;

namespace Tvn.Cosine.Text.Nlp
{
    public class Document : IText
    {
        public Document(string text, List<Sentence> sentences, List<Token> tokens)
        {
            Text = text;
            Sentences = sentences;
            Tokens = tokens;
        }

        public List<Sentence> Sentences { get; }
        public List<Token> Tokens { get; }
        public string Text { get; } 
    }
}
