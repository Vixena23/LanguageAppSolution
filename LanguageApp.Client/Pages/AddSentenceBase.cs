using Blazored.Modal;
using Blazored.Modal.Services;
using LanguageApp.Client.Services.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace LanguageApp.Client.Pages
{
    public class AddSentenceBase : ComponentBase
    {
        protected SentenceToAddDto newSentence { get; set; } = new SentenceToAddDto();
        protected IEnumerable<CategoryDto> Categories { get; set; }
        protected List<TagDto> Tags { get; set; } = new List<TagDto>();
        protected string[] selected = new[] { "white", "black" };

        [Inject]
        public ISentenceService SentenceService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }
        [Inject]
        public ITagService TagService { get; set; }

        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategoriesDtos();
            Tags = await TagService.GetAllTags();
            newSentence.CategoryId = 1;
        }

        protected async Task HandleValidSubmit()
        {
             await CloseModalAndPassVariable(newSentence);
        }

        protected async Task Cancel()
        {
            await ModalInstance.CancelAsync();
        }

        private async Task CloseModalAndPassVariable(SentenceToAddDto sentenceToAddDto)
        {
            
            var result = await AddSentence(sentenceToAddDto);
            if (result != null)
            {
                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                Console.WriteLine("Nie udało sie utwożyć nowego zdania!");
            }
        }

        private async Task<SentenceDto> AddSentence(SentenceToAddDto sentenceToAddDto)
        {
            var result = await SentenceService.AddSentence(sentenceToAddDto);
            return result;
        }
    }
}
