using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    class tile_grass : tile
    {
        public tile_grass()
        {
            this.ascii = '-';
            this.backcolor = ConsoleColor.DarkGreen;
            this.forecolor = ConsoleColor.Green;
        }
    }

    class tile_water : tile
    {
        public tile_water()
        {
            this.ascii = ' ';
            this.backcolor = ConsoleColor.Blue;
            this.forecolor = ConsoleColor.White;
        }
    }
}
