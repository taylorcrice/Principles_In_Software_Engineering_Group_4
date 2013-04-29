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
