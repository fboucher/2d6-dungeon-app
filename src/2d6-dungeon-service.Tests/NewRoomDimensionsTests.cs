using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for issue #244: a new room must not reach the dungeon as 0 x 0.
///
/// Replays the NewRoomDialog flow with GameTurn: the dimensions roll, then the exits
/// and description rolls (the dialog sets NextAction itself before each of those),
/// then Dungeon.AddRoom as Play.razor does.
/// </summary>
public class NewRoomDimensionsTests
{
    private static DiceResult TwoDice(int primary, int secondary) => new DiceResult
    {
        DiceRolled = DiceRolled.TwoD6,
        PrimaryDice = primary,
        SecondaryDice = secondary,
        IsDouble = primary == secondary,
        IsDoubleSix = primary == 6 && secondary == 6,
        IsOneDiceOne = (primary == 1) != (secondary == 1)
    };

    private static (GameTurn Turn, Dungeon Dungeon) StartNewRoom()
    {
        var dungeon = new Dungeon();
        var gameTurn = new GameTurn
        {
            d6Service = new MockD6Service(),
            CurrentRoom = dungeon.GetNewRoom()
        };
        return (gameTurn, dungeon);
    }

    private static async Task RollExitsAndDescription(GameTurn gameTurn, Dungeon dungeon)
    {
        gameTurn.NextAction = ActionType.RollForExits;
        await gameTurn.ContinueTurn(new DiceResult { DiceRolled = DiceRolled.OneD6, PrimaryDice = 4 }, dungeon);

        gameTurn.NextAction = ActionType.RollRoomDefinition;
        await gameTurn.ContinueTurn(TwoDice(2, 5), dungeon);
    }

    [Fact]
    public async Task NewRoom_DoubleWithoutSecondRoll_CannotBeAddedToDungeon()
    {
        // Arrange
        var (gameTurn, dungeon) = StartNewRoom();

        // Act: roll 3-3, skip the second roll and move on to the next steps
        await gameTurn.ContinueTurn(TwoDice(3, 3), dungeon);
        Assert.Equal(ActionType.DoubleSizedRoom, gameTurn.NextAction);
        await RollExitsAndDescription(gameTurn, dungeon);

        // Assert
        var room = gameTurn.CurrentRoom!;
        Assert.Throws<ArgumentException>(() => dungeon.AddRoom(room));
        Assert.Empty(dungeon.GetRooms());
    }

    [Fact]
    public async Task NewRoom_DoubleWithSecondRoll_HasSummedDimensionsAndIsAdded()
    {
        // Arrange
        var (gameTurn, dungeon) = StartNewRoom();

        // Act: roll 3-3, then 2-4
        await gameTurn.ContinueTurn(TwoDice(3, 3), dungeon);
        await gameTurn.ContinueTurn(TwoDice(2, 4), dungeon);
        await RollExitsAndDescription(gameTurn, dungeon);
        dungeon.AddRoom(gameTurn.CurrentRoom!);

        // Assert
        var room = Assert.Single(dungeon.GetRooms());
        Assert.Equal(5, room.Width);
        Assert.Equal(7, room.Height);
    }

    [Fact]
    public async Task NewRoom_NonDoubleRoll_HasDiceDimensionsAndIsAdded()
    {
        // Arrange
        var (gameTurn, dungeon) = StartNewRoom();

        // Act
        await gameTurn.ContinueTurn(TwoDice(4, 2), dungeon);
        await RollExitsAndDescription(gameTurn, dungeon);
        dungeon.AddRoom(gameTurn.CurrentRoom!);

        // Assert
        var room = Assert.Single(dungeon.GetRooms());
        Assert.Equal(4, room.Width);
        Assert.Equal(2, room.Height);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 3)]
    [InlineData(3, 0)]
    [InlineData(-1, 4)]
    public void AddRoom_WithoutPositiveDimensions_ShouldThrow(int width, int height)
    {
        // Arrange
        var dungeon = new Dungeon();
        var room = new MappedRoom { Width = width, Height = height };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => dungeon.AddRoom(room));
        Assert.Empty(dungeon.GetRooms());
    }
}
