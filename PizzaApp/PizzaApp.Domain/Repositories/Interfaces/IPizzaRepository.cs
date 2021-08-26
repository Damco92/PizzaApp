using PizzaApp.DataAccess.Models;
using System.Collections.Generic;

namespace PizzaApp.Domain.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(int id);
    }
}
