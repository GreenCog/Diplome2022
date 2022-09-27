using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Description;
using Antitriche_diplome.models.ApiModels;
using NuGet.Versioning;

namespace Antitriche_diplome.back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultatsController : ControllerBase
    {
        private readonly Antitriche_diplomebackContext _context;

        public ResultatsController(Antitriche_diplomebackContext context)
        {
            _context = context;
        }

        //// GET: api/Resultat/22-09-03
        //[HttpGet("date/{date}")]
        //public async Task<ActionResult<IEnumerable<ResultatDTO>>> GetResultatParDate(DateTime date)
        //{
        //    if (_context.Resultat == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Resultat.Select(r => new ResultatDTO(r)).Where(r => r.Date.Date.ToString() == date.Date.ToString()).ToListAsync();
        //}
        //// GET: api/Resultat/22-09-03
        //[HttpGet("test/{test}")]
        //public async Task<ActionResult<IEnumerable<ResultatDTO>>> GetResultatParTest(string test)
        //{
        //    if (_context.Resultat == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Resultat.Select(r => new ResultatDTO(r)).Contains( test).ToListAsync();
        //}
        // GET: api/Resultats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultatDTO>>> GetResultat()
        {
            if (_context.Resultats == null)
            {
                return NotFound();
            }

            return await _context.Resultats.Select(r => new ResultatDTO(r)).ToListAsync();
        }

        // GET: api/Resultats/5
        [ResponseType(typeof(Resultat))]
        [HttpGet("{id}")]
        public async Task<ActionResult<Resultat>> GetResultat(int id)
        {
            if (_context.Resultats == null)
            {
                return NotFound();
            }

            var resultat = _context.Resultats
                .Include(r => r.ResultatAFKs)
                .Include(r => r.ResultatWindows)
                .Include(r => r.ResultatWebs)
                .FirstOrDefault(r => r.Id == id);


            if (resultat == null)
            {
                return NotFound();
            }

            return resultat;
        }


        // POST: api/Resultats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resultat>> PostResultat(Resultat resultat)
        {
            _context.Resultats.Add(resultat);

            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetResultat", new { id = resultat.Id }, resultat);
            return CreatedAtAction(nameof(GetResultat), new { id = resultat.Id }, resultat);
        }

        

        private bool ResultatExists(int id)
        {
            return (_context.Resultats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}