using LanguageApp.Client.Services.Contracts;
using LanguageApp.Models.Dtos;
using System.Net.Http.Json;

namespace LanguageApp.Client.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly HttpClient _httpClient;

        public SentenceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SentenceDto> AddSentence(SentenceToAddDto sentenceToAddDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Sentence", sentenceToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(SentenceDto);
                    }

                    return await response.Content.ReadFromJsonAsync<SentenceDto>(); 
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} - Message: {message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during 'AddSentence' request. Error message: {ex.Message}");
                throw;
            }
        }

        public async Task<SentenceDto> GetSentence(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Sentence/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(SentenceDto);
                    }

                    return await response.Content.ReadFromJsonAsync<SentenceDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} - Message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during 'GetSentence' request. Error message: {ex.Message}");
                throw;
            }
        }

        public async Task<List<SentenceDto>> GetSentences()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Sentence");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<SentenceDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<SentenceDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} - Message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during 'GetSentences' request. Error message: {ex.Message}");
                throw;
            }
        }
    }
}
