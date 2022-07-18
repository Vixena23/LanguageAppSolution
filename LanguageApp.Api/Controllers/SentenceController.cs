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

        public SentenceController(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
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

                var newSentenceDto = await _sentenceRepository.GetSentence(newSentence.Id);

                if (newSentenceDto == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrive a sentence (sentenceId:{newSentence.Id})");
                }

                return Ok(newSentenceDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SentenceDto>> GetSentence(int id)
        {
            var sentence = await _sentenceRepository.GetSentence(id);

            if (sentence == null)
            {
                return NoContent();
            }

            return Ok(sentence);
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
