using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClimaAPI;
using Newtonsoft.Json;

internal class Program
{
    private static readonly HttpClient client = new HttpClient();
    private static string apiKey = "06ecad15142181d6606ab17ec2d88ca2";

    private static async Task Main(string[] args)
    {
        string city;
        do
        {
            Console.WriteLine("Digite o nome da cidade desejada (ou 'sair' para encerrar):");
            city = Console.ReadLine();

            if (!string.Equals(city, "sair", StringComparison.OrdinalIgnoreCase))
            {
                await GetWeatherData(city);
            }

        } while (!string.Equals(city, "sair", StringComparison.OrdinalIgnoreCase));
    }

    private static async Task GetWeatherData(string city)
    {
        var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
            Console.WriteLine($"Cidade: {weatherData.Name}");
            Console.WriteLine($"Temperatura: {weatherData.Main.Temp}°C");
            Console.WriteLine($"Condição: {weatherData.Weather[0].Description}");
            Console.WriteLine($"Humidade: {weatherData.Main.Humidity}%");
            Console.WriteLine($"Vento: {weatherData.Wind.Speed} m/s");
        }
        else
        {
            Console.WriteLine("Erro ao obter dados: " + responseBody);
        }
    }
}








