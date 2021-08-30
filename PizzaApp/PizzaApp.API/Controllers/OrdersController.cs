using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Dtos;
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
            return Ok(order);
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderDto orderViewModel)
        {
            _ordersService.InsertNewOrder(orderViewModel);
            return Ok("Order added");
        }
    }
}
