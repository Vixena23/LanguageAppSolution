using LanguageApp.Api.Data;
using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
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
        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _languageAppDbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetTag(int id)
        {
            return await _languageAppDbContext.Tags.FindAsync(id);
        }
    }
}
