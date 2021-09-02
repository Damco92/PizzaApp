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

        [HttpGet("checkOrder/{id}")]
        public IActionResult CheckOrder(int id)
        {
            var result = _ordersService.CheckIfOrderIsReady(id);
            return Ok(result);
        }

        [HttpGet("getLastOrderId")]
        public IActionResult GetLastOrder()
        {
            var lastOrder = _ordersService.GetLastAddedOrderId();
            if (lastOrder == 0)
                return NotFound();

            return Ok(lastOrder);
        }

        [HttpGet("getStateId/{orderId}")]
        public IActionResult GetCurrentState(int orderId)
        {
            var result = _stateService.GetCurrentStateIdByOrderId(orderId);

            if (result == 0)
                return NoContent();

            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult UpdateLastOrderState()
        {
           _ordersService.UpdateLastOrderState();
            return Ok("Updated");
        }
    }
}
