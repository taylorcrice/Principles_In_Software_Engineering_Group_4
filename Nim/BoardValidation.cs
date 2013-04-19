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

        //merge with update board method in board state class
        public int[] alterBoardState(int row /*make this type safe, make enum? */, int piecesToRemove)
        {
            if (piecesToRemove > 0)//during the second round of play the computer always takes 0... was happening before the switch was refactored
            {
                if (validateBoardAfterMove(row, piecesToRemove))
                {
                    boardState[row - 1] = boardState[row - 1] - piecesToRemove;
                }
            }
            else
            {
                boardState = null;
            }
            return boardState;
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
