using System;
using System.Collections.Generic;


namespace ScrambleSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int mi = 0;
                        
            while (mi != 3)
            {
                mi = MenuInput();

                const int tileCount = 9;
                List<Tile> allTiles = new List<Tile>();

                if (mi == 1)
                {
                    GetUserTiles(tileCount, allTiles);
                }
                else if (mi == 2)
                {
                    GetPredefinedTiles(allTiles);
                }
                else
                {
                    continue;
                }

                Grid Gr = new Grid(3, 3, allTiles);

                SolutionFinder Sf = new SolutionFinder(Gr);
                Sf.FindSolution();
                Sf.InConclusion();              
            }
        }
        
        static void GetUserTiles(int tc, List<Tile> tiles)
        {
            for (int i = 1; i <= tc; i++)
            {
                Console.WriteLine($"Clockwise from 12:00, what is on each side of tile #{i}?");
                Console.WriteLine("   (one character per side, please)");
                string nd = Console.ReadLine();
                string ed = Console.ReadLine();
                string sd = Console.ReadLine();
                string wd = Console.ReadLine();
                tiles.Add(new Tile(nd, ed, sd, wd, i));
            }
        }

        static void GetPredefinedTiles(List<Tile> tiles) {
            tiles.Add(new Tile("D", "A", "A", "D", 1));
            tiles.Add(new Tile("A", "B", "C", "D", 2));
            tiles.Add(new Tile("C", "A", "D", "B", 3));
            tiles.Add(new Tile("C", "B", "D", "A", 4));
            tiles.Add(new Tile("D", "C", "A", "B", 5));
            tiles.Add(new Tile("A", "D", "C", "B", 6));
            tiles.Add(new Tile("A", "C", "D", "B", 7));
            tiles.Add(new Tile("D", "B", "C", "A", 8));
            tiles.Add(new Tile("D", "A", "A", "D", 9));
        }

        static int MenuInput()
        {
            int x = 0;
            
            Console.WriteLine("============================================");
            Console.WriteLine("        MENU        ");
            Console.WriteLine("1) Enter your own tiles");
            Console.WriteLine("2) See this thing work on predefined tiles");
            Console.WriteLine("3) Exit");
            Console.WriteLine("============================================");

            ConsoleKeyInfo UserInput = Console.ReadKey();
            Console.WriteLine();

            if (char.IsDigit(UserInput.KeyChar))
            {
                x = int.Parse(UserInput.KeyChar.ToString());
            }

            return x;
        }
    }
}
