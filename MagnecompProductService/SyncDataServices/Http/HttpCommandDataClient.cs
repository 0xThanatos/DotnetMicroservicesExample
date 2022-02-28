using System.Text;
using System.Text.Json;
using MagnecompProductService.Dtos;

namespace MagnecompProductService.SyncDataServices.Http
{
  public class HttpCommandDataClient : ICommandDataClient
  {
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
      _httpClient = httpClient;
      _configuration = configuration;
    }

    public async Task SendProductToCommand(ProductReadDto product)
    {
      var httpContent = new StringContent(
        JsonSerializer.Serialize(product),
        Encoding.UTF8,
        "application/json");

      var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("--> Sync POST to CommandService was OK!");
      }
      else
      {
        Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
      }
    }
  }
}