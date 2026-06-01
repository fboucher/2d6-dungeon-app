using System;
using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class DungeonTests
{
    [Fact]
    public void StartDungeonLevel_AreaGreaterThan12_ShouldHalfDimensions()
    {
        // Arrange
        var dResult = new DiceResult
        {
            PrimaryDice = 6,
            SecondaryDice = 4 // Area = 24
        };

        // Act
        var (room, dice) = Dungeon.StartDungeonLevel(dResult);

        // Assert
        // Expected: ceiling(6/2) = 3, ceiling(4/2) = 2. Area = 6
        Assert.Equal(3, dice.PrimaryDice);
        Assert.Equal(2, dice.SecondaryDice);
        Assert.Equal(3, room.Width);
        Assert.Equal(2, room.Height);
        Assert.Equal(1, room.Id);
        Assert.Equal(3, room.ExitsCount);
    }

    [Fact]
    public void StartDungeonLevel_AreaLessThan6_ShouldSetTo3x2()
    {
        // Arrange
        var dResult = new DiceResult
        {
            PrimaryDice = 2,
            SecondaryDice = 2 // Area = 4
        };

        // Act
        var (room, dice) = Dungeon.StartDungeonLevel(dResult);

        // Assert
        // Expected: fallback to 3x2
        Assert.Equal(3, dice.PrimaryDice);
        Assert.Equal(2, dice.SecondaryDice);
        Assert.Equal(3, room.Width);
        Assert.Equal(2, room.Height);
    }

    [Fact]
    public void StartDungeonLevel_AreaBetween6And12_ShouldPreserveDimensions()
    {
        // Arrange
        var dResult = new DiceResult
        {
            PrimaryDice = 3,
            SecondaryDice = 3 // Area = 9
        };

        // Act
        var (room, dice) = Dungeon.StartDungeonLevel(dResult);

        // Assert
        // Expected: no change
        Assert.Equal(3, dice.PrimaryDice);
        Assert.Equal(3, dice.SecondaryDice);
        Assert.Equal(3, room.Width);
        Assert.Equal(3, room.Height);
    }
}
