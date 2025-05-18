namespace App.DTO.v1;

public class MiniatureCollectionStats
{
    public int TotalMiniatures { get; set; }
    public Dictionary<string, int> MiniaturesByState { get; set; } = new();
    public Dictionary<string, int> MiniaturesByMonth { get; set; } = new();
}