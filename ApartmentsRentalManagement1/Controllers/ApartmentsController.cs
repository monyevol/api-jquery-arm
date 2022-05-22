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
    public class ApartmentsController : Controller
    {
        private RentManagementModel db = new RentManagementModel();

        // GET: Apartments
        public ActionResult Index()
        {
            return View(db.Apartments.ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            List<SelectListItem> conditions = new List<SelectListItem>();

            conditions.Add(new SelectListItem() { Text = "Unknown", Value = "Unknown" });
            conditions.Add(new SelectListItem() { Text = "Occupied", Value = "Occupied" });
            conditions.Add(new SelectListItem() { Text = "Available", Value = "Available" });
            conditions.Add(new SelectListItem() { Text = "Not Ready", Value = "Not Ready" });
            conditions.Add(new SelectListItem() { Text = "Needs Maintenance", Value = "Needs Maintenance" });

            ViewData["OccupancyStatus"] = conditions;

            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApartmentId,UnitNumber,Bedrooms,Bathrooms,MonthlyRate,SecurityDeposit,OccupancyStatus")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> conditions = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Unknown",           Value = "Unknown",           Selected = (apartment.OccupancyStatus == "Unknown")           },
                new SelectListItem() { Text = "Occupied",          Value = "Occupied",          Selected = (apartment.OccupancyStatus == "Occupied")          },
                new SelectListItem() { Text = "Available",         Value = "Available",         Selected = (apartment.OccupancyStatus == "Available")         },
                new SelectListItem() { Text = "Not Ready",         Value = "Not Ready",         Selected = (apartment.OccupancyStatus == "Not Ready")         },
                new SelectListItem() { Text = "Needs Maintenance", Value = "Needs Maintenance", Selected = (apartment.OccupancyStatus == "Needs Maintenance") }
            };

            ViewData["OccupancyStatus"] = conditions;

            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApartmentId,UnitNumber,Bedrooms,Bathrooms,MonthlyRate,SecurityDeposit,OccupancyStatus")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            db.Apartments.Remove(apartment);
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
