using LanguageApp.Models.Dtos;

namespace LanguageApp.Client.Services.Contracts
{
    public interface ITagService
    {
        Task<List<TagDto>> GetAllTags();
    }
}
