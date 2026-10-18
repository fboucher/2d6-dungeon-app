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

        await js.InvokeVoidAsync("DrawRoom", gidX, gidY, currentRoom.Width, currentRoom.Height, currentRoom.YouAreHere, currentRoom.IsUnique);

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

            await js.InvokeVoidAsync("DrawDoor", x, y, orientation, isMain, door.Value.ExitType, door.Value.IsLocked, youAreHere, door.Value.IsDamaged);
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

    public static (int X, int Y) GetDoorGridPosition(MappedRoom room, Direction wall) => room.GetDoorCell(wall);

    public static (int X, int Y) GetRoomOriginForDoorGridPosition(MappedRoom room, Direction wall, int doorX, int doorY)
        => room.GetOriginForDoorCell(wall, doorX, doorY);

}
