using System;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for CombatState.GetShiftPointsFor, which resolves the shift allowance
/// belonging to whichever fighter currently holds the turn.
/// </summary>
public class CombatStateTests
{
    private static Adventurer CreateAdventurer(int shift)
    {
        return new Adventurer
        {
            Shift = shift
        };
    }

    private static Creature CreateCreature(int? shiftPoints)
    {
        return new Creature
        {
            id = 1,
            name = "BLACKSMITH",
            level = 1,
            creature_type = "Humanoid",
            health_points = 6,
            shift_points = shiftPoints
        };
    }

    [Fact]
    public void GetShiftPointsFor_AdventurerTurn_ReturnsAdventurerShift()
    {
        // Arrange
        var combatState = new CombatState(CreateAdventurer(shift: 3))
        {
            Creature = CreateCreature(shiftPoints: 1)
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Adventurer);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetShiftPointsFor_CreatureTurn_ReturnsCreatureShiftPoints()
    {
        // Arrange
        var combatState = new CombatState(CreateAdventurer(shift: 3))
        {
            Creature = CreateCreature(shiftPoints: 1)
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Creature);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetShiftPointsFor_CreatureWithMoreShiftThanAdventurer_ReturnsCreatureShiftPoints()
    {
        // Arrange: guards against the adventurer's pool leaking into the creature's turn
        var combatState = new CombatState(CreateAdventurer(shift: 1))
        {
            Creature = CreateCreature(shiftPoints: 4)
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Creature);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void GetShiftPointsFor_NullShiftPoints_ReturnsZero()
    {
        // Arrange: shift_points is a nullable int in the domain model
        var combatState = new CombatState(CreateAdventurer(shift: 2))
        {
            Creature = CreateCreature(shiftPoints: null)
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Creature);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetShiftPointsFor_CreatureTurnWithNoCreature_ReturnsZero()
    {
        // Arrange
        var combatState = new CombatState(CreateAdventurer(shift: 2))
        {
            Creature = null
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Creature);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetShiftPointsFor_NoCurrentFighter_ReturnsAdventurerShift()
    {
        // Arrange: initiative has not been picked yet
        var combatState = new CombatState(CreateAdventurer(shift: 2))
        {
            Creature = CreateCreature(shiftPoints: 1)
        };

        // Act
        var result = combatState.GetShiftPointsFor(null);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void GetShiftPointsFor_ToggleBetweenFighters_ReturnsEachOwnPool()
    {
        // Arrange
        var combatState = new CombatState(CreateAdventurer(shift: 2))
        {
            Creature = CreateCreature(shiftPoints: 1)
        };

        // Act
        var adventurerFirst = combatState.GetShiftPointsFor(FighterType.Adventurer);
        var creatureSecond = combatState.GetShiftPointsFor(FighterType.Creature);
        var adventurerAgain = combatState.GetShiftPointsFor(FighterType.Adventurer);

        // Assert
        Assert.Equal(2, adventurerFirst);
        Assert.Equal(1, creatureSecond);
        Assert.Equal(2, adventurerAgain);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(6)]
    public void GetShiftPointsFor_CreatureTurn_ReturnsExactCreatureValue(int shiftPoints)
    {
        // Arrange
        var combatState = new CombatState(CreateAdventurer(shift: 2))
        {
            Creature = CreateCreature(shiftPoints)
        };

        // Act
        var result = combatState.GetShiftPointsFor(FighterType.Creature);

        // Assert
        Assert.Equal(shiftPoints, result);
    }
}
