using AdventOfCode2024.Solvers;

namespace AdventOfCode2024 {
    public class SolverFactory {
        public static ISolver GetSolver(int day)
        {
            return day switch {
                1 => new Day1(),
                2 => new Day2(),
                3 => new Day3(),
                _ => throw new Exception("No such day!")
            };
        }

    }
}