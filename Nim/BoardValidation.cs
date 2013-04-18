using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardValidation
    {
        public static bool gameoverCheck()
        {
            return (GameBoard.row1 + GameBoard.row2 + GameBoard.row3) <= 0;
        }

        public static int[] validateMove(int row, int count)
        {
            int[] boardState = { GameBoard.row1, GameBoard.row2, GameBoard.row3 };
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
                      boardState[1] = boardState[1] - count;
                    }
                    break;
                case 3:
                    valid = (boardState[2] - count) >= 0;
                    if (valid)
                    {
                      boardState[2] = boardState[2] - count;
                    }
                    break;
            }
            valid = count != 0;
            if (!valid)
            {
                boardState = null;
            }
            return boardState;
        }

        public static List<TurnData> getValidBoardState()
        {
            int[] currentBoardState = GameBoard.getBoardState();
            List<TurnData> validMoveData = new List<TurnData>();
            for (int i = 0; i < ComputerData.uniqueMove.Count; i++)
            {
                if (ComputerData.uniqueMove[i].board[0] == currentBoardState[0] && ComputerData.uniqueMove[i].board[1] == currentBoardState[1] && ComputerData.uniqueMove[i].board[2] < currentBoardState[2]
                    || ComputerData.uniqueMove[i].board[0] == currentBoardState[0] && ComputerData.uniqueMove[i].board[2] == currentBoardState[2] && ComputerData.uniqueMove[i].board[1] < currentBoardState[1]
                    || ComputerData.uniqueMove[i].board[1] == currentBoardState[1] && ComputerData.uniqueMove[i].board[2] == currentBoardState[2] && ComputerData.uniqueMove[i].board[0] < currentBoardState[0])
                {
                    validMoveData.Add(ComputerData.uniqueMove[i]);
                }
            }
            return validMoveData;
        }
    }
}
