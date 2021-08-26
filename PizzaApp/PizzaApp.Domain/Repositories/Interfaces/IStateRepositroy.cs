using PizzaApp.DataAccess.Models;
using System.Collections.Generic;

namespace PizzaApp.Domain.Repositories.Interfaces
{
    public interface IStateRepositroy
    {
        IEnumerable<State> GetAllStates();
        State GetCurrentStateForOrderByOrderId(int orderId);
        IEnumerable<State> GetNextPossibleStatesForOrderByOrderId(int orderId);
        void UpdateStateForOrderByOrderId(int orderId, State newState);
    }
}
