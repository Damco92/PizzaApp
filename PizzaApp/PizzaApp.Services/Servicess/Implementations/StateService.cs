using AutoMapper;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Dtos;
using PizzaApp.Services.Servicess.Interfaces;
using System.Collections.Generic;

namespace PizzaApp.Services.Servicess.Implementations
{
    public class StateService : IStateService
    {
        private readonly IStateRepositroy _stateRepositroy;
        private readonly IMapper _mapper;

        public StateService(IStateRepositroy stateRepositroy, IMapper mapper)
        {
            _stateRepositroy = stateRepositroy;
            _mapper = mapper;
        }
        public IEnumerable<StateDto> GetNextStatesForOrder(int orderId)
        {
            var states = _stateRepositroy.GetNextPossibleStatesForOrderByOrderId(orderId);
            return _mapper.Map<IEnumerable<StateDto>>(states);
        }
    }
}
