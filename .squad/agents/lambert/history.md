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

### Dice Component Architecture
- **Display Component**: `src/2d6-dungeon-web-client/Components/Shared/Dice.razor`
- **Dice Images**: `src/2d6-dungeon-web-client/wwwroot/dice/` (red, purple, white; faces 0-6)
- **Animation JS**: `src/2d6-dungeon-web-client/wwwroot/scripts/diceAnimation.js`
- **CSS Animations**: Defined in `wwwroot/app.css` (diceRoll, diceSettle keyframes)
- **Pattern**: Component takes `Animate="true"` parameter to enable roll animation on value changes

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

### Dice Roll Animation (2025)
- Pure CSS/JS animation—no external libraries
- Animation includes rotation, scale bounce, and "tumbling" effect
- Cycles through random dice faces (8 frames over 600ms) before settling
- Settle animation adds "pop" effect with scale and brightness
- Animation triggered only when face value changes (detects new rolls)
- Components with `Animate="true"`: Play.razor, Combat.razor, CombatTurnConsole.razor, NewRoomDialog.razor, TableViewer.razor, AdventureInit.razor

### Dice Animation System Enhancements (2025)
- **Animation Types**: Added `AnimateType` parameter to Dice component
  - `Roll` (default): Full tumbling animation with random face cycling
  - `Flip`: Single rotation for shift button adjustments
- **Flip Animation**: 0.3s rotateX animation that shows dice spinning to new face
  - Direction-aware (up/down based on value increase/decrease)
  - Used when ShiftButtons modify dice values
- **Doubles Celebration**: Sparkle/star burst effect when rolling doubles
  - Golden glow on both dice with CSS drop-shadow
  - 12 circular sparkles radiating outward
  - 6 star characters (✦) spinning outward
  - All CSS keyframe animations, no libraries
- **Dice Component API**:
  - `DiceId` property exposes element ID for external coordination
  - `CelebrateDoublesWith(partnerId)` method for parent-triggered celebration
  - `DoublesCelebrationPartnerId` parameter for automatic doubles detection
- **CSS keyframes added**: `diceFlipUp`, `diceFlipDown`, `doublesGlow`, `sparkle-burst`, `star-burst`

### Dice Animation Trigger Pattern (2025)
- **Critical Pattern**: Animation is triggered in `OnParametersSetAsync` when `faceA != previousFaceA`
- **Pitfall**: Conditional rendering (`@if(result != null)`) creates components with face already set; `OnInitialized` sets `previousFaceA = faceA`, so no change is detected
- **Solution**: Always render Dice components, use CSS `display:none` to hide when face=0
- **Correct Pattern**: Initialize DiceResult with `PrimaryDice = 0`, render dice with `style="display:none"` when 0, dice appears with animation when value changes
- **Working Example**: Combat.razor (lines 31-32) - dice always rendered with initial face=0
- **Fixed**: NewRoomDialog.razor - changed from conditional `@if` to always-render with CSS visibility

### Map Viewport Panning (2025-2026)
- **Purpose**: Allow panning to view large dungeon maps (e.g., 80x80) when viewport shows limited area (e.g., 20x20)
- **Implementation**: Pure Canvas 2D with JS offset variables—no external libraries
- **Architecture**:
  - `viewportOffsetX` / `viewportOffsetY` globals in canvasTools.js track pan position (in grid squares)
  - `PAN_STEP = 2` moves approximately 2 squares per pan action
  - `DrawRoom()` and `DrawDoor()` subtract viewport offset from grid coordinates before converting to pixels
- **Controls**:
  - **UI Buttons**: Chevron arrows (neutral appearance) for left/right/up/down panning
  - **Keyboard**: Arrow keys pan the map (prevents default scroll, ignores input fields)
  - **Center Button**: Centers viewport on current room
  - **Reset Button**: Returns viewport to origin (0,0)
- **C# Interop**: `MapTools.PanViewport()`, `MapTools.CenterViewportOn()`, `MapTools.ResetViewport()` in MapTools.cs
- **JS Functions**: `panViewport(direction)`, `centerViewportOn(gridX, gridY)`, `resetViewport()`, `getViewportOffset()`, `getViewportGridSize()`
- **UX Notes**:
  - Pan controls use neutral button style to distinguish from room-positioning controls (accent style)
  - Clear labeling separates "Pan Map View" from "Position New Room" controls
  - Helper classes `ViewportOffset` and `ViewportSize` added for JS interop return values
- **Agent 5 Completion (2026-02-28)**: Full implementation with keyboard + UI button controls tested and working

### Dice Roll Animation Enhancements (2026-02-28)
- **Agent 2**: Initial implementation of Roll and Flip animation types with doubles celebration
  - Roll: 600ms tumbling with random face cycling
  - Flip: 300ms direction-aware rotation for shift button adjustments
  - Doubles: Golden glow + radial sparkle/star burst effects
  - New CSS keyframes: diceFlipUp, diceFlipDown, doublesGlow, sparkle-burst, star-burst
  - Component API: DiceId property, CelebrateDoublesWith() method, DoublesCelebrationPartnerId parameter
- **Agent 3**: Fixed critical animation trigger pattern
  - Root cause: Conditional @if rendering prevents change detection in OnParametersSetAsync
  - Solution: Always render Dice components, use CSS `display:none` when face=0
  - Pattern documented for team knowledge
- **Agent 4**: Fixed NewRoomDialog animation triggering
  - Refactored from conditional to always-render pattern
  - Aligns with established pattern in Combat.razor
