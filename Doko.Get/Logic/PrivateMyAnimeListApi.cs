using System.Net.Http.Json;
using Doko.Get.Interface;
using Doko.Get.Model.MyAnimeList;

namespace Doko.Get;

public class PrivateMyAnimeListApi
{
    private readonly HttpClient _HttpClient;
    private readonly IApiToken _ApiToken;

    public PrivateMyAnimeListApi(HttpClient httpClient, IApiToken apiToken)
    {
        _HttpClient = httpClient;
        _ApiToken = apiToken;

        if (apiToken.HasToken()) 
            _HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken.TokenInfo?.access_token}");
    }

    public async Task Authorize()
    {
        // var response = await _httpClient.PostAsync("v1/oauth2/authorize", content.ToContent());
        
        // if(response.IsSuccessStatusCode)
        // {
        //     _apiToken.TokenInfo = response.Content.ReadFromJsonAsync<MyAnimeListToken>().Result;
        //     _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiToken.TokenInfo?.access_token}");
        // }
        // var code = await response.Content.ReadAsStringAsync();
        // await GetToken(code, codeVerifier);
    }

    public string GetAuthorizationLink()
    {
        MALAuthContent content = new();
        return $"v1/oauth2/authorize?{content.ToContent()}";
    }
}
