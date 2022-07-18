using LanguageApp.Client.Services.Contracts;
using LanguageApp.Models.Dtos;
using System.Net.Http.Json;

namespace LanguageApp.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesDtos()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Category");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoryDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
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
