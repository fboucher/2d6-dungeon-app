var canvas;
var context;
var vw,vh;
let cubeSize = 30;


const ROOM_COLORS = {
  regular: {
    border: '#000000',
    background: '#a5a7ae'
  },
  draft: {
    border: '#b1b2b3',
    background: '#f0f0f0'
  },
  current: {
    border: '#FF6B35',
    background: '#F7EDD5'
  }
};

const EXIT_COLORS = {
  regular: {
    border: '#000000',
    background: '#DEC5C0'
  },
  main: {
    border: '#000000',
    background: '#B3D2D3'
  },
  current_to: {
    border: '#000000',
    background: '#0000FF'
  },
  current_from: {
    border: '#000000',
    background: '#FF0000'
  }
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

function DrawRoom(posX, posY, width, height, state = 'regular'){

  // Get colors based on state, default to regular if invalid state
  const colors = ROOM_COLORS[state] || ROOM_COLORS.regular;

  posX = posX * cubeSize;
  posY = posY * cubeSize;
  width = width * cubeSize;
  height = height * cubeSize;

  // Draw border
  context.fillStyle = colors.border; 
  context.fillRect(posX, posY, width, height);
  context.stroke();
  
  // Draw background
  context.fillStyle = colors.background;
  context.fillRect(posX+1, posY+1, width-2, height-2);
  context.stroke();
}

function DrawDoor(posX, posY, orientation, isMain=false){

  let doorColor = '#B3D2D3'
  if(isMain == false){
    doorColor = '#DEC5C0'
  }

  // Always draw a full square (30x30)
  let doorWidth = cubeSize; // one square
  let doorHeight = cubeSize; // one square
  
  posX = posX * cubeSize;
  posY = posY * cubeSize;

  if(orientation == 'V') {
    posY = posY - cubeSize;
  }
  else{
    posX = posX - cubeSize;
  }

  context.fillStyle = '#000000'; 
  context.fillRect(posX, posY, doorWidth, doorHeight);
  context.stroke();
  context.fillStyle = doorColor;
  context.fillRect(posX+1, posY+1, doorWidth-2, doorHeight-2);
  context.stroke();
}
