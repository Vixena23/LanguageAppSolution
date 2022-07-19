using LanguageApp.Api.Extensions;
using LanguageApp.Api.Repositories.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly ISentenceRepository _sentenceRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SentenceController(ISentenceRepository sentenceRepository,
                                  ITagRepository tagRepository,
                                  ICategoryRepository categoryRepository)
        {
            _sentenceRepository = sentenceRepository;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<SentenceDto>> PostSentence([FromBody] SentenceToAddDto sentenceToAddDto)
        {
            try
            {
                var newSentence = await _sentenceRepository.AddSentence(sentenceToAddDto);

                if (newSentence == null)
                {
                    return NoContent();
                }

                var category = await _categoryRepository.GetCategory(newSentence.CategoryId);

                if (category == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrive a category (categoryId:{newSentence.CategoryId})");
                }

                if (sentenceToAddDto.Tags.Count > 0)
                {
                    var sentencesTags = sentenceToAddDto.Tags.ConvertToEntity(newSentence.Id);

                    await _tagRepository.AddSentencesTags(sentencesTags);
                }
                

                var sentenceDto = newSentence.ConvertToDto(sentenceToAddDto.Tags, category);

                return Ok(sentenceDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SentenceDto>> GetSentence(int id)
        {
            var sentenceDto = await _sentenceRepository.GetSentence(id);

            if (sentenceDto == null)
            {
                return NoContent();
            }

            return Ok(sentenceDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SentenceDto>>> GetSentences()
        {
            var sentences = await _sentenceRepository.GetSentences();

            if (sentences == null)
            {
                return NoContent();
            }

            return Ok(sentences);
        }
    }
}
