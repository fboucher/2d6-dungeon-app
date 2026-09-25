using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace c5m._2d6Dungeon;

public class MagicPotion
{
    private static readonly Regex HealRegex = new(@"Heal up to (\d+) Health Points", RegexOptions.IgnoreCase);

    public int Id { get; set; }

    [JsonPropertyName("potion_type")]
    public required string PotionType { get; set; }
    public string? Modifier { get; set; }
    public string? Duration { get; set; }
    public string? Cost { get; set; }

    /// <summary>
    /// Health Points restored by a healing potion (e.g. "Heal up to 10 Health Points"), or 0 if it doesn't heal.
    /// </summary>
    [JsonIgnore]
    public int HealAmount
    {
        get
        {
            var match = HealRegex.Match(Modifier ?? string.Empty);
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
    }
}
