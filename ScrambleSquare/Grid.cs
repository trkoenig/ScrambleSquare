using System;
using System.Collections.Generic;

/* 
 * 0 1 2
 * 3 4 5
 * 6 7 8
 */

namespace ScrambleSquare
{
    public class Grid
    {
        public Tile[,] Tiles { get; }
        public Grid(int w, int h, List<Tile> tiles)
        {
            this.Tiles = new Tile[h, w];
            int rowCount = 0;
            int colCount = 0;
            foreach (var t in tiles)
            {
                this.Tiles[rowCount, colCount] = t;
                if (colCount == w - 1)
                {
                    colCount = 0;
                    rowCount++;
                }
                else
                {
                    colCount++;
                }
            }
        }

        public int TileCount()
        {
            return Tiles.Length;
        }

        public Tuple<int, int> IndexesFromPosition(int pos)
        {
            var res = new Tuple<int, int>(pos / 3, pos % 3);
            return res;
        }

        public int PositionFromIndexes(Tuple<int, int> idx)
        {
            return (idx.Item1 * 3 + idx.Item2);
        }

        public Tile Tile(int pos)
        {
            return Tile(IndexesFromPosition(pos));
        }
                
        public Tile Tile(Tuple<int, int> idx)
        {
            return Tiles[idx.Item1, idx.Item2];
        }
                
        public Tile TileFromId(int id)
        {
            foreach (Tile t in Tiles)
            {
                if (t.Id == id) return t;
            }

            return null;
        }

        public bool Valid()
        {
            bool res = true;
            for (int i = 0; i < 9; i++)
            {
                res = res && TileValid(i);
            }
            return res;
        }

        //for now only works on 3x3 grids
        private bool TileValid(int pos)
        {
            Tile baseTile = Tile(pos);
            bool res = true;

            if (pos > 2)
            { //middle, bottom rows check Northern neighbors
                if (!TilesFitTogether(baseTile, Tile(pos - 3), 'N')) res = false;
            }
            if (pos % 3 != 0)
            { //middle, right columns check Western neighbors
                if (!TilesFitTogether(baseTile, Tile(pos - 1), 'W')) res = false;
            }
            if (pos % 3 != 2)
            { //left, middle columns check Eastern neighbors
                if (!TilesFitTogether(baseTile, Tile(pos + 1), 'E')) res = false;
            }
            if (pos < 5)
            { //middle, top rows check Southern neighbors
                if (!TilesFitTogether(baseTile, Tile(pos + 3), 'S')) res = false;
            }

            return res;
        }

        //direction = t2 in relation to t1
        private bool TilesFitTogether(Tile t1, Tile t2, char direction)
        {
            switch (direction)
            {
                case 'N':
                    return t1.NorthDescr == t2.SouthDescr;
                case 'E':
                    return t1.EastDescr == t2.WestDescr;
                case 'S':
                    return t1.SouthDescr == t2.NorthDescr;
                case 'W':
                    return t1.WestDescr == t2.EastDescr;
                default:
                    return false;
            }
        }

        public void SwapTiles(int pos1, int pos2)
        {
            if (pos1 == pos2) return;
   
            Tuple<int, int> idx1 = IndexesFromPosition(pos1);
            Tuple<int, int> idx2 = IndexesFromPosition(pos2);
            
            Tile tt = Tile(idx1);
            Tiles[idx1.Item1, idx1.Item2] = Tile(idx2);
            Tiles[idx2.Item1, idx2.Item2] = tt;
        }

        public void MoveTile(int tileId, int newPos)
        {
            Tuple<int, int> idx1;
            Tuple<int, int> idx2 = IndexesFromPosition(newPos);

            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if (Tiles[c, r].Id == tileId)
                    {
                        idx1 = new Tuple<int, int>(c, r);
                        SwapTiles(PositionFromIndexes(idx1), newPos);
                        return;
                    }
                }
            }
        }

        public void DrawGrid()
        {
            //todo: clean up (but making it neater might make it too hard to modify/understand...)
            
            if (Valid())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A solution:");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a solution:");
            }

            //draw a row of tiles
            for (int c = 0; c < 3; c++)
            {
                Tile t0 = Tiles[c, 0];
                Tile t1 = Tiles[c, 1];
                Tile t2 = Tiles[c, 2];

                string s = "";
                s += " ___________  ___________  ___________\n";
                s += $"|     {t0.NorthDescr}     ||     {t1.NorthDescr}     ||     {t2.NorthDescr}     |\n";
                s += "|           ||           ||           |\n";
                s += $"|{t0.WestDescr}    {t0.Id}    {t0.EastDescr}||{t1.WestDescr}    {t1.Id}    {t1.EastDescr}||{t2.WestDescr}    {t2.Id}    {t2.EastDescr}|\n";
                s += "|           ||           ||           |\n";
                s += $"|_____{t0.SouthDescr}_____||_____{t1.SouthDescr}_____||_____{t2.SouthDescr}_____|\n";
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}