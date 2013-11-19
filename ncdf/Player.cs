using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    class Player
    {
        int x, y;
        int lx, ly;
        tile current_tile
        {
            get
            {
                return tiles.get(x, y);
            }
        }

        internal bool buildmode = false;

        public void SetLastPos(int x, int y)
        {
            this.lx = x;
            this.ly = y;
        }

        public void SetPos(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetPos()
        {
            return new int[] { x, y };
        }

        public void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    if(buildmode && y - 1 >= 0 && y - 1 < tiles.height)
                    {
                        tiles.set(x, y - 1, new tile_grass());
                    }
                    if(MovementCheckY(y - 1))
                    {
                        lx = x;
                        ly = y;
                        y = y - 1;
                    }
                    break;
                case 1:
                    if (buildmode && x + 1 >= 0 && x + 1 < tiles.width)
                    {
                        tiles.set(x + 1, y, new tile_grass());
                    }
                    if (MovementCheckX(x + 1))
                    {
                        lx = x;
                        ly = y;
                        x = x + 1;
                    }
                    break;
                case 2:
                    if (buildmode && y + 1 >= 0 && y + 1 < tiles.height)
                    {
                        tiles.set(x, y + 1, new tile_grass());
                    }
                    if (MovementCheckY(y + 1))
                    {
                        lx = x;
                        ly = y;
                        y = y + 1;
                    }
                    break;
                case 3:
                    if (buildmode && x - 1 >= 0 && x - 1 < tiles.width)
                    {
                        tiles.set(x - 1, y, new tile_grass());
                    }
                    if (MovementCheckX(x - 1))
                    {
                        lx = x;
                        ly = y;
                        x = x - 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private bool MovementCheckY(int p)
        {
            return p >= 0 && p < tiles.width && tiles.get(x,p) != null && (tiles.get(x,p).type == 1 || tiles.get(x,p).type == 4);
        }

        private bool MovementCheckX(int p)
        {
            return p >= 0 && p < tiles.width && tiles.get(p, y) != null && (tiles.get(p, y).type == 1 || tiles.get(p, y).type == 4);
        }

        public string Values
        {
            get
            {
                return String.Format("x:{0},y:{1} lx:{2},ly:{3}", x, y, lx, ly);
            }
        }

        public void Output()
        {
            if (tiles.get(lx, ly) != null) { tiles.get(lx, ly).Output(); }
            var sx = Console.CursorLeft;
            var sy = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.Write("@");
            Console.SetCursorPosition(sx, sy);
        }
    }
}
