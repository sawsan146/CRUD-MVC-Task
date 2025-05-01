using MVC_CRUD.Models;
using MVC_CRUD.ViewModels;

namespace MVC_CRUD.Services.Contract
{
    public interface IProductService
    {

        public List<ProductViewModel> GetAllProducts();
        //Product GetProductById(int id);
        public bool AddProduct(ProductViewModel product);
       
        public bool UpdateProduct(ProductViewModel product);
        public ProductViewModel GetProductById(int id);
        public bool DeleteProductById(int id);





    }
}
