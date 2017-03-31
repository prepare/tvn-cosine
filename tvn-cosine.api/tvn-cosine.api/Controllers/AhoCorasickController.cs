using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tvn_cosine.api.Controllers
{
    public class AhoCorasickController : ApiController
    {
        // GET: api/AhoCorasick
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AhoCorasick/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AhoCorasick
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AhoCorasick/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AhoCorasick/5
        public void Delete(int id)
        {
        }
    }
}
