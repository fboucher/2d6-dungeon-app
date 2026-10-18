using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Issue #245: the entrance door sits in the middle of the wall it is on, and the new room
/// is placed so that door lands on the grid cell of the door it was entered through.
/// </summary>
public class EntranceDoorPositionTests
{
    private static MappedRoom NewRoom(int width, int height) =>
        new MappedRoom { Id = 2, Width = width, Height = height };

    // Bad scenario from the issue: a 6x2 room entered from the West used ceil(Width/2) = 3
    // on a wall that is only 2 long. This failed before the fix.
    [Theory]
    [InlineData(Direction.West)]
    [InlineData(Direction.East)]
    public void SetDungeonEntranceDoor_WideShortRoomOnSideWall_PositionIsWithinHeight(Direction wall)
    {
        var room = NewRoom(6, 2);

        GameTurn.SetDungeonEntranceDoor(room, wall, 1);

        var position = room.Exits![wall].PositionOnWall;
        Assert.InRange(position, 1, room.Height);
        Assert.Equal(1, position);
    }

    public static TheoryData<Direction, int, int> WallsAndSizes()
    {
        var data = new TheoryData<Direction, int, int>();
        var sizes = new (int W, int H)[] { (1, 1), (2, 2), (3, 3), (6, 2), (2, 6), (5, 3), (3, 5), (4, 1), (1, 4) };
        foreach (var wall in new[] { Direction.North, Direction.East, Direction.South, Direction.West })
            foreach (var (w, h) in sizes)
                data.Add(wall, w, h);
        return data;
    }

    [Theory]
    [MemberData(nameof(WallsAndSizes))]
    public void SetDungeonEntranceDoor_IsInTheMiddleOfTheEntranceWall(Direction wall, int width, int height)
    {
        var room = NewRoom(width, height);

        GameTurn.SetDungeonEntranceDoor(room, wall, 1);

        var wallLength = wall == Direction.North || wall == Direction.South ? width : height;
        var position = room.Exits![wall].PositionOnWall;
        Assert.Equal((int)Math.Ceiling(wallLength / 2.0), position);
        Assert.InRange(position, 1, wallLength);
    }

    [Theory]
    [MemberData(nameof(WallsAndSizes))]
    public void GetOriginForDoorCell_PutsTheEntranceOnTheSourceDoorCell(Direction wall, int width, int height)
    {
        // Source room whose door leads into the new room's entrance wall.
        var exitWall = GameTurn.GetOppositeDirection(wall);
        var source = new MappedRoom
        {
            Id = 1, CoordX = 20, CoordY = 20, Width = 4, Height = 4,
            Exits = new Dictionary<Direction, Exit>
            {
                [exitWall] = new Exit { Direction = exitWall, PositionOnWall = 2, TargetRoomId = 2 }
            }
        };
        var (doorX, doorY) = source.GetDoorCell(exitWall);

        var room = NewRoom(width, height);
        GameTurn.SetDungeonEntranceDoor(room, wall, source.Id);
        (room.CoordX, room.CoordY) = room.GetOriginForDoorCell(wall, doorX, doorY);

        Assert.Equal((doorX, doorY), room.GetDoorCell(wall));

        var dungeon = new Dungeon();
        dungeon.AddRoom(source);
        dungeon.AddRoom(room);
        Assert.Empty(dungeon.ValidateDoors(room));
    }
}
