using System.Web.Http;
using Antitriche_diplome.models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Antitriche_diplome.back.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ReglesController : ControllerBase
    {
        private readonly Antitriche_diplomebackContext _context;

        public ReglesController(Antitriche_diplomebackContext context)
        {
            _context = context;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult<Regle>> PostRegle(Regle regle)
        {
            _context.Regles.Add(regle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegle", new { id = regle.Id }, regle);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<Regle>>> GetRegle()
        {
            return await _context.Regles.ToListAsync();
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<Regle>> GetRegle(int id)
        {
            var regle = await _context.Regles.FindAsync(id);

            if (regle == null)
            {
                return NotFound();
            }

            return regle;
        }


        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<ActionResult<Regle>> DeleteRegle(int id)
        {
            var regle = await _context.Regles.FindAsync(id);
            if (regle == null)
            {
                return NotFound();
            }

            _context.Regles.Remove(regle);
            await _context.SaveChangesAsync();

            return regle;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> PutRegle(int id, Regle regle)
        {
            if (id != regle.Id)
            {
                return BadRequest();
            }

            _context.Entry(regle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegleExists(id))
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

        private bool RegleExists(int id)
        {
            if (_context.Regles.Find(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}