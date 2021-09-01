using PizzaApp.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaApp.Domain.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<Pizza> GetPizzaById(int id);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(int id);
    }
}
