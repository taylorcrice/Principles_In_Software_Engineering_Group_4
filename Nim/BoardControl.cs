using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Nim
{
    class BoardControl
    {
        public static void updateBoard(int[] board)
        {
            GameBoard.row1 = board[0];
            GameBoard.row2 = board[1];
            GameBoard.row3 = board[2];
            GameBoard.turnCount++;
            BoardData.saveData(GameBoard.getBoardState(),GameBoard.turnCount);
        }

        public static void resetBoard()
        {
            GameBoard.gameover = false;
            GameBoard.row1 = GameBoard.ROW1_SIZE;
            GameBoard.row2 = GameBoard.ROW2_SIZE;
            GameBoard.row3 = GameBoard.ROW3_SIZE;
            GameBoard.turnCount = 0;
            int[] board = { GameBoard.row1, GameBoard.row2, GameBoard.row3 };
        }
    }
}
