using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab.Api.Data;
using Lab.Api.Models;

namespace Lab.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly LabApiContext _context;

        public ItemsController(LabApiContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabItem>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabItem>> GetLabItem(Guid id)
        {
            var labItem = await _context.Items.FindAsync(id);

            if (labItem == null)
            {
                return NotFound();
            }

            return labItem;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabItem(Guid id, LabItem labItem)
        {
            if (id != labItem.Code)
            {
                return BadRequest();
            }

            _context.Entry(labItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LabItem>> PostLabItem(LabItem labItem)
        {
            _context.Items.Add(labItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabItem", new { id = labItem.Code }, labItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LabItem>> DeleteLabItem(Guid id)
        {
            var labItem = await _context.Items.FindAsync(id);
            if (labItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(labItem);
            await _context.SaveChangesAsync();

            return labItem;
        }

        private bool LabItemExists(Guid id)
        {
            return _context.Items.Any(e => e.Code == id);
        }
    }
}
