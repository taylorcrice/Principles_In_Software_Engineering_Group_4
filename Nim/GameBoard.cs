using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class GameBoard
    {
        public const int ROW1_SIZE = 3;
        public const int ROW2_SIZE = 5;
        public const int ROW3_SIZE = 7;
        public const int NUM_ROWS = 3;


        public int row1
        {
            get { return BOARD.row1; }
            set { BOARD.row1 = value; }
        }
        public int row2
        {
            get { return BOARD.row2; }
            set { BOARD.row2 = value; }
        }
        public int row3
        {
            get { return BOARD.row3; }
            set { BOARD.row3 = value; }
        }
        public int turnCount
        {
            get { return BOARD.turnCount; }
            set { BOARD.turnCount = value; }
        }
        public bool gameover
        {
            get { return BOARD.gameover; }
            set { BOARD.gameover = value; }
        }

        public int[] getBoardState()
        {
            return new int[] { row1, row2, row3 };
        }
        
        private static GameBoard BOARD = new GameBoard();

        public static GameBoard Board
        {
            get { return BOARD; }
            set { BOARD = value; }
        }

        private GameBoard()
        {
            BOARD.gameover = false;
            BOARD.row1 = ROW1_SIZE;
            BOARD.row2 = ROW2_SIZE;
            BOARD.row3 = ROW3_SIZE;
            BOARD.turnCount = 0;
            int[] board = { row1, row2, row3 };
        }
    }
}
