using System.Text.Json;
using System.Text.Json.Serialization;
using c5m._2d6Dungeon.Game;

namespace c5m._2d6Dungeon;

//lowercase to match the database
public class AdventurerDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int id { get; set; } = 0;
    public string name { get; set; } = string.Empty;
    public int level { get; set; }
    public int xp { get; set; }
    public string serialiazedObj { get; set; } = string.Empty;

    public AdventurerDTO(){}

    public AdventurerDTO(Adventurer a)
    {
        id = 0;
        name = a.Name;
        level = a.Level;
        xp = a.XP;
        serialiazedObj = DatabaseEncode(a);
    }

    private static string DatabaseEncode(Adventurer player)
    {
        var jsonPlayer = JsonSerializer.Serialize<Adventurer>(player);
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(jsonPlayer);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}



