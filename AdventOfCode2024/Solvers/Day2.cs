namespace AdventOfCode2024.Solvers {
    public class Day2 : ISolver {

        // I'd like to rewrite this one in a better way, possibly with more LINQ

        public void Solve() {
            Console.WriteLine("** Hooray! Day 2! **");

            int safe_reports = Parse("InputData/day2.txt");

            Console.WriteLine($"{safe_reports} of the reports are safe!");
        }

        private int Parse(string path) {

            int safe_reports = 0;

            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines) {
                List<int> values = line.Split(" ").Select(s => int.Parse(s)).ToList();

                bool is_safe = true;

                int error_index = get_bad_index(values);

                if(error_index != -1) {
                    //Console.WriteLine($"Error found at index {1+error_index} ({values[error_index]}) in {string.Join(" ", values)}!");
                    bool fixed_it = false;
                    for(int i = 0; i < values.Count; i++) {
                        List<int> new_values = new List<int>(values);
                        new_values.RemoveAt(i);
                        if (get_bad_index(new_values) == -1) {
                            //Console.WriteLine($"Fixed: {string.Join(" ", new_values)}");
                            fixed_it = true;
                            break;
                        }
                    }
                    if(!fixed_it) is_safe = false;

                }

                if(is_safe) safe_reports++;
                //Console.WriteLine();

            }

            return safe_reports;
        }

        // Returns index of bad value, otherwise -1
        private int get_bad_index(List<int> values) {
            int direction = 0;
            for(int i = 1; i < values.Count; i++) {
                (int val, int prev) = (values[i], values[i-1]);
                int difference = val - prev;
                if(i == 1) {
                    direction = Math.Sign(difference);
                }

                if(Math.Abs(difference) > 3 || Math.Abs(difference) < 1 || Math.Sign(difference) != direction) {
                    return i;
                }

            }
            return -1;
            

        }
    }
}