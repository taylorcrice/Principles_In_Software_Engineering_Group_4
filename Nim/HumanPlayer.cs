using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class HumanPlayer : PlayerInterface
    {

        public void move(GameBoard board)
        {
            Console.WriteLine("Enter the row you would like to remove from");
            bool validInput = false;
            int row = 0;
            int[] boardStateAfterMove;

            do
            {
                try
                {
                    row = Convert.ToInt32(Console.ReadLine());
                    if (row > 0 && row <= GameBoard.NUM_ROWS)
                    {
                        validInput = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Enter the row you would like to remove from");
                    validInput = false;
                }
            }
            while(!validInput);
            Console.WriteLine("Enter the number of pieces you would like to remove");
            do
            {
                int count = 0;
                try
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    //check count
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Enter the number of pieces you would like to remove");
                    validInput = false;
                }
                validInput = board.alterBoardState(row,count);
            }
            while (!validInput);
        }
    }
}
