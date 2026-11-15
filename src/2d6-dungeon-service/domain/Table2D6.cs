using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon.domain;

public class SimpleTable2D6
{
    public required string TableCode { get; set; }
    public required string[] Headers { get; set; }
    public required List<SimpleTable2D6Row> Rows { get; set; }
}

public class SimpleTable2D6Row 
{
    public required string Roll { get; set; }
    public required string Description { get; set; }

    [JsonIgnore]
    public (int Primary, int Secondary) RollSortKey => ParseRollSortKey(Roll);

    private static (int Primary, int Secondary) ParseRollSortKey(string? roll)
    {
        if (string.IsNullOrWhiteSpace(roll))
        {
            return (int.MaxValue, int.MaxValue);
        }

        var trimmed = roll.AsSpan().Trim();
        var dashIndex = trimmed.IndexOf('-');
        if (dashIndex >= 0)
        {
            var firstPart = trimmed[..dashIndex].Trim();
            var secondPart = trimmed[(dashIndex + 1)..].Trim();
            if (int.TryParse(firstPart, out var primary) && int.TryParse(secondPart, out var secondary))
            {
                return (primary, secondary);
            }
        }

        if (int.TryParse(trimmed, out var single))
        {
            return (single, 0);
        }

        return (int.MaxValue, int.MaxValue);
    }
}
