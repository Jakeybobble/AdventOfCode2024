namespace AdventOfCode2024.Solvers {
    public class Day5 : ISolver {
        public void Solve() {
            Console.WriteLine("** Yeeow! Day 5 is on! **");
            int value = Parse("InputData/day5.txt");
            Console.WriteLine($"The answer is {value}!");
            
        }

        enum Mode {
            Rules, Updates
        }

        public int Parse(string path) {

            int sum = 0;

            Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
            Mode mode = Mode.Rules;
            foreach(string line in File.ReadAllLines(path)) {
                if(line == "") {
                    mode = Mode.Updates;
                    continue;
                }

                if(mode == Mode.Rules) { // Hmm. Enum. Not sure why I chose this.
                    int[] numbers = line.Split("|").Select(int.Parse).ToArray();

                    if (rules.TryGetValue(numbers[0], out List<int> rule_numbers)) {
                        rule_numbers.Add(numbers[1]);
                    }else{
                        rules[numbers[0]] = [numbers[1]];
                    }

                } else if(mode == Mode.Updates) {

                    int[] page_numbers = line.Split(",").Select(int.Parse).ToArray();
                    bool correct = true;
                    for(int i = 0; i < page_numbers.Length; i++) {
                        int num = page_numbers[i];
                        if(!rules.ContainsKey(num)) continue;
                        List<int> rule_numbers = rules[num];
                        if(page_numbers.Take(i).Intersect(rule_numbers).Any()) correct = false;
                    }

                    //Console.WriteLine($"{string.Join("-", page_numbers)}: {correct}");
                    if(correct) {
                        int middle_value = page_numbers[page_numbers.Length/2];
                        sum+=middle_value;
                    }

                }
            }

            return sum;
        }
    }
}