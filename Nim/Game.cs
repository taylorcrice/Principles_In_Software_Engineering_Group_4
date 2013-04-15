using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Game
    {
        GameBoard game;
        PlayerInterface player1, player2;
        public Game()
        {
            ComputerAI.init();
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("Type P for player vs. computer");
                Console.WriteLine("Type C for computer vs. computer");
                Console.WriteLine("Type E to exit");
                string input = Console.ReadLine();
                ///Player vs Computer
                if (input == "p")
                {
                    gameLoopPvC();
                }

                 ///Computer vs Computer
                else if (input == "c")
                {
                    game = new GameBoard();
                    int timesToPlay=0;
                    bool getValidInput = true;
                    while (getValidInput)
                    {
                        Console.WriteLine("How many games would you like the computers to play");
                        try
                        {
                            timesToPlay = Convert.ToInt32(Console.ReadLine());
                            getValidInput = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Input");
                            getValidInput = true;
                        }
                    }
                    //Gameplay
                    for (int i = 0; i < timesToPlay; i++)
                    {
                        while (!game.gameover)
                        {
                            //Console.WriteLine("----------------");
                            ComputerAI.smartMove(game);
                            //game.Print();
                        }
                        game.evaluateData();
                        ComputerAI.analyzeData(game.data);
                        game = new GameBoard();
                    }
                }
                else if (input == "e")
                {
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Type P for player vs. computer");
                    Console.WriteLine("Type C for computer vs. computer");
                }
            }
        }

        void gameLoopPvC()
        {
            game = new GameBoard();
            game.Print();
            while (!game.gameover)
            {
                
                game.Print();
                //computer moves
                if (!game.gameover)
                {
                    Console.WriteLine("The computer has moved.");
                    ComputerAI.smartMove(game);
                    game.Print();
                }
            }
            game.evaluateData();
            ComputerAI.analyzeData(game.data);
        }

        public void evaluateData(GameBoard)
        {
            int numerator, denominator;
            denominator = data.Count / 2;
            numerator = denominator;
            for (int i = data.Count - 1; i >= 0; i--)
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