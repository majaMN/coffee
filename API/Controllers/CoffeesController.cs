using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core;

namespace API.Controllers
{
    [Route("api/coffees")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeApplication _application;

        public CoffeesController(ICoffeeApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetCoffee()
        {
            return _application.GetAllCoffees();
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(int id)
        {
            return _application.GetAllCustomers();
        }


        [HttpPut("customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            return _application.GetCustomerById(id);
        }

        [HttpPut("points")]
        public async Task<ActionResult> UpdatePoints(int customerId, int points)
        {
            var saveResult = _application.UpdatePoints(customerId, points);
            return saveResult == true ? Ok(saveResult) : BadRequest(saveResult);

        }

        [HttpPost("purchases")]
        public async Task<ActionResult> AddPurchase(int customerId, int coffeeId, int quantity)
        {
            var saveResult = _application.AddPurchase(customerId, coffeeId, quantity);
            return saveResult == true ? Ok(saveResult) : BadRequest(saveResult);
        }

    }
}
