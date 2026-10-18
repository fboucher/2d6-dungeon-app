using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class DoorConnectionTests
{
    // "Left" room at (10,10) 4x4 has an east door at position 2 -> cell (14, 11).
    // "Right" room at (15,10) 3x3 has a west door at position 2 -> cell (14, 11).
    private static (Dungeon dungeon, MappedRoom left, MappedRoom right) Build(int? leftTarget = null, int? rightTarget = null, int rightPos = 2)
    {
        var dungeon = new Dungeon();
        var left = new MappedRoom
        {
            Id = 1, CoordX = 10, CoordY = 10, Width = 4, Height = 4,
            Exits = new Dictionary<Direction, Exit>
            {
                [Direction.East] = new Exit { Direction = Direction.East, PositionOnWall = 2, TargetRoomId = leftTarget, ExitType = "wooden", Lockable = true }
            }
        };
        var right = new MappedRoom
        {
            Id = 2, CoordX = 15, CoordY = 10, Width = 3, Height = 3,
            Exits = new Dictionary<Direction, Exit>
            {
                [Direction.West] = new Exit { Direction = Direction.West, PositionOnWall = rightPos, TargetRoomId = rightTarget, ExitType = "metal", Lockable = true, IsLocked = true }
            }
        };
        dungeon.AddRoom(left);
        dungeon.AddRoom(right);
        return (dungeon, left, right);
    }

    [Fact]
    public void FindConnectCandidate_FacingUnexploredDoorOnSameCell_IsFound()
    {
        var (dungeon, left, right) = Build();

        var candidate = dungeon.FindConnectCandidate(left, Direction.East);

        Assert.NotNull(candidate);
        Assert.Same(right, candidate!.Value.Room);
        Assert.Equal(Direction.West, candidate.Value.Wall);
    }

    [Fact]
    public void FindConnectCandidate_DifferentCell_IsNotFound()
    {
        var (dungeon, left, _) = Build(rightPos: 3);

        Assert.Null(dungeon.FindConnectCandidate(left, Direction.East));
    }

    [Fact]
    public void FindConnectCandidate_PartnerAlreadyConnected_IsNotFound()
    {
        var (dungeon, left, _) = Build(rightTarget: 99);

        Assert.Null(dungeon.FindConnectCandidate(left, Direction.East));
    }

    [Fact]
    public void FindConnectCandidate_OurDoorAlreadyConnected_IsNotFound()
    {
        var (dungeon, left, _) = Build(leftTarget: 2);

        Assert.Null(dungeon.FindConnectCandidate(left, Direction.East));
    }

    [Fact]
    public void ConnectDoor_LinksBothSides_AndCopiesTypeAndLockFromTheOtherDoor()
    {
        var (dungeon, left, right) = Build();

        Assert.True(dungeon.ConnectDoor(left, Direction.East));

        var ours = left.Exits![Direction.East];
        var theirs = right.Exits![Direction.West];
        Assert.Equal(2, ours.TargetRoomId);
        Assert.Equal(1, theirs.TargetRoomId);
        Assert.Equal("metal", ours.ExitType);
        Assert.True(ours.IsLocked);
        Assert.Equal(2, theirs.PositionOnWall);
    }

    [Fact]
    public void ConnectDoor_WithoutCandidate_ChangesNothing()
    {
        var (dungeon, left, _) = Build(rightPos: 3);

        Assert.False(dungeon.ConnectDoor(left, Direction.East));
        Assert.Null(left.Exits![Direction.East].TargetRoomId);
        Assert.Equal("wooden", left.Exits[Direction.East].ExitType);
    }

    [Fact]
    public void DisconnectDoor_ClearsBothSides_KeepingTypeAndLock()
    {
        var (dungeon, left, right) = Build(leftTarget: 2, rightTarget: 1);

        Assert.True(dungeon.DisconnectDoor(left, Direction.East));

        Assert.Null(left.Exits![Direction.East].TargetRoomId);
        Assert.Null(right.Exits![Direction.West].TargetRoomId);
        Assert.Equal("metal", right.Exits[Direction.West].ExitType);
        Assert.True(right.Exits[Direction.West].IsLocked);
    }

    [Fact]
    public void DisconnectDoor_EntranceDoor_IsRefused()
    {
        var (dungeon, left, right) = Build(leftTarget: 2, rightTarget: 1);
        left.Exits![Direction.East].IsEntrance = true;

        Assert.False(dungeon.CanDisconnectDoor(left, Direction.East));
        Assert.False(dungeon.DisconnectDoor(left, Direction.East));
        Assert.Equal(1, right.Exits![Direction.West].TargetRoomId);
    }

    [Fact]
    public void DisconnectDoor_LobbyExit_AndUnexploredDoor_AreRefused()
    {
        var (dungeon, left, _) = Build(leftTarget: -1);
        Assert.False(dungeon.CanDisconnectDoor(left, Direction.East));

        left.Exits![Direction.East].TargetRoomId = null;
        Assert.False(dungeon.CanDisconnectDoor(left, Direction.East));
    }

    [Fact]
    public void SetDungeonEntranceDoor_FlagsTheDoorAsEntrance()
    {
        var room = new MappedRoom { Width = 3, Height = 3 };

        GameTurn.SetDungeonEntranceDoor(room, Direction.South, 4);

        Assert.True(room.Exits![Direction.South].IsEntrance);
    }
}
