using OakleyShop.Domain.InputModels;
using OakleyShop.Domain.OutputModels;

namespace OakleyShop.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductOutputModel> CreateAsync(ProductInputModel product);
        Task<ProductOutputModel> UpdateAsync(ProductInputModel product);
        Task<bool> DeleteAsync(int id);
        Task<ProductOutputModel> GetAsync(int id);
        Task<List<ProductOutputModel>> GetAllByCategoryAsync(string code);
    }
}
