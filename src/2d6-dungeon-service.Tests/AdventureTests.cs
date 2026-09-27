using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for Adventure and MappedRoom class, verifying room display names and journal entry formatting.
/// </summary>
public class AdventureTests
{
    [Fact]
    public void AppendRoomEntryJournal_WhenRoomIsLobby_LogsLobby()
    {
        // Arrange
        var adventure = new Adventure();
        var lobby = new MappedRoom
        {
            Id = 1,
            IsLobby = true
        };

        // Act
        adventure.AppendRoomEntryJournal(lobby);

        // Assert
        Assert.EndsWith("Entered room: Lobby", adventure.Journal);
    }

    [Fact]
    public void AppendRoomEntryJournal_WhenRoomIsCorridor_LogsCorridorWithId()
    {
        // Arrange
        var adventure = new Adventure();
        var corridor = new MappedRoom
        {
            Id = 4,
            IsCorridor = true
        };

        // Act
        adventure.AppendRoomEntryJournal(corridor);

        // Assert
        Assert.EndsWith("Entered room: Corridor 4", adventure.Journal);
    }

    [Fact]
    public void AppendRoomEntryJournal_WhenRoomHasRoomType_LogsRoomType()
    {
        // Arrange
        var adventure = new Adventure();
        var room = new MappedRoom
        {
            Id = 2,
            RoomType = "Armory"
        };

        // Act
        adventure.AppendRoomEntryJournal(room);

        // Assert
        Assert.EndsWith("Entered room: Armory", adventure.Journal);
    }

    [Fact]
    public void AppendRoomEntryJournal_WhenRoomHasNoRoomType_LogsRoomWithId()
    {
        // Arrange
        var adventure = new Adventure();
        var room = new MappedRoom
        {
            Id = 5,
            RoomType = null
        };

        // Act
        adventure.AppendRoomEntryJournal(room);

        // Assert
        Assert.EndsWith("Entered room: Room 5", adventure.Journal);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void AppendRoomEntryJournal_WhenRoomHasEmptyOrWhitespaceRoomType_LogsRoomWithId(string emptyType)
    {
        // Arrange
        var adventure = new Adventure();
        var room = new MappedRoom
        {
            Id = 7,
            RoomType = emptyType
        };

        // Act
        adventure.AppendRoomEntryJournal(room);

        // Assert
        Assert.EndsWith("Entered room: Room 7", adventure.Journal);
    }

    [Fact]
    public void DisplayName_WhenLobby_ReturnsLobbyEvenIfRoomTypeSet()
    {
        // Arrange
        var lobby = new MappedRoom
        {
            Id = 1,
            IsLobby = true,
            RoomType = "Entrance Hall",
            IsCorridor = true
        };

        // Assert
        Assert.Equal("Lobby", lobby.DisplayName);
    }

    [Fact]
    public void DisplayName_WhenCorridor_ReturnsCorridorWithIdEvenIfRoomTypeSet()
    {
        // Arrange
        var corridor = new MappedRoom
        {
            Id = 3,
            IsCorridor = true,
            RoomType = "Hallway"
        };

        // Assert
        Assert.Equal("Corridor 3", corridor.DisplayName);
    }

    [Fact]
    public void FormatRoomEntryJournal_FormatsExpectedString()
    {
        // Arrange
        var corridor = new MappedRoom
        {
            Id = 2,
            IsCorridor = true
        };

        // Act
        var formatted = Adventure.FormatRoomEntryJournal(corridor);

        // Assert
        Assert.Equal("Entered room: Corridor 2", formatted);
    }
}
