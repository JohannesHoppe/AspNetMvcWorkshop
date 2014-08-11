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
            var hans = new Gutachter
                       {
                           Vorname = "Hans",
                           Nachname = "Müller"
                       };

            var context = new DashboardContext();
            context.Gutachter.Add(hans);
            context.SaveChanges();

            return new[] { hans };
        }

        // GET api/values/5
        public dynamic Get(int id)
        {
            return new
                   {
                       Test = DateTime.Now
                   };
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
