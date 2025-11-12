using Doko.Mongo.Document;
using Doko.Mongo.Interface;
using MongoDB.Driver;

namespace Doko.Mongo.Collection;

public class AnimeCollection : IAnimeCollection
{
    private readonly IMongoCollection<Anime> _animes;

    public AnimeCollection(IMongoDatabase db)
        =>_animes = db.GetCollection<Anime>("anime");
    
    public async Task InsertAsync(ICollection<Anime> animes)
        => await _animes.InsertManyAsync(animes);
}
