using LanguageApp.Api.Entity;
using LanguageApp.Models.Dtos;

namespace LanguageApp.Api.Repositories.Contracts
{
    public interface ISentenceRepository
    {
        Task<IEnumerable<SentenceDto>> GetSentences();
        Task<SentenceDto> GetSentence(int id);
        Task<Sentence> DeleteSentence(int id);
        Task<Sentence> AddSentence(SentenceToAddDto sentenceToAddDto);
        Task<Sentence> UpdateSentence(SentenceDto sentenceDto);
    }
}
