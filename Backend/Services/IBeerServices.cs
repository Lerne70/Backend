using Backend.DTOs;

namespace Backend.Services
{
    public interface IBeerServices
    {

        Task<IEnumerable<BeerDto>> Get();
    }
}
