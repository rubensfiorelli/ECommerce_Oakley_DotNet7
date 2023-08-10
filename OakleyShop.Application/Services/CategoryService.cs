using AutoMapper;
using OakleyShop.Domain.InputModels;
using OakleyShop.Domain.Interfaces.Repositories;
using OakleyShop.Domain.Interfaces.Services;
using OakleyShop.Domain.OutputModels;

namespace OakleyShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryOutputModel> CreateAsync(CategoryInputModel model)
        {


            var category = model.ToEntity();

            await _repository.CreateAsync(category);

            await _repository.Commit();

            return _mapper.Map<CategoryOutputModel>(category);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _repository.DeleteAsync(id);

            return await _repository.Commit();
        }

        public async Task<List<CategoryOutputModel>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return _mapper.Map<List<CategoryOutputModel>>(categories); ;

        }

        public Task<CategoryOutputModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryOutputModel>> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryOutputModel> UpdateAsync(CategoryInputModel model)
        {
            var category = model.ToEntity();

            await _repository.UpdateAsync(category);

            await _repository.Commit();

            return _mapper.Map<CategoryOutputModel>(category);
        }
    }
}
