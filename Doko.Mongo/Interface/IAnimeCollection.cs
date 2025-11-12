using Doko.Mongo.Document;

namespace Doko.Mongo.Interface;

public interface IAnimeCollection
{
    Task InsertAsync(ICollection<Anime> animes);
}
