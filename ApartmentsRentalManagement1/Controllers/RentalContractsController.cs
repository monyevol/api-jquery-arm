using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.Controllers
{
    public class RentalContractsController : Controller
    {
        private RentManagementModel db = new RentManagementModel();

        // GET: RentalContracts
        public ActionResult Index()
        {
            return View(db.RentalContracts.ToList());
        }

        // GET: RentalContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalContract rentalContract = db.RentalContracts.Find(id);
            if (rentalContract == null)
            {
                return HttpNotFound();
            }
            return View(rentalContract);
        }

        // GET: RentalContracts/Create
        public ActionResult Create()
        {
            List<SelectListItem> maritals = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Unknown",   Value = "Unknown"   },
                new SelectListItem() { Text = "Single",    Value = "Single"    },
                new SelectListItem() { Text = "Widdow",    Value = "Widdow"    },
                new SelectListItem() { Text = "Married",   Value = "Married"   },
                new SelectListItem() { Text = "Divorced",  Value = "Divorced"  },
                new SelectListItem() { Text = "Separated", Value = "Separated" }
            };

            ViewBag.MaritalStatus = maritals;

            return View();
        }

        // POST: RentalContracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalContractId,ContractNumber,EmployeeNumber,ContractDate,FirstName,LastName,MaritalStatus,NumberOfChildren,UnitNumber,RentStartDate")] RentalContract rentalContract)
        {
            if (ModelState.IsValid)
            {
                db.RentalContracts.Add(rentalContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalContract);
        }

        // GET: RentalContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalContract rentalContract = db.RentalContracts.Find(id);
            if (rentalContract == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> maritals = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Single",    Value = "Single",    Selected = (rentalContract.MaritalStatus == "Single")    },
                new SelectListItem() { Text = "Widdow",    Value = "Widdow",    Selected = (rentalContract.MaritalStatus == "Widdow")    },
                new SelectListItem() { Text = "Married",   Value = "Married",   Selected = (rentalContract.MaritalStatus == "Married")   },
                new SelectListItem() { Text = "Unknown",   Value = "Unknown",   Selected = (rentalContract.MaritalStatus == "Unknown")   },
                new SelectListItem() { Text = "Divorced",  Value = "Divorced",  Selected = (rentalContract.MaritalStatus == "Divorced")  },
                new SelectListItem() { Text = "Separated", Value = "Separated", Selected = (rentalContract.MaritalStatus == "Separated") }
            };

            ViewBag.MaritalStatus = maritals;

            return View(rentalContract);
        }

        // POST: RentalContracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalContractId,ContractNumber,EmployeeNumber,ContractDate,FirstName,LastName,MaritalStatus,NumberOfChildren,UnitNumber,RentStartDate")] RentalContract rentalContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalContract);
        }

        // GET: RentalContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalContract rentalContract = db.RentalContracts.Find(id);
            if (rentalContract == null)
            {
                return HttpNotFound();
            }
            return View(rentalContract);
        }

        // POST: RentalContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalContract rentalContract = db.RentalContracts.Find(id);
            db.RentalContracts.Remove(rentalContract);
            db.SaveChanges();
            return RedirectToAction("Index");
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
