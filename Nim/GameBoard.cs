using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Nim
{
    class GameBoard
    {
        private Row[] rows { get; set; }
        private const int NUM_ROWS = 3;
        private BoardValidation validator;

        private int myVar;
	

        public bool gameover {get{ return validator.gameoverCheck(getBoardState()); } set;}


        public int[] getBoardState()
        {
            int[] returnValue;
            returnValue = new int[NUM_ROWS];
            for(int i=0;i<NUM_ROWS;i++)
            {
                returnValue[i] = rows[i].numberOfPieces;
            }
            return returnValue;
      
        }

        //merge with update board method in board state class
        public bool alterBoardState(int rowNumber /*make this type safe, make enum? */, int piecesToRemove)
        {
            bool alterationSuccessful= false;                   
            if (validator.validateBoardMove(rowNumber, piecesToRemove, getBoardState()))
            {
                rows[rowNumber - 1].numberOfPieces = rows[rowNumber - 1].numberOfPieces - piecesToRemove;
                alterationSuccessful = true;
            }
           
            return alterationSuccessful;
        }

        public int turnCount{get; set;}
        private BoardData boardData = new BoardData();

        public GameBoard()
        {
            gameover = false;
            rows = new Row [NUM_ROWS];
            rows[0] = new Row(3);
            rows[1] = new Row(5);
            rows[2] = new Row(7);
            turnCount = 0;
        }

        public void updateBoard(int[] board)
        {
            Debug.Assert(rows.Length == board.Length);
            for (int i = 0; i < board.Length; i++)
            {
                rows[i].numberOfPieces = board[i];
            }
            turnCount++;
            boardData.saveData(getBoardState(), turnCount);
        }
    }
}
