using Caliburn.Micro;
using PizzaApp.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PizzaApp.WPF.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ObservableCollection<Pizza> Pizzas { get; set; }

        public ShellViewModel()
        {
            Pizzas = GetPizzas();
        }

        private ObservableCollection<Pizza> GetPizzas()
        {
            ObservableCollection<Pizza> result = new ObservableCollection<Pizza>();
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231");

                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/pizzas").Result;

                if (response.IsSuccessStatusCode)
                {
                    result.Add(new Pizza { });
                }
            }

            return result;
        }
    }
}
