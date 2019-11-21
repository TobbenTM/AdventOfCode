const fs = require('fs');
const path = require('path');

const inputFile = path.join(__dirname, 'input.txt');

fs.readFile(inputFile, 'utf8', function(err, contents) {
  const banks = contents.split('\t').map(s => parseInt(s));
  let history = {
    [banks.join()]: true,
  };
  let steps = 0;
  while(true) {
    steps += 1;
    redistribute(banks);
    if (history[banks.join()]) {
      break;
    }
    history[banks.join()] = steps;
  }
  console.log(`Done redistributing, found ${banks.join()} again after ${steps} steps (${steps-history[banks.join()]} since last time).`);
});

function redistribute(banks) {
  const max = Math.max(...banks);
  let index = banks.indexOf(max);

  let quantity = banks[index];
  banks[index] = 0;

  while (quantity > 0) {
    index += 1;
    banks[index % banks.length] += 1;
    quantity -= 1;
  }
}
