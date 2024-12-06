namespace AdventOfCode2024.Solvers {
    public class Day6 : ISolver {
        public void Solve() {
            Console.WriteLine("** Waowaowaowao no way it's the 6 of days! **");
            int value = Parse("InputData/day6.txt");
            Console.WriteLine($"Value is {value}.");
        }

        class Tile {
            public enum TileType {
                Empty = '.', Solid = '#', Walked = 'X'
            }

            public TileType tileType = TileType.Empty;
            public Tile(char c) {
                switch(c) {
                    case '#': tileType = TileType.Solid; break;
                    default: tileType = TileType.Empty; break;
                }
            }
            
        }

        public int Parse(string path) {
            int spaces = 0;
            string[] input = File.ReadAllLines(path);

            (int,int) guardPos = (0,0);
            int guardDirection = 0;

            Tile[,] tiles = new Tile[input[0].Length,input.Length];

            for(int y = 0; y < input.Length; y++) {
                string line = input[y];
                for(int x = 0; x < line.Length; x++) {
                    char c = line[x];
                    tiles[x,y] = new Tile(c);
                    if(c == '^') guardPos = (x,y);

                }
            }
            
            (int, int)[] step = {(0, -1), (1, 0), (0, 1), (-1, 0)}; // Up right down left
            while(true) {
                tiles[guardPos.Item1,guardPos.Item2].tileType = Tile.TileType.Walked;

                var nextPos = (guardPos.Item1 + step[guardDirection].Item1, guardPos.Item2 + step[guardDirection].Item2);
                if(nextPos.Item1 < 0 || nextPos.Item1 >= tiles.GetLength(0) || nextPos.Item2 < 0 || nextPos.Item2 >= tiles.GetLength(1)) {
                    break;
                }
                Tile nextTile = tiles[nextPos.Item1, nextPos.Item2];
                if(nextTile.tileType == Tile.TileType.Solid){
                    guardDirection = (guardDirection + 1) % 4;
                }else{
                    guardPos = nextPos;
                }
                Console.WriteLine(guardPos);
                
            }

            spaces = tiles.Cast<Tile>().Count(a => a.tileType == Tile.TileType.Walked);
            return spaces;
        }
    }
}