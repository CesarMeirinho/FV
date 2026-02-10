using System.Security.AccessControl;

namespace ProjetoFV.Models
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel( int id, string name,decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Invalid price");
            }
            else if (price == 0)
            {
                throw new ArgumentException("Invalid price");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name");
            }
            
            Id = id;
            Name = name;
            Price = price;
            
            
        }
         


        public decimal Price { get; set; } 
        public  string Name { get; set; }
        public  int Id { get; set; }

        

    }
}
