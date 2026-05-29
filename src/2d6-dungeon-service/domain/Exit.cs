using System.ComponentModel;

namespace c5m._2d6Dungeon;

public class Exit
{
    public Direction Direction { get; set; }
    public int? TargetRoomId { get; set; }
    public string? ExitType { get; set; }
    public bool Lockable { get; set; }
    public bool IsLocked { get; set; }
    public int PositionOnWall { get; set; }
    public int LockModifier { get; set; } = 0;
    public int? LockQuality { get; set; }
    public bool IsDamaged { get; set; } = false;

    public static string GetDirection(Direction value)
    {
        var firstOrDefault = value
            .GetType()
            .GetMember(value.ToString())
            .First();

        var attributes = firstOrDefault.GetCustomAttributes(false);
        return ((DescriptionAttribute)attributes[0]).Description;
    }
    }
