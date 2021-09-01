using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Domain.Repositories.Implementations
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaAppDbContext _dbContext;
        public PizzaRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await _dbContext.Pizzas.Include(x => x.PizzaSize).Include(x => x.PizzaType).ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _dbContext.Pizzas.SingleOrDefaultAsync(x => x.Id == id);
        }
        public void UpdatePizza(Pizza pizza)
        {
            _dbContext.Pizzas.Update(pizza);
            _dbContext.SaveChanges();
        }

        public void DeletePizza(int id)
        {
            var pizza = _dbContext.Pizzas.SingleOrDefault(x => x.Id == id);

            if (pizza == null)
            {
                throw new ApplicationException("The order can not be found");
            }

            _dbContext.Pizzas.Remove(pizza);
            _dbContext.SaveChanges();
        }
    }
}
