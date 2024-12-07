using AdventOfCode2024.Solvers;

namespace AdventOfCode2024 {
    public class SolverFactory {
        public static ISolver GetSolver(int day)
        {
            return day switch {
                1 => new Day1(),
                2 => new Day2(),
                3 => new Day3(),
                4 => new Day4(),
                5 => new Day5(),
                6 => new Day6(),
                7 => new Day7(),
                _ => throw new Exception("No such day!")
            };
        }

    }
}