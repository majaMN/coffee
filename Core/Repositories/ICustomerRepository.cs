using Core.Models;

namespace Core.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Update(Customer customer);
    }
}
