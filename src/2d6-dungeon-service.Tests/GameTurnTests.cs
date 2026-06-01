using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.domain;
using c5m._2d6Dungeon.Game;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class GameTurnTests
{
    [Fact]
    public async Task ContinueTurn_RollRoomDefinition_ShouldUseMockedD6Service()
    {
        // Arrange
        var mockD6Service = new MockD6Service();
        var gameTurn = new GameTurn
        {
            d6Service = mockD6Service,
            NextAction = ActionType.RollRoomDefinition,
            CurrentRoom = new MappedRoom
            {
                Width = 4,
                Height = 5
            }
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 3,
            SecondaryDice = 4,
            DiceRolled = DiceRolled.TwoD6
        };

        var dungeon = new Dungeon();

        mockD6Service.RollRoomFunc = (roll, size) => Task.FromResult(new Room
        {
            id = 42,
            roll = roll,
            exits = "W E",
            level = 1,
            room_type = "Library",
            is_unique = true,
            encounter = "A quiet goblin reading a book.",
            description = "Smells like old paper."
        });

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, dungeon);

        // Assert
        Assert.NotNull(result.CurrentRoom);
        Assert.Equal("Smells like old paper.", result.CurrentRoom.Description);
        Assert.Equal("A quiet goblin reading a book.", result.CurrentRoom.Encounter);
        Assert.True(result.CurrentRoom.IsUnique);
        Assert.Equal("Library", result.CurrentRoom.RoomType);
    }

    [Fact]
    public async Task ContinueTurn_RolledForRoom_DoubleSix_ShouldSetDrawRoom()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForARoom,
            CurrentRoom = new MappedRoom()
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 6,
            SecondaryDice = 6,
            IsDouble = true,
            IsDoubleSix = true,
            IsOneDiceOne = false
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(ActionType.DrawRoom, result.NextAction);
        Assert.Equal(6, result.CurrentRoom!.Width);
        Assert.Equal(6, result.CurrentRoom.Height);
        Assert.False(result.CurrentRoom.IsCorridor);
    }

    [Fact]
    public async Task ContinueTurn_RolledForRoom_NonSixDouble_ShouldSetDoubleSizedRoom()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForARoom,
            CurrentRoom = new MappedRoom()
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 4,
            SecondaryDice = 4,
            IsDouble = true,
            IsDoubleSix = false,
            IsOneDiceOne = false
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(ActionType.DoubleSizedRoom, result.NextAction);
    }

    [Fact]
    public async Task ContinueTurn_RolledForRoom_OneDiceOne_ShouldSetRollForExitsAndCorridor()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForARoom,
            CurrentRoom = new MappedRoom()
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 1,
            SecondaryDice = 4,
            IsDouble = false,
            IsDoubleSix = false,
            IsOneDiceOne = true
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(ActionType.RollForExits, result.NextAction);
        Assert.Equal(1, result.CurrentRoom!.Width);
        Assert.Equal(4, result.CurrentRoom.Height);
        Assert.True(result.CurrentRoom.IsCorridor);
    }

    [Fact]
    public async Task ContinueTurn_RolledForRoom_Standard_ShouldSetDrawRoom()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForARoom,
            CurrentRoom = new MappedRoom()
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 2,
            SecondaryDice = 5,
            IsDouble = false,
            IsDoubleSix = false,
            IsOneDiceOne = false
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(ActionType.DrawRoom, result.NextAction);
        Assert.Equal(2, result.CurrentRoom!.Width);
        Assert.Equal(5, result.CurrentRoom.Height);
        Assert.False(result.CurrentRoom.IsCorridor);
    }

    [Fact]
    public async Task ContinueTurn_FinishDoubleSizedRoom_ShouldSumDiceAndSetDrawRoom()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.DoubleSizedRoom,
            CurrentRoom = new MappedRoom(),
            LastDiceResult = new DiceResult
            {
                PrimaryDice = 3,
                SecondaryDice = 3,
                IsDouble = true
            }
        };

        var secondRoll = new DiceResult
        {
            PrimaryDice = 4,
            SecondaryDice = 2
        };

        // Act
        var result = await gameTurn.ContinueTurn(secondRoll, new Dungeon());

        // Assert
        Assert.Equal(ActionType.DrawRoom, result.NextAction);
        Assert.Equal(7, result.LastDiceResult!.PrimaryDice);
        Assert.Equal(5, result.LastDiceResult.SecondaryDice);
        Assert.Equal(7, result.CurrentRoom!.Width);
        Assert.Equal(5, result.CurrentRoom.Height);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(5, 2)]
    [InlineData(6, 2)]
    [InlineData(4, 3)]
    public async Task ContinueTurn_RollForExits_ShouldSetCorrectExitCounts(int diceValue, int expectedExits)
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForExits,
            CurrentRoom = new MappedRoom
            {
                IsCorridor = false
            }
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = diceValue
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(expectedExits, result.CurrentRoom!.ExitsCount);
        Assert.Equal(ActionType.Encounter, result.NextAction);
    }

    [Fact]
    public async Task ContinueTurn_RollForExits_Corridor_ShouldTransitionToEndOfTurn()
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForExits,
            CurrentRoom = new MappedRoom
            {
                IsCorridor = true
            }
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = 3
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(ActionType.EndOfTurn, result.NextAction);
    }

    [Theory]
    [InlineData(6, "All doors in this room are locked!")]
    [InlineData(5, "Reinforced doors are locked.")]
    [InlineData(4, "Metal doors are locked.")]
    [InlineData(3, "No doors are locked.")]
    public async Task ContinueTurn_RollForLocks_ShouldSetLockRollAndMessage(int diceValue, string expectedMessage)
    {
        // Arrange
        var gameTurn = new GameTurn
        {
            NextAction = ActionType.RollForLocks,
            CurrentRoom = new MappedRoom()
        };

        var diceResult = new DiceResult
        {
            PrimaryDice = diceValue
        };

        // Act
        var result = await gameTurn.ContinueTurn(diceResult, new Dungeon());

        // Assert
        Assert.Equal(diceValue, result.CurrentRoom!.LockRoll);
        Assert.Equal(ActionType.Encounter, result.NextAction);
        Assert.Equal(expectedMessage, result.Message);
    }
}

public class MockD6Service : ID6Service
{
    public Func<int, string, Task<Room>>? RollRoomFunc { get; set; }

    public Task<Room> RollRoom(int roll, string size)
    {
        if (RollRoomFunc != null)
        {
            return RollRoomFunc(roll, size);
        }
        return Task.FromResult(new Room
        {
            id = 1,
            roll = roll,
            exits = "W E",
            level = 1,
            room_type = "Standard",
            is_unique = false,
            encounter = "Nothing",
            description = "A standard room."
        });
    }

    public Task<int> GetSaveGameCount() => throw new NotImplementedException();
    public Task<AdventureDTOList?> GetAdventurePreviews() => throw new NotImplementedException();
    public Task<Adventure> GetAdventure(int id) => throw new NotImplementedException();
    public Task<Adventure> AdventureSave(Adventure game) => throw new NotImplementedException();
    public Task<bool> AdventureDelete(int id) => throw new NotImplementedException();
    public Task<AdventurerDTOList?> GetAdventurerPreviews() => throw new NotImplementedException();
    public Task<Adventurer> GetAdventurer(int id) => throw new NotImplementedException();
    public Task<bool> SaveAdventurer(Adventurer player) => throw new NotImplementedException();
    public Task<int> AdventurerCreate(Adventurer player) => throw new NotImplementedException();
    public Task<bool> AdventurerDelete(int id) => throw new NotImplementedException();
    public Task<IQueryable<Creature>> GetCreatures() => throw new NotImplementedException();
    public Task<WeaponList> GetWeapons() => throw new NotImplementedException();
    public Task<WeaponManoeuvreList?> GetWeaponManoeuvreList(int weaponId, int level) => throw new NotImplementedException();
    public Task<ArmourPieceList> GetArmourPieces() => throw new NotImplementedException();
    public Task<ArmourPieceList> GetInitialArmourPieces() => throw new NotImplementedException();
    public Task<MagicScrollList> GetMagicScrolls() => throw new NotImplementedException();
    public Task<MagicScrollList> GetInitialMagicScrolls() => throw new NotImplementedException();
    public Task<MagicPotion> GetInitialMagicPotion() => throw new NotImplementedException();
    public Task<List<MagicPotion>> GetMagicPotions() => throw new NotImplementedException();
    public Task<MetaTablesList> GetMetaTables() => throw new NotImplementedException();
    public Task<SimpleTable2D6?> GetTableData(string tableCode) => throw new NotImplementedException();
}
