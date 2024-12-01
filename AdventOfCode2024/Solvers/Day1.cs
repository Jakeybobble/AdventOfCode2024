namespace AdventOfCode2024.Solvers {
    public class Day1 : ISolver
    {
        public void Solve()
        {
            Console.WriteLine("** Wohoo! Day 1 of Advent of Code! **");

            int total_distance = Parse("InputData/day1.txt");

            Console.WriteLine($"The total distance is {total_distance}!");

        }

        private int Parse(string path)
        {
            int total_distance = 0;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            using(StreamReader file = new StreamReader(path)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    string[] parts = line.Split("   ");
                    left.Add(int.Parse(parts[0]));
                    right.Add(int.Parse(parts[1]));
                }
                file.Close();
            }

            left.Sort();
            right.Sort();

            for(int i = 0; i < left.Count; i++) {
                int distance = Math.Abs(left[i] - right[i]);
                total_distance += distance;
            }
            return total_distance;

        }
    }
}