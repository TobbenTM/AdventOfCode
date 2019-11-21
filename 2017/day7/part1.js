const fs = require('fs');
const path = require('path');

const inputFile = path.join(__dirname, 'input.txt');

fs.readFile(inputFile, 'utf8', function(err, contents) {
  const lines = contents.split('\n');

});

class Program {
  constructor(input) {
    const pattern = /^(\w+) (\(\d+\))(?: -> (?:(\w+)(?:, )?)+)?$/;
  }
}
