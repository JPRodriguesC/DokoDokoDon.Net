using Doko.Get.Interface;
using Doko.Don.Model.Enums;
using Doko.Don.Interface;
using Doko.Mongo.Document;
using Doko.Mongo.Interface;

namespace Doko.Don.Logic;

public class AnimeService : IAnimeService
{
    private readonly IPublicMALApi _publicMALApi;
    private readonly IAnimeCollection _animeCollection;

    public AnimeService(IPublicMALApi publicMALApi, IAnimeCollection animeCollection)
    {
        _publicMALApi = publicMALApi;
        _animeCollection = animeCollection;
    }
    
    public async Task<IEnumerable<Anime>> ListSeasonalAsync(int year, SeasonEnum season)
    {
        var seasonalAnimes = await _publicMALApi.GetSeasonalAnimeAsync(year, season.ToString());
        if (seasonalAnimes is not null)
        {
            var animes = from anime in seasonalAnimes
                        select new Anime
                        {
                            MyAnimeListId = anime.Id,
                            Title = anime.Title
                        };

            await _animeCollection.InsertAsync(animes.ToList());

            return animes;
        }

        return new List<Anime>();
    }
}
