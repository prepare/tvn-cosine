using System.Collections.Generic;
using Tvn.Cosine.Data.Media;

namespace Tvn.Cosine.Text.Nlp
{
    public class Sentence : IText
    {
        public Sentence(string text,
                        ICollection<Token> tokens,
                        ICollection<Token> namedEntities, 
                        Sentiment sentiment, 
                        IDictionary<Sentiment, double> sentimentDictionary)
        {
            Text = text;
            Tokens = tokens;
            NamedEntities = namedEntities;
            SentimentDictionary = sentimentDictionary;
            Sentiment = sentiment;
        }

        public string Text { get; }
        public ICollection<Token> Tokens { get; }
        public ICollection<Token> NamedEntities { get; }
        public IDictionary<Sentiment, double> SentimentDictionary { get; }
        public Sentiment Sentiment { get; } 
    }
}
