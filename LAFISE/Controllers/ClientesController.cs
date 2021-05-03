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
    public class ClientesController : ApiController
    {
        private Aplicacion db = new Aplicacion();

        // GET: api/Clientes
        public IQueryable<Clientes> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> GetClientes(decimal id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientes(decimal id, Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.IdCliente)
            {
                return BadRequest();
            }

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> PostClientes(Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(clientes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientes.IdCliente }, clientes);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> DeleteClientes(decimal id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clientes);
            await db.SaveChangesAsync();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientesExists(decimal id)
        {
            return db.Clientes.Count(e => e.IdCliente == id) > 0;
        }
    }
}