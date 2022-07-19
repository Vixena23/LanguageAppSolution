using LanguageApp.Api.Entity;
using LanguageApp.Models.Dtos;

namespace LanguageApp.Api.Repositories.Contracts
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTags();
        Task<Tag> GetTag(int id);
        Task<List<TagDto>> GetSentencesTags(int sentenceId);
        Task AddSentencesTags(List<SentencesTag> tags);
    }
}
