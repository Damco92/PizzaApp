using Microsoft.AspNetCore.Mvc;

namespace PizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private readonly IOrderService _ordersService;
        //private readonly IOrderTransitionsService _orderTransitionsService;
        //public OrdersController(IOrderService ordersService, IOrderTransitionsService orderTransitionsService)
        //{
        //    _ordersService = ordersService;
        //    _orderTransitionsService = orderTransitionsService;
        //}

        //Actions
        //GET /orders/id
        [HttpGet]
        public IActionResult GetOrderById(int id)
        {
            //var order = _ordersService.GetOrderById(id);
            //var orderTransactions = _orderTransitionsService.GetPossibleNextStates((int)order.CurrentOrderState);
            //order.NextPossibleStates = orderTransactions;
            return Ok();
        }
    }
}
