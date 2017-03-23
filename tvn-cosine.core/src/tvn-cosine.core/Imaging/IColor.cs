namespace tvn.cosine.Imaging
{
    /// <summary>
    /// Default IColor interface.
    /// </summary>
    public interface IColor : IName
    {
        /// <summary>
        ///The alpha component.
        /// </summary>
        byte A { get; }

        /// <summary>
        /// The blue component.
        /// </summary>
        byte B { get; }

        /// <summary>
        /// The green component value.
        /// </summary>
        byte G { get; }

        /// <summary>
        /// The red component value.
        /// </summary>
        byte R { get; } 
    }
}
