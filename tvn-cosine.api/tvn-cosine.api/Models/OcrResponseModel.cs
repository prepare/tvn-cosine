using System;
using Tvn.Cosine.Data;

namespace tvn_cosine.api.Models
{
    public class OcrResponseModel : IId<Guid>
    {
        public Guid Id { get; set; }
        public TimeSpan RequestDuration { get; set; }
        public string Text { get; set; }
    }
}