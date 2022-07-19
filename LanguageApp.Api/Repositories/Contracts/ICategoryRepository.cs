using LanguageApp.Api.Entity;
using LanguageApp.Models.Dtos;

namespace LanguageApp.Api.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
    }
}
