using Microsoft.EntityFrameworkCore;
using OakleyShop.Data.DatabaseContext;
using OakleyShop.Domain.Entities;
using OakleyShop.Domain.Interfaces.Repositories;

namespace OakleyShop.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<Category> _dataset;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = context.Set<Category>();
        }


        public async Task<Category> CreateAsync(Category category)
        {
            try
            {

                var seek = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(category.Id));

                category.CreateAt = DateTime.UtcNow;
                _dataset.Add(category);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            try
            {

                var result = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(category.Id));
                if (result != null)
                {

                    category.UpdateAt = DateTime.UtcNow;
                    category.CreateAt = result.CreateAt;

                    _dataset.Entry(result).CurrentValues.SetValues(category);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return category;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {

                var result = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(id));
                if (result != null)
                    _dataset.Remove(result);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                using (_context)
                {
                    return await _dataset.Take(40).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> GetAsync(Guid id)
        {
            try
            {
                using (_context)
                {
                    var result = await _dataset.SingleOrDefaultAsync(c => c.Id.Equals(id));
                    if (result is null)
                        return null;

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> GetByTitle(string title)
        {
            try
            {
                using (_context)
                {
                    var categories = await _dataset
                        .Where(c => c.Title.Normalize().Contains(title.Normalize()))
                        .AsNoTracking()
                        .Take(40)
                        .ToListAsync();

                    return categories;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }


    }
}
