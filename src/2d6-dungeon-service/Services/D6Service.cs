using System.Net.Http.Json;
using System.Text.Json;
using Bogus;
using Bogus.DataSets;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.domain;
using c5m._2d6Dungeon.Game;
using Microsoft.Extensions.Logging;

namespace c5m._2d6Dungeon;

public class D6Service
{

    #region == Sercice =====
    private readonly HttpClient httpClient;
    private readonly ILogger<D6Service> logger;
    private readonly JsonSerializerOptions options;
    public D6Service(HttpClient httpClient, ILogger<D6Service> logger)
    {
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        this.httpClient = httpClient;
        this.logger = logger;
    }
    #endregion

    #region == Adventure =====

    public async Task<int> GetSaveGameCount()
    {
        var games = await GetAdventurePreviews();
        return games?.value?.Count() ?? 0;
    }

    public async Task<AdventurePreviewList?> GetAdventurePreviews()
    {
        return await httpClient.GetFromJsonAsync<AdventurePreviewList?>("api/adventure?$select=id,adventurer_name,level,last_saved_datetime");
    }

    public async Task<Adventure> GetAdventure(int id)
    {
        var result = await httpClient.GetFromJsonAsync<AdventurePreviewList>($"api/adventure/id/{id.ToString()}");
        var adventurePrev = result!.value.First<AdventurePreview>();

        Adventure loadedGame = new Adventure(adventurePrev);
        if(loadedGame.Id == 0)
            loadedGame.Id = id;

        return loadedGame;
    }

    private async Task<int> AdventureCreate(Adventure game)
    {
        AdventurePreview draftSavedGame = new AdventurePreview();
        draftSavedGame.adventurer_name = game.Adventurer.Name;
        draftSavedGame.last_saved_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        var response = await httpClient.PostAsJsonAsync<AdventurePreview>($"api/adventure", draftSavedGame);
        var status = response.EnsureSuccessStatusCode();

        if (!status.IsSuccessStatusCode)
            throw new Exception("Problem Saving the Game");
        
        var returnedList = await response.Content.ReadFromJsonAsync<AdventurePreviewList>();
        return returnedList!.value.First<AdventurePreview>().id;
    }

    public async Task<Adventure> AdventureSave(Adventure game)
    {
        if(game.Id == 0){
            game.Id = await AdventureCreate(game);
        }

        var serializedGame = new AdventurePreview(game);
        serializedGame.last_saved_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        var response = await httpClient.PutAsJsonAsync<AdventurePreview>($"api/adventure/id/{game.Id.ToString()}", serializedGame);
        var status = response.EnsureSuccessStatusCode();

        if (!status.IsSuccessStatusCode)
            Console.WriteLine($"Problem while saving: code {status.StatusCode}");
        
        return game;
    }
    
    public async Task<bool> AdventureDelete(int id)
    {
        var response = await httpClient.DeleteAsync($"api/adventure/id/{id.ToString()}");
        var status = response.EnsureSuccessStatusCode();

        if (status.IsSuccessStatusCode)
            return true;
        return false;
    }

    #endregion

    

    #region == Adventurer =====
    public async Task<Adventurer> GetAdventurer(int id)
    {
        var result = await httpClient.GetFromJsonAsync<AdventurerPreviewList>($"api/adventurer/id/{id.ToString()}");
        var adventurerPrev = result!.value.First<AdventurerPreview>();

        return new Adventurer(adventurerPrev);
    }

    public async Task<AdventurerPreviewList?> GetAdventurerPreviews()
    {
        return await httpClient.GetFromJsonAsync<AdventurerPreviewList?>("api/adventurer?$select=id,name,xp,level");
    }

    public async Task<bool> SaveAdventurer(Adventurer player)
    {
        var dbPlayer = new AdventurerPreview(player);

        var response = await httpClient.PutAsJsonAsync<AdventurerPreview>($"api/adventurer/id/{player.Id.ToString()}", dbPlayer);
        var status = response.EnsureSuccessStatusCode();

        if (status.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> AdventurerCreate(Adventurer player)
    {
        var dbPlayer = new AdventurerPreview(player);

        var response = await httpClient.PostAsJsonAsync<AdventurerPreview>($"api/adventurer", dbPlayer);
        var status = response.EnsureSuccessStatusCode();

        if (status.IsSuccessStatusCode)
            return true;
        return false;
    }

    #endregion

    

    #region == Adventurer Options =====

    //public async Task<List<Weapon>> GetWeapons(){}


    #endregion
    
    

    #region == Creature Options =====

    public async Task<IQueryable<Creature>> GetCreatures(){

        var result = await httpClient.GetFromJsonAsync<CreatureList>("api/creature", options);
        return result!.value.AsQueryable();
    }


    #endregion
    

    
    #region == Rooms =====

    public async Task<Room> GetRoom(int id)
    {
        var result = await httpClient.GetFromJsonAsync<RoomList>($"api/room/id/{id.ToString()}");
        var room = result!.value.First<Room>();

        return room;
    }

    public async Task<Room> RollRoom(int roll, string size)
    {
        // ex: http://localhost:5000/api/room/?$filter=roll eq 2 and size eq 'small'
        var result = await httpClient.GetFromJsonAsync<RoomList>($"api/room/?$filter=roll eq {roll.ToString()} and size eq '{size}'");
        var room = result!.value.First<Room>();

        return room;
    }

    #endregion


    
    #region == WeaponManoeuvre =====

    public async Task<WeaponList> GetWeapons()
    {
        logger.LogTrace(@"httpClient URL: {0}", httpClient.BaseAddress);
        var result = await httpClient.GetFromJsonAsync<WeaponList>("api/weapon", options);
        // var weapons = result.value.GroupBy(w => new {w.weapon})
        //                 .Select(w => w.First().weapon)
        //                 .ToList();
        // return weapons;
        return result ?? new WeaponList();
    }


    public async Task<WeaponManoeuvreList?> GetWeaponManoeuvreList(int weaponId, int level)
    {
        var q = $"api/weapon_manoeuvre?$filter=level eq {level} and weapon_id eq {weaponId}";
        return await httpClient.GetFromJsonAsync<WeaponManoeuvreList>(q, options);
    }

    #endregion



    #region == ArmourPiece =====

    public async Task<ArmourPieceList> GetArmourPieces()
    {
        var result = await httpClient.GetFromJsonAsync<ArmourPieceList>("api/armour_piece", options);
        return result ?? new ArmourPieceList();
    }

    #endregion


    
    #region == MagicScroll =====

    public async Task<MagicScrollList> GetMagicScrolls()
    {
        var result = await httpClient.GetFromJsonAsync<MagicScrollList>("api/magic_scroll", options);
        return result ?? new MagicScrollList();
    }

    #endregion

    

    #region == MagicPotion =====


    public async Task<MagicPotion> GetInitialMagicPotion()
    {
        var q = $"api/magic_potion?$filter=potion_type eq 'HEALING'";
        var result = await httpClient.GetFromJsonAsync<MagicPotionlList>(q);
        return result!.value.First<MagicPotion>();
    }

    #endregion


    #region == Meta Tables =====


    public async Task<MetaTablesList> GetMetaTables()
    {
        var result = await httpClient.GetFromJsonAsync<MetaTablesList>("api/meta_table", options);
        return result ?? new MetaTablesList();
    }

    public async Task<SimpleTable2D6?> GetTableData(string tableCode)
    {
        try
        {
            string baseDirectory = AppContext.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "data");
            
            if (!Directory.Exists(dataDirectory))
            {
                string assemblyLocation = Path.GetDirectoryName(typeof(D6Service).Assembly.Location) ?? baseDirectory;
                dataDirectory = Path.Combine(assemblyLocation, "data");
                
                if (!Directory.Exists(dataDirectory))
                {
                    string parentDir = Directory.GetParent(assemblyLocation)?.FullName ?? assemblyLocation;
                    dataDirectory = Path.Combine(parentDir, "data");
                }
            }
            
            string filePath = Path.Combine(dataDirectory, $"{tableCode}.csv");
            
            logger.LogInformation($"Looking for table data at: {filePath}");
            
            if (!File.Exists(filePath))
            {
                logger.LogError($"Table CSV file not found: {filePath}");
                return null;
            }
            
            var lines = await File.ReadAllLinesAsync(filePath);
            
            if (lines.Length == 0)
            {
                return null;
            }
            
            var headers = lines[0].Split('|').Select(h => h.Trim()).ToArray();
            
            var rows = new List<SimpleTable2D6Row>();
            for (int i = 1; i < lines.Length; i++)
            {
                var cols = lines[i].Split('|');
                rows.Add(new SimpleTable2D6Row{
                                                Roll = cols[0], 
                                                Description = cols[1].Trim('"')
                                            });
            }
            
            return new SimpleTable2D6 
            { 
                TableCode = tableCode,
                Headers = headers,
                Rows = rows
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error reading table {tableCode}");
            return null;
        }
    }

    #endregion
}
