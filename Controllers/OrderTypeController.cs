using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Controllers
{
    public class OrderTypeController : Controller
    {
        private SampleEntities db = new SampleEntities();

        // GET: OrderType/Order Type List
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "SpecimenType")
            {
                return View(db.OrderTypes.Where(p => p.SpecimenType == search || search == null).ToList());
            }
            else
            {
                return View(db.OrderTypes.Where(p =>p.OrderCode.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: /OrderType/Delete
        public ActionResult Delete(string id = null)
        {
            OrderType orderType = db.OrderTypes.SingleOrDefault(p => p.OrderCode == id);
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // POST: /OrderType/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OrderType order = new OrderType();
            OrderType orderType = db.OrderTypes.SingleOrDefault(p => p.OrderCode == id);
            db.OrderTypes.Remove(orderType);
            TryUpdateModel<OrderType>(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}