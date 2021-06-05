using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HRM_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Delete(int id)
        {
        }
    }
}
