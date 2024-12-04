namespace AdventOfCode2024.Solvers {
    public class Day2 : ISolver {
        public void Solve() {
            Console.WriteLine("** Hooray! Day 2! **");

            int safe_reports = Parse("InputData/day2.txt");

            Console.WriteLine($"{safe_reports} of the reports are safe!");
        }

        private int Parse(string path) {

            int safe_reports = 0;

            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines) {
                int[] values = line.Split(" ").Select(s => int.Parse(s)).ToArray();
                
                bool safe = true;
                int dir = 0;
                for(int i = 1; i < values.Length; i++) {
                    int value = values[i];
                    int last = values[i-1];

                    int difference = value - last;
                    int sign = Math.Sign(difference);
                    if(i == 1) { // If beginning of loop
                        dir = sign;
                    }

                    if(sign != dir || Math.Abs(difference) > 3) {
                        safe = false; break;
                    }

                }
                if(safe) safe_reports++;


            }

            return safe_reports;
        }
    }
}