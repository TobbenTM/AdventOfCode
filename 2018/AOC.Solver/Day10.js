const fs = require('fs');
const path = require('path');

const inputFile = path.join(__dirname, 'Day10.input');
const outputFile = path.join(__dirname, 'Day10.output');

fs.readFile(inputFile, 'utf8', function (err, contents) {
  const stars = contents.split('\n').map(s => parseStar(s));
  let iterations = 0;
  while (true) {
    const map = isInterestingFormation(stars);
    if (map) {
      // printStarField(stars, map.xorigin, map.yorigin, map.xend, map.yend);
      writeStarField(stars, map.xorigin, map.yorigin, map.xend, map.yend);
      console.log(`Interesting map at iteration #${iterations}..`);
    }
    stars.forEach(s => s.pos.x += s.vel.x);
    stars.forEach(s => s.pos.y += s.vel.y);
    iterations += 1;
    if (iterations % 1000 === 0) {
      console.log(`Reached ${iterations} iterations..`);
    }
  }
});

function isInterestingFormation(stars) {
  const totalPos = stars.reduce((sum, cur) => ({
    x: sum.x + cur.pos.x,
    y: sum.y + cur.pos.y,
  }), { x: 0, y: 0 });
  const averagePos = {
    x: totalPos.x / stars.length,
    y: totalPos.y / stars.length,
  };

  const starsInRange = stars.filter(s => Math.abs(s.pos.y - averagePos.y) < 10);
  
  if (starsInRange.length > stars.length * 0.5) {
    const xpos = starsInRange.map(s => Math.floor(s.pos.x));
    const ypos = starsInRange.map(s => Math.floor(s.pos.y));

    const map = {
      xorigin: Math.min(...xpos),
      xend: Math.max(...xpos) + 1,
      yorigin: Math.min(...ypos),
      yend: Math.max(...ypos) + 1,
    }
    return map;
  }
  return false;
}

function printStarField(stars, xorigin, yorigin, xend, yend) {
  console.clear();
  for (var yi = yorigin; yi < yend; yi++) {
    let line = '';
    for (var xi = xorigin; xi < xend; xi++) {
      line += stars.some(s => s.pos.x === xi && s.pos.y === yi) ? '#' : '.';
    }
    console.log(line);
  }
}

function writeStarField(stars, xorigin, yorigin, xend, yend) {
  let contents = '';
  for (var yi = yorigin; yi < yend; yi++) {
    let line = '';
    for (var xi = xorigin; xi < xend; xi++) {
      line += stars.some(s => s.pos.x === xi && s.pos.y === yi) ? '#' : '.';
    }
    contents += line;
    contents += '\n';
  }
  fs.writeFileSync(outputFile, contents);
}

function parseStar(input) {
  const re = /position=<(-? ?\d+), (-? ?\d+)> velocity=<( ?-?\d), ( ?-?\d)>/;
  const match = re.exec(input);
  if (!match || match.length < 5) throw 'Could not parse input! Line: ' + input;
  return {
    pos: {
      x: parseInt(match[1]),
      y: parseInt(match[2]),
    },
    vel: {
      x: parseInt(match[3]),
      y: parseInt(match[4]),
    },
  };
}
