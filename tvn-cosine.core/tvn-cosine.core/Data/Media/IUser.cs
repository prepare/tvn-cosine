using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface for a user.
    /// </summary>
    public interface IUser : IId, IDateCreated, IDateLastUpdated, IName, IEmail
    {
        /// <summary>
        /// Encrypted Password.
        /// </summary>
        byte[] Password { get; }

        /// <summary>
        /// Collection of languases loaded for user.
        /// </summary>
        ICollection<ILanguage> Languages { get; }
    }
}
