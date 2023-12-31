﻿using Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Data;
using Op_WebAPI.Models;
using Op_WebAPI.Service;
using System.Linq;

namespace Op_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly DataContext _context;
        private Seed _seeder;

        public AttractionController(DataContext context, Seed seeder)
        {
            _context = context;
            _seeder = seeder;   
        }

        //GET : api/ Attractions
        [HttpGet]
        [ActionName("Attractions")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractions()
        {
            if (_context.SightSeeings == null) return NotFound();

            var attractions = await _context.SightSeeings.Include(x => x.Address).ToListAsync();

            return attractions;
        }

        //GET : api/ Attraction/ Category
        [HttpGet]
        [ActionName("Category filter")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCategory(string category)
        {
            if (_context.SightSeeings == null) return NotFound();

            var categorii = await _context.SightSeeings.Where(c => c.Category == category).ToListAsync();
            if (categorii == null) return NotFound();

            return categorii;
        }

        //GET : api/ Attraction/ Name
        [HttpGet]
        [ActionName("Attraction filtered by name")]
        public async Task<ActionResult<csAttraction>> GetAttractionByName(string name)
        {
            if (_context.SightSeeings == null) return NotFound();

            var sightseeing = await _context.SightSeeings.Include(a => a.Address).Where(a => a.AttractionName == name).ToListAsync();
            if (sightseeing.Count < 1) return NotFound();

            return Ok(sightseeing);
        }

        //GET : api/ Attraction/ Description 
        [HttpGet]
        [ActionName("Attraction filtered by description")]
        public async Task<ActionResult<csAttraction>> GetByDescription(string description)
        {
            if (_context.SightSeeings == null) return NotFound();
            
            var des = await _context.SightSeeings.Where(d => d.Description == description).ToListAsync();
            if (des.Count < 1) return NotFound();

            return Ok(des); 
        }

        //GET : api/ Attraction/ City
        [HttpGet]
        [ActionName("City filter")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCity(string city)
        {
            if (_context.SightSeeings == null) return NotFound();

            var citii = await _context.SightSeeings.Include(c => c.Address).Where(c => c.Address.City == city).ToListAsync();
            if (citii.Count < 1) return NotFound(); 

            return Ok(citii);
        }

        //GET : api/ Attraction/ Country
        [HttpGet]
        [ActionName("Country filter")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttractionByCountry(string country)
        {
            if (_context.SightSeeings == null) return NotFound();

            var land = await _context.SightSeeings.Include(x => x.Address).Where(x => x.Address.Country == country).ToListAsync();
            if (land.Count < 1) return NotFound();

            return Ok(land);
        }

        //GET : api/ Attraction/ with Info  
        [HttpGet]
        [ActionName("Attraction's review filtered by Id")]
        public async Task<ActionResult<csAttraction>> GetAttractionWithReview(int id)
        {
            if (_context.SightSeeings == null) return NotFound(); 

            var attraction = await _context.SightSeeings.Include(x => x.Review).Where(x => x.AttractionId == id).ToListAsync();
  
            return Ok(attraction); 
        }

        //GET : api/ Attraction/ no Review
        [HttpGet]
        [ActionName("Attraction without review")]
        public async Task<ActionResult<IEnumerable<csAttraction>>> GetAttraction()
        {
            if (_context.SightSeeings == null) return NotFound();

            var noReview = await _context.SightSeeings.Include(x => x.Review).Where(x => x.Review.Count == 0).ToListAsync(); 
            return noReview;
        }
    }
}
