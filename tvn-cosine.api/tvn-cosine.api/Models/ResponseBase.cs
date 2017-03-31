using System;
using Tvn.Cosine.Data;

namespace tvn_cosine.api.Models
{
    public abstract class ResponseBase : IId<Guid>
    {
        public Guid Id { get; set; }
        public TimeSpan RequestDuration { get; set; }
    }
}