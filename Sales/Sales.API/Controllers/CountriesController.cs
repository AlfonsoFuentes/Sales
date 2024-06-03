using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/Countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _context.Countries.SingleOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Country country)
        {
            await _context.AddAsync(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Country country)
        {

            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Countries.SingleOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
