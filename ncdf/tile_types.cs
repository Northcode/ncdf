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
            //this.ascii = '░';
            this.ascii = ' ';
            this.backcolor = ConsoleColor.Green;
            this.forecolor = ConsoleColor.DarkGreen;
            this.type = 1;
        }
    }

    class tile_water : tile
    {
        public tile_water()
        {
            this.ascii = ' ';
            this.backcolor = ConsoleColor.Blue;
            this.forecolor = ConsoleColor.White;
            this.type = 2;
        }
    }

    class tile_rock : tile
    {
        public tile_rock()
        {
            this.ascii = '#';
            this.backcolor = ConsoleColor.DarkGray;
            this.forecolor = ConsoleColor.Gray;
            this.type = 3;
        }
    }

    class tile_forest : tile
    {
        public tile_forest()
        {
            this.ascii = 'ÿ';
            this.forecolor = ConsoleColor.Green;
            this.backcolor = ConsoleColor.DarkGreen;
            this.type = 4;
        }
    }

    class tile_wood : tile
    {
        public tile_wood()
        {
            this.ascii = '-';
            this.backcolor = ConsoleColor.DarkRed;
            this.forecolor = ConsoleColor.DarkYellow;
            this.type = 5;
        }
    }
}
