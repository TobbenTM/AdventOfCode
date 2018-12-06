const input = 361527;
let map = [
  [1]
];
let x = 0, y = 0;
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

console.log(`Final position: ${x},${y}, distance: ${Math.abs(x)+Math.abs(y)}, number: ${map[x][y]}`);

function move(xdiff, ydiff) {
  x += xdiff;
  y += ydiff;
  if (!map[x]) {
    map[x] = [];
  }
  if (map[x][y]) {
    throw 'Map location already in use!'
  }
  const val = getAdjacents().reduce((acc, n) => acc + (n || 0), 0);
  map[x][y] = val;
  if (val > input) {
    return true;
  }
  return false;
}

function getAdjacents() {
  if (!map[x+1]) {
    map[x+1] = [];
  }
  if (!map[x-1]) {
    map[x-1] = [];
  }
  return [
    map[x-1][y-1],
    map[x+0][y-1],
    map[x+1][y-1],
    map[x-1][y],
    map[x+1][y],
    map[x-1][y+1],
    map[x+0][y+1],
    map[x+1][y+1]
  ];
}
