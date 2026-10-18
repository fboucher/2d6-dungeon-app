using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class DoorValidationTests
{
    // Room 1 at (10,10) 4x4 with a connected east door at position 2 -> cell (14, 11).
    private static (Dungeon dungeon, MappedRoom room, MappedRoom neighbour) Build(int neighbourPos)
    {
        var dungeon = new Dungeon();
        var room = new MappedRoom
        {
            Id = 1, CoordX = 10, CoordY = 10, Width = 4, Height = 4,
            Exits = new Dictionary<Direction, Exit>
            {
                [Direction.East] = new Exit { Direction = Direction.East, PositionOnWall = 2, TargetRoomId = 2 }
            }
        };
        // Neighbour west wall is at x = CoordX - 1 = 14 -> CoordX 15; door cell y = CoordY - 1 + pos.
        var neighbour = new MappedRoom
        {
            Id = 2, CoordX = 15, CoordY = 10, Width = 3, Height = 3,
            Exits = new Dictionary<Direction, Exit>
            {
                [Direction.West] = new Exit { Direction = Direction.West, PositionOnWall = neighbourPos, TargetRoomId = 1 }
            }
        };
        dungeon.AddRoom(room);
        dungeon.AddRoom(neighbour);
        return (dungeon, room, neighbour);
    }

    [Fact]
    public void ValidateDoors_AlignedConnectedDoors_HasNoIssues()
    {
        var (dungeon, room, _) = Build(neighbourPos: 2);

        Assert.Empty(dungeon.ValidateDoors(room));
    }

    [Fact]
    public void ValidateDoors_MisalignedConnectedDoor_ReportsIssueNamingNeighbour()
    {
        var (dungeon, room, _) = Build(neighbourPos: 3);

        var issue = Assert.Single(dungeon.ValidateDoors(room));
        Assert.Equal(Direction.East, issue.Wall);
        Assert.Contains("Room 2", issue.Message);
    }

    [Fact]
    public void ValidateDoors_PositionBeyondWall_ReportsIssue()
    {
        var (dungeon, room, _) = Build(neighbourPos: 2);
        room.Exits![Direction.East].PositionOnWall = 5;

        var issue = Assert.Single(dungeon.ValidateDoors(room));
        Assert.Equal(Direction.East, issue.Wall);
    }

    [Fact]
    public void ValidateDoors_UnexploredDoorInRange_IsIgnoredForAlignment()
    {
        var (dungeon, room, _) = Build(neighbourPos: 2);
        room.Exits![Direction.North] = new Exit { Direction = Direction.North, PositionOnWall = 4 };

        Assert.Empty(dungeon.ValidateDoors(room));
    }

    [Fact]
    public void ValidateDoors_DoorToExitOrMissingRoom_IsIgnoredForAlignment()
    {
        var (dungeon, room, _) = Build(neighbourPos: 2);
        room.Exits![Direction.South] = new Exit { Direction = Direction.South, PositionOnWall = 1, TargetRoomId = -1 };
        room.Exits[Direction.North] = new Exit { Direction = Direction.North, PositionOnWall = 1, TargetRoomId = 99 };

        Assert.Empty(dungeon.ValidateDoors(room));
    }
}
