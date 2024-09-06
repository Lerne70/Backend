using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;

        public BeerController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerDto>> Get() => 
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerID,
                Name = b.Name,
                BrandID = b.BrandID,
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                BrandID = beer.BrandID,
                Alcohol = beer.Alcohol,
            };

            return Ok(beerDto);
        }
    }
}
