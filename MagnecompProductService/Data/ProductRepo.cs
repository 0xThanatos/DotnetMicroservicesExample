using MagnecompProductService.Models;

namespace MagnecompProductService.Data
{
  public class ProductRepo : IProductRepo
  {
    private readonly AppDbContext _context;

    public ProductRepo(AppDbContext context)
    {
      _context = context;
    }

    public void CreateProduct(Product product)
    {
      if(product == null)
      {
        throw new System.ArgumentNullException(nameof(product));
      }

      _context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllProducts()
    {
      return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
      return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateProduct(Product product)
    {
      throw new NotImplementedException();
    }
  }
}