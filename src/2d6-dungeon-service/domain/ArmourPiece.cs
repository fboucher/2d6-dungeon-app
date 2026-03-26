using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class ArmourPiece
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    [JsonPropertyName("dice_set")]
    public int DiceSet { get; set; }
    public string? Modifier { get; set; }
}
