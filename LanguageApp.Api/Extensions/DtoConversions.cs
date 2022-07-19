using LanguageApp.Api.Entity;
using LanguageApp.Models.Dtos;

namespace LanguageApp.Api.Extensions
{
    public static class DtoConversions
    {
        public static SentenceDto ConvertToDto (this Sentence sentence, 
                                                List<TagDto> tags,
                                                Category category)
        {
            return new SentenceDto
            {
                Id = sentence.Id,
                OryginalText = sentence.OryginalText,
                TranslateText = sentence.TranslateText,
                CategoryId = sentence.CategoryId,
                CategoryName = category.Name,
                Tags = tags
            };
        }
    }
}
