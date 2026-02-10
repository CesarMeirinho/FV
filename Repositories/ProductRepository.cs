using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjetoFV.Models;

namespace ProjetoFV.Repositories
{
    public class ProductRepository
    {
        protected static List<ProductModel> _products = new();
        
        private static int _nextId = 1;
       
        public void Create(ProductModel product)
        {
            product.Id = _nextId;
            _nextId++;

            _products.Add(product);
        }
        public ProductModel GetByID(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Update(ProductModel product)
        {
            var existing = GetByID(product.Id);

            if (existing == null)
                throw new Exception("Produto não encontrado");

            existing.Name = product.Name; 
            existing.Price = product.Price;
        }
        public void DeleteByID(int id)
        {
            var existing = GetByID(id);

            if (existing == null)
                throw new Exception("Produto não encontrado");

            _products.Remove(existing);
        }
        public List<ProductModel> GetAll()
        {
            return _products;
        }

    }
}
