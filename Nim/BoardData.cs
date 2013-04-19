using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class BoardData
    {
        public List<TurnData> gameData { get; set; }

        public BoardData()
        {
            gameData = new List<TurnData>();
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
    }
}
