namespace tvn_cosine.core
{
    public interface IParentChild<T>
    {
        T Parent { get; }
        System.Collections.Generic.ICollection<T> Children { get; }
    }
}
