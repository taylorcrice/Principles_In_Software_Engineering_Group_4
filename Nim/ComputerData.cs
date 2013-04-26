using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerData
    {
        public List<TurnData> uniqueMove { get; set; }

        public ComputerData()
        {
            uniqueMove = new List<TurnData>();
            for (int row1 = 0; row1 <= GameBoard.rows[0].maxRowSize; row1++)
            {
                for (int row2 = 0; row2 <= GameBoard.rows[1].maxRowSize; row2++)
                {
                    for (int row3 = 0; row3 <= GameBoard.rows[2].maxRowSize; row3++)
                    {
                        int[] board = { row1, row2, row3 };
                        uniqueMove.Add(new TurnData(board, 0));
                    }
                }
            }
        }

        public void analyzeData(BoardData boardData)
        {
            List<TurnData> previousGameData = boardData.gameData;
            for (int i = 0; i < uniqueMove.Count; i++)
            {
                bool dataExists = false;
                float percentage = 0;
                for (int j = 0; j < previousGameData.Count; j++)
                {
                    if (uniqueMove[i].board[0] == previousGameData[j].board[0] && uniqueMove[i].board[1] == previousGameData[j].board[1] && uniqueMove[i].board[2] == previousGameData[j].board[2])
                    {
                        percentage += previousGameData[j].percentage;
                        dataExists = true;
                    }
                }
                if (dataExists)
                {
                    percentage += uniqueMove[i].percentage * uniqueMove[i].turn;
                    uniqueMove[i].turn++;
                    uniqueMove[i].percentage = percentage / uniqueMove[i].turn;
                }
            }
        }
    }
}
