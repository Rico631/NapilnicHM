using Second.Models;

namespace Second.Interfaces
{
    public interface IProductService
    {
        Product GetProductByName(string name);
        Product CreateProduct(Product product);
    }
}