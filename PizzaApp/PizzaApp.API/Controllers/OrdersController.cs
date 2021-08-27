using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Servicess.Interfaces;

namespace PizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersService;
        private readonly IStateService _stateService;
        public OrdersController(IOrderService ordersService, IStateService stateService)
        {
            _ordersService = ordersService;
            _stateService = stateService;
        }

        [HttpGet("order/{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _ordersService.GetOrderById(id);
            var nextStates = _stateService.GetNextStatesForOrder(id);
            var nameOfStates = new System.Collections.Generic.List<string>();
            foreach (var state in nextStates)
            {
                nameOfStates.Add(state.StateName);
            }
            order.NextPossibleStates = nameOfStates;
            return Ok(order);
        }
    }
}
