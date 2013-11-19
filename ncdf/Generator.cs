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
    }
}
