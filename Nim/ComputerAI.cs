using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    static class ComputerAI
    {
        

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

        
    }
}
