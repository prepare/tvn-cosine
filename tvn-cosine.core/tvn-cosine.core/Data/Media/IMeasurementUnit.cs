namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a measurement unit.
    /// </summary>
    public interface IMeasurementUnit : IId, IDescription, IPrefix
    {
        /// <summary>
        /// The measurement system for this measurement unit.
        /// </summary>
        IMeasurementSystem MeasurementSystem { get; }
    }
}
