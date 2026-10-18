namespace c5m._2d6Dungeon;

public class MappedRoom
{
    public int Id { get; set; }
    public bool IsCorridor { get; set; }
    public bool IsUnique { get; set; }
    public string? RoomType { get; set; }
    public int ExitsCount { get; set; }
    public Dictionary<Direction,Exit>? Exits { get; set; }
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool IsLobby { get; set; } = false;
    public string? Description { get; set; }
    public string? Encounter { get; set; }
    public string? ExitsType { get; set; }
    public int? LockRoll { get; set; }
    public bool YouAreHere { get; set; } = false;

    /// <summary>
    /// True once the room's dimensions have been rolled (Width and Height are both positive).
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public bool HasDimensions => Width > 0 && Height > 0;

    [System.Text.Json.Serialization.JsonIgnore]
    public string DisplayName
    {
        get
        {
            if (IsLobby)
            {
                return "Lobby";
            }
            if (IsCorridor)
            {
                return $"Corridor {Id}";
            }
            return string.IsNullOrWhiteSpace(RoomType) ? $"Room {Id}" : RoomType;
        }
    }


    public const int MinSide = 2;
    public const int MaxSide = 12;
    public const int MaxCorridorSide = 6;

    /// <summary>Allowed Width when editing. A corridor's 1-wide side is locked; its other side is 2-6.</summary>
    public (int Min, int Max) GetWidthRange() => GetSideRange(Width, Height);

    /// <summary>Allowed Height when editing. A corridor's 1-wide side is locked; its other side is 2-6.</summary>
    public (int Min, int Max) GetHeightRange() => GetSideRange(Height, Width);

    private (int Min, int Max) GetSideRange(int side, int otherSide)
    {
        if (IsCorridor && side == 1) return (1, 1);
        if (IsCorridor && otherSide == 1) return (MinSide, MaxCorridorSide);
        return (MinSide, MaxSide);
    }

    public static MappedRoom DraftCurrentRoom(DiceResult dResult){
        return new MappedRoom{
            Width = dResult.PrimaryDice,
            Height = dResult.SecondaryDice,
            IsCorridor = dResult.IsOneDiceOne
        };
    }

}
