using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a page.
    /// </summary>
    public interface IPage : IId, IDateCreated
    {
        /// <summary>
        /// Issue of this page.
        /// </summary>
        IIssue Issue { get; }

        /// <summary>
        /// The user who created the page.
        /// </summary>
        IUser CreatedBy { get; }

        /// <summary>
        /// Collection of page files.
        /// </summary>
        ICollection<IPageFile> PageFiles { get; }

        /// <summary>
        /// The page number.
        /// </summary>
        ushort Number { get; }

        /// <summary>
        /// The publication section for this page.
        /// </summary>
        IPublicationSection PublicationSection { get; }

        /// <summary>
        /// The page status.
        /// </summary>
        IPageStatus PageStatus { get; }
    }
}
