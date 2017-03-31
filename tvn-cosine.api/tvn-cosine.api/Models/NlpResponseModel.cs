using Tvn.Cosine.Text.Nlp;

namespace tvn_cosine.api.Models
{
    public class NlpResponseModel : ResponseBase
    {
        public Document Document { get; set; }
    }
}