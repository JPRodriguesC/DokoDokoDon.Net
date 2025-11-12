using System.Text.Json.Serialization;

namespace Doko.Get.Model.MyAnimeList;

public class MALAnime
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("main_picture")]
    public MainPicture? MainPicture { get; set; }

    [JsonPropertyName("alternative_titles")]
    public AlternativeTitles? AlternativeTitles { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public string? Synopsis { get; set; }

    public float? Mean { get; set; }

    public int? Rank { get; set; }

    public int? Popularity { get; set; }

    [JsonPropertyName("num_list_users")]
    public int? NumListUsers { get; set; }

    [JsonPropertyName("num_scoring_users")]
    public int? NumScoringUsers { get; set; }

    public string? Nsfw { get; set; }

    public List<Genre>? Genres { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("media_type")]
    public string? MediaType { get; set; } = string.Empty;

    public string? Status { get; set; }

    [JsonPropertyName("my_list_status")]
    public MyListStatus? MyListStatus { get; set; }

    [JsonPropertyName("num_episodes")]
    public int? NumEpisodes { get; set; }

    [JsonPropertyName("start_season")]
    public StartSeason? StartSeason { get; set; }

    public Broadcast? Broadcast { get; set; }

    public string? Source { get; set; }

    [JsonPropertyName("average_episode_duration")]
    public int? AverageEpisodeDuration { get; set; }

    public string? Rating { get; set; }

    public List<Studio>? Studios { get; set; }
}

public class MainPicture
{
    public string? Medium { get; set; }
    public string? Large { get; set; }
}

public class AlternativeTitles
{
    public string? Synonyms { get; set; }
    public string? En { get; set; }
    public string? Ja { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class MyListStatus
{
    public string? Status { get; set; }
    public int? Score { get; set; }
    public int? NumEpisodesWatched { get; set; }
    public bool? IsRewatching { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
}

public class StartSeason
{
    public int Year { get; set; }
    public string? Season { get; set; }
}

public class Broadcast
{
    public string? DayOfTheWeek { get; set; }
    public string? StartTime { get; set; }
}

public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

