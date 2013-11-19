using System;
using System.Threading;

namespace ncdf
{
	class prg
	{
        public static Random randGen;

		static void Main(string[] args)
		{
            Console.Write("Width (max. 120): ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height (max. 60): ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of islands: ");
            int islands = Convert.ToInt32(Console.ReadLine());
            Console.Write("Island size (rec. 15-20): ");
            int islandsize = Convert.ToInt32(Console.ReadLine());

            tiles.width = width;
            tiles.height = height;
            Console.BufferWidth = width + 5;
            Console.WindowWidth = width + 1;
            Console.BufferHeight = height + 5;
            Console.WindowHeight = height + 1;

            while (true)
            {
                tiles.init();
                randGen = new Random(DateTime.Now.Millisecond);
                Generator.FillWater();
                for (int i = 0; i < islands; i++)
                {
                    Generator.generateGrass(islandsize);
                }
                tiles.OutputTiles();
                Console.ReadKey();
            }
		}
	}
}