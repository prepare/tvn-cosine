namespace Tvn.Cosine.Text.Nlp
{
    public class Token
    {
        public Token(string tokenValue,
                     PartOfSpeechTag partOfSpeechTag,
                     NamedEntity namedEntity)
        {
            Value = tokenValue;
            PartOfSpeechTag = partOfSpeechTag;
            NamedEntity = namedEntity;
        }

        public string Value { get; }
        public PartOfSpeechTag PartOfSpeechTag { get; }
        public NamedEntity NamedEntity { get; } 
    }
}
