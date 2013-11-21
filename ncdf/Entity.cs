using System;

namespace ncdf
{
	class Entity
	{
		protected internal int id;
		protected internal char ascii;
		protected internal ConsoleColor backcolor;
		protected internal ConsoleColor forecolor;

        protected internal int x, y;

		public Entity() {
			this.ascii = 'E';
			backcolor = ConsoleColor.Black;
			forecolor = ConsoleColor.White;
		}

		protected internal tile current_tile
		{
			get
			{
				return tiles.get(x,y);
			}
		}

        public void SetPos(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetXY()
        {
            y = 0;
            x = 0;
            while (id - (y * tiles.width - 1) > tiles.width)
            {
                y++;
            }
            x = id - y * tiles.width;
            return new int[] { x, y };
        }

        public int[] GetPos()
        {
            return new int[] { x, y };
        }

        public virtual void Output()
        {
            var sx = Console.CursorLeft;
            var sy = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = forecolor;
            Console.BackgroundColor = backcolor;
            Console.Write(ascii);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(sx, sy);
        }
	}

	static class Enteties
	{
		static Entity[] EntityTable;

		public static int width;
		public static int height;

		public static void init()
		{
			int size = width*height;
			EntityTable = new Entity[size];
		}

        public static void set(int n, Entity e)
        {
			EntityTable[n] = e;
			e.id = n;
            e.GetXY();
		}

        public static Entity get(int n, Entity e)
        {
			return EntityTable[n];
		}

        public static int getn(int x, int y)
        {
			return y*width + x;
		}

        public static void set(int x, int y, Entity e)
        {
			set(getn(x,y),e);
		}

        public static Entity get(int x, int y, Entity e)
        {
			return get(getn(x,y),e);
		}

        public static void OutputEnteties()
        {
            foreach (Entity e in EntityTable)
            {
                if(e != null)
                {
                    e.Output();
                }
            }
        }
	}
}