using OakleyShop.Domain.Entities;

namespace OakleyShop.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IUnitOfWork
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllByCategoryAsync(string code);

    }
}
