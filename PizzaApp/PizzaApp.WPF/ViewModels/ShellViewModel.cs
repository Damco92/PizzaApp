using Caliburn.Micro;
using Newtonsoft.Json;
using PizzaApp.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PizzaApp.WPF.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ObservableCollection<Pizza> Pizzas { get; set; }
        private Pizza _selectedPizza;
        public string DisplayImage { get { return @"C:\Users\d.stojanov\Desktop\Pizzas-Images\capri.png"; } }

        public Pizza SelectedPizza
        {
            get { return _selectedPizza; }
            set 
            {
                _selectedPizza = value; 
                NotifyOfPropertyChange(() => SelectedPizza);
            }
        }


        public ShellViewModel()
        {
            Pizzas = GetPizzas().Result;
            
        }

        private async Task<ObservableCollection<Pizza>> GetPizzas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/pizzas");

                if (!response.Result.IsSuccessStatusCode)
                {
                    throw new ApplicationException("Did not fetch data");
                }

                return JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(await response.Result.Content.ReadAsStringAsync());
            }
        }
    }
}
