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
    public class NyVagtsController : ApiController
    {
        private Context db = new Context();

        // GET: api/NyVagts
        public IQueryable<NyVagt> GetNyVagts()
        {
            return db.NyVagts;
        }

        // GET: api/NyVagts/5
        [ResponseType(typeof(NyVagt))]
        public IHttpActionResult GetNyVagt(int id)
        {
            NyVagt nyVagt = db.NyVagts.Find(id);
            if (nyVagt == null)
            {
                return NotFound();
            }

            return Ok(nyVagt);
        }

        // PUT: api/NyVagts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNyVagt(int id, NyVagt nyVagt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nyVagt.NyVagtID)
            {
                return BadRequest();
            }

            db.Entry(nyVagt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NyVagtExists(id))
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

        // POST: api/NyVagts
        [ResponseType(typeof(NyVagt))]
        public IHttpActionResult PostNyVagt(NyVagt nyVagt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NyVagts.Add(nyVagt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nyVagt.NyVagtID }, nyVagt);
        }

        // DELETE: api/NyVagts/5
        [ResponseType(typeof(NyVagt))]
        public IHttpActionResult DeleteNyVagt(int id)
        {
            NyVagt nyVagt = db.NyVagts.Find(id);
            if (nyVagt == null)
            {
                return NotFound();
            }

            db.NyVagts.Remove(nyVagt);
            db.SaveChanges();

            return Ok(nyVagt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NyVagtExists(int id)
        {
            return db.NyVagts.Count(e => e.NyVagtID == id) > 0;
        }
    }
}