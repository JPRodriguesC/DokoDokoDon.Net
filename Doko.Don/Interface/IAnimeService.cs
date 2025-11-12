using Doko.Don.Model.Enums;
using Doko.Don.Model;
using Doko.Mongo.Document;

namespace Doko.Don.Interface;

public interface IAnimeService
{
    Task<IEnumerable<Anime>> ListSeasonalAsync(int year, SeasonEnum season);
}
