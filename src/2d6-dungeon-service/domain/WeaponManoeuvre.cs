using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class WeaponManoeuvre
{
    public int Id { get; set; }
    public int Level { get; set; }
    
    [JsonPropertyName("weapon_id")]
    public int WeaponId { get; set; }
    
    [JsonPropertyName("dice_set")]
    public string? DiceSet { get; set; }
    public string? Description { get; set; }
    public string? Modifier { get; set; }

    public static WeaponManoeuvre? Parse(string encodedString){

        if(string.IsNullOrEmpty(encodedString)) return null;

        var parts = encodedString.Split('|');
        return new WeaponManoeuvre{
            DiceSet = parts[0],
            Description = parts[1],
            Modifier = parts[2]
        };

    }    
}


