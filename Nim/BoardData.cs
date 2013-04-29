using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardData
    {
        public List<TurnData> gameData { get; set; }
        public List<TurnData> uniqueMoves { get; set; }

        public BoardData(GameBoard board)
        {
            gameData = new List<TurnData>();

            uniqueMoves = new List<TurnData>();
            for (int row1 = 0; row1 <= board.rows[0].maxRowSize; row1++)
            {
                for (int row2 = 0; row2 <= board.rows[1].maxRowSize; row2++)
                {
                    for (int row3 = 0; row3 <= board.rows[2].maxRowSize; row3++)
                    {
                        int[] boardSet = { row1, row2, row3 };
                        uniqueMoves.Add(new TurnData(boardSet, 0));
                    }
                }
            }
        }

        public void evaluateData()
        {
            int numerator, denominator;
            denominator = gameData.Count / 2;
            numerator = denominator;
            for (int i = gameData.Count - 1; i >= 0; i--)
            {
                numerator *= -1;
                gameData[i].percentage = (float)numerator / (float)denominator;
                if (numerator > 0)
                {
                    numerator--;
                }
            }
            gameData[0].percentage = 0.0f;
        }

        public  void saveData(int[] board, int turnCount)
        {
            gameData.Add(new TurnData(board, turnCount));
        }

        public void resetData()
        {
            gameData = new List<TurnData>();
        }

        public void analyzeData()
        {
            List<TurnData> previousGameData = gameData;
            for (int i = 0; i < uniqueMoves.Count; i++)
            {
                bool dataExists = false;
                float percentage = 0;
                for (int j = 0; j < previousGameData.Count; j++)
                {
                    if (uniqueMoves[i].board[0] == previousGameData[j].board[0] && uniqueMoves[i].board[1] == previousGameData[j].board[1] && uniqueMoves[i].board[2] == previousGameData[j].board[2])
                    {
                        percentage += previousGameData[j].percentage;
                        dataExists = true;
                    }
                }
                if (dataExists)
                {
                    percentage += uniqueMoves[i].percentage * uniqueMoves[i].turn;
                    uniqueMoves[i].turn++;
                    uniqueMoves[i].percentage = percentage / uniqueMoves[i].turn;
                }
            }
        }
    }
}
