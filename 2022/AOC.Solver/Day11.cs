using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver;

public static class Day11
{
    public static ulong SolvePart1(string input)
    {
        var monkeys = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries).Select(s => new Monkey(s)).ToArray();

        for (var round = 0; round < 20; round++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.Turn(monkeys, reduceWorryLevel: true, 0);
            }
        }

        return monkeys
            .Select(m => m.NumberOfInspectionsMade)
            .OrderByDescending(m => m)
            .Take(2)
            .Aggregate(1UL, (a, b) => a * b);
    }

    public static ulong SolvePart2(string input)
    {
        var monkeys = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries).Select(s => new Monkey(s)).ToArray();
        var lcm = monkeys.Select(m => m.TestValue).Aggregate(LeastCommonMultiple);

        for (var round = 0; round < 10_000; round++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.Turn(monkeys, reduceWorryLevel: false, lcm);
            }
        }

        return monkeys
            .Select(m => m.NumberOfInspectionsMade)
            .OrderByDescending(m => m)
            .Take(2)
            .Aggregate(1UL, (a, b) => a * b);
    }

    private static uint GreatestCommonDivisor(uint a, uint b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    private static uint LeastCommonMultiple(uint a, uint b) => a / GreatestCommonDivisor(a, b) * b;
}

public class Monkey
{
    private readonly Queue<ulong> _items;

    private readonly WorryMathOperation _operationType;

    private readonly uint _operationValue;

    private readonly uint _trueTarget;

    private readonly uint _falseTarget;

    public ulong NumberOfInspectionsMade { get; private set; } = 0;

    public uint TestValue { get; }

    public Monkey(string input)
    {
        var re = new Regex(
            @"Monkey (\d+):\s+Starting items: ([\d, ]+)\s+Operation: new = old (\*|\+) (old|\d+)\s+Test: divisible by (\d+)\s+If true: throw to monkey (\d+)\s+If false: throw to monkey (\d+)");

        var matches = re.Match(input);
        _items = new Queue<ulong>(matches.Groups[2].Value.Split(",", StringSplitOptions.TrimEntries).Select(ulong.Parse));
        _operationType = matches.Groups[3].Value switch
        {
            "+" => WorryMathOperation.Add,
            "*" => WorryMathOperation.Multiply,
            _ => throw new ArgumentOutOfRangeException(),
        };
        _operationValue = matches.Groups[4].Value == "old" ? 0 : uint.Parse(matches.Groups[4].Value);
        TestValue = uint.Parse(matches.Groups[5].Value);
        _trueTarget = uint.Parse(matches.Groups[6].Value);
        _falseTarget = uint.Parse(matches.Groups[7].Value);
    }

    public void Turn(Monkey[] monkeys, bool reduceWorryLevel, ulong lcm)
    {
        while (_items.Any())
        {
            NumberOfInspectionsMade += 1;

            var item = _items.Dequeue();
            switch (_operationType)
            {
                case WorryMathOperation.Add:
                    checked
                    {
                        item += _operationValue == 0 ? item : _operationValue;
                    }
                    break;
                case WorryMathOperation.Multiply:
                    checked
                    {
                        item *= _operationValue == 0 ? item : _operationValue;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (reduceWorryLevel)
            {
                item /= 3;
            }
            else
            {
                item %= lcm;
            }

            if (item % TestValue == 0)
            {
                monkeys[_trueTarget].Catch(item);
            }
            else
            {
                monkeys[_falseTarget].Catch(item);
            }
        }
    }

    private void Catch(ulong item)
    {
        _items.Enqueue(item);
    }

    private enum WorryMathOperation
    {
        Multiply,
        Add,
    }
}
