using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiyasMatrimony.API.Data;

namespace SiyasMatrimony.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        private readonly DataContext _context;

        public ReligionController(DataContext context)
        {
            _context = context;
        } 

        [HttpGet("GetAllReligions")]
        public async Task<IActionResult> GetAllRelegions()
        {
            var religions = await _context.Religions.Include(p=>p.Castes).ToListAsync();
            return Ok(religions);
        }

        [HttpGet("GetAllStars")]
        public async Task<IActionResult> GetAllStars()
        {
            var stars = await _context.Stars.Include(p=>p.Rashi).ToListAsync();
            return Ok(stars);
        }
        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _context.Countries.Include(p=>p.States).ToListAsync();
            return Ok(countries);
        }
        [Route("GetAllCities/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllCities(int id)
        {
            var countries = await _context.Cities.Where(p=>p.state_id == id).ToListAsync();
            return Ok(countries);
        }
    }
}