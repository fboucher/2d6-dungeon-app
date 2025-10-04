using System.Text.Json;
using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

//lowercase to match the database
public class AdventurePreview
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int id { get; set; } = 0;
    public string name { get; set; } = string.Empty;
    public int adventurer_id { get; set; } = 0;
    public int level { get; set; } = 0;
    public string last_saved_datetime { get; set; } = string.Empty;
    public string serialiazedObj { get; set; } = string.Empty;

    public AdventurePreview(){}

    public AdventurePreview(Adventure a)
    {
        id = 0;
        name = a.Name;
        adventurer_id = a.Adventurer.Id;
        level = a.Dungeon.FloorLevel;
        serialiazedObj = DatabaseEncode(a);
    }

    private static string DatabaseEncode(Adventure adventure)
    {
        var jsonAdventure = JsonSerializer.Serialize<Adventure>(adventure);
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(jsonAdventure);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}