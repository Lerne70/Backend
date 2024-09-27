using Backend.DTOs;
using Backend.Migrations;
using Backend.Models;
using Backend.Respository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonServices<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beearRepository;

        public BeerService(IRepository<Beer> beerRepository) 
        { 
            _beearRepository = beerRepository;

        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beearRepository.Get();

            return beers.Select(b => new BeerDto()
            {
                Id = b.BeerID,
                Name = b.Name,
                BrandID = b.BrandID,
                Alcohol = b.Alcohol,
            });
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beearRepository.GetById(id);

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

            await _beearRepository.Add(beer);
            await _beearRepository.Save();

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };

            return beerDto;
        }
        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beearRepository.GetById(id);

            if (beer != null) {
                beer.Name = beerUpdateDto.Name;
                beer.Alcohol = beerUpdateDto.Alcohol;
                beer.BrandID = beerUpdateDto.BrandID;
                
                _beearRepository.Update(beer);
                await _beearRepository.Save();

                var beerDto = new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                return beerDto;
            }

            return null;
        }
        
        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beearRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                _beearRepository.Delete(beer);
                await _beearRepository.Save();

                return beerDto;
            }

            return null;
        }

    }
}
