using Core.Models;

namespace Core
{
    public interface ICoffeeApplication
    {
        List<Coffee> GetAllCoffees();
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        bool UpdatePoints(int customerId, int points);
        decimal GetCashValuePerPoint(int customerId);
        bool AddPurchase(int customerId, int coffeeId, int quantity);
    }
}
