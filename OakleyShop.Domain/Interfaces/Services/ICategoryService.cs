using OakleyShop.Domain.InputModels;
using OakleyShop.Domain.OutputModels;

namespace OakleyShop.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryOutputModel> CreateAsync(CategoryInputModel model);
        Task<CategoryOutputModel> UpdateAsync(CategoryInputModel model);
        Task<bool> DeleteAsync(Guid id);
        Task<CategoryOutputModel> GetAsync(Guid id);
        Task<List<CategoryOutputModel>> GetAllAsync();
        Task<List<CategoryOutputModel>> GetByTitle(string title);
    }
}
