using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly DataContext _context;
        public AttractionController(DataContext context)
        {
            _context = context;
        }

        //GET: api/ Attractions
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractions()
        {
            if (_context.SightSeeings == null)  return NotFound();

            return await _context.SightSeeings.ToListAsync(); 
        }

        //GET : api/ Attraction/ id 
        [HttpGet("{id}")]
        public async Task<ActionResult<csAttraction>> GetAttraction(int id)
        {
            if (_context.SightSeeings == null) return NotFound();

            var attraction = await _context.SightSeeings.FindAsync(id);
            if (attraction == null) return NotFound(); 
            
            return attraction;
        }

        //GET : api/ Attraction/ category
        [HttpGet("category/{category}")] 
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCategory(string category)
        {
            if (_context.SightSeeings == null) return NotFound();

            var categorii = await _context.SightSeeings.Where(c => c.Category == category).ToListAsync();
            if (categorii == null) return NotFound(); 
            
            return categorii;
        }

        //GET : api/ Attraction/ country
        [HttpGet("country/{country}")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCountry(string country)
        {
            if (_context.SightSeeings == null) return NotFound();

            var land = await _context.SightSeeings.Include(x => x.Address).Where(x => x.Address.Country == country).ToListAsync();
            if (land == null) return NotFound();

            return Ok(land);
        }

        //GET : api/ Attraction/ city
        [HttpGet("{}")]



        //PUT : api/ Attraction/ id 
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutAttraction(int id, csAttraction attraction)
        {
            if(id != attraction.AttractionId) return BadRequest();
            
            _context.Entry(attraction).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) 
            {
                if (!AttractionExists(id)) return NotFound();
            }
            return ;
        }*/
    }
}
