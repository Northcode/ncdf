using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    class Player : Unit
    {
        internal bool buildmode = false;

        public Player() {
            this.ascii = '@';
        }

        public string Values
        {
            get
            {
                return String.Format("x:{0},y:{1} lx:{2},ly:{3}", x, y, lx, ly);
            }
        }
    }
}
