const fs = require('fs');
const path = require('path');

const inputFile = path.join(__dirname, 'input.txt');

fs.readFile(inputFile, 'utf8', function(err, contents) {
  const instructions = contents.split('\n').map(s => parseInt(s));
  const steps = machine(instructions);
  console.log(`${steps} taken to exit the stack`);
});

function machine(instructions) {
  let pointer = 0;
  let steps = 0;
  while (true) {
    const next = instructions[pointer] + pointer;

    // console.log(`Jumping ${instructions[pointer]} steps from pointer ${pointer}..`)

    if (next >= instructions.length || next < 0) {
      return steps + 1;
    }

    instructions[pointer] += 1;
    pointer = next;
    steps += 1;
  }
}
