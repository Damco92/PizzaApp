using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.Domain.Repositories.Implementations
{
    public class StateRepositroy : IStateRepositroy
    {
        private PizzaAppDbContext _dbContext;
        public StateRepositroy(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<State> GetAllStates()
        {
            return _dbContext.States;
        }

        public State GetCurrentStateForOrderByOrderId(int orderId)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == orderId);

            if(order == null)
            {
                throw new System.Exception("Order does not exist");
            }

            return order.StateNavigation;
        }

        public IEnumerable<State> GetNextPossibleStatesForOrderByOrderId(int orderId)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                throw new System.Exception("Order does not exist");
            }

            return _dbContext.Transitions.Where(x => x.CurrentStateId == order.StateId)
                                        .Select(x => x.NextStateNavigation);
        }

        public void UpdateStateForOrderByOrderId(int orderId, State newState)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                throw new System.Exception("Order does not exist");
            }

            order.StateNavigation = newState;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
