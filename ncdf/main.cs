using System;
using System.Text;
using System.Threading;

namespace ncdf
{
	class prg
	{
        public static Random randGen;

		static void Main(string[] args)
		{
            Console.Write("Width (max. 200): ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height (max. 70): ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Terrain scale (1-100): ");
            int islandsize = Convert.ToInt32(Console.ReadLine());

            tiles.width = width;
            tiles.height = height;
            Console.BufferWidth = width + 5;
            Console.WindowWidth = width + 1;
            Console.BufferHeight = height + 5;
            Console.WindowHeight = height + 1;

            randGen = new Random(DateTime.Now.Millisecond);

            while (true)
            {
                tiles.init();
                Generator.xoffset = randGen.Next(0, 500);
                Generator.yoffset = randGen.Next(0, 500);
                Generator.FillWater();
                Generator.generateGrass(islandsize);
                Generator.generateForest(islandsize);
                Generator.generateRock(islandsize);
                tiles.OutputTiles();
                Console.ReadKey();
            }
		}
	}
}