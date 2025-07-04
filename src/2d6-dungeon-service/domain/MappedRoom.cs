namespace c5m._2d6Dungeon;

public class MappedRoom
{
    public int Id { get; set; }
    public bool IsCorridor { get; set; }
    public int ExitsCount { get; set; }
    public Dictionary<Direction, Exit>? Exits { get; set; }
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool IsLobby { get; set; } = false;
    public string? Description { get; set; }
    public MappedRoomState State { get; set; } = MappedRoomState.Current;


    public static MappedRoom DraftCurrentRoom(DiceResult dResult)
    {
        return new MappedRoom
        {
            Width = dResult.PrimaryDice,
            Height = dResult.SecondaryDice,
            IsCorridor = dResult.IsOneDiceOne
        };
    }

}

public enum MappedRoomState
{
    Regular,
    Draft,
    Current
}

