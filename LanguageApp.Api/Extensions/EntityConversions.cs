using LanguageApp.Api.Entity;
using LanguageApp.Models.Dtos;

namespace LanguageApp.Api.Extensions
{
    public static class EntityConversions
    {
        public static List<SentencesTag> ConvertToEntity (this IEnumerable<TagDto> sentencesTags, int sentenceId)
        {
            return (from tag in sentencesTags
                    select new SentencesTag
                    {
                        SentenceId = sentenceId,
                        TagId = tag.Id
                    }).ToList();
        }
    }
}
