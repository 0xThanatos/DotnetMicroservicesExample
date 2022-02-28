using System.ComponentModel.DataAnnotations;

namespace MagnecompProductService.Models
{
  public class Product
  {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public string Cost { get; set; }
  }
}