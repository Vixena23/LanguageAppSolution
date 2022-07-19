using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LanguageApp.Api.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly LanguageAppDbContext _languageAppDbContext;

        public TagRepository(LanguageAppDbContext languageAppDbContext)
        {
            _languageAppDbContext = languageAppDbContext;
        }

        public async Task AddSentencesTags(List<SentencesTag> tags)
        {
            _languageAppDbContext.SentencesTags.AddRange(tags);
            await _languageAppDbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _languageAppDbContext.Tags.ToListAsync();
        }

        public async Task<List<TagDto>> GetSentencesTags(int sentenceId)
        {
            return await (from sentencesTag in _languageAppDbContext.SentencesTags
                          join tag in _languageAppDbContext.Tags
                          on sentencesTag.TagId equals tag.Id
                          where sentencesTag.Id == sentenceId
                          select new TagDto
                          {
                              Id = tag.Id,
                              Color = tag.Color,
                              Name = tag.Name
                          }).ToListAsync();
        }

        public async Task<Tag> GetTag(int id)
        {
            return await _languageAppDbContext.Tags.FindAsync(id);
        }
    }
}
