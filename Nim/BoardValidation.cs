using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardValidation
    {
        public List<TurnData> uniqueMoves { get; set; }

        public BoardValidation(Row[] rows)
        {
            uniqueMoves = new List<TurnData>();
            for (int row1 = 0; row1 <= rows[0].maxRowSize; row1++)
            {
                for (int row2 = 0; row2 <= rows[1].maxRowSize; row2++)
                {
                    for (int row3 = 0; row3 <= rows[2].maxRowSize; row3++)
                    {
                        int[] board = { row1, row2, row3 };
                        uniqueMoves.Add(new TurnData(board, 0));
                    }
                }
            }
        }

        public bool gameoverCheck(int[] boardState)
        {
            return (boardState[0] + boardState[1] + boardState[3]) <= 0;
        }

        //consider merging with update board in GameBoard class
        public bool validateBoardMove(int rowNum, int piecesToRemove, int[] boardState)
        {
            bool validMove = false;
            if (rowNum > 0 && rowNum < boardState.Length)
            {
                validMove = boardState[rowNum - 1] - piecesToRemove >= 0 && piecesToRemove > 0;
            }
            return validMove;
        }


        public List<TurnData> getValidBoardState(int[] boardState)
        {
            int[] currentBoardState = boardState;
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
