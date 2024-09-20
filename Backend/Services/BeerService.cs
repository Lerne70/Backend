﻿using Backend.DTOs;
using Backend.Migrations;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : IBeerServices
    {

        private StoreContext _context;

        public BeerService(StoreContext context) 
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

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if(beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID,
                };

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandID = beerInsertDto.BrandID,
                Alcohol = beerInsertDto.Alcohol
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };

            return beerDto;
        }
        public Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }
        
       

        

        public Task<BeerDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
