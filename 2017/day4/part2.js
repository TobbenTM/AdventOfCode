const fs = require('fs');
const path = require('path');

const inputFile = path.join(__dirname, 'input.txt');

fs.readFile(inputFile, 'utf8', function(err, contents) {
  const passphrases = contents.split('\n');
  const validPassphrases = passphrases.reduce((acc, pw) => {
    try {
      if (isValidPassphrase(pw)) {
        return acc + 1;
      } else {
        return acc;
      }
    } catch(_) {
      return acc;
    }
  }, 0);
  console.log(`Found ${validPassphrases} valid passphrases out of ${passphrases.length} possible.`);
});

function isValidPassphrase(passphrase) {
  const words = passphrase.split(' ');
  let wordmap = {};
  words.forEach((word) => {
    if (wordmap[sortWord(word)]) throw 'Duplicate word found';
    wordmap[sortWord(word)] = true;
  });
  return true;
}

function sortWord(word) {
  return word.split('').sort().join('');
}
