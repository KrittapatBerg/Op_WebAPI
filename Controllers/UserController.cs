using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [ActionName("Users with reviews")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csUser>>> GetUsers()
        {
            if (_context.Users == null) return NotFound();

            var users = await _context.Users.Include(u => u.Reviews).ToListAsync();

            if(users == null) return NotFound();

            return users;
        }
    }
}
