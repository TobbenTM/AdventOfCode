namespace AOC.Solver.IntcodeComputer
{
    public enum OpCode
    {
        Unknown = 0,
        Add = 1,
        Multiply = 2,
        Assign = 3,
        Output = 4,
        JumpIfPositive = 5,
        JumpIfZero = 6,
        CompareLessThan = 7,
        CompareEquals = 8,
        SetRelativeBase = 9,
        Halt = 99,
    }
}
