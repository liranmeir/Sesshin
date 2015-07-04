
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Sesshin.Model;
using Sesshin.DAL;
 

namespace Sesshin.Admin.Controllers
{   
    public class TherapistsController : Controller
    {
        private SesshinAdminContext context = new SesshinAdminContext();

        //
        // GET: /Therapists/

        public ViewResult Index()
        {
            return View(context.Therapists.Include(therapist => therapist.ThreatmentTypes).ToList());
        }

        //
        // GET: /Therapists/Details/5

        public ViewResult Details(int id)
        {
            Therapist therapist = context.Therapists.Single(x => x.Id == id);
            return View(therapist);
        }

        //
        // GET: /Therapists/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Therapists/Create

        [HttpPost]
        public ActionResult Create(Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                context.Therapists.Add(therapist);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(therapist);
        }
        
        //
        // GET: /Therapists/Edit/5
 
        public ActionResult Edit(int id)
        {
            Therapist therapist = context.Therapists.Single(x => x.Id == id);
            return View(therapist);
        }

        //
        // POST: /Therapists/Edit/5

        [HttpPost]
        public ActionResult Edit(Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                context.Entry(therapist).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(therapist);
        }

        //
        // GET: /Therapists/Delete/5
 
        public ActionResult Delete(int id)
        {
            Therapist therapist = context.Therapists.Single(x => x.Id == id);
            return View(therapist);
        }

        //
        // POST: /Therapists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Therapist therapist = context.Therapists.Single(x => x.Id == id);
            context.Therapists.Remove(therapist);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}