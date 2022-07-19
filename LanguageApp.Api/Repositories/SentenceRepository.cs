using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Extensions;
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
                                  join category in _languageAppDbContext.Categories
                                  on sentence.CategoryId equals category.Id
                                  where sentence.Id == id
                                  select new SentenceDto
                                  {
                                      Id = sentence.Id,
                                      CategoryId = category.Id,
                                      OryginalText = sentence.OryginalText,
                                      TranslateText = sentence.TranslateText,
                                      CategoryName = category.Name,
                                      Tags = (from tag in _languageAppDbContext.Tags
                                              join sentenceTags in _languageAppDbContext.SentencesTags
                                              on tag.Id equals sentenceTags.TagId
                                              where sentenceTags.SentenceId == sentence.Id
                                              select new TagDto 
                                              { 
                                                Id = tag.Id,
                                                Name = tag.Name,
                                                Color = tag.Color
                                              }).ToList()
                                  }).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<SentenceDto>> GetSentences()
        {
            return await (from sentence in _languageAppDbContext.Sentences
                          join category in _languageAppDbContext.Categories
                          on sentence.CategoryId equals category.Id
                          select new SentenceDto
                          {
                              Id = sentence.Id,
                              CategoryId = category.Id,
                              OryginalText = sentence.OryginalText,
                              TranslateText = sentence.TranslateText,
                              CategoryName = category.Name,
                              Tags = (from tag in _languageAppDbContext.Tags
                                      join sentenceTags in _languageAppDbContext.SentencesTags
                                      on tag.Id equals sentenceTags.TagId
                                      where sentenceTags.SentenceId == sentence.Id
                                      select new TagDto
                                      {
                                          Id = tag.Id,
                                          Name = tag.Name,
                                          Color = tag.Color
                                      }).ToList()
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
