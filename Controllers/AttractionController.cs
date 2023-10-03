using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;
using System.Linq;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly DataContext _context;
       
        public AttractionController(DataContext context)
        {
            _context = context;
            var seed = new Seed();

        }

        //GET : api/ Attractions/ Seed 
        //[HttpGet]
        //[ActionName("Seed")]
        //[ProducesResponseType(200, Type = typeof(int))]
        //[ProducesResponseType(400, Type = typeof(string))]
        //public async Task<IActionResult> Seed(string count)
        //{
        //    try
        //    {
        //        int _count = int.Parse(count);

        //       // int cnt = await _context.;
        //        return Ok(cnt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}
        //GET : api/ Attractions
        [HttpGet]
        [ActionName("Read")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractions()
        {
            
            Seed.SeedData(_context);

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

        //GET : api/ Attraction/ no Review 
        [HttpGet("{no review}")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionNoReview()
        {
            if (_context.SightSeeings == null) return NotFound(); 

            var noReview = await _context.SightSeeings.Include(x => x.Review).Where(x => x.Review == null).ToListAsync();

            return noReview; 
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
