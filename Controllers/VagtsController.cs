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
    public class VagtsController : ApiController
    {
        private ItemContext db = new ItemContext();

        // GET: api/Vagts
        public IQueryable<Vagt> GetVagts()
        {
            return db.Vagts;
        }

        // GET: api/Vagts/5
        [ResponseType(typeof(Vagt))]
        public IHttpActionResult GetVagt(int id)
        {
            Vagt vagt = db.Vagts.Find(id);
            if (vagt == null)
            {
                return NotFound();
            }

            return Ok(vagt);
        }

        // PUT: api/Vagts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVagt(int id, Vagt vagt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagt.VagtID)
            {
                return BadRequest();
            }

            db.Entry(vagt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagtExists(id))
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

        // POST: api/Vagts
        [ResponseType(typeof(Vagt))]
        public IHttpActionResult PostVagt(Vagt vagt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vagts.Add(vagt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VagtExists(vagt.VagtID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vagt.VagtID }, vagt);
        }

        // DELETE: api/Vagts/5
        [ResponseType(typeof(Vagt))]
        public IHttpActionResult DeleteVagt(int id)
        {
            Vagt vagt = db.Vagts.Find(id);
            if (vagt == null)
            {
                return NotFound();
            }

            db.Vagts.Remove(vagt);
            db.SaveChanges();

            return Ok(vagt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VagtExists(int id)
        {
            return db.Vagts.Count(e => e.VagtID == id) > 0;
        }
    }
}