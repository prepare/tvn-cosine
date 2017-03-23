using System;
using System.Collections.Generic;

namespace Tvn.Cosine.Data.Contracts
{
    public interface IContract : IId, IDateCreated, IIsActive, IIsDeleted
    {
        ICollection<ILineItem> LineItems { get; }

        IStatus Status { get; }

        IDecisionState DecisionState { get; }
        IDecision Decision { get; }
        IUser DecisionMadeBy { get; }
        DateTime DecisionMadeDate { get; }

        DateTime StartDate { get; }
        DateTime? EndDate { get; }
    }
}
