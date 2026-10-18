using c5m._2d6Dungeon;
using Xunit;

namespace _2d6_dungeon_service.Tests;

public class MappedRoomResizeTests
{
    [Fact]
    public void Ranges_ForRegularRoom_AreTwoToTwelve()
    {
        var room = new MappedRoom { Width = 4, Height = 3 };

        Assert.Equal((2, 12), room.GetWidthRange());
        Assert.Equal((2, 12), room.GetHeightRange());
    }

    [Fact]
    public void Ranges_ForHorizontalCorridor_LockHeightAndLimitWidthToSix()
    {
        var room = new MappedRoom { IsCorridor = true, Width = 4, Height = 1 };

        Assert.Equal((2, 6), room.GetWidthRange());
        Assert.Equal((1, 1), room.GetHeightRange());
    }

    [Fact]
    public void Ranges_ForVerticalCorridor_LockWidthAndLimitHeightToSix()
    {
        var room = new MappedRoom { IsCorridor = true, Width = 1, Height = 5 };

        Assert.Equal((1, 1), room.GetWidthRange());
        Assert.Equal((2, 6), room.GetHeightRange());
    }
}
