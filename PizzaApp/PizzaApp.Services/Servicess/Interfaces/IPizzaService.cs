using PizzaApp.DataAccess.Models;
using PizzaApp.Services.Dtos;
using System.Collections.Generic;

namespace PizzaApp.Services.Servicess.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<PizzaDto> GetAllPizzas();
        IEnumerable<PizzaSizeDto> GetAllPizzaSizes();
        IEnumerable<PizzaTypeDto> GetAllPizzaTypes();
        PizzaDto GetPizzaById(int id);
    }
}
