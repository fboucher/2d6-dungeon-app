# Lambert's History

## Project Context
**Project:** 2d6 Dungeon App — a dungeon crawler game
**Stack:** .NET Aspire, Blazor web client, C# domain/services
**Owner:** Frank

## Learnings

### Map Graphics Architecture
- **Rendering**: HTML5 Canvas via `src/2d6-dungeon-web-client/wwwroot/scripts/canvasTools.js`
- **C# Interop**: `src/2d6-dungeon-web-client/Domain/MapTools.cs` calls JS via IJSRuntime
- **Play Page**: `src/2d6-dungeon-web-client/Components/Pages/Play.razor` contains the canvas element
- **Grid Size**: 30px cube size for map tiles

### User Preferences (Frank)
- Prefers NO external libraries for graphics unless absolutely necessary
- Any library additions require explicit approval

### Visual Design Decisions (2024)
- Implemented parchment-style map background with radial gradient
- Added procedural noise texture for aged look (seeded random for consistency)
- 3D beveled walls with shadow offset and highlight edges
- Stone tile floor pattern using brick-style offset layout
- Warm torch glow effect (radial gradient) for current room indication
- Color palette defined in `MapTheme` constant object for easy theming
- Door colors use forest green (unlocked) and rust red (locked)
