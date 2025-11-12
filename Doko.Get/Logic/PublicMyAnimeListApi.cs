using Doko.Get.Interface;
using Doko.Get.Model.MyAnimeList;
using System.Text.Json;

namespace Doko.Get.Logic;

public class PublicMyAnimeListApi : IPublicMALApi
{
    private readonly HttpClient _httpClient;

    public PublicMyAnimeListApi(HttpClient httpClient)
    {
        var clientId = Environment.GetEnvironmentVariable("MAL_CLIENT_ID");
        var malUri = Environment.GetEnvironmentVariable("MAL_URL") ?? throw new ArgumentNullException("Environment variable not found: MAL_URL.");

        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(malUri);
        _httpClient.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", clientId);
    }

    public async Task<IEnumerable<MALAnime>> GetSeasonalAnimeAsync(int year, string season)
    {
        var response = await _httpClient.GetAsync($"anime/season/{year}/{season}?limit=500");
        if (response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var content = await response.Content.ReadAsStringAsync();
            var malres = JsonSerializer.Deserialize<MALResponse<MALAnime>>(content, options);
            if (malres is not null) return malres.Data.Select(d => d.Node);
        }

        return new List<MALAnime>();
    }
}