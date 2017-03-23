namespace Tvn.Cosine.Text.Nlp
{
    public interface INlpEngine
    {
        string Version { get; }
        Document Process(string input);
    }
}
