using Doko.Don.Interface;
using Doko.Don.Model;
using Doko.Don.Model.Enums;
using Doko.Mongo.Document;
using Microsoft.AspNetCore.Mvc;

namespace Doko.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly ILogger<AnimeController> _logger;
    private readonly IAnimeService _service;

    public AnimeController(ILogger<AnimeController> logger, IAnimeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetSeasonal")]
    public async Task<IEnumerable<Anime>> List(int year, SeasonEnum season)
        => await _service.ListSeasonalAsync(year, season);
}
