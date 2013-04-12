using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class TurnData
    {
        public int[] board { get; set; }
        public int turn { get; set; }
        public float percentage { get; set; }
        public TurnData(int[] b, int t)
        {
            board = b;
            turn = t;
            percentage = 0;
        }
    }
}
