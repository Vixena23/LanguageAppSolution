using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LanguageApp.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LanguageAppDbContext _languageAppDbContext;

        public CategoryRepository(LanguageAppDbContext languageAppDbContext)
        {
            _languageAppDbContext = languageAppDbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _languageAppDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _languageAppDbContext.Categories.FindAsync(id);
        }
    }
}
