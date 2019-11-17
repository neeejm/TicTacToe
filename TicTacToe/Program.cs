using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<char>();
            var player = 1;
            int boxIndex;
            bool replay = true;

            Console.WriteLine("\n\n\tWELCOME\n\tTO\n\tTIC-TAC-TOE");
            Console.WriteLine("\n\n\n\tPress \"Enter\" ENJOY ..\n\n");
            Console.ReadKey();
            Console.Clear();
            while (replay)
            {
                do
                {
                    Game.side.Clear();

                    Console.Write("\n>>> Player, choose ur side : ");
                    string tmp = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(tmp))
                        Game.side.Add(Char.ToUpper(Convert.ToChar(tmp)));
                    else
                        Game.side.Add('i'); //give invalid char to hundle exception of an empty input
                }
                while (Game.side[0] != Grid.X && Game.side[0] != Grid.O);

                Game.side = Game.Side(Game.side);

                //PVP 
                Grid.Reset(boxes);
                for (var i = 0; i < Grid.size; ++i)
                {
                    Console.WriteLine("\n****************************");
                    Console.WriteLine("Player 1 : {0} - Player 2 : {1}", Game.side[0], Game.side[1]);
                    Console.WriteLine("****************************");
                    Grid.Table(boxes);

                    bool isValid;
                    //Console.WriteLine("end");
                    do
                    {
                        Console.Write("\n--> Player {0} choose ur play : ", player);

                        string tmp = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(tmp))
                            boxIndex = Convert.ToInt32(tmp);
                        else
                            boxIndex = 0; //give invalid index to hundle exception of an empty input

                        //Console.WriteLine(boxIndex);
                        isValid = Grid.Valid(boxes, boxIndex - 1);
                        //Console.WriteLine(isValid);
                    }
                    while (isValid == false);

                    boxes[boxIndex - 1] = Game.side[player - 1];
                    Console.Clear();

                    if (Game.Result(boxes))
                    {
                        Console.WriteLine("\n\tPlayer {0} WON\n", player);
                        break;
                    }

                    if (player == 1)
                        player++;
                    else
                        player--;
                }

                if (!Game.Result(boxes))
                {
                    Console.WriteLine("\n\tIts a DRAW\n");
                }

                string input;
                do
                {
                    Console.WriteLine("Wanna play again (y/n): ");
                    input = Console.ReadLine();
                }
                while (input.ToLower() != "y" && input.ToLower() != "n");
                if (input.ToLower() == "n")
                    replay = false;
            }


            Console.Write("Press \"Enter\" To exit ...");
            Console.Read();
        }
    }
}
