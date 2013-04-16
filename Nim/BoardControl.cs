using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Nim
{
    class BoardControl
    {
        public void updateBoard(int[] board)
        {
            GameBoard.Board.row1 = board[0];
            GameBoard.Board.row2 = board[1];
            GameBoard.Board.row3 = board[2];
            GameBoard.Board.turnCount++;
        }

        public void resetBoard()
        {
            GameBoard.Board.gameover = false;
            GameBoard.Board.row1 = GameBoard.ROW1_SIZE;
            GameBoard.Board.row2 = GameBoard.ROW2_SIZE;
            GameBoard.Board.row3 = GameBoard.ROW3_SIZE;
            GameBoard.Board.turnCount = 0;
            int[] board = { GameBoard.Board.row1, GameBoard.Board.row2, GameBoard.Board.row3 };
        }
    }
}
