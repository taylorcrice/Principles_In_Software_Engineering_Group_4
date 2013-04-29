using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerAI : PlayerInterface
    {
        private BoardValidation validator;

        public ComputerAI(GameBoard board)
        {
            validator = new BoardValidation(board.rows);
        }


        public void move(GameBoard board)
        {
            //dummy initializations
            float currentMax = -1.5f;
            int index =-1;

            //this isn't right
            List<TurnData> validMoveData = validator.getValidBoardState(board.getBoardState());
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
                board.updateBoard(validMoveData[index].board);
            }
            else
            {
                randMove(board);
            }
        }

        public void randMove(GameBoard board)
        {            
            
            int[] boardStateAfterMove = null;
            bool validMove = (boardStateAfterMove != null);

            do
            {
                Random rand = new Random();
                //fix this logic later
                int randRow, randNumPieces;
                randRow = rand.Next(1, GameBoard.NUM_ROWS+1);
                randNumPieces = rand.Next(1, board.rows[randRow-1].maxRowSize);
                validMove = board.alterBoardState(randRow, randNumPieces);
            }
            while (!validMove) ;
        }        
    }
}
