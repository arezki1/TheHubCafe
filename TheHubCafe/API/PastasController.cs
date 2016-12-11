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
    public class PastasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Pastas
        public IQueryable<Pasta> GetPastas()
        {
            return db.Pastas;
        }

        // GET: api/Pastas/5
        [ResponseType(typeof(Pasta))]
        public IHttpActionResult GetPasta(int id)
        {
            Pasta pasta = db.Pastas.Find(id);
            if (pasta == null)
            {
                return NotFound();
            }

            return Ok(pasta);
        }

        // PUT: api/Pastas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasta(int id, Pasta pasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasta.ID)
            {
                return BadRequest();
            }

            db.Entry(pasta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastaExists(id))
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

        // POST: api/Pastas
        [ResponseType(typeof(Pasta))]
        public IHttpActionResult PostPasta(Pasta pasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pastas.Add(pasta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pasta.ID }, pasta);
        }

        // DELETE: api/Pastas/5
        [ResponseType(typeof(Pasta))]
        public IHttpActionResult DeletePasta(int id)
        {
            Pasta pasta = db.Pastas.Find(id);
            if (pasta == null)
            {
                return NotFound();
            }

            db.Pastas.Remove(pasta);
            db.SaveChanges();

            return Ok(pasta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PastaExists(int id)
        {
            return db.Pastas.Count(e => e.ID == id) > 0;
        }
    }
}