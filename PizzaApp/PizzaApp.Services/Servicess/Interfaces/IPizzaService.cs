using PizzaApp.Services.Dtos;
using System.Collections.Generic;

namespace PizzaApp.Services.Servicess.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<PizzaDto> GetAllPizzas();
        PizzaDto GetPizzaById(int id);
    }
}
