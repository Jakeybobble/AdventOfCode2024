namespace AdventOfCode2024.Solvers {
    public class Day7 : ISolver {
        public void Solve() {
            Console.WriteLine("** It'sa day of 7's! Yiyiyiyppeeeeeeeee **");
            long value = Parse("InputData/day7.txt");
            Console.WriteLine($"Value is {value}.");
        }

        public long Parse(string path) {
            long sum = 0;

            var input = File.ReadAllLines(path);
            // I've never parsed anything like this before, it's pretty fun.
            // It's inspired by bettercallsean's AoC2024 Day05.cs
            Dictionary<long, long[]> tests = input.Select(l => l.Split(": ").ToList())
            .Select(v => (v[0], v[1]))
            .ToDictionary(v => long.Parse(v.Item1), v => v.Item2.Split(" ").Select(long.Parse).ToArray());

            foreach(var (testValue, testNumbers) in tests) {
                //Console.WriteLine($"{testValue}: {string.Join(", ", testNumbers)}");

                // Generate a stack of all the possible operations we want to do
                Stack<char[]> operationSequences = new Stack<char[]>();
                int length = testNumbers.Length - 1;
                for(int i=0; i < Math.Pow(2, length); i++) {
                    string binaryString = Convert.ToString(i, 2).PadLeft(length, '0');
                    operationSequences.Push(binaryString.Replace('0', '+').Replace('1', '*').ToCharArray());

                }

                // Consume all operations
                while(operationSequences.Count > 0) {
                    //Console.WriteLine("");
                    Stack<char> sequence = new Stack<char>(operationSequences.Pop());
                    
                    Stack<long> ints = new Stack<long>(testNumbers.Reverse());

                    bool valid = true;
                    while(ints.Count > 1 && valid) {
                        long first = ints.Pop();
                        long second = ints.Pop();
                        char op = sequence.Pop();
                        //Console.WriteLine($"Calculated {first} {op} {second}");

                        long operationResult = op switch {
                            '+' => first + second,
                            '*' => first * second,
                            _ => 0
                        };

                        if (operationResult > testValue) {
                            valid = false;
                            break;
                        }

                        ints.Push(operationResult);
                    }

                    if (!valid) continue;

                    long result = ints.Pop();
                    if(result == testValue){
                        //Console.WriteLine(result);
                        sum+=result;
                        break;
                    }

                }

            }
            
            return sum;
        }
    }
}