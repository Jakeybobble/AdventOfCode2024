namespace AdventOfCode2024.Solvers {
    public class Day4 : ISolver {
        public void Solve() {
            Console.WriteLine("** Waow it's day 4 **");
            int answer = Parse("InputData/day4.txt");
            Console.WriteLine($"The answer appears to be {answer}...!");
        }

        class Box {
            public int x; public int y; public char Character;
            public bool Enabled = false;
            public Box(int x, int y, char character) {
                this.x = x; this.y = y; this.Character = character;
            }
        }

        private static int width = 0;
        private static int height = 0;
        private static Box[,] boxes;

        private int Parse(string path) {
            int count = 0;

            int[] dx = { 1, 1, 0, -1, -1, -1, 0, 1 }; // Horizontal steps
            int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 }; // Vertical steps
            

            string[] lines = File.ReadAllLines(path);
            width = lines[0].Length;
            height = lines.Length;

            boxes = new Box[width,height];

            for(int y = 0; y < height; y++) {
                for(int x = 0; x < width; x++) {
                    boxes[x,y] = new Box(x,y,lines[y][x]);
                }
            }

            for(int y = 0; y < height; y++) {
                for(int x = 0; x < width; x++) {
                    Box box = boxes[x,y];
                    // Check in all directions
                    for(int i = 0; i < 8; i++) {
                        string str = GetString(x,y,dx[i], dy[i]);
                        if(str == "XMAS") count++;
                    }
                }
                //Console.WriteLine();
            }

            /* Test...
            for(int i = 0; i < 8; i++) {
                string str = GetString(0,0,dx[i], dy[i]);
                Console.WriteLine(str);
            }
            */

            // Draw all
            for(int y = 0; y < height; y++) {
                for(int x = 0; x < width; x++) {
                    Box box = boxes[x,y];
                    char symbol = box.Enabled ? box.Character : '.';
                    Console.Write(symbol);
                    
                }
                Console.WriteLine();
            }

            return count;
        }

        private Box? Get(int x, int y) {
            if(x < 0 || x > width-1 || y < 0 || y > height-1) return null;
            return boxes[x,y];
        }

        private string GetString(int x, int y, int dx, int dy) {
            string str = "";
            for(int i = 0; i < 4; i++) {
                Box box = Get(x + dx*i, y + dy*i)!;
                if(box != null) {
                    str+=box.Character;
                }
            }
            return str;
        }
    }
}