namespace tvn.cosine
{
    public interface IParentChild<T>
    {
        T Parent { get; }
        System.Collections.Generic.ICollection<T> Children { get; }
    }
}
