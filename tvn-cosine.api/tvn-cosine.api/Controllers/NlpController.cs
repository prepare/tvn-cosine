using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tvn_cosine.api.Controllers
{
    public class NlpController : ApiController
    {
        // GET: api/Nlp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Nlp/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Nlp
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Nlp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Nlp/5
        public void Delete(int id)
        {
        }
    }
}
