using Microsoft.JSInterop;

namespace c5m._2d6Dungeon.web.Domain;

public static class MapTools
{

    public static async Task RefreshCanvas(IJSRuntime js)
    {
        await js.InvokeVoidAsync("onResize");
    }

    public static async Task DrawRoom(IJSRuntime js, MappedRoom currentRoom)
    {
        int gidX = (currentRoom.CoordX);
        int gidY = (currentRoom.CoordY);

        string txtState = currentRoom.State.ToString().ToLower();

        await js.InvokeVoidAsync("DrawRoom", gidX, gidY, currentRoom.Width, currentRoom.Height, txtState);

        await DrawDoors(js, currentRoom);
    }

    public static async Task DrawDoors(IJSRuntime js, MappedRoom currentRoom)
    {
        foreach (var door in currentRoom.Exits!)
        {
            string orientation = GetDoorOrientation(door.Key);
            int x = 0;
            int y = 0;
            bool isMain = false;

            switch (door.Key)
            {
                case Direction.North:
                    x = currentRoom.CoordX + door.Value.PositionOnWall;
                    y = currentRoom.CoordY - 1; // Position outside the room (above)
                    break;
                case Direction.East:
                    x = currentRoom.CoordX + currentRoom.Width; // Position outside the room (to the right)
                    y = currentRoom.CoordY + door.Value.PositionOnWall;
                    break;
                case Direction.South:
                    x = currentRoom.CoordX + door.Value.PositionOnWall;
                    y = currentRoom.CoordY + currentRoom.Height; // Position outside the room (below)
                    isMain = currentRoom.IsLobby;
                    break;
                case Direction.West:
                    x = currentRoom.CoordX - 1; // Position outside the room (to the left)
                    y = currentRoom.CoordY + door.Value.PositionOnWall;
                    break;
            }

            await js.InvokeVoidAsync("DrawDoor", x, y, orientation, isMain);
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

}
