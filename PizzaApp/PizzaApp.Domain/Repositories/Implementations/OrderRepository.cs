using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using System;
using System.Linq;

namespace PizzaApp.Domain.Repositories.Implementations
{
    public class OrderRepository : IOrderRepositroy
    {
        private readonly PizzaAppDbContext _dbContext;
        public OrderRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Order GetOrderById(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == id);

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
    }
}
