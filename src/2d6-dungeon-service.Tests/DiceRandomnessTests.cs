using System.Linq;
using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class DiceRandomnessTests
{
    private const int Rolls = 60000;

    [Fact]
    public void DefaultRollDie_IsUniformOverOneToSix()
    {
        var counts = new int[7];
        for (int i = 0; i < Rolls; i++) counts[DiceResult.DefaultRollDie()]++;

        Assert.Equal(0, counts[0]);
        // Expected 10000 per face; sd is about 91, so +/-500 is more than 5 sd.
        for (int face = 1; face <= 6; face++)
            Assert.InRange(counts[face], 9500, 10500);
    }

    [Fact]
    public void DefaultRollDie_ConsecutiveRollsAreNotCorrelated()
    {
        int repeats = 0;
        int previous = DiceResult.DefaultRollDie();
        for (int i = 0; i < Rolls; i++)
        {
            int next = DiceResult.DefaultRollDie();
            if (next == previous) repeats++;
            previous = next;
        }

        // A fair die repeats the previous value 1 time in 6 (10000, sd about 91).
        Assert.InRange(repeats, 9500, 10500);
    }
}
