using MagnecompProductService.Dtos;

namespace MagnecompProductService.SyncDataServices.Http
{
  public interface ICommandDataClient
  {
    Task SendProductToCommand(ProductReadDto product);
  }
}