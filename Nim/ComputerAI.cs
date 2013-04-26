﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerAI : PlayerInterface
    {
        public void move()
        {
            //dummy initializations
            float currentMax = -1.5f;
            int index =-1;

            //this isn't right
            List<TurnData> validMoveData = BoardValidation.getValidBoardState();
            for (int i = 0; i < validMoveData.Count; i++)
            {
                if (validMoveData[i].percentage > currentMax && currentMax != 0)
                {
                    index = i;
                    currentMax = validMoveData[i].percentage;
                }
            }
            if (currentMax != 0)
            {
                BoardControl.updateBoard(validMoveData[index].board);
            }
            else
            {
                randMove();
            }
        }

        static public void randMove()
        {            
            
            int[] boardStateAfterMove = null;
            bool validMove = (boardStateAfterMove != null);

            do
            {
                Random rand = new Random();
                //fix this logic later
                int randRow, randNumPieces;
                randRow = rand.Next(1, GameBoard.NUM_ROWS + 1);
                randNumPieces = rand.Next(1, GameBoard.rows[GameBoard.NUM_ROWS].maxRowSize);

                boardStateAfterMove = BoardValidation.validateMove(randRow, randNumPieces);
                validMove = (boardStateAfterMove != null);
            }
            while (!validMove) ;
            BoardControl.updateBoard(boardStateAfterMove);
        }

        
    }
}
