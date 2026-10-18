using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class MappedRoomDoorTests
{
    private static MappedRoom RoomWithDoors(params Exit[] doors)
    {
        var room = new MappedRoom { Width = 4, Height = 4, Exits = new Dictionary<Direction, Exit>() };
        foreach (var d in doors) room.Exits[d.Direction] = d;
        room.ExitsCount = doors.Length;
        return room;
    }

    [Fact]
    public void AddDoor_OnFreeWall_CreatesUnexploredDoorAtPositionOne_CopyingTemplate()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.North, ExitType = "wooden", Lockable = true, IsLocked = true, PositionOnWall = 3 });

        var door = room.AddDoor(Direction.East);

        Assert.Null(door.TargetRoomId);
        Assert.Equal(1, door.PositionOnWall);
        Assert.Equal("wooden", door.ExitType);
        Assert.True(door.Lockable);
        Assert.True(door.IsLocked);
        Assert.Equal(2, room.ExitsCount);
        Assert.Same(door, room.Exits![Direction.East]);
    }

    [Fact]
    public void AddDoor_WithoutOtherDoor_FallsBackToExitsTypeUnlocked()
    {
        var room = new MappedRoom { Width = 3, Height = 3, ExitsType = "Metal" };

        var door = room.AddDoor(Direction.South);

        Assert.Equal("Metal", door.ExitType);
        Assert.True(door.Lockable);
        Assert.False(door.IsLocked);
    }

    [Fact]
    public void AddDoor_IgnoresConnectedDoorsAsTemplate()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.South, TargetRoomId = 1, ExitType = "stone_slab" });
        room.ExitsType = "archway";

        var door = room.AddDoor(Direction.North);

        Assert.Equal("archway", door.ExitType);
    }

    [Fact]
    public void AddDoor_OnWallWithDoor_Throws()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.North });

        Assert.False(room.CanAddDoor(Direction.North));
        Assert.Throws<InvalidOperationException>(() => room.AddDoor(Direction.North));
    }

    [Fact]
    public void RemoveDoor_Unexplored_RemovesAndUpdatesCount()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.North }, new Exit { Direction = Direction.East });

        Assert.True(room.RemoveDoor(Direction.North));

        Assert.False(room.Exits!.ContainsKey(Direction.North));
        Assert.Equal(1, room.ExitsCount);
    }

    [Fact]
    public void RemoveDoor_Connected_IsRefused()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.North, TargetRoomId = 2 });

        Assert.False(room.CanRemoveDoor(Direction.North));
        Assert.False(room.RemoveDoor(Direction.North));
        Assert.True(room.Exits!.ContainsKey(Direction.North));
    }

    [Fact]
    public void RemoveDoor_LobbySouth_IsRefused()
    {
        var room = RoomWithDoors(new Exit { Direction = Direction.South });
        room.IsLobby = true;

        Assert.False(room.RemoveDoor(Direction.South));
    }
}
