using System;
using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for DiceResult class, verifying dice rolling mechanics and classification logic.
/// 
/// Note: These tests mock the static RollDie delegate to enable deterministic testing.
/// Each test that modifies RollDie must reset it in a finally block to prevent side effects.
/// </summary>
public class DiceResultTests
{
    private static void ResetRollDie()
    {
        DiceResult.RollDie = () =>
        {
            var die = new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6 };
            return die.OrderBy(x => Guid.NewGuid()).First<int>();
        };
    }

    [Fact]
    public void ToDiceSet_ShouldReturnFormattedString()
    {
        // Arrange
        var diceResult = new DiceResult
        {
            PrimaryDice = 3,
            SecondaryDice = 4
        };

        // Act
        var result = diceResult.ToDiceSet();

        // Assert
        Assert.Equal("3-4", result);
    }

    [Fact]
    public void Roll2Dice_DoubleSix_ShouldClassifyCorrectly()
    {
        try
        {
            // Arrange: Mock RollDie to return 6 every time
            DiceResult.RollDie = () => 6;

            // Act
            var result = DiceResult.Roll2Dice();

            // Assert
            Assert.Equal(6, result.PrimaryDice);
            Assert.Equal(6, result.SecondaryDice);
            Assert.True(result.IsDouble);
            Assert.True(result.IsDoubleSix);
            Assert.False(result.IsOneDiceOne);
        }
        finally
        {
            ResetRollDie();
        }
    }

    [Fact]
    public void Roll2Dice_DoubleNonSix_ShouldClassifyCorrectly()
    {
        try
        {
            // Arrange
            DiceResult.RollDie = () => 3;

            // Act
            var result = DiceResult.Roll2Dice();

            // Assert
            Assert.Equal(3, result.PrimaryDice);
            Assert.Equal(3, result.SecondaryDice);
            Assert.True(result.IsDouble);
            Assert.False(result.IsDoubleSix);
            Assert.False(result.IsOneDiceOne);
        }
        finally
        {
            ResetRollDie();
        }
    }

    [Fact]
    public void Roll2Dice_OneDiceOne_ShouldClassifyCorrectly()
    {
        try
        {
            // Arrange
            var rollCount = 0;
            DiceResult.RollDie = () =>
            {
                rollCount++;
                return rollCount == 1 ? 1 : 4;
            };

            // Act
            var result = DiceResult.Roll2Dice();

            // Assert
            Assert.Equal(1, result.PrimaryDice);
            Assert.Equal(4, result.SecondaryDice);
            Assert.False(result.IsDouble);
            Assert.False(result.IsDoubleSix);
            Assert.True(result.IsOneDiceOne);
        }
        finally
        {
            ResetRollDie();
        }
    }

    [Fact]
    public void Roll2Dice_StandardRoll_ShouldClassifyCorrectly()
    {
        try
        {
            // Arrange
            var rollCount = 0;
            DiceResult.RollDie = () =>
            {
                rollCount++;
                return rollCount == 1 ? 2 : 5;
            };

            // Act
            var result = DiceResult.Roll2Dice();

            // Assert
            Assert.Equal(2, result.PrimaryDice);
            Assert.Equal(5, result.SecondaryDice);
            Assert.False(result.IsDouble);
            Assert.False(result.IsDoubleSix);
            Assert.False(result.IsOneDiceOne);
        }
        finally
        {
            ResetRollDie();
        }
    }

    [Fact]
    public void Roll1Dice_ShouldReturnCorrectValue()
    {
        try
        {
            // Arrange
            DiceResult.RollDie = () => 5;

            // Act
            var result = DiceResult.Roll1Dice();

            // Assert
            Assert.Equal(5, result.PrimaryDice);
            Assert.Equal(0, result.SecondaryDice);
            Assert.Equal(DiceRolled.OneD6, result.DiceRolled);
        }
        finally
        {
            ResetRollDie();
        }
    }
}
