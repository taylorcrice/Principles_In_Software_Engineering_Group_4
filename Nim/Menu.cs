using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Menu
    {
        Game game;
        public Menu()
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
                    game = new Game();
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
                        game = new Game();
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
            game = new Game();
            game.Print();
            while (!game.gameover)
            {
                Console.WriteLine("Enter the row you would like to remove from");
                bool getValidInput = false;
                int row = 0;

                while (!getValidInput)
                {
                    try
                    {
                        row = Convert.ToInt32(Console.ReadLine());
                        if (row < 4 && row > 0)
                        {
                            getValidInput = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("Enter the row you would like to remove from");
                        game.Print();
                        getValidInput = false;
                    }
                }
                Console.WriteLine("Enter the number of pieces you would like to remove");
                getValidInput = false;
                while (!getValidInput)
                {
                    int count =0;
                    try
                    {
                        count = Convert.ToInt32(Console.ReadLine());
                        //check count
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("Enter the number of pieces you would like to remove");
                        game.Print();
                        getValidInput = false;
                    }
                    getValidInput = game.moveCheck(row, count);
                }
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


    }
}