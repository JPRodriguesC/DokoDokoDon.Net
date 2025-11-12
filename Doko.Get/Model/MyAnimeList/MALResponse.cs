namespace Doko.Get.Model.MyAnimeList;

public class MALResponse<T>
{
    public IEnumerable<DataNode<T>> Data { get; set; } = default!;
    public Paging Paging { get; set; } = default!;
}

public record DataNode<T>
(
    T Node
);

public record Paging
(
    string Previous,
    string Next
);