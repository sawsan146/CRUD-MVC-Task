using MVC_CRUD.Models;
using MVC_CRUD.Repositories.Contract;

namespace MVC_CRUD.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool AddProduct(Product product)
        {

            _context.Products.Add(product);
            var res = _context.SaveChanges();
            return res > 0;

        }

        public List<Product> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Qty = product.Qty;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
