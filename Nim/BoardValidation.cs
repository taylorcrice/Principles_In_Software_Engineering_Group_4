using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardValidation
    {
        public static bool gameoverCheck(int[] board)
        {
            return (board[0] + board[1] + board[2]) <= 0;
        }

        public static int[] validateMove(int row, int count)
        {
            int[] boardState = { GameBoard.Board.row1, GameBoard.Board.row2, GameBoard.Board.row3 };
            bool valid = false;
            switch (row)
            {
                case 1:
                    valid = (boardState[0] - count) >= 0;
                    if (valid)
                    {
                      boardState[0] = boardState[0] - count;
                    }
                    break;
                case 2:
                    valid = (boardState[1] - count) >= 0;
                    if (valid)
                    {
                      boardState[1] = boardState[0] - count;
                    }
                    break;
                case 3:
                    valid = (boardState[2] - count) >= 0;
                    if (valid)
                    {
                      boardState[2] = boardState[0] - count;
                    }
                    break;
            }
            if (count == 0)
            {
                valid = false;
            }
            if (!valid)
            {
                boardState = null;
            }
            return boardState;
        }
    }
}
