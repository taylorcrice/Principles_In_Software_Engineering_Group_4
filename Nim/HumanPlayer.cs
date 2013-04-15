using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class HumanPlayer : PlayerInterface
    {

        public void move()
        {
            Console.WriteLine("Enter the row you would like to remove from");
            bool getValidInput = false;
            int row = 0;

            while (!getValidInput)
            {
                try
                {
                    row = Convert.ToInt32(Console.ReadLine());
                    if (row > 0 && row <= GameBoard.NUM_ROWS)
                    {
                        getValidInput = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Enter the row you would like to remove from");
                    getValidInput = false;
                }
            }
            Console.WriteLine("Enter the number of pieces you would like to remove");
            getValidInput = false;
            while (!getValidInput)
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
                    getValidInput = false;
                }
                getValidInput = game.moveCheck(row, count);
            }
        }
    }
}
