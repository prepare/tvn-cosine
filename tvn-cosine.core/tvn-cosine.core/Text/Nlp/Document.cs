using System.Collections.Generic;
using Tvn.Cosine.Data.Media;

namespace Tvn.Cosine.Text.Nlp
{
    public class Document : IText
    {
        public Document(string text, ICollection<Sentence> sentences, ICollection<Token> tokens)
        {
            Text = text;
            Sentences = sentences;
            Tokens = tokens;
        }

        public ICollection<Sentence> Sentences { get; }
        public ICollection<Token> Tokens { get; }
        public string Text { get; } 
    }
}
