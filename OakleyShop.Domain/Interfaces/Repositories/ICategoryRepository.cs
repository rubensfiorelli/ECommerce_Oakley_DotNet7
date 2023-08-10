using OakleyShop.Domain.Entities;

namespace OakleyShop.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IUnitOfWork
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Guid id);
        Task<Category> GetAsync(Guid id);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetByTitle(string title);
    }
}
