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
