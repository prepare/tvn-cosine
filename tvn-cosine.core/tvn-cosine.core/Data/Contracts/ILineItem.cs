namespace Tvn.Cosine.Data.Contracts
{
    public interface ILineItem : IId, IDescription
    {
        ICurrency Currency { get; }
        decimal Units { get; }
        decimal PricePerUnit { get; }
    }
}
