using Core.Models;
using Core.Repositories;

namespace Core.SQL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _dbContext;
        private int _nextId = 1;
        public CustomerRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            var existingData = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            customer.Id = existingData != null? existingData.Id: _nextId++;
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }
    }
}
