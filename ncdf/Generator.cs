using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    static class Generator
    {
        public static void FillWater()
        {
            for (int i = 0; i < tiles.width * tiles.height; i++)
            {
                tiles.set(i, new tile_water());
            }
        }

        public static void generateGrass(int size)
        {
            tile t = new tile_grass();
            tiles.set(prg.randGen.Next(0, tiles.width), prg.randGen.Next(0, tiles.height), t);
            t.Spread(prg.randGen, size);
        }

        public static void generateRock(int size)
        {
            tile t = new tile_rock();
            int x = prg.randGen.Next(0,tiles.width);
            int y = prg.randGen.Next(0,tiles.height);
            while (tiles.get(x,y).type != 1)
            {
                x = prg.randGen.Next(0, tiles.width);
                y = prg.randGen.Next(0, tiles.height);
            }
            tiles.set(x, y, t);
            t.Spread(prg.randGen, size);
        }
    }
}
