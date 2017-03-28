using System.Collections.Generic;

namespace Tvn.Cosine.Text.Nlp
{
    public class Document
    {
        private readonly string document;

        public Document(string document, 
                        ICollection<Sentence> sentences, 
                        ICollection<Token> tokens)
        {
            this.document = document;
            Sentences = sentences;
            Tokens = tokens;
        }

        public ICollection<Sentence> Sentences { get; }
        public ICollection<Token> Tokens { get; }

        public override string ToString()
        {
            return this.document;
        }
    }
}
