using AutoMapper;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Dtos;
using PizzaApp.Services.Servicess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.Services.Servicess.Implementations
{
    public class StateService : IStateService
    {
        private readonly IStateRepositroy _stateRepositroy;
        private readonly IOrderRepositroy _orderRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepositroy stateRepositroy, IMapper mapper, IOrderRepositroy orderRepositroy)
        {
            _stateRepositroy = stateRepositroy;
            _orderRepository = orderRepositroy;
            _mapper = mapper;
        }

        public int  GetCurrentStateIdByOrderId(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId).Result;
            return order.StateNavigation.Id;
        }

        public int GetNextStateIdByOrderId(int orderId)
        {
            var result = _stateRepositroy.GetNextPossibleStatesForOrderByOrderId(orderId)
                    .SingleOrDefault(x => x.StateTypeId != DataAccess.Models.StateTypeId.Canceled);

            if (result == null)
                return 0;

            return result.Id;
        }

        public IEnumerable<StateDto> GetNextStatesForOrder(int orderId)
        {
            var states = _stateRepositroy.GetNextPossibleStatesForOrderByOrderId(orderId);
            return _mapper.Map<IEnumerable<StateDto>>(states);
        }
    }
}
