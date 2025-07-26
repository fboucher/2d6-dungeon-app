namespace c5m._2d6Dungeon;

using c5m._2d6Dungeon.domain;
using c5m._2d6Dungeon.Game;

public interface ID6Service
{
    // Adventure
    Task<int> GetSaveGameCount();
    Task<AdventurePreviewList?> GetAdventurePreviews();
    Task<Adventure> GetAdventure(int id);
    Task<Adventure> AdventureSave(Adventure game);
    Task<bool> AdventureDelete(int id);

    // Adventurer
    Task<AdventurerPreviewList?> GetAdventurerPreviews();
    Task<Adventurer> GetAdventurer(int id);
    Task<bool> SaveAdventurer(Adventurer player);
    Task<bool> AdventurerCreate(Adventurer player);
    Task<bool> AdventurerDelete(int id);
    
    // Creature
    Task<IQueryable<Creature>> GetCreatures();


    // Room
    Task<Room> RollRoom(int roll, string size);

    // WeaponManoeuvre
    Task<WeaponList> GetWeapons();
    Task<WeaponManoeuvreList?> GetWeaponManoeuvreList(int weaponId, int level);

     // ArmourPieces
    Task<ArmourPieceList> GetArmourPieces();


    // MagicScroll
    Task<MagicScrollList> GetMagicScrolls();

    // MagicPotion
    Task<MagicPotion> GetInitialMagicPotion();

    // MetaTables
    Task<MetaTablesList> GetMetaTables();

    Task<SimpleTable2D6?> GetTableData(string tableCode);
}
