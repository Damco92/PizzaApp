using System;
using System.Collections.Generic;

namespace PizzaApp.Services.Dtos
{
    public class OrderDto
    {
        public string DateAndTimeSubmited { get; set; } = DateTime.Now.ToString();
        public bool IsDelivered { get; set; } = false;
        public string PizzaType { get; set; }
        public string PizzaSize { get; set; }
        public string CurrentStateType { get; set; } = "Preparing";
        public IEnumerable<string> NextPossibleStates { get; set; }
    }
}
