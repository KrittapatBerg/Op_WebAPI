using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Service;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        public Seed _seeder;
        public AdminController(DataContext context, Seed seeder)
        {
            _context = context;
            _seeder = seeder;
        }
        //GET : api/ Attractions
        [HttpGet]
        [ActionName("Seed")]
        [ProducesResponseType(200)]
        public ActionResult Seed()
        {
            //Drop database if it exists
            _context.Database.EnsureDeleted();

            //Create the database 
            _context.Database.EnsureCreated();

            _seeder.SeedData(_context);
            return Ok("Succesfully seeded");
        }

        //Delete : api/ remove seed
        [HttpGet]
        [ActionName("RemoveSeed")]
        [ProducesResponseType(200)]
        public ActionResult Remove()
        {
            try
            {
                //Drop database if it exists
                _context.Database.EnsureDeleted();

                return Ok("Successfully removed data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
