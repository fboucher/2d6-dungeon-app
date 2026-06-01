using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class DiceResultTests
{
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
}
