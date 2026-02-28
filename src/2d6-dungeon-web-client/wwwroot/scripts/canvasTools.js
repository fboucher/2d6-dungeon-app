
var canvas;
var context;
var vw,vh;
let cubeSize = 30;

// Viewport offset for panning - measured in grid squares
let viewportOffsetX = 0;
let viewportOffsetY = 0;
const PAN_STEP = 2; // Move 2 squares at a time

// Door lock state colors - configurable for different themes
const DoorColors = {
  LOCKED: '#8B2500',    // Dark rust red for locked doors
  UNLOCKED: '#2E5A2E',  // Forest green for unlocked doors
  SYMBOL: '#1a1a1a',    // Near-black for door symbols
  WALL: '#1a1a1a'       // Near-black for wall sections around doors
};

// Map visual theme colors
const MapTheme = {
  PARCHMENT_LIGHT: '#E8DCC4',
  PARCHMENT_DARK: '#C4B59A',
  PARCHMENT_SHADOW: '#A89878',
  STONE_LIGHT: '#D4C8B8',
  STONE_MID: '#B8A898',
  STONE_DARK: '#8A7A6A',
  WALL_OUTER: '#2A2420',
  WALL_INNER: '#4A4038',
  WALL_HIGHLIGHT: '#6A5A4A',
  GRID_DOT: '#8B7355',
  CURRENT_ROOM_GLOW: 'rgba(255, 200, 100, 0.15)',
  TORCH_GLOW: 'rgba(255, 180, 80, 0.08)'
};

// resize the canvas to fill the browser window
window.addEventListener('resize', onResize, false);
function onResize() {
  canvas = document.getElementById('dotCanvas');
  context = canvas.getContext('2d');

  vw = canvas.width;
  vh = canvas.height;

  resizeCanvas();
}

function resizeCanvas() {
  // Get the DPR and size of the canvas
  const dpr = window.devicePixelRatio;
  const rect = canvas.getBoundingClientRect();

  // Set the "actual" size of the canvas
  canvas.width = rect.width * dpr;
  canvas.height = rect.height * dpr;

  // Scale the context to ensure correct drawing operations
  context.scale(dpr, dpr);

  // Set the "drawn" size of the canvas
  canvas.style.width = `${rect.width}px`;
  canvas.style.height = `${rect.height}px`;

  drawParchmentBackground();
}

// Parchment-style background with subtle texture
function drawParchmentBackground() {
  const rect = canvas.getBoundingClientRect();
  const width = rect.width;
  const height = rect.height;

  // Base parchment gradient
  const gradient = context.createRadialGradient(
    width / 2, height / 2, 0,
    width / 2, height / 2, Math.max(width, height) * 0.7
  );
  gradient.addColorStop(0, MapTheme.PARCHMENT_LIGHT);
  gradient.addColorStop(0.7, MapTheme.PARCHMENT_DARK);
  gradient.addColorStop(1, MapTheme.PARCHMENT_SHADOW);
  
  context.fillStyle = gradient;
  context.fillRect(0, 0, width, height);

  // Add subtle noise texture
  drawParchmentNoise(width, height);
  
  // Draw refined grid dots
  drawGridDots(width, height);
}

// Procedural parchment texture
function drawParchmentNoise(width, height) {
  // Use a seeded random for consistency
  const seed = 12345;
  let rng = seed;
  const seededRandom = () => {
    rng = (rng * 1103515245 + 12345) & 0x7fffffff;
    return rng / 0x7fffffff;
  };

  // Subtle speckles
  for (let i = 0; i < 800; i++) {
    const x = seededRandom() * width;
    const y = seededRandom() * height;
    const alpha = seededRandom() * 0.08;
    const size = seededRandom() * 2 + 0.5;
    
    context.fillStyle = `rgba(100, 80, 60, ${alpha})`;
    context.beginPath();
    context.arc(x, y, size, 0, Math.PI * 2);
    context.fill();
  }

  // Age marks / slight stains
  for (let i = 0; i < 15; i++) {
    const x = seededRandom() * width;
    const y = seededRandom() * height;
    const radius = seededRandom() * 40 + 20;
    
    const stainGradient = context.createRadialGradient(x, y, 0, x, y, radius);
    stainGradient.addColorStop(0, `rgba(120, 100, 80, ${seededRandom() * 0.04})`);
    stainGradient.addColorStop(1, 'rgba(120, 100, 80, 0)');
    
    context.fillStyle = stainGradient;
    context.beginPath();
    context.arc(x, y, radius, 0, Math.PI * 2);
    context.fill();
  }
}

// Enhanced grid dots
function drawGridDots(width, height) {
  const cw = cubeSize;
  const ch = cubeSize;

  for (let x = 0; x < width; x += cw) {
    for (let y = 0; y < height; y += ch) {
      // Subtle cross-hair style dots
      context.fillStyle = MapTheme.GRID_DOT;
      context.globalAlpha = 0.4;
      
      // Center dot
      context.beginPath();
      context.arc(x, y, 1.5, 0, Math.PI * 2);
      context.fill();
      
      context.globalAlpha = 1;
    }
  }
}

GetFloorColor = function(youAreHere){
  if(youAreHere == true){
    return MapTheme.STONE_LIGHT;
  }
  return MapTheme.STONE_MID;
}

function DrawRoom(posX, posY, width, height, youAreHere=false){
  // Apply viewport offset
  const pixelX = (posX - viewportOffsetX) * cubeSize;
  const pixelY = (posY - viewportOffsetY) * cubeSize;
  const pixelWidth = width * cubeSize;
  const pixelHeight = height * cubeSize;

  // Wall thickness for 3D effect
  const wallThickness = 4;
  const shadowOffset = 3;

  // Draw outer shadow (gives depth)
  context.fillStyle = 'rgba(0, 0, 0, 0.3)';
  context.fillRect(
    pixelX + shadowOffset, 
    pixelY + shadowOffset, 
    pixelWidth, 
    pixelHeight
  );

  // Draw wall base (dark outer wall)
  context.fillStyle = MapTheme.WALL_OUTER;
  context.fillRect(pixelX, pixelY, pixelWidth, pixelHeight);

  // Draw wall highlight (top and left edges for beveled effect)
  context.fillStyle = MapTheme.WALL_HIGHLIGHT;
  context.fillRect(pixelX, pixelY, pixelWidth, wallThickness - 1);
  context.fillRect(pixelX, pixelY, wallThickness - 1, pixelHeight);

  // Draw wall inner edge
  context.fillStyle = MapTheme.WALL_INNER;
  context.fillRect(
    pixelX + wallThickness - 2, 
    pixelY + wallThickness - 2, 
    pixelWidth - (wallThickness - 2), 
    2
  );
  context.fillRect(
    pixelX + wallThickness - 2, 
    pixelY + wallThickness - 2, 
    2, 
    pixelHeight - (wallThickness - 2)
  );

  // Draw floor
  const floorX = pixelX + wallThickness;
  const floorY = pixelY + wallThickness;
  const floorWidth = pixelWidth - (wallThickness * 2);
  const floorHeight = pixelHeight - (wallThickness * 2);

  // Floor base color
  context.fillStyle = GetFloorColor(youAreHere);
  context.fillRect(floorX, floorY, floorWidth, floorHeight);

  // Draw stone tile pattern
  drawStoneTiles(floorX, floorY, floorWidth, floorHeight, youAreHere);

  // Current room glow effect
  if (youAreHere) {
    drawRoomGlow(floorX, floorY, floorWidth, floorHeight);
  }
}

// Draw stone tile pattern on floor
function drawStoneTiles(x, y, width, height, youAreHere) {
  const tileSize = cubeSize;
  
  context.strokeStyle = youAreHere ? MapTheme.STONE_MID : MapTheme.STONE_DARK;
  context.lineWidth = 1;
  context.globalAlpha = 0.4;

  // Draw horizontal tile lines
  for (let ty = y + tileSize; ty < y + height; ty += tileSize) {
    context.beginPath();
    context.moveTo(x, ty);
    context.lineTo(x + width, ty);
    context.stroke();
  }

  // Draw vertical tile lines with offset for brick pattern
  for (let row = 0; row < Math.ceil(height / tileSize); row++) {
    const rowY = y + (row * tileSize);
    const offset = (row % 2) * (tileSize / 2);
    
    for (let tx = x + offset + tileSize; tx < x + width; tx += tileSize) {
      const lineTop = rowY;
      const lineBottom = Math.min(rowY + tileSize, y + height);
      
      context.beginPath();
      context.moveTo(tx, lineTop);
      context.lineTo(tx, lineBottom);
      context.stroke();
    }
  }

  // Add subtle stone texture variation
  const seed = Math.floor(x * 100 + y);
  let rng = seed;
  const seededRandom = () => {
    rng = (rng * 1103515245 + 12345) & 0x7fffffff;
    return rng / 0x7fffffff;
  };

  context.globalAlpha = 0.15;
  for (let i = 0; i < Math.floor(width * height / 400); i++) {
    const sx = x + seededRandom() * width;
    const sy = y + seededRandom() * height;
    const sSize = seededRandom() * 3 + 1;
    
    context.fillStyle = seededRandom() > 0.5 ? MapTheme.STONE_DARK : MapTheme.STONE_LIGHT;
    context.beginPath();
    context.arc(sx, sy, sSize, 0, Math.PI * 2);
    context.fill();
  }

  context.globalAlpha = 1;
  context.lineWidth = 1;
}

// Glow effect for current room
function drawRoomGlow(x, y, width, height) {
  const centerX = x + width / 2;
  const centerY = y + height / 2;
  const maxRadius = Math.max(width, height) * 0.8;

  const glowGradient = context.createRadialGradient(
    centerX, centerY, 0,
    centerX, centerY, maxRadius
  );
  glowGradient.addColorStop(0, MapTheme.CURRENT_ROOM_GLOW);
  glowGradient.addColorStop(0.5, MapTheme.TORCH_GLOW);
  glowGradient.addColorStop(1, 'rgba(255, 180, 80, 0)');

  context.fillStyle = glowGradient;
  context.fillRect(x, y, width, height);
}

function DrawDoor(posX, posY, orientation, isMain=false, doorType='archway', isLocked=false, youAreHere= false) {
  // Use lock state colors
  let doorColor = isLocked ? DoorColors.LOCKED : DoorColors.UNLOCKED;

  // Door dimensions
  let doorWidth = cubeSize;
  let doorHeight = cubeSize;
  
  // Apply viewport offset
  const pixelX = (posX - viewportOffsetX) * cubeSize;
  const pixelY = (posY - viewportOffsetY) * cubeSize;

  // Draw floor under door
  let floorColor = GetFloorColor(youAreHere);
  context.fillStyle = floorColor;
  context.fillRect(pixelX + 2, pixelY + 2, doorWidth - 4, doorHeight - 4);

  // Draw subtle door frame shadow
  context.fillStyle = 'rgba(0, 0, 0, 0.2)';
  if (orientation === 'H') {
    context.fillRect(pixelX + 4, pixelY, doorWidth - 8, 2);
    context.fillRect(pixelX + 4, pixelY + doorHeight - 2, doorWidth - 8, 2);
  } else {
    context.fillRect(pixelX, pixelY + 4, 2, doorHeight - 8);
    context.fillRect(pixelX + doorWidth - 2, pixelY + 4, 2, doorHeight - 8);
  }

  // Draw wall continuation lines (thicker, more visible)
  context.strokeStyle = MapTheme.WALL_OUTER;
  context.lineWidth = 3;
  context.beginPath();
  
  if (orientation === 'H') {
    // Vertical wall lines on left and right
    context.moveTo(pixelX + 1, pixelY);
    context.lineTo(pixelX + 1, pixelY + doorHeight);
    context.moveTo(pixelX + doorWidth - 1, pixelY);
    context.lineTo(pixelX + doorWidth - 1, pixelY + doorHeight);
  } else {
    // Horizontal wall lines on top and bottom
    context.moveTo(pixelX, pixelY + 1);
    context.lineTo(pixelX + doorWidth, pixelY + 1);
    context.moveTo(pixelX, pixelY + doorHeight - 1);
    context.lineTo(pixelX + doorWidth, pixelY + doorHeight - 1);
  }
  
  context.stroke();
  context.lineWidth = 2;

  // Draw the door symbol
  DrawDoorType(pixelX, pixelY, doorWidth, doorHeight, orientation, doorType, doorColor, isMain);
}

// Door type constants
const DoorTypes = {
  ARCHWAY: 'archway',
  WOODEN: 'wooden',
  METAL: 'metal',
  REINFORCED: 'reinforced',
  CURTAIN: 'curtain',
  PORTCULLIS: 'portcullis',
  STONE_SLAB: 'stone_slab'
};

// Main function to draw door type symbol
function DrawDoorType(posX, posY, width, height, orientation, doorType, doorColor, isMain=false) {
  const centerX = posX + width / 2;
  const centerY = posY + height / 2;
  
  // Use the door color for the symbol
  context.strokeStyle = doorColor;
  context.fillStyle = doorColor;
  context.lineWidth = 2;

  // Main entrance gets special treatment
  if (isMain) {
    DrawMainEntrance(centerX, centerY, width, height, orientation);
    context.lineWidth = 1;
    return;
  }
  
  switch (doorType) {
    case DoorTypes.ARCHWAY:
      DrawArchway(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.WOODEN:
      DrawWoodenDoor(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.METAL:
      DrawMetalDoor(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.REINFORCED:
      DrawReinforcedDoor(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.CURTAIN:
      DrawCurtain(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.PORTCULLIS:
      DrawPortcullis(centerX, centerY, width, height, orientation);
      break;
    case DoorTypes.STONE_SLAB:
      DrawStoneSlab(centerX, centerY, width, height, orientation);
      break;
    default:
      DrawArchway(centerX, centerY, width, height, orientation);
      break;
  }
  
  context.lineWidth = 1;
}

// Main entrance: special dungeon entrance marker
function DrawMainEntrance(centerX, centerY, width, height, orientation) {
  const size = Math.min(width, height) * 0.35;
  
  // Draw a decorative arch shape
  context.strokeStyle = '#5A4A3A';
  context.lineWidth = 3;
  
  context.beginPath();
  if (orientation === 'H') {
    // Arch shape for horizontal doorway
    context.moveTo(centerX - size, centerY + size * 0.5);
    context.lineTo(centerX - size, centerY - size * 0.3);
    context.quadraticCurveTo(centerX, centerY - size, centerX + size, centerY - size * 0.3);
    context.lineTo(centerX + size, centerY + size * 0.5);
  } else {
    // Rotated arch for vertical doorway
    context.moveTo(centerX + size * 0.5, centerY - size);
    context.lineTo(centerX - size * 0.3, centerY - size);
    context.quadraticCurveTo(centerX - size, centerY, centerX - size * 0.3, centerY + size);
    context.lineTo(centerX + size * 0.5, centerY + size);
  }
  context.stroke();

  // Add a small "exit" indicator arrow
  context.fillStyle = '#5A4A3A';
  context.beginPath();
  if (orientation === 'H') {
    context.moveTo(centerX, centerY + size * 0.8);
    context.lineTo(centerX - size * 0.3, centerY + size * 0.4);
    context.lineTo(centerX + size * 0.3, centerY + size * 0.4);
  } else {
    context.moveTo(centerX + size * 0.8, centerY);
    context.lineTo(centerX + size * 0.4, centerY - size * 0.3);
    context.lineTo(centerX + size * 0.4, centerY + size * 0.3);
  }
  context.closePath();
  context.fill();
}

// Archway: Open doorway pattern -|  |- (showing the door is open)
function DrawArchway(centerX, centerY, width, height, orientation) {
  context.beginPath();
  
  if (orientation === 'H') {
    // Horizontal door - draw -|  |- pattern horizontally
    // Left side: horizontal line with vertical cap
    const leftX = centerX - width * 0.3;
    const rightX = centerX + width * 0.3;
    const lineLength = width * 0.15;
    const capHeight = height * 0.25;
    
    // Left horizontal line
    context.moveTo(leftX - lineLength, centerY);
    context.lineTo(leftX, centerY);
    // Left vertical cap
    context.moveTo(leftX, centerY - capHeight);
    context.lineTo(leftX, centerY + capHeight);
    
    // Right horizontal line
    context.moveTo(rightX, centerY);
    context.lineTo(rightX + lineLength, centerY);
    // Right vertical cap
    context.moveTo(rightX, centerY - capHeight);
    context.lineTo(rightX, centerY + capHeight);
  } else {
    // Vertical door - draw pattern vertically
    const topY = centerY - height * 0.3;
    const bottomY = centerY + height * 0.3;
    const lineLength = height * 0.15;
    const capWidth = width * 0.25;
    
    // Top vertical line with horizontal cap
    context.moveTo(centerX, topY - lineLength);
    context.lineTo(centerX, topY);
    // Top horizontal cap
    context.moveTo(centerX - capWidth, topY);
    context.lineTo(centerX + capWidth, topY);
    
    // Bottom vertical line with horizontal cap
    context.moveTo(centerX, bottomY);
    context.lineTo(centerX, bottomY + lineLength);
    // Bottom horizontal cap
    context.moveTo(centerX - capWidth, bottomY);
    context.lineTo(centerX + capWidth, bottomY);
  }
  
  context.stroke();
}

// Wooden door: Rectangle outline
function DrawWoodenDoor(centerX, centerY, width, height, orientation) {
  const rectWidth = orientation === 'H' ? width * 0.5 : width * 0.35;
  const rectHeight = orientation === 'H' ? height * 0.35 : height * 0.5;
  
  context.strokeRect(centerX - rectWidth / 2, centerY - rectHeight / 2, rectWidth, rectHeight);
}

// Metal door: Filled black rectangle
function DrawMetalDoor(centerX, centerY, width, height, orientation) {
  const rectWidth = orientation === 'H' ? width * 0.5 : width * 0.35;
  const rectHeight = orientation === 'H' ? height * 0.35 : height * 0.5;
  
  context.fillRect(centerX - rectWidth / 2, centerY - rectHeight / 2, rectWidth, rectHeight);
}

// Reinforced door: Rectangle with cross pattern
function DrawReinforcedDoor(centerX, centerY, width, height, orientation) {
  const rectWidth = orientation === 'H' ? width * 0.5 : width * 0.35;
  const rectHeight = orientation === 'H' ? height * 0.35 : height * 0.5;
  
  const x = centerX - rectWidth / 2;
  const y = centerY - rectHeight / 2;
  
  context.strokeRect(x, y, rectWidth, rectHeight);
  
  // Draw cross inside
  context.beginPath();
  context.moveTo(x, y);
  context.lineTo(x + rectWidth, y + rectHeight);
  context.moveTo(x + rectWidth, y);
  context.lineTo(x, y + rectHeight);
  context.stroke();
}

// Curtain: Wavy lines
function DrawCurtain(centerX, centerY, width, height, orientation) {
  context.beginPath();
  
  if (orientation === 'H') {
    // Draw two wavy vertical lines
    const startY = centerY - height * 0.35;
    const endY = centerY + height * 0.35;
    const waveWidth = width * 0.08;
    
    // Left wavy line
    const leftX = centerX - width * 0.15;
    context.moveTo(leftX, startY);
    for (let y = startY; y <= endY; y += 3) {
      const offset = Math.sin((y - startY) * 0.4) * waveWidth;
      context.lineTo(leftX + offset, y);
    }
    
    // Right wavy line
    const rightX = centerX + width * 0.15;
    context.moveTo(rightX, startY);
    for (let y = startY; y <= endY; y += 3) {
      const offset = Math.sin((y - startY) * 0.4) * waveWidth;
      context.lineTo(rightX + offset, y);
    }
  } else {
    // Draw two wavy horizontal lines
    const startX = centerX - width * 0.35;
    const endX = centerX + width * 0.35;
    const waveHeight = height * 0.08;
    
    // Top wavy line
    const topY = centerY - height * 0.15;
    context.moveTo(startX, topY);
    for (let x = startX; x <= endX; x += 3) {
      const offset = Math.sin((x - startX) * 0.4) * waveHeight;
      context.lineTo(x, topY + offset);
    }
    
    // Bottom wavy line
    const bottomY = centerY + height * 0.15;
    context.moveTo(startX, bottomY);
    for (let x = startX; x <= endX; x += 3) {
      const offset = Math.sin((x - startX) * 0.4) * waveHeight;
      context.lineTo(x, bottomY + offset);
    }
  }
  
  context.stroke();
}

// Portcullis: Line with circles
function DrawPortcullis(centerX, centerY, width, height, orientation) {
  const circleRadius = Math.min(width, height) * 0.08;
  
  if (orientation === 'H') {
    // Vertical line
    context.beginPath();
    context.moveTo(centerX, centerY - height * 0.35);
    context.lineTo(centerX, centerY + height * 0.35);
    // Draw both circles in the same path
    context.moveTo(centerX - width * 0.15 + circleRadius, centerY);
    context.arc(centerX - width * 0.15, centerY, circleRadius, 0, Math.PI * 2);
    context.moveTo(centerX + width * 0.15 + circleRadius, centerY);
    context.arc(centerX + width * 0.15, centerY, circleRadius, 0, Math.PI * 2);
    context.stroke();
  } else {
    // Horizontal line
    context.beginPath();
    context.moveTo(centerX - width * 0.35, centerY);
    context.lineTo(centerX + width * 0.35, centerY);
    // Draw both circles in the same path
    context.moveTo(centerX + circleRadius, centerY - height * 0.15);
    context.arc(centerX, centerY - height * 0.15, circleRadius, 0, Math.PI * 2);
    context.moveTo(centerX + circleRadius, centerY + height * 0.15);
    context.arc(centerX, centerY + height * 0.15, circleRadius, 0, Math.PI * 2);
    context.stroke();
  }
}

// Stone Slab: Rectangle with smaller filled rectangle inside
function DrawStoneSlab(centerX, centerY, width, height, orientation) {
  const outerWidth = orientation === 'H' ? width * 0.5 : width * 0.35;
  const outerHeight = orientation === 'H' ? height * 0.35 : height * 0.5;
  const innerWidth = outerWidth * 0.5;
  const innerHeight = outerHeight * 0.5;
  
  // Outer rectangle
  context.strokeRect(centerX - outerWidth / 2, centerY - outerHeight / 2, outerWidth, outerHeight);
  
  // Inner filled rectangle
  context.fillRect(centerX - innerWidth / 2, centerY - innerHeight / 2, innerWidth, innerHeight);
}

// ============================================
// VIEWPORT PANNING CONTROLS
// ============================================

// Pan the viewport by a number of grid squares
function panViewport(direction) {
  switch (direction) {
    case 'left':
      viewportOffsetX -= PAN_STEP;
      break;
    case 'right':
      viewportOffsetX += PAN_STEP;
      break;
    case 'up':
      viewportOffsetY -= PAN_STEP;
      break;
    case 'down':
      viewportOffsetY += PAN_STEP;
      break;
  }
}

// Center the viewport on a specific grid position
function centerViewportOn(gridX, gridY) {
  const rect = canvas.getBoundingClientRect();
  const viewportGridWidth = Math.floor(rect.width / cubeSize);
  const viewportGridHeight = Math.floor(rect.height / cubeSize);
  
  // Center the given position in the viewport
  viewportOffsetX = gridX - Math.floor(viewportGridWidth / 2);
  viewportOffsetY = gridY - Math.floor(viewportGridHeight / 2);
}

// Get current viewport offset (for UI display)
function getViewportOffset() {
  return { x: viewportOffsetX, y: viewportOffsetY };
}

// Get viewport dimensions in grid squares
function getViewportGridSize() {
  const rect = canvas.getBoundingClientRect();
  return {
    width: Math.floor(rect.width / cubeSize),
    height: Math.floor(rect.height / cubeSize)
  };
}

// Reset viewport to origin
function resetViewport() {
  viewportOffsetX = 0;
  viewportOffsetY = 0;
}

// Keyboard event handler for panning
function setupKeyboardPanning() {
  document.addEventListener('keydown', function(e) {
    // Only pan if canvas is visible/focused area and not in input field
    if (e.target.tagName === 'INPUT' || e.target.tagName === 'TEXTAREA') {
      return;
    }
    
    let shouldPan = false;
    
    switch (e.key) {
      case 'ArrowLeft':
        panViewport('left');
        shouldPan = true;
        break;
      case 'ArrowRight':
        panViewport('right');
        shouldPan = true;
        break;
      case 'ArrowUp':
        panViewport('up');
        shouldPan = true;
        break;
      case 'ArrowDown':
        panViewport('down');
        shouldPan = true;
        break;
    }
    
    if (shouldPan) {
      e.preventDefault();
      // Dispatch custom event for Blazor to handle redraw
      window.dispatchEvent(new CustomEvent('viewportPanned'));
    }
  });
}

// Initialize keyboard panning when DOM is ready
if (document.readyState === 'loading') {
  document.addEventListener('DOMContentLoaded', setupKeyboardPanning);
} else {
  setupKeyboardPanning();
}


