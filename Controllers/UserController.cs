using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        //GET : api/ Users
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csUser>>> GetUsers()
        {
            if (_context.Users == null) return NotFound();
            return await _context.Users.ToListAsync();
        }

        //GET : api/ User/ id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<csUser>> GetUser(int id)
        {
            if (_context.Users == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return user; 
        }
    }
}
