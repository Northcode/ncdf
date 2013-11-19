using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    class tile
    {
        internal int id;
        internal int type;

        internal char ascii;
        internal ConsoleColor backcolor;
        internal ConsoleColor forecolor;

        public tile()
        {
            this.ascii = ' ';
            this.forecolor = ConsoleColor.Gray;
            this.backcolor = ConsoleColor.Black;
            this.type = 0;
        }

        public int[] GetXY()
        {
            int y = 0;
            int x = 0;
            while (id - (y * tiles.width - 1) > tiles.width)
            {
                y++;
            }
            x = id - y * tiles.width;
            return new int[] { x, y };
        }

        public void Output()
        {
            int sx = Console.CursorLeft;
            int sy = Console.CursorTop;
            Console.ForegroundColor = forecolor;
            Console.BackgroundColor = backcolor;
            int[] xy = GetXY();
            Console.SetCursorPosition(xy[0], xy[1]);
            Console.Write(ascii);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(sx, sy);
        }

        public void SetChar(char c)
        {
            ascii = c;
        }

        public tile GetRight()
        {
            return tiles.get(id + 1);
        }

        public tile GetLeft()
        {
            return tiles.get(id - 1);
        }

        public tile GetAbove()
        {
            return tiles.get(id - tiles.width);
        }

        public tile GetBelow()
        {
            return tiles.get(id + tiles.width);
        }

        public void SpreadRight(Random r, int l)
        {
            if (this.GetRight() != null)
            {
                tile t = this.GetRight();
                SpreadTo(r, l, t);
            }
        }

        private void SpreadTo(Random r, int l, tile t)
        {
            t.ascii = this.ascii;
            t.forecolor = this.forecolor;
            t.backcolor = this.backcolor;
            t.type = this.type;
            t.Spread(r, l);
        }

        public void SpreadLeft(Random r, int l)
        {
            if (this.GetLeft() != null)
            {
                tile t = this.GetLeft();
                SpreadTo(r, l, t);
            }
        }

        public void SpreadAbove(Random r, int l)
        {
            if (this.GetAbove() != null)
            {
                tile t = this.GetAbove();
                SpreadTo(r, l, t);
            }
        }

        public void SpreadBelow(Random r, int l)
        {
            if (this.GetBelow() != null)
            {
                tile t = this.GetBelow();
                SpreadTo(r, l, t);
            }
        }

        public void Spread(Random r, int l)
        {
            if (l == 0)
            {
                return;
            }
            int n = r.Next(0, 101);
            if (n > 20)
            {
                if (r.Next(0, 4) > 1)
                {
                    SpreadLeft(r, l - 1);
                }
                if (r.Next(0, 4) > 1)
                {
                    SpreadRight(r, l - 1);
                }
                if (r.Next(0, 4) > 1)
                {
                    SpreadAbove(r, l - 1);
                }
                if (r.Next(0, 4) > 1)
                {
                    SpreadBelow(r, l - 1);
                }
            }
        }
    }

    static class tiles
    {
        static tile[] tileArray;
        public static int width = 40;
        public static int height = 20;

        public static tile get(int x, int y)
        {
            return get(getc(x, y));
        }

        public static tile get(int n)
        {
            if (n >= 0 && n < tileArray.Length)
            {
                return tileArray[n];
            }
            else
            {
                return null;
            }
        }

        public static void set(int n, tile t)
        {
            tileArray[n] = t;
            tileArray[n].id = n;
        }

        public static void set(int x, int y, tile t)
        {
            set(getc(x, y), t);
        }

        static int getc(int x, int y)
        {
            return y * width + x;
        }

        public static void init()
        {
            tileArray = new tile[width * height];
            for (int i = 0; i < tileArray.Length; i++)
            {
                tileArray[i] = new tile();
                tileArray[i].id = i;
            }
        }

        public static void OutputTiles()
        {
            for (int i = 0; i < tileArray.Length; i++)
            {
                if (tileArray[i] != null)
                {
                    tileArray[i].Output();
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
