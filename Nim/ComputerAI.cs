using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    static class ComputerAI
    {
        static List<TurnData> data = new List<TurnData>();
        static List<TurnData> uniqueMove;
        //static public void move(Game game);

        static public void init()
        {
            uniqueMove = new List<TurnData>();
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 6; b++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        int[] board = {a,b,c};
                        uniqueMove.Add(new TurnData(board, 0));
                    }
                }
            }
        }

        static public void smartMove(Game game)
        {
            float currentMax = -1.5f;
            int index =-1;
            int[] currentBoardState = {game.row1, game.row2, game.row3};
            for (int i = 0; i < uniqueMove.Count; i++)
            {
                if (uniqueMove[i].percentage > currentMax)
                {
                    if (uniqueMove[i].board[0] == currentBoardState[0] && uniqueMove[i].board[1] == currentBoardState[1] && uniqueMove[i].board[2] < currentBoardState[2]
                        || uniqueMove[i].board[0] == currentBoardState[0] && uniqueMove[i].board[2] == currentBoardState[2] && uniqueMove[i].board[1] < currentBoardState[1]
                        || uniqueMove[i].board[1] == currentBoardState[1] && uniqueMove[i].board[2] == currentBoardState[2] && uniqueMove[i].board[0] < currentBoardState[0])
                    {



                        index = i;
                        currentMax = uniqueMove[i].percentage;
                    }

                }
            }
            if (currentMax != 0)
            {
                game.computerMove(uniqueMove[index].board);
            }
            else
            {
                randMove(game);
            }
        }

        static public void randMove(Game game)
        {
            bool moveMade = false;
            var rand = new Random();
            while (!moveMade)
            {
                int a,b;
                a = rand.Next(0, 3);
                int[] currentBoardState = { game.row1, game.row2, game.row3 };
                if (currentBoardState[a] > 0)
                {
                    b = rand.Next(1, currentBoardState[a] +1);

                    moveMade = game.moveCheck(a+1, b);
                }
            }
        }

        public static void analyzeData(List<TurnData> data)
        {
            for (int i = 0; i < uniqueMove.Count; i++)
            {
                bool dataExists = false;
                float percentage = 0;
                for (int x = 0; x < data.Count; x++)
                {
                    if (uniqueMove[i].board[0] == data[x].board[0] && uniqueMove[i].board[1] == data[x].board[1] && uniqueMove[i].board[2] == data[x].board[2])
                    {
                        percentage += data[x].percentage;
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
