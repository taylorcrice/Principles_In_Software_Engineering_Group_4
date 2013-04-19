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


        public int[] boardState
        {
            get { return new int[3] { row1, row2, row3 }; }
      
        }
        
        
        public int row1{get; set;}
        public int row2{get; set;}
        public int row3{get; set;}
        public int turnCount{get; set;}
        public bool gameover{get; set;}
        private BoardData boardData = new BoardData();

        public int[] getBoardState()
        {
            return new int[] { row1, row2, row3 };
        }

        public GameBoard()
        {
            gameover = false;
            row1 = 3;
            row2 = 5;
            row3 = 7;
            turnCount = 0;
        }

        public void updateBoard(int[] board)
        {
            row1 = board[0];
            row2 = board[1];
            row3 = board[2];
            turnCount++;
            boardData.saveData(getBoardState(), turnCount);
        }
    }
}
