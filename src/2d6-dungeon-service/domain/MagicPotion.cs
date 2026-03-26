using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class MagicPotion
{
    public int Id { get; set; }

    [JsonPropertyName("potion_type")]
    public required string PotionType { get; set; }
    public string? Modifier { get; set; }
    public string? Duration { get; set; }
    public string? Cost { get; set; }
}
