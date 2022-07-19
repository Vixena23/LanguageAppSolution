using LanguageApp.Api.Entity;
using LanguageApp.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetCategories()
        {
            var tags = await _tagRepository.GetAllTags();

            if (tags == null)
            {
                return NoContent();
            }

            return Ok(tags);
        }
    }
}
