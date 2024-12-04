using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solvers {
    public class Day3 : ISolver {
        public void Solve() {
            Console.WriteLine("** No way it's day 3!!!!!!!!! **");

            int answer = Parse("InputData/day3.txt");

            Console.WriteLine($"The answer is: {answer}!");

        }

        private int Parse(string path) {
            int total = 0;
            string mul = "mul(";

            string test = "";

            string input = File.ReadAllText(path);
            input+="a"; // Just add another character to not check index out of bounds
            for(int i = 0; i < input.Length; i++) {
                char c = input[i];
                if(c == mul[0]) {
                    string sub = input.Substring(i, mul.Length);
                    if(sub == mul) {
                        // Get numbers
                        int count = i+mul.Length;
                        string args = "";
                        while(count < input.Length) {
                            char n_c = input[count];
                            
                            if(char.IsDigit(n_c) || n_c == ',') {
                                args+=n_c;
                                count++;
                            }else{
                                break;
                            }

                        }
                        string hat = input.Substring(count,1);
                        if(hat == ")"){
                            int[] vals = args.Split(',').Select(v => int.Parse(v)).ToArray();
                            if(vals.Length == 2) {
                                total+=vals[0]*vals[1];
                            }
                            
                        }
                    }

                }


            }

            Console.WriteLine(test);

            return total;
        }
    }
}