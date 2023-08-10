using Microsoft.EntityFrameworkCore;
using OakleyShop.Data.DatabaseContext;
using OakleyShop.Domain.Entities;
using OakleyShop.Domain.Interfaces.Repositories;

namespace OakleyShop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<Product> _dataset;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = context.Set<Product>();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    product.CreateAt = DateTime.UtcNow;
                    await _dataset.AddAsync(product);
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(product.Id));
                    if (result != null)
                        product.UpdateAt = DateTime.UtcNow;
                    product.CreateAt = result.CreateAt;

                    _context.Entry(result).CurrentValues
                        .SetValues(product);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (_context)
                {
                    var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                    if (result is null)
                    {
                        return false;
                    }

                    _dataset.Remove(result);
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetAllByCategoryAsync(string code)
        {
            try
            {
                using (_context)
                {
                    var products = await _dataset
                        .Include(c => c.Category)
                        .Where(p => p.Code.Normalize()
                        .Contains(code.Normalize()))
                        .Take(40).AsNoTracking().ToListAsync();

                    return products;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                using (_context)
                {
                    var result = await _dataset.FirstOrDefaultAsync(p => p.Id.Equals(id));
                    if (result != null)
                        return result;

                    return null;
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
