using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LAFISE.Models;

namespace LAFISE.Controllers
{
    public class TransaccionesController : ApiController
    {
        private Aplicacion db = new Aplicacion();

        // GET: api/Transacciones
        public IQueryable<Transacciones> GetTransacciones()
        {
            return db.Transacciones;
        }

        // GET: api/Transacciones/5
        [ResponseType(typeof(Transacciones))]
        public async Task<IHttpActionResult> GetTransacciones(decimal id)
        {
            Transacciones transacciones = await db.Transacciones.FindAsync(id);
            if (transacciones == null)
            {
                return NotFound();
            }

            return Ok(transacciones);
        }

        // PUT: api/Transacciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransacciones(decimal id, Transacciones transacciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transacciones.IdTransaccion)
            {
                return BadRequest();
            }

            db.Entry(transacciones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionesExists(id))
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

        // POST: api/Transacciones
        [ResponseType(typeof(Transacciones))]
        public async Task<IHttpActionResult> PostTransacciones(Transacciones transacciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transacciones.Add(transacciones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transacciones.IdTransaccion }, transacciones);
        }

        // DELETE: api/Transacciones/5
        [ResponseType(typeof(Transacciones))]
        public async Task<IHttpActionResult> DeleteTransacciones(decimal id)
        {
            Transacciones transacciones = await db.Transacciones.FindAsync(id);
            if (transacciones == null)
            {
                return NotFound();
            }

            db.Transacciones.Remove(transacciones);
            await db.SaveChangesAsync();

            return Ok(transacciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransaccionesExists(decimal id)
        {
            return db.Transacciones.Count(e => e.IdTransaccion == id) > 0;
        }
    }
}