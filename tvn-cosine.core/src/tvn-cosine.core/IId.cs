namespace tvn_cosine.core
{
    public interface IId<T>
    {
        T Id { get; }
    }

    public interface IId : IId<uint>
    { }
}
