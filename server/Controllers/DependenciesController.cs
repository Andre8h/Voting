using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenciesController : ControllerBase
    {
        private readonly VotingDbcontext _context;

        public DependenciesController(VotingDbcontext context)
        {
            _context = context;
        }

        // GET: api/Dependencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependencies>>> GetDependencies()
        {
            return await _context.Dependencies.ToListAsync();
        }

        // GET: api/Dependencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dependencies>> GetDependencies(int id)
        {
            var dependencies = await _context.Dependencies.FindAsync(id);

            if (dependencies == null)
            {
                return NotFound();
            }

            return dependencies;
        }

        // PUT: api/Dependencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependencies(int id, Dependencies dependencies)
        {
            if (id != dependencies.Dependency_iD)
            {
                return BadRequest();
            }

            _context.Entry(dependencies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependenciesExists(id))
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

        // POST: api/Dependencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dependencies>> PostDependencies(Dependencies dependencies)
        {
            _context.Dependencies.Add(dependencies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDependencies", new { id = dependencies.Dependency_iD }, dependencies);
        }

        // DELETE: api/Dependencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependencies(int id)
        {
            var dependencies = await _context.Dependencies.FindAsync(id);
            if (dependencies == null)
            {
                return NotFound();
            }

            _context.Dependencies.Remove(dependencies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DependenciesExists(int id)
        {
            return _context.Dependencies.Any(e => e.Dependency_iD == id);
        }
    }
}
