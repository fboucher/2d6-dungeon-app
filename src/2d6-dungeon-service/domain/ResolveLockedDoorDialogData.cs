namespace c5m._2d6Dungeon;

public class ResolveLockedDoorDialogData
{
    public required Exit Exit { get; set; }
    public required Adventure Adventure { get; set; }
    public required Direction Direction { get; set; }
    public bool CombatInitiated { get; set; } = false;
    public bool Unlocked { get; set; } = false;
}
