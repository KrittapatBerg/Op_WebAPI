using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DataContext _context;
        public AddressController(DataContext context)
        {
            _context = context;
        }

        //GET : api/ Addresses
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csAddress>>> GetAddresses()
        {
            if (_context.Addresses == null)  return NotFound();
            return await _context.Addresses.ToListAsync(); 
        }

        //GET : api/ Address/id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<csAddress>> GetAddress(int id)
        {
            if (_context.Addresses == null) return NotFound();

            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return NotFound();
            return Ok(address);
        }
    }
}
