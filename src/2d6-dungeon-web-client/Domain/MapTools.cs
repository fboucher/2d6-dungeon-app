using Microsoft.JSInterop;

namespace c5m._2d6Dungeon.web.Domain;

// Helper classes for JS interop
public class ViewportOffset
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class ViewportSize
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public static class MapTools
{

    public static async Task RefreshCanvas(IJSRuntime js) 
    { 
        await js.InvokeVoidAsync("onResize");
    }

    // Viewport panning methods
    public static async Task PanViewport(IJSRuntime js, string direction)
    {
        await js.InvokeVoidAsync("panViewport", direction);
    }

    public static async Task CenterViewportOn(IJSRuntime js, int gridX, int gridY)
    {
        await js.InvokeVoidAsync("centerViewportOn", gridX, gridY);
    }

    public static async Task ResetViewport(IJSRuntime js)
    {
        await js.InvokeVoidAsync("resetViewport");
    }

    public static async Task<(int X, int Y)> GetViewportOffset(IJSRuntime js)
    {
        var offset = await js.InvokeAsync<ViewportOffset>("getViewportOffset");
        return (offset.X, offset.Y);
    }

    public static async Task<(int Width, int Height)> GetViewportGridSize(IJSRuntime js)
    {
        var size = await js.InvokeAsync<ViewportSize>("getViewportGridSize");
        return (size.Width, size.Height);
    }

    public static async Task DrawRoom(IJSRuntime js, MappedRoom currentRoom)
    {
        int gidX = (currentRoom.CoordX);
        int gidY = (currentRoom.CoordY);

        await js.InvokeVoidAsync("DrawRoom", gidX, gidY, currentRoom.Width, currentRoom.Height, currentRoom.YouAreHere);

        await DrawDoors(js, currentRoom, currentRoom.YouAreHere);
    }

    public static async Task DrawDoors(IJSRuntime js, MappedRoom currentRoom, bool youAreHere)
    {
        foreach (var door in currentRoom.Exits!)
        {
            string orientation = GetDoorOrientation(door.Key);
            bool isMain = false;

            var (x, y) = GetDoorGridPosition(currentRoom, door.Key);
            if (door.Key == Direction.South)
            {
                isMain = currentRoom.IsLobby;
            }

            await js.InvokeVoidAsync("DrawDoor", x, y, orientation, isMain, null, null, youAreHere);
        }


    }

    private static string GetDoorOrientation(Direction onWall)
    {
        if (onWall == Direction.South || onWall == Direction.North)
        {
            return "H";
        }
        return "V";
    }

    public static (int X, int Y) GetDoorGridPosition(MappedRoom room, Direction wall)
    {
        if (room.Exits == null || !room.Exits.TryGetValue(wall, out var exit))
        {
            throw new InvalidOperationException($"Room {room.Id} has no exit on wall '{wall}'.");
        }

        return wall switch
        {
            Direction.North => (room.CoordX - 1 + exit.PositionOnWall, room.CoordY - 1),
            Direction.East => (room.CoordX + room.Width, room.CoordY - 1 + exit.PositionOnWall),
            Direction.South => (room.CoordX - 1 + exit.PositionOnWall, room.CoordY + room.Height),
            Direction.West => (room.CoordX - 1, room.CoordY - 1 + exit.PositionOnWall),
            _ => throw new ArgumentOutOfRangeException(nameof(wall), wall, "Unknown wall direction")
        };
    }

    public static (int X, int Y) GetRoomOriginForDoorGridPosition(MappedRoom room, Direction wall, int doorX, int doorY)
    {
        if (room.Exits == null || !room.Exits.TryGetValue(wall, out var exit))
        {
            throw new InvalidOperationException($"Room {room.Id} has no exit on wall '{wall}'.");
        }

        var pos = exit.PositionOnWall;
        return wall switch
        {
            Direction.North => (doorX + 1 - pos, doorY + 1),
            Direction.East => (doorX - room.Width, doorY + 1 - pos),
            Direction.South => (doorX + 1 - pos, doorY - room.Height),
            Direction.West => (doorX + 1, doorY + 1 - pos),
            _ => throw new ArgumentOutOfRangeException(nameof(wall), wall, "Unknown wall direction")
        };
    }

}
