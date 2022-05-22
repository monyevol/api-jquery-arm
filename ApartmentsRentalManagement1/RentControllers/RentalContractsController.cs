using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.RentControllers
{
    public class RentalContractsController : ApiController
    {
        private RentManagementModel db = new RentManagementModel();

        // GET: api/RentalContracts
        public IQueryable<RentalContract> GetRentalContracts()
        {
            return db.RentalContracts;
        }

        // GET: api/RentalContracts/5
        [ResponseType(typeof(RentalContract))]
        public IHttpActionResult GetRentalContract(int id)
        {
            RentalContract rentalContract = db.RentalContracts.Find(id);
            if (rentalContract == null)
            {
                return NotFound();
            }

            return Ok(rentalContract);
        }

        // PUT: api/RentalContracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRentalContract(int id, RentalContract rentalContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentalContract.RentalContractId)
            {
                return BadRequest();
            }

            db.Entry(rentalContract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalContractExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RentalContracts
        [ResponseType(typeof(RentalContract))]
        public IHttpActionResult PostRentalContract(RentalContract rentalContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentalContracts.Add(rentalContract);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentalContract.RentalContractId }, rentalContract);
        }

        // DELETE: api/RentalContracts/5
        [ResponseType(typeof(RentalContract))]
        public IHttpActionResult DeleteRentalContract(int id)
        {
            RentalContract rentalContract = db.RentalContracts.Find(id);
            if (rentalContract == null)
            {
                return NotFound();
            }

            db.RentalContracts.Remove(rentalContract);
            db.SaveChanges();

            return Ok(rentalContract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalContractExists(int id)
        {
            return db.RentalContracts.Count(e => e.RentalContractId == id) > 0;
        }
    }
}