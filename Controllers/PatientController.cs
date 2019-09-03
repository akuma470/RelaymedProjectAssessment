using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;//Model class reference
using System.Data.Entity.Infrastructure;//RetryLimitExceededException class reference

namespace PatientManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private SampleEntities db = new SampleEntities();

        // GET: /Patient/ Patient List
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: /Patient /Details
        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patients.SingleOrDefault(p => p.MedicalRecordNumber == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: /Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Patient/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                //System.Console.WriteLine(ex);
            }
            return View(patient);
        }

        // GET: /Patient/Update
        public ActionResult Edit(int? id)
        {
            Patient pat = new Patient();
            //id = pat.MedicalRecordNumber;
            Patient patient = db.Patients.SingleOrDefault(p => p.MedicalRecordNumber == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: /Patient/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var patientToUpdate = db.Patients.SingleOrDefault(p => p.MedicalRecordNumber == id);
            if (TryUpdateModel(patientToUpdate, "",
               new string[] { "MedicalRecordNumber", "FirstName", "LastName", "DateOfBirth", "Address" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                catch (Exception ex)
                { 
                    ModelState.AddModelError("", ex);
                    //System.Console.WriteLine(ex);
                }
            }
            return View(patientToUpdate);
        }

        // GET: /Patient/Delete
        public ActionResult Delete(int id = 0)
        {
            Patient patient = db.Patients.SingleOrDefault(p => p.MedicalRecordNumber == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: /Patient/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient pat = new Patient();
            Patient patient = db.Patients.SingleOrDefault(p => p.MedicalRecordNumber == id);
            db.Patients.Remove(patient);
            TryUpdateModel<Patient>(pat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
