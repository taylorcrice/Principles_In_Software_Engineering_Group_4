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

        static public void init()
        {
            uniqueMove = new List<TurnData>();
            for (int row1 = 0; row1 <= GameBoard.ROW1_SIZE; row1++)
            {
                for (int row2 = 0; row2 <= GameBoard.ROW2_SIZE; row2++)
                {
                    for (int row3 = 0; row3 <= GameBoard.ROW3_SIZE; row3++)
                    {
                        int[] board = {row1,row2,row3};
                        uniqueMove.Add(new TurnData(board, 0));
                    }
                }
            }
        }

        static public void smartMove(GameBoard game)
        {
            //dummy initializations
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
                game.updateBoard(uniqueMove[index].board);
            }
            else
            {
                randMove(game);
            }
        }

        static public void randMove(GameBoard game)
        {
            bool moveMade = false;
            var rand = new Random();
            while (!moveMade)
            {
                int randRow,randNumPieces;
                randRow = rand.Next(0, GameBoard.NUM_ROWS);
                int[] currentBoardState = { game.row1, game.row2, game.row3 };
                if (currentBoardState[randRow] > 0)
                {
                    randNumPieces = rand.Next(1, currentBoardState[randRow] +1);

                    moveMade = game.moveCheck(randRow+1, randNumPieces);
                }
            }
        }

        public static void analyzeData(List<TurnData> data)
        {
            for (int i = 0; i < uniqueMove.Count; i++)
            {
                bool dataExists = false;
                float percentage = 0;
                for (int j = 0; j < data.Count; j++)
                {
                    if (uniqueMove[i].board[0] == data[j].board[0] && uniqueMove[i].board[1] == data[j].board[1] && uniqueMove[i].board[2] == data[j].board[2])
                    {
                        percentage += data[j].percentage;
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
