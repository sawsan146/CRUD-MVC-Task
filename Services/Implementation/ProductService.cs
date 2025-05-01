using MVC_CRUD.Models;
using MVC_CRUD.Repositories.Contract;
using MVC_CRUD.Services.Contract;
using MVC_CRUD.ViewModels;

namespace MVC_CRUD.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();

            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Qty = product.Qty
                };
                productViewModels.Add(productViewModel);
            }
            return productViewModels;

        }
        public bool AddProduct(ProductViewModel product)
        {

            var productModel = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };

            return _productRepository.AddProduct(productModel);

        }

        public bool UpdateProduct(ProductViewModel product)
        {
            var productModel = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };
            return _productRepository.UpdateProduct(productModel);
        }

        public ProductViewModel GetProductById(int id)
        {

            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };
            return productViewModel;
        }

        public bool DeleteProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return false;
            }
            return _productRepository.DeleteProduct(id);
        }
    }
}
