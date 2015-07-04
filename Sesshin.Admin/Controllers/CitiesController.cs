using Sesshin.DAL;
using Sesshin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sesshin.Admin.Controllers
{
    public class CitiesController : ApiController
    {
         
        //public List<City> GetByName(string val) 
        //{
        //    using (var db = new SesshinAdminContext())
        //    {
        //        var ret = db.Cities.Where(c => c.Name.StartsWith(val))
        //                            .Take(5).ToList();
                
        //        return ret;
        //    }   
        //}

        // GET api/cities
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cities/תל
        public dynamic Get(string query)
        {
            using (var db = new SesshinAdminContext())
            {
                var ret = db.Cities.Where(c => c.Name.StartsWith(query))
                                    .OrderBy(c => c.Name)
                                    .Take(5).Select(x => new { Id = x.Id, Name = x.Name}).ToList();

                return ret;
            }  
        }

        // POST api/cities
        //public List<City> Post(string query)
        //{
        //    using (var db = new SesshinAdminContext())
        //    {
        //        var ret = db.Cities.Where(c => c.Name.StartsWith(query))
        //                            .OrderBy(c => c.Name)
        //                            .Take(5).ToList();

        //        return ret;
        //    }  
        //}

        // PUT api/cities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cities/5
        public void Delete(int id)
        {
        }
    }
}
