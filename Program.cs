using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Digite o nome do Pokémon: ");
        string nome = Console.ReadLine();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nome}";

        HttpClient client = new HttpClient();

        try
        {
            var resposta = await client.GetStringAsync(url);

            JsonDocument json = JsonDocument.Parse(resposta);

            int id = json.RootElement.GetProperty("id").GetInt32();
            string name = json.RootElement.GetProperty("name").GetString();
            int altura = json.RootElement.GetProperty("height").GetInt32();
            int peso = json.RootElement.GetProperty("weight").GetInt32();

            Console.WriteLine("\nDados do Pokémon:");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Peso: {peso}");
        }
        catch
        {
            Console.WriteLine("Pokémon não encontrado.");
        }
    }
}