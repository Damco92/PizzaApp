using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Domain.Repositories.Implementations
{
    public class OrderRepository : IOrderRepositroy
    {
        private  PizzaAppDbContext _dbContext;
        public OrderRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _dbContext.Orders.Include(x => x.Pizza)
                    .Include(x => x.StateNavigation)
                    .SingleOrDefaultAsync(x => x.Id == id);

            if(order == null)
            {
                throw new ApplicationException("The order does not exist");
            }

            return order;
        }

        public void InsertOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrderById(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == id);

            if(order == null)
            {
                throw new ApplicationException("The order can not be found");
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.Include(x => x.StateNavigation).ToListAsync();
        }
    }
}
