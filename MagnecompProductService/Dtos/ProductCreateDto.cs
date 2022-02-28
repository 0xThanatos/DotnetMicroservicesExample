using System.ComponentModel.DataAnnotations;

namespace MagnecompProductService.Dtos
{
  public class ProductCreateDto
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public string Cost { get; set; }
  }
}