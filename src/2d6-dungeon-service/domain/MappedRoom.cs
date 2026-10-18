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

    /// <summary>Number of cells along the given wall.</summary>
    public int GetWallLength(Direction wall) =>
        wall == Direction.North || wall == Direction.South ? Width : Height;

    /// <summary>Grid cell occupied by the door on the given wall.</summary>
    public (int X, int Y) GetDoorCell(Direction wall)
    {
        if (Exits == null || !Exits.TryGetValue(wall, out var exit))
            throw new InvalidOperationException($"Room {Id} has no exit on wall '{wall}'.");

        return wall switch
        {
            Direction.North => (CoordX - 1 + exit.PositionOnWall, CoordY - 1),
            Direction.East => (CoordX + Width, CoordY - 1 + exit.PositionOnWall),
            Direction.South => (CoordX - 1 + exit.PositionOnWall, CoordY + Height),
            Direction.West => (CoordX - 1, CoordY - 1 + exit.PositionOnWall),
            _ => throw new ArgumentOutOfRangeException(nameof(wall), wall, "Unknown wall direction")
        };
    }

    /// <summary>A wall can take a new door when it has none.</summary>
    public bool CanAddDoor(Direction wall) => Exits == null || !Exits.ContainsKey(wall);

    /// <summary>
    /// Only unexplored doors can be removed; connected doors and the Lobby's south door stay.
    /// </summary>
    public bool CanRemoveDoor(Direction wall)
    {
        if (Exits == null || !Exits.TryGetValue(wall, out var exit)) return false;
        if (IsLobby && wall == Direction.South) return false;
        return exit.TargetRoomId == null;
    }

    /// <summary>
    /// Adds an unexplored door at position 1. Type and lock state are copied from another
    /// unexplored door of the room, falling back to <see cref="ExitsType"/> and unlocked.
    /// </summary>
    public Exit AddDoor(Direction wall)
    {
        if (!CanAddDoor(wall))
            throw new InvalidOperationException($"Room {Id} already has a door on wall '{wall}'.");

        Exits ??= new Dictionary<Direction, Exit>();
        var template = Exits.Values.FirstOrDefault(e => e.TargetRoomId == null);

        var door = new Exit { Direction = wall, PositionOnWall = 1 };
        if (template != null)
        {
            door.ExitType = template.ExitType;
            door.Lockable = template.Lockable;
            door.IsLocked = template.IsLocked;
        }
        else
        {
            door.ExitType = ExitsType;
            door.Lockable = GameTurn.IsDoorTypeLockable(ExitsType);
        }

        Exits.Add(wall, door);
        ExitsCount++;
        return door;
    }

    public bool RemoveDoor(Direction wall)
    {
        if (!CanRemoveDoor(wall)) return false;

        Exits!.Remove(wall);
        ExitsCount = Math.Max(0, ExitsCount - 1);
        return true;
    }

    public static MappedRoom DraftCurrentRoom(DiceResult dResult){
        return new MappedRoom{
            Width = dResult.PrimaryDice,
            Height = dResult.SecondaryDice,
            IsCorridor = dResult.IsOneDiceOne
        };
    }

}
