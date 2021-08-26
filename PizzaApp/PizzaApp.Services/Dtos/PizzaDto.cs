namespace PizzaApp.Services.Dtos
{
    public class PizzaDto
    {
        public string PizzaSize { get; set; }
        public string PizzaType { get; set; }
        public double TimeOfBaking { get; set; } = 30;
    }
}
