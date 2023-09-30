using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;
using System.Linq;

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

        //GET : api/ Attractions
        [HttpGet]
            [ProducesResponseType(200)]
           public  async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractions()
            {
                if (_context.SightSeeings == null) return NotFound();

                var attractions = await _context.SightSeeings.Include(x => x.Address).ToListAsync();

                return attractions;
            }


            //GET : api/ Attraction/ id 
            [HttpGet("{id}")]
            public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttraction(int id)
            {
                if (_context.SightSeeings == null) return NotFound();

                var attraction = await _context.SightSeeings.Include(x => x.Review).Include(x => x.Address).Where(x => x.AttractionId == id).ToListAsync();

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
            [HttpGet("city/{city}")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCity(string city)
            {
                if (_context.SightSeeings == null) return NotFound();

                var citii = await _context.SightSeeings.Include(c => c.Address).Where(c => c.Address.City == city).ToListAsync();
                if (citii == null) return NotFound();

                return Ok(citii);
            }

        }
    
}
