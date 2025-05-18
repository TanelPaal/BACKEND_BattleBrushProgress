namespace App.DTO.v1;

public class PersonPaintsStats
{
    public int TotalPaints { get; set; }
    public Dictionary<string, int> PaintsByBrand { get; set; } = new();
    public Dictionary<string, int> PaintsByType { get; set; } = new();
    public Dictionary<string, int> PaintsByMonth { get; set; } = new();
}