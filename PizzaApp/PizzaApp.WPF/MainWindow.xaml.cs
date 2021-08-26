using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace PizzaApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += ShowValues;
        }

        private async void ShowValues(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:11231/home");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    string[] words = responseString.Split(',');
                    foreach (var word in words)
                    {
                        PizzaSizes.Items.Add(word);
                    }
                }
            }
        }
    }
}
