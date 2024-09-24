
using Backend.Models;

namespace Backend.Respository
{
    public class BeerRespository : IRepository<Beer>
    {
        public Task Add(Beer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Beer>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Beer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}
