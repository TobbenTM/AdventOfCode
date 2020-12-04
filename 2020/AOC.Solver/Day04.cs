using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day04
    {
        public static int SolvePart1(string input)
        {
            var passports = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            return passports.Count(passport => IsValidPassport(passport));
        }

        public static int SolvePart2(string input)
        {
            var passports = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            return passports.Count(passport => IsValidPassport(passport, validateValues: true));
        }

        public static bool IsValidPassport(string passport, bool validateValues = false)
        {
            var fields = passport.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]);
            var requiredKeys = new List<string>
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
            };

            var hasAllKeys = requiredKeys.All(key => fields.ContainsKey(key));
            if (!validateValues)
            {
                return hasAllKeys;
            }

            try
            {
                var byr = int.Parse(fields["byr"]);
                var iyr = int.Parse(fields["iyr"]);
                var eyr = int.Parse(fields["eyr"]);
                var hgtVal = int.Parse(fields["hgt"].Trim('c', 'm', 'i', 'n'));
                var hgtUnit = fields["hgt"].Substring(fields["hgt"].Length - 2, 2);
                var hclRe = new Regex("#[0-9a-f]{6}");
                var eclColors = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                var pidRe = new Regex("[0-9]{9}");
                return hasAllKeys
                    && byr >= 1920 && byr <= 2002
                    && iyr >= 2010 && iyr <= 2020
                    && eyr >= 2020 && eyr <= 2030
                    && (hgtUnit == "cm" && hgtVal >= 150 && hgtVal <= 193 || hgtUnit == "in" && hgtVal >= 59 && hgtVal <= 76)
                    && fields["hcl"].Length == 7 && hclRe.IsMatch(fields["hcl"])
                    && fields["ecl"].Length == 3 && eclColors.Contains(fields["ecl"])
                    && fields["pid"].Length == 9 && pidRe.IsMatch(fields["pid"]);
            }
            catch
            {
                return false;
            }
        }
    }
}
