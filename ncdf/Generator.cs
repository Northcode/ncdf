using SimplexNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    static class Generator
    {
        public static float xoffset = 0;
        public static float yoffset = 0;

        public static void FillWater()
        {
            for (int i = 0; i < tiles.width * tiles.height; i++)
            {
                tiles.set(i, new tile_water());
            }
        }

        public static void generateGrass(int size)
        {
            for (int y = 0; y < tiles.height; y++)
            {
                for (int x = 0; x < tiles.width; x++)
                {
                    float data = Noise.Generate((float)(x + xoffset) / (size), (float)(y + yoffset) / (size), 0f);
                    if (data > 0)
                    {
                        tiles.set(x, y, new tile_grass());
                    }
                }
            }
        }

        public static void generateRock(int size)
        {
            for (int y = 0; y < tiles.height; y++)
            {
                for (int x = 0; x < tiles.width; x++)
                {
                    float data = Noise.Generate((float)(x + xoffset) / (size), (float)(y + yoffset) / (size), 10f);
                    float data2 = Noise.Generate((float)(x + xoffset) / (size), (float)(y + yoffset) / (size), 5f);
                    if (data > 0)
                    {
                        if (tiles.get(x,y) != null && tiles.get(x, y).type == 1 && data2 > 0)
                        { tiles.set(x, y, new tile_rock()); }
                    }
                }
            }
        }

        public static void generateForest(int size)
        {
            for (int y = 0; y < tiles.height; y++)
            {
                for (int x = 0; x < tiles.width; x++)
                {
                    float data = Noise.Generate((float)(x + xoffset) / (size), (float)(y + yoffset) / (size), 3f);
                    float data2 = Noise.Generate((float)(x + xoffset) / (size), (float)(y + yoffset) / (size), 7f);
                    if (data > 0)
                    {
                        if (tiles.get(x, y) != null && tiles.get(x, y).type == 1 && data2 > 0)
                        { tiles.set(x, y, new tile_forest()); }
                    }
                }
            }
        }
    }
}
