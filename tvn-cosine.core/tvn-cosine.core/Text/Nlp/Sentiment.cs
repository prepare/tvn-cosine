using Tvn.Cosine.Data;

namespace Tvn.Cosine.Text.Nlp
{
    public class Sentiment : IId, IName
    {
        public Sentiment(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public uint Id { get; }
        public string Name { get; }
    }
}
