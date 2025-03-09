using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raktarkezelo.Models;
using Raktarkezelo.data;

namespace Raktarkezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class suppliersController : ControllerBase
    {
        private readonly RaktarDBContext _context;

        public suppliersController(RaktarDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<supplier>>> GetSuppliers(int page=1, int pageSize=10)
        {
            return await _context.Suppliers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<supplier>> Getsupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<supplier>> Postsupplier(supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsupplier", new { id = supplier.Id }, supplier);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Putsupplier(int id, supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!supplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool supplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
