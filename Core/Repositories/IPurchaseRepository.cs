using Core.Models;

namespace Core.Repositories
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetAll();
        Purchase GetById(int id);
        void Add(Purchase purchase);
    }
}
