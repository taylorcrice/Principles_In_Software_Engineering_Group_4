using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class GameBoard
    {
        Row[] rows;
        public const int NUM_ROWS = 3;


        public int[] boardState()
        {
            int[] returnValue;
            returnValue = new int[NUM_ROWS];
            for(int i=0;i<NUM_ROWS;i++)
            {
                returnValue[i] = rows[i].numberOfPieces;
            }
            return returnValue;
      
        }

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
