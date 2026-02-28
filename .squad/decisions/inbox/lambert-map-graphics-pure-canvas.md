# Decision: Map Graphics Using Pure Canvas 2D

**Author:** Lambert (Designer)  
**Date:** 2024

## What
Enhanced map graphics implementation using only native Canvas 2D API — no external libraries.

## Context
Frank requested improved visuals for the dungeon map (previously basic shapes) but preferred avoiding external graphics libraries unless absolutely necessary.

## Decision
Implemented all visual improvements using pure Canvas 2D:
- Parchment background with procedural texture
- 3D beveled walls with shadows
- Stone tile floor patterns
- Radial gradient glow effects
- Enhanced door symbols

## Rationale
- **Zero dependencies**: No additional bundle size or version management
- **Full control**: Complete customization of all visual elements
- **Performance**: Native Canvas is highly optimized
- **Maintainability**: All code in one file (`canvasTools.js`)

## Trade-offs
- More code than using a library like Pixi.js or Konva
- No built-in animation framework (would need to implement manually if desired)
- No scene graph for complex interactivity

## Files Changed
- `src/2d6-dungeon-web-client/wwwroot/scripts/canvasTools.js`
