using AutoMapper;
using MagnecompProductService.Data;
using MagnecompProductService.Dtos;
using MagnecompProductService.Models;
using MagnecompProductService.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnecompProductService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepo _repository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public ProductsController(
      IProductRepo repository,
      IMapper mapper,
      ICommandDataClient commandDataClient
    )
    {
      _repository = repository;
      _mapper = mapper;
      _commandDataClient = commandDataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
    {
      Console.WriteLine("--> Getting Products...");

      var productItems = _repository.GetAllProducts();

      return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<ProductReadDto> GetProductById(int id)
    {
      var productItem = _repository.GetProductById(id);

      if (productItem != null)
      {
        return Ok(_mapper.Map<ProductReadDto>(productItem));
      }
      else
      {
        return NotFound();
      }
    }

    public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
    {
      var productModel = _mapper.Map<Product>(productCreateDto);
      _repository.CreateProduct(productModel);
      _repository.SaveChanges();

      var productReadDto = _mapper.Map<ProductReadDto>(productModel);

      try
      {
        await _commandDataClient.SendProductToCommand(productReadDto);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
      }

      return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
    }
  }
}