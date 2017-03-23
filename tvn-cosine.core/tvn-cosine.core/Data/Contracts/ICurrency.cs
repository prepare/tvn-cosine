namespace Tvn.Cosine.Data.Contracts
{
    /// <summary>
    /// Interface for a currency.
    /// </summary>
    public interface ICurrency : IId<string>, IName
    {
        /// <summary>
        /// The code of the currency.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Symbol for the currency.
        /// </summary>
        string Symbol { get; }
    }
}
