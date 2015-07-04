using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Sesshin.DAL;
using Sesshin.Model;
using Sesshin.Service;
using System.Data.Entity;

namespace Sesshin.Cons
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestActiveTrail();

            TestThearapistScreen();


        }

        private static void TestThearapistScreen()
        {
            var ctx = new SesshinAdminContext();

            //ctx.ThreatmentTypes.Add(new ThreatmentType {Name = "שיאצו"});
            //ctx.SaveChanges();
            //var query = ctx.ThreatmentTypes.Where(x=>x.Name== "שיאצו");
            //var res = query.ToList();


            //ctx.Therapists.Add(new Therapist { FirstName = "jhony",LastName = "boy",Phone = "123123", Email = "asdfasdf"});
            //ctx.SaveChanges();

            var city = ctx.Cities.FirstOrDefault(c => c.Name == "רמלה");

            var thr = new Therapist()
            {
                Id = 3, FirstName = "jhony", LastName = "guy", Phone = "123123", Email = "asdfasdf"
            };

            city.Therapists.Add(thr);

            ctx.Entry(thr).State = EntityState.Modified;
            ctx.SaveChanges();


            var query = ctx.Therapists.Where(x => x.FirstName == "jhony");
            var res = query.ToList();


            //Parallel.ForEach(res, obj =>
            //{
            //    JavaScriptSerializer js = new JavaScriptSerializer();
            //    string json = js.Serialize(obj);
            //    Console.WriteLine(json);
            //});
        }

        private static void TestActiveTrail()
        {
            var customerService = new CustomerService();//IocConfig.IocContiner.Resolve<ICustomerService>();

            var customer = new Customer
            {
                FirstName = "LIRAN",
                LastName = "Meir",
                Email = "liranmeir@gmail.com",
                Address = new Address { City = "תל אביב" },
                Aniversery = DateTime.Now,
                IsAcceptEmail = true
            };

            customerService.UploadToActiveTrailIfAccepted(customer);
        }
    }
}
