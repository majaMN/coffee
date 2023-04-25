using Core.Models;
using Core.Repositories;

namespace Core.SQL
{
    public class PurchasesRepository : IPurchaseRepository
    {
        private readonly ApplicationContext _dbContext;
        private int _nextId = 1;
        public PurchasesRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public void Add(Purchase purchase)
        {
            purchase.Id = _nextId++;
            _dbContext.Purchases.Add(purchase);
        }

        public List<Purchase> GetAll()
        {
            return _dbContext.Purchases.ToList();
        }

        public Purchase GetById(int id)
        {
            return _dbContext.Purchases.Find(id);
        }
    }
}
