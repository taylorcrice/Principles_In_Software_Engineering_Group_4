using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardValidation
    {

        
        public static bool gameoverCheck(int[] boardState)
        {
            return (boardState[0] + boardState[1] + boardState[3]) <= 0;
        }

        //consider merging with update board in GameBoard class
        public bool validateBoardAfterMove(int row, int piecesToRemove)
        {
            bool validAfterMove = false;
            if (boardState != null)//Have to check for null
            {
                validAfterMove = (boardState[row - 1] - piecesToRemove) >= 0;
            }
            return validAfterMove;
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
