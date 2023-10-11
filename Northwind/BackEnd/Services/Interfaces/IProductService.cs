using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id); 
        Task<Product> GetById(int id);
        

    }
}
