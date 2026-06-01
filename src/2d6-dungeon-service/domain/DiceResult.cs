namespace c5m._2d6Dungeon;

public class DiceResult
{
    public DiceRolled DiceRolled { get; set; }
    public int PrimaryDice { get; set; }
    public int SecondaryDice { get; set; }
    public bool IsOneDiceOne { get; set; } = false;
    public bool IsDouble { get; set; } = false;
    public bool IsDoubleSix { get; set; } = false;



    public static Func<int> RollDie { get; set; } = () =>
    {
        var die = new List<int> { 1,2,3,4,5,6 };
        return die.OrderBy(x => Guid.NewGuid()).First<int>(); 
    };

    private static int RollDice()
    {
        return RollDie();
    }
    public static DiceResult Roll2Dice ()
    {
        var result = new DiceResult();
        result.DiceRolled = DiceRolled.TwoD6;
        result.PrimaryDice = RollDice();
        result.SecondaryDice = RollDice();
        result.IsOneDiceOne = ((result.PrimaryDice == 1 && result.SecondaryDice != 1) || (result.PrimaryDice != 1 && result.SecondaryDice == 1)) ? true: false;
        result.IsDouble = (result.PrimaryDice == result.SecondaryDice) ? true: false;
        result.IsDoubleSix = (result.PrimaryDice == 6 && result.SecondaryDice == 6) ? true: false;
        return result;
    }

    public static DiceResult Roll1Dice()
    {
        var result = new DiceResult();
        result.DiceRolled = DiceRolled.OneD6;
        result.PrimaryDice = RollDice();
        result.SecondaryDice = 0;
        return result;
    }

    public string ToDiceSet()
    {
        return $"{PrimaryDice}-{SecondaryDice}";
    }


}

public enum DiceRolled
{
    OneD6 = 1,
    TwoD6 = 2
}


