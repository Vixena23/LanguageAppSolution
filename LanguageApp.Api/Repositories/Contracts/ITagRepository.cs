using LanguageApp.Api.Entity;

namespace LanguageApp.Api.Repositories.Contracts
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTags();
        Task<Tag> GetTag(int id);
    }
}
