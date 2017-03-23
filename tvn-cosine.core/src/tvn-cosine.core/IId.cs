namespace tvn.cosine
{
    public interface IId<T>
    {
        T Id { get; }
    }

    public interface IId : IId<uint>
    { }
}
