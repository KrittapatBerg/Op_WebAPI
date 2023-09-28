using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly DataContext _context;
        public RatingController(DataContext context)
        {
            _context = context;
        }

        //GET : api/ Ratings 
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<ActionResult<IEnumerable<csRating>>> GetRatings()
        {
            if (_context.Ratings == null) return NotFound();

            return await _context.Ratings.ToListAsync();
        }

        //GET : api/ Rating/ id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<csRating>> GetRating(int id)
        {
            if (_context.Ratings == null) return NotFound();

            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null) return NotFound();

            return rating; 
        }
    }
}
