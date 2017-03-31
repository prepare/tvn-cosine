using System;
using Tvn.Cosine.Data;

namespace tvn_cosine.api.Models
{
    public class ExceptionModel : IDateCreated
    {
        public DateTime DateCreated { get; set; }
        public string ExceptionMessage { get; set; }
        public TimeSpan RequestDuration { get; set; }

        public override string ToString()
        {
            return string.Format("{{DateCreated: {0},ExceptionMessage: {1}, RequestDuration: {2}}}", DateCreated, ExceptionMessage, RequestDuration);
        }
    }
}