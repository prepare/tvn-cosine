using Tvn.Cosine.Data;

namespace Tvn.Cosine.Text.Nlp
{
    public class PartOfSpeechTag : IName, IDescription
    {
        private PartOfSpeechTag(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Description { get; }
        public string Name { get; }
    }
}
