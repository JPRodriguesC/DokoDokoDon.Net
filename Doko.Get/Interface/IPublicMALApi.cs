using Doko.Get.Model.MyAnimeList;

namespace Doko.Get.Interface;

public interface IPublicMALApi
{
    Task<IEnumerable<MALAnime>> GetSeasonalAnimeAsync(int year, string season);
}