namespace AdventOfCode2024.Solvers {
    public class Day4 : ISolver {
        public void Solve() {
            Console.WriteLine("** Waow it's day 4 **");
            (int xmas_count, int x_count) = Parse("InputData/day4.txt");
            Console.WriteLine($"XMAS count: {xmas_count}, X count: {x_count}!");
        }

        class Box {
            public int x; public int y; public char Character;
            public Box(int x, int y, char character) {
                this.x = x; this.y = y; this.Character = character;
            }
        }

        private static int width = 0;
        private static int height = 0;
        private static Box[,] boxes = new Box[0,0];

        private (int, int) Parse(string path) {
            int xmas_count = 0;
            int x_count = 0;

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
                        if(str == "XMAS") xmas_count++;
                    }
                    if(box.Character == 'A' && IsX(x,y)){
                        x_count++;
                    }

                }
                //Console.WriteLine();
            }

            return (xmas_count, x_count);
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

        private bool IsX(int x, int y) {
            if( // Not pretty
            (
                (Get(x-1,y-1)?.Character == 'M' && Get(x+1,y+1)?.Character == 'S')
                || (Get(x-1,y-1)?.Character == 'S' && Get(x+1,y+1)?.Character == 'M')
            ) &&
            (
                (Get(x+1,y-1)?.Character == 'M' && Get(x-1,y+1)?.Character == 'S')
                || (Get(x+1,y-1)?.Character == 'S' && Get(x-1,y+1)?.Character == 'M')
            )
            ) {
                return true;
            }
            return false;
        }
    }
}