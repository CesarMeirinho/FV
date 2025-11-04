using ProjetoFV.Models;
using ProjetoFV.Controllers;
using static ProjetoFV.Services.ProductService;
using ProjetoFV.Repositories;

namespace ProjetoFV.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService()
        {
            _repo = new ProductRepository();
        }

        public List<ProductModel> GetAllProductPrice()
        {
            var price = _repo.GetLatestPrice();
            return price;
        }
    }
}
