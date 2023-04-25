using Core.Models;
using Core.Repositories;

namespace Core.SQL
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly ApplicationContext _dbContext;

        public CoffeeRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public List<Coffee> GetAll() => _dbContext.Coffee.ToList();

        public Coffee GetById(int id) => _dbContext.Coffee.FirstOrDefault(c => c.Id == id);
    }
}
