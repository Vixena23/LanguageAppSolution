using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LanguageApp.Api.Repositories
{
    public class SentenceRepository : ISentenceRepository
    {
        private readonly LanguageAppDbContext _languageAppDbContext;

        public SentenceRepository(LanguageAppDbContext languageAppDbContext)
        {
            _languageAppDbContext = languageAppDbContext;
        }

        public async Task<Sentence> AddSentence(SentenceToAddDto sentenceToAddDto)
        {
            var sentence = new Sentence
            {
                OryginalText = sentenceToAddDto.OryginalText,
                TranslateText = sentenceToAddDto.TranslateText,
                CategoryId = sentenceToAddDto.CategoryId,
                TagId = sentenceToAddDto.TagId
            };

            var result = await _languageAppDbContext.Sentences.AddAsync(sentence);
            await _languageAppDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Sentence> DeleteSentence(int id)
        {
            var sentence = await _languageAppDbContext.Sentences.FindAsync(id);

            if (sentence != null)
            {
                _languageAppDbContext.Sentences.Remove(sentence);
                await _languageAppDbContext.SaveChangesAsync();
            }

            return sentence;
        }

        public async Task<SentenceDto> GetSentence(int id)
        {
            return await (from sentence in _languageAppDbContext.Sentences
                                  join tag in _languageAppDbContext.Tags
                                  on sentence.TagId equals tag.Id
                                  join category in _languageAppDbContext.Categories
                                  on sentence.CategoryId equals category.Id
                                  where sentence.Id == id
                                  select new SentenceDto
                                  {
                                      Id = sentence.Id,
                                      TagId = tag.Id,
                                      CategoryId = category.Id,
                                      OryginalText = sentence.OryginalText,
                                      TranslateText = sentence.TranslateText,
                                      CategoryName = category.Name,
                                      TagName = tag.Name,
                                      TagColor = tag.Color
                                  }).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<SentenceDto>> GetSentences()
        {
            return await (from sentence in _languageAppDbContext.Sentences
                          join tag in _languageAppDbContext.Tags
                          on sentence.TagId equals tag.Id
                          join category in _languageAppDbContext.Categories
                          on sentence.CategoryId equals category.Id
                          select new SentenceDto
                          {
                              Id = sentence.Id,
                              TagId = tag.Id,
                              CategoryId = category.Id,
                              OryginalText = sentence.OryginalText,
                              TranslateText = sentence.TranslateText,
                              CategoryName = category.Name,
                              TagName = tag.Name,
                              TagColor = tag.Color
                          }).ToListAsync();
        }

        public async Task<Sentence> UpdateSentence(SentenceDto sentenceDto)
        {
            var sentence = await _languageAppDbContext.Sentences.FindAsync(sentenceDto.Id);

            if (sentence != null)
            {
                var result = _languageAppDbContext.Sentences.Update(sentence);
                await _languageAppDbContext.SaveChangesAsync();
                return result.Entity;
            }

            return sentence;
        }
    }
}
