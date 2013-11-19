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
            Console.WindowHeight = height + 2;

            randGen = new Random(DateTime.Now.Millisecond);

            var run = true;

            while (run)
            {
                tiles.init();
                Generator.xoffset = randGen.Next(0, 500);
                Generator.yoffset = randGen.Next(0, 500);
                Generator.FillWater();
                Generator.generateGrass(islandsize);
                Generator.generateForest(islandsize);
                Generator.generateRock(islandsize);
                tiles.OutputTiles();
                Console.SetCursorPosition(0, height);
                Console.Write("1: Regenerate  2: Done          ");
                var key = Console.ReadKey();
                run = (key.Key == ConsoleKey.D1);
            }

            Player p = new Player();

            int n = 0;
            var b = true;
            while (b)
            {
                if (tiles.get(n) != null)
                {
                    b = tiles.get(n).type != 1;
                    n++;
                }
            }

            tile t = tiles.get(n);
            int x = t.GetXY()[0], y = t.GetXY()[1];
            p.SetPos(x,y);
            p.SetLastPos(x,y);

            run = true;
            tiles.OutputTiles();
            while (run)
            {
                p.Output();
                Console.SetCursorPosition(0, height);
                Console.Write("wasd: move  q: exit e: buildmode (" + (p.buildmode ? "on" : "off") + ")");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.W)
                {
                    p.Move(0);
                }
                else if (key.Key == ConsoleKey.D)
                {
                    p.Move(1);
                }
                else if (key.Key == ConsoleKey.S)
                {
                    p.Move(2);
                }
                else if (key.Key == ConsoleKey.A)
                {
                    p.Move(3);
                }
                else if (key.Key == ConsoleKey.E)
                {
                    p.buildmode = !p.buildmode;
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    run = false;
                }
            }

            Console.ReadKey();
		}
	}
}