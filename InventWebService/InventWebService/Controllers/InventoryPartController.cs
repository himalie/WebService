using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventWebService.Models;
using System.Web;

namespace InventWebService.Controllers
{
    public class InventoryPartController : ApiController
    {
        IRepository<InventoryPart> repository_ = new InventoryPartRepository();

        // GET api/inventorypart
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();

            List<InventoryPart> parts = repository_.GetAll();

            response = Request.CreateResponse(HttpStatusCode.OK, parts);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // GET api/inventorypart/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse();
            InventoryPart part = repository_.GetById(id);

            response = Request.CreateResponse(HttpStatusCode.OK, part);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // POST api/inventorypart
        [HttpPost]
        public HttpResponseMessage Post(InventoryPart part)
        {
            //if (!this.ModelState.IsValid)
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));

            Boolean result = repository_.Insert(part);

            HttpContext context = HttpContext.Current;

            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            return response;
        }

        // PUT api/inventorypart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/inventorypart/5
        public void Delete(int id)
        {
        }
    }
}
