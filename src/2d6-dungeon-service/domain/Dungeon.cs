using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class Dungeon
{
    /// <summary>
    /// Gets or sets the floor level of the dungeon.
    /// </summary>
    public int FloorLevel { get; set; } = 1;

    [JsonInclude]
    private List<MappedRoom> _mappedRooms;


    /// <summary>
    /// Initializes a new instance of the <see cref="Dungeon"/> class.
    /// </summary>
    public Dungeon()
    {
        _mappedRooms = new List<MappedRoom>();
    }


    /// <summary>
    /// Gets the list of mapped rooms in the dungeon.
    /// </summary>
    private List<MappedRoom> MappedRooms
    {
        get => _mappedRooms;
        set => _mappedRooms = value;
    }

    public MappedRoom GetNewRoom()
    {
        var room = new MappedRoom();
        room.Id = MappedRooms.Count + 1;
        room.IsLobby = false;
        room.State = MappedRoomState.Draft;
        return room;
    }

    /// <summary>
    /// Adds a room to the dungeon.
    /// </summary>
    /// <param name="room">The room to add.</param>
    public void AddRoom(MappedRoom room)
    {
        if(room.Id == 0)
            room.Id = MappedRooms.Count + 1;
        MappedRooms.Add(room);
    }

    /// <summary>
    /// Gets the list of rooms in the dungeon.
    /// </summary>
    /// <returns>The list of mapped rooms.</returns>
    public List<MappedRoom> GetRooms()
    {
        return MappedRooms;
    }

    public MappedRoom? GetRoom(int id)
    {
        return MappedRooms.FirstOrDefault(r => r.Id == id);
    }

    /// <summary>
    /// Starts a new dungeon level based on the dice result.
    /// </summary>
    /// <param name="dResult">The dice result.</param>
    /// <returns>The starting room of the dungeon level.</returns>
    public static MappedRoom StartDungeonLevel(ref DiceResult dResult)
    {
        int area = dResult.PrimaryDice * dResult.SecondaryDice;
        if (area > 12)
        {
            dResult.PrimaryDice = (int)Math.Ceiling((decimal)dResult.PrimaryDice / 2);
            dResult.SecondaryDice = (int)Math.Ceiling((decimal)dResult.SecondaryDice / 2);
            area = dResult.PrimaryDice * dResult.SecondaryDice;
        }
        if (area < 6)
        {
            dResult.PrimaryDice = 3;
            dResult.SecondaryDice = 2;
        }
        var entryRoom = MappedRoom.DraftCurrentRoom(dResult);
        entryRoom.Id = 1;
        entryRoom.ExitsCount = 3;
        entryRoom.Description = "This is the entrance of the dungeon. The room is empty.";
        return entryRoom;
    }


    public void ChangeRoom(MappedRoom roomFrom, MappedRoom roomTo)
    {
        MappedRooms.First(r => r.Id == roomFrom.Id).State = MappedRoomState.Regular;
        MappedRooms.First(r => r.Id == roomTo.Id).State = MappedRoomState.Current;
    }

}
