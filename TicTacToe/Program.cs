using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<char>() { 'a', 'b', 'O', '0', 'O', '0', 'O', '0', '0' };
            var player = 1;
            int boxIndex;

            Console.WriteLine("\n\n\tWELCOME\n\tTO\n\tTIC-TAC-TOE");
            Console.WriteLine("\n\n\n\tPress \"Enter\" ENJOY ..\n\n");
            Console.ReadKey();
            Console.Clear();

            var side = new List<char>();
            do
            {
                Console.Write("\n>>> Player, choose ur side : ");
                side.Add(Char.ToUpper(Convert.ToChar(Console.ReadLine())));
                Console.WriteLine(side[0]);
            }
            while (side[0] != Grid.X && side[0] != Grid.O);

            side = Game.Side(side);

            //PVP 
            Grid.Reset(boxes);
            for (var i = 0; i < Grid.size; ++i)
            {
                Console.WriteLine("\n****************************");
                Console.WriteLine("Player 1 : {0} - Player 2 : {1}", side[0], side[1]);
                Console.WriteLine("****************************");
                Grid.Table(boxes);

                bool isValid;
                //Console.WriteLine("end");
                do
                {
                    Console.Write("\n--> Player {0} choose ur play : ", player);
                    boxIndex = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine(boxIndex);
                    isValid = Grid.Valid(boxes, boxIndex-1);
                    //Console.WriteLine(isValid);
                }
                while (isValid == false);

                boxes[boxIndex - 1] = side[player - 1];
                Console.Clear();

                if (Game.Result(boxes))
                {
                    Console.WriteLine("n\tPlayer {0} WON\n", player);
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
        }
    }
}
