
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Respository
{
    public class BeerRespository : IRepository<Beer>
    {
        private StoreContext _cotext;

        public BeerRespository(StoreContext cotext)
        {
            _cotext = cotext;
        }

        public async Task<IEnumerable<Beer>> Get() => await _cotext.Beers.ToListAsync();

        public async Task<Beer> GetById(int id) => await _cotext.Beers.FindAsync(id);


        public async Task Add(Beer beer)
            => await _cotext.Beers.AddAsync(beer);

        public void Update(Beer beer)
        {
            _cotext.Beers.Attach(beer);
            _cotext.Beers.Entry(beer).State = EntityState.Modified;
        }

        public void Delete(Beer beer)
            => _cotext.Beers.Remove(beer);

        public async Task Save()
            => await _cotext.SaveChangesAsync();

        
    }
}
