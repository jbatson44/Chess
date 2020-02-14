using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pair
    {
        public Pair(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int row;
        public int col;
    }
}
