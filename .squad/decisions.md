# Decisions

<!-- Append-only. Scribe merges from decisions/inbox/. -->

## Parameter naming standard
**What:** All [Parameter] properties use PascalCase with private _camelCase backing field
**Files changed:** Adventurer.razor, Play.razor

## User directive: Prefer no external libraries for graphics
**By:** Frank (via Copilot)  
**Date:** 2026-02-28T19:41:15Z  
**What:** Prefer no external libraries for graphics work. If external libraries would make things significantly easier, ask first before adding dependencies.
**Why:** User preference — captured for team memory

## Map Graphics Using Pure Canvas 2D
**Author:** Lambert (Designer)  
**Date:** 2026-02-28

**What:** Enhanced map graphics implementation using only native Canvas 2D API — no external libraries.

**Context:** Frank requested improved visuals for the dungeon map (previously basic shapes) but preferred avoiding external graphics libraries unless absolutely necessary.

**Decision:** Implemented all visual improvements using pure Canvas 2D:
- Parchment background with procedural texture
- 3D beveled walls with shadows
- Stone tile floor patterns
- Radial gradient glow effects
- Enhanced door symbols

**Rationale:**
- **Zero dependencies**: No additional bundle size or version management
- **Full control**: Complete customization of all visual elements
- **Performance**: Native Canvas is highly optimized
- **Maintainability**: All code in one file (canvasTools.js)

**Trade-offs:**
- More code than using a library like Pixi.js or Konva
- No built-in animation framework (would need to implement manually if desired)
- No scene graph for complex interactivity

**Files Changed:** src/2d6-dungeon-web-client/wwwroot/scripts/canvasTools.js

## Map Viewport Panning Implementation
**Author:** Lambert (Designer)  
**Date:** 2026-02-28

**What:** Added viewport panning controls to the dungeon map, allowing users to navigate around large maps (e.g., 80x80 grid) when the visible viewport is smaller (e.g., ~26x26 grid at 800x800px canvas).

**Implementation:**
- Pure Canvas 2D (no external libraries per team decision)
- Pan Step: 2 grid squares per pan action
- Controls: Arrow buttons (chevron icons, neutral style), keyboard arrow keys (with input field exclusion), center on room button, reset to origin button

**UX Decision:** Pan controls use neutral button appearance to visually distinguish from the existing room-positioning controls (which use accent style). This creates clear visual grouping between "navigating the viewport" and "positioning a new room."

**Files Changed:**
- src/2d6-dungeon-web-client/wwwroot/scripts/canvasTools.js
- src/2d6-dungeon-web-client/Domain/MapTools.cs
- src/2d6-dungeon-web-client/Components/Pages/Play.razor
