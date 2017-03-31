using System.Web.Http;
using tvn_cosine.api.Models;

namespace tvn_cosine.api.Controllers
{
    public class NlpController : ApiController
    {
        // GET: api/Nlp
        public IHttpActionResult Get()
        {
            return Ok(string.Format("Stanford Nlp Version: {0}", null));
        }
         
        // POST: api/Nlp
        public IHttpActionResult Post([FromBody]TextObjectModel value)
        {
            return Ok(string.Format("Stanford Nlp Version: {0}", null));
        } 
    }
}
