using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsectCatalog.Controllers
{
    public class InsectController : ApiController
    {
        // GET: api/Insect
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Insect/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Insect
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Insect/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Insect/5
        public void Delete(int id)
        {
        }
    }
}
