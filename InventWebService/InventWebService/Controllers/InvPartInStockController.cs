using InventWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InventWebService.Controllers
{
    public class InvPartInStockController : ApiController
    {
        IRepository<InvPartInStock> repository_ = new InventoryPartInStockRepository();

        // GET api/InvPartInStock
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();

            List<InvPartInStock> parts = repository_.GetAll();

            response = Request.CreateResponse(HttpStatusCode.OK, parts);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // GET api/InvPartInStock/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse();
            InvPartInStock partInStock = repository_.GetById(id);

            response = Request.CreateResponse(HttpStatusCode.OK, partInStock);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // POST api/InvPartInStock
        [HttpPost]
        public HttpResponseMessage Post(InvPartInStock partInStock)
        {
            //if (!this.ModelState.IsValid)
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));

            Boolean result = repository_.Insert(partInStock);

            HttpContext context = HttpContext.Current;

            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            return response;
        }

        // PUT api/InvPartInStock/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/InvPartInStock/5
        public void Delete(int id)
        {
        }
    }
}
