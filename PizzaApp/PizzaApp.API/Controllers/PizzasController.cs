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
            var result = _pizzaService.GetAllActivePizzas();
            return Ok(result);
        }

        [HttpGet("pizzaTypes")]
        public IActionResult GetPizzaTypes()
        {
            var pizzaTypes = _pizzaService.GetAllPizzaTypes();
            return Ok(pizzaTypes);
        }

        [HttpGet("pizzaSizes")]
        public IActionResult GetPizzaSizes()
        {
            var pizzaSizes = _pizzaService.GetAllPizzaSizes();
            return Ok(pizzaSizes);
        }

        [HttpGet("pizza/{pizzaId}")]
        public IActionResult GetPizzaById(int pizzaId)
        {
            var pizza = _pizzaService.GetPizzaById(pizzaId);
            return Ok(pizza);
        }
    }
}
