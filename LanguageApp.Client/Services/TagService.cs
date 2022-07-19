using LanguageApp.Client.Services.Contracts;
using LanguageApp.Models.Dtos;
using System.Net.Http.Json;

namespace LanguageApp.Client.Services
{
    public class TagService : ITagService
    {
        private readonly HttpClient _httpClient;

        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TagDto>> GetAllTags()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Tag");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TagDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<TagDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} - Message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during 'GetCategories' request. Error message: {ex.Message}");
                throw;
            }
        }
    }
}
