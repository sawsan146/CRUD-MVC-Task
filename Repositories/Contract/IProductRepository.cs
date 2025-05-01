using MVC_CRUD.Models;

namespace MVC_CRUD.Repositories.Contract
{
    public interface IProductRepository
    {

        public List<Product> GetAll();
        public bool AddProduct(Product product);
        public bool UpdateProduct(Product product);

        public Product GetProductById(int id);

        public bool DeleteProduct(int id);
    }
}
