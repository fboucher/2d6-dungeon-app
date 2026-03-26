using System;

namespace c5m._2d6Dungeon;

public class CombatState
{
    public Game.Adventurer Player { get; set; }
    public Creature? Creature { get; set; }
    public int TurnCounter { get; set; } = 0;
    public List<string> CombatActions { get; set; }

    public CombatState(Game.Adventurer player)
    {
        Player = player;
        CombatActions = new List<string>();
    }
}