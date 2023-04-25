using Core.Models;

namespace Core.Repositories
{
    public interface ICoffeeRepository
    {
        List<Coffee> GetAll();
        Coffee GetById(int id);
    }
}
