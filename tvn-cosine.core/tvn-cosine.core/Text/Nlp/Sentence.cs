using System.Collections.Generic;
using Tvn.Cosine.Data.Media;

namespace Tvn.Cosine.Text.Nlp
{
    public class Sentence : IText
    {
        public Sentence(string text, 
                        List<Token> tokens, 
                        List<Token> namedEntities, 
                        Sentiment sentiment, 
                        Dictionary<Sentiment, double> sentimentDictionary)
        {
            Text = text;
            Tokens = tokens;
            NamedEntities = namedEntities;
            SentimentDictionary = sentimentDictionary;
            Sentiment = sentiment;
        }

        public string Text { get; }
        public List<Token> Tokens { get; }
        public List<Token> NamedEntities { get; }
        public Dictionary<Sentiment, double> SentimentDictionary { get; }
        public Sentiment Sentiment { get; } 
    }
}
