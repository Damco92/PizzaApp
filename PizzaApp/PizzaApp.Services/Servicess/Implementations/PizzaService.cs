using AutoMapper;
using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Dtos;
using PizzaApp.Services.Servicess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.Services.Servicess.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepositroy;
        private readonly IMapper _mapper;
        public PizzaService(IPizzaRepository pizzaRepositroy, IMapper mapper)
        {
            _pizzaRepositroy = pizzaRepositroy;
            _mapper = mapper;
        }
        public IEnumerable<PizzaDto> GetAllPizzas()
        {
            var pizzas = _pizzaRepositroy.GetAllPizzas();
            return _mapper.Map<IEnumerable<PizzaDto>>(pizzas);
        }

        public IEnumerable<PizzaSizeDto> GetAllPizzaSizes()
        {
            var pizzaSizes = _pizzaRepositroy.GetAllPizzas().Select(x => x.PizzaSize);
            return _mapper.Map<IEnumerable<PizzaSizeDto>>(pizzaSizes);
        }

        public IEnumerable<PizzaTypeDto> GetAllPizzaTypes()
        {
            var pizzaTypes = _pizzaRepositroy.GetAllPizzas().Select(x => x.PizzaType);
            return _mapper.Map<IEnumerable<PizzaTypeDto>>(pizzaTypes);
        }

        public PizzaDto GetPizzaById(int id)
        {
            Pizza pizza = _pizzaRepositroy.GetPizzaById(id);
            return _mapper.Map<PizzaDto>(pizza);
        }
    }
}
