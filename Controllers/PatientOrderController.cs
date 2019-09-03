using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models; //Model class reference
using System.Data.Entity.Infrastructure;//RetryLimitExceededException class reference


namespace PatientManagementSystem.Controllers
{
    public class PatientOrderController : Controller
    {
        private SampleEntities db = new SampleEntities();

        // GET: /Patient Order List/
        public ActionResult Index()
        {
            List<PatientOrder> patientOrder = db.PatientOrders.ToList();
            return View(patientOrder);
        }

        //Get : /Patient Order /Delete
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            PatientOrder patientOrder = db.PatientOrders.SingleOrDefault(p => p.PatientOrderId == id);
            if (patientOrder == null)
            {
                return HttpNotFound();
            }
            return View(patientOrder);
        }

        //Post : /Patient Order /Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientOrder patOrder = new PatientOrder();

            PatientOrder patientOrder = db.PatientOrders.SingleOrDefault(p => p.PatientOrderId == id);
            db.PatientOrders.Remove(patientOrder);
            TryUpdateModel<PatientOrder>(patOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get : /Patient Order /Update
        public ActionResult Edit(int? id)
        {
            PatientOrder patOrder = new PatientOrder();
            //id = pat.MedicalRecordNumber;
            PatientOrder patientOrder = db.PatientOrders.SingleOrDefault(p => p.PatientOrderId == id);
            if (patientOrder == null)
            {
                return HttpNotFound();//Check code
            }
            return View(patientOrder);
        }

        //Post : /Patient Order /Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var patientOrderToUpdate = db.PatientOrders.SingleOrDefault(p => p.PatientOrderId == id);
            if (TryUpdateModel(patientOrderToUpdate, "",
               new string[] { "PatientOrderId", "CreationDate", "PatientId", "OrderCode", "Status" }))
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
            return View(patientOrderToUpdate);
        }

        // GET: /PatientOrder/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /PatientOrder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PatientOrder patientOrder)
        {
            PatientOrder po = new PatientOrder();
            //po.CreationDate = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    db.PatientOrders.Add(patientOrder);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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

            return View(patientOrder);
        }

        /*public ActionResult Create(int patientOrderId,int patientId, string orderCode, string status)
        {
            PatientOrder patientOrder = new PatientOrder();
            patientOrder.PatientOrderId = patientOrderId;
            patientOrder.CreationDate = DateTime.Now;
            patientOrder.PatientId = patientId;
            patientOrder.OrderCode = orderCode;
            patientOrder.Status = status;
            if (ModelState.IsValid)
            {
                db.PatientOrders.Add(patientOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientOrder);
        }*/

    }
}