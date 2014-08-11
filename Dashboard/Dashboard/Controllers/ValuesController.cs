using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Gutachter> Get()
        {
            return null;
        }

        // GET api/values/5
        public dynamic Get(int id)
        {
            return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
