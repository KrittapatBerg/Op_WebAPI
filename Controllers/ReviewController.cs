using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataContext _context;
        public ReviewController(DataContext context)
        {
            _context = context;
        }

        //GET : api/ Reviews 
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csReview>>> GetReviews()
        {
            if (_context.Reviews == null) return NotFound();
            
            return await _context.Reviews.ToListAsync();
        }

        //GET : api/ Review/ id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]

        public async Task<ActionResult<csReview>> GetReview(int id)
        {
            if (_context.Reviews == null) return NotFound();

            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();

            return review; 
        }
    }
}
