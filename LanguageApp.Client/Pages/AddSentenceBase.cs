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
        protected List<TagDto> tagListSelected { get; set; } = new List<TagDto>();

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
            newSentence.Tags = tagListSelected;
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

        private int _tagId = 0;
        protected int TagId
        {
            get
            {
                return _tagId;
            }
            set
            {
                UpdateTag(value);
                _tagId = 0;
            }
        }

        private void UpdateTag(int tagId)
        {
            var tag = Tags.Find(x => x.Id == tagId);
            tagListSelected.Add(tag);
            Tags.Remove(tag);
        }
        protected void RemoveTag(int tagId)
        {
            var tag = tagListSelected.Find(x => x.Id == tagId);
            Tags.Add(tag);
            tagListSelected.Remove(tag);
        }
    }
}
