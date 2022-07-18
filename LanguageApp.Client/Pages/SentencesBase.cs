using Blazored.Modal;
using Blazored.Modal.Services;
using LanguageApp.Client.Services.Contracts;
using LanguageApp.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace LanguageApp.Client.Pages
{
    public class SentencesBase : ComponentBase
    {
        [Inject]
        public ISentenceService SentenceService { get; set; }
        [Inject]
        public IModalService ModalService { get; set; }
        public List<SentenceDto> Sentences { get; set; }
        //public IEnumerable<TagDto> Tags { get; set; }
        //public IEnumerable<CategoryDto> Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Sentences = await SentenceService.GetSentences();
        }

        protected async Task ShowModal()
        {
            var formModal = ModalService.Show<AddSentence>("Dodaj zdanie");
            var result = await formModal.Result;

            if (result.Cancelled)
            {
                Console.WriteLine("Modal was cancelled");
            }
            else
            {
                var sentenceToAdd = (SentenceDto)result.Data;
                Sentences.Add(sentenceToAdd);
            }
        }
    }

}
