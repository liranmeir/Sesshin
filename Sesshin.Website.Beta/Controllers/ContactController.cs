using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sesshin.Models;

namespace Sesshin.Website.Beta.Controllers
{
    public class ContactController : ApiController
    {
        // GET: api/Contact
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contact/5
        public string Get(int id)
        {
            return "value";
        }

        //todo stopping point

        // POST: api/Contact
        public HttpResponseMessage Post([FromBody]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ContactResponse() {IsSuccess = true, Message="ההודעה התקבלה נציג יצור איתך קשר בהקדם"};
                    var response = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "איראה שגיאה אנא נסה שוב");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }

    public class ContactResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
