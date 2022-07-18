using LanguageApp.Models.Dtos;

namespace LanguageApp.Client.Services.Contracts
{
    public interface ISentenceService
    {
        Task<List<SentenceDto>> GetSentences();
        Task<SentenceDto> GetSentence(int id);
        Task<SentenceDto> AddSentence(SentenceToAddDto sentenceToAddDto);
    }
}
