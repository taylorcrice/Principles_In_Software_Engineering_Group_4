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

        //split into two methodes
        //consider wrapping row features
        //change function higher up
        public static int[] validateMove(int row /*make this type safe, make enum? */, int piecesToRemove)
        {
            //test
            int[] boardState = { GameBoard.row1, GameBoard.row2, GameBoard.row3 };
            bool valid = false;
            valid = (boardState[row-1] - piecesToRemove) >= 0;
            if (valid)
            {
                boardState[row - 1] = boardState[row - 1] - piecesToRemove;
            }

            valid = piecesToRemove >= 0;
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
