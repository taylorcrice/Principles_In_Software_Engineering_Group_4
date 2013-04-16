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
        public static int row1{get; set;}
        public static int row2{get; set;}
        public static int row3{get; set;}
        public static int turnCount{get; set;}
        public static bool gameover{get; set;}

        public static int[] getBoardState()
        {
            return new int[] { row1, row2, row3 };
        }
        
        private static GameBoard BOARD = new GameBoard();

        public static GameBoard Board
        {
            get { return BOARD; }
            set { BOARD = value; }
        }

        public static void initBoard()
        {
            gameover = false;
            row1 = ROW1_SIZE;
            row2 = ROW2_SIZE;
            row3 = ROW3_SIZE;
            turnCount = 0;
        }
    }
}
