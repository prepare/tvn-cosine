using System.Collections.Generic; 

namespace Tvn.Cosine.Text.Nlp
{
    public class Sentence
    {
        private readonly string sentence;

        public Sentence(string sentence,
                        ICollection<Token> tokens,
                        ICollection<Token> namedEntities, 
                        Sentiment sentiment, 
                        IDictionary<Sentiment, double> sentimentDictionary)
        {
            this.sentence = sentence;
            Tokens = tokens;
            NamedEntities = namedEntities;
            SentimentDictionary = sentimentDictionary;
            Sentiment = sentiment;
        }
         
        public ICollection<Token> Tokens { get; }
        public ICollection<Token> NamedEntities { get; }
        public IDictionary<Sentiment, double> SentimentDictionary { get; }
        public Sentiment Sentiment { get; }

        public override string ToString()
        {
            return this.sentence;
        }
    }
}
