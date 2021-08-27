using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Servicess.Interfaces;

namespace PizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        public PizzasController(IPizzaService pizzaSerivce)
        {
            _pizzaService = pizzaSerivce;
        }
        public IActionResult GetPizzas()
        {
            var result = _pizzaService.GetAllPizzas();
            return Ok(result);
        }

        [HttpGet("pizza/{pizzaId}")]
        public IActionResult GetPizzaById(int pizzaId)
        {
            var pizza = _pizzaService.GetPizzaById(pizzaId);
            return Ok(pizza);
        }
    }
}
