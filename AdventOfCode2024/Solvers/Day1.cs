namespace AdventOfCode2024.Solvers {
    public class Day1 : ISolver
    {
        public void Solve()
        {
            Console.WriteLine("** Wohoo! Day 1 of Advent of Code! **");

            (int total_distance, int similarity_score) = Parse("InputData/day1_Sample.txt");

            Console.WriteLine($"The total distance is {total_distance} and the similarity score is {similarity_score}!");

        }

        private (int, int) Parse(string path)
        {
            int total_distance = 0;
            int similarity_score = 0;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines) {
                string[] parts = line.Split("   ");
                left.Add(int.Parse(parts[0]));
                right.Add(int.Parse(parts[1]));
            }

            left.Sort();
            right.Sort();

            for(int i = 0; i < left.Count; i++) {
                int distance = Math.Abs(left[i] - right[i]);
                int similarity = left[i] * right.Count(m => m == left[i]);

                total_distance += distance;
                similarity_score += similarity;

            }


            return (total_distance, similarity_score);

        }
    }
}