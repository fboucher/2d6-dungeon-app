namespace c5m._2d6Dungeon;

public class Creature
{
    public required int id { get; set; }
    public required string name { get; set; }
    public required int level { get; set; }
    public required string creature_type { get; set; }
    public required int health_points { get; set; }
    public int? experience { get; set; }
    public int? shift_points { get; set; }
    public string? treasure { get; set; }
    public string? interrupt1 { get; set; }
    public string? interrupt2 { get; set; }
    public string? manoeuvre1 { get; set; }
    public string? manoeuvre2 { get; set; }
    public string? description { get; set; }
    public string? prime_attack_rolls { get; set; }
    public string? mishap_attack_rolls { get; set; }
}