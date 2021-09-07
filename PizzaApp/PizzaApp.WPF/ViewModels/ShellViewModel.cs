using Caliburn.Micro;
using Newtonsoft.Json;
using PizzaApp.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.WPF.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ObservableCollection<Pizza> Pizzas { get; set; }
        private Pizza _selectedPizza;
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
            Pizzas =  GetPizzas().Result;
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
        public async Task<string> InsertOrder(Pizza pizza)
        {
            var json = JsonConvert.SerializeObject(pizza);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:11231/api/orders/create";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(url,data);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<int> GetlastOrderId()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/orders/getLastOrderId");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No order exists in the database");
                }

               var result = await response.Content.ReadAsStringAsync();

                return int.Parse(result);
            }
        }
        public async Task<string> CheckCurrentOrderStatus()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"/api/orders/checkOrder");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<int> GetCurrentStateId(int orderId)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"/api/orders/getStateId/{orderId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var result = await response.Content.ReadAsStringAsync();
                return int.Parse(result);
            }
        }

        public async Task<int> GetNextStateId(int orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"/api/states/state/nextState/{orderId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var result = await response.Content.ReadAsStringAsync();
                return int.Parse(result);
            }
        }
        public async Task<string> DeleteLastOrder()
        {
            var url = "http://localhost:11231/api/orders/delete";
            int lastOrderId;
            try
            {
                lastOrderId = await GetlastOrderId();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            Order order = new Order();
            using (HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("http://localhost:11231/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"api/orders/order/{lastOrderId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("The order is not found");
                }

                order = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
            }
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {

                var response = await client.PutAsync(url, data);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("The order is not deleted");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> UpdateLastOrderStatus()
        {
            var url = "http://localhost:11231/api/orders/update";
            int lastOrderId;
            try
            {
                lastOrderId = await GetlastOrderId();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            Order order = new Order();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11231/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"api/orders/order/{lastOrderId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("The order is not found");
                }

                order = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
            }
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("The order was not updated");
                }
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}