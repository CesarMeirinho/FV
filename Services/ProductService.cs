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
            var price = _repo.GetAll();
            return price;
        }
        public void Create(string name, decimal price)
        {
            var product = new ProductModel(0, name, price);
            _repo.Create(product);
        }
        public void Update(int id, string name, decimal price)
        {
            var product = new ProductModel(id, name, price);
            _repo.Update(product);
        }
        public void Delete(int id)
        {
            _repo.DeleteByID(id);
        }
        public ProductModel GetById(int id)
        {
            return _repo.GetByID(id);
        }
    }
}
