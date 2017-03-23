using System.Collections.Generic;

namespace Tvn.Cosine.Data
{
    /// <summary>
    /// Interface for a user.
    /// </summary>
    public interface IUser : IId, IDateCreated, IDateLastUpdated, IName, IEmail
    {
        /// <summary>
        /// Encrypted Password.
        /// </summary>
        byte[] PasswordHash { get; }

        /// <summary>
        /// Password salt.
        /// </summary>
        byte[] PasswordSalt { get; }

        /// <summary>
        /// Collection of languases loaded for user.
        /// </summary>
        ICollection<ILanguage> Languages { get; }
    }
}
