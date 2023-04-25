using Core.Models;
using Core.Repositories;

namespace Core
{
    public class CoffeeApplication : ICoffeeApplication
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeApplication(ICustomerRepository customer, IPurchaseRepository purchase, ICoffeeRepository coffee)
        {
            _coffeeRepository = coffee;
            _customerRepository = customer;
            _purchaseRepository = purchase;
        }



        public bool AddPurchase(int customerId, int coffeeId, int quantity)
        {
            try
            {
                var customer = GetCustomerById(customerId);
                var coffee =  GetAllCoffees().FirstOrDefault(c => c.Id == coffeeId);
                var totalPrice = coffee.Price * quantity;
                var purchase = new Purchase
                {
                    CustomerId = customerId,
                    CoffeeId = coffeeId,
                    Quantity = quantity,
                    TotalPrice = totalPrice
                };
                _purchaseRepository.Add(purchase);
                UpdatePoints(customerId, quantity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Coffee> GetAllCoffees()
        {
            return _coffeeRepository.GetAll();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public decimal GetCashValuePerPoint(int customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer.Points > 0 ? customer.CashValuePerPoint / customer.Points : 0;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public bool UpdatePoints(int customerId, int points)
        {
            try
            {
                var customer = _customerRepository.GetById(customerId);
                customer.Points += points;
                _customerRepository.Update(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
