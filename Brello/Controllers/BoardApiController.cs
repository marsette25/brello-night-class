using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Brello.Controllers
{
    public class BoardApiController : ApiController
    {
        // GET: api/BoardApi

       public string Get()
        {
            return "Hello, is it me you're looking for?";
        }
            /*
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/BoardApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BoardApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BoardApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BoardApi/5
        public void Delete(int id)
        {
        }
    }
}
