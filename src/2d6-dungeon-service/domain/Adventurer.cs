using System.Text.Json;

namespace c5m._2d6Dungeon.Game;

public class Adventurer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int HealthPoints { get; set; }
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
    public List<string>? Treasures { get; set; }
    public int LiberatedPrisoners { get; set; }
    public List<string>? SideQuests { get; set; }
    public FavorOfTheGods FavorOfTheGods { get; set; }
    public int Rations { get; set; }
    
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
        Treasures = new List<string>();
        SideQuests = new List<string>();
        LiberatedPrisoners = 0;
        FavorOfTheGods = new FavorOfTheGods();

        //Values from Core Rules
        Shift = 2;
        Discipline = 1;
        Precision = 0;
        HealthPoints = 10;
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
        Treasures = new List<string>();
        SideQuests = new List<string>();
        LiberatedPrisoners = 0;
        FavorOfTheGods = new FavorOfTheGods();

        //Values from Core Rules
        Shift = 2;
        Discipline = 1;
        Precision = 0;
        HealthPoints = 10;
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
            Treasures = new List<string>();
            SideQuests = new List<string>();
            LiberatedPrisoners = 0;
            FavorOfTheGods = new FavorOfTheGods();

            //Values from Core Rules
            Shift = 2;
            Discipline = 1;
            Precision = 0;
            HealthPoints = 10;
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
            FavorOfTheGods = aComplete.FavorOfTheGods;

            Shift = aComplete.Shift;
            Discipline = aComplete.Discipline;
            Precision = aComplete.Precision;
            HealthPoints = aComplete.HealthPoints;
            Rations = aComplete.Rations;
        }
    }

    private static Adventurer DatabaseDecode(string base64EncodedData) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        string jsonPlayer = System.Text.Encoding.UTF8.GetString(base64EncodedBytes)!;
        return JsonSerializer.Deserialize<Adventurer>(jsonPlayer)!;
    }
}
