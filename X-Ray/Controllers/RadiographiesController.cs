using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using X_Ray.Models;

namespace X_Ray.Controllers
{
    public class RadiographiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Radiographies
        [Authorize(Roles=("Manager, Admin"))]
        public ActionResult Index()
        {
            return View(db.Radiographies.ToList());
        }

        // GET: Radiographies/Details/5
        [Authorize(Roles = ("Manager, Admin"))]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // GET: Radiographies/Create
        public ActionResult Create()
        {
            var users = db.Users.ToList();
            var list = users.Where(u => u.Department == "XRay" && u.Hospital == "Main Hospital").ToList();
            var selectlist = new SelectList(from x in list select new { x.Id , WholeName = x.Surname + " " + x.Name}, "Id", "WholeName");
            //var selectlist = new SelectList(list, "Id", "Surname");
            ViewBag.Users = selectlist;
            return View();
        }

        // POST: Radiographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientCode,Name,Surname,NameOfFather,NameOfMother,InsuranceCode,Gender,DateOfBirth,Address,HomePhone,WorkingPhone,MobilePhone,RadiographyCode,Reasoning,RadiographyActions,SuggestedDate,Priority,Status,Doctor")] Radiography radiography)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(radiography.Doctor.Id);
                radiography.Doctor = user;
                radiography.DateOfSubmission = DateTime.Now;
                radiography.CreatedBy = db.Users.Find(User.Identity.GetUserId());
                radiography.Created = DateTime.Now;
                db.Radiographies.Add(radiography);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(radiography);
        }

        // GET: Radiographies/Edit/5
        [Authorize(Roles = ("Manager, Admin"))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // POST: Radiographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ("Manager, Admin"))]
        public ActionResult Edit([Bind(Include = "Id,PatientCode,Name,Surname,NameOfFather,NameOfMother,InsuranceCode,Gender,DateOfBirth,Address,HomePhone,WorkingPhone,MobilePhone,RadiographyCode,DateOfSubmission,Reasoning,RadiographyActions,SuggestedDate,SuggestedDateTime,Priority,Status")] Radiography radiography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radiography).State = EntityState.Modified;
                radiography.Created = DateTime.Now;
                radiography.Modified = DateTime.Now;
                radiography.ModifiedBy = db.Users.Find(User.Identity.GetUserId());
                radiography.SuggestedDate = radiography.SuggestedDate + radiography.SuggestedDateTime;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radiography);
        }

        // GET: Radiographies/Delete/5
        [Authorize(Roles = ("Manager, Admin"))]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // POST: Radiographies/Delete/5
        [Authorize(Roles = ("Manager, Admin"))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radiography radiography = db.Radiographies.Find(id);
            db.Radiographies.Remove(radiography);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles=("Doctor,Manager,Admin"))]
        public ActionResult MyList()
        {
            var UserName = User.Identity.GetUserName();
            return View(db.Radiographies.Where(r => r.Doctor.UserName == UserName).ToList());
        }

        

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
