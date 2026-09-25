using System.Text.Json;
using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon.Game;

public class Adventurer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    public int XP { get; set; }
    public int Shift { get; set; }
    public int Discipline { get; set; }
    public int Precision { get; set; }
    public Weapon? Weapon { get; set; }
    public int AppliedRunes { get; set; }
    public List<WeaponManoeuvre>? WeaponManoeuvres { get; set; }
    public List<ArmourPiece>? ArmourPieces { get; set; }
    public List<MagicScroll>? MagicScrolls { get; set; }
    public int LegendStatusLevelTracker { get; set; }
    public List<MagicPotion>? MagicPotions { get; set; }
    public int Bloodied { get; set; }
    public Boolean Fever { get; set; }
    public int Soaked { get; set; }
    public Boolean Pneumonia { get; set; }
    public Coins Coins { get; set; }
    public string? Treasures { get; set; }
    public int LiberatedPrisoners { get; set; }
    public string? SideQuests { get; set; }
    public List<string> LargeAndHeavyItems { get; set; }
    public string? SmallItems { get; set; }
    public string? AdditionalNotes { get; set; }
    public string? LootLockup { get; set; }
    public Dictionary<string, string> NarrativeMoments { get; set; }
    public FavorOfTheGods FavorOfTheGods { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Rations { get; set; }

    public const int DefaultMaxHealthPoints = 10;

    public Adventurer()
    {
        Name = string.Empty;
        Level = 1;
        XP = 0;
        WeaponManoeuvres = new List<WeaponManoeuvre>();
        ArmourPieces = new List<ArmourPiece>();
        MagicScrolls = new List<MagicScroll>();
        MagicPotions = new List<MagicPotion>();
        LegendStatusLevelTracker = 0;
        Fever = false;
        Pneumonia = false;
        Coins = new Coins();
        Treasures = string.Empty;
        SideQuests = string.Empty;
        LiberatedPrisoners = 0;
        LargeAndHeavyItems = new List<string>();
        SmallItems = string.Empty;
        AdditionalNotes = string.Empty;
        LootLockup = string.Empty;
        NarrativeMoments = new Dictionary<string, string>();
        FavorOfTheGods = new FavorOfTheGods();

        //Values from Core Rules
        Shift = 2;
        Discipline = 1;
        Precision = 0;
        MaxHealthPoints = DefaultMaxHealthPoints;
        HealthPoints = MaxHealthPoints;
        Rations = 3;
    }
    
    public Adventurer(string name)
    {
        Name = name;
        Level = 1;
        XP = 0;
        WeaponManoeuvres = new List<WeaponManoeuvre>();
        ArmourPieces = new List<ArmourPiece>();
        MagicScrolls = new List<MagicScroll>();
        MagicPotions = new List<MagicPotion>();
        LegendStatusLevelTracker = 0;
        Fever = false;
        Pneumonia = false;
        Coins = new Coins();
        Treasures = string.Empty;
        SideQuests = string.Empty;
        LiberatedPrisoners = 0;
        LargeAndHeavyItems = new List<string>();
        SmallItems = string.Empty;
        AdditionalNotes = string.Empty;
        LootLockup = string.Empty;
        NarrativeMoments = new Dictionary<string, string>();
        FavorOfTheGods = new FavorOfTheGods();

        //Values from Core Rules
        Shift = 2;
        Discipline = 1;
        Precision = 0;
        MaxHealthPoints = DefaultMaxHealthPoints;
        HealthPoints = MaxHealthPoints;
        Rations = 3;
    }

    public Adventurer(AdventurerDTO preview){
        if(string.IsNullOrEmpty(preview.serialiazedObj)){
            
            Id = preview.id;
            Name =  preview.name;
            XP = preview.xp;
            Level = preview.level;
            WeaponManoeuvres = new List<WeaponManoeuvre>();
            ArmourPieces = new List<ArmourPiece>();
            MagicScrolls = new List<MagicScroll>();
            MagicPotions = new List<MagicPotion>();
            LegendStatusLevelTracker = 0;
            Fever = false;
            Pneumonia = false;
            Coins = new Coins();
            Treasures = string.Empty;
            SideQuests = string.Empty;
            LiberatedPrisoners = 0;
            LargeAndHeavyItems = new List<string>();
            SmallItems = string.Empty;
            AdditionalNotes = string.Empty;
            LootLockup = string.Empty;
            NarrativeMoments = new Dictionary<string, string>();
            FavorOfTheGods = new FavorOfTheGods();

            //Values from Core Rules
            Shift = 2;
            Discipline = 1;
            Precision = 0;
            MaxHealthPoints = DefaultMaxHealthPoints;
            HealthPoints = MaxHealthPoints;
            Rations = 3;
        }
        else
        {
            Adventurer aComplete = DatabaseDecode(preview.serialiazedObj);
            Id = aComplete.Id;
            Name = aComplete.Name;
            Level = aComplete.Level;
            XP = aComplete.XP;
            Discipline = aComplete.Discipline;
            WeaponManoeuvres = aComplete.WeaponManoeuvres;
            ArmourPieces = aComplete.ArmourPieces;
            MagicScrolls = aComplete.MagicScrolls;
            MagicPotions = aComplete.MagicPotions;
            LegendStatusLevelTracker = aComplete.LegendStatusLevelTracker;
            Fever = aComplete.Fever;
            Pneumonia = aComplete.Pneumonia;
            Coins = aComplete.Coins;
            Treasures = aComplete.Treasures;
            SideQuests = aComplete.SideQuests;
            LiberatedPrisoners = aComplete.LiberatedPrisoners;
            LargeAndHeavyItems = aComplete.LargeAndHeavyItems ?? new List<string>();
            SmallItems = aComplete.SmallItems;
            AdditionalNotes = aComplete.AdditionalNotes;
            LootLockup = aComplete.LootLockup;
            NarrativeMoments = aComplete.NarrativeMoments ?? new Dictionary<string, string>();
            FavorOfTheGods = aComplete.FavorOfTheGods;

            Shift = aComplete.Shift;
            Discipline = aComplete.Discipline;
            Precision = aComplete.Precision;
            HealthPoints = aComplete.HealthPoints;
            // Saves from before MaxHealthPoints existed get the default max, raised if their HP is already higher
            MaxHealthPoints = Math.Max(aComplete.MaxHealthPoints, aComplete.HealthPoints);
            Rations = aComplete.Rations <= 0 ? 3 : aComplete.Rations;
        }
    }

    /// <summary>
    /// Heals the adventurer by up to <paramref name="amount"/> Health Points without going over MaxHealthPoints.
    /// HP already above the maximum (e.g. from a "can exceed baseline" effect) is left unchanged.
    /// </summary>
    /// <returns>The number of Health Points actually recovered.</returns>
    public int Heal(int amount)
    {
        if (amount <= 0 || HealthPoints >= MaxHealthPoints)
        {
            return 0;
        }

        int previous = HealthPoints;
        HealthPoints = Math.Min(HealthPoints + amount, MaxHealthPoints);
        return HealthPoints - previous;
    }

    private static Adventurer DatabaseDecode(string base64EncodedData) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        string jsonPlayer = System.Text.Encoding.UTF8.GetString(base64EncodedBytes)!;
        return JsonSerializer.Deserialize<Adventurer>(jsonPlayer)!;
    }
}
