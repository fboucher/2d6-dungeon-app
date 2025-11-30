
var canvas;
var context;
var vw,vh;
let cubeSize = 30;

// Door lock state colors - configurable for different themes
const DoorColors = {
  LOCKED: '#CC3333',    // Red for locked doors
  UNLOCKED: '#33CC33',  // Green for unlocked doors
  SYMBOL: '#000000',    // Black for door symbols
  WALL: '#000000'       // Black for wall sections around doors
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

  drawDots();
}

// dots
function drawDots() {

  var r = 1,
      cw = cubeSize,
      ch = cubeSize;

  //Paper color
  context.fillStyle = '#3B3428';
  context.fillRect(0, 0, vw, vh); 
  
  for (var x = 0; x < vw; x+=cw) {
    for (var y = 0; y < vh; y+=ch) {
        context.fillStyle = '#777777';   
        context.fillRect(x-r/2,y-r/2,r,r);
      }
  }
}

GetFloorColor = function(youAreHere){
  console.log("youAreHere in GetFloorColor:", youAreHere);
  let floorColor = '#ffffff';
  if(youAreHere == true){
    floorColor = '#F7EDD5'; 
  }
  return floorColor;
}

function DrawRoom(posX, posY, width, height, youAreHere=false){

  console.log("youAreHere in DrawRoom:", youAreHere);
  let roomColor = GetFloorColor(youAreHere);

  posX = posX * cubeSize;
  posY = posY * cubeSize;
  width = width * cubeSize;
  height = height * cubeSize;

  context.fillStyle = '#000000'; 
  context.fillRect(posX, posY, width, height);
  context.stroke();
  context.fillStyle = roomColor;
  context.fillRect(posX+1, posY+1, width-2, height-2);
  context.stroke();
}

function DrawDoor(posX, posY, orientation, isMain=false, doorType='archway', isLocked=false, youAreHere= false) {

  console.log("youAreHere in DrawDoor:", youAreHere);
  // Use lock state colors - unlocked (green) by default, locked (red) when locked
  let doorColor = isLocked ? DoorColors.LOCKED : DoorColors.UNLOCKED;

  // Always draw a full square (30x30)
  let doorWidth = cubeSize; // one square
  let doorHeight = cubeSize; // one square
  
  posX = posX * cubeSize;
  posY = posY * cubeSize;

  let floorColor = GetFloorColor(youAreHere);
  context.fillStyle = floorColor;
  context.fillRect(posX + 1, posY + 1, doorWidth - 2, doorHeight - 2);

  // Draw wall line sections on each side of the door (1 cube long each)
  // This makes doors look connected to walls instead of floating
  context.strokeStyle = DoorColors.WALL;
  context.lineWidth = 1;
  context.beginPath();
  
  if (orientation === 'H') {
    // Horizontal door (on top/bottom wall) - add vertical wall lines on left and right
    // Left wall line (vertical, 1 cube tall)
    context.moveTo(posX, posY);
    context.lineTo(posX, posY + doorHeight);
    // Right wall line (vertical, 1 cube tall)
    context.moveTo(posX + doorWidth, posY);
    context.lineTo(posX + doorWidth, posY + doorHeight);
  } else {
    // Vertical door (on left/right wall) - add horizontal wall lines on top and bottom
    // Top wall line (horizontal, 1 cube wide)
    context.moveTo(posX, posY);
    context.lineTo(posX + doorWidth, posY);
    // Bottom wall line (horizontal, 1 cube wide)
    context.moveTo(posX, posY + doorHeight);
    context.lineTo(posX + doorWidth, posY + doorHeight);
  }
  
  context.stroke();
  context.lineWidth = 2;

  // Draw the door type symbol with the appropriate color (no background square)
  DrawDoorType(posX, posY, doorWidth, doorHeight, orientation, doorType, doorColor);
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
function DrawDoorType(posX, posY, width, height, orientation, doorType, doorColor) {
  const centerX = posX + width / 2;
  const centerY = posY + height / 2;
  
  // Use the door color for the symbol (green for unlocked, red for locked)
  context.strokeStyle = doorColor;
  context.fillStyle = doorColor;
  context.lineWidth = 2;
  
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


