using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sesshin.DAL;
using Sesshin.Model;

namespace Sesshin.Admin.Controllers
{
    public class TherapistApiController : ApiController
    {

        private readonly ITherapistRepository therapistRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TherapistApiController() : this(new TherapistRepository())
        {
        }

        public TherapistApiController(ITherapistRepository therapistRepository)
        {
			this.therapistRepository = therapistRepository;
        }

        // GET api/therapistapi
        public IEnumerable<Therapist> Get()
        {
            return therapistRepository.All.AsEnumerable();
        }

        // GET api/therapistapi/5
        public Therapist Get(int id)
        {
            try
            {
                Therapist therapist = therapistRepository.Find(id);
                return therapist;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
        }

        // POST api/therapistapi
        public HttpResponseMessage Post([FromBody]Therapist therapist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    therapistRepository.InsertOrUpdate(therapist);
                    var response = Request.CreateResponse<Therapist>(HttpStatusCode.Created, therapist);
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/therapistapi/5
        public HttpResponseMessage Put(int id, [FromBody]Therapist therapist)
        {
            try
            {
                therapistRepository.InsertOrUpdate(therapist);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/therapistapi/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                therapistRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.therapistRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
