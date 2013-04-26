using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ViewControl
    {
        public static void Print()
        {
            int[] boardState = { GameBoard.rows[0].numberOfPieces, GameBoard.rows[1].numberOfPieces, GameBoard.rows[2].numberOfPieces };
            for (int i = 0; i < boardState[0]; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int i = 0; i < boardState[1]; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int i = 0; i < boardState[2]; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
}
