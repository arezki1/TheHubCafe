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
using TheHubCafe.Models;

namespace TheHubCafe.API
{
    public class SaladsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Salads
        public IQueryable<Salad> GetSalads()
        {
            return db.Salads;
        }

        // GET: api/Salads/5
        [ResponseType(typeof(Salad))]
        public IHttpActionResult GetSalad(int id)
        {
            Salad salad = db.Salads.Find(id);
            if (salad == null)
            {
                return NotFound();
            }

            return Ok(salad);
        }

        // PUT: api/Salads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalad(int id, Salad salad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salad.ID)
            {
                return BadRequest();
            }

            db.Entry(salad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaladExists(id))
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

        // POST: api/Salads
        [ResponseType(typeof(Salad))]
        public IHttpActionResult PostSalad(Salad salad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salads.Add(salad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salad.ID }, salad);
        }

        // DELETE: api/Salads/5
        [ResponseType(typeof(Salad))]
        public IHttpActionResult DeleteSalad(int id)
        {
            Salad salad = db.Salads.Find(id);
            if (salad == null)
            {
                return NotFound();
            }

            db.Salads.Remove(salad);
            db.SaveChanges();

            return Ok(salad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaladExists(int id)
        {
            return db.Salads.Count(e => e.ID == id) > 0;
        }
    }
}