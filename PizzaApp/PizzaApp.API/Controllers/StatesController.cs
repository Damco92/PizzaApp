using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Servicess.Interfaces;

namespace PizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IOrderService _orderService;
        public StatesController(IStateService stateService, IOrderService orderService)
        {
            _stateService = stateService;
            _orderService = orderService;
        }
        [HttpGet("nextstate")]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpGet("state/nextState/{orderId}")]
        public IActionResult GetNextStateForOrder(int orderId)
        {
            var result = _stateService.GetNextStateIdByOrderId(orderId);

            if (result == 0)
                return NoContent();

            return Ok(result);
        }
    }
}
