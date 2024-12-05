namespace AdventOfCode2024.Solvers {
    public class Template : ISolver {
        public void Solve() {
            Console.WriteLine("** Day message! **");
            int value = Parse("");
            Console.WriteLine($"Value is {value}.");
        }

        public int Parse(string path) {
            return -1;
        }
    }
}