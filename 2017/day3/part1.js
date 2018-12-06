const input = 361527;
let x = 0, y = 0, n = 1;
let rank = 0;

loop();

function loop() {
  while (true) {
    // Move into first
    if (move(1, 0)) return;
    rank += 1;
  
    // Move up
    for (var i = 0; i < rank; i++) {
      if (move(0, -1)) return;
    }
    // Move left
    for (var i = 0; i < rank+1; i++) {
      if (move(-1, 0)) return;
    }
    // Move down
    for (var i = 0; i < rank+1; i++) {
      if (move(0, 1)) return;
    }
    // Move right
    for (var i = 0; i < rank+1; i++) {
      if (move(1, 0)) return;
    }
  
    rank += 1;
  }
}

console.log(`Final position: ${x},${y}, distance: ${Math.abs(x)+Math.abs(y)}`);

function move(xdiff, ydiff) {
  n += 1;
  x += xdiff;
  y += ydiff;
  if (n >= input) {
    return true;
  }
  return false;
}
