using LanguageApp.Models.Dtos;

namespace LanguageApp.Client.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesDtos();
    }
}
