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
using WebServiceVagtPlan;

namespace WebServiceVagtPlan.Controllers
{
    public class VagtPlansController : ApiController
    {
        private ItemContext db = new ItemContext();

        // GET: api/VagtPlans
        public IQueryable<VagtPlan> GetVagtPlans()
        {
            return db.VagtPlans;
        }

        // GET: api/VagtPlans/5
        [ResponseType(typeof(VagtPlan))]
        public IHttpActionResult GetVagtPlan(int id)
        {
            VagtPlan vagtPlan = db.VagtPlans.Find(id);
            if (vagtPlan == null)
            {
                return NotFound();
            }

            return Ok(vagtPlan);
        }

        // PUT: api/VagtPlans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVagtPlan(int id, VagtPlan vagtPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagtPlan.ID)
            {
                return BadRequest();
            }

            db.Entry(vagtPlan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagtPlanExists(id))
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

        // POST: api/VagtPlans
        [ResponseType(typeof(VagtPlan))]
        public IHttpActionResult PostVagtPlan(VagtPlan vagtPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VagtPlans.Add(vagtPlan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vagtPlan.ID }, vagtPlan);
        }

        // DELETE: api/VagtPlans/5
        [ResponseType(typeof(VagtPlan))]
        public IHttpActionResult DeleteVagtPlan(int id)
        {
            VagtPlan vagtPlan = db.VagtPlans.Find(id);
            if (vagtPlan == null)
            {
                return NotFound();
            }

            db.VagtPlans.Remove(vagtPlan);
            db.SaveChanges();

            return Ok(vagtPlan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VagtPlanExists(int id)
        {
            return db.VagtPlans.Count(e => e.ID == id) > 0;
        }
    }
}