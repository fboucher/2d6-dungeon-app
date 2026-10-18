using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class Dungeon
{
    /// <summary>
    /// Gets or sets the floor level of the dungeon.
    /// </summary>
    public int FloorLevel { get; set; } = 1;

    [JsonInclude]
    private List<MappedRoom> _mappedRooms;

    [JsonInclude]
    private Dictionary<int, HashSet<int>> _usedUniqueRoomsByLevel;


    /// <summary>
    /// Initializes a new instance of the <see cref="Dungeon"/> class.
    /// </summary>
    public Dungeon()
    {
        _mappedRooms = new List<MappedRoom>();
        _usedUniqueRoomsByLevel = new Dictionary<int, HashSet<int>>();
    }


    /// <summary>
    /// Gets the list of mapped rooms in the dungeon.
    /// </summary>
    private List<MappedRoom> MappedRooms
    {
        get => _mappedRooms;
        set => _mappedRooms = value;
    }

    public MappedRoom GetNewRoom()
    {
        var room = new MappedRoom();
        room.Id = MappedRooms.Count + 1;
        room.IsLobby = false; 
        return room;
    }

    /// <summary>
    /// Adds a room to the dungeon.
    /// </summary>
    /// <param name="room">The room to add.</param>
    /// <exception cref="ArgumentException">The room's dimensions are not set.</exception>
    public void AddRoom(MappedRoom room)
    {
        if (!room.HasDimensions)
            throw new ArgumentException($"Cannot add a room of {room.Width} by {room.Height}. Its dimensions must be rolled first.", nameof(room));
        if(room.Id == 0)
            room.Id = MappedRooms.Count + 1;
        MappedRooms.Add(room);
    }

    /// <summary>
    /// Gets the list of rooms in the dungeon.
    /// </summary>
    /// <returns>The list of mapped rooms.</returns>
    public List<MappedRoom> GetRooms()
    {
        return MappedRooms;
    }

    public MappedRoom? GetRoom(int id)
    {
        return MappedRooms.FirstOrDefault(r => r.Id == id);
    }

    /// <summary>
    /// Starts a new dungeon level based on the dice result.
    /// </summary>
    /// <param name="dResult">The dice result.</param>
    /// <returns>The starting room of the dungeon level.</returns>
    public static (MappedRoom Room, DiceResult Dice) StartDungeonLevel(DiceResult dResult)
    {
        var resultDice = new DiceResult
        {
            DiceRolled = dResult.DiceRolled,
            PrimaryDice = dResult.PrimaryDice,
            SecondaryDice = dResult.SecondaryDice,
            IsOneDiceOne = dResult.IsOneDiceOne,
            IsDouble = dResult.IsDouble,
            IsDoubleSix = dResult.IsDoubleSix
        };

        int area = resultDice.PrimaryDice * resultDice.SecondaryDice;
        if (area > 12)
        {
            resultDice.PrimaryDice = (int)Math.Ceiling((decimal)resultDice.PrimaryDice / 2);
            resultDice.SecondaryDice = (int)Math.Ceiling((decimal)resultDice.SecondaryDice / 2);
            area = resultDice.PrimaryDice * resultDice.SecondaryDice;
        }
        if (area < 6)
        {
            resultDice.PrimaryDice = 3;
            resultDice.SecondaryDice = 2;
        }
        var entryRoom = MappedRoom.DraftCurrentRoom(resultDice);
        entryRoom.Id = 1;
        entryRoom.ExitsCount = 3;
        entryRoom.Description = "This is the entrance of the dungeon. The room is empty.";
        return (entryRoom, resultDice);
    }


    /// <summary>
    /// Checks the doors of a room: each must sit within its wall and, when connected to a
    /// visited room, on the same grid cell as that room's door on the opposite wall.
    /// </summary>
    public List<DoorIssue> ValidateDoors(MappedRoom room)
    {
        var issues = new List<DoorIssue>();
        if (room.Exits == null) return issues;

        foreach (var (wall, exit) in room.Exits)
        {
            if (exit.PositionOnWall < 1 || exit.PositionOnWall > room.GetWallLength(wall))
            {
                issues.Add(new DoorIssue(wall, $"The {wall} door is outside the wall."));
                continue;
            }

            if (exit.TargetRoomId is not > 0) continue;

            var target = GetRoom(exit.TargetRoomId.Value);
            var opposite = GameTurn.GetOppositeDirection(wall);
            if (target?.Exits == null || !target.Exits.ContainsKey(opposite)) continue;

            if (room.GetDoorCell(wall) != target.GetDoorCell(opposite))
                issues.Add(new DoorIssue(wall, $"The {wall} door doesn't line up with {target.DisplayName}."));
        }

        return issues;
    }

    /// <summary>
    /// Finds the unexplored door of another room that faces the unexplored door on <paramref name="wall"/>
    /// of <paramref name="room"/> from the very same grid cell, if any.
    /// </summary>
    public (MappedRoom Room, Direction Wall)? FindConnectCandidate(MappedRoom room, Direction wall)
    {
        if (room.Exits == null || !room.Exits.TryGetValue(wall, out var exit) || exit.TargetRoomId != null)
            return null;

        var facing = GameTurn.GetOppositeDirection(wall);
        var cell = room.GetDoorCell(wall);

        foreach (var other in MappedRooms)
        {
            if (other.Id == room.Id) continue;
            if (other.Exits == null || !other.Exits.TryGetValue(facing, out var otherExit)) continue;
            if (otherExit.TargetRoomId != null) continue;
            if (other.GetDoorCell(facing) == cell) return (other, facing);
        }

        return null;
    }

    /// <summary>
    /// Links the unexplored door on <paramref name="wall"/> to the facing candidate door; our door takes
    /// the other door's type and lock state. Returns false when there is no candidate.
    /// </summary>
    public bool ConnectDoor(MappedRoom room, Direction wall)
    {
        var candidate = FindConnectCandidate(room, wall);
        if (candidate == null) return false;

        var ours = room.Exits![wall];
        var theirs = candidate.Value.Room.Exits![candidate.Value.Wall];

        ours.ExitType = theirs.ExitType;
        ours.Lockable = theirs.Lockable;
        ours.IsLocked = theirs.IsLocked;
        ours.LockModifier = theirs.LockModifier;
        ours.LockQuality = theirs.LockQuality;
        ours.IsDamaged = theirs.IsDamaged;

        ours.TargetRoomId = candidate.Value.Room.Id;
        theirs.TargetRoomId = room.Id;
        return true;
    }

    /// <summary>A door can be disconnected when it leads to a visited room and is not an entrance.</summary>
    public bool CanDisconnectDoor(MappedRoom room, Direction wall)
    {
        if (room.Exits == null || !room.Exits.TryGetValue(wall, out var exit)) return false;
        if (exit.IsEntrance || exit.TargetRoomId is not > 0) return false;
        return GetRoom(exit.TargetRoomId.Value) != null;
    }

    /// <summary>Makes both ends of the connection unexplored again; type and lock state are kept.</summary>
    public bool DisconnectDoor(MappedRoom room, Direction wall)
    {
        if (!CanDisconnectDoor(room, wall)) return false;

        var ours = room.Exits![wall];
        var other = GetRoom(ours.TargetRoomId!.Value)!;
        var back = other.Exits?.Values.FirstOrDefault(e => e.TargetRoomId == room.Id);

        ours.TargetRoomId = null;
        if (back != null) back.TargetRoomId = null;
        return true;
    }

    public void ChangeRoom(MappedRoom roomFrom, MappedRoom roomTo)
    {
        var from = MappedRooms.FirstOrDefault(r => r.Id == roomFrom.Id);
        var to = MappedRooms.FirstOrDefault(r => r.Id == roomTo.Id);

        if (from != null)
            from.YouAreHere = false;

        if (to != null)
            to.YouAreHere = true;
    }

    /// <summary>
    /// Checks if a unique room has already been used on the specified floor level.
    /// </summary>
    /// <param name="roomId">The Room ID from the database.</param>
    /// <param name="floorLevel">The dungeon floor level.</param>
    /// <returns>True if the unique room has been used on this level; false otherwise.</returns>
    public bool HasUsedUnique(int roomId, int floorLevel)
    {
        if (!_usedUniqueRoomsByLevel.ContainsKey(floorLevel))
            return false;
        return _usedUniqueRoomsByLevel[floorLevel].Contains(roomId);
    }

    /// <summary>
    /// Marks a unique room as used on the specified floor level.
    /// </summary>
    /// <param name="roomId">The Room ID from the database.</param>
    /// <param name="floorLevel">The dungeon floor level.</param>
    public void MarkUniqueUsed(int roomId, int floorLevel)
    {
        if (!_usedUniqueRoomsByLevel.ContainsKey(floorLevel))
            _usedUniqueRoomsByLevel[floorLevel] = new HashSet<int>();
        _usedUniqueRoomsByLevel[floorLevel].Add(roomId);
    }

}
