using System;
using System.Collections.Generic;
using System.Text.Json;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for Adventurer class constructors and initialization logic.
/// 
/// Verifies that:
/// - Default constructor initializes all properties with appropriate defaults
/// - Named constructor preserves name while using default values for other properties
/// - AdventurerDTO constructors properly serialize/deserialize adventurer state
/// - Full serialization roundtrips maintain all character data (stats, inventory, etc.)
/// </summary>
public class AdventurerTests
{
    [Fact]
    public void Constructor_Default_ShouldInitializeDefaultValues()
    {
        // Act
        var adventurer = new Adventurer();

        // Assert
        Assert.Equal(string.Empty, adventurer.Name);
        Assert.Equal(1, adventurer.Level);
        Assert.Equal(0, adventurer.XP);
        Assert.Equal(2, adventurer.Shift);
        Assert.Equal(1, adventurer.Discipline);
        Assert.Equal(0, adventurer.Precision);
        Assert.Equal(10, adventurer.HealthPoints);
        Assert.Equal(3, adventurer.Rations);
        Assert.NotNull(adventurer.WeaponManoeuvres);
        Assert.NotNull(adventurer.ArmourPieces);
        Assert.NotNull(adventurer.MagicScrolls);
        Assert.NotNull(adventurer.MagicPotions);
        Assert.NotNull(adventurer.Coins);
        Assert.NotNull(adventurer.LargeAndHeavyItems);
        Assert.NotNull(adventurer.NarrativeMoments);
        Assert.NotNull(adventurer.FavorOfTheGods);
    }

    [Fact]
    public void Constructor_WithName_ShouldInitializeNameAndDefaultValues()
    {
        // Act
        var adventurer = new Adventurer("Valiant Hero");

        // Assert
        Assert.Equal("Valiant Hero", adventurer.Name);
        Assert.Equal(1, adventurer.Level);
        Assert.Equal(0, adventurer.XP);
        Assert.Equal(2, adventurer.Shift);
        Assert.Equal(1, adventurer.Discipline);
        Assert.Equal(0, adventurer.Precision);
        Assert.Equal(10, adventurer.HealthPoints);
        Assert.Equal(3, adventurer.Rations);
        Assert.NotNull(adventurer.WeaponManoeuvres);
    }

    [Fact]
    public void Constructor_WithEmptyPreviewDTO_ShouldInitializeDefaultValues()
    {
        // Arrange
        var preview = new AdventurerDTO
        {
            id = 42,
            name = "Preview Name",
            xp = 50,
            level = 2,
            serialiazedObj = string.Empty
        };

        // Act
        var adventurer = new Adventurer(preview);

        // Assert
        Assert.Equal(42, adventurer.Id);
        Assert.Equal("Preview Name", adventurer.Name);
        Assert.Equal(50, adventurer.XP);
        Assert.Equal(2, adventurer.Level);
        Assert.Equal(2, adventurer.Shift);
        Assert.Equal(10, adventurer.HealthPoints);
        Assert.Equal(3, adventurer.Rations);
    }

    [Fact]
    public void Constructor_WithSerializedPreviewDTO_ShouldDecodeAndInitializeCorrectly()
    {
        // Arrange
        var original = new Adventurer("Legendary Warrior")
        {
            Id = 99,
            Level = 5,
            XP = 1200,
            Shift = 4,
            Discipline = 3,
            Precision = 2,
            HealthPoints = 15,
            Rations = 1,
            Coins = new Coins { GoldCoins = 10, SilverCoins = 5 }
        };

        var preview = new AdventurerDTO(original);

        // Act
        var adventurer = new Adventurer(preview);

        // Assert
        Assert.Equal(99, adventurer.Id);
        Assert.Equal("Legendary Warrior", adventurer.Name);
        Assert.Equal(5, adventurer.Level);
        Assert.Equal(1200, adventurer.XP);
        Assert.Equal(4, adventurer.Shift);
        Assert.Equal(3, adventurer.Discipline);
        Assert.Equal(2, adventurer.Precision);
        Assert.Equal(15, adventurer.HealthPoints);
        Assert.Equal(1, adventurer.Rations);
        Assert.Equal(10, adventurer.Coins.GoldCoins);
        Assert.Equal(5, adventurer.Coins.SilverCoins);
    }

    [Fact]
    public void Constructor_Default_ShouldStartAtMaxHealthPoints()
    {
        var adventurer = new Adventurer();

        Assert.Equal(10, adventurer.MaxHealthPoints);
        Assert.Equal(adventurer.MaxHealthPoints, adventurer.HealthPoints);
    }

    [Fact]
    public void Constructor_WithSerializedPreviewDTO_ShouldPreserveMaxHealthPoints()
    {
        var original = new Adventurer("Tough One") { MaxHealthPoints = 18, HealthPoints = 7 };

        var adventurer = new Adventurer(new AdventurerDTO(original));

        Assert.Equal(18, adventurer.MaxHealthPoints);
        Assert.Equal(7, adventurer.HealthPoints);
    }

    [Theory]
    [InlineData(8, 10)]
    [InlineData(14, 14)]
    public void Constructor_WithLegacySerializedDTO_ShouldDefaultMaxHealthPoints(int healthPoints, int expectedMax)
    {
        // Adventurers saved before MaxHealthPoints existed have no such field in their JSON
        var json = JsonSerializer.Serialize(new { Name = "Old Save", HealthPoints = healthPoints });
        var preview = new AdventurerDTO
        {
            serialiazedObj = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json))
        };

        var adventurer = new Adventurer(preview);

        Assert.Equal(expectedMax, adventurer.MaxHealthPoints);
        Assert.Equal(healthPoints, adventurer.HealthPoints);
    }

    [Fact]
    public void Heal_WhenAmountExceedsMissingHealth_ShouldCapAtMaxHealthPoints()
    {
        var adventurer = new Adventurer { HealthPoints = 8 };

        var healed = adventurer.Heal(4);

        Assert.Equal(10, adventurer.HealthPoints);
        Assert.Equal(2, healed);
    }

    [Fact]
    public void Heal_WhenAmountFitsBelowMax_ShouldHealFully()
    {
        var adventurer = new Adventurer { HealthPoints = 3 };

        var healed = adventurer.Heal(4);

        Assert.Equal(7, adventurer.HealthPoints);
        Assert.Equal(4, healed);
    }

    [Fact]
    public void Heal_WhenAlreadyAtMax_ShouldNotIncreaseHealthPoints()
    {
        var adventurer = new Adventurer();

        var healed = adventurer.Heal(10);

        Assert.Equal(10, adventurer.HealthPoints);
        Assert.Equal(0, healed);
    }

    [Fact]
    public void Heal_WhenAboveMax_ShouldNotReduceHealthPoints()
    {
        var adventurer = new Adventurer { HealthPoints = 25 };

        var healed = adventurer.Heal(5);

        Assert.Equal(25, adventurer.HealthPoints);
        Assert.Equal(0, healed);
    }

    [Fact]
    public void Heal_WithHealingPotion_ShouldCapAtMaxHealthPoints()
    {
        var adventurer = new Adventurer { HealthPoints = 4 };
        var potion = new MagicPotion { PotionType = "HEALING", Modifier = "Heal up to 10 Health Points" };

        adventurer.Heal(potion.HealAmount);

        Assert.Equal(adventurer.MaxHealthPoints, adventurer.HealthPoints);
    }

    [Theory]
    [InlineData("Heal up to 10 Health Points", 10)]
    [InlineData("Heal up to 60 Health Points", 60)]
    [InlineData("Gain 15 Health Points (can exceed baseline level)", 0)]
    [InlineData("+2 Shift for 1 whole combat", 0)]
    [InlineData(null, 0)]
    public void MagicPotion_HealAmount_ShouldParseModifier(string? modifier, int expected)
    {
        var potion = new MagicPotion { PotionType = "ANY", Modifier = modifier };

        Assert.Equal(expected, potion.HealAmount);
    }
}
