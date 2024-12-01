using AdventOfCode2024.Solvers;

namespace AdventOfCode2024 {
    public class SolverFactory {
        public static ISolver GetSolver(int day)
        {
            return day switch {
                1 => new Day1(),
                _ => throw new Exception("No such day!")
            };
        }

    }
}