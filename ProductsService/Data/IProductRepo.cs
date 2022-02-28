using MagnecompProductService.Models;

namespace MagnecompProductService.Data
{
  public interface IProductRepo
  {
    bool SaveChanges();

    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
  }
}