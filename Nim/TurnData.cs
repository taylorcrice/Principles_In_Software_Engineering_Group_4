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
        public TurnData(int[] board, int turn)
        {
            this.board = board;
            this.turn = turn;
            percentage = 0;
        }
    }
}
