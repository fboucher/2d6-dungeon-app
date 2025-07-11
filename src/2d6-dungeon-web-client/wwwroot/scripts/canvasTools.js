
var canvas;
var context;
var vw,vh;
let cubeSize = 30;

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

function DrawRoom(posX, posY, width, height, youAreHere=false){

  let roomColor = '#ffffff';
  if(youAreHere == true){
    roomColor = '#F7EDD5'; 
  }

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

  // if(orientation == 'V') {
  //   posY = posY - cubeSize;
  // }

  context.fillStyle = '#000000'; 
  context.fillRect(posX, posY, doorWidth, doorHeight);
  context.stroke();
  context.fillStyle = doorColor;
  context.fillRect(posX+1, posY+1, doorWidth-2, doorHeight-2);
  context.stroke();
}
