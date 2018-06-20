using System;
using System.Collections.Generic;

namespace ScrambleSquare
{
    public class Tile 
    {
        public string NorthDescr { get; set; }
        public string EastDescr { get; set; }
        public string SouthDescr { get; set; }
        public string WestDescr { get; set; }
        public int Id { get; }

        public Tile(string northDescr, string eastDescr, string southDescr, string westDescr, int id) 
        {
            this.NorthDescr = northDescr;
            this.EastDescr = eastDescr;
            this.SouthDescr = southDescr;
            this.WestDescr = westDescr;
            this.Id = id;
        }

        public void RotateTile() //always clockwise 
        {
            string t = NorthDescr;
            NorthDescr = WestDescr;
            WestDescr = SouthDescr;
            SouthDescr = EastDescr;
            EastDescr = t;
        }
    } 
}