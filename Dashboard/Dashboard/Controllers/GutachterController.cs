using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class GutachterController : ODataController
    {
        private readonly IGutachterRepository _repository;

        public GutachterController(IGutachterRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [Queryable(AllowedQueryOptions=AllowedQueryOptions.All)]
        public IQueryable<Gutachter> Get()
        {
            return _repository.ReadAll().AsQueryable();
        }

        // GET api/values/5
        public Gutachter Get(int id)
        {
            return _repository.Read(id);
        }

        // POST api/values
        public HttpResponseMessage Post(Gutachter gutachter)
        {
            var newId = _repository.Create(gutachter.Vorname, gutachter.Nachname, gutachter.EMail);

            return Request.CreateResponse(HttpStatusCode.Created, 
                "{ Id: " + newId + ", "
               + "  '_links': {"
               + "      'self':   { 'href': '/api/Gutachter/'" + newId + " }"
               + "}");
        }

        // PUT api/values/5
        public void Put(Gutachter gutachter)
        {
            _repository.Update(gutachter);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
