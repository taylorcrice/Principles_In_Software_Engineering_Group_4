using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Game
    {
        PlayerInterface player1, player2;
        ComputerData computerData ;
        GameBoard board;
        BoardData boardData;
        public Game()
        {
            bool gameRunning = true;
            ComputerData computerData = new ComputerData();
            GameBoard board = new GameBoard();
            BoardData boardData = new BoardData();
            while (gameRunning)
            {
                Console.WriteLine("Type P for player vs. computer");
                Console.WriteLine("Type C for computer vs. computer");
                Console.WriteLine("Type E to exit");

                int numberOfGamesToPlay = 1;
                string input = Console.ReadLine();
                if (input == "P")
                {
                    player1 = new HumanPlayer();
                    player2 = new ComputerAI();
                }
                else if (input == "C")
                {
                    player1 = new ComputerAI();
                    player2 = new ComputerAI();
                    Console.WriteLine("How many games would you Like to play?");
                    bool validInput = false;
                    do
                    {
                        try
                        {
                            numberOfGamesToPlay = Convert.ToInt32(Console.ReadLine());
                            validInput = true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Input.");
                            validInput = false;
                        }
                    } while (!validInput);
                }
                else if (input == "E")
                {
                    numberOfGamesToPlay = 0;
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Type P for player vs. computer");
                    Console.WriteLine("Type C for computer vs. computer");
                }
                for (int i = 0; i < numberOfGamesToPlay; i++)
                {
                    gameLoop();
                }
            }
        }

        private void gameLoop()
        {
            do
            {
                player1.move();
                ViewControl.Print();
                if (!BoardValidation.gameoverCheck(board.getBoardState()))
                {
                    player2.move();
                }
                ViewControl.Print();
            } while (!BoardValidation.gameoverCheck(board.getBoardState()));
            boardData.evaluateData();
            computerData.analyzeData(boardData);
            board = new GameBoard();
        }

        
    }
}