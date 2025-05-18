namespace App.DTO.v1;

public class RandomMiniaturePick
{
    public Guid MiniatureCollectionId { get; set; }
    public string CollectionName { get; set; } = default!;
    public string? CollectionDesc { get; set; }
}
