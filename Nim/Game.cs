using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Game
    {
        public int row1 { get; set; }
        public int row2 { get; set; }
        public int row3 { get; set; }
        int turnCount;
        public bool gameover { get; set; }
        public List<TurnData> data { get; set; }
        public const int ROW1_SIZE = 3;
        public const int ROW2_SIZE = 5;
        public const int ROW3_SIZE = 7;
        public const int NUM_ROWS = 3;


        public Game()
        {
            data = new List<TurnData>();
            gameover = false;
            row1 = ROW1_SIZE;
            row2 = ROW2_SIZE;
            row3 = ROW3_SIZE;
            turnCount = 0;
            int[] board = { row1, row2, row3 };
            data.Add(new TurnData(board, turnCount));
        }

        public bool gameoverCheck()
        {
            return (row1 + row2 + row3) <= 0;
        }

        public void Print()
        {
            for (int i = 0; i < row1; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int i = 0; i < row2; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int i = 0; i < row3; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }

        public void computerMove(int[] board)
        {
            row1 = board[0];
            row2 = board[1];
            row3 = board[2];
            gameover = gameoverCheck();
            turnCount++;
            data.Add(new TurnData(board, turnCount));
        }

        public bool moveCheck(int row, int count)
        {
            bool valid = false;
            switch (row)
            {
                case 1:
                    valid = (row1 - count) >= 0;
                    if (valid)
                    {
                        row1 -= count;
                    }
                    break;
                case 2:
                    valid = (row2 - count) >= 0;
                    if (valid)
                    {
                        row2 -= count;
                    }
                    break;
                case 3:
                    valid = (row3 - count) >= 0;
                    if (valid)
                    {
                        row3 -= count;
                    }
                    break;
            }
            if (count == 0)
            {
                valid = false;
            }
            if (valid)
            {
                int[] board = { row1, row2, row3 };
                gameover = gameoverCheck();
                turnCount++;
                data.Add(new TurnData(board, turnCount));
            }
            return valid;
        }

        public void evaluateData()
        {
            int numerator, denominator;
            denominator = data.Count / 2;
            numerator = denominator;
            for (int i = data.Count-1; i >= 0; i--)
            {
                numerator *= -1;
                data[i].percentage = (float)numerator / (float)denominator;
                if (numerator > 0)
                {
                    numerator--;
                }
            }
            data[0].percentage = 0.0f;
        }
    }
}
