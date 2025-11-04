using ProjetoFV.Models;

namespace ProjetoFV.Repositories
{
    public class ProductRepository
    {
        public List<ProductModel> GetLatestPrice()
        {
            //simulação de preço (mas vai vir do db)
            return new List<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Produto A", Price = 10.50m },
                new ProductModel { Id = 2, Name = "Produto B", Price = 25.00m },
                new ProductModel { Id = 3, Name = "Produto C", Price = 99.90m }
            };
        }
    }
}
