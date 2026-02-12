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
        public void AddStock(int id, double quantidade)
        {
            var produto = GetById(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.Stock += quantidade;

            _repo.Update(produto);
        }
        public void RemoveStock(int id, double quantidade)
        {
            var produto = GetById(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");
            else if (produto.Stock < quantidade)
                throw new Exception("Quantidade em estoque insuficiente.");
            
            produto.Stock -= quantidade;

            _repo.Update(produto);
        }
    }
}
